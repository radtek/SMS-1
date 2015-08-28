using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Entities
{
    
    public partial class OrganisationUnitDTO
    {

        //public OrganisationUnitDTO()
        //{
        //    IsConcreteOrganisation = false;
        //    if(OrganisationID != Guid.Empty)
        //        StrOrganisationId = OrganisationID.ToString();
        //}


        public string UnitJson { get; set; }

        public bool IsConcreteOrganisation { get; set; }

        public string StrOrganisationId { get; set; }
    }
}
