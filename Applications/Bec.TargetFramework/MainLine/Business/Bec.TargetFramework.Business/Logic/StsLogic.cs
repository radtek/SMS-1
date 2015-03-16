using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Business.Infrastructure;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using EnsureThat;

namespace Bec.TargetFramework.Business.Logic
{
    public class StsLogic : LogicBase , IStsLogic
    {
        private IClassificationDataLogic m_ClassificationLogic;
        private ILRLogic m_LRLogic;

        public StsLogic(ILogger logger, ICacheProvider cacheProvider, IClassificationDataLogic dataLogic,ILRLogic lrLogic)
            : base(logger, cacheProvider)
        {
            m_ClassificationLogic = dataLogic;
            m_LRLogic = lrLogic;
        }

        //public void SaveLRDocument(UnitOfWorkScope<TargetFrameworkEntities> scope,LRDocumentDTO dto)
        //{

        //        var entity = LRDocumentConverter.ToEntity(dto);

        //        if (entity.Attachment != null)
        //        {
        //            Attachment attachment = AttachmentConverter.ToEntity(dto.Attachment);

        //            attachment.ParentID = entity.LRDocumentID;

        //            scope.DbContext.Attachments.Add(attachment);
        //        }

        //        scope.DbContext.LRDocuments.Add(entity);
        //}

        //[EnsureArgumentAspect]
        //public void SaveLRDocumentList(List<LRDocumentDTO> dtoList)
        //{
        //    using (
        //        var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
        //            true))
        //            {

        //        dtoList.ForEach(item =>
        //        {
        //            SaveLRDocument(scope, item);
        //        });

        //                scope.Save();
        //            }

        //}

        //public void SaveLRTitle(Guid stsPropertyId,Guid productPurchaseProductTaskID,Guid? stsSearchPropertyId, LRTitleDTO dto)
        //{
        //    using (
        //        var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
        //            true))
        //    {
        //        var title = LRTitleConverter.ToEntity(dto);

        //        title.StsPropertyID = stsPropertyId;
        //        title.ProductPurchaseProductTaskID = productPurchaseProductTaskID;

        //        if (stsSearchPropertyId.HasValue)
        //            title.StsSearchPropertyID = stsSearchPropertyId;

        //        // create address
        //        if (dto.Address != null)
        //        {
        //            var address = AddressConverter.ToEntity(dto.Address);

        //            address.ParentID = title.LRTitleID;

        //            scope.DbContext.Addresses.Add(address);
        //        }

        //        // add and save title
        //        scope.DbContext.LRTitles.Add(title);

        //        scope.Save();
        //    }
        //}

        //public void SaveLRTitleList(Guid stsPropertyId, Guid productPurchaseProductTaskID, Guid? stsSearchPropertyId, List<LRTitleDTO> dtoList)
        //{
        //    using (
        //        var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
        //            true))
        //    {
        //        dtoList.ForEach(item =>
        //        {
        //            var title = LRTitleConverter.ToEntity(dto);

        //            title.StsPropertyID = stsPropertyId;
        //            title.ProductPurchaseProductTaskID = productPurchaseProductTaskID;

        //            if (stsSearchPropertyId.HasValue)
        //                title.StsSearchPropertyID = stsSearchPropertyId;

        //            // create address
        //            if (dto.Address != null)
        //            {
        //                var address = AddressConverter.ToEntity(dto.Address);

        //                address.ParentID = title.LRTitleID;

        //                scope.DbContext.Addresses.Add(address);
        //            }

        //            // add and save title
        //            scope.DbContext.LRTitles.Add(title);
                    
        //        });

        //        scope.Save();
        //    }
        //}

        //public void SaveLRRegisterExtractWithDocuments(LRRegisterExtractDTO dto,List<LRDocumentDTO> documents )
        //{
        //    using (
        //        var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
        //    true))
        //    {
        //        var register = LRRegisterExtractConverter.ToEntity(dto);

        //        scope.DbContext.LRRegisterExtracts.Add(register);

        //        // save any documents
        //        if (documents != null && documents.Count > 0)
        //        {
        //            documents.ForEach(item =>
        //            {
        //                SaveLRDocument(scope, item);
        //            });
        //        }

        //        scope.Save();
        //    }
        //}

        //public void SaveLRRegisterExtract(LRRegisterExtractDTO dto)
        //{
        //    using (
        //        var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
        //    true))
        //    {
        //        var register = LRRegisterExtractConverter.ToEntity(dto);

        //        scope.DbContext.LRRegisterExtracts.Add(register);

        //        scope.Save();
        //    }
        //}
    }
}
