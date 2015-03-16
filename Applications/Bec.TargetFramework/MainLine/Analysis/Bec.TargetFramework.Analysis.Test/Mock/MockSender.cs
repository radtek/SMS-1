using System;
using System.Text;

namespace Bec.TargetFramework.Analysis.Test
{
    public class MockSender : Sender
    {     
        protected override string GetBatchID()
        {
            var id = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Domain))
                id.Append(Domain.ToUpper());
            id.Append("_");
            id.Append("SMOV");
            id.Append("_");
            id.Append("INT2");
            id.Append("_");
            id.Append(GetDateNow().ToString("yyyyMMdd"));
            id.Append("_");

            if (CurrentBatchNumber == 1)
                id.Append("162758592");
            else
                id.Append("162758" + (CurrentBatchNumber - 1 + 592).ToString("000"));

            return id.ToString();
        }

        protected override DateTime GetDateNow()
        {
            return new DateTime(2015, 02, 04);
        }

        protected override string GetBatchFileName()
        {
            return GetBatchID() + ".xml";
        }
    }
}
