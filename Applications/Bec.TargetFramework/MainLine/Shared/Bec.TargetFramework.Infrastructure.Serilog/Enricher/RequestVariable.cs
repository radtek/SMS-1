using System;

namespace Serilog.Web.Extensions.Enrichers
{
    public enum RequestVariable
    {
        AcceptTypes,
        ApplicationPath,
        AnonymousID,
        ContentEncoding,
        ContentLength,
        ContentType,
        CurrentExecutionFilePath,
        CurrentExecutionFilePathExtension,
        FilePath,
        HttpMethod,
        IsAuthenticated,
        IsLocal,
        IsSecureConnection,
        Path,
        PathInfo,
        PhysicalApplicationPath,
        PhysicalPath,
        RawUrl,
        RequestType,
        TotalBytes,
        Url,
        UrlReferrer,
        UserAgent,
        UserLanguages,
        UserHostAddress,
        UserHostName
    }
}