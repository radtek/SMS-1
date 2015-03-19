﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Web.Caching;
using Autofac;
using Autofac.Integration.Mvc;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Repositories;
using Bec.TargetFramework.Data.Infrastructure;
using System.Web.Security;
using System.Web.Routing;
using Bec.TargetFramework.Web.Framework.Helpers;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Framework.Infrastructure;

namespace Bec.TargetFramework.UI.Process.Filters
{
    using ServiceStack.Text;

    public class PreventMultipleLoginsActionFilter : ActionFilterAttribute
    {
        //This stores the time between Requests (in seconds)
        public int DelayRequest = 10;
        //The Error Message that will be displayed in case of excessive Requests
        public string ErrorMessage = "Excessive Request Attempts Detected.";
        //This will store the URL to Redirect errors to
        public string RedirectURL;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            AutofacDependencyResolver resolver = DependencyResolver.Current as AutofacDependencyResolver;

            var container = resolver.ApplicationContainer;

            var logic = container.Resolve<IUserLogic>();

            if (filterContext.HttpContext.Session[WebUserHelper.m_WEBUSEROBJECTSESSIONKEY] != null)
            {
                var webUser = WebUserHelper.GetWebUserObject(filterContext.HttpContext);

                var logins = logic.UserLoginSessions(webUser.UserID);

                if (logins.Any(sessionID => sessionID.Equals(webUser.SessionIdentifier)))
                {
                    // check to see if your user ID is being used elsewhere under a different session ID
                    if (!logins.Any(sessionID => !sessionID.Equals(webUser.SessionIdentifier)))
                    {
                        base.OnActionExecuting(filterContext);
                    }
                    else
                    {
                        // if it is being used elsewhere, update all their Logins records to LoggedIn = false, except for your session ID
                        logic.LogEveryoneElseOut(webUser.UserID, webUser.SessionIdentifier);
                        base.OnActionExecuting(filterContext);
                    }
                }
                else
                {
                    // logout
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary { { "controller", "LoggedOutByAnother" }, { "action", "Index" }, { "area", "UserAccount" } });
                }
            }
            else
            {
                if (filterContext.HttpContext.Request.RawUrl == "/" || filterContext.HttpContext.Request.RawUrl == "/home/index")
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary { { "Controller", "Login" }, { "Action", "Index" }, { "Area", "UserAccount" } });
                else
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary { { "controller", "SessionExpired" }, { "action", "Index" }, { "area", "UserAccount" } });
            }
        }
    }

    public class UserAccountLogicHelper
    {
        public static Dictionary<string, string> CreateRequestDictionary(HttpRequestBase request)
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();

            // params
            request.Params.AllKeys.ToList().ForEach(
                item =>
                {
                    var value = request.Params.GetValues(item);

                    if (!item.ToLowerInvariant().StartsWith("username") && !item.ToLowerInvariant().StartsWith("password") && !item.ToLowerInvariant().StartsWith("fedauth") && !item.ToLowerInvariant().StartsWith("allraw") && !item.ToLowerInvariant().StartsWith("__request") && !item.ToLowerInvariant().StartsWith("all_"))
                        requestParameters.Add(item, value.Dump());
                });

            // browser properties
            request.Browser.ToStringDictionary()
                .ToList()
                .ForEach(
                    item =>
                    {
                        if (item.Key != null && item.Value != null)
                            if (!requestParameters.ContainsKey(item.Key))
                                requestParameters.Add(item.Key, item.Value);
                    });

            // header data
            request.Headers.AllKeys
                .ToList()
                .ForEach(
                    item =>
                    {
                        if (item != null)
                            if (!requestParameters.ContainsKey(item))
                                requestParameters.Add(item, request.Headers[item]);
                    });

            return requestParameters;
        }

        public static void SaveLoginSessionData(Guid userId, string sessionIndentifier,Dictionary<string, string> requestParameters)
        {
            AutofacDependencyResolver resolver = DependencyResolver.Current as AutofacDependencyResolver;

            var container = resolver.ApplicationContainer;

            var logic = container.Resolve<IUserLogic>();

            logic.SaveUserAccountLoginSessionData(userId, sessionIndentifier, requestParameters);
        }

    }
}