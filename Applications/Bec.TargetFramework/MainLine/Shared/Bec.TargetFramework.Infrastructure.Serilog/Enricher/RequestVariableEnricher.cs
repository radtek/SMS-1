using System;
using System.Web;
using Serilog.Web.Extensions.Enrichers.Infrastructure;

namespace Serilog.Web.Extensions.Enrichers
{
    public class RequestVariableEnricher : NamedScalarKeyBasedWithDefaultValueHttpRequestEnricherBase<RequestVariable>
    {
        public const string DefaultPropertyValue = "N/A";

        public RequestVariableEnricher(RequestVariable keyName, object defaultValue = null, string propertyName = null,
            Func<HttpContextBase> httpContextGetter = null)
            : base(keyName, defaultValue ?? DefaultPropertyValue, propertyName, httpContextGetter)
        {
        }

        protected override object GetValueByKey(HttpRequestBase httpRequest, RequestVariable key)
        {
            object value;
            switch (key)
            {
                case RequestVariable.AcceptTypes:
                    value = (httpRequest.AcceptTypes != null) ? String.Join(",", httpRequest.AcceptTypes) : null;
                    break;
                case RequestVariable.ApplicationPath:
                    value = httpRequest.ApplicationPath;
                    break;
                case RequestVariable.AnonymousID:
                    value = httpRequest.AnonymousID;
                    break;
                case RequestVariable.ContentEncoding:
                    value = (httpRequest.ContentEncoding != null) ? httpRequest.ContentEncoding.WebName : null;
                    break;
                case RequestVariable.ContentLength:
                    value = httpRequest.ContentLength;
                    break;
                case RequestVariable.ContentType:
                    value = httpRequest.ContentType;
                    break;
                case RequestVariable.CurrentExecutionFilePath:
                    value = httpRequest.CurrentExecutionFilePath;
                    break;
                case RequestVariable.CurrentExecutionFilePathExtension:
                    value = httpRequest.CurrentExecutionFilePathExtension;
                    break;
                case RequestVariable.FilePath:
                    value = httpRequest.FilePath;
                    break;
                case RequestVariable.HttpMethod:
                    value = httpRequest.HttpMethod;
                    break;
                case RequestVariable.IsAuthenticated:
                    value = httpRequest.IsAuthenticated;
                    break;
                case RequestVariable.IsLocal:
                    value = httpRequest.IsLocal;
                    break;
                case RequestVariable.IsSecureConnection:
                    value = httpRequest.IsSecureConnection;
                    break;
                case RequestVariable.Path:
                    value = httpRequest.Path;
                    break;
                case RequestVariable.PathInfo:
                    value = httpRequest.PathInfo;
                    break;
                case RequestVariable.PhysicalApplicationPath:
                    value = httpRequest.PhysicalApplicationPath;
                    break;
                case RequestVariable.PhysicalPath:
                    value = httpRequest.PhysicalPath;
                    break;
                case RequestVariable.RawUrl:
                    value = httpRequest.RawUrl;
                    break;
                case RequestVariable.RequestType:
                    value = httpRequest.RequestType;
                    break;
                case RequestVariable.TotalBytes:
                    value = httpRequest.TotalBytes;
                    break;
                case RequestVariable.Url:
                    value = httpRequest.Url;
                    break;
                case RequestVariable.UrlReferrer:
                    value = httpRequest.UrlReferrer;
                    break;
                case RequestVariable.UserAgent:
                    value = httpRequest.UserAgent;
                    break;
                case RequestVariable.UserLanguages:
                    value = (httpRequest.UserLanguages != null) ? String.Join(",", httpRequest.UserLanguages) : null;
                    break;
                case RequestVariable.UserHostAddress:
                    value = httpRequest.UserHostAddress;
                    break;
                case RequestVariable.UserHostName:
                    value = httpRequest.UserHostName;
                    break;
                default:
                    value = key.ToString().ToUpperInvariant();
                    break;
            }
            return value;
        }
    }
}