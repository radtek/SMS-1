using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsureThat;
using Bec.TargetFramework.SB.Client.Interfaces;
using System.Security.Cryptography;
using System.Text;
using ServiceStack.Text;
using System.Diagnostics;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class HelpLogicController : LogicBase
    {
        public TFSettingsLogicController Settings { get; set; }
        public ClassificationDataLogicController ClassificationLogic { get; set; }
        public NotificationLogicController NotificationLogic { get; set; }
        public IEventPublishLogicClient EventPublishClient { get; set; }
        public UserLogicController UserLogic { get; set; }

        public bool DoesTypeAlreadyExist(int helpTypeID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().Helps.Any(s => s.HelpTypeID.Equals(helpTypeID) && s.IsDeleted == false);
            }
        }

        public bool DoesShowMeHowUiPageUrlAlreadyExist(Guid helpID, string uiPageURL)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                int helpTypeID = HelpTypeEnum.ShowMeHow.GetIntValue();

                return scope.DbContexts.Get<TargetFrameworkEntities>().Helps.Any(s => !s.HelpID.Equals(helpID) && s.IsDeleted == false && s.HelpTypeID.Equals(helpTypeID) && s.UiPageUrl.ToLower().Equals(uiPageURL));
            }
        }

        public async Task MarkCalloutAsViewed(Guid uaoID,Guid helpItemID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var callOutViewed = new UserAccountOrganisationHelpViewed
                {
                    CreatedOn = DateTime.Now,
                    HelpItemID = helpItemID,
                    UserAccountOrganisationID = uaoID
                };

                scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisationHelpVieweds.Add(callOutViewed);

                await scope.SaveChangesAsync();
            }
        }


        public string GetFromTempStore(Guid uaoID, Guid tempID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                if (scope.DbContexts.Get<TargetFrameworkEntities>().TempJsonData.Any(s => s.TempJsonDataID.Equals(tempID) && s.UserAccountOrganisationID.Equals(uaoID)))
                {
                    var item = scope.DbContexts.Get<TargetFrameworkEntities>().TempJsonData.SingleOrDefault(s => s.TempJsonDataID.Equals(tempID) && s.UserAccountOrganisationID.Equals(uaoID));

                    return item.JsonData;
                }
                else 
                    return null;
                
            }
        }

        public async Task DeleteTempStore(Guid uaoID,Guid tempID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                if(scope.DbContexts.Get<TargetFrameworkEntities>().TempJsonData.Any(s => s.TempJsonDataID.Equals(tempID)))
                {
                    scope.DbContexts.Get<TargetFrameworkEntities>().TempJsonData.Remove(scope.DbContexts.Get<TargetFrameworkEntities>().TempJsonData.Single(s => s.TempJsonDataID.Equals(tempID)));
                    await scope.SaveChangesAsync();
                }
            }
        }

        public List<AddHelpItemDTO> GetHelpItemsForDisplay(Guid uaoID,int helpTypeID,string uiPageUrl)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var helpItemEntities = scope.DbContexts.Get<TargetFrameworkEntities>().FnGetHelpItem(uaoID, helpTypeID, uiPageUrl).OrderBy(s => s.DisplayOrder).ToList();

                return helpItemEntities.Select(s => CreateNewAddHelpItemFromHelpItem(s)).ToList();
            }
        }

        public async Task DeleteHelpItem(Guid hiID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                if(scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Any(s => s.HelpItemID.Equals(hiID)))
                {
                    var helpItem = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Single(s => s.HelpItemID.Equals(hiID));

                    // mark as deleted
                    helpItem.IsDeleted = true;

                    // reorder grid items
                    var existingHelpItems = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Where(hi => hi.HelpID.Equals(helpItem.HelpID) && !hi.HelpItemID.Equals(hiID)
                        && hi.IsDeleted == false).OrderBy(o => o.DisplayOrder);

                    int displayOrder = 0;

                    foreach (var ehi in existingHelpItems)
                    {
                        ehi.DisplayOrder = displayOrder;
                        displayOrder++;
                    }

                    await scope.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteHelp(Guid hID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                // mark as deleted
                if (scope.DbContexts.Get<TargetFrameworkEntities>().Helps.Any(s => s.HelpID.Equals(hID)))
                {
                    var help = scope.DbContexts.Get<TargetFrameworkEntities>().Helps.Single(s => s.HelpID.Equals(hID));

                    if (help.HelpItems.Any())
                    {
                        foreach (var hi in help.HelpItems)
                        {
                            hi.IsDeleted = true;
                        }
                    }

                    help.IsDeleted = true;

                    await scope.SaveChangesAsync();
                }
            }
        }

        public async Task AddToTempStore(Guid uaoID,Guid tempID,string data)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                if (scope.DbContexts.Get<TargetFrameworkEntities>().TempJsonData.Any(s => s.TempJsonDataID.Equals(tempID) && s.UserAccountOrganisationID.Equals(uaoID)))
                {
                    var item = scope.DbContexts.Get<TargetFrameworkEntities>().TempJsonData.SingleOrDefault(s => s.TempJsonDataID.Equals(tempID) && s.UserAccountOrganisationID.Equals(uaoID));

                    item.JsonData = data;
                }
                else
                {
                    var newJsonItem = new TempJsonDatum{
                        TempJsonDataID = tempID,
                        JsonData = data,
                        UserAccountOrganisationID = uaoID,
                        CreatedOn = DateTime.Now
                    };

                    scope.DbContexts.Get<TargetFrameworkEntities>().TempJsonData.Add(newJsonItem);
                }

                await scope.SaveChangesAsync();
            }
        }

        public async Task MoveHelpItem(Guid hiID,Guid hID,bool up)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var helpItems = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Where(s => s.HelpID == hID && s.IsDeleted == false).OrderBy(o => o.DisplayOrder).ToList();

                if (helpItems.Any())
                {
                    // check position of current item
                    var currentIndex = helpItems.FindIndex(s => s.HelpItemID.Equals(hiID));
                    var helpItem = helpItems.Single(s => s.HelpItemID.Equals(hiID));

                    if (up && (helpItem.DisplayOrder > 0))
                    {
                        // up
                        helpItems.Single(s => s.DisplayOrder.Equals((helpItem.DisplayOrder - 1))).DisplayOrder = helpItem.DisplayOrder;
                        helpItems[currentIndex].DisplayOrder = (helpItem.DisplayOrder - 1);
                        
                    }
                    else if (!up && (helpItem.DisplayOrder < (helpItems.Count - 1)))
                    {
                        // down
                        helpItems.Single(s => s.DisplayOrder.Equals(helpItem.DisplayOrder + 1)).DisplayOrder = helpItem.DisplayOrder;
                        helpItems[currentIndex].DisplayOrder = helpItem.DisplayOrder + 1;
                       
                    }

                    await scope.SaveChangesAsync();
                }
            }
        }

        private AddHelpItemDTO CreateNewAddHelpItemFromHelpItem(HelpItem hi)
        {
            var hiDto = new AddHelpItemDTO
            {
                CreatedOn = hi.CreatedOn,
                CreatedBy = hi.CreatedBy,
                Description = hi.Description,
                Title = hi.Title,
                HelpID = hi.HelpID,
                EffectiveFrom = hi.EffectiveFrom,
                DisplayOrder = hi.DisplayOrder,
                UiSelector = hi.UiSelector,
                UiSelectorParent = hi.UiSelectorParent,
                HelpItemID = hi.HelpItemID,
                ModifiedBy = hi.ModifiedBy,
                ModifiedOn = hi.ModifiedOn,
                UiPosition = hi.UiPosition
            };

            return hiDto;
        }

        public IEnumerable<AddHelpItemDTO> GetHelpItems(Guid hID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var helpItemsDtos = new List<AddHelpItemDTO>();

                var helpItems = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Where(s => s.HelpID == hID && s.IsDeleted == false);

                if (helpItems.Any())
                {
                    helpItems.ToList().ForEach(hi =>
                    {
                        var hiDto = CreateNewAddHelpItemFromHelpItem(hi);

                        if (hi.Roles.Any())
                        {
                            hiDto.SelectedRoles = hi.Roles.Select(s => s.RoleID.ToString()).ToArray();
                            hiDto.SelectedRoleNames = hi.Roles.Select(s => s.RoleName.ToString()).ToList();
                        }

                        if(hi.UiPosition.HasValue)
                        {
                     
                                if(hi.UiPosition ==  HelpPositionEnum.Top.GetIntValue())
                                    hiDto.UiPositionName = HelpPositionEnum.Top.ToString();
                                else if(hi.UiPosition ==   HelpPositionEnum.Bottom.GetIntValue())
                                    hiDto.UiPositionName = HelpPositionEnum.Bottom.ToString();
                                else if(hi.UiPosition ==   HelpPositionEnum.Left.GetIntValue())
                                    hiDto.UiPositionName = HelpPositionEnum.Left.ToString();
                                else if(hi.UiPosition ==   HelpPositionEnum.Right.GetIntValue())
                                    hiDto.UiPositionName = HelpPositionEnum.Right.ToString();
                           
                        }

                        helpItemsDtos.Add(hiDto);
                    });
                }

                return helpItemsDtos.AsEnumerable().OrderBy(s => s.DisplayOrder);
            }
        }

        public AddHelpItemDTO GetHelpItem(Guid hiID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var helpItem = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Single(s => s.HelpItemID == hiID);

                var hiDto = CreateNewAddHelpItemFromHelpItem(helpItem);

                if (helpItem.Roles.Any())
                    hiDto.SelectedRoles = helpItem.Roles.Select(s => s.RoleID.ToString()).ToArray();

                return hiDto;
            }
        }

        public async Task SaveHelpItem(AddHelpItemDTO dto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var existingHelpItem = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.FirstOrDefault(s => s.HelpItemID == dto.HelpItemID);

                if (existingHelpItem == null)
                {
                    // get total number of existing
                    var totalExistingHelpItems = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Count(s => s.HelpID.Equals(dto.HelpID)
                        && s.IsDeleted == false);

                    existingHelpItem = new HelpItem
                    {
                        CreatedOn = dto.CreatedOn,
                        CreatedBy = dto.CreatedBy,
                        Description = dto.Description,
                        Title = dto.Title,
                        HelpID = dto.HelpID,
                        EffectiveFrom = dto.EffectiveFrom,
                        DisplayOrder = totalExistingHelpItems,
                        UiSelector = dto.UiSelector,
                        UiSelectorParent = dto.UiSelectorParent,
                        UiPosition = dto.UiPosition,
                        HelpItemID = Guid.NewGuid()
                    };

                    if (dto.SelectedRoles.Any())
                    {
                        var roleList = new List<Role>();
                        dto.SelectedRoles.ToList().ForEach(item =>
                        {
                            var roleID = Guid.Parse(item);
                            roleList.Add(scope.DbContexts.Get<TargetFrameworkEntities>().Roles.Single(s => s.RoleID == roleID));
                        });

                        existingHelpItem.Roles = roleList;
                    }

                    scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Add(existingHelpItem);

                    
                }
                else
                {
                    existingHelpItem.ModifiedOn =dto.ModifiedOn;
                    existingHelpItem.ModifiedBy =dto.ModifiedBy;
                    existingHelpItem.Description = dto.Description;
                    existingHelpItem.Title = dto.Title;
                    existingHelpItem.EffectiveFrom = dto.EffectiveFrom;
                    existingHelpItem.DisplayOrder = dto.DisplayOrder;
                    existingHelpItem.UiSelector = dto.UiSelector;
                    existingHelpItem.UiSelectorParent = dto.UiSelectorParent;
                    existingHelpItem.UiPosition = dto.UiPosition;

                    if (dto.SelectedRoles.Any())
                    {
                        if (existingHelpItem.Roles.Any())
                            existingHelpItem.Roles.Clear();

                        dto.SelectedRoles.ToList().ForEach(item =>
                        {
                            var roleID = Guid.Parse(item);
                            existingHelpItem.Roles.Add(scope.DbContexts.Get<TargetFrameworkEntities>().Roles.Single(s => s.RoleID == roleID));
                        });
                    }
                }

                await scope.SaveChangesAsync();
            }
        }

        public AddHelpDTO GetHelp(Guid hID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var help = scope.DbContexts.Get<TargetFrameworkEntities>().Helps.Single(s => s.HelpID == hID);
                var addHelpDto = new AddHelpDTO
                {
                    CreatedOn = help.CreatedOn,
                    CreatedBy = help.CreatedBy,
                    Description = help.Description,
                    Name = help.Name,
                    HelpTypeID = help.HelpTypeID,
                    HelpID = help.HelpID,
                    UiPageUrl = help.UiPageUrl,
                    ModifiedBy = help.ModifiedBy,
                    ModifiedOn = help.ModifiedOn
                };

                return addHelpDto;
            }
        }

        public async Task SaveHelp(AddHelpDTO dto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var existingHelp = scope.DbContexts.Get<TargetFrameworkEntities>().Helps.FirstOrDefault(s => s.HelpID.Equals(dto.HelpID));

                if(existingHelp==null)
                {
                    existingHelp = new Help
                    {
                        CreatedOn = dto.CreatedOn,
                        CreatedBy = dto.CreatedBy,
                        Description = dto.Description,
                        Name = dto.Name,
                        HelpTypeID = dto.HelpTypeID,
                        HelpID = Guid.NewGuid(),
                        UiPageUrl = dto.UiPageUrl
                    };

                    scope.DbContexts.Get<TargetFrameworkEntities>().Helps.Add(existingHelp);

                    // process items
                    if (dto.HelpItems.Any())
                    {
                        int index = 0;
                        foreach (var helpItem in dto.HelpItems)
                        {
                            var hi = new HelpItem
                            {
                                CreatedOn = helpItem.CreatedOn,
                                CreatedBy = helpItem.CreatedBy,
                                Description = helpItem.Description,
                                Title = helpItem.Title,
                                HelpID = existingHelp.HelpID,
                                EffectiveFrom = helpItem.EffectiveFrom,
                                DisplayOrder = index,
                                UiSelector = helpItem.UiSelector,
                                UiSelectorParent = helpItem.UiSelectorParent,
                                HelpItemID = Guid.NewGuid(),
                                UiPosition = helpItem.UiPosition
                            };

                            index++;

                            scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Add(hi);

                            if (helpItem.SelectedRoles.Any())
                            {
                                var roleList = new List<Role>();

                                helpItem.SelectedRoles.ToList().ForEach(item => {
                                    var roleID = Guid.Parse(item);
                                    roleList.Add(scope.DbContexts.Get<TargetFrameworkEntities>().Roles.Single(s => s.RoleID == roleID));
                                });

                                hi.Roles = roleList;
                            }
                        }
                    }                    
                }
                else
                {
                    existingHelp.ModifiedOn = dto.ModifiedOn;
                    existingHelp.ModifiedBy = dto.ModifiedBy;
                    existingHelp.Description = dto.Description;
                    existingHelp.Name = dto.Name;
                    existingHelp.UiPageUrl = dto.UiPageUrl;
                }

                await scope.SaveChangesAsync();
            }
        }


        public IEnumerable<RoleDTO> GetHelpRoles()
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                // load all vclassification
                return scope.DbContexts.Get<TargetFrameworkEntities>().Roles.Where(s => s.HelpRoles.Any()).ToDtos();
            }
        }

        public async Task<Guid> CreateSupportItem(SupportItemDTO supportItemDto, Guid orgId)
        {
            Ensure.That(supportItemDto).IsNotNull();

            using (var scope = DbContextScopeFactory.Create())
            {
                var highestTicketNumber = scope.DbContexts.Get<TargetFrameworkEntities>().SupportItems.Max(s => s.TicketNumber);
                var administrationOrganisation = scope.DbContexts.Get<TargetFrameworkEntities>().Organisations.Single(s => s.OrganisationTypeID.Equals(30));
 
                supportItemDto.TicketNumber = highestTicketNumber + 1;
                supportItemDto.SupportItemID = Guid.NewGuid();
                supportItemDto.OrganisationID = administrationOrganisation.OrganisationID;

                scope.DbContexts.Get<TargetFrameworkEntities>().SupportItems.Add(supportItemDto.ToEntity());
                scope.SaveChanges();
            }

            var supportGroupHash = GetSupportSafeSendGroupHash();

            await NotificationLogic.CreateConversation(null, supportItemDto.UserAccountOrganisationID, supportItemDto.AttachmentsID, ActivityType.SupportMessage, supportItemDto.SupportItemID, supportItemDto.Title, supportItemDto.Description, false,new string[] {supportGroupHash});
         
            
            return supportItemDto.SupportItemID;
        }

        private string GetSupportSafeSendGroupHash()
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var adminOrganisationTypeID = OrganisationTypeEnum.Administration.GetIntValue();
                var adminOrganisation = scope.DbContexts.Get<TargetFrameworkEntities>().Organisations.FirstOrDefault(s => s.OrganisationTypeID.Equals(adminOrganisationTypeID));
                var supportSafeSendGroup = scope.DbContexts.Get<TargetFrameworkEntities>().SafeSendGroups.FirstOrDefault(s => s.OrganisationTypeID.Equals(adminOrganisationTypeID) && s.Name.Equals("Support"));

                if (supportSafeSendGroup == null)
                    throw new ArgumentNullException("Support Safe Send Group is missing");
                else
                    return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(adminOrganisation.OrganisationID.ToString() + supportSafeSendGroup.SafeSendGroupID.ToString())).Select(c => c.ToString("x2")));
            }
        }

        public int? GetSupportItemRank(Guid stID, bool isClose)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var result = scope.DbContexts.Get<TargetFrameworkEntities>().FnSupportTicketRank(stID, isClose);

                return result.First().ReturnValue;
            }
        }
    }
}
