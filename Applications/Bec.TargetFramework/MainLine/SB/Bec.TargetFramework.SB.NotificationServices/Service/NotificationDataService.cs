
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.WCF.Exception;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.SB.Notifications.Base;
using Bec.TargetFramework.SB.NotificationServices.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Autofac;
using EnsureThat;

namespace Bec.TargetFramework.SB.NotificationServices.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NotificationDataService" in both code and config file together.
    //[WcfGlobalExceptionOperationBehaviorAttribute(typeof(WcfGlobalErrorHandler))]
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    //public class NotificationDataService : INotificationDataService
    //{
    //    private ILogger m_Logger;
    //    private INotificationLogic m_Logic;

    //    public NotificationDataService(ILogger logger,INotificationLogic logic)
    //    {
    //        m_Logger = logger;
    //        m_Logic = logic;
    //    }

    //    public byte[] GenerateNotificationOutputFromNotificationID(Guid notificationID)
    //    {
    //        Ensure.That(notificationID.Equals(Guid.Empty)).IsFalse();

    //        byte[] data = null;

    //        using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, m_Logger))
    //        {
    //            var notification = scope.DbContext.Notifications.Single(s => s.NotificationID.Equals(notificationID));

    //            var constructDto = m_Logic.GetNotificationConstruct(notification.NotificationConstructID,notification.NotificationConstructVersionNumber);
    //            StandaloneReportGenerator generator = NotificationService.m_IocContainer.Resolve<StandaloneReportGenerator>();

    //            data = generator.GenerateReport(constructDto,JsonHelper.DeserializeData<NotificationDictionaryDTO>( notification.NotificationData));
    //        }

    //        return data;
    //    }

    //    public byte[] GenericNotificationtOutputFromNotificationConstruct(Guid notificationConstructID, int notificationConstructVersionNumber, NotificationDictionaryDTO dto, NotificationExportFormatIDEnum exportFormatEnumValue)
    //    {
    //        Ensure.That(notificationConstructID.Equals(Guid.Empty)).IsFalse();

    //        byte[] data = null;

    //        using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, m_Logger))
    //        {
    //            var constructDto = m_Logic.GetNotificationConstruct(notificationConstructID, notificationConstructVersionNumber);

    //            // determine whether has mutator
    //            if (!string.IsNullOrEmpty(constructDto.NotificationConstructMutatorObjectType))
    //            {
    //                // create mutator and execute
    //                Type mutatorType = Type.GetType(constructDto.NotificationConstructMutatorObjectType, false);

    //                Ensure.That(mutatorType).IsNotNull();

    //                BaseNotificationMutator mutator = Activator.CreateInstance(mutatorType) as BaseNotificationMutator;

    //                mutator.IocContainer = NotificationService.m_IocContainer;

    //                // initialise main 
    //                mutator.InitialiseBase(dto);

    //                // initialuse mutation
    //                mutator.InitialiseMutator();

    //                // perform mutation
    //                dto = mutator.MutateNotification();
    //            }

    //            StandaloneReportGenerator generator = NotificationService.m_IocContainer.Resolve<StandaloneReportGenerator>();

    //            data = generator.GenerateReport(constructDto, dto, exportFormatEnumValue);
    //        }

    //        return data;
    //    }

    //    public NotificationRenderDTO GenerateNotificationNotCompiledOutputFromNotificationID(Guid notificationID)
    //    {
    //        Ensure.That(notificationID.Equals(Guid.Empty)).IsFalse();

    //        NotificationRenderDTO dto = new NotificationRenderDTO();

    //        byte[] data = null;

    //        using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, m_Logger))
    //        {
    //            var notification = scope.DbContext.Notifications.Single(s => s.NotificationID.Equals(notificationID));

    //            var constructDto = m_Logic.GetNotificationConstruct(notification.NotificationConstructID, notification.NotificationConstructVersionNumber);
    //            StandaloneReportGenerator generator = NotificationService.m_IocContainer.Resolve<StandaloneReportGenerator>();

    //            data = generator.GenerateReportMrt(constructDto,JsonHelper.DeserializeData<NotificationDictionaryDTO>(notification.NotificationData));

    //            dto.ReportTemplate = data;
    //            dto.NotificationConstructDTO = constructDto;
    //            dto.json = notification.NotificationData;
    //            dto.BusinessObjects = generator.BusinessObjects;
    //        }

    //        return dto;
    //    }        
    //}
}
