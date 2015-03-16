using System;
using System.Collections.Generic;
using System.Linq;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;

namespace Bec.TargetFramework.Business.Logic
{
    using Bec.TargetFramework.Aop.Aspects;
    using Bec.TargetFramework.Entities;

    [Trace(TraceExceptionsOnly = true)]
    public class DeductionLogic : LogicBase, IDeductionLogic
    {
        public DeductionLogic(ILogger logger, ICacheProvider cacheProvider) : base(logger, cacheProvider)
        {
        }

        public List<VProductDeductionDTO> GetProductDeductions(Guid productID, int versionNumber)
        {
            List<VProductDeductionDTO> deductions = new List<VProductDeductionDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                scope.DbContext
                     .VProductDeductions
                     .Where(item => item.ProductID.Equals(productID) && item.ProductVersionID.Equals(versionNumber))
                     .ToList()
                     .ForEach(item =>
                     {
                         deductions.Add(VProductDeductionConverter.ToDto(item));
                     });
            }

            return deductions;
        }

        public List<VCountryDeductionDTO> GetCountryDeductions(string countryCode)
        {
            List<VCountryDeductionDTO> deductions = new List<VCountryDeductionDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                scope.DbContext
                     .VCountryDeductions
                     .Where(item => item.CountryCode.Equals(countryCode))
                     .ToList()
                     .ForEach(item =>
                     {
                         deductions.Add(VCountryDeductionConverter.ToDto(item));
                     });
            }

            return deductions;
        }
    }
}
