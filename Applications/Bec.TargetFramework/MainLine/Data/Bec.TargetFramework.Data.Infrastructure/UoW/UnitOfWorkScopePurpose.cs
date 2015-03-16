using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Data.Infrastructure
{
    /// <summary>
    /// Purpose of a UnitOfWorkScope.
    /// </summary>
    public enum UnitOfWorkScopePurpose
    {
        /// <summary>
        /// This unit of work scope will only be used for reading.
        /// </summary>
        Reading,

        /// <summary>
        /// This unit of work scope will be used for writing. If SaveChanges
        /// isn't called, it cancels the entire unit of work.
        /// </summary>
        Writing
    }
}
