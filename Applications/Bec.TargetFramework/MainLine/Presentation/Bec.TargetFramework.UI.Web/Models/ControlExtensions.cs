using Bec.TargetFramework.UI.Web;
using Bec.TargetFramework.UI.Web.Helpers;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Web.Framework.Extensions
{
    public static class ControlExtensions
    {
        public static TextArea.Builder ApplyFieldDefaults(this TextArea.Builder builder, string ipName, string fdName)
        {
            return new FieldDetailHelper<TextArea.Builder>().ApplyFieldDefaults(builder, ipName, fdName);
        }
        public static DateField.Builder ApplyFieldDefaults(this DateField.Builder builder, string ipName, string fdName)
        {
            return new FieldDetailHelper<DateField.Builder>().ApplyFieldDefaults(builder, ipName, fdName);
        }

        public static NumberField.Builder ApplyFieldDefaults(this NumberField.Builder builder, string ipName, string fdName)
        {
            return new FieldDetailHelper<NumberField.Builder>().ApplyFieldDefaults(builder, ipName, fdName);
        }

        public static ComboBox.Builder ApplyFieldDefaults(this ComboBox.Builder builder, string ipName, string fdName)
        {
            return new FieldDetailHelper<ComboBox.Builder>().ApplyFieldDefaults(builder, ipName, fdName);
        }
        public static FormPanel.Builder ApplyFieldDefaults(this FormPanel.Builder builder, string ipName, string fdName)
        {
            return new FieldDetailHelper<FormPanel.Builder>().ApplyFieldDefaults(builder, ipName, fdName);
        }

        public static Store.Builder GenerateAjaxGridStoreAndModel<T>(this Store.Builder builder, string id, string modelIdProperty, string proxyUrl, string modelName = "", List<string> propertiesToIgnore = null) where T : class
        {
            return new StoreHelper().GenerateAjaxGridStoreAndModel(builder,typeof(T), id, modelIdProperty, proxyUrl, modelName = "", propertiesToIgnore = null);
        }

        public static AjaxProxy.Builder GenerateAjaxProxy(this AjaxProxy.Builder builder,string modelIdProperty, string proxyUrl) 
        {
            return new StoreHelper().GenerateAjaxProxy(builder, modelIdProperty, proxyUrl);
        }

        public static Model.Builder GenerateModel<T>(this Model.Builder builder, List<string> propertiesToIgnore = null) where T : class
        {
            return new StoreHelper().GenerateModel(builder,typeof(T), propertiesToIgnore = null);
        }

        public static Panel.Builder ApplyPanelDefaults(this Panel.Builder builder, string ipName)
        {
            return new FieldDetailHelper<Panel.Builder>().ApplyPanelDefaults(builder, ipName);
        }

        public static Checkbox.Builder ApplyFieldDefaults(this Checkbox.Builder builder, string ipName, string fdName)
        {
            return new FieldDetailHelper<Checkbox.Builder>().ApplyFieldDefaults(builder, ipName, fdName);
        }

        public static RadioGroup.Builder ApplyRadioGroupDefaults(this RadioGroup.Builder builder, string ipName, string fdName)
        {
            return new FieldDetailHelper<RadioGroup.Builder>().ApplyFieldDefaults(builder, ipName, fdName);
        }

        public static FormPanel.Builder ApplyFormPanelDefaults(this FormPanel.Builder builder, Func<FormPanel.Builder, FormPanel.Builder> func)
        {
            return func.Invoke(builder);
        }

        public static Button.Builder ApplyButtonDefaults(this Button.Builder builder, Func<Button.Builder, Button.Builder> func)
        {
            return func.Invoke(builder);
        }

        public static TextField.Builder ApplyTextFieldDefaults(this TextField.Builder builder, Func<TextField.Builder, TextField.Builder> func)
        {
            return func.Invoke(builder);
        }

        public static TextField.Builder ApplyFieldDefaults(this TextField.Builder builder, string ipName, string fdName)
        {
            return new FieldDetailHelper<TextField.Builder>().ApplyFieldDefaults(builder, ipName, fdName);
        }

        public static Label.Builder ApplyFieldDefaults(this Label.Builder builder, string ipName, string fdName)
        {
            return new FieldDetailHelper<Label.Builder>().ApplyFieldDefaults(builder, ipName, fdName);
        }

        public static Image.Builder ApplyFieldDefaults(this Image.Builder builder, string ipName, string fdName)
        {
            return new FieldDetailHelper<Image.Builder>().ApplyFieldDefaults(builder, ipName, fdName);
        }      

        public static Container.Builder ApplyContainerDefaults(this Container.Builder builder, Func<Container.Builder, Container.Builder> func)
        {
            return func.Invoke(builder);
        }

        public static DateField.Builder ApplyDateFieldDefaults(this DateField.Builder builder, Func<DateField.Builder, DateField.Builder> func)
        {
            return func.Invoke(builder);
        }

        public static Checkbox.Builder ApplyCheckboxDefaults(this Checkbox.Builder builder, Func<Checkbox.Builder, Checkbox.Builder> func)
        {
            return func.Invoke(builder);
        }

        public static TextArea.Builder ApplyTextAreaDefaults(this TextArea.Builder builder, Func<TextArea.Builder, TextArea.Builder> func)
        {
            return func.Invoke(builder);
        }

        public static ComboBox.Builder ApplyComboxDefaults(this ComboBox.Builder builder, Func<ComboBox.Builder, ComboBox.Builder> func)
        {
            return func.Invoke(builder);
        }

        public static LinkButton.Builder ApplyLogOutLinkButtonDefaults(this LinkButton.Builder builder, Func<LinkButton.Builder, LinkButton.Builder> func)
        {
            return func.Invoke(builder);
        }
    }


}
