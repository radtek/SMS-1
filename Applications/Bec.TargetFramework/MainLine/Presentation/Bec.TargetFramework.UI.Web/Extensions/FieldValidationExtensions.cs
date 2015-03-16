using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using Ensure = Fabrik.Common.Ensure;

namespace Bec.TargetFramework.UI.Web
{
    public static class FieldValidationExtensions
    {
        public static FormPanelResult ReturnFormPanelWithErrorsForInvalidModelState(this Controller controller)
        {
            var errors = new FieldErrors();

            foreach (var key in controller.ModelState.Keys)
            {
                if (!string.IsNullOrEmpty(key) && controller.ModelState[key].Errors.ToList().Count > 0)
                    errors.Add(new FieldError(key.ToString(),
                        controller.ModelState[key].Errors.Select(s => s.ErrorMessage).ToArray()));
            }

            return controller.FormPanel(controller.ModelState);
        }

        public static FormPanelResult PopulateFormErrors(this Controller controller,string formErrorsID, List<string> errors)
        {
            var multiSelect = controller.GetCmp<MultiSelect>(formErrorsID);

            Ensure.NotNull((multiSelect));

            multiSelect.ListTitle = "Errors";

            if (errors == null || errors.Count == 0)
                multiSelect.Hidden = true;
            else
            {
                multiSelect.Hidden = false;
                multiSelect.Cls = "errorMultiSelect";
                multiSelect.Border = false;
                multiSelect.ListConfig = new BoundList{DisableSelection = true};
                
                errors.ForEach(item =>
                {
                    ListItem li = new ListItem(item, item);

                    multiSelect.Items.Add(li);
                });

            }

            multiSelect.Update();

            return controller.FormPanel(controller.ModelState);
        }

        public static FormPanelResult PopulateFormMessages(this Controller controller, string formMessagesID, List<string> messages)
        {
            var multiSelect = controller.GetCmp<MultiSelect>(formMessagesID);

            Ensure.NotNull((multiSelect));

            multiSelect.ListTitle = "Messages";

            if (messages == null || messages.Count == 0)
                multiSelect.Hidden = true;
            else
            {
                multiSelect.Hidden = false;
                multiSelect.Cls = "messageMultiSelect";
                multiSelect.Border = false;
                multiSelect.ListConfig = new BoundList { DisableSelection = true };

                messages.ForEach(item =>
                {
                    ListItem li = new ListItem(item, item);

                    multiSelect.Items.Add(li);
                });

            }

            multiSelect.Update();

            return controller.FormPanel(controller.ModelState);
        }
    }
}