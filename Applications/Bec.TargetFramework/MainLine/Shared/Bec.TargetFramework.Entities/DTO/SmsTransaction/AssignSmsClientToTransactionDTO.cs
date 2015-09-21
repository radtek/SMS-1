﻿using System;
using Bec.TargetFramework.Entities.Enums;

namespace Bec.TargetFramework.Entities
{
    [System.Serializable]
    public class AssignSmsClientToTransactionDTO
    {
        public Guid TransactionID { get; set; }
        public Guid UaoID { get; set; }
        public Guid AssigningByOrganisationID { get; set; }
        public UserAccountOrganisationTransactionType UserAccountOrganisationTransactionType { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string AdditionalAddressInformation { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostalCode { get; set; }
        public bool Manual { get; set; }
    }
}
