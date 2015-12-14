using Bec.TargetFramework.Entities.Enums;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Extensions
{
    public static class ActivityTypeExtensions
    {
        public static string GetFaIconClass(this ActivityType? activityType)
        {
            if (activityType.HasValue)
            {
                switch (activityType)
                {
                    case ActivityType.SmsTransaction:
                        return "fa-home";
                    case ActivityType.BankAccount:
                        return "fa-bank";
                }
            }

            return "fa-envelope-o";
        }
    }
}