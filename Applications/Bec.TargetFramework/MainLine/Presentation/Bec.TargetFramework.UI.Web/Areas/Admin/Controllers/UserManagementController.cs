using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

//Bec.TargetFramework.Entities
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Web.Framework.Extensions;
using Bec.TargetFramework.Web.Framework.Helpers;
using Ext.Net.MVC;
using Ext.Net;
using ServiceStack.Text;
using System.Threading.Tasks;
using Fabrik.Common;
using System.ComponentModel.DataAnnotations;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Data.Infrastructure.Linq;
using Bec.TargetFramework.Entities.Validators;
using BrockAllen.MembershipReboot;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.UI.Web.Areas.Admin.Controllers
{
    public class UserManagementController :ApplicationControllerBase
    {
        private IUserLogic m_UserLogic;
        private UserAccountService m_UaService;

        public UserManagementController(UserAccountService uaService, IUserLogic logic, ILogger logger)
            : base(logger)
        {
            m_UserLogic = logic;
            m_UaService = uaService;
        }
        /// <summary>
        /// Users management.
        /// </summary>
        /// <param name="containerId">The container identifier.</param>
        /// <returns>vUserManagementDTO view</returns>
        public ActionResult UserManagement(string containerId, string id)
        {
            UserManagementCritieraDTO dto = new UserManagementCritieraDTO();
            if (!string.IsNullOrEmpty(id))
                dto.OrganisationID = Guid.Parse(id);
            return this.CreatePartialViewResult("UserManagement",
                containerId,
                dto);
        }

        /// <summary>
        /// Gets the user management.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="dto">The user management search criteria dto.</param>
        /// <returns></returns>
        public StoreResult GetUserManagement(StoreRequestParameters parameters, UserManagementCritieraDTO dto)
        {
            SortingPagingDto pagingDto = new SortingPagingDto { PageNumber = parameters.Page-1,PageSize=parameters.Limit};

            var data = new Paging<vUserManagementDTO>(m_UserLogic.GetAllUserManagementDTO(pagingDto, dto),m_UserLogic.GetAllUserManagementDTOCount(pagingDto, dto));

            return this.Store(data);
        }

       
        /// <summary>
        /// Activates the or deactivate the user
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns></returns>
        public virtual ActionResult ActivateOrDeactivate(string id)
        {
            Ensure.NotNullOrEmpty(id);
            Guid userId = string.IsNullOrEmpty(id) ? Guid.Empty : Guid.Parse(id);
            m_UserLogic.UpdateUserStatus(userId, false);
            return this.Direct();
        }

        /// <summary>
        /// Lock or unlock user
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns></returns>
        public virtual ActionResult LockOrUnlock(string id)
        {
            Ensure.NotNullOrEmpty(id);
            Guid userId = string.IsNullOrEmpty(id) ? Guid.Empty : Guid.Parse(id);
            m_UserLogic.LockOrUnlockUser(userId);
            return this.Direct();
        }

        /// <summary>
        /// Deletes the specified user. Update IsDeleted flag
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public virtual ActionResult Delete(string id)
        {
            Ensure.NotNullOrEmpty(id);
            Guid userId = string.IsNullOrEmpty(id) ? Guid.Empty : Guid.Parse(id);
            m_UserLogic.UpdateUserStatus(userId, true);
            return this.Direct();
        }

        public virtual ActionResult EditUser(string id, string containerId)
        {
            Ensure.NotNullOrEmpty(id);
            var contact = m_UserLogic.EditUser(Guid.Parse(id));
            
            List<AddressDTO> addressList = new List<AddressDTO>();
            if (contact != null)
            {
                addressList = m_UserLogic.GetUserAddresses(contact.ContactID);
                if (addressList.Count > 0)
                {
                    contact.AddressesJson = JsonSerializer.SerializeToString(addressList);
                    addressList.ForEach(item =>
                    {
                        contact.AddressListItems.Add(item.Name);
                    });
                }
            }

            return this.CreatePartialViewResult("EditUserManagement", containerId, contact);
        }

        public virtual ActionResult AddUser(string containerId)
        {
            var result = new Ext.Net.MVC.PartialViewResult
            {
                ViewName = "AddUserManagement",
                RenderMode = RenderMode.AddTo,
                Model = new ContactDTO(),
                ClearContainer = true,
                ContainerId = containerId,
                WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required

            };

            return result;
        }

        public virtual ActionResult GerUserManagementDTO(string id, string containerId)
        {
            Ensure.NotNullOrEmpty(id);
            var user = m_UserLogic.GerUserManagementDTO(Guid.Parse(id));
            return this.CreatePartialViewResult("EditUserGroupsRoles", containerId, user);
        }


        public virtual ActionResult GetUserRoles(string userId, string orgId)
        {
            Guid id = string.IsNullOrEmpty(userId) ? Guid.Empty : Guid.Parse(userId);
            Guid organisationId = string.IsNullOrEmpty(orgId) ? Guid.Empty : Guid.Parse(orgId);

            return Json(new { data = m_UserLogic.GetUserRoles(id, organisationId) }, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult GetOrganisationRoles(string userId, string orgId)
        {
            Guid id = string.IsNullOrEmpty(userId) ? Guid.Empty : Guid.Parse(userId);
            Guid organisationId = string.IsNullOrEmpty(orgId) ? Guid.Empty : Guid.Parse(orgId);

            return Json(new { data = m_UserLogic.GetOrganisationRoles(id, organisationId) }, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult GetUserGroups(string userId, string orgId)
        {
            Guid id = string.IsNullOrEmpty(userId) ? Guid.Empty : Guid.Parse(userId);
            Guid organisationId = string.IsNullOrEmpty(orgId) ? Guid.Empty : Guid.Parse(orgId);

            return Json(new { data = m_UserLogic.GetUserGroups(id, organisationId) }, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult GetOrganisationGroups(string userId, string orgId)
        {
            Guid id = string.IsNullOrEmpty(userId) ? Guid.Empty : Guid.Parse(userId);
            Guid organisationId = string.IsNullOrEmpty(orgId) ? Guid.Empty : Guid.Parse(orgId);

            return Json(new { data = m_UserLogic.GetOrganisationGroups(id, organisationId) }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
         public ActionResult ResetPassword(string email)
        {
            Ensure.NotNullOrEmpty(email);
            try
            {
                m_UserLogic.ResetPassword(email);
            }
            catch (Exception ex)
            {

                return new AjaxResult { ErrorMessage = ex.Message };
            }
            
            return this.Direct();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult EditUserGroupsAndRoles(string userId, string containerId)
        {
            Guid id = string.IsNullOrEmpty(userId) ? Guid.Empty : Guid.Parse(userId);
            
            List<OrganisationRoleDTO> selectedRoles = new List<OrganisationRoleDTO>();
            List<OrganisationGroupDTO> selectedGroups = new List<OrganisationGroupDTO>();

            if (Request.Params["roles"] != null)
                JSON.Deserialize<List<ListItem>>(Request.Params["roles"]).ToList().ForEach(item
                    => selectedRoles.Add(new OrganisationRoleDTO { OrganisationRoleID = new Guid(item.Value.ToString()) }));
            if (Request.Params["groups"] != null)
                JSON.Deserialize<List<ListItem>>(Request.Params["groups"]).ToList().ForEach(item
                    => selectedGroups.Add(new OrganisationGroupDTO { OrganisationGroupID = new Guid(item.Value.ToString()) }));

            m_UserLogic.SaveUserRoles(id, selectedRoles);
            m_UserLogic.SaveUserGroups(id, selectedGroups);
            return this.Direct();
        }

        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult AddUser(ContactDTO model, string containerId)
        {
            if (model != null && ModelState.IsValid)
            {
                List<string> errors = new List<string>();
                new ContactDTOValidator(m_UaService)
                .Validate(model).Errors.ToList()
                .ForEach(er => errors.Add(er.ErrorMessage));

                if (errors.Count > 0)
                {
                    ConstructFormErrors("UserManagementFormErrors", errors);
                    return this.FormPanel(this.ModelState);
                }
                else
                {
                    return this.CreatePartialViewResult("AddUserDetails", containerId, m_UserLogic.AddUser(model));
                }
            }
            return this.Direct();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult AddUserDetails(ContactDTO model, string containerId, string userTypeId, string userCategoryId)
        {
            if (model != null && ModelState.IsValid)
            {
                var addressList = JsonSerializer.DeserializeFromString<List<AddressDTO>>(model.AddressesJson);

                List<string> errors = new List<string>();
                new ContactDTOValidator(m_UaService, addressList)
                .Validate(model).Errors.ToList()
                .ForEach(er => errors.Add(er.ErrorMessage));

                if (errors.Count > 0)
                {
                    ConstructFormErrors("AddUserDetailsFormErrors", errors);
                    return this.FormPanel(this.ModelState);
                }
                else
                {
                    model.Addresses = addressList;
                    model.AddressesJson = EncodingHelper.Base64Encode(model.AddressesJson);
                    m_UserLogic.AddUserDetails(model, userTypeId, userCategoryId);

                    return this.CreatePartialViewResult("AddUserGroupsRoles", containerId, model);
                }

            }
            return this.Direct();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult UpdateUser(ContactDTO model, string containerId)
        {
            var err = ModelState
            .Where(x => x.Value.Errors.Count > 0)
            .Select(x => new { x.Key, x.Value.Errors })
            .ToArray();

            var addressList = JsonSerializer.DeserializeFromString<List<AddressDTO>>(model.AddressesJson);
            model.Addresses = addressList;

            if (model != null && ModelState.IsValid)
            {
                List<string> errors = new List<string>();
                new ContactDTOValidator(m_UaService, addressList)
                .Validate(model).Errors.ToList()
                .ForEach(er => errors.Add(er.ErrorMessage));

                if (errors.Count > 0)
                {
                    ConstructFormErrors("UserManagementFormErrors", errors);
                    return this.FormPanel(this.ModelState);
                }
                else
                {
                    model.AddressesJson = EncodingHelper.Base64Encode(model.AddressesJson);
                    m_UserLogic.UpdateUser(model);
                    return EditUser(model.ParentID.ToString(), containerId);
                }

            }
            return this.Direct();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteAddressToContact(string addressId, string userId, string containerId)
        {
            Ensure.NotNullOrEmpty(addressId);
            Guid userAddressId = string.IsNullOrEmpty(addressId) ? Guid.Empty : Guid.Parse(addressId);
            m_UserLogic.DeleteAddressToContact(userAddressId);
            return EditUser(userId, containerId);
        }

        #region Remote Validation
        public virtual JsonResult IsUserExist()
        {
            bool valid = true;
            var userName = Request.Form["value"];
            if (!string.IsNullOrEmpty(userName))
                valid = !(m_UserLogic.IsUserExist(userName));

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult IsEmailExist()
        {
            bool valid = true;
            var email = Request.Form["value"];
            if (!string.IsNullOrEmpty(email))
                valid = !(m_UserLogic.IsEmailExist(email));

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}