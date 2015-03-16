using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.UI.Web.Areas.Workflow.Controllers
{
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.UI.Process.Base;
    using Bec.TargetFramework.Workflow.Interfaces;

    using Fabrik.Common;

    using NHibernate.Engine;

    public class WorkflowController : ApplicationControllerBase
    {
        private IWorkflowProcessService m_WorkflowProcessLogic;

        public WorkflowController(ILogger logger, IWorkflowProcessService logic)
            : base(logger)
        {
            m_WorkflowProcessLogic = logic;
        }

        // GET: Workflow/Workflow
        public ActionResult Index(string workflowInstanceID)
        {

            workflowInstanceID = "b4b40c4f-9119-4b5a-bc9c-3da7d3cb4934";
            Ensure.Argument.NotNull(workflowInstanceID);

            var dto =
                m_WorkflowProcessLogic.GetCurrentWorkflowInstanceManualActionNotCompleted(
                    Guid.Parse(workflowInstanceID));

            // need to hide parameters so use TempData
            Session.Add("WorkflowDTO",dto);


            return RedirectToAction(
                dto.CurrentActionDTO.ActionName,
                dto.CurrentActionDTO.ControllerName,
                new
                    {
                        area = dto.CurrentActionDTO.AreaName,
                        isProcessed = false
                    }
                );
        }
    }
}