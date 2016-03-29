using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
using System.Collections.Generic;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Presentation.Web.Models.ToastrNotification;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class HelpController : ApplicationControllerBase
    {
        public IHelpLogicClient HelpClient { get; set; }
        public IQueryLogicClient QueryClient { get; set; }

        public IClassificationDataLogicClient ClassificationClient { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [ClaimsRequired("View", "Help", Order = 1001)]
        public async Task<ActionResult> MarkCalloutAsViewed(Guid helpItemID)
        {
            await HelpClient.MarkCalloutAsViewedAsync(WebUserHelper.GetWebUserObject(HttpContext).UaoID, helpItemID);
            return Json(new { success = true, action = "MarkCalloutAsViewed" });
        }

        private int GetHelpTypeID(string htn)
        {
            int helpTypeID = -1;

            if (htn == HelpTypeEnum.Tour.ToString())
                helpTypeID = HelpTypeEnum.Tour.GetIntValue();
            else if (htn == HelpTypeEnum.Callout.ToString())
                helpTypeID = HelpTypeEnum.Callout.GetIntValue();
             else if (htn == HelpTypeEnum.ShowMeHow.ToString())
                helpTypeID = HelpTypeEnum.ShowMeHow.GetIntValue();

            return helpTypeID;
        }

        [ClaimsRequired("Add", "Help", Order = 1002)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CheckForOnlyOneOfType(string htn)
        {
            var helpTypeID = GetHelpTypeID(htn);

            if(helpTypeID == HelpTypeEnum.ShowMeHow.GetIntValue())
                return Json("true", JsonRequestBehavior.AllowGet);
            
            var doesHelpTypeExist = await HelpClient.DoesTypeAlreadyExistAsync(helpTypeID);

            if (doesHelpTypeExist)
                return Json("Only one Tour or Callout Help can exist", JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }

        [ClaimsRequired("Add", "Help", Order = 1003)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DoesShowMeHowUiPageUrlExist(string htn,string uiPageUrl,Guid helpID)
        {
            if (htn != HelpTypeEnum.ShowMeHow.ToString())
                return Json("true", JsonRequestBehavior.AllowGet);
            else
            {
                var doesAlreadyExist = await HelpClient.DoesShowMeHowUiPageUrlAlreadyExistAsync(helpID, uiPageUrl.ToLower());

                if (doesAlreadyExist)
                    return Json("A Show Me How with the Page Url:" + uiPageUrl + " already exists", JsonRequestBehavior.AllowGet);
                else
                    return Json("true", JsonRequestBehavior.AllowGet);
            }
        }

        [ClaimsRequired("View", "Help", Order = 1004)]
        public async Task<ActionResult> GetHelpItemsForDisplay(string htn,string uiPageUrl)
        {
            var helpTypeID = GetHelpTypeID(htn);

            var helpItems = await HelpClient.GetHelpItemsForDisplayAsync(WebUserHelper.GetWebUserObject(HttpContext).UaoID,helpTypeID,uiPageUrl);

            foreach(var helpItem in helpItems)
            {
                if (helpItem.UiPosition == HelpPositionEnum.Top.GetIntValue())
                    helpItem.UiPositionName = HelpPositionEnum.Top.ToString();
                else if (helpItem.UiPosition == HelpPositionEnum.Bottom.GetIntValue())
                    helpItem.UiPositionName = HelpPositionEnum.Bottom.ToString();
                else if (helpItem.UiPosition == HelpPositionEnum.Left.GetIntValue())
                    helpItem.UiPositionName = HelpPositionEnum.Left.ToString();
                else if (helpItem.UiPosition == HelpPositionEnum.Right.GetIntValue())
                    helpItem.UiPositionName = HelpPositionEnum.Right.ToString();
            }

            return Json(new { Items = helpItems, Count = helpItems.Count }, JsonRequestBehavior.AllowGet);
        }

        [ClaimsRequired("Add", "Help", Order = 1005)]
        private async Task<List<AddHelpItemDTO>> GetHelpItemsFromTempStore(Guid tempStoreID)
        {
            var jsonData = await HelpClient.GetFromTempStoreAsync(WebUserHelper.GetWebUserObject(HttpContext).UaoID, tempStoreID);

            if (string.IsNullOrEmpty(jsonData))
                return new List<AddHelpItemDTO>();
            else return JsonHelper.DeserializeData<List<AddHelpItemDTO>>(jsonData).ToList();
        }

        [ClaimsRequired("Add", "Help", Order = 1006)]
        private async Task AddHelpItemsToTempStore(Guid tempStoreID,List<AddHelpItemDTO> items)
        {
            await HelpClient.AddToTempStoreAsync(WebUserHelper.GetWebUserObject(HttpContext).UaoID, tempStoreID, JsonHelper.SerializeData<List<AddHelpItemDTO>>(items));
        }

        [ClaimsRequired("Add", "Help", Order = 1007)]
        public async Task<ActionResult> MoveUpAdd(Guid hiID, Guid tempStoreID)
        {
            var helpItems = await GetHelpItemsFromTempStore(tempStoreID);
            var helpItemIndex = helpItems.FindIndex(s => s.HelpItemID.Equals(hiID));
            var helpItem = helpItems.Single(s => s.HelpItemID.Equals(hiID));


            if (helpItem.DisplayOrder > 0)
            {
                helpItems.Single(s => s.DisplayOrder == (helpItem.DisplayOrder - 1)).DisplayOrder = helpItem.DisplayOrder;
                helpItems[helpItemIndex].DisplayOrder = (helpItem.DisplayOrder - 1);
                await AddHelpItemsToTempStore(tempStoreID,helpItems);
            }

            return Json(new { success = true, action = "MoveUpAdd" });
        }

        [ClaimsRequired("Add", "Help", Order = 1008)]
        public async Task<ActionResult> MoveDownAdd(Guid hiID, Guid tempStoreID)
        {
            var helpItems = await GetHelpItemsFromTempStore(tempStoreID);
            var helpItemIndex = helpItems.FindIndex(s => s.HelpItemID.Equals(hiID));
            var helpItem = helpItems.Single(s => s.HelpItemID.Equals(hiID));

            if ((helpItem.DisplayOrder < (helpItems.Count - 1)))
            {
                helpItems.Single(s => s.DisplayOrder == (helpItem.DisplayOrder + 1)).DisplayOrder = helpItem.DisplayOrder;
                helpItems[helpItemIndex].DisplayOrder = (helpItem.DisplayOrder + 1);
                await AddHelpItemsToTempStore(tempStoreID, helpItems);
            }

            return Json(new { success = true, action = "MoveDownAdd" });
        }

        [ClaimsRequired("Add", "Help", Order = 1009)]
        public async Task<ActionResult> AddHelpItem(string htn, Guid tempStoreID)
        {
            var newHelpItem = new AddHelpItemDTO
            {
                HelpTypeName = htn,
                TempStoreID = tempStoreID,
                HelpItemID = Guid.NewGuid()
            };

            newHelpItem.Roles = await HelpClient.GetHelpRolesAsync();
            return PartialView("_AddHelpItem", newHelpItem);
        }

        [ClaimsRequired("Add", "Help", Order = 1010)]
        public async Task<ActionResult> EditAddHelpItem(Guid tempStoreID, Guid hiID)
        {
            var helpItems = await GetHelpItemsFromTempStore(tempStoreID);
            var helpItem = helpItems.Single(s => s.HelpItemID.Equals(hiID));
            helpItem.Roles = HelpClient.GetHelpRolesSync();
            return PartialView("_EditAddHelpItem", helpItem);
        }

        [ClaimsRequired("Add", "Help", Order = 1011)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAddHelpItem(AddHelpItemDTO helpItem)
        {
            var addHelpItems = await GetHelpItemsFromTempStore(helpItem.TempStoreID);
            var itemIndex = addHelpItems.FindIndex(s => s.HelpItemID.Equals(helpItem.HelpItemID));
            addHelpItems[itemIndex] = helpItem;
            await AddHelpItemsToTempStore(helpItem.TempStoreID, addHelpItems);
            return Json(new { success = true, action = "EditAddHelpItem" });
        }

        [ClaimsRequired("Add", "Help", Order = 1012)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddHelpItem(AddHelpItemDTO helpItem)
        {
            var addHelpItems = await GetHelpItemsFromTempStore(helpItem.TempStoreID);
            helpItem.DisplayOrder = addHelpItems.Count;
            helpItem.CreatedBy = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            helpItem.CreatedOn = DateTime.Now;
            addHelpItems.Add(helpItem);
            await AddHelpItemsToTempStore(helpItem.TempStoreID, addHelpItems);
            return Json(new { success = true, action = "AddHelpItem" });
        }


        [ClaimsRequired("Add", "Help", Order = 1013)]
        public ActionResult AddHelp()
        {
            var newHelpItem = new AddHelpDTO{TempStoreID = Guid.NewGuid(),HelpID=Guid.NewGuid()};
            return PartialView("_AddHelp", newHelpItem);
        }

        [ClaimsRequired("Add", "Help", Order = 1014)]
        public async Task<ActionResult> CancelHelp(Guid tempStoreID)
        {
            await HelpClient.DeleteTempStoreAsync(WebUserHelper.GetWebUserObject(HttpContext).UaoID, tempStoreID);
            return Json(new { success = true, action = "CancelHelp" });
        }

        [ClaimsRequired("Add", "Help", Order = 1015)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddHelp(AddHelpDTO help)
        {
            help.HelpItems = await GetHelpItemsFromTempStore(help.TempStoreID);

            try
            {
                help.CreatedBy = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
                help.CreatedOn = DateTime.Now;

                help.HelpItems.ToList().ForEach(item =>
                    {
                        item.CreatedOn = DateTime.Now;
                        item.CreatedBy = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
                    });

                await HelpClient.SaveHelpAsync(help);
                await HelpClient.DeleteTempStoreAsync(WebUserHelper.GetWebUserObject(HttpContext).UaoID, help.TempStoreID);

                TempData["JumpToHelpID"] = help.HelpID;
            }
            catch(Exception ex)
            {
                Logger.Error(ex);

                this.AddToastMessage("Add Help has failed", "Help " + help.Name + " has saved unsuccessfully. Please try again", ToastType.Success);
            }

            return RedirectToAction("Index");
        }

        [ClaimsRequired("Edit", "Help", Order = 1016)]
        public async Task<ActionResult> EditHelp(Guid hID)
        {
            var helpDto = await HelpClient.GetHelpAsync(hID);
            return PartialView("_EditHelp", helpDto);
        }

        [ClaimsRequired("Edit", "Help", Order = 1017)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditHelp(AddHelpDTO help)
        {
            try
            {
                help.ModifiedBy = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
                help.ModifiedOn = DateTime.Now;

                await HelpClient.SaveHelpAsync(help);

                TempData["JumpToHelpID"] = help.HelpID;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);

                this.AddToastMessage("Edit Help has failed", "Help " + help.Name + " has saved unsuccessfully. Please try again", ToastType.Success);
            }

            return RedirectToAction("Index");
        }

        [ClaimsRequired("Delete", "Help", Order = 1018)]
        public async Task<ActionResult> DeleteHelpItemTemp(Guid hiID,Guid tempStoreID)
        {
            var helpItems = await GetHelpItemsFromTempStore(tempStoreID);
            var helpItemIndex = helpItems.FindIndex(s => s.HelpItemID.Equals(hiID));

            // remove item
            helpItems.RemoveAt(helpItemIndex);

            // reapply displayorder
            var displayOrder = 0;
            helpItems.OrderBy(o => o.DisplayOrder).ToList().ForEach(hi =>
                {
                    hi.DisplayOrder = displayOrder;
                    displayOrder++;
                });

            await AddHelpItemsToTempStore(tempStoreID, helpItems);

            return Json(new { success = true, action = "DeleteHelpItemTemp" });
        }

        [ClaimsRequired("Delete", "Help", Order = 1019)]
        public async Task<ActionResult> DeleteHelpItem(Guid hiID)
        {
            var helpItem = await HelpClient.GetHelpItemAsync(hiID);

            return PartialView("_DeleteHelpItem", helpItem);
        }

        [ClaimsRequired("Delete", "Help", Order = 1020)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteHelpItem(AddHelpItemDTO dto)
        {
            try
            {
                await HelpClient.DeleteHelpItemAsync(dto.HelpItemID);

                return Json(new { success = true, action = "DeleteHelpItem" });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);

                this.AddToastMessage("Delete HelpItem failed", "Help Item " + dto.Title + " did not delete successfully. Please try again", ToastType.Error);

                return Json(new { success = false, action = "DeleteHelpItem" });
            }
        }

        [ClaimsRequired("Delete", "Help", Order = 1021)]
        public async Task<ActionResult> DeleteHelp(Guid hID)
        {
            var help = await HelpClient.GetHelpAsync(hID);

            return PartialView("_DeleteHelp", help);
        }

        [ClaimsRequired("Edit", "Help", Order = 1022)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteHelp(AddHelpDTO dto)
        {
            try
            {
                await HelpClient.DeleteHelpAsync(dto.HelpID);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);

                this.AddToastMessage("Delete Help failed", "Help " + dto.Name + " did not delete successfully. Please try again", ToastType.Error);
            }

            return RedirectToAction("Index");
        }
        [ClaimsRequired("View", "Help", Order = 1023)]
        public async Task<ActionResult> GetHelpItems(Guid hID)
        {
            var helpItems = await HelpClient.GetHelpItemsAsync(hID);
            return Json(new { Items = helpItems, Count = helpItems.Count() }, JsonRequestBehavior.AllowGet);
        }
        [ClaimsRequired("Edit", "Help", Order = 1024)]
        public async Task<ActionResult> MoveUpEdit(Guid hiID,Guid hID)
        {
            await HelpClient.MoveHelpItemAsync(hiID,hID,true);
            return Json(new { success = true, action = "MoveUpEdit" });
        }
        [ClaimsRequired("Edit", "Help", Order = 1025)]
        public async Task<ActionResult> MoveDownEdit(Guid hiID, Guid hID)
        {
            await HelpClient.MoveHelpItemAsync(hiID, hID, false);
            return Json(new { success = true, action = "MoveDown" });
        }

        [ClaimsRequired("Edit", "Help", Order = 1026)]
        public async Task<ActionResult> EditHelpItem(string htn,Guid hiID)
        {
            var helpItem = await HelpClient.GetHelpItemAsync(hiID);
            helpItem.Roles = await HelpClient.GetHelpRolesAsync();
            helpItem.HelpTypeName = htn;
            return PartialView("_EditHelpItem", helpItem);
        }

        [ClaimsRequired("Edit", "Help", Order = 1027)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditHelpItem(AddHelpItemDTO help)
        {
            try
            {
                help.ModifiedBy = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
                help.ModifiedOn = DateTime.Now;

                await HelpClient.SaveHelpItemAsync(help);

                return Json(new { success = true, action = "EditHelpItem" });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);

                this.AddToastMessage("Edit HelpItem has failed", "Help Item " + help.Title + " did not save successfully. Please try again", ToastType.Error);

                return Json(new { success = false, action = "EditHelpItem" });
            }
        }

        [ClaimsRequired("Edit", "Help", Order = 1028)]
        public async Task<ActionResult> AddEditHelpItem(string htn, Guid hID)
        {
            var newHelpItem = new AddHelpItemDTO
            {
                HelpTypeName = htn,
                HelpItemID = Guid.NewGuid(),
                HelpID = hID
            };

            newHelpItem.Roles = await HelpClient.GetHelpRolesAsync();
            return PartialView("_AddEditHelpItem", newHelpItem);
        }

        [ClaimsRequired("Edit", "Help", Order = 1029)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddEditHelpItem(AddHelpItemDTO helpItem)
        {
            try
            {
                helpItem.CreatedBy = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
                helpItem.CreatedOn = DateTime.Now;

                await HelpClient.SaveHelpItemAsync(helpItem);

                return Json(new { success = true, action = "AddEditHelpItem" });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);

                this.AddToastMessage("Add HelpItem has failed", "Help Item " + helpItem.Title + " did not save successfully. Please try again", ToastType.Error);

                return Json(new { success = false, action = "AddEditHelpItem" });
            }
        }

        [ClaimsRequired("Add", "Help", Order = 1030)]
        public async Task<ActionResult> GetHelpItemsTemp(Guid tempStoreID)
        {
            List<AddHelpItemDTO> addHelpItems = await GetHelpItemsFromTempStore(tempStoreID);

            if (addHelpItems.Count == 0)
            {
                addHelpItems = new List<AddHelpItemDTO>();
                await AddHelpItemsToTempStore(tempStoreID, addHelpItems);
            }

            // add role names
            var roles = await HelpClient.GetHelpRolesAsync();

            addHelpItems.ForEach(ro =>
                {
                    if(ro.SelectedRoles != null && ro.SelectedRoles.Length > 0)
                    ro.SelectedRoleNames = ro.SelectedRoles.Select(s => roles.Single(r => r.RoleID.Equals(Guid.Parse(s))).RoleName).ToList();

                    if (ro.UiPosition.HasValue)
                    {
                        if (ro.UiPosition == HelpPositionEnum.Top.GetIntValue())
                            ro.UiPositionName = HelpPositionEnum.Top.ToString();
                        else if (ro.UiPosition == HelpPositionEnum.Bottom.GetIntValue())
                            ro.UiPositionName = HelpPositionEnum.Bottom.ToString();
                        else if (ro.UiPosition == HelpPositionEnum.Left.GetIntValue())
                            ro.UiPositionName = HelpPositionEnum.Left.ToString();
                        else if (ro.UiPosition == HelpPositionEnum.Right.GetIntValue())
                            ro.UiPositionName = HelpPositionEnum.Right.ToString();
                    }
                });

            return Json(new { Items = addHelpItems.OrderBy(s => s.DisplayOrder), Count = addHelpItems.Count}, JsonRequestBehavior.AllowGet);
        }

        [ClaimsRequired("Add", "Help", Order = 1031)]
        public async Task<ActionResult> GetHelp(string search, HelpTypeEnum helpTypeFilter)
        {
            var helpTypeList = await ClassificationClient.GetRootClassificationDataForTypeNameAsync("HelpTypeID");
            var select = ODataHelper.Select<HelpDTO>(x => new
            {
                x.HelpID,
                HelpTypeName = x.ClassificationType.Name,
                x.Name,
                x.Description,
                x.UiPageUrl,
                x.CreatedOn,
                x.ModifiedOn,
                cfn = x.UserAccountOrganisation_CreatedBy.Contact.FirstName,
                cln = x.UserAccountOrganisation_CreatedBy.Contact.LastName,
                x.UserAccountOrganisation_ModifiedBy.Contact.FirstName,
                x.UserAccountOrganisation_ModifiedBy.Contact.LastName,
                HelpItems = x.HelpItems.Select(b => new { b.HelpItemID, b.Title, b.UiSelector, b.EffectiveFrom, b.ClassificationType.Name, 
                    cfn = b.UserAccountOrganisation_CreatedBy.Contact.FirstName, 
                    cln =b.UserAccountOrganisation_CreatedBy.Contact.LastName,
                    b.UserAccountOrganisation_ModifiedBy.Contact.FirstName,
                    b.UserAccountOrganisation_ModifiedBy.Contact.LastName, 
                    b.IsDeleted,
                    b.CreatedBy, b.Description, b.DisplayOrder, blah = b.Roles.Select(r => new { r.RoleName }) })
            });

            var tourTypeID = helpTypeList.Single(s => s.ClassificationTypeID.Equals(HelpTypeEnum.Tour.GetIntValue())).ClassificationTypeID;
            var calloutTypeID = helpTypeList.Single(s => s.ClassificationTypeID.Equals(HelpTypeEnum.Callout.GetIntValue())).ClassificationTypeID;
            var shmTypeID = helpTypeList.Single(s => s.ClassificationTypeID.Equals(HelpTypeEnum.ShowMeHow.GetIntValue())).ClassificationTypeID;

            var where = ODataHelper.Expression<HelpDTO>(x => x.HelpID != null && x.IsDeleted == false);

            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim().ToLower();
                where = Expression.And(where, ODataHelper.Expression<HelpDTO>(x =>
                    x.Name.ToLower().Contains(search) ||
                    x.Description.ToLower().Contains(search) ||
                    x.HelpItems.Any(hi => hi.Title.ToLower().Contains(search))
                    ));
            }

            switch (helpTypeFilter)
            {
                case HelpTypeEnum.Tour:
                    where = Expression.And(where, ODataHelper.Expression<HelpDTO>(x => x.HelpTypeID == tourTypeID));
                    break;
                case HelpTypeEnum.Callout:
                    where = Expression.And(where, ODataHelper.Expression<HelpDTO>(x => x.HelpTypeID == calloutTypeID));
                    break;
                case HelpTypeEnum.ShowMeHow:
                    where = Expression.And(where, ODataHelper.Expression<HelpDTO>(x => x.HelpTypeID == shmTypeID));
                    break;
            }
 
            var filter = ODataHelper.Filter(where);
            JObject res = await QueryClient.QueryAsync("Helps", ODataHelper.RemoveParameters(Request) + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

    }

    public class SelectItem
{
    public string id { get; set; }
    public string text { get; set; }
}

}