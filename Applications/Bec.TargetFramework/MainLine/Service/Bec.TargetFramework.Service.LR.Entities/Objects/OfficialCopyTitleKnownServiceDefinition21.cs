using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Service.LR.Entities.OfficialCopyTitleKnown21;
using Bec.TargetFramework.Service.LR.Infrastructure.Base;
using Bec.TargetFramework.Service.LR.Interfaces.Interfaces;

namespace Bec.TargetFramework.Service.LR.Entities.Objects
{
    public class OfficialCopyTitleKnownServiceDefinition21 : LRServiceDefinitionBase
    {
        public override object CreateAndInitialiseRequest(ConcurrentDictionary<string, object> objectDictionary)
        {
            var requestDto = objectDictionary["LRServiceRequestDTO"] as LRServiceRequestDTO;

            var request = new RequestTitleKnownOfficialCopyV2_1Type();
            request.Product = new Q1ProductType();

            request.Product.CustomerReference = new Q1CustomerReferenceType();
            request.Product.ExternalReference = new Q1ExternalReferenceType();
            request.Product.DocumentDetails = new Q1DocumentDetailsType[0];
            request.Product.Contact = new Q1ContactType[1];
            request.Product.ExpectedPrice = new Q1ExpectedPriceType();
            request.Product.ExpectedPrice.GrossPriceAmount = new AmountType();
            request.Product.TitleKnownOfficialCopy = new Q1TitleKnownOfficialCopyType();
            request.Product.SubjectProperty = new Q1SubjectPropertyType();
            request.Product.SubjectProperty.TenureTypeCode = new TenureCodeType();
            request.Product.SubjectProperty.TitleNumber = new Q2TextType();     
            request.ID = new Q1IdentifierType();
            request.ID.MessageID = new Q1TextType();
            request.ID.MessageID.Value = requestDto.MessageID;
            request.Product.CustomerReference.Reference = requestDto.CustomerReference;
            request.Product.ExternalReference.Reference = requestDto.ExternalReference;

            return request;
        }

        public override Type ServiceClientType
        {
            get { return typeof(OfficialCopyTitleKnown21.OC1TitleKnownV2_1ServiceClient); }
        }
    }
}
