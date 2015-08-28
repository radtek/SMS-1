using Bec.TargetFramework.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Services.Address
{
    public interface IAddressService
    {
        List<PostCodeDTO> FindAddressesByPostCode(string postCode, string building);

        GoogleGeoCodeResponse GeoCodePostcode(string postCode);
    }
}
