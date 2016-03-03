using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure;
using EnsureThat;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class ProductLogicController : LogicBase
    {
        public ProductLogicController()
        {
        }

        public ProductDTO GetTopUpProduct()
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().Products.Single(x => x.ProductDetails.FirstOrDefault().Name == "Credit Top Up").ToDtoWithRelated(1);
            }
        }

        public ProductDetailDTO GetBankAccountCheckProduct()
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().ProductDetails.Single(x => x.Name == "Bank Account Check").ToDtoWithRelated(1);
            }
        }
    }
}
