using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum ExperianProveIDEnum : int
    {
        AuthenticationError=0,
        BadLoginorPassword=1,
        AuthenticationErrorInsufficientCredits=3,
        AuthenticationErrorInsufficientCredentials=4,
        AuthenticationErrorExpiredContract=5,
        ChargingError=50,
        ChargingErrorInsufficientCredits=51,
        ChargingErrorInsufficientCredentials=52,
        GENERALENTRYERROR=100,
        MISSINGENTRY=101,
        INVALIDENTRYENTRYNAME=150,
        SearchError=500,
        SearchErrorNoMatchFound=501,
        SearchErrorToomanymatches=502,
        SearchErrorDuplicatesearch=503,
        SystemError=900,
        ServiceMaintenanceMode=949,
        XMLParsingError=950,
        InvalidXMLdocument=951,
        UnknownError=999
    }
}
