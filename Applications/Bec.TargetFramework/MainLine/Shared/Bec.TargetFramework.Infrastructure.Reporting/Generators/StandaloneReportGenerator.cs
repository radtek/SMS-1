using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using EnsureThat;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Export;

namespace Bec.TargetFramework.Infrastructure.Reporting.Generators
{
    public sealed class StandaloneReportGenerator
    {
        private NotificationConstructDTO m_NotificationDTO;
        private List<NotificationRenderObjectDTO> m_BusinessObjects;
        private NotificationDictionaryDTO m_NotificationDictionary;

        private void InitialiseData(NotificationConstructDTO constructDto, NotificationDictionaryDTO dictionary)
        {
            m_BusinessObjects = new List<NotificationRenderObjectDTO>();
            m_NotificationDTO = constructDto;
            m_NotificationDictionary = dictionary;
        }

        public string GetReportTextItem(NotificationConstructDTO constructDto, NotificationDictionaryDTO dictionary, string id)
        {
            InitialiseData(constructDto, dictionary);

            StiReport report = LoadAndCompileReport();

            this.ProcessNotificationBusinessObjects(report);

            StiText item = report.GetComponentByName(id) as StiText;

            return item.Text.Value;
        }

        public byte[] GenerateReport(NotificationConstructDTO constructDto, NotificationDictionaryDTO dictionary, NotificationExportFormatIDEnum exportEnumValue)
        {
            InitialiseData(constructDto, dictionary);

            return LoadAndExportReport((int)exportEnumValue);
        }

        public byte[] GenerateReport(NotificationConstructDTO constructDto, NotificationDictionaryDTO dictionary)
        {
            InitialiseData(constructDto, dictionary);

            return LoadAndExportReport();
        }

        private StiReport LoadAndCompileReport()
        {
            StiReport report = new StiReport();

            // load report file
            var rep = this.m_NotificationDTO.NotificationConstructData.Single(x => x.UsesBusinessObjects ?? false);
            Ensure.That(rep).IsNotNull();
            report.Load(rep.NotificationData);

            report.Compile();

            return report;
        }

        private byte[] LoadAndExportReport(int? exportFormatOverride = null)
        {
            StiReport report = LoadAndCompileReport();

            this.ProcessNotificationBusinessObjects(report);

            report.Render();

            return ExportReport(report, exportFormatOverride);
        }

        private byte[] ExportReport(StiReport report, int? exportFormatOverride = null)
        {
            byte[] data = null;
            StiExportSettings settings = null;
            StiExportFormat exportFormat = StiExportFormat.Html5;

            int exportFormatValue = m_NotificationDTO.DefaultNotificationExportFormatID.GetValueOrDefault((int)NotificationExportFormatIDEnum.HTML5);

            if (exportFormatOverride.HasValue)
                exportFormatValue = exportFormatOverride.Value;

            if (exportFormatValue.Equals((int)NotificationExportFormatIDEnum.HTML))
            {
                settings = this.GenerateHtmlSettings();
                exportFormat = StiExportFormat.Html;
            }
            else if (exportFormatValue.Equals((int)NotificationExportFormatIDEnum.HTML5))
            {
                settings = this.GenerateHtml5Settings();
                exportFormat = StiExportFormat.Html5;
            }
            else if (exportFormatValue.Equals((int)NotificationExportFormatIDEnum.PDF))
            {
                settings = this.GeneratePdfSettings();
                exportFormat = StiExportFormat.Pdf;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                report.ExportDocument(exportFormat, ms, settings);

                data = ms.ToArray();

                ms.Close();
            }

            Ensure.That(data).IsNotNull();

            return data;
        }

        private StiExportSettings GeneratePdfSettings()
        {
            return new StiPdfExportSettings();
        }

        private StiExportSettings GenerateHtml5Settings()
        {
            var settings = new StiHtml5ExportSettings { ImageFormat = ImageFormat.Png, UseEmbeddedImages = true };

            return settings;
        }

