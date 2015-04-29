using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.SB.Entities.Enums
{
    public enum BusMessageTypeIDEnum : int
    {
        [StringValue("Atomic")]
        Atomic = 801300,
        [StringValue("Scheduled")]
        Scheduled = 801301
    }
    public enum BusMessageStatusIDEnum : int
    {
        [StringValue("Completed")]
        Completed = 801400,
        [StringValue("Failed")]
        Failed = 801401,
        [StringValue("Received")]
        Received = 801402,
        [StringValue("Sent")]
        Sent = 801403
    }

    public enum BusTaskStatusEnum : int
    {
        [StringValue("Pending")]
        Pending = 1,
        [StringValue("Successful")]
        Successful = 2,
        [StringValue("Failed")]
        Failed = 3,
        [StringValue("Processing")]
        Processing = 4
    }

    public enum StatusTypeEnum : int
    {
        [StringValue("Bus Task Schedule Process Log Status")]
        BusTaskScheduleProcessLogStatus = 1,
        [StringValue("Bus Message Process Log Status")]
        BusMessageProcessLogStatus = 2
    }

    public enum BusMessageStatusEnum : int
    {
        [StringValue("Pending")]
        Pending = 1,
        [StringValue("Successful")]
        Successful = 2,
        [StringValue("Failed")]
        Failed = 3,
        [StringValue("Processing")]
        Processing = 4,
        [StringValue("Received")]
        Received = 5,
        [StringValue("Sent")]
        Sent = 6
    }
}
