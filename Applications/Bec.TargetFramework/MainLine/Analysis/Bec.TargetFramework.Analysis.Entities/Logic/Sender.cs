using Bec.TargetFramework.Analysis.Infrastructure;
using Bec.TargetFramework.Analysis.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bec.TargetFramework.Analysis
{
    public class Sender : ISender
    {
        public string Domain { get; set; }
        public string Lender { get; set; }
        public int BatchSize { get; set; }
        public int CurrentBatchNumber { get; private set; }

        public bool Send(List<SearchDetail> inputs)
        {
            // In case BatchSize is not set
            if (BatchSize <= 0)
                BatchSize = inputs.Count;

            // Split the inputs into batches
            var batchInputs = Split(inputs, BatchSize);

            // Process each batch
            CurrentBatchNumber = 0;
            foreach (var batchInput in batchInputs)
            {
                CurrentBatchNumber++;
                CreateNewBatch(batchInput);
            }

            return true;
        }

        private static List<List<SearchDetail>> Split(List<SearchDetail> source, int batchSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / batchSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        private void CreateNewBatch(List<SearchDetail> inputs)
        {
            var batch = new Batch();
            batch.Domain = Domain;
            batch.Lender = Lender;
            batch.BatchID = GetBatchID();
            batch.BatchFileName = GetBatchFileName();

            batch.CreatedOn = GetDateNow();
            batch.CreatedOnSpecified = true;
            batch.Search = new List<SearchDetail>();
            for (int i = 0; i < inputs.Count; i++)
            {
                inputs[i].Domain = null;
                inputs[i].Lender = null;
                batch.Search.Add(inputs[i]);
            }

            // Get the xml representation of the search result
            var xml = SearchDetailHelper.Serialize<Batch>(batch);

            File.WriteAllText(Path.Combine(OutputPath, batch.BatchFileName), xml);
        }

        public string OutputPath { get; set; }

        protected virtual DateTime GetDateNow()
        {
            return DateTime.Now.Date;
        }

        protected virtual string GetBatchFileName()
        {
            return GetBatchID() + ".xml";
        }

        protected virtual string GetBatchID()
        {
            var id = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Domain))
                id.Append(Domain.ToUpper());
            id.Append("_");
            id.Append("SMOV");
            id.Append("_");
            id.Append("INT2");
            id.Append("_");
            id.Append(DateTime.Now.ToString("yyyyMMdd"));
            id.Append("_");
            id.Append(DateTime.Now.ToString("HHmmssfff"));
            return id.ToString();
        }
    }
}
