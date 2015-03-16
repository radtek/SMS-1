using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Bec.TargetFramework.UI.Web.Base;
using Ext.Net;
using NHibernate.Linq;
using Stimulsoft.Report.Export;

namespace Bec.TargetFramework.UI.Web.Helpers
{


    public class StoreHelper
    {
        public Model.Builder GenerateModel(Model.Builder builder,Type t,
            List<string> propertiesToIgnore = null)
        {
            return builder.Fields(fields =>
            {
                t.GetProperties(BindingFlags.Public | BindingFlags.Instance).ForEach(prop =>
                {
                    if (propertiesToIgnore == null || !propertiesToIgnore.Contains(prop.Name))
                    {
                        if (prop.PropertyType == (typeof (string)))
                            fields.Add(new ModelField(prop.Name, ModelFieldType.String));
                        else if (prop.PropertyType == (typeof (int)))
                            fields.Add(new ModelField(prop.Name, ModelFieldType.Int));
                        else if (prop.PropertyType == (typeof (float)))
                            fields.Add(new ModelField(prop.Name, ModelFieldType.Float));
                        else if (prop.PropertyType == (typeof (DateTime)))
                            fields.Add(new ModelField(prop.Name, ModelFieldType.Date));
                        else if (prop.PropertyType == (typeof (bool)))
                            fields.Add(new ModelField(prop.Name, ModelFieldType.Boolean));
                        else
                            fields.Add(new ModelField(prop.Name, ModelFieldType.Auto));
                    }
                });
            });
        }

        public AjaxProxy.Builder GenerateAjaxProxy(AjaxProxy.Builder sb, string modelIdProperty, string proxyUrl)
        {
            return 
            sb.Url(proxyUrl)
            .Reader(r => r.Add(new JsonReader { Root = "data", IDProperty = modelIdProperty }));
        }

        public Store.Builder GenerateAjaxGridStoreAndModel(Store.Builder sb,Type t, string id, string modelIdProperty, string proxyUrl, string modelName = "", List<string> propertiesToIgnore = null)
        {
            var resolver = DependencyResolver.Current as AutofacDependencyResolver;

            var fieldDetailsAndValidations =
                resolver.ApplicationContainer.Resolve<FieldDetailsAndValidationsContainerDTO>();

            Store.Builder storeBuilder = sb;

            AjaxProxy ajaxProxy = new AjaxProxy();

            Model model = new Model();

            if (!string.IsNullOrEmpty(modelName))
                model.Name = modelName;

            ModelFieldCollection mfc = new ModelFieldCollection();

            t.GetProperties(BindingFlags.Public | BindingFlags.Instance).ForEach(prop =>
            {
                if (propertiesToIgnore == null || !propertiesToIgnore.Contains(prop.Name))
                {
                    if (prop.PropertyType == (typeof(string)))
                        model.Fields.Add(new ModelField(prop.Name, ModelFieldType.String));
                    else if (prop.PropertyType == (typeof(int)))
                        model.Fields.Add(new ModelField(prop.Name, ModelFieldType.Int));
                    else if (prop.PropertyType == (typeof(float)))
                        model.Fields.Add(new ModelField(prop.Name, ModelFieldType.Float));
                    else if (prop.PropertyType == (typeof(DateTime)))
                        model.Fields.Add(new ModelField(prop.Name, ModelFieldType.Date));
                    else if (prop.PropertyType == (typeof(bool)))
                        model.Fields.Add(new ModelField(prop.Name, ModelFieldType.Boolean));
                    else
                        model.Fields.Add(new ModelField(prop.Name, ModelFieldType.Auto));
                }
            });

            

            return storeBuilder.ID(id)
                .AutoLoad(true)
                .RemoteSort(false)
                .Model(model)
                .Proxy(ajaxProxy);
        }
    }
}

                                                                    