using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Framework.Configuration;
using Ext.Net;
using Fabrik.Common;
using Bec.TargetFramework.UI.Web.Base;

namespace Bec.TargetFramework.UI.Web
{
    public class FieldDetailHelper<T> where T:class
    {
        public T ApplyFieldDefaults(T t,string ipName, string fdName)
        {
            var resolver = DependencyResolver.Current as AutofacDependencyResolver;

            var fieldDetailsAndValidations = resolver.ApplicationContainer.Resolve<FieldDetailsAndValidationsContainerDTO>();

            VFieldDetailForUIDTO fDto = fieldDetailsAndValidations.GetFieldDetail(ipName, fdName);
            // now call correct default method for builder type
            if (typeof(T) == typeof(TextField.Builder))
                t = (T)ApplyTextFieldDefaults((TextField.Builder)Convert.ChangeType(t, typeof(TextField.Builder)), ipName, fdName, fDto);
            else if (typeof(T) == typeof(NumberField.Builder))
                t = (T)ApplyNumberFieldDefaults((NumberField.Builder)Convert.ChangeType(t, typeof(NumberField.Builder)), ipName, fdName, fDto);
            else if (typeof(T) == typeof(Label.Builder))
                t = (T)ApplyLabelFieldDefaults((Label.Builder)Convert.ChangeType(t, typeof(Label.Builder)), ipName, fdName, fDto);
            else if (typeof(T) == typeof(Image.Builder))
                t = (T)ApplyImageFieldDefaults((Image.Builder)Convert.ChangeType(t, typeof(Image.Builder)), ipName, fdName, fDto);
            else if (typeof(T) == typeof(ComboBox.Builder))
                t = (T)ApplyComboBoxDefaults((ComboBox.Builder)Convert.ChangeType(t, typeof(ComboBox.Builder)), ipName, fdName, fDto);
            else if (typeof(T) == typeof(FormPanel.Builder))
                t = (T)ApplyFormPanelDefaults((FormPanel.Builder)Convert.ChangeType(t, typeof(FormPanel.Builder)), ipName, fdName, fDto);
            else if (typeof(T) == typeof(RadioGroup.Builder))
                t = (T)ApplyRadioGroupDefaults((RadioGroup.Builder)Convert.ChangeType(t, typeof(RadioGroup.Builder)), ipName, fdName, fDto);
            else if (typeof(T) == typeof(Panel.Builder))
                t = (T)ApplyPanelDefaults((Panel.Builder)Convert.ChangeType(t, typeof(Panel.Builder)), ipName, fdName, fDto);
            else if (typeof(T) == typeof(Checkbox.Builder))
                t = (T)ApplyCheckboxDefaults((Checkbox.Builder)Convert.ChangeType(t, typeof(Checkbox.Builder)), ipName, fdName, fDto);
            else if (typeof(T) == typeof(DateField.Builder))
                t = (T)ApplyDateFieldDefaults((DateField.Builder)Convert.ChangeType(t, typeof(DateField.Builder)), ipName, fdName, fDto);
            else if (typeof(T) == typeof(TextArea.Builder))
                t = (T)ApplyTextAreaDefaults((TextArea.Builder)Convert.ChangeType(t, typeof(TextArea.Builder)), ipName, fdName, fDto);

            
            return t;
        }
        

        private T ApplyTextAreaDefaults(TextArea.Builder builder, string ipName, string fdName, VFieldDetailForUIDTO dto)
        {
            TextArea.Builder build = builder.LabelAlign(LabelAlign.Top)
                .MsgTarget(MessageTarget.Under)
                .FieldLabel(dto.OverrideFieldLabelValue)
                .AllowBlank(!dto.IsMandatory)
                .BlankText("Required")
                
                .Hidden(!dto.IsVisible);

            var tooltipstring = (dto.OverrideToolTipIsHTML.HasValue ? dto.OverrideToolTipIsHTML.Value : false) ? dto.OverrideToolTipHTML : dto.OverrideToolTipValue;

            if (!string.IsNullOrEmpty(tooltipstring))
                build = build.ToolTips(tp => tp.Add(CreateToolTip(tooltipstring)));

            builder.Tag("this is help " + fdName);

            return (T)Convert.ChangeType(build, typeof(T));
        }

        private T ApplyDateFieldDefaults(DateField.Builder builder, string ipName, string fdName, VFieldDetailForUIDTO dto)
        {
            DateField.Builder build = builder.LabelAlign(LabelAlign.Top)
                .MsgTarget(MessageTarget.Under)
                .FieldLabel(dto.OverrideFieldLabelValue)
                .AllowBlank(!dto.IsMandatory)
                .BlankText("Required")
                .Hidden(!dto.IsVisible);

            var tooltipstring = (dto.OverrideToolTipIsHTML.HasValue ? dto.OverrideToolTipIsHTML.Value : false) ? dto.OverrideToolTipHTML : dto.OverrideToolTipValue;

            if (!string.IsNullOrEmpty(tooltipstring))
                build = build.ToolTips(tp => tp.Add(CreateToolTip(tooltipstring)));

            builder.Tag("this is help " + fdName);

            return (T)Convert.ChangeType(build, typeof(T));
        }

