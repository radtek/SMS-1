using Bec.TargetFramework.Analysis.Interfaces;
using Bec.TargetFramework.Data.Analysis;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Log;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using Bec.TargetFramework.Analysis;

namespace Bec.TargetFramework.Analysis
{
    public class Receiver : IReceiver
    {
        public List<SearchDetail> GetApplicationsThatMatchASearch()
        {
            var matches = new List<SearchDetail>();

            // Read the DB to get all the applications recorded so far, that are active
            using (var scope = new UnitOfWorkScope<TargetFrameworkAnalysisEntities>(UnitOfWorkScopePurpose.Reading, new NullLogger(), true))
            {
                var AnalysisInputMortgageApplicationRepos = scope.GetGenericRepository<AnalysisInputMortgageApplication, Guid>();
                var list = AnalysisInputMortgageApplicationRepos.FindAll(
                    s => s.IsActive.Equals(true)
                        && s.IsDeleted.Equals(false))
                        .ToList();

                // Convert it to the usable dto
                list.ForEach(it => matches.Add(ConvertApplicationToSearchDTO(it)));
            }

            return matches;
        }

        private SearchDetail ConvertApplicationToSearchDTO(AnalysisInputMortgageApplication application)
        {
            Ensure.That(application.InputData).IsNotNull();
            return JsonHelper.DeserializeData<SearchDetail>(application.InputData);
        }
    }
}
