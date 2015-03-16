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
using Bec.TargetFramework.Infrastructure.Helpers;
using Ext.Net;
using Ext.Net.MVC;
using Fabrik.Common;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.UI.Web.Areas.Component.Controllers
{
    public class UserOrganisationController : ApplicationControllerBase
    {
        private UserAccountService m_UaService;
        private AuthenticationService m_AuthSvc;

        public UserOrganisationController(UserAccountService uaService, AuthenticationService authSvc, ILogger logger)
            : base(logger)
        {
            m_UaService = uaService;
            m_AuthSvc = authSvc;
        }
        
        #region Users

        public ActionResult GetUsers(string usersJsonValue)
        {
            var usersList = JsonSerializer.DeserializeFromString<List<ContactDTO>>(usersJsonValue);

            if (usersList != null && usersList.Count > 0)
            {
                return this.Store(usersList.ToList());
            }
            else
                return this.Store(new List<ContactDTO>());

        }

        [HttpPost]
        public virtual ActionResult ShowEditOrganisationUserWindow(string id, string usersJsonValue, string branches, string units)
        {
            Ext.Net.Window window = new Window.Builder()
                .ID("OrganisationUserEditWindow")
                .Title("Edit User")
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
                    .Url(Url.Action("EditOrganisationUser", "UserOrganisation", new { area = "Component", id = id, usersJsonValue = usersJsonValue, branches = branches, units = units }))
                    .Mode(LoadMode.Frame));

            window.Render(RenderMode.AddTo, "OrganisationUserForm");

            window.Show();

            return this.Direct();
        }
        [HttpPost]
        public virtual ActionResult ShowAddOrganisationUserWindow(string id, string usersJsonValue, string branches, string units)
        {
            Ext.Net.Window window = new Window.Builder()
                .ID("OrganisationUserAddWindow")
                .Title("Add User")
                .Icon(Icon.Application)
                .AutoRender(false)
                .Width(800)
                .Height(800)
                .CloseAction(CloseAction.Destroy)
                .BodyPadding(5)
                .Modal(true)
                .Loader(Html.X()
                    .ComponentLoader()
                    .Url(Url.Action("AddOrganisationUser", "UserOrganisation", new { area = "Component", id = id, usersJsonValue = usersJsonValue, branches = branches, units = units }))
                    .Mode(LoadMode.Frame));

            window.Render(RenderMode.AddTo, "OrganisationUserForm");

            window.Show();

            return this.Direct();
        }


        [HttpPost]
        public virtual ActionResult DeleteOrganisationUser(string id, string usersJsonValue)
        {
            Ensure.NotNullOrEmpty(id);

            var branchList = JsonSerializer.DeserializeFromString<List<ContactDTO>>(usersJsonValue);

            var selectedUser = branchList.Single(it => it.ContactID.Equals(Guid.Parse(id)));

            branchList.Remove(selectedUser);

            var hidden = this.GetCmp<Hidden>("UseresJson");

            hidden.SetValue(JsonSerializer.SerializeToString(branchList));

            hidden.Update();

            Ext.Net.MessageBus.Default.Publish("DeleteOrganisationUser");

            return this.Direct();
        }

        public virtual ActionResult AddOrganisationUser(string id, string usersJsonValue,string branches, string units)
        {
            var UserList = JsonSerializer.DeserializeFromString<List<ContactDTO>>(usersJsonValue);
            var BranchList = JsonSerializer.DeserializeFromString<List<ContactDTO>>(branches);
            var UnitList = JsonSerializer.DeserializeFromString<List<OrganisationUnitDTO>>(units);

            List<System.Web.UI.WebControls.ListItem> branchListItems = new List<System.Web.UI.WebControls.ListItem>();
            BranchList.ForEach(it => branchListItems.Add(new System.Web.UI.WebControls.ListItem { Text = it.ContactName, Value = it.ContactName }));

            List<System.Web.UI.WebControls.ListItem> unitsListItems = new List<System.Web.UI.WebControls.ListItem>();
            UnitList.ForEach(it => unitsListItems.Add(new System.Web.UI.WebControls.ListItem { Text = it.Name, Value = it.Name }));

            return View(new ContactDTO { ContactJson = usersJsonValue, ContactID = Guid.NewGuid(), OrgansationsBranches = branchListItems,OrgansationsUnits = unitsListItems});
        }

        [HttpPost]
        public virtual ActionResult AddOrganisationUser(ContactDTO model)
        {
            if (model != null && ModelState.IsValid)
            {
                var branchList = JsonSerializer.DeserializeFromString<List<ContactDTO>>(model.ContactJson);
                var addressList = JsonSerializer.DeserializeFromString<List<AddressDTO>>(model.AddressesJson);

                List<string> errors = new List<string>();

                new WizardContactDTOValidator(m_UaService, addressList)
                    .Validate(model).Errors.ToList()
                    .ForEach(er => errors.Add(er.ErrorMessage));

                if (errors.Count > 0)
                {
                    ConstructFormErrors("ContactFormErrors", errors);
                    return this.FormPanel(this.ModelState);
                }
                else
                {
                    // base64 encode addresses
                    model.AddressesJson = EncodingHelper.Base64Encode(model.AddressesJson);

                    model.ContactJson = string.Empty;

                    branchList.Add(model);

                    X.Js.Call("window.parent.closeAddWindowAndUpdateUser('" +
                              JsonSerializer.SerializeToString(branchList) + "')");
                }
            }

            return this.FormPanel(this.ModelState);
        }


        public virtual ActionResult EditOrganisationUser(string id, string usersJsonValue, string branches, string units)
        {

            var branchList = JsonSerializer.DeserializeFromString<List<ContactDTO>>(usersJsonValue);

            var BranchList = JsonSerializer.DeserializeFromString<List<ContactDTO>>(branches);
            var UnitList = JsonSerializer.DeserializeFromString<List<OrganisationUnitDTO>>(units);

            var branch = branchList.Single(item => item.ContactID.Equals(Guid.Parse(id)));

            branch.ContactJson = usersJsonValue;

            // create address list items collction
            branch.AddressListItems = new List<string>();

            List<System.Web.UI.WebControls.ListItem> branchListItems = new List<System.Web.UI.WebControls.ListItem>();
            BranchList.ForEach(it => branchListItems.Add(new System.Web.UI.WebControls.ListItem { Text = it.ContactName, Value = it.ContactName }));

            List<System.Web.UI.WebControls.ListItem> unitsListItems = new List<System.Web.UI.WebControls.ListItem>();
            UnitList.ForEach(it => unitsListItems.Add(new System.Web.UI.WebControls.ListItem { Text = it.Name, Value = it.Name }));

            branch.OrgansationsBranches = branchListItems;
            branch.OrgansationsUnits = unitsListItems;

            branch.AddressesJson = EncodingHelper.Base64Decode(branch.AddressesJson);

            var addressList = JsonSerializer.DeserializeFromString<List<AddressDTO>>(branch.AddressesJson);

            addressList.ForEach(it =>
            {
                branch.AddressListItems.Add(it.Name);
            });

            return View(branch);
        }

        [HttpPost]
        public virtual ActionResult EditOrganisationUser(ContactDTO model)
        {
            if (model != null && ModelState.IsValid)
            {
                var branchList = JsonSerializer.DeserializeFromString<List<ContactDTO>>(model.ContactJson);
                var addressList = JsonSerializer.DeserializeFromString<List<AddressDTO>>(model.AddressesJson);

                List<string> errors = new List<string>();

                new WizardContactDTOValidator(m_UaService, addressList)
                    .Validate(model).Errors.ToList()
                    .ForEach(er => errors.Add(er.ErrorMessage));

                if (errors.Count > 0)
                {
                    ConstructFormErrors("ContactFormErrors", errors);
                    return this.FormPanel(this.ModelState);
                }
                else
                {

                    branchList.Remove(branchList.Single(it => it.ContactID.Equals(model.ContactID)));

                    model.ContactJson = string.Empty;

                    branchList.Add(model);

                    X.Js.Call("window.parent.closeEditWindowAndUpdateUser('" +
                              JsonSerializer.SerializeToString(branchList) + "')");
                }

            }

            return this.FormPanel(this.ModelState);
        }

        #endregion
    }
}