        public Panel.Builder ApplyPanelDefaults(Panel.Builder builder, string ipName)
        {
            var resolver = DependencyResolver.Current as AutofacDependencyResolver;

            var fieldDetailsAndValidations = resolver.ApplicationContainer.Resolve<FieldDetailsAndValidationsContainerDTO>();

                VInterfacePanelForUIDTO dto = fieldDetailsAndValidations.GetInterfacePanelDetails(ipName);

            if (dto != null)
            {
                Ensure.Argument.NotNull(dto);

                Panel.Builder build = builder.Hidden(!dto.IsVisible)
                   .Cls("my-header")
                   .Title(dto.InterfacePanelLabel)
                   .AutoDataBind(true)
                   ;
                   
                return build;
            }

            return builder;
          
        }

        private T ApplyImageFieldDefaults(Image.Builder builder, string ipName, string fdName, VFieldDetailForUIDTO dto)
        {
            var resolver = DependencyResolver.Current as AutofacDependencyResolver;

            var commonSettings = resolver.ApplicationContainer.Resolve<CommonSettings>();
            
            if (!string.IsNullOrEmpty(dto.IconFileName))
            {
                Image.Builder build =
                    builder.ImageUrl(commonSettings.IconFilePath  + dto.IconFileName)
                    .Hidden(!dto.IsVisible)
                    .Resizable(false)
                    .Height(30)
                    .Width(20);
                return (T)Convert.ChangeType(build, typeof(T));
            }

            return (T)Convert.ChangeType(builder, typeof(T));            
        }

        private T ApplyTextFieldDefaults(TextField.Builder builder, string ipName, string fdName,VFieldDetailForUIDTO dto)
        {
            TextField.Builder build = builder.LabelAlign(LabelAlign.Top)
                .MsgTarget(MessageTarget.Under)
                .FieldLabel(dto.OverrideFieldLabelValue)
                .AllowBlank(!dto.IsMandatory)
                .BlankText("Required")
                .Hidden(!dto.IsVisible);

            var tooltipstring = (dto.OverrideToolTipIsHTML.HasValue ? dto.OverrideToolTipIsHTML.Value : false) ? dto.OverrideToolTipHTML : dto.OverrideToolTipValue;

            if (!string.IsNullOrEmpty(tooltipstring))
                build = build.ToolTips(tp => tp.Add(CreateToolTip(tooltipstring)));

            // executed, we only process the text field once
            //if(dto.OverrideHelpIsHTML.GetValueOrDefault(false))
            //    builder.Tag(dto.OverrideHelpHTML);
            //else
            //    builder.Tag(dto.OverrideHelpValue);
            //    

            builder.Tag("this is help " + fdName);

            return (T) Convert.ChangeType(build,typeof(T));
        }

        private T ApplyNumberFieldDefaults(NumberField.Builder builder, string ipName, string fdName, VFieldDetailForUIDTO dto)
        {
            NumberField.Builder build = builder.LabelAlign(LabelAlign.Top)
                .MsgTarget(MessageTarget.Under)
                .FieldLabel(dto.OverrideFieldLabelValue)
                .AllowBlank(!dto.IsMandatory)
                .BlankText("Required")
                .Hidden(!dto.IsVisible);

            var tooltipstring = (dto.OverrideToolTipIsHTML.HasValue ? dto.OverrideToolTipIsHTML.Value : false) ? dto.OverrideToolTipHTML : dto.OverrideToolTipValue;

            if (!string.IsNullOrEmpty(tooltipstring))
                build = build.ToolTips(tp => tp.Add(CreateToolTip(tooltipstring)));

            // executed, we only process the text field once
            //if(dto.OverrideHelpIsHTML.GetValueOrDefault(false))
            //    builder.Tag(dto.OverrideHelpHTML);
            //else
            //    builder.Tag(dto.OverrideHelpValue);
            //    

            builder.Tag("this is help " + fdName);

            return (T)Convert.ChangeType(build, typeof(T));
        }

        private T ApplyLabelFieldDefaults(Label.Builder builder, string ipName, string fdName, VFieldDetailForUIDTO dto)
        {
            Label.Builder build = builder
                .Hidden(!dto.IsVisible)
                .Text(dto.OverrideFieldLabelValue);

            var tooltipstring = (dto.OverrideToolTipIsHTML.HasValue ? dto.OverrideToolTipIsHTML.Value : false) ? dto.OverrideToolTipHTML : dto.OverrideToolTipValue;

            if (!string.IsNullOrEmpty(tooltipstring))
                build = build.ToolTips(tp => tp.Add(CreateToolTip(tooltipstring)));

            // executed, we only process the text field once
            builder.Tag(fdName + Guid.NewGuid());

            return (T)Convert.ChangeType(build, typeof(T));
        }

