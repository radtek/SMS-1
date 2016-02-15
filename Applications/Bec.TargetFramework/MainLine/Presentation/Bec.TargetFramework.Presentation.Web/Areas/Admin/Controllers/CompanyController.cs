﻿using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    [ClaimsRequired("Add", "Company", Order = 1000)]
    public class CompanyController : ApplicationControllerBase
    {
        public IOrganisationLogicClient OrganisationClient { get; set; }
        public INotificationLogicClient NotificationClient { get; set; }
        public IUserLogicClient UserLogicClient { get; set; }
        public IQueryLogicClient queryClient { get; set; }

        public ActionResult Provisional()
        {
            return View();
        }

        public ActionResult Qualified()
        {
            return View();
        }

        public async Task<ActionResult> LoadCompanies(ProfessionalOrganisationStatusEnum orgStatus)
        {
            List<VOrganisationWithStatusAndAdminDTO> list = await OrganisationClient.GetCompaniesAsync(orgStatus);

            var jsonData = new { total = list.Count, list };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ViewRejectTempCompany(Guid orgId, int? returnTab)
        {
            var org = await OrganisationClient.GetOrganisationDTOAsync(orgId);
            if (org == null) return new HttpNotFoundResult("Organisation not found");
            return PartialView("_RejectTempCompany", new RejectCompanyDTO { OrganisationId = orgId, CompanyName = org.Name, ReturnTab = returnTab ?? 0 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RejectTempCompany(RejectCompanyDTO model)
        {
            await OrganisationClient.RejectOrganisationAsync(model);
            TempData["tabIndex"] = model.ReturnTab;
            return RedirectToAction("Provisional");
        }

        public async Task<ActionResult> ViewUnverify(Guid orgId)
        {
            var org = await OrganisationClient.GetOrganisationDTOAsync(orgId);
            if (org == null) return new HttpNotFoundResult("Organisation not found");
            return PartialView("_Unverify", new RejectCompanyDTO { OrganisationId = orgId, CompanyName = org.Name, ReturnTab = 0 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Unverify(RejectCompanyDTO model)
        {
            await OrganisationClient.UnverifyOrganisationAsync(model);
            return RedirectToAction("Provisional");
        }

        public async Task<ActionResult> ViewVerify(Guid orgId)
        {
            var org = await OrganisationClient.GetOrganisationWithStatusAndAdminAsync(orgId);
            if (org == null) return new HttpNotFoundResult("Organisation not found");

            VerifyCompanyDTO dto = new VerifyCompanyDTO
            {
                OrganisationID = orgId,
                UaoID = org.UserAccountOrganisationID,
                OrganisationName = org.Name,
                RegulatorName = org.Regulator,
                RegulatorNumber = org.RegulatorNumber,
                OrganisationType = org.OrganisationTypeDescription,
                FilesPerMonth = org.FilesPerMonth > 0 ? org.FilesPerMonth : (int?)null,
                IsAuthorityDelegated = !string.IsNullOrWhiteSpace(org.AuthorityDelegatedByEmail)
            };
            // ZM: IMPORTANT! The way the function is presented is different from how it is stored in DB
            // hence the confusion with AuthorityDelegatedToSalutation and AuthorityDelegatedBySalutation
            // fields differ with 'To' and 'By'
            if (dto.IsAuthorityDelegated)
            {
                dto.Salutation = org.AuthorityDelegatedBySalutation;
                dto.FirstName = org.AuthorityDelegatedByFirstName;
                dto.LastName = org.AuthorityDelegatedByLastName;
                dto.Email = org.AuthorityDelegatedByEmail;
                dto.AuthorityDelegatedToSalutation = org.OrganisationAdminSalutation;
                dto.AuthorityDelegatedToFirstName = org.OrganisationAdminFirstName;
                dto.AuthorityDelegatedToLastName = org.OrganisationAdminLastName;
                dto.AuthorityDelegatedToEmail = org.OrganisationAdminEmail;
            }
            else
            {
                dto.Salutation = org.OrganisationAdminSalutation;
                dto.FirstName = org.OrganisationAdminFirstName;
                dto.LastName = org.OrganisationAdminLastName;
                dto.Email = org.OrganisationAdminEmail;
            }
            
            return PartialView("_Verify", dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Verify(VerifyCompanyDTO dto)
        {
            await EnsureSroUaoIsInOrg(dto.UaoID, dto.OrganisationID, queryClient);
            //set org status
            await OrganisationClient.AddOrganisationStatusAsync(dto.OrganisationID, StatusTypeEnum.ProfessionalOrganisation, ProfessionalOrganisationStatusEnum.Verified, null, dto.PhoneNumber);
            await OrganisationClient.UpdateOrganisationDetailsAsync(dto);

            TempData["VerifiedCompanyId"] = dto.OrganisationID;
            TempData["tabIndex"] = 1;
            return RedirectToAction("Provisional");
        }

        public async Task<ActionResult> ViewGeneratePin(Guid orgId, Guid uaoId, bool setVerified)
        {
            var org = await OrganisationClient.GetOrganisationDTOAsync(orgId);
            if (org == null) return new HttpNotFoundResult("Organisation not found");
            ViewBag.orgId = orgId;
            ViewBag.uaoId = uaoId;
            ViewBag.companyName = org.Name;
            ViewBag.setVerified = setVerified;
            return PartialView("_GeneratePin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GeneratePin(Guid orgId, Guid uaoId, bool setVerified)
        {
            if (setVerified)
            {
                var orgDetails = OrganisationClient.GetOrganisationWithStatusAndAdmin(orgId);
                await OrganisationClient.AddOrganisationStatusAsync(orgId, StatusTypeEnum.ProfessionalOrganisation, ProfessionalOrganisationStatusEnum.Verified, null, orgDetails.VerifiedNotes);
            }
            await UserLogicClient.GeneratePinAsync(uaoId, false, true, false);

            TempData["VerifiedCompanyId"] = orgId;
            TempData["tabIndex"] = 1;
            return RedirectToAction("Provisional");
        }

        public ActionResult ViewAddNotes(Guid orgID, bool qualified)
        {
            ViewBag.orgID = orgID;
            ViewBag.qualified = qualified;
            return PartialView("_AddNotes");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNotes(Guid orgID, string notes, bool qualified)
        {
            await OrganisationClient.AddNotesAsync(orgID, WebUserHelper.GetWebUserObject(HttpContext).UaoID, notes);
            if (qualified)
            {
                TempData["QualifiedCompanyId"] = orgID;
                return RedirectToAction("Qualified");
            }
            else
            {
                TempData["VerifiedCompanyId"] = orgID;
                TempData["tabIndex"] = 1;
                return RedirectToAction("Provisional");
            }
        }

        public async Task<ActionResult> GetNotes(Guid orgID)
        {
            var select = ODataHelper.Select<OrganisationNoteDTO>(x => new { x.Notes, x.UserAccountOrganisation.Contact.FirstName, x.UserAccountOrganisation.Contact.LastName, x.DateTime });
            var filter = ODataHelper.Filter<OrganisationNoteDTO>(x => x.OrganisationID == orgID);
            var order = ODataHelper.OrderBy<OrganisationNoteDTO>(x => new { x.DateTime }) + " desc";
            var res = await queryClient.QueryAsync<OrganisationNoteDTO>("OrganisationNotes", select + filter + order);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        internal static async Task EnsureSroUaoIsInOrg(Guid uaoID, Guid orgID, IQueryLogicClient client)
        {
            var select = ODataHelper.Select<UserAccountOrganisationDTO>(x => new { x.OrganisationID });
            var filter = ODataHelper.Filter<UserAccountOrganisationDTO>(x => x.UserAccountOrganisationID == uaoID && x.OrganisationID == orgID && x.Contact.IsPrimaryContact);
            var result = await client.QueryAsync<UserAccountOrganisationDTO>("UserAccountOrganisations", select + filter);
            if (!result.Any()) throw new AccessViolationException("Operation failed");
        }

        public ActionResult ViewRegisterLender()
        {
            return PartialView("_RegisterLender", new AddCompanyDTO { OrganisationType = OrganisationTypeEnum.Lender });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterLender(AddCompanyDTO model)
        {
            var orgId = await OrganisationClient.AddNewUnverifiedOrganisationAndAdministratorAsync(model);
            TempData["AddTempCompanyId"] = orgId;
            TempData["tabIndex"] = 0;
            return RedirectToAction("Provisional");
        }
    }
}