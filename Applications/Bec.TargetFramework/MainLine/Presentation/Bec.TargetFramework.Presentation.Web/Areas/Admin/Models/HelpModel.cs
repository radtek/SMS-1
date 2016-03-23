using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Entities.Enums;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Models
{
    public class HelpModel
    {
        public Guid HelpPageID { get; set; }

        public string PageName { get; set; }

        public string PageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string HelpPageType { get; set; }

        public int HelpPageTypeId { get; set; }

        public HelpModel(HelpPageDTO helpPage)
        {
            HelpPageID = helpPage.HelpPageID;
            HelpPageType = helpPage.HelpPageTypeId == HelpPageTypeIdEnum.ShowMeHow.GetIntValue() ? 
                HelpPageTypeIdEnum.ShowMeHow.GetStringValue() :
                (helpPage.HelpPageTypeId == HelpPageTypeIdEnum.Callout.GetIntValue() ? 
                HelpPageTypeIdEnum.Callout.GetStringValue() : 
                HelpPageTypeIdEnum.Tour.GetStringValue());
            PageName = helpPage.HelpPageTypeId == HelpPageTypeIdEnum.ShowMeHow.GetIntValue() ? helpPage.PageName : string.Empty;
            PageUrl = helpPage.HelpPageTypeId == HelpPageTypeIdEnum.ShowMeHow.GetIntValue() ? helpPage.PageUrl : string.Empty;
            CreatedOn = helpPage.CreatedOn;
            ModifiedOn = helpPage.ModifiedOn;
            HelpPageTypeId = helpPage.HelpPageTypeId;
        }
    }
}