        private T ApplyComboBoxDefaults(ComboBox.Builder builder, string ipName, string fdName, VFieldDetailForUIDTO dto)
        {

            ComboBox.Builder build = builder.LabelAlign(LabelAlign.Top)
               .MsgTarget(MessageTarget.Under)
               .FieldLabel(dto.OverrideFieldLabelValue??"")
               .AllowBlank(!dto.IsMandatory)
               .BlankText("Required")
               .Hidden(!dto.IsVisible)
               .AutoDataBind(true)
               .QueryMode(DataLoadMode.Local)
               .TriggerAction(TriggerAction.All)
               .ForceSelection(true);

            var tooltipstring = (dto.OverrideToolTipIsHTML.HasValue ? dto.OverrideToolTipIsHTML.Value : false) ? dto.OverrideToolTipHTML : dto.OverrideToolTipValue;

            if (!string.IsNullOrEmpty(tooltipstring))
                build = build.ToolTips(tp => tp.Add(CreateToolTip(tooltipstring)));

            // executed, we only process the text field once
            builder.Tag(fdName + Guid.NewGuid());
            return (T)Convert.ChangeType(build, typeof(T));
        }

        private T ApplyFormPanelDefaults(FormPanel.Builder builder, string ipName, string fdName, VFieldDetailForUIDTO dto)
        {

            FormPanel.Builder build = builder.Hidden(!dto.IsVisible)
               .AutoDataBind(true);
               

            var tooltipstring = (dto.OverrideToolTipIsHTML.HasValue ? dto.OverrideToolTipIsHTML.Value : false) ? dto.OverrideToolTipHTML : dto.OverrideToolTipValue;

            if (!string.IsNullOrEmpty(tooltipstring))
                build = build.ToolTips(tp => tp.Add(CreateToolTip(tooltipstring)));

            // executed, we only process the text field once
            builder.Tag(fdName + Guid.NewGuid());
            return (T)Convert.ChangeType(build, typeof(T));
        }

        private T ApplyPanelDefaults(Panel.Builder builder, string ipName, string fdName, VFieldDetailForUIDTO dto)
        {

            Panel.Builder build = builder.Hidden(!dto.IsVisible)
               .Cls("my-header") 
               .Title(dto.OverrideFieldLabelValue)    
               .AutoDataBind(true);

            var tooltipstring = (dto.OverrideToolTipIsHTML.HasValue ? dto.OverrideToolTipIsHTML.Value : false) ? dto.OverrideToolTipHTML : dto.OverrideToolTipValue;

            if (!string.IsNullOrEmpty(tooltipstring))
                build = build.ToolTips(tp => tp.Add(CreateToolTip(tooltipstring)));

            // executed, we only process the text field once
            builder.Tag(fdName + Guid.NewGuid());
            return (T)Convert.ChangeType(build, typeof(T));
        }

        private T ApplyCheckboxDefaults(Checkbox.Builder builder, string ipName, string fdName, VFieldDetailForUIDTO dto)
        {

            Checkbox.Builder build = builder.Hidden(!dto.IsVisible)
               .FieldLabel("")
               .BoxLabel(dto.OverrideFieldLabelValue)
               .BoxLabelAlign(BoxLabelAlign.After)
               .MsgTarget(MessageTarget.Under)
               ;

            var tooltipstring = (dto.OverrideToolTipIsHTML.HasValue ? dto.OverrideToolTipIsHTML.Value : false) ? dto.OverrideToolTipHTML : dto.OverrideToolTipValue;

            if (!string.IsNullOrEmpty(tooltipstring))
                build = build.ToolTips(tp => tp.Add(CreateToolTip(tooltipstring)));

            // executed, we only process the text field once
            builder.Tag(fdName + Guid.NewGuid());
            return (T)Convert.ChangeType(build, typeof(T));
        }

        private T ApplyRadioGroupDefaults(RadioGroup.Builder builder, string ipName, string fdName, VFieldDetailForUIDTO dto)
        {

            RadioGroup.Builder build = builder
                .Hidden(!dto.IsVisible)
                .FieldLabel(dto.OverrideFieldLabelValue);

            var tooltipstring = (dto.OverrideToolTipIsHTML.HasValue ? dto.OverrideToolTipIsHTML.Value : false) ? dto.OverrideToolTipHTML : dto.OverrideToolTipValue;

            if (!string.IsNullOrEmpty(tooltipstring))
                build = build.ToolTips(tp => tp.Add(CreateToolTip(tooltipstring)));

            // executed, we only process the text field once
            builder.Tag(fdName + Guid.NewGuid());

            return (T)Convert.ChangeType(build, typeof(T));
        }
        private ToolTip CreateToolTip(string tooltipstring)
        {
            ToolTip tip = new ToolTip();
            tip.TrackMouse = true;
            tip.Html = tooltipstring;

            return tip;
        }
      
        
    }
}