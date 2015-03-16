using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Data.Infrastructure;
//Bec.TargetFramework.Entities
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Workflow.Engine;
using Bec.TargetFramework.Workflow.Interfaces;
using Bec.TargetFramework.Workflow.Providers;
using Omu.ValueInjecter;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.Workflow.Logic
{
    public class WorkflowInstanceLogic : LogicBase
    {
        private WorkflowEngine m_Engine;

        public WorkflowInstanceLogic(ILogger logger,ICacheProvider cacheProvider,WorkflowEngine engine)
            : base(logger,cacheProvider)
        {
            m_Engine = engine;
        }

        public List<WorkflowInstanceDTO> GetWorkflowInstancesForParentID(Guid parentID)
        {
            List<WorkflowInstanceDTO> instances = new List<WorkflowInstanceDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var repos = scope.GetGenericRepositoryNoTracking<WorkflowInstance, Guid>();

                repos.FindAll(s => s.ParentID.Equals(parentID)).ToList()
                    .ForEach(item =>
                    {
                        WorkflowInstanceDTO dto = new WorkflowInstanceDTO();

                        dto.InjectFrom<NullableInjection>(item);

                        instances.Add(dto);
                    });
            }

            return instances;
        }

        public WorkflowInstanceDTO ScheduleCreationOfWorkflowInstance(Guid workflowID, int versionNumber, Guid parentID)
        {
            IWorkflowContainer container = m_Engine.CreateNewWorkflowInstanceContainerNotStarted(workflowID, versionNumber, parentID, new ConcurrentDictionary<string, object>());

            WorkflowInstanceDTO dto = new WorkflowInstanceDTO();
            dto.WorkflowInstanceID = container.WorkflowInstance.ID;

            return dto;
        }

        public WorkflowInstanceStatusOverviewDTO GetWorkflowInstanceStatus(Guid workflowInstanceID)
        {
            WorkflowInstanceStatusOverviewDTO ovweDto = new WorkflowInstanceStatusOverviewDTO();

            using (
                var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger)
                )
            {
                var repos = scope.GetGenericRepositoryNoTracking<WorkflowInstance, Guid>();

                WorkflowInstanceDTO dto = new WorkflowInstanceDTO();
                dto.WorkflowInstanceID = workflowInstanceID;
                ovweDto.Instance = dto;

                // get current status
                scope.DbContext.VWorkflowInstanceStatus.Where(s => s.WorkflowInstanceID.Equals(workflowInstanceID)).AsNoTracking().ToList()
                    .ForEach(item =>
                    {
                        WorkflowInstanceStatusDTO sDTO = new WorkflowInstanceStatusDTO();
                        sDTO.InjectFrom<NullableInjection>(item);
                        ovweDto.InstanceStatuses.Add(sDTO);
                    });
            }

            // determine current status
            return ovweDto;
        }

        public List<Entities.WorkflowInstanceProgressDTO> GetWorkflowInstanceProgress(Guid workflowInstanceID)
        {
            List<Entities.WorkflowInstanceProgressDTO> list = new List<WorkflowInstanceProgressDTO>();

            using (
                var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger)
                )
            {
                scope.DbContext.VWorkflowInstanceProgresses.Where(s => s.WorkflowInstanceID.Equals(workflowInstanceID)).AsNoTracking()
                    .ToList()
                    .ForEach(item =>
                    {
                        WorkflowInstanceProgressDTO dto = new WorkflowInstanceProgressDTO();

                        dto.InjectFrom<NullableInjection>(item);

                        list.Add(dto);
                    });
            }

            return list;
        }

        public Entities.WorkflowInstanceDTO ScheduleRestartOfWorkflowInstance(Guid workflowInstanceID)
        {
            IWorkflowContainer container = m_Engine.LoadWorkflowInstanceContainerNotStarted(workflowInstanceID);
              
            WorkflowInstanceDTO dto = new WorkflowInstanceDTO();
            dto.WorkflowInstanceID = container.WorkflowInstance.ID;

            return dto;
        }

        public WorkflowInstanceDTO ScheduleExecutionOfWorkflowAction(Guid workflowInstanceID)

        {
            return null;
        }

    }
}
