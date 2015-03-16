using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bec.TargetFramework.Entities.Validators;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Infrastructure.Log;
//Bec.TargetFramework.Entities
using BrockAllen.MembershipReboot;
using Newtonsoft.Json.Linq;
using ServiceStack.Text;
using Ext.Net;
using Ext.Net.MVC;
using Bec.TargetFramework.Infrastructure.Helpers;
using Fabrik.Common;

using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.UI.Web.Areas.Component.Controllers
{
    public class BranchOrganisationController : ApplicationControllerBase
    {
        private IOrganisationLogic m_Logic;

        public BranchOrganisationController(IOrganisationLogic logic,ILogger logger)
            : base(logger)
        {
            m_Logic = logic;
        }
        //
        // GET: /Component/OrganisationUnit/
        public ActionResult Index()
        {
            return View();
        }

        #region Branches

        public ActionResult GetBranches(string branchesJsonValue)
        {
            var branchesList = JsonSerializer.DeserializeFromString<List<ContactDTO>>(branchesJsonValue);

            if (branchesList != null && branchesList.Count > 0)
            {
                return this.Store(branchesList.ToList());
            }
            else
                return this.Store(new List<ContactDTO>());
        }

        [HttpPost]
        public virtual ActionResult ShowAddOrganisationBranchWindow(string id, string branchesJsonValue)
        {
            return CreateAddBranchWindow(id, branchesJsonValue);
        }

        /// <summary>
        /// Organisation Edit Administration Area for Adding Branch
        /// </summary>
        /// <param name="id"></param>
        /// <param name="branchesJsonValue"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult ShowAddOrganisationBranchWindowWithinAdmin(string id)
        {
            Ensure.Argument.NotNullOrEmpty(id);

            var organisationId = Guid.Parse(id);

            var branches = m_Logic.GetOrganisationBranches(organisationId);

            return CreateAddBranchWindow(id, JsonSerializer.SerializeToString(branches),true);
        }

        private DirectResult CreateAddBranchWindow(string id, string branchesJsonValue, bool organisationIsConcrete = false)
        {
            Ext.Net.Window window = new Window.Builder()
                .ID("OrganisationBranchAddWindow")
                .Title("Add Branch")
                .Icon(Icon.Application)
                .AutoRender(false)
                .Width(800)
                .Height(800)
                .CloseAction(CloseAction.Destroy)
                .BodyPadding(5)
                .Modal(true)
                .Loader(Html.X()
                    .ComponentLoader()
                    .AjaxOptions(new AjaxOptions { Method = HttpMethod.POST })
                    .Url(Url.Action("AddOrganisationBranch", "BranchOrganisation", new { area = "Component", id = id, branchesJsonValue = branchesJsonValue, organisationIsConcrete = organisationIsConcrete }))
                    .Mode(LoadMode.Frame));

            if(organisationIsConcrete)
                window.Render(RenderMode.AddTo, "BranchesAndUsersForm");
            else
                window.Render(RenderMode.AddTo, "OrganisationOtherForm");

            window.Show();

            return this.Direct();
        }

        public virtual ActionResult DeleteOrganisationBranch(string id, string branchesJsonValue)
        {
            Ensure.NotNullOrEmpty(id);

            if (branchesJsonValue == null)
            {
                m_Logic.DeleteOrganisationBranch(Guid.Parse(id));
            }
            else
            {
                var branchList = JsonSerializer.DeserializeFromString<List<ContactDTO>>(branchesJsonValue);

                var selectedBranch = branchList.Single(it => it.ContactID.Equals(Guid.Parse(id)));

                branchList.Remove(selectedBranch);

                var hidden = this.GetCmp<Hidden>("BranchesJson");

                hidden.SetValue(JsonSerializer.SerializeToString(branchList));

                hidden.Update();
            }
           // Ext.Net.MessageBus.Default.Publish("DeleteOrganisationBranch");

            return this.Direct();
        }

        public virtual ActionResult AddOrganisationBranch(string id, string branchesJsonValue,bool organisationIsConcrete)
        {
            var BranchList = JsonSerializer.DeserializeFromString<List<ContactDTO>>(branchesJsonValue);

            return View(new ContactDTO{ ContactJson = branchesJsonValue, ContactID = Guid.NewGuid(), OrganisationID = id , IsConcreteOrganisation = organisationIsConcrete});
                
        }

        [HttpPost]
        public virtual ActionResult AddOrganisationBranch(ContactDTO model)
        {
            if (model != null && ModelState.IsValid)
            {
                var branchList = JsonSerializer.DeserializeFromString<List<ContactDTO>>(model.ContactJson);
                var addressList = JsonSerializer.DeserializeFromString<List<AddressDTO>>(model.AddressesJson);

                List<string> errors = new List<string>();

                new WizardContactDTOValidator(branchList,addressList)
                    .Validate(model).Errors.ToList()
                    .ForEach(er => errors.Add(er.ErrorMessage));

                if (errors.Count > 0)
                {
                    ConstructFormErrors("BranchFormErrors", errors);
                    return this.FormPanel(this.ModelState);
                }
                else
                {
                    if (model.IsConcreteOrganisation)
                    {
                        model.Addresses = JsonSerializer.DeserializeFromString<List<AddressDTO>>(model.AddressesJson);
                        m_Logic.SaveOrganisationBranch(model);

                      //  Ext.Net.MessageBus.Default.Publish("AddOrganisationBranch");

                        X.Js.Call("window.parent.closeAddWindowAndUpdateBranch('" +
                                  JsonSerializer.SerializeToString(branchList) + "')");
                    }
                    else
                    {
                        model.ContactJson = string.Empty;

                        // base64 encode addresses
                        model.AddressesJson = EncodingHelper.Base64Encode(model.AddressesJson);

                        branchList.Add(model);

                        X.Js.Call("window.parent.closeAddWindowAndUpdateBranch('" +
                                  JsonSerializer.SerializeToString(branchList) + "')");
                    }
                }
            }

            return this.FormPanel(this.ModelState);
        }

        [HttpPost]
        public virtual ActionResult ShowEditOrganisationBranchWindowWithinAdmin(string id, string contactId)
        {
            Ensure.Argument.NotNullOrEmpty(id);
            var organisationId = Guid.Parse(id);

            var branches = m_Logic.GetOrganisationBranches(organisationId);

            var branch = branches.Single(item => item.ContactID.Equals(Guid.Parse(contactId)));

            return CreateEditBranchWindow(contactId, JsonSerializer.SerializeToString(branch), organisationId.ToString(), true);
        }

        [HttpPost]
        public virtual ActionResult ShowEditOrganisationBranchWindow(string id, string branchesJsonValue)
        {
            return CreateEditBranchWindow(id, branchesJsonValue);
        }


        [HttpPost]
        public virtual ActionResult CreateEditBranchWindow(string id, string branchesJsonValue, string organisationID = null, bool organisationIsConcrete = false)
        {
            Ext.Net.Window window = new Window.Builder()
                .ID("OrganisationBranchEditWindow")
                .Title("Edit Branch")
                .Icon(Icon.Application)
                .AutoRender(false)
                .Width(800)
                .Height(800)
                .CloseAction(CloseAction.Destroy)
                .BodyPadding(5)
                .Modal(true)
                .Loader(Html.X()
                    .ComponentLoader()
                    .AjaxOptions(new AjaxOptions { Method = HttpMethod.POST })
                    .Url(Url.Action("EditOrganisationBranch", "BranchOrganisation", new { area = "Component", id = id, branchesJsonValue = branchesJsonValue, organisationID = organisationID,  organisationIsConcrete = organisationIsConcrete }))
                    .Mode(LoadMode.Frame));

            if (organisationIsConcrete)
                window.Render(RenderMode.AddTo, "BranchesAndUsersForm");
            else
                window.Render(RenderMode.AddTo, "OrganisationOtherForm");

            window.Show();

            return this.Direct();
        }

        public virtual ActionResult EditOrganisationBranch(string id, string branchesJsonValue, string organisationID , bool organisationIsConcrete)
        {

            var branchList = JsonSerializer.DeserializeFromString<List<ContactDTO>>(branchesJsonValue);

            var branch = branchList.Single(item => item.ContactID.Equals(Guid.Parse(id)));

            branch.ContactJson = branchesJsonValue;

            // create address list items collction
            branch.AddressListItems = new List<string>();
            var addressList = new List<AddressDTO>();
            if (organisationIsConcrete)
            {
                addressList = m_Logic.GetAllBranchAddresses(Guid.Parse(id));
                branch.AddressesJson = JsonSerializer.SerializeToString(addressList);

                addressList.ForEach(it =>
                {
                    branch.AddressListItems.Add(it.Name);
                });
            }
            else
            {
                branch.AddressesJson = EncodingHelper.Base64Decode(branch.AddressesJson);
                addressList = JsonSerializer.DeserializeFromString<List<AddressDTO>>(branch.AddressesJson);

                addressList.ForEach(it =>
                {
                    branch.AddressListItems.Add(it.Name);
                });
            }
            
            branch.OrganisationID = organisationID;
            branch.IsConcreteOrganisation = organisationIsConcrete;
            return View(branch);
        }

        [HttpPost]
        public virtual ActionResult EditOrganisationBranch(ContactDTO model)
        {
            if (model != null && ModelState.IsValid)
            {
                var branchList = JsonSerializer.DeserializeFromString<List<ContactDTO>>(model.ContactJson);
                var addressList = JsonSerializer.DeserializeFromString<List<AddressDTO>>(model.AddressesJson);

                if(model.IsConcreteOrganisation)
                {
                    var branches = m_Logic.GetAllBranches(Guid.Parse(model.OrganisationID));
                    if (branches.Count > 0)
                        branches.ForEach(branch => {
                            if (branch.ContactID != model.ContactID)
                                branchList.Add(branch);
                        });
                }

                List<string> errors = new List<string>();

                new WizardContactDTOValidator(branchList, addressList)
                    .Validate(model).Errors.ToList()
                    .ForEach(er => errors.Add(er.ErrorMessage));

                if (errors.Count > 0)
                {
                    ConstructFormErrors("BranchFormErrors", errors);
                    return this.FormPanel(this.ModelState);
                }
                else
                {
                    if (model.IsConcreteOrganisation)
                    {

                        model.Addresses = JsonSerializer.DeserializeFromString<List<AddressDTO>>(model.AddressesJson);

                        m_Logic.SaveOrganisationBranch(model);

                        //Ext.Net.MessageBus.Default.Publish("EditOrganisationBranch");

                        X.Js.Call("window.parent.closeEditWindowAndUpdateBranch('" +
                                  JsonSerializer.SerializeToString(branchList) + "')");
                    }
                    else
                    {
                        branchList.Remove(branchList.Single(it => it.ContactID.Equals(model.ContactID)));

                        model.ContactJson = string.Empty;

                        branchList.Add(model);

                        X.Js.Call("window.parent.closeEditWindowAndUpdateBranch('" +
                                  JsonSerializer.SerializeToString(branchList) + "')");
                    }
                }

            }

            return this.FormPanel(this.ModelState);
        }

        public ActionResult GetBranchesforOrg(string id)
        {
            Guid orgid = string.IsNullOrEmpty(id) ? Guid.Empty : Guid.Parse(id);

            var branchList = m_Logic.GetOrganisationBranches(orgid);
            if (branchList != null && branchList.Count > 0)
            {
                return this.Store(branchList.ToList());
            }
            else
                return this.Store(new List<vBranchDTO>());
        }

        #endregion


    }
}