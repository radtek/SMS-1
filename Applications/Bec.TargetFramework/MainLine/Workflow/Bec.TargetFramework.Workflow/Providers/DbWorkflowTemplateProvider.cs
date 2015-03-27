using System.Runtime.CompilerServices;
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

namespace Bec.TargetFramework.Workflow.Providers
{
    //Bec.TargetFramework.Entities

    using EnumerableExtensions = Fabrik.Common.EnumerableExtensions;
    using Bec.TargetFramework.Entities;

    public class DbWorkflowTemplateProvider : ProviderBase
    {
        public DbWorkflowTemplateProvider(ILogger logger) : base(logger)
        {
            
        }

        private ICollection<WorkflowParameterTemplate> m_WorkflowParameters;
    
        private ICollection<WorkflowObjectTypeTemplate> m_WorkflowObjectTypes;
        private ICollection<WorkflowCommandTemplate> m_WorkflowCommands;
        private ICollection<WorkflowHierarchyTemplate> m_WorkflowHierarchy;

        public IWorkflowContainer Load(IWorkflowContainer emptyContainer, Guid workflowTemplateID, int versionNumber)
        {
            var workflowContainerBase = CreateContainer(emptyContainer,workflowTemplateID);

            return workflowContainerBase;
        }
        
        private WorkflowContainerBase CreateContainer(IWorkflowContainer emptyContainer, Guid id)
        {
            var workflowContainerBase = emptyContainer as WorkflowContainerBase; ;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var workflow = scope.DbContext
                    .WorkflowTemplates
                    .Include("WorkflowCommandTemplates")
                    .Include("WorkflowConditionTemplates")
                    .Include("WorkflowHierarchyTemplates")
                    .Include("WorkflowMainCompleteConditionTemplates")
                    .Include("WorkflowMainExecuteCommandTemplates")
                    .Include("WorkflowMainParameterTemplates")
                    .Include("WorkflowMainPostCommandTemplates")
                    .Include("WorkflowMainPreCommandTemplates")
                    .Include("WorkflowClaimTemplates")
                    .Include("WorkflowRoleTemplates")
                    .Include("WorkflowMainStartConditionTemplates")
                    .Include("WorkflowObjectTypeTemplates")
                    .Include("WorkflowParameterTemplates")
                    .Include("WorkflowRestrictionTemplates")
                    .Include("WorkflowTransistionTemplates").Single(s => s.WorkflowTemplateID.Equals(id));

                m_WorkflowParameters = workflow.WorkflowParameterTemplates;
                m_WorkflowObjectTypes = workflow.WorkflowObjectTypeTemplates;
                m_WorkflowCommands = workflow.WorkflowCommandTemplates;
                m_WorkflowHierarchy = workflow.WorkflowHierarchyTemplates;

                workflowContainerBase.ID = workflow.WorkflowTemplateID;
                workflowContainerBase.Name = workflow.Name;
                workflowContainerBase.Description = workflow.Description;
                workflowContainerBase.WorkflowVersionNumber = workflow.WorkflowTemplateVersionNumber;

                if (workflow.WorkflowClaimTemplates != null && workflow.WorkflowClaimTemplates.Any())
                    workflow.WorkflowClaimTemplates.ToList()
                        .ForEach(
                            wft =>
                                {
                                    if(workflowContainerBase.WorkflowClaims == null)
                                        workflowContainerBase.WorkflowClaims = new List<WorkflowClaimDTO>();

                                    var entity = new WorkflowClaimDTO();

                                    entity.InjectFrom<NullableInjection>(wft);

                                    workflowContainerBase.WorkflowClaims.Add(entity);
                                });

               
                if (workflow.WorkflowRoleTemplates != null && workflow.WorkflowRoleTemplates.Any())
                    workflow.WorkflowRoleTemplates.ToList()
                        .ForEach(
                            wft =>
                            {
                                if (workflowContainerBase.WorkflowRoles == null)
                                    workflowContainerBase.WorkflowRoles = new List<WorkflowRoleDTO>();

                                var entity = new WorkflowRoleDTO();

                                entity.InjectFrom<NullableInjection>(wft);

                                workflowContainerBase.WorkflowRoles.Add(entity);
                            });
                
                // get parameters
                workflowContainerBase.Parameters = CreateParameters(workflow.WorkflowMainParameterTemplates.ToList<object>(), "WorkflowTemplateID");

                //workflowContainerBase.StartConditions = CreateConditions( scope,workflow.WorkflowMainStartConditionTemplates.ToList<object>(), "WorkflowTemplateID");

                //workflowContainerBase.CompleteConditions = CreateConditions(scope, workflow.WorkflowMainCompleteConditionTemplates.ToList<object>(), "WorkflowTemplateID");

                //workflowContainerBase.PreCommands = CreateCommands(scope, workflow.WorkflowMainPreCommandTemplates.ToList<object>(), "WorkflowTemplateID");

                //workflowContainerBase.ExecuteCommands = CreateCommands(scope, workflow.WorkflowMainExecuteCommandTemplates.ToList<object>(), "WorkflowTemplateID");

                //workflowContainerBase.PostCommands = CreateCommands(scope, workflow.WorkflowMainPostCommandTemplates.ToList<object>(), "WorkflowTemplateID");

                workflowContainerBase.Transistions = CreateTransistions(scope,workflow.WorkflowTransistionTemplates.ToList());

                workflowContainerBase.TransistionHierarchy = CreateWorkflowTransistionHierarchies(scope,
                    workflowContainerBase, id, workflow.WorkflowTemplateVersionNumber);
            }

            return workflowContainerBase;
        }

        private WorkflowTransistionHierarchyBase CreateWorkflowTransistionHierarchies(UnitOfWorkScope<TargetFrameworkEntities> scope, WorkflowContainerBase container,Guid templateID,
            int versionNumber)
        {
            WorkflowTransistionHierarchyBase hierarchy = new WorkflowTransistionHierarchyBase();

            scope.DbContext.WorkflowTransistionHierarchyTemplates.Where(
                s => s.WorkflowTemplateID.Equals(templateID) && s.WorkflowTemplateVersionNumber.Equals(versionNumber))
                .ToList()
                .ForEach(item =>
                {
                    WorkflowTransistionHierarchyComponentBase cb = new WorkflowTransistionHierarchyComponentBase();
                    cb.IsWorkflowEnd = item.IsWorkflowEnd;
                    cb.IsWorkflowStart = item.IsWorkflowStart;
                    cb.ChildComponent =
                            container.Transistions.Single(t => t.ID.Equals(item.ChildComponentID)) as WorkflowTransistionBase;

                    if (item.ParentComponentID.HasValue)
                    {
                        cb.ParentComponent =
                            container.Transistions.Single(t => t.ID.Equals(item.ParentComponentID.Value)) as WorkflowTransistionBase;
                    }

                    hierarchy.Hierarchy.Add(cb);
                });

            return hierarchy;
        }

