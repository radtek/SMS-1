﻿using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class HelpLogicController : LogicBase
    {
        public TFSettingsLogicController Settings { get; set; }
        public ClassificationDataLogicController ClassificationLogic { get; set; }

        public bool DoesTypeAlreadyExist(int helpTypeID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().Helps.Any(s => s.HelpTypeID.Equals(helpTypeID));
            }
        }

        public bool DoesShowMeHowUiPageUrlAlreadyExist(Guid helpID, string uiPageURL)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                int helpTypeID = HelpTypeEnum.ShowMeHow.GetIntValue();

                return scope.DbContexts.Get<TargetFrameworkEntities>().Helps.Any(s => !s.HelpID.Equals(helpID) && s.HelpTypeID.Equals(helpTypeID) && s.UiPageUrl.ToLower().Equals(uiPageURL));
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

                    if(helpItem.Roles.Any())
                        helpItem.Roles.Clear();

                    if (helpItem.UserAccountOrganisationHelpVieweds.Any())
                        helpItem.UserAccountOrganisationHelpVieweds.Clear();

                    scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Remove(helpItem);

                    // reorder grid items
                    var existingHelpItems = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Where(hi => hi.HelpID.Equals(helpItem.HelpID) && !hi.HelpItemID.Equals(hiID)).OrderBy(o => o.DisplayOrder);

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
                if (scope.DbContexts.Get<TargetFrameworkEntities>().Helps.Any(s => s.HelpID.Equals(hID)))
                {
                    var help = scope.DbContexts.Get<TargetFrameworkEntities>().Helps.Single(s => s.HelpID.Equals(hID));

                    if (help.HelpItems.Any())
                    {
                        while(help.HelpItems.Count > 0)
                        {
                            var helpItem = help.HelpItems.First();
                            if (helpItem.Roles.Any())
                                helpItem.Roles.Clear();

                            scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Remove(helpItem);
                        }

                        help.HelpItems.Clear();
                    }

                    scope.DbContexts.Get<TargetFrameworkEntities>().Helps.Remove(help);

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
                var helpItems = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Where(s => s.HelpID == hID).OrderBy(o => o.DisplayOrder).ToList();

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

                var helpItems = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Where(s => s.HelpID == hID);

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
                    var totalExistingHelpItems = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Count(s => s.HelpID.Equals(dto.HelpID));

                    existingHelpItem = new HelpItem
                    {
                        CreatedOn = DateTime.Now,
                        CreatedBy = UserNameService.UserName,
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
                    existingHelpItem.ModifiedOn = DateTime.Now;
                    existingHelpItem.ModifiedBy =UserNameService.UserName;
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
                        CreatedOn = DateTime.Now,
                        CreatedBy = UserNameService.UserName,
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
                                CreatedOn = DateTime.Now,
                                CreatedBy = UserNameService.UserName,
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
                    existingHelp.ModifiedOn = DateTime.Now;
                    existingHelp.ModifiedBy = UserNameService.UserName;
                    existingHelp.Description = dto.Description;
                    existingHelp.Name = dto.Name;
                    existingHelp.UiPageUrl = dto.UiPageUrl;
                }

                await scope.SaveChangesAsync();
            }
        }


        public IEnumerable<RoleDTO> GetHelpRoles()
        { 
            string key = "GetHelpRoles";

            using (var cacheClient = CacheProvider.CreateCacheClient(Logger))
            {
                var cachedList = cacheClient.Get<IEnumerable<RoleDTO>>(key);

                if(cachedList == null)
                {
                    using (var scope = DbContextScopeFactory.CreateReadOnly())
                    {
                        // load all vclassification
                        cachedList = scope.DbContexts.Get<TargetFrameworkEntities>().Roles.Where(s => s.HelpRoles.Any()).ToDtos();
                        cacheClient.Set(key, cachedList, DateTime.Now.AddHours(8));
                    }
                }

                return cachedList;
            }
        }
    }
}
