﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabrik.Common;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using BrockAllen.MembershipReboot;

namespace Bec.TargetFramework.Entities
{
    public static class WebUserHelper
    {
        public const string m_WEBUSEROBJECTSESSIONKEY = "wjdjwqd8u8wqhdjw9ejdwe8fejw9f9w";
        public static WebUserObject GetWebUserObject(this HttpContextBase context)
        {
            WebUserObject userObject = null;

            Ensure.NotNull(context);
            Ensure.NotNull(context.Session);

            if (context.Session[m_WEBUSEROBJECTSESSIONKEY] != null)
            {
                userObject = context.Session[m_WEBUSEROBJECTSESSIONKEY] as WebUserObject;

                // update url
                userObject.URLAccessed = context.Request.RawUrl;

                context.Session[m_WEBUSEROBJECTSESSIONKEY] = userObject;
            }

            return userObject;
        }

        public static WebUserObject CreateWebUserObjectInSession(HttpContextBase context, UserAccount ua, Guid orgID, Guid uaoID, string orgName, bool needsTc)
        {
            Ensure.NotNull(context);
            Ensure.NotNull(context.Request);
            Ensure.NotNull(ua);

            var user = new WebUserObject
            {
                IPAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? context.Request.UserHostAddress,
                SessionIdentifier = Guid.NewGuid().ToString(),
                URLAccessed = context.Request.RawUrl,
                UserName = ua.FullName,
                UserID = ua.ID,
                OrganisationID = orgID,
                UaoID = uaoID,
                IsTemporaryUser = ua.IsTemporaryAccount,
                NeedsTCs = needsTc,
                OrganisationName = orgName
            };

            context.Session[m_WEBUSEROBJECTSESSIONKEY] = user;

            return user;
        }

        public static string GetOrganisationName(this HttpContextBase context)
        {
            var obj = GetWebUserObject(context);
            return obj == null ? "" : obj.OrganisationName;
        }

        public static string GetUserName(this HttpContextBase context)
        {
            var obj = GetWebUserObject(context);
            return obj == null ? "" : obj.UserName;
        }
    }

    [Serializable]
    public class WebUserObject
    {
        public string IPAddress { get; set; }
        public string SessionIdentifier { get; set; }
        public string URLAccessed { get; set; }

        public string UserName { get; set; }

        public Guid UserID { get; set; }

        public bool IsTemporaryUser { get; set; }
        public bool NeedsTCs { get; set; }
        public Guid OrganisationID { get; set; }
        public Guid UaoID { get; set; }
        public string OrganisationName { get; set; }
    }
}