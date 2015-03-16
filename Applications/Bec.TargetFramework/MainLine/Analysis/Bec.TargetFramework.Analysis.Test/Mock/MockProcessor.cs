using Bec.TargetFramework.Analysis.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Test
{
    public class MockProcessor : Processor
    {
        public override void Process()
        {
            TestUtils.DeletePreviousTestMortgageApplications();
            Interaction2RequestTests.AddNewApplication(MockApplicationsCount);

            var receiver = new MockReceiver();
            var matches = receiver.GetApplicationsThatMatchASearch();

            var mutationEngine = new MockMutationEngine();
            mutationEngine.Apply(new MockMutationScript());

            var mutationResults = mutationEngine.Mutate(matches);

            var collator = new MockCollator();
            var collatorResults = collator.Collate(mutationResults);

            // Trigger the code to test
            var sender = new MockSender();
            sender.OutputPath = Interaction2RequestTests.OUTPUTPATH;
            sender.Domain = "PARA";
            sender.Lender = "Paragon";
            
            var senderResult = sender.Send(collatorResults);
        }

        public int MockApplicationsCount { get; set; }
    }
}
