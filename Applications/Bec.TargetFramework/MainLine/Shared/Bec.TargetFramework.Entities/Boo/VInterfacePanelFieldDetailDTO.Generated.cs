﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
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
    public partial class VInterfacePanelFieldDetailDTO
    {
        #region Constructors
  
        public VInterfacePanelFieldDetailDTO() {
        }

        public VInterfacePanelFieldDetailDTO(global::System.Guid interfacePanelID, string panelname, global::System.Guid fieldDetailID, string fieldname, string overrideValidationMessage) {

          this.InterfacePanelID = interfacePanelID;
          this.Panelname = panelname;
          this.FieldDetailID = fieldDetailID;
          this.Fieldname = fieldname;
          this.OverrideValidationMessage = overrideValidationMessage;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid InterfacePanelID { get; set; }

        [DataMember]
        public string Panelname { get; set; }

        [DataMember]
        public global::System.Guid FieldDetailID { get; set; }

        [DataMember]
        public string Fieldname { get; set; }

        [DataMember]
        public string OverrideValidationMessage { get; set; }

        #endregion
    }

}
