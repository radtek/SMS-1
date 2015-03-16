using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum PaymentApiErrorCode
    {
        BadRequestAdditionaldetails=400,
UnauthorizedAdditionaldetails=401,
PaymentRequiredAdditionaldetails=402,
ForbiddenAdditionaldetails=403,
NotFoundAdditionaldetails=404,
MethodNotAllowedAdditionaldetails=405,
NotAcceptableAdditionaldetails=406,
ProxyAuthenticationRequiredAdditionaldetails=407,
RequestTimeoutAdditionaldetails=408,
ConflictAdditionaldetails=409,
GoneAdditionaldetails=410,
LengthRequiredAdditionaldetails=411,
PreconditionFailedAdditionaldetails=412,
RequestEntityTooLargeAdditionaldetails=413,
RequestURITooLongAdditionaldetails=414,
UnsupportedMediaTypeAdditionaldetails=415,
RequestedRangeNotSuitableAdditionaldetails=416,
ExpectationFailedAdditionaldetails=417,
InternalServerErrorAdditionaldetails=500,
    }
}
