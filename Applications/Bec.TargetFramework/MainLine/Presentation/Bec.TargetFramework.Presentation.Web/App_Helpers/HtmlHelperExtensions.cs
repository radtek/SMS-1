#region Using

using System;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Collections.Generic;
using Bec.TargetFramework.Infrastructure.Extensions;

#endregion

namespace Bec.TargetFramework.Presentation.Web
{
    public static class HtmlHelperExtensions
    {
        private static string _displayVersion;

        /// <summary>
        ///     Retrieves a non-HTML encoded string containing the assembly version as a formatted string.
        ///     <para>If a project name is specified in the application configuration settings it will be prefixed to this value.</para>
        ///     <para>
        ///         e.g.
        ///         <code>1.0 (build 100)</code>
        ///     </para>
        ///     <para>
        ///         e.g.
        ///         <code>ProjectName 1.0 (build 100)</code>
        ///     </para>
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static IHtmlString AssemblyVersion(this HtmlHelper helper)
        {
            if (string.IsNullOrWhiteSpace(_displayVersion))
                SetDisplayVersion();

            return helper.Raw(_displayVersion);
        }

        /// <summary>
        ///     Compares the requested route with the given <paramref name="value" /> value, if a match is found the
        ///     <paramref name="attribute" /> value is returned.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="value">The action value to compare to the requested route action.</param>
        /// <param name="attribute">The attribute value to return in the current action matches the given action value.</param>
        /// <returns>A HtmlString containing the given attribute value; otherwise an empty string.</returns>
        public static IHtmlString RouteIf(this HtmlHelper helper, string attribute, string controller, string action = "")
        {
            var currentController =
                (helper.ViewContext.RequestContext.RouteData.Values["controller"] ?? string.Empty).ToString().UnDash();
            var currentAction =
                (helper.ViewContext.RequestContext.RouteData.Values["action"] ?? string.Empty).ToString().UnDash();

            var hasController = controller.Equals(currentController, StringComparison.InvariantCultureIgnoreCase);
            var hasAction = action.Equals(currentAction, StringComparison.InvariantCultureIgnoreCase);

            return hasAction && hasController ? new HtmlString(attribute) : new HtmlString(string.Empty);
        }

        /// <summary>
        ///     Renders the specified partial view with the parent's view data and model if the given setting entry is found and
        ///     represents the equivalent of true.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName">The name of the partial view.</param>
        /// <param name="appSetting">The key value of the entry point to look for.</param>
        public static void RenderPartialIf(this HtmlHelper htmlHelper, string partialViewName, string appSetting)
        {
            var setting = Settings.GetValue<bool>(appSetting);

            htmlHelper.RenderPartialIf(partialViewName, setting);
        }

        /// <summary>
        ///     Renders the specified partial view with the parent's view data and model if the given setting entry is found and
        ///     represents the equivalent of true.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName">The name of the partial view.</param>
        /// <param name="condition">The boolean value that determines if the partial view should be rendered.</param>
        public static void RenderPartialIf(this HtmlHelper htmlHelper, string partialViewName, bool condition)
        {
            if (!condition)
                return;

            htmlHelper.RenderPartial(partialViewName);
        }

        public static void RenderActionIf(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, bool condition)
        {
            if (!condition)
            {
                return;
            }

            htmlHelper.RenderAction(actionName, controllerName, routeValues);
        }

        /// <summary>
        ///     Retrieves a non-HTML encoded string containing the assembly version and the application copyright as a formatted
        ///     string.
        ///     <para>If a company name is specified in the application configuration settings it will be suffixed to this value.</para>
        ///     <para>
        ///         e.g.
        ///         <code>1.0 (build 100) © 2015</code>
        ///     </para>
        ///     <para>
        ///         e.g.
        ///         <code>1.0 (build 100) © 2015 CompanyName</code>
        ///     </para>
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static IHtmlString Copyright(this HtmlHelper helper)
        {
            var copyright =
                string.Format("{0} &copy; {1} {2}", helper.AssemblyVersion(), DateTime.Now.Year, Settings.Company)
                    .Trim();

            return helper.Raw(copyright);
        }

        private static void SetDisplayVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;

            _displayVersion =
                string.Format("{4} {0}.{1}.{2} (build {3})", version.Major, version.Minor, version.Build,
                    version.Revision, Settings.Project).Trim();
        }