        private List<IWorkflowParameter> CreateParameters(List<object> parameters,string id)
        {
            List<IWorkflowParameter> wfParams = new List<IWorkflowParameter>();

            if(parameters.Count > 0)
            {
                var typeDescriptor = TypeDescriptor.GetProperties(parameters[0]);

                parameters.ToList().ForEach(pr =>
                    {
                        var parameterId = (Guid) typeDescriptor["WorkflowParameterTemplateID"].GetValue(pr);
                        var parentId = (Guid) typeDescriptor[id].GetValue(pr) ;

                        var parameter = m_WorkflowParameters.Single(s => s.WorkflowParameterTemplateID.Equals(parameterId));

                        WorkflowParameterBase pb =new WorkflowParameterBase
                        {
                            Description = parameter.Description,
                            Name = parameter.Name,
                            ObjectType = parameter.ObjectType,
                            ObjectValue = parameter.ObjectValue,
                            VersionNumber = parameter.WorkflowTemplateVersionNumber,
                            WorkflowID = parameter.WorkflowTemplateID
                        };

                        wfParams.Add(pb);
                    });
            }

            return wfParams;
        }

        private IWorkflowObjectType CreateObjectType(Guid objectTypeID)
        {
            var otEntity = m_WorkflowObjectTypes.Single(s => s.WorkflowObjectTypeTemplateID.Equals(objectTypeID));

            IWorkflowObjectType ot = new WorkflowObjectTypeBase();
            
            ot.InjectFrom<NullableInjection>(otEntity);

            return ot;
        }

        //private List<IWorkflowCondition> CreateConditions(UnitOfWorkScope<TargetFrameworkEntities> scope, List<object> conditions,string id)
        //{
        //    List<IWorkflowCondition> wfConditions = new List<IWorkflowCondition>();

        //    if (conditions.Count > 0)
        //    {
        //        var typeDescriptor = TypeDescriptor.GetProperties(conditions[0]);

        //    conditions.ToList().ForEach(pr =>
        //        {
        //            var childId = (Guid)typeDescriptor["WorkflowConditionTemplateID"].GetValue(pr);
        //            var parentId = (Guid)typeDescriptor[id].GetValue(pr);

        //            var condition = scope.DbContext.WorkflowConditionTemplates
        //                .Include("WorkflowConditionParameterTemplates")
        //                .Single(s => s.WorkflowConditionTemplateID.Equals(childId));

        //            WorkflowConditionBase pb = new WorkflowConditionBase
        //            {
        //                Description = condition.Description,
        //                Name = condition.Name,
        //                WorkflowVersionNumber = condition.WorkflowTemplateVersionNumber,
        //                WorkflowID = condition.WorkflowTemplateID,
        //                ID = condition.WorkflowConditionTemplateID,
        //                Parameters = CreateParameters(condition.WorkflowConditionParameterTemplates.ToList<object>(),"WorkflowConditionTemplateID")
        //            };

        //            if(condition.WorkflowObjectTypeTemplateID.HasValue)
        //                pb.ObjectType = CreateObjectType(condition.WorkflowObjectTypeTemplateID.Value);

        //            wfConditions.Add(pb);
        //        });
        //    }

        //    return wfConditions;
        //}

        private List<IWorkflowCommand> CreateCommands(UnitOfWorkScope<TargetFrameworkEntities> scope, List<object> commands, string id)
        {
            List<IWorkflowCommand> wfCommands = new List<IWorkflowCommand>();

            if (commands.Count > 0)
            {
                var typeDescriptor = TypeDescriptor.GetProperties(commands[0]);

                commands.ToList().ForEach(pr =>
                    {
                        var childId = (Guid)typeDescriptor["WorkflowCommandTemplateID"].GetValue(pr);
                        var parentId = (Guid)typeDescriptor[id].GetValue(pr);

                        var command = scope.DbContext.WorkflowCommandTemplates
                            .Include("WorkflowCommandParameterTemplates")
                            .Single(s => s.WorkflowCommandTemplateID.Equals(childId));

                        WorkflowCommandBase pb = new WorkflowCommandBase
                        {
                            Description = command.Description,
                            Name = command.Name,
                            WorkflowVersionNumber = command.WorkflowTemplateVersionNumber,
                            WorkflowID = command.WorkflowTemplateID,
                            ID = command.WorkflowCommandTemplateID,
                            Parameters = CreateParameters(command.WorkflowCommandParameterTemplates.ToList<object>(), "WorkflowCommandTemplateID")
                        };

                        if (command.WorkflowObjectTypeTemplateID.HasValue)
                            pb.ObjectType = CreateObjectType(command.WorkflowObjectTypeTemplateID.Value);

                        wfCommands.Add(pb);
                    });
            }

            return wfCommands;
        }

