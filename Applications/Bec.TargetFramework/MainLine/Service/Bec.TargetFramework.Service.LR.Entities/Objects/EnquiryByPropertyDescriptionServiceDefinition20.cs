using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Service.LR.Entities.EnquiryByPropertyDescription20;
using Bec.TargetFramework.Service.LR.Infrastructure.Base;
using Bec.TargetFramework.Service.LR.Interfaces.Interfaces;

namespace Bec.TargetFramework.Service.LR.Entities.Objects
{
    public class EnquiryByPropertyDescriptionServiceDefinition20 : LRServiceDefinitionBase
    {
        public override object CreateAndInitialiseRequest(ConcurrentDictionary<string, object> objectDictionary)
        {
            var requestDto = objectDictionary["LRServiceRequestDTO"] as LRServiceRequestDTO;


            var request = new RequestSearchByPropertyDescriptionV2_0Type();
            request.Product = new Q1ProductType();

            request.Product.SubjectProperty = new Q1SubjectPropertyType();
            request.Product.SubjectProperty.Address = new Q1AddressType();
            request.Product.CustomerReference = new Q1CustomerReferenceType();
            request.Product.ExternalReference = new Q1ExternalReferenceType();

            request.ID = new Q1IdentifierType();
            request.ID.MessageID = new Q1TextType();
            request.ID.MessageID.Value = requestDto.MessageID;
            request.Product.CustomerReference.Reference = requestDto.CustomerReference;
            request.Product.ExternalReference.Reference = requestDto.ExternalReference;

            return request;
        }

        public override Type ServiceClientType
        {
            get { return typeof(PropertyDescriptionEnquiryV2_0ServiceClient); }
        }
    }
}