        /// <summary>
        ///     Returns an unordered list (ul element) of validation messages that utilizes bootstrap markup and styling.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="alertType">The alert type styling rule to apply to the summary element.</param>
        /// <param name="heading">The optional value for the heading of the summary element.</param>
        /// <returns></returns>
        public static HtmlString ValidationBootstrap(this HtmlHelper htmlHelper, string alertType = "danger",
            string heading = "")
        {
            if (htmlHelper.ViewData.ModelState.IsValid)
                return new HtmlString(string.Empty);

            var sb = new StringBuilder();

            sb.AppendFormat("<div class=\"alert alert-{0} alert-block\">", alertType);
            sb.Append("<button class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>");

            if (!string.IsNullOrWhiteSpace(heading))
            {
                sb.AppendFormat("<h4 class=\"alert-heading\">{0}</h4>", heading);
            }

            sb.Append(htmlHelper.ValidationSummary());
            sb.Append("</div>");

            return new HtmlString(sb.ToString());
        }

        public static bool RouteMatches(this HtmlHelper helper, string controller, string action)
        {
            var currentController = (helper.ViewContext.RequestContext.RouteData.Values["controller"] ?? string.Empty).ToString().UnDash();
            var currentAction = (helper.ViewContext.RequestContext.RouteData.Values["action"] ?? string.Empty).ToString().UnDash();

            var hasController = controller.Equals(currentController, StringComparison.InvariantCultureIgnoreCase);
            var hasAction = action.Equals(currentAction, StringComparison.InvariantCultureIgnoreCase);

            return hasAction && hasController;
        }

        /// <summary>
        /// Creates a SelectList with 'Text' and 'Value' members populated from the specified enum's values and StringValueAttribute values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static SelectList EnumList<T>(this HtmlHelper helper)
        {
            List<object> rejects = new List<object>();
            Type eType = typeof(T);
            foreach (var item in Enum.GetValues(eType))
            {
                var member = eType.GetMember(item.ToString())[0];
                StringValueAttribute attr = member.GetCustomAttributes(typeof(StringValueAttribute), false).FirstOrDefault() as StringValueAttribute;
                rejects.Add(new { Text = attr.StringValue, Value = (int)item });
            }
            return new SelectList(rejects, "Value", "Text");
        }

        public static SelectList EnumListString<T>(this HtmlHelper helper)
        {
            List<object> rejects = new List<object>();
            Type eType = typeof(T);
            foreach (var item in Enum.GetValues(eType))
            {
                var member = eType.GetMember(item.ToString())[0];
                StringValueAttribute attr = member.GetCustomAttributes(typeof(StringValueAttribute), false).FirstOrDefault() as StringValueAttribute;
                rejects.Add(new { Text = attr.StringValue, Value = attr.StringValue });
            }
            return new SelectList(rejects, "Value", "Text");
        }
        
        public static MvcHtmlString Timeago(this HtmlHelper helper, DateTime dateTime)
        {
            return MvcHtmlString.Create(dateTime.ToRelativeDate());
        }

        public static IHtmlString AntiForgeryTokenValue(this HtmlHelper htmlHelper)
        {
            var field = htmlHelper.AntiForgeryToken().ToHtmlString();
            var beginIndex = field.IndexOf("value=\"") + 7;
            var endIndex = field.IndexOf("\"", beginIndex);
            return new HtmlString(field.Substring(beginIndex, endIndex - beginIndex));
        }

        private static string ToRelativeDate(this DateTime dateTime)
        {
            var timeSpan = DateTime.Now - dateTime;

            if (timeSpan <= TimeSpan.FromSeconds(60))
                return string.Format("{0} {1} ago", timeSpan.Seconds, "second".ToSingularPluralAware(timeSpan.Seconds));

            if (timeSpan <= TimeSpan.FromMinutes(60))
                return timeSpan.Minutes > 1 ? String.Format("{0} minutes ago", timeSpan.Minutes) : "about a minute ago";

            if (timeSpan <= TimeSpan.FromHours(24))
                return timeSpan.Hours > 1 ? String.Format("{0} hours ago", timeSpan.Hours) : "about an hour ago";

            if (timeSpan <= TimeSpan.FromDays(30))
                return timeSpan.Days > 1 ? String.Format("{0} days ago", timeSpan.Days) : "yesterday";

            if (timeSpan <= TimeSpan.FromDays(365))
                return timeSpan.Days > 30 ? String.Format("{0} months ago", timeSpan.Days / 30) : "about a month ago";

            return timeSpan.Days > 365 ? String.Format("{0} years ago", timeSpan.Days / 365) : "about a year ago";
        }
    }
}