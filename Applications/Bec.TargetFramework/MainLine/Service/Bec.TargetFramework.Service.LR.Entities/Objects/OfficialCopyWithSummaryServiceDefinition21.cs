using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Service.LR.Entities.EnquiryByPropertyDescription20;
using Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummary21;
using Bec.TargetFramework.Service.LR.Infrastructure.Base;
using Bec.TargetFramework.Service.LR.Interfaces.Interfaces;
using Q1CustomerReferenceType = Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummary21.Q1CustomerReferenceType;
using Q1ExternalReferenceType = Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummary21.Q1ExternalReferenceType;
using Q1IdentifierType = Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummary21.Q1IdentifierType;
using Q1ProductType = Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummary21.Q1ProductType;
using Q1SubjectPropertyType = Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummary21.Q1SubjectPropertyType;
using Q1TextType = Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummary21.Q1TextType;

namespace Bec.TargetFramework.Service.LR.Entities.Objects
{
    public class OfficialCopyWithSummaryServiceDefinition21 : LRServiceDefinitionBase
    {
        public override object CreateAndInitialiseRequest(ConcurrentDictionary<string, object> objectDictionary)
        {
            var requestDto = objectDictionary["LRServiceRequestDTO"] as LRServiceRequestDTO;

            var request = new RequestOCWithSummaryV2_0Type();
            request.Product = new Q1ProductType();
            request.Product.CustomerReference = new Q1CustomerReferenceType();
            request.Product.ExternalReference = new Q1ExternalReferenceType();

            request.Product.TitleKnownOfficialCopy = new Q1TitleKnownOfficialCopyType();
            request.Product.ExpectedPrice = new Q1ExpectedPriceType();
            request.Product.ExpectedPrice.GrossPriceAmount = new AmountType();
            request.Product.SubjectProperty = new Q1SubjectPropertyType();
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
            get { return typeof(OfficialCopyWithSummary21.OCWithSummaryV2_1ServiceClient); }
        }
    }
}
