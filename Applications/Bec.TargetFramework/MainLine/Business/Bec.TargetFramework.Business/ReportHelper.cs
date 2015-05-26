using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using EnsureThat;
using Stimulsoft.Report;
using Stimulsoft.Report.Export;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business
{
    public static class ReportHelper
    {
        public static string GetReportTextItem(NotificationConstructDTO constructDto, NotificationDictionaryDTO dictionary, string id)
        {
            StiReport report = new StiReport();
            report.Load(Enumerable.First(constructDto.NotificationConstructData).NotificationData);
            report.Compile();

            Stimulsoft.Report.Components.StiText item = report.GetComponentByName(id) as Stimulsoft.Report.Components.StiText;

            return item.Text.Value;
        }

        public static byte[] GenerateReport(NotificationConstructDTO constructDto, NotificationDictionaryDTO dictionary, NotificationExportFormatIDEnum exportEnumValue)
        {
            StiReport report = new StiReport();
            report.Load(Enumerable.First(constructDto.NotificationConstructData).NotificationData);
            report.Compile();
            report.Render();

            byte[] data = null;
            StiExportSettings settings = new StiPdfExportSettings();
            var exportFormat = StiExportFormat.Pdf;

            using (MemoryStream ms = new MemoryStream())
            {
                report.ExportDocument(exportFormat, ms, settings);

                data = ms.ToArray();

                ms.Close();
            }

            Ensure.That(data).IsNotNull();

            return data;
        }
    }
}
