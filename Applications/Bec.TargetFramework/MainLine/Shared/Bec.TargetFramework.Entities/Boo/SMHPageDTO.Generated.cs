﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    [System.Serializable]
    public partial class SMHPageDTO
    {
        #region Constructors
  
        public SMHPageDTO() {
        }

        public SMHPageDTO(global::System.Guid pageID, string pageName, string pageURL, global::System.Nullable<System.Guid> roleId, List<SMHItemDTO> sMHItems, RoleDTO role) {

          this.PageID = pageID;
          this.PageName = pageName;
          this.PageURL = pageURL;
          this.RoleId = roleId;
          this.SMHItems = sMHItems;
          this.Role = role;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PageID { get; set; }

        [DataMember]
        public string PageName { get; set; }

        [DataMember]
        public string PageURL { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> RoleId { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<SMHItemDTO> SMHItems { get; set; }

        [DataMember]
        public RoleDTO Role { get; set; }

        #endregion
    }

}