        private StiExportSettings GenerateHtmlSettings()
        {
            var settings = new StiHtmlExportSettings
            {
                ImageFormat = ImageFormat.Png
            };

            return settings;
        }

        private void PopulateBusinessObject(
            StiReport reportSource,
            string objectParentName,
            string objectParentType,
            string name,
            string objectName,
            string objectType,
            bool isBusinessObject,
            string businessObjectCategoryName)
        {
            Ensure.That(name).IsNotNull();
            Ensure.That(objectType).IsNotNull();

            bool hasParentProperty = !string.IsNullOrEmpty(objectParentName) && !string.IsNullOrEmpty(objectParentType);
            bool hasParameterName = !string.IsNullOrEmpty(name);

            object value = null;

            if (hasParameterName)
            {
                // determine type of property
                try
                {
                    if (hasParentProperty)
                    {
                        var parentValue = GetData(objectParentName); // Get GetJsonMethod(objectParentType).Invoke(this, new object[] { objectParentName });
                        value = parentValue.GetType().GetProperty(objectName).GetValue(parentValue);
                    }
                    else
                        value = GetData(name); // GetJsonMethod(objectType).Invoke(this, new object[] { name });
                }
                catch (NullReferenceException ex)
                {
                    throw new NullReferenceException(
                        "NotificationParameter Type cannot be found:" + objectType + " parentType:" + objectParentType
                        + " parameterName:" + name);
                }

                if (value != null)
                {
                    if (isBusinessObject)
                    {
                        Ensure.That(businessObjectCategoryName).IsNotNull();

                        NotificationRenderObjectDTO dto = new NotificationRenderObjectDTO();

                        dto.BusinessObjectCategoryName = businessObjectCategoryName;
                        dto.BusinessObjectContent = ObjectToByteArray(value);
                        dto.BusinessObjectName = name;
                        dto.BusinessObjectTypeName = objectType;

                        m_BusinessObjects.Add(dto);

                        reportSource.RegBusinessObject(
                         businessObjectCategoryName,
                         name,
                         value);
                    }
                }
                else
                    throw new NullReferenceException(
                        "NotificationParameter has no value in json:" + objectType + " parentType:" + objectParentType
                        + " parameterName:" + name);
            }
        }


        private void ProcessNotificationBusinessObjects(StiReport report)
        {
            m_NotificationDTO.NotificationConstructParameters.ToList()
                .ForEach(
                    item =>
                    this.PopulateBusinessObject(
                        report,
                        item.ObjectParentName,
                        item.ObjectParentType,
                        item.ParameterOrBusinessObjectName,
                        item.ObjectName,
                        item.ObjectType, item.IsBusinessObject.GetValueOrDefault(false), item.BusinessObjectCategoryName));
        }

        private T GetData<T>(string key) where T : class
        {
            Ensure.That(key).IsNotNullOrEmpty();
            Ensure.That(m_NotificationDictionary.NotificationDictionary.ContainsKey(key)).IsTrue();

            T t = null;

            object value = null;

            if (m_NotificationDictionary.NotificationDictionary.TryGetValue(key, out value))
                if (value.GetType() == typeof(T))
                    return (T)value;

            return t;
        }

        private object GetData(string key)
        {
            Ensure.That(key).IsNotNullOrEmpty();
            Ensure.That(m_NotificationDictionary.NotificationDictionary.ContainsKey(key)).IsTrue();

            object value = null;

            m_NotificationDictionary.NotificationDictionary.TryGetValue(key, out value);

            return value;
        }

        private bool DataContains(string key)
        {
            return this.m_NotificationDictionary.NotificationDictionary.ContainsKey(key);
        }

        private byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        public List<NotificationRenderObjectDTO> BusinessObjects
        {
            get
            {
                return m_BusinessObjects;
            }
        }
    }
}
