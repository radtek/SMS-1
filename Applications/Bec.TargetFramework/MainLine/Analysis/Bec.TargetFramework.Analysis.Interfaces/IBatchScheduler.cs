using Quartz;
using System;
namespace Bec.TargetFramework.Analysis.Interfaces
{
    public interface IBatchScheduler
    {
        DateTime GetNextTriggerDate();

        void Start();
    }
}
