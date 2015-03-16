using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Bec.TargetFramework.Entities
using Ext.Net;
using Ext.Net.MVC;
using Fabrik.Common;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Infrastructure.Log;
using ServiceStack.Text;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Web.Framework.Helpers;
using Bec.TargetFramework.Web.Framework.Extensions;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.UI.Web.Areas.Component.Controllers
{
    public class OrganisationController : ApplicationControllerBase
    {
        private IOrganisationLogic m_OrganisationLogic;

        public OrganisationController(IOrganisationLogic logic,ILogger logger)
            : base(logger)
        {
            m_OrganisationLogic = logic;
        }

        public StoreResult GetOrganisations(StoreRequestParameters parameters, string SearchQuery)
        {
            Func<List<vOrganisationDTO>> funcList = () => { return m_OrganisationLogic.GetAllOrganisationDetailDTO(SearchQuery); };

            return this.Store(new GridPagingHelper<vOrganisationDTO>(funcList, "Name").GetPaging(parameters));
        }
        public ActionResult GetOrganisationTemplates(int typeId)
        {
            List<VOrganisationTemplateDTO> orgTemps = m_OrganisationLogic.GetOrganisationTemplatesforOrganisationType(typeId);
            return this.Store(orgTemps);
        }
        /// <summary>
        /// Gets the organisation details list.
        /// </summary>
        /// <returns></returns>
        public ActionResult GetOrganisationDetails(string id)
        {
            List<OrganisationDetailDTO> orgList = new List<OrganisationDetailDTO>();
            if (id != null)
                orgList = m_OrganisationLogic.GetOrganisationDetailsIncludingBranches(id);
            else
                 orgList = m_OrganisationLogic.GetOrganisationDetails();
            return this.Store(orgList);
        }

        /// <summary>
        /// Ges the organisation units list.
        /// </summary>
        /// <param name="id">The organisation identifier.</param>
        /// <returns></returns>
        public ActionResult GeOrganisations(string id)
        {
            Guid orgId = string.IsNullOrEmpty(id) ? Guid.Empty : Guid.Parse(id);
            List<OrganisationUnitDTO> unitList = m_OrganisationLogic.GetOrganisationUnits(orgId);
            return this.Store(unitList);
        }

        /// <summary>
        /// Ges the organisation units list.
        /// </summary>
        /// <param name="id">The organisation identifier.</param>
        /// <returns></returns>
        public ActionResult GeOrganisationUnits(string id)
        {
            Guid orgId = string.IsNullOrEmpty(id) ? Guid.Empty : Guid.Parse(id);
            List<OrganisationUnitDTO> unitList = m_OrganisationLogic.GetOrganisationUnits(orgId);
            return this.Store(unitList);
        }

        public ActionResult OrganisationManagement(string containerId)
        {
            return this.CreatePartialViewResult("OrganisationManagement"
                , containerId
                , new vOrganisationDTO());
        }

        //
        // GET: /Component/Organisation/
        public ActionResult OrganisationDetail(string containerId)
        {
            var result = new Ext.Net.MVC.PartialViewResult
            {
                ViewName = "OrganisationDetail",
                RenderMode = RenderMode.AddTo,
                Model = new OrganisationDTO(),
                ClearContainer = true,
                ContainerId = containerId,
                WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required
            };

            return result;
        }

        public ActionResult AddOrganisationWizardToContainer(string containerId)
        {
            var result = new Ext.Net.MVC.PartialViewResult
            {
                ViewName = "OrganisationWizard",
                RenderMode = RenderMode.AddTo,
                Model = new OrganisationDTO(),
                ClearContainer = true,
                ContainerId = containerId,
                WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required
            };

            return result;
        }

        [HttpPost]
        public ActionResult ValidateOrganisationDetail(OrganisationDetailDTO viewModel)
        {
            Ensure.NotNull(viewModel);

            List<string> errors = new List<string>();

            ConstructFormErrors("DetailFormErrors", errors);

            return this.Direct();
        }

        public ActionResult ValidateOrganisationOther(OrganisationDetailDTO viewModel)
        {
            Ensure.NotNull(viewModel);

            List<string> errors = new List<string>();

            ConstructFormErrors("OrganisationOtherFormErrors", errors);

            return this.Direct();
        }

         public ActionResult ValidateOrganisationUser(OrganisationDetailDTO viewModel)
        {
            Ensure.NotNull(viewModel);

            List<string> errors = new List<string>();

            ConstructFormErrors("OrganisationOtherFormErrors", errors);

            return this.Direct();
        }

        [HttpPost]
        public ActionResult OrganisationWizardFinish(OrganisationDTO model, int index)
        {
            if (ModelState.IsValid)
            {
                                
                model.Branches = JsonSerializer.DeserializeFromString<List<ContactDTO>>(model.BranchesJson);
                model.Users = JsonSerializer.DeserializeFromString<List<ContactDTO>>(model.UsersJson);
                model.Units = JsonSerializer.DeserializeFromString<List<OrganisationUnitDTO>>(model.UnitsJson);

                // decode all addresses
                model.Branches.ForEach(it =>
                {
                    it.Addresses = JsonSerializer.DeserializeFromString<List<AddressDTO>>(EncodingHelper.Base64Decode(it.AddressesJson));
                });

                model.Users.ForEach(it =>
                {
                    it.Addresses = JsonSerializer.DeserializeFromString<List<AddressDTO>>(EncodingHelper.Base64Decode(it.AddressesJson));
                });

                m_OrganisationLogic.AddNewOrganisationFromWizard(model);
                return OrganisationManagement("AdministrationCenterPanel");
            }

            return this.FormPanel(this.ModelState);
        }

        public virtual ActionResult Delete(string id)
        {
            Ensure.NotNullOrEmpty(id);

            m_OrganisationLogic.ActivateDeactivateOrDeleteOrganisation(Guid.Parse(id), true);

            return this.Direct();
        }
        public virtual ActionResult ActivateOrDeactivate(string id)
        {
            Ensure.NotNullOrEmpty(id);

            m_OrganisationLogic.ActivateDeactivateOrDeleteOrganisation(Guid.Parse(id), false);

            return this.Direct();
        }

        #region Wizard

        public ActionResult Next_Click(int index, int total)
        {
            if (index < total)
            {
                this.GetCmp<Panel>("OrganisationWizardPanel").ActiveIndex = index + 1;
                this.CheckButtons(index + 1);
            }
            else
                this.CheckButtons(index);


            return this.Direct();
        }

        public ActionResult Prev_Click(int index, int total)
        {
            if ((index - 1) >= 0)
            {
                this.GetCmp<Panel>("OrganisationWizardPanel").ActiveIndex = index - 1;

                this.CheckButtons(index - 1);
            }
            else
                this.CheckButtons(index);

            return this.Direct();
        }

        private void CheckButtons(int index)
        {
            this.GetCmp<Button>("btnNext").Disabled = index == 2;
            this.GetCmp<Button>("btnPrev").Disabled = index == 0;
        }

        #endregion

        #region Remote Validation
        public virtual JsonResult DoesOrganisationNameExist()
            {
            bool valid = true;
            var orgname = Request.Form["value"];
            if (!string.IsNullOrEmpty(orgname))
                valid = !(m_OrganisationLogic.DoesOrganisationNameExist(orgname));

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}