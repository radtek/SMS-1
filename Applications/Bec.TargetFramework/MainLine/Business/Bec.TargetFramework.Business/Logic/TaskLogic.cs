using System;
using System.Collections.Generic;
using System.Linq;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
//Bec.TargetFramework.Entities
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;

namespace Bec.TargetFramework.Business.Logic
{
    using System.Collections.ObjectModel;
    using System.Reflection.Emit;
    using System.Runtime.Remoting.Messaging;

    using Bec.TargetFramework.Aop.Aspects;
    using Bec.TargetFramework.Entities;

    using Omu.ValueInjecter;

    [Trace(TraceExceptionsOnly = true)]
    public class TaskLogic : LogicBase, ITaskLogic
    {
        public TaskLogic(ILogger logger, ICacheProvider cacheProvider)
            : base(logger, cacheProvider)
        {
        }


        public List<VBusTaskScheduleDTO> GetAllBusTaskSchedules()
        {
            List<VBusTaskScheduleDTO> list = new List<VBusTaskScheduleDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                list = VBusTaskScheduleConverter.ToDtos(scope.DbContext.VBusTaskSchedules);
            }

            return list;
        }
    }
}