        private List<IWorkflowTransistion> CreateTransistions(UnitOfWorkScope<TargetFrameworkEntities> scope, List<WorkflowTransistionTemplate> transistions)
        {
            List<IWorkflowTransistion> wfTransistions = new List<IWorkflowTransistion>();

            if (transistions.Count > 0)
            {
                //transistions.ToList().ForEach(pr =>
                 //   {
                    //    var transistion = scope.DbContext.WorkflowTransistionTemplates
                    //        .Include("WorkflowHierarchyTemplates")
                    //        .Include("WorkflowTransistionCompleteConditionTemplates")
                    //        .Include("WorkflowTransistionParameterTemplates")
                    //        .Include("WorkflowTransistionStartConditionTemplates")
                    //        .Include("WorkflowTransistionWorkflowDecisionTemplates")
                    //        .Include("WorkflowTransistionWorkflowActionTemplates")
                    //        .Single(s => s.WorkflowTransistionTemplateID.Equals(pr.WorkflowTransistionTemplateID));

                    //    WorkflowTransistionBase pb = new WorkflowTransistionBase
                    //    {
                    //        Description = transistion.Description,
                    //        Name = transistion.Name,
                    //        WorkflowVersionNumber = transistion.WorkflowTemplateVersionNumber,
                    //        IsStart = transistion.IsWorkflowStart,
                    //        IsEnd = transistion.IsWorkflowEnd,
                    //        ID = transistion.WorkflowTransistionTemplateID,
                    //        Parameters = CreateParameters(transistion.WorkflowTransistionParameterTemplates.ToList<object>(), "WorkflowTransistionTemplateID"),
                    //        StartConditions = CreateConditions(scope, transistion.WorkflowTransistionStartConditionTemplates.ToList<object>(), "WorkflowTransistionTemplateID"),
                    //        CompleteConditions = CreateConditions(scope, transistion.WorkflowTransistionCompleteConditionTemplates.ToList<object>(), "WorkflowTransistionTemplateID")
                    //    };

                    //    pb.TransistionComponents = new List<IWorkflowMainComponent>();

                    //    // actions
                    //    transistion.WorkflowTransistionWorkflowActionTemplates.ToList().ForEach(act =>
                    //    {
                    //        var action = scope.DbContext.WorkflowActionTemplates
                    //            .Include("WorkflowActionCompleteConditionTemplates")
                    //            .Include("WorkflowActionExecuteCommandTemplates")
                    //            .Include("WorkflowActionParameterTemplates")
                    //            .Include("WorkflowActionPostCommandTemplates")
                    //            .Include("WorkflowActionRestrictionTemplates")
                    //            .Include("WorkflowActionStartConditionTemplates")
                    //            .Include("WorkflowActionPreCommandTemplates")
                    //            .Single(wa => wa.WorkflowActionTemplateID.Equals(act.WorkflowActionTemplateID));

                    //        var obtype = CreateObjectType(action.WorkflowObjectTypeTemplateID.Value);


                    //        WorkflowActionBase ab = Activator.CreateInstance(Type.GetType(obtype.ObjectTypeNameSpace + "." + obtype.ObjectTypeName + ", " + obtype.ObjectTypeAssembly)) as WorkflowActionBase;

                    //            ab.ID = action.WorkflowActionTemplateID;
                    //            ab.Name =action.Name;
                    //            ab.Description = action.Description;
                    //            ab.IsStart = action.IsTransistionStart;
                    //            ab.IsManual = action.IsManual;
                    //            ab.IsEnd = action.IsTransistionEnd;
                    //            //ab.WorkflowVersionNumber = action.WorkflowTe;
                    //            ab.Parameters = CreateParameters(action.WorkflowActionParameterTemplates.ToList<object>(), "WorkflowActionTemplateID");
                    //            ab.StartConditions = CreateConditions(scope, action.WorkflowActionStartConditionTemplates.ToList<object>(), "WorkflowActionTemplateID");
                    //            ab.CompleteConditions = CreateConditions(scope, action.WorkflowActionCompleteConditionTemplates.ToList<object>(), "WorkflowActionTemplateID");
                    //            ab.PreCommands = CreateCommands(scope, action.WorkflowActionPreCommandTemplates.ToList<object>(), "WorkflowActionTemplateID");
                    //            ab.ExecuteCommands = CreateCommands(scope, action.WorkflowActionExecuteCommandTemplates.ToList<object>(), "WorkflowActionTemplateID");
                    //            ab.PostCommands = CreateCommands(scope, action.WorkflowActionPostCommandTemplates.ToList<object>(), "WorkflowActionTemplateID");

                    //        if (action.WorkflowObjectTypeTemplateID.HasValue)
                    //            ab.ObjectType = CreateObjectType(action.WorkflowObjectTypeTemplateID.Value);

                    //        pb.TransistionComponents.Add(ab);
                    //    });

                    //    // decisions
                    //    transistion.WorkflowTransistionWorkflowDecisionTemplates.ToList().ForEach(act =>
                    //    {
                    //        var decision = scope.DbContext.WorkflowDecisionTemplates
                    //            .Include("WorkflowDecisionExecuteCommandTemplates")
                    //            .Include("WorkflowDecisionFailureActionTemplates")
                    //            .Include("WorkflowDecisionErrorActionTemplates")
                    //            .Include("WorkflowDecisionParameterTemplates")
                    //            .Include("WorkflowDecisionSuccessActionTemplates")
                    //            .Single(wa => wa.WorkflowDecisionTemplateID.Equals(act.WorkflowDecisionTemplateID));

                    //        var obtype = CreateObjectType(decision.WorkflowObjectTypeTemplateID.Value);


                    //        WorkflowDecisionBase ab = Activator.CreateInstance(Type.GetType(obtype.ObjectTypeNameSpace + "." + obtype.ObjectTypeName + ", " + obtype.ObjectTypeAssembly)) as WorkflowDecisionBase;

                    //            ab.ID = decision.WorkflowDecisionTemplateID;
                    //            ab.Name =decision.Name;
                    //            ab.Description = decision.Description;
                    //            ab.IsStart = decision.IsTransistionStart;
                    //            ab.IsEnd = decision.IsTransistionEnd;
                    //            ab.WorkflowVersionNumber = decision.WorkflowTemplateVersionNumber;
                    //            ab.Parameters = CreateParameters(decision.WorkflowDecisionParameterTemplates.ToList<object>(), "WorkflowDecisionTemplateID");
                    //            ab.ExecuteCommands = CreateCommands(scope, decision.WorkflowDecisionExecuteCommandTemplates.ToList<object>(), "WorkflowDecisionTemplateID");
                            


                    //        if (decision.WorkflowObjectTypeTemplateID.HasValue)
                    //            ab.ObjectType = CreateObjectType(decision.WorkflowObjectTypeTemplateID.Value);

                    //        ab.SuccessComponents = new List<IWorkflowComponent>();
                    //        ab.FailureComponents = new List<IWorkflowComponent>();
                    //        ab.ErrorComponents = new List<IWorkflowComponent>();

                    //        decision.WorkflowDecisionSuccessTemplates.ToList().ForEach(at =>
                    //            {
                    //                if(at.NextWorkflowActionTemplateID.HasValue)
                    //                ab.SuccessComponents.Add(pb.TransistionComponents.OfType<IWorkflowAction>().Single(it => it.ID.Equals(at.NextWorkflowActionTemplateID)));
                    //                else
                    //                    ab.SuccessComponents.Add(pb.TransistionComponents.OfType<IWorkflowDecision>().Single(it => it.ID.Equals(at.NextWorkflowDecisionTemplateID)));

                    //            });

                    //        decision.WorkflowDecisionFailureTemplates.ToList().ForEach(at =>
                    //            {
                    //                if (at.NextWorkflowActionTemplateID.HasValue)
                    //                ab.FailureComponents.Add(pb.TransistionComponents.OfType<IWorkflowAction>().Single(it => it.ID.Equals(at.NextWorkflowActionTemplateID)));
                    //                else
                    //                    ab.FailureComponents.Add(pb.TransistionComponents.OfType<IWorkflowDecision>().Single(it => it.ID.Equals(at.NextWorkflowDecisionTemplateID)));
                    //            });

                    //        decision.WorkflowDecisionErrorTemplates.ToList().ForEach(at =>
                    //        {
                    //            if (at.NextWorkflowActionTemplateID.HasValue)
                    //            ab.ErrorComponents.Add(pb.TransistionComponents.OfType<IWorkflowAction>().Single(it => it.ID.Equals(at.NextWorkflowActionTemplateID)));
                    //            else
                    //            ab.ErrorComponents.Add(pb.TransistionComponents.OfType<IWorkflowDecision>().Single(it => it.ID.Equals(at.NextWorkflowDecisionTemplateID)));
                    //        });

                    //        pb.TransistionComponents.Add(ab);
                    //    });

                    //    // create hierarchy
                    //    List<IWorkflowHierarchyComponent> list = new List<IWorkflowHierarchyComponent>();

                    //    m_WorkflowHierarchy.Where(s => s.WorkflowTransistionTemplateID.Equals(pb.ID)).ToList()
                    //        .ForEach(item =>
                    //        {
                    //            WorkflowHierarchyComponentBase cb = new WorkflowHierarchyComponentBase
                    //            {
                    //                ID = item.WorkflowHierarchyTemplateID,
                    //                ChildComponent = pb.TransistionComponents.Single(s => s.ID.Equals(item.ChildComponentID)),
                    //                IsStart = item.IsTransistionStart.GetValueOrDefault(false),
                    //                IsEnd = item.IsTranistionEnd.GetValueOrDefault(false),
                    //                IsChildDependentOnParent = item.IsChildDependentOnParent.GetValueOrDefault(false)
                    //            };

                    //            if(item.ParentComponentID.HasValue)
                    //                cb.ParentComponent = pb.TransistionComponents.Single(s => s.ID.Equals(item.ParentComponentID));

                    //            list.Add(cb);    
                    //        });

                    //    pb.TransistionHierarchy = list;

                    //    wfTransistions.Add(pb);
                    //});
            }

            return wfTransistions;
        }

