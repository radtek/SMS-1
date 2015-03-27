using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Workflow.Base;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Workflow.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;
using System.Transactions;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Entities;
using ServiceStack.Text;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Workflow.Providers
{
    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Fabrik.Common;
    using Bec.TargetFramework.Entities.Enums;

    //Bec.TargetFramework.Entities
    [Serializable]
    public class DbWorkflowProvider : ProviderBase
    {
        private ICacheProvider m_CacheProvider;
        private IClassificationDataLogic m_ClassificationDataLogic;
        public DbWorkflowProvider(ILogger logger, ICacheProvider cacheProvider, IClassificationDataLogic logic)
            : base(logger)
        {
            m_CacheProvider = cacheProvider;
            m_ClassificationDataLogic = logic;
        }

        public IWorkflowContainer Load(IWorkflowContainer emptyContainer, Guid workflowID, int version)
        {
            var workflowContainerBase = CreateContainer(emptyContainer,workflowID, version);

            return workflowContainerBase;
        }
        private ICollection<WorkflowParameter> m_WorkflowParameters;
    
        private ICollection<WorkflowObjectType> m_WorkflowObjectTypes;
        private ICollection<WorkflowCommand> m_WorkflowCommands;
        private ICollection<WorkflowHierarchy> m_WorkflowHierarchy;
        private ICollection<WorkflowRole> m_Role;
        private ICollection<WorkflowClaim> m_RoleClaim;

        public IWorkflowInstance CreateInstance(Guid workflowID, int versionNumber, Guid parentID, List<UserAccountOrganisationDTO> workflowUsers = null)
        {
            var instance = new WorkflowInstanceBase
            {
                Executions = new List<WorkflowInstanceExecutionBase>(),
                ID = Guid.NewGuid(),
                IsActive = true,
                ParentID = parentID,
                WorkflowVersionNumber = versionNumber,
                WorkflowID = workflowID,
                WorkflowInstanceStatusID = WorkflowInstanceStatusIDEnum.New.GetIntValue()
            };

            instance.InstanceSession.SessionStartedOn = DateTime.Now;
            instance.InstanceSession.WorkflowInstanceID = instance.ID;
            instance.InstanceSession.WorkflowInstanceSessionID = Guid.NewGuid();

            if (workflowUsers != null)
            {
                //instance.Restrictions = new List<WorkflowInstanceRestrictionDTO>();

                //workflowUsers.ForEach(
                //    it =>
                //        {
                //            instance.Restrictions.Add(new WorkflowInstanceRestrictionDTO
                //                                          {
                //                                              WorkflowInstanceID = instance.ID,
                //                                              WorkflowID = instance.WorkflowID,
                //                                              WorkflowVersionNumber= instance.WorkflowVersionNumber,
                //                                              UserAccountOrganisationID = it.UserAccountOrganisationID
                //                                          });
                //        });
            }

            return instance;
        }

        public IWorkflowInstance ModifyInstanceStatus(IWorkflowInstance workflowInstance)
        {
            workflowInstance.WorkflowInstanceStatusID = WorkflowInstanceStatusIDEnum.InProgress.GetIntValue();
            
            return workflowInstance;
        }
        private WorkflowContainerBase CreateContainer(IWorkflowContainer emptyContainer, Guid id, int versionNumber)
        {
            var workflowContainerBase = emptyContainer as WorkflowContainerBase;

            string key = id.ToString() + "_" + versionNumber;

            using (
                var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger)
                )
            {
                Data.Workflow workflow = null;

                using (var cacheClient = m_CacheProvider.CreateCacheClient(Logger))
                {
                    workflow = cacheClient.Get<Data.Workflow>(key);

                    if (workflow == null)
                    {
                        scope.DisableProxyAndLazyLoading();

                        workflow =
                            scope.DbContext.Workflows.Include("WorkflowCommands")
                                .Include("WorkflowConditions")
                                .Include("WorkflowHierarchies")
                                .Include("WorkflowMainCompleteConditions")
                                .Include("WorkflowMainExecuteCommands")
                                .Include("WorkflowMainParameters")
                                .Include("WorkflowMainPostCommands")
                                .Include("WorkflowMainPreCommands")
                                .Include("WorkflowMainStartConditions")
                                .Include("WorkflowObjectTypes")
                                .Include("WorkflowParameters")
                                .Include("WorkflowRoles")
                                .Include("WorkflowClaims")
                                .Include("WorkflowTransistionHierarchies")
                                .Include("WorkflowTransistions")
                                .AsNoTracking()
                                .Single(
                                    s =>
                                        s.WorkflowID.Equals(id) && s.WorkflowVersionNumber.Equals(versionNumber));

                        cacheClient.Add<Data.Workflow>(key, workflow, DateTime.Now.AddHours(12));

                        scope.EnableProxyAndLazyLoading();
                    }
                }

                m_WorkflowParameters = workflow.WorkflowParameters;

                if (workflow.WorkflowRoles != null && workflow.WorkflowRoles.Any())
                    workflowContainerBase.WorkflowRoles = WorkflowRoleConverter.ToDtos(workflow.WorkflowRoles);
                if (workflow.WorkflowClaims != null && workflow.WorkflowClaims.Any())
                    workflowContainerBase.WorkflowClaims = WorkflowClaimConverter.ToDtos(workflow.WorkflowClaims);

                m_WorkflowObjectTypes = workflow.WorkflowObjectTypes;
                m_WorkflowCommands = workflow.WorkflowCommands;
                m_WorkflowHierarchy = workflow.WorkflowHierarchies;

                workflowContainerBase.ID = workflow.WorkflowID;
                workflowContainerBase.Name = workflow.Name;
                workflowContainerBase.Description = workflow.Description;
                workflowContainerBase.WorkflowVersionNumber = workflow.WorkflowVersionNumber;

                // get parameters
                workflowContainerBase.Parameters = CreateParameters(
                    workflow.WorkflowParameters.ToList<object>(),
                    "WorkflowID");

                //workflowContainerBase.StartConditions = CreateConditions(
                //    scope,
                //    workflow.WorkflowMainStartConditions.ToList<object>(),
                //    "WorkflowID",
                //    id,
                //    versionNumber);

                //workflowContainerBase.CompleteConditions = CreateConditions(
                //    scope,
                //    workflow.WorkflowMainCompleteConditions.ToList<object>(),
                //    "WorkflowID",
                //    id,
                //    versionNumber);

                //workflowContainerBase.PreCommands = CreateCommands(
                //    scope,
                //    workflow.WorkflowMainPreCommands.ToList<object>(),
                //    "WorkflowID",
                //    id,
                //    versionNumber);

                //workflowContainerBase.ExecuteCommands = CreateCommands(
                //    scope,
                //    workflow.WorkflowMainExecuteCommands.ToList<object>(),
                //    "WorkflowID",
                //    id,
                //    versionNumber);

                //workflowContainerBase.PostCommands = CreateCommands(
                //    scope,
                //    workflow.WorkflowMainPostCommands.ToList<object>(),
                //    "WorkflowID",
                //    id,
                //    versionNumber);

                workflowContainerBase.Transistions = CreateTransistions(
                    scope,
                    workflow.WorkflowTransistions.ToList(),
                    id,
                    versionNumber);

                workflowContainerBase.TransistionHierarchy = new WorkflowTransistionHierarchyBase();

                workflow.WorkflowTransistionHierarchies.ToList().ForEach(
                    item =>
                    {
                        var component = new WorkflowTransistionHierarchyComponentBase
                        {
                            IsWorkflowEnd =
                                item.IsWorkflowEnd,
                            IsWorkflowStart =
                                item
                                    .IsWorkflowStart,
                            ChildComponent =
                                (workflowContainerBase
                                    .Transistions
                                    .Single(
                                        t =>
                                            t.ID
                                                .Equals
                                                (
                                                    item
                                                        .ChildComponentID))
                                    as
                                    WorkflowTransistionBase)
                        };

                        if (item.ParentComponentID.HasValue)
                            component.ParentComponent =
                                (workflowContainerBase.Transistions.Single(
                                    t => t.ID.Equals(item.ParentComponentID)) as WorkflowTransistionBase);

                        workflowContainerBase.TransistionHierarchy.Hierarchy.Add(component);
                    });
            }
            

            return workflowContainerBase;
        }

        private List<IWorkflowParameter> CreateParameters(List<object> parameters,string id)
        {
            List<IWorkflowParameter> wfParams = new List<IWorkflowParameter>();

            if(parameters.Count > 0)
            {
                var typeDescriptor = TypeDescriptor.GetProperties(parameters[0]);

                parameters.ToList().ForEach(pr =>
                    {
                        var parameterId = (Guid) typeDescriptor["WorkflowParameterID"].GetValue(pr);
                        var parentId = (Guid) typeDescriptor[id].GetValue(pr) ;

                        var parameterss = m_WorkflowParameters.Where(s => s.WorkflowParameterID.Equals(parameterId)).ToList();

                        if (parameterss.Count > 0)
                        {
                            var parameter = parameterss.First();
                            WorkflowParameterBase pb = new WorkflowParameterBase
                                                           {
                                                               Description = parameter.Description,
                                                               Name = parameter.Name,
                                                               ObjectType = parameter.ObjectType,
                                                               ObjectValue = parameter.ObjectValue,
                                                               VersionNumber =
                                                                   parameter.WorkflowVersionNumber,
                                                               WorkflowID = parameter.WorkflowID
                                                           };

                            wfParams.Add(pb);
                        }

                       
                    });
            }

            return wfParams;
        }

        private IWorkflowObjectType CreateObjectType(Guid objectTypeID)
        {
            var otEntity = m_WorkflowObjectTypes.Single(s => s.WorkflowObjectTypeID.Equals(objectTypeID));

            IWorkflowObjectType ot = new WorkflowObjectTypeBase();

            ot.Description = otEntity.Description;
            ot.Name = otEntity.Name;
            ot.ObjectTypeAssembly = otEntity.ObjectTypeAssembly;
            ot.ObjectTypeName = otEntity.ObjectTypeName;
            ot.ObjectTypeNameSpace = otEntity.ObjectTypeNameSpace;
            ot.VersionNumber = otEntity.WorkflowVersionNumber;
            ot.WorkflowID = otEntity.WorkflowID;
            ot.WorkflowObjectTypeID = otEntity.WorkflowObjectTypeID;

            return ot;
        }

        //private List<IWorkflowCondition> CreateConditions(UnitOfWorkScope<TargetFrameworkEntities> scope, List<object> conditions,string id,Guid wid,int version)
        //{
        //    List<IWorkflowCondition> wfConditions = new List<IWorkflowCondition>();

        //    if (conditions.Count > 0)
        //    {
        //        var typeDescriptor = TypeDescriptor.GetProperties(conditions[0]);

        //    conditions.ToList().ForEach(pr =>
        //        {
        //            var childId = (Guid)typeDescriptor["WorkflowConditionID"].GetValue(pr);
        //            var parentId = (Guid)typeDescriptor[id].GetValue(pr);

        //            var condition = scope.DbContext.WorkflowConditions
        //                .Include("WorkflowConditionParameters")
        //                .Single(s => s.WorkflowConditionID.Equals(childId) && s.WorkflowID.Equals(wid) && s.WorkflowVersionNumber.Equals(version));

        //            WorkflowConditionBase pb = new WorkflowConditionBase
        //            {
        //                Description = condition.Description,
        //                Name = condition.Name,
        //                WorkflowVersionNumber = condition.WorkflowVersionNumber,
        //                WorkflowID = condition.WorkflowID,
        //                ID = condition.WorkflowConditionID,
        //                Parameters = CreateParameters(condition.WorkflowConditionParameters.ToList<object>(),"WorkflowConditionID")
        //            };

        //            pb.ObjectType = CreateObjectType(condition.WorkflowObjectTypeID);

        //            wfConditions.Add(pb);
        //        });
        //    }

        //    return wfConditions;
        //}

        //private List<IWorkflowCommand> CreateCommands(UnitOfWorkScope<TargetFrameworkEntities> scope, List<object> commands, string id,Guid wid,int version)
        //{
        //    List<IWorkflowCommand> wfCommands = new List<IWorkflowCommand>();

        //    if (commands.Count > 0)
        //    {
        //        var typeDescriptor = TypeDescriptor.GetProperties(commands[0]);

        //        commands.ToList().ForEach(pr =>
        //            {
        //                var childId = (Guid)typeDescriptor["WorkflowCommandID"].GetValue(pr);
        //                var parentId = (Guid)typeDescriptor[id].GetValue(pr);

        //                var command = scope.DbContext.WorkflowCommands
        //                    .Include("WorkflowCommandParameters")
        //                    .Single(s => s.WorkflowCommandID.Equals(childId) && s.WorkflowID.Equals(wid) && s.WorkflowVersionNumber.Equals(version));

        //                WorkflowCommandBase pb = new WorkflowCommandBase
        //                {
        //                    Description = command.Description,
        //                    Name = command.Name,
        //                    WorkflowVersionNumber = command.WorkflowVersionNumber,
                            
        //                    WorkflowID = command.WorkflowID,
        //                    ID = command.WorkflowCommandID,
        //                    Parameters = CreateParameters(command.WorkflowCommandParameters.ToList<object>(), "WorkflowCommandID")
        //                };

        //                pb.ObjectType = CreateObjectType(command.WorkflowObjectTypeID);

        //                wfCommands.Add(pb);
        //            });
        //    }

        //    return wfCommands;
        //}

        private List<IWorkflowTransistion> CreateTransistions(UnitOfWorkScope<TargetFrameworkEntities> scope, List<WorkflowTransistion> transistions,Guid id,int version)
        {
            List<IWorkflowTransistion> wfTransistions = new List<IWorkflowTransistion>();

            using (var cacheClient = m_CacheProvider.CreateCacheClient(Logger))
            {
                if (transistions.Count > 0)
                {
                    transistions.ToList().ForEach(pr =>
                    {
                        string key  = "WFTrans_" +  pr.WorkflowTransistionID + "_" + id + "_" + version;

                        WorkflowTransistion transistion = null;

                        transistion = cacheClient.Get<Data.WorkflowTransistion>(key);

                        if (transistion == null)
                        {
                            scope.DisableProxyAndLazyLoading();

                            transistion = scope.DbContext.WorkflowTransistions
                           .Include("WorkflowHierarchies")
                           .Include("WorkflowTransistionCompleteConditions")
                           .Include("WorkflowTransistionParameters")
                           .Include("WorkflowTransistionStartConditions")
                           .Include("WorkflowTransistionWorkflowDecisions")
                           .Include("WorkflowTransistionWorkflowActions")
                           .Single(
                               s =>
                                   s.WorkflowTransistionID.Equals(pr.WorkflowTransistionID) && s.WorkflowID.Equals(id) &&
                                   s.WorkflowVersionNumber.Equals(version));

                            cacheClient.Add<Data.WorkflowTransistion>(key, transistion, DateTime.Now.AddHours(12));

                            scope.EnableProxyAndLazyLoading();
                        }

                       

                        WorkflowTransistionBase pb = new WorkflowTransistionBase
                        {
                            Description = transistion.Description,
                            Name = transistion.Name,
                            WorkflowVersionNumber = transistion.WorkflowVersionNumber,
                            IsStart = transistion.IsWorkflowStart,
                            IsEnd = transistion.IsWorkflowEnd,
                            ID = transistion.WorkflowTransistionID,
                            Parameters =
                                CreateParameters(transistion.WorkflowTransistionParameters.ToList<object>(),
                                    "WorkflowTransistionID"),
                            //StartConditions =
                            //    CreateConditions(scope, transistion.WorkflowTransistionStartConditions.ToList<object>(),
                            //        "WorkflowTransistionID", id, version),
                            //CompleteConditions =
                            //    CreateConditions(scope,
                            //        transistion.WorkflowTransistionCompleteConditions.ToList<object>(),
                            //        "WorkflowTransistionID", id, version)
                        };

                        pb.TransistionComponents = new List<IWorkflowMainComponent>();

                        // actions
                        transistion.WorkflowTransistionWorkflowActions.ToList().ForEach(act =>
                        {
                            string actionKey = "WFAction_" + act.WorkflowActionID;

                            WorkflowAction action = null;

                            action = cacheClient.Get<Data.WorkflowAction>(actionKey);

                            if (action == null)
                            {
                                scope.DisableProxyAndLazyLoading();

                                action = scope.DbContext.WorkflowActions
                                .Include("WorkflowActionCompleteConditions")
                                .Include("WorkflowActionExecuteCommands")
                                .Include("WorkflowActionParameters")
                                .Include("WorkflowActionPostCommands")
                                .Include("WorkflowActionStartConditions")
                                .Include("WorkflowActionPreCommands")
                                .Single(
                                    wa =>
                                        wa.WorkflowActionID.Equals(act.WorkflowActionID) && wa.WorkflowID.Equals(id) &&
                                        wa.WorkflowVersionNumber.Equals(version));

                                cacheClient.Add<Data.WorkflowAction>(actionKey, action, DateTime.Now.AddHours(12));

                                scope.EnableProxyAndLazyLoading();
                            }

                            

                            var obtype = CreateObjectType(action.WorkflowObjectTypeID);


                            WorkflowActionBase ab =
                                Activator.CreateInstance(
                                    Type.GetType(obtype.ObjectTypeNameSpace.Replace("\n", "").Replace("\t", "").Trim() +
                                                 "." + obtype.ObjectTypeName.Replace("\n", "").Replace("\t", "").Trim() +
                                                 ", " +
                                                 obtype.ObjectTypeAssembly.Replace("\n", "").Replace("\t", "").Trim()))
                                    as WorkflowActionBase;

                            ab.ID = action.WorkflowActionID;
                            ab.Name = action.Name;
                            ab.Description = action.Description;
                            ab.IsStart = action.IsTransistionStart;
                            ab.IsManual = action.IsManual;
                            ab.IsEnd = action.IsTransistionEnd;
                            ab.WorkflowVersionNumber = action.WorkflowVersionNumber;
                            ab.Parameters = CreateParameters(action.WorkflowActionParameters.ToList<object>(),
                                "WorkflowActionID");
                            //ab.StartConditions = CreateConditions(scope,
                            //    action.WorkflowActionStartConditions.ToList<object>(), "WorkflowActionID", id, version);
                            //ab.CompleteConditions = CreateConditions(scope,
                            //    action.WorkflowActionCompleteConditions.ToList<object>(), "WorkflowActionID", id,
                            //    version);
                            //ab.PreCommands = CreateCommands(scope, action.WorkflowActionPreCommands.ToList<object>(),
                            //    "WorkflowActionID", id, version);
                            //ab.ExecuteCommands = CreateCommands(scope,
                            //    action.WorkflowActionExecuteCommands.ToList<object>(), "WorkflowActionID", id, version);
                            //ab.PostCommands = CreateCommands(scope, action.WorkflowActionPostCommands.ToList<object>(),
                            //    "WorkflowActionID", id, version);
                            ab.ObjectType = CreateObjectType(action.WorkflowObjectTypeID);

                            pb.TransistionComponents.Add(ab);
                        });

                        // decisions
                        transistion.WorkflowTransistionWorkflowDecisions.ToList().ForEach(
                            act =>
                            {
                                var decision =
                                    scope.DbContext.WorkflowDecisions.Include("WorkflowDecisionExecuteCommands")
                                        .Include("WorkflowDecisionParameters")
                                        .Single(
                                            wa =>
                                                wa.WorkflowDecisionID.Equals(act.WorkflowDecisionID)
                                                && wa.WorkflowID.Equals(id) && wa.WorkflowVersionNumber.Equals(version));

                                var obtype = CreateObjectType(decision.WorkflowObjectTypeID);


                                WorkflowDecisionBase ab =
                                    Activator.CreateInstance(
                                        Type.GetType(
                                            obtype.ObjectTypeNameSpace.Replace("\r", "")
                                                .Replace("\n", "")
                                                .Replace("\t", "")
                                                .Trim() + "." +
                                            obtype.ObjectTypeName.Replace("\r", "")
                                                .Replace("\n", "")
                                                .Replace("\t", "")
                                                .Trim() + ", "
                                            +
                                            obtype.ObjectTypeAssembly.Replace("\r", "")
                                                .Replace("\n", "")
                                                .Replace("\t", "")
                                                .Trim())) as WorkflowDecisionBase;

                                ab.ID = decision.WorkflowDecisionID;
                                ab.Name = decision.Name;
                                ab.Description = decision.Description;
                                ab.IsStart = decision.IsTransistionStart;
                                ab.IsEnd = decision.IsTransistionEnd;
                                ab.WorkflowVersionNumber = decision.WorkflowVersionNumber;
                                ab.Parameters =
                                    CreateParameters(
                                        decision.WorkflowDecisionParameters.ToList<object>(),
                                        "WorkflowDecisionID");
                                //ab.ExecuteCommands = CreateCommands(
                                //    scope,
                                //    decision.WorkflowDecisionExecuteCommands.ToList<object>(),
                                //    "WorkflowDecisionID",
                                //    id,
                                //    version);
                                ab.ObjectType = CreateObjectType(decision.WorkflowObjectTypeID);



                                ab.SuccessComponents = new List<IWorkflowComponent>();
                                ab.FailureComponents = new List<IWorkflowComponent>();
                                ab.ErrorComponents = new List<IWorkflowComponent>();

                                pb.TransistionComponents.Add(ab);

                            });

                        pb.TransistionComponents.OfType<IWorkflowDecision>().ToList().ForEach(
                            wd =>
                            {
                                string decisionKey = "WFDecision_" + wd.ID;

                                WorkflowDecision decision = cacheClient.Get<Data.WorkflowDecision>(decisionKey);

                                if (decision == null)
                                {
                                    scope.DisableProxyAndLazyLoading();

                                    decision =
                                        scope.DbContext.WorkflowDecisions
                                        //.Include("WorkflowDecisionSuccesses_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber")
                                            .Include(
                                                "WorkflowDecisionSuccesses_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber")
                                        //.Include("WorkflowDecisionErrors_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber")
                                            .Include(
                                                "WorkflowDecisionErrors_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber")
                                        //.Include("WorkflowDecisionFailures_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber")
                                            .Include(
                                                "WorkflowDecisionFailures_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber")
                                            .Single(
                                                wa =>
                                                    wa.WorkflowDecisionID.Equals(wd.ID)
                                                    && wa.WorkflowID.Equals(id) && wa.WorkflowVersionNumber.Equals(version));

                                    cacheClient.Add<Data.WorkflowDecision>(decisionKey, decision, DateTime.Now.AddHours(12));

                                    scope.EnableProxyAndLazyLoading();
                                }


                                if (decision.Name.Equals("Terms&ConditionsNextOrPreviousWorkFlowDecision"))
                                {

                                }

                                decision.WorkflowDecisionSuccesses_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber
                                    .ToList().ForEach(at =>
                                    {
                                        if (at.NextWorkflowActionID.HasValue)
                                            wd.SuccessComponents.Add(
                                                pb.TransistionComponents.OfType<IWorkflowAction>()
                                                    .Single(it => it.ID.Equals(at.NextWorkflowActionID)));
                                        else
                                            wd.SuccessComponents.Add(
                                                pb.TransistionComponents.OfType<IWorkflowDecision>()
                                                    .Single(it => it.ID.Equals(at.NextWorkflowDecisionID)));
                                    });

                                decision.WorkflowDecisionFailures_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber
                                    .ToList().ForEach(at =>
                                    {
                                        if (at.NextWorkflowActionID.HasValue)
                                            wd.FailureComponents.Add(
                                                pb.TransistionComponents.OfType<IWorkflowAction>()
                                                    .Single(it => it.ID.Equals(at.NextWorkflowActionID)));
                                        else
                                            wd.FailureComponents.Add(
                                                pb.TransistionComponents.OfType<IWorkflowDecision>()
                                                    .Single(it => it.ID.Equals(at.NextWorkflowDecisionID)));
                                    });

                                decision.WorkflowDecisionErrors_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber
                                    .ToList().ForEach(at =>
                                    {
                                        if (at.NextWorkflowActionID.HasValue)
                                            wd.ErrorComponents.Add(
                                                pb.TransistionComponents.OfType<IWorkflowAction>()
                                                    .Single(it => it.ID.Equals(at.NextWorkflowActionID)));
                                        else
                                            wd.ErrorComponents.Add(
                                                pb.TransistionComponents.OfType<IWorkflowDecision>()
                                                    .Single(it => it.ID.Equals(at.NextWorkflowDecisionID)));
                                    });
                            });




                        //    pb.TransistionComponents.Add(ab);
                        //});

                        // create hierarchy
                        List<IWorkflowHierarchyComponent> list = new List<IWorkflowHierarchyComponent>();

                        m_WorkflowHierarchy.Where(s => s.WorkflowTransistionID.Equals(pb.ID)).ToList()

                            .ForEach(item =>
                            {
                                if (pb.TransistionComponents.Any(s => s.ID.Equals(item.ChildComponentID)))
                                {
                                    WorkflowHierarchyComponentBase cb = new WorkflowHierarchyComponentBase
                                    {
                                        ID = item.WorkflowHierarchyID,
                                        ChildComponent =
                                            pb.TransistionComponents.Single(s => s.ID.Equals(item.ChildComponentID)),
                                        IsStart = item.IsTransistionStart.GetValueOrDefault(false),
                                        IsEnd = item.IsTranistionEnd.GetValueOrDefault(false),
                                        IsChildDependentOnParent =
                                            item.IsChildDependentOnParent.GetValueOrDefault(false)
                                    };


                                    if (item.ParentComponentID.HasValue)
                                        cb.ParentComponent =
                                            pb.TransistionComponents.Single(s => s.ID.Equals(item.ParentComponentID));

                                    list.Add(cb);
                                }

                            });

                        pb.TransistionHierarchy = list;

                        wfTransistions.Add(pb);
                    });

                }
            }

            return wfTransistions;
        }

     
    }
}