        public Bec.TargetFramework.Data.Workflow CreateFromTemplate(Guid workflowTemplateID,int versionNumber)
        {
            Bec.TargetFramework.Data.Workflow workflow = null;
            try
            {
                using (TransactionScope tscope = new TransactionScope())
                {

                    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, false))
            {
                List<WorkflowAction> actions = new List<WorkflowAction>();
                List<WorkflowDecision> decisions = new List<WorkflowDecision>();

                var workflowTemplate = scope.DbContext
                    .WorkflowTemplates
                    .Include("WorkflowCommandTemplates")
                    .Include("WorkflowConditionTemplates")
                    .Include("WorkflowHierarchyTemplates")
                    .Include("WorkflowMainCompleteConditionTemplates")
                    .Include("WorkflowMainExecuteCommandTemplates")
                    .Include("WorkflowMainParameterTemplates")
                    .Include("WorkflowMainPostCommandTemplates")
                    .Include("WorkflowMainPreCommandTemplates")
                    .Include("WorkflowClaimTemplates")
                    .Include("WorkflowRoleTemplates")
                    .Include("WorkflowMainStartConditionTemplates")
                    .Include("WorkflowObjectTypeTemplates")
                    .Include("WorkflowParameterTemplates")
                    //.Include("WorkflowRestrictionTemplates")
                    .Include("WorkflowTransistionHierarchyTemplates")
                    .Include("WorkflowTransistionTemplates").Single(s => s.WorkflowTemplateID.Equals(workflowTemplateID));

                // create workflow
                workflow = new Data.Workflow();
                workflow.InjectFrom<NullableInjection>(workflowTemplate);
                workflow.WorkflowID = Guid.NewGuid();
                workflow.WorkflowVersionNumber = versionNumber;

                List<WorkflowRole> roles = new List<WorkflowRole>();
                workflowTemplate.WorkflowRoleTemplates.ToList().ForEach
                    (item =>
                        {
                            WorkflowRole wr = new WorkflowRole();
                            wr.InjectFrom<NullableInjection>(item);
                            wr.WorkflowRoleID =item.WorkflowRoleTemplateID;
                            wr.WorkflowID = workflow.WorkflowID;
                            wr.WorkflowVersionNumber = versionNumber;
                            wr.RoleDescription = item.RoleDescription;
                            wr.RoleName = item.RoleName;
                            wr.IsActive = item.IsActive;
                            wr.IsDeleted = item.IsDeleted;

                            scope.DbContext.WorkflowRoles.Add(wr);

                            roles.Add(wr);
                        }
                    );


                List<WorkflowClaim> Claims = new List<WorkflowClaim>();
                workflowTemplate.WorkflowClaimTemplates.ToList().ForEach
                    (item =>
                    {
                        WorkflowClaim wr = new WorkflowClaim();
                        wr.InjectFrom<NullableInjection>(item);
                        wr.WorkflowClaimID = item.WorkflowClaimTemplateID;
                        wr.WorkflowRoleID = item.WorkflowRoleTemplateID;
                        wr.WorkflowID = workflow.WorkflowID;
                        wr.WorkflowVersionNumber = versionNumber;
                        wr.IsActive = item.IsActive;
                        wr.IsDeleted = item.IsDeleted;
                        wr.StateID = item.StateID;
                        wr.StateItemID = item.StateItemID;
                        wr.ResourceID = item.ResourceID;
                        wr.OperationID = item.OperationID;

                        scope.DbContext.WorkflowClaims.Add(wr);

                        Claims.Add(wr);
                    }
                    );

                // create parameters
                List<WorkflowParameter> parameters = new List<WorkflowParameter>();
                workflowTemplate.WorkflowParameterTemplates.ToList().ForEach
                    (item =>
                        {
                            WorkflowParameter wr = new WorkflowParameter();
                            wr.InjectFrom<NullableInjection>(item);
                            wr.WorkflowParameterID = item.WorkflowParameterTemplateID;
                            wr.WorkflowID = workflow.WorkflowID;
                            wr.WorkflowVersionNumber = versionNumber;

                            scope.DbContext.WorkflowParameters.Add(wr);

                            parameters.Add(wr);
                        }
                    );

                // create parameters
                List<WorkflowObjectType> objectTypes = new List<WorkflowObjectType>();
                workflowTemplate.WorkflowObjectTypeTemplates.ToList().ForEach
                    (item =>
                        {
                            if(!objectTypes.Any(s => s.WorkflowObjectTypeID.Equals(item.WorkflowObjectTypeTemplateID)))
                            {
                                WorkflowObjectType wr = new WorkflowObjectType();
                                wr.InjectFrom<NullableInjection>(item);
                                wr.WorkflowObjectTypeID = item.WorkflowObjectTypeTemplateID;
                                wr.WorkflowID = workflow.WorkflowID;
                                wr.WorkflowVersionNumber = versionNumber;

                                scope.DbContext.WorkflowObjectTypes.Add(wr);

                                objectTypes.Add(wr);
                            }
                        }
                    );

                //List<WorkflowCondition> conditions = new List<WorkflowCondition>();

                //workflowTemplate.WorkflowConditionTemplates.ToList().ForEach(item =>
                //    {
                //        if (!conditions.Any(s => s.WorkflowConditionID.Equals(item.WorkflowConditionTemplateID)))
                //        {
                //            var conditionTemplate = scope.DbContext.WorkflowConditionTemplates
                //            .Include("WorkflowConditionParameterTemplates")
                //            .Single(s => s.WorkflowConditionTemplateID.Equals(item.WorkflowConditionTemplateID));

                //            WorkflowCondition command = new WorkflowCondition();
                //            command.InjectFrom<NullableInjection>(conditionTemplate);
                //            command.WorkflowID = workflow.WorkflowID;
                //            command.WorkflowVersionNumber = workflow.WorkflowVersionNumber;
                //            command.WorkflowConditionID = item.WorkflowConditionTemplateID;
                //            command.WorkflowObjectTypeID = item.WorkflowObjectTypeTemplateID.Value;

                //            // add parameters
                //            conditionTemplate.WorkflowConditionParameterTemplates.ToList().ForEach(cp =>
                //                {
                //                    command.WorkflowConditionParameters.Add(new WorkflowConditionParameter
                //                    {
                //                        WorkflowVersionNumber = versionNumber,
                //                        WorkflowConditionID = command.WorkflowConditionID,
                //                        WorkflowParameterID = cp.WorkflowParameterTemplateID,
                //                        WorkflowID = workflow.WorkflowID
                //                    });
                //                });

                //            conditions.Add(command);

                //            scope.DbContext.WorkflowConditions.Add(command);
                //        }

                //        //// add main parameters to context
                //        //command.WorkflowConditionParameters.ToList().ForEach(p =>
                //        //    {
                //        //        scope.DbContext.WorkflowConditionParameters.Add(p);
                //        //    });
                //    });

                //List<WorkflowCommand> commands = new List<WorkflowCommand>();

                //workflowTemplate.WorkflowCommandTemplates.ToList().ForEach(item =>
                //    {
                //        if (!commands.Any(s => s.WorkflowCommandID.Equals(item.WorkflowCommandTemplateID)))
                //        {
                //            var commandTemplate = scope.DbContext.WorkflowCommandTemplates
                //            .Include("WorkflowCommandParameterTemplates")
                //            .Single(s => s.WorkflowCommandTemplateID.Equals(item.WorkflowCommandTemplateID));

                //            WorkflowCommand command = new WorkflowCommand();
                //            command.InjectFrom<NullableInjection>(commandTemplate);
                //            command.WorkflowID = workflow.WorkflowID;
                //            command.WorkflowVersionNumber = workflow.WorkflowVersionNumber;
                //            command.WorkflowCommandID = item.WorkflowCommandTemplateID;
                //            command.WorkflowObjectTypeID = item.WorkflowObjectTypeTemplateID.Value;

                //            // add parameters
                //            commandTemplate.WorkflowCommandParameterTemplates.ToList().ForEach(cp =>
                //                {
                //                    command.WorkflowCommandParameters.Add(new WorkflowCommandParameter
                //                    {
                //                        WorkflowVersionNumber = versionNumber,
                //                        WorkflowCommandID = command.WorkflowCommandID,
                //                        WorkflowParameterID = cp.WorkflowParameterTemplateID,
                //                        WorkflowID = workflow.WorkflowID
                //                    });
                //                });

                //            commands.Add(command);

                //            scope.DbContext.WorkflowCommands.Add(command);

                //            // add main parameters to context
                //            command.WorkflowCommandParameters.ToList().ForEach(p =>
                //                {
                //                    scope.DbContext.WorkflowCommandParameters.Add(p);
                //                });
                //        }
                //    });



                // create workflow parameters
                workflowTemplate.WorkflowMainParameterTemplates.ToList().ForEach(item =>
                    {
                        var wp = parameters.Single(s => s.WorkflowParameterID.Equals(item.WorkflowParameterTemplateID));
                        workflow.WorkflowMainParameters.Add(new WorkflowMainParameter
                            {
                                WorkflowVersionNumber = versionNumber,
                                WorkflowID = workflow.WorkflowID,
                                WorkflowParameterID = item.WorkflowParameterTemplateID
                            });
                    });


                //workflowTemplate.WorkflowMainCompleteConditionTemplates.ToList().ForEach(item =>
                //    {
                //        var wp = conditions.Single(s => s.WorkflowConditionID.Equals(item.WorkflowConditionTemplateID));
                //        workflow.WorkflowMainCompleteConditions.Add(new WorkflowMainCompleteCondition
                //            {
                //                WorkflowVersionNumber = versionNumber,
                //                WorkflowID = workflow.WorkflowID,
                //                WorkflowConditionID = item.WorkflowConditionTemplateID
                //            });
                //    });

                //workflowTemplate.WorkflowMainStartConditionTemplates.ToList().ForEach(item =>
                //    {
                //        var wp = conditions.Single(s => s.WorkflowConditionID.Equals(item.WorkflowConditionTemplateID));
                //        workflow.WorkflowMainStartConditions.Add(new WorkflowMainStartCondition
                //            {
                //                WorkflowVersionNumber = versionNumber,
                //                WorkflowID = workflow.WorkflowID,
                //                WorkflowConditionID = item.WorkflowConditionTemplateID
                //            });
                //    });

                //workflowTemplate.WorkflowMainExecuteCommandTemplates.ToList().ForEach(item =>
                //    {
                //        var wp = commands.Single(s => s.WorkflowCommandID.Equals(item.WorkflowCommandTemplateID));
                //        workflow.WorkflowMainExecuteCommands.Add(new WorkflowMainExecuteCommand
                //            {
                //                WorkflowVersionNumber = versionNumber,
                //                WorkflowID = workflow.WorkflowID,
                //                WorkflowCommandID = item.WorkflowCommandTemplateID
                //            });
                //    });

                //workflowTemplate.WorkflowMainPostCommandTemplates.ToList().ForEach(item =>
                //    {
                //        var wp = commands.Single(s => s.WorkflowCommandID.Equals(item.WorkflowCommandTemplateID));
                //        workflow.WorkflowMainPostCommands.Add(new WorkflowMainPostCommand
                //            {
                //                WorkflowVersionNumber = versionNumber,
                //                WorkflowID = workflow.WorkflowID,
                //                WorkflowCommandID = item.WorkflowCommandTemplateID
                //            });
                //    });

                //workflowTemplate.WorkflowMainPreCommandTemplates.ToList().ForEach(item =>
                //    {
                //        var wp = commands.Single(s => s.WorkflowCommandID.Equals(item.WorkflowCommandTemplateID));
                //        workflow.WorkflowMainPreCommands.Add(new WorkflowMainPreCommand
                //            {
                //                WorkflowVersionNumber = versionNumber,
                //                WorkflowID = workflow.WorkflowID,
                //                WorkflowCommandID = item.WorkflowCommandTemplateID
                //            }); ;
                //    });

                //// save workflow other
                //// create action
                List<WorkflowTransistion> transistions = new List<WorkflowTransistion>();

                workflowTemplate.WorkflowTransistionTemplates.ToList().ForEach(item =>
                    {
                        if (!transistions.Any(s => s.WorkflowTransistionID.Equals(item.WorkflowTransistionTemplateID)))
                        {
                            var transistionTemplate = scope.DbContext.WorkflowTransistionTemplates
                            .Include("WorkflowHierarchyTemplates")
                            .Include("WorkflowTransistionCompleteConditionTemplates")
                            .Include("WorkflowTransistionParameterTemplates")
                            .Include("WorkflowTransistionStartConditionTemplates")
                            .Include("WorkflowTransistionWorkflowDecisionTemplates")
                            .Include("WorkflowTransistionWorkflowActionTemplates")
                            .Single(s => s.WorkflowTransistionTemplateID.Equals(item.WorkflowTransistionTemplateID));

                            WorkflowTransistion transistion = new WorkflowTransistion();
                            transistion.WorkflowTransistionID = item.WorkflowTransistionTemplateID;
                            transistion.WorkflowVersionNumber = versionNumber;
                            transistion.WorkflowID = workflow.WorkflowID;

                            transistion.InjectFrom<NullableInjection>(transistionTemplate);

                            scope.DbContext.WorkflowTransistions.Add(transistion);

                            // parameters
                            transistionTemplate.WorkflowTransistionParameterTemplates.ToList().ForEach(it =>
                                {
                                    transistion.WorkflowTransistionParameters.Add(new WorkflowTransistionParameter
                                        {
                                            WorkflowVersionNumber = versionNumber,
                                            WorkflowParameterID = it.WorkflowParameterTemplateID,
                                            WorkflowTransistionID = transistion.WorkflowTransistionID,
                                            WorkflowID = workflow.WorkflowID
                                        });
                                });

                            //transistionTemplate.WorkflowTransistionCompleteConditionTemplates.ToList().ForEach(it =>
                            //{
                            //    var wp = conditions.Single(s => s.WorkflowConditionID.Equals(it.WorkflowConditionTemplateID));
                            //    transistion.WorkflowTransistionCompleteConditions.Add(new WorkflowTransistionCompleteCondition
                            //        {
                            //            WorkflowVersionNumber = versionNumber,
                            //            WorkflowConditionID = it.WorkflowConditionTemplateID,
                            //            WorkflowTransistionID = transistion.WorkflowTransistionID,
                            //            WorkflowID = workflow.WorkflowID
                            //        });
                            //});

                            //transistionTemplate.WorkflowTransistionStartConditionTemplates.ToList().ForEach(it =>
                            //{
                            //    var wp = conditions.Single(s => s.WorkflowConditionID.Equals(it.WorkflowConditionTemplateID));
                            //    transistion.WorkflowTransistionStartConditions.Add(new WorkflowTransistionStartCondition
                            //        {
                            //            WorkflowVersionNumber = versionNumber,
                            //            WorkflowConditionID = it.WorkflowConditionTemplateID,
                            //            WorkflowTransistionID = transistion.WorkflowTransistionID,
                            //            WorkflowID = workflow.WorkflowID
                            //        });
                            //});

                            // actions
                            transistionTemplate.WorkflowTransistionWorkflowActionTemplates.ToList().ForEach(act =>
                                {
                                    if (!actions.Any(s => s.WorkflowActionID.Equals(act.WorkflowActionTemplateID)))
                                    {
                                        var actionTemplate = scope.DbContext.WorkflowActionTemplates
                                    .Include("WorkflowActionCompleteConditionTemplates")
                                    .Include("WorkflowActionExecuteCommandTemplates")
                                    .Include("WorkflowActionParameterTemplates")
                                    .Include("WorkflowActionPostCommandTemplates")
                                    .Include("WorkflowActionStartConditionTemplates")
                                    .Include("WorkflowActionPreCommandTemplates")
                                    .Single(wa => wa.WorkflowActionTemplateID.Equals(act.WorkflowActionTemplateID));

                                        WorkflowAction action = new WorkflowAction();
                                        action.InjectFrom<NullableInjection>(actionTemplate);
                                        action.WorkflowID = workflow.WorkflowID;
                                        action.WorkflowVersionNumber = versionNumber;
                                        action.WorkflowActionID = act.WorkflowActionTemplateID;
                                        action.WorkflowObjectType = objectTypes.Single(s => s.WorkflowObjectTypeID.Equals(actionTemplate.WorkflowObjectTypeTemplateID));

                                        scope.DbContext.WorkflowActions.Add(action);

                                        actionTemplate.WorkflowActionParameterTemplates.ToList().ForEach(it =>
                                        {
                                            action.WorkflowActionParameters.Add(new WorkflowActionParameter
                                                {
                                                    WorkflowVersionNumber = versionNumber,
                                                    WorkflowParameterID = it.WorkflowParameterTemplateID,
                                                    WorkflowActionID = action.WorkflowActionID,
                                                    WorkflowID = workflow.WorkflowID
                                                });
                                        });

                                        //actionTemplate.WorkflowActionCompleteConditionTemplates.ToList().ForEach(it =>
                                        //{
                                        //    var wp = conditions.Single(s => s.WorkflowConditionID.Equals(it.WorkflowConditionTemplateID));
                                        //    action.WorkflowActionCompleteConditions.Add(new WorkflowActionCompleteCondition
                                        //        {
                                        //            WorkflowVersionNumber = versionNumber,
                                        //            WorkflowConditionID = it.WorkflowConditionTemplateID,
                                        //            WorkflowActionID = action.WorkflowActionID,
                                        //            WorkflowID = workflow.WorkflowID
                                        //        });
                                        //});


                                        //actionTemplate.WorkflowActionStartConditionTemplates.ToList().ForEach(it =>
                                        //{
                                        //    var wp = conditions.Single(s => s.WorkflowConditionID.Equals(it.WorkflowConditionTemplateID));
                                        //    action.WorkflowActionStartConditions.Add(new WorkflowActionStartCondition
                                        //        {
                                        //            WorkflowVersionNumber = versionNumber,
                                        //            WorkflowConditionID = it.WorkflowConditionTemplateID,
                                        //            WorkflowActionID = action.WorkflowActionID,
                                        //            WorkflowID = workflow.WorkflowID
                                        //        });
                                        //});


                                        //actionTemplate.WorkflowActionExecuteCommandTemplates.ToList().ForEach(it =>
                                        //{
                                        //    var wp = commands.Single(s => s.WorkflowCommandID.Equals(it.WorkflowCommandTemplateID));
                                        //    action.WorkflowActionExecuteCommands.Add(new WorkflowActionExecuteCommand
                                        //        {
                                        //            WorkflowVersionNumber = versionNumber,
                                        //            WorkflowCommandID = it.WorkflowCommandTemplateID,
                                        //            WorkflowActionID = action.WorkflowActionID,
                                        //            WorkflowID = workflow.WorkflowID
                                        //        });
                                        //});


                                        //actionTemplate.WorkflowActionPostCommandTemplates.ToList().ForEach(it =>
                                        //{
                                        //    var wp = commands.Single(s => s.WorkflowCommandID.Equals(it.WorkflowCommandTemplateID));
                                        //    action.WorkflowActionPostCommands.Add(new WorkflowActionPostCommand
                                        //        {
                                        //            WorkflowVersionNumber = versionNumber,
                                        //            WorkflowCommandID = it.WorkflowCommandTemplateID,
                                        //            WorkflowActionID = action.WorkflowActionID,
                                        //            WorkflowID = workflow.WorkflowID
                                        //        });
                                        //});


                                        //actionTemplate.WorkflowActionPreCommandTemplates.ToList().ForEach(it =>
                                        //{
                                        //    var wp = commands.Single(s => s.WorkflowCommandID.Equals(it.WorkflowCommandTemplateID));
                                        //    action.WorkflowActionPreCommands.Add(new WorkflowActionPreCommand
                                        //        {
                                        //            WorkflowVersionNumber = versionNumber,
                                        //            WorkflowCommandID = it.WorkflowCommandTemplateID,
                                        //            WorkflowActionID = action.WorkflowActionID,
                                        //            WorkflowID = workflow.WorkflowID
                                        //        });
                                        //});


                                        actions.Add(action);
                                    }

                                    if (transistion.WorkflowTransistionWorkflowActions == null)
                                        transistion.WorkflowTransistionWorkflowActions = new List<WorkflowTransistionWorkflowAction>();

                                    if (!transistion.WorkflowTransistionWorkflowActions.Any(s => s.WorkflowActionID.Equals(act.WorkflowActionTemplateID)))
                                    transistion.WorkflowTransistionWorkflowActions.Add(new WorkflowTransistionWorkflowAction
                                    {
                                        WorkflowVersionNumber = versionNumber,
                                        WorkflowActionID = act.WorkflowActionTemplateID,
                                        WorkflowTransistionID = transistion.WorkflowTransistionID,
                                        WorkflowID = workflow.WorkflowID
                                    });

                                });



                            //// decisions 
                            //transistionTemplate.WorkflowTransistionWorkflowDecisionTemplates.ToList().ForEach(act =>
                            //{
                            //    if (!decisions.Any(s => s.WorkflowDecisionID.Equals(act.WorkflowDecisionTemplateID)))
                            //    {
                            //        var decisionTemplate = scope.DbContext.WorkflowDecisionTemplates
                            //            .Include("WorkflowDecisionExecuteCommandTemplates")
                            //            .Include("WorkflowDecisionFailureActionTemplates")
                            //            .Include("WorkflowDecisionErrorActionTemplates")
                            //            .Include("WorkflowDecisionParameterTemplates")
                            //            .Include("WorkflowDecisionSuccessActionTemplates")
                            //            .Single(wa => wa.WorkflowDecisionTemplateID.Equals(act.WorkflowDecisionTemplateID));

                            //        WorkflowDecision decision = new WorkflowDecision();
                            //        decision.InjectFrom<NullableInjection>(decisionTemplate);
                            //        decision.WorkflowVersionNumber = versionNumber;
                            //        decision.WorkflowID = workflow.WorkflowID;
                            //        decision.WorkflowDecisionID = act.WorkflowDecisionTemplateID;
                            //        decision.WorkflowObjectType = objectTypes.Single(s => s.WorkflowObjectTypeID.Equals(decisionTemplate.WorkflowObjectTypeTemplateID));


                            //        scope.DbContext.WorkflowDecisions.Add(decision);

                            //        decisionTemplate.WorkflowDecisionParameterTemplates.ToList().ForEach(it =>
                            //            {
                            //                if (!decision.WorkflowDecisionParameters.Any(s => s.WorkflowParameterID.Equals(it.WorkflowParameterTemplateID)))
                            //                decision.WorkflowDecisionParameters.Add(new WorkflowDecisionParameter
                            //                    {
                            //                        WorkflowVersionNumber = versionNumber,
                            //                        WorkflowParameterID = it.WorkflowParameterTemplateID,
                            //                        WorkflowDecisionID = decision.WorkflowDecisionID,
                            //                        WorkflowID = workflow.WorkflowID
                            //                    });
                            //            });

                            //        decisionTemplate.WorkflowDecisionExecuteCommandTemplates.ToList().ForEach(it =>
                            //            {
                            //                var wp = commands.Single(s => s.WorkflowCommandID.Equals(it.WorkflowCommandTemplateID));

                            //                if (!decision.WorkflowDecisionExecuteCommands.Any(s => s.WorkflowCommandID.Equals(it.WorkflowCommandTemplateID)))
                            //                decision.WorkflowDecisionExecuteCommands.Add(new WorkflowDecisionExecuteCommand
                            //                    {
                            //                        WorkflowVersionNumber = versionNumber,
                            //                        WorkflowCommandID = it.WorkflowCommandTemplateID,
                            //                        WorkflowDecisionID = decision.WorkflowDecisionID,
                            //                        WorkflowID = workflow.WorkflowID
                            //                    });
                            //            });

                            //        decisionTemplate.WorkflowDecisionFailureTemplates.ToList().ForEach(it =>
                            //            {
                            //                var wp = actions.Single(s => s.WorkflowActionID.Equals(it.NextWorkflowActionTemplateID));

                            //                if (decision.WorkflowDecisionFailures == null)
                            //                    decision.WorkflowDecisionFailures = new List<WorkflowDecisionFailure>();
                            //                if (it.NextWorkflowActionTemplateID.HasValue)
                            //                    if (!decision.WorkflowDecisionFailures.Any(s => s.NextWorkflowActionID.Equals(it.NextWorkflowActionTemplateID)))
                            //                    decision.WorkflowDecisionFailures.Add(new WorkflowDecisionFailure
                            //                        {
                            //                            WorkflowVersionNumber = versionNumber,
                            //                            NextWorkflowActionID = it.NextWorkflowActionTemplateID,
                            //                            WorkflowDecisionID = decision.WorkflowDecisionID,
                            //                            WorkflowID = workflow.WorkflowID
                            //                        });
                            //                else
                            //                        if (!decision.WorkflowDecisionFailures.Any(s => s.NextWorkflowActionID.Equals(it.NextWorkflowDecisionTemplateID)))
                            //                            decision.WorkflowDecisionFailures.Add(new WorkflowDecisionFailure
                            //                            {
                            //                                WorkflowVersionNumber = versionNumber,
                            //                                NextWorkflowDecisionID = it.NextWorkflowDecisionTemplateID,
                            //                                WorkflowDecisionID = decision.WorkflowDecisionID,
                            //                                WorkflowID = workflow.WorkflowID
                            //                            });

                            //            });

                            //        decisionTemplate.WorkflowDecisionErrorTemplates.ToList().ForEach(it =>
                            //        {
                            //            var wp = actions.Single(s => s.WorkflowActionID.Equals(it.NextWorkflowActionTemplateID));

                            //            if (decision.WorkflowDecisionErrors == null)
                            //                decision.WorkflowDecisionErrors = new List<WorkflowDecisionError>();

                            //            if (it.NextWorkflowActionTemplateID.HasValue)
                            //                if (!decision.WorkflowDecisionErrors.Any(s => s.NextWorkflowActionID.Equals(it.NextWorkflowActionTemplateID)))
                            //                    decision.WorkflowDecisionErrors.Add(new WorkflowDecisionError
                            //                    {
                            //                        WorkflowVersionNumber = versionNumber,
                            //                        NextWorkflowActionID = it.NextWorkflowActionTemplateID,
                            //                        WorkflowDecisionID = decision.WorkflowDecisionID,
                            //                        WorkflowID = workflow.WorkflowID
                            //                    });

                            //                else
                            //                    if (!decision.WorkflowDecisionErrors.Any(s => s.NextWorkflowActionID.Equals(it.NextWorkflowDecisionTemplateID)))
                            //                        decision.WorkflowDecisionErrors.Add(new WorkflowDecisionError
                            //                        {
                            //                            WorkflowVersionNumber = versionNumber,
                            //                            NextWorkflowDecisionID = it.NextWorkflowDecisionTemplateID,
                            //                            WorkflowDecisionID = decision.WorkflowDecisionID,
                            //                            WorkflowID = workflow.WorkflowID
                            //                        });
                            //        });

                            //        decisionTemplate.WorkflowDecisionSuccessTemplates.ToList().ForEach(it =>
                            //            {
                            //                var wp = actions.Single(s => s.WorkflowActionID.Equals(it.NextWorkflowActionTemplateID));

                            //                if (decision.WorkflowDecisionSuccesses == null)
                            //                    decision.WorkflowDecisionSuccesses = new List<WorkflowDecisionSuccess>();

                            //                if (it.NextWorkflowActionTemplateID.HasValue)
                            //                    if (!decision.WorkflowDecisionSuccesses.Any(s => s.NextWorkflowActionID.Equals(it.NextWorkflowActionTemplateID)))
                            //                        decision.WorkflowDecisionSuccesses.Add(new WorkflowDecisionSuccess
                            //                            {
                            //                                WorkflowVersionNumber = versionNumber,
                            //                                NextWorkflowActionID = it.NextWorkflowActionTemplateID,
                            //                                WorkflowDecisionID = decision.WorkflowDecisionID,
                            //                                WorkflowID = workflow.WorkflowID
                            //                            });
                            //                    else
                            //                        if (!decision.WorkflowDecisionSuccesses.Any(s => s.NextWorkflowActionID.Equals(it.NextWorkflowDecisionTemplateID)))
                            //                            decision.WorkflowDecisionSuccesses.Add(new WorkflowDecisionSuccess
                            //                            {
                            //                                WorkflowVersionNumber = versionNumber,
                            //                                NextWorkflowDecisionID = it.NextWorkflowDecisionTemplateID,
                            //                                WorkflowDecisionID = decision.WorkflowDecisionID,
                            //                                WorkflowID = workflow.WorkflowID
                            //                            });
                            //            });


                            //        decisions.Add(decision);


                            //    }

                            //    if (transistion.WorkflowTransistionWorkflowDecisions == null)
                            //        transistion.WorkflowTransistionWorkflowDecisions = new List<WorkflowTransistionWorkflowDecision>();

                            //    if (!transistion.WorkflowTransistionWorkflowDecisions.Any(s => s.WorkflowDecisionID.Equals(act.WorkflowDecisionTemplateID)))
                            //    transistion.WorkflowTransistionWorkflowDecisions.Add(new WorkflowTransistionWorkflowDecision
                            //    {
                            //        WorkflowVersionNumber = versionNumber,
                            //        WorkflowDecisionID = act.WorkflowDecisionTemplateID,
                            //        WorkflowTransistionID = transistion.WorkflowTransistionID,
                            //        WorkflowID = workflow.WorkflowID
                            //    });
                            //});

                            if (transistion.WorkflowHierarchies == null)
                                transistion.WorkflowHierarchies = new List<WorkflowHierarchy>();

                            transistionTemplate.WorkflowHierarchyTemplates.ToList().ForEach(act =>
                                {
                                    WorkflowHierarchy wf = new WorkflowHierarchy();
                                    wf.InjectFrom<NullableInjection>(act);
                                    wf.WorkflowID = workflow.WorkflowID;
                                    wf.WorkflowVersionNumber = versionNumber;
                                    wf.WorkflowHierarchyID = Guid.NewGuid();
                                    wf.WorkflowTransistionID = transistion.WorkflowTransistionID;
                                    wf.IsChildDependentOnParent = act.IsChildDependentOnParent;
                                    transistion.WorkflowHierarchies.Add(wf);
                                });



                        }
                    });

                // add transistion hierarchies
                workflowTemplate.WorkflowTransistionHierarchyTemplates.ToList().ForEach(item =>
                {
                    var workflowTH = new WorkflowTransistionHierarchy
                    {
                        IsWorkflowEnd = item.IsWorkflowEnd,
                        IsWorkflowStart = item.IsWorkflowStart,
                        ChildComponentID = item.ChildComponentID,
                        ParentComponentID = item.ParentComponentID,
                        WorkflowVersionNumber = versionNumber,
                        WorkflowID = workflow.WorkflowID,
                        WorkflowTransistionHierarchyID = Guid.NewGuid()
                    };

                    scope.DbContext.WorkflowTransistionHierarchies.Add(workflowTH);
                });

                scope.DbContext.Workflows.Add(workflow);


                scope.Save();
            }

            tscope.Complete();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return workflow;
        }
    }
}
