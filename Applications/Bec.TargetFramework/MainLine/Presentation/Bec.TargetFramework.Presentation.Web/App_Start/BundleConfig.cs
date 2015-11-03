using System.Web;
using System.Web.Optimization;

namespace Bec.TargetFramework.Presentation.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/bs").Include(
                "~/content/css/bootstrap.min.css",
                "~/content/css/font-awesome.min.css",
                "~/content/css/smartadmin-production-plugins.min.css"                
                ));

            bundles.Add(new StyleBundle("~/content/smartadmin").Include(
                "~/content/css/smartadmin-production.min.css",
                "~/content/css/smartadmin-skins.min.css",
                "~/content/css/smartadmin-rtl.min.css",
                "~/content/css/your_style.min.css",
                "~/content/site.css"
                ));

            bundles.Add(new StyleBundle("~/content/websitelayout/css/style").Include(
                "~/content/bootstrap.css",
                "~/content/websitelayout/css/style.css",
                "~/content/css/font-awesome.min.css"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/smartadmin").Include(
                "~/Scripts/app.config.js",
                "~/Scripts/plugin/jquery-touch/jquery.ui.touch-punch.min.js",
                "~/Scripts/bootstrap/bootstrap.min.js",
                "~/Scripts/notification/SmartNotification.min.js",
                "~/Scripts/smartwidgets/jarvis.widget.min.js",
                "~/Scripts/plugin/jquery-validate/jquery.validate.min.js",
                "~/Scripts/plugin/masked-input/jquery.maskedinput.min.js",
                "~/Scripts/plugin/select2/select2.min.js",
                "~/Scripts/plugin/bootstrap-slider/bootstrap-slider.min.js",
                "~/Scripts/plugin/bootstrap-progressbar/bootstrap-progressbar.min.js",
                "~/Scripts/plugin/msie-fix/jquery.mb.browser.min.js",
                "~/Scripts/plugin/fastclick/fastclick.min.js",
                "~/Scripts/plugin/moment/moment.min.js",
                "~/Scripts/app.min.js",
                "~/Scripts/Libs/handlebars-v3.0.3.js",
                "~/Scripts/Libs/handlebars-helper-x.js",
                "~/Scripts/Libs/lodash.js",
                "~/Scripts/Libs/jquery.bootstrap.wizard.js",
                "~/Scripts/Libs/accounting.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/websitelayout").Include(
                "~/Scripts/Libs/lodash.js",
                "~/Scripts/bootstrap/bootstrap.min.js",
                "~/Scripts/plugin/jquery-validate/jquery.validate.min.js",

                //"~/Scripts/jquery.unobtrusive-ajax.min.js",
                //"~/Scripts/kendo/kendo.core.min.js",
                //"~/Scripts/kendo/kendo.data.min.js",
                //"~/Scripts/kendo/kendo.data.odata.min.js",
                //"~/Scripts/kendo/kendo.columnsorter.min.js",
                //"~/Scripts/kendo/kendo.pager.min.js",
                //"~/Scripts/kendo/kendo.userevents.min.js",
                //"~/Scripts/kendo/kendo.selectable.min.js",
                //"~/Scripts/kendo/kendo.grid.min.js",
                //"~/Scripts/kendo/kendo.aspnetmvc.min.js",

                //"~/Scripts/plugin/jquery-touch/jquery.ui.touch-punch.min.js",

                //"~/Scripts/app.config.js",
                //"~/Scripts/plugin/jquery-touch/jquery.ui.touch-punch.min.js",
                //"~/Scripts/notification/SmartNotification.min.js",
                //"~/Scripts/smartwidgets/jarvis.widget.min.js",
                //"~/Scripts/plugin/jquery-validate/jquery.validate.min.js",
                //"~/Scripts/plugin/masked-input/jquery.maskedinput.min.js",
                //"~/Scripts/plugin/select2/select2.min.js",
                //"~/Scripts/plugin/bootstrap-slider/bootstrap-slider.min.js",
                //"~/Scripts/plugin/bootstrap-progressbar/bootstrap-progressbar.min.js",
                //"~/Scripts/plugin/msie-fix/jquery.mb.browser.min.js",
                //"~/Scripts/plugin/fastclick/fastclick.min.js",
                //"~/Scripts/plugin/moment/moment.min.js",

                //"~/Scripts/app.min.js",

                "~/Scripts/site.js",
                "~/Scripts/Libs/handlebars-v3.0.3.js",
                "~/Scripts/Libs/handlebars-helper-x.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/full-calendar").Include(
                "~/Scripts/plugin/moment/moment.min.js",
                "~/Scripts/plugin/fullcalendar/jquery.fullcalendar.min.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/charts").Include(
                "~/Scripts/plugin/easy-pie-chart/jquery.easy-pie-chart.min.js",
                "~/Scripts/plugin/sparkline/jquery.sparkline.min.js",
                "~/Scripts/plugin/morris/morris.min.js",
                "~/Scripts/plugin/morris/raphael.min.js",
                "~/Scripts/plugin/flot/jquery.flot.cust.min.js",
                "~/Scripts/plugin/flot/jquery.flot.resize.min.js",
                "~/Scripts/plugin/flot/jquery.flot.time.min.js",
                "~/Scripts/plugin/flot/jquery.flot.fillbetween.min.js",
                "~/Scripts/plugin/flot/jquery.flot.orderBar.min.js",
                "~/Scripts/plugin/flot/jquery.flot.pie.min.js",
                "~/Scripts/plugin/flot/jquery.flot.tooltip.min.js",
                "~/Scripts/plugin/dygraphs/dygraph-combined.min.js",
                "~/Scripts/plugin/chartjs/chart.min.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/datatables").Include(
                "~/Scripts/plugin/datatables/jquery.dataTables.min.js",
                "~/Scripts/plugin/datatables/dataTables.colVis.min.js",
                "~/Scripts/plugin/datatables/dataTables.tableTools.min.js",
                "~/Scripts/plugin/datatables/dataTables.bootstrap.min.js",
                "~/Scripts/plugin/datatable-responsive/datatables.responsive.min.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/jq-grid").Include(
                "~/Scripts/plugin/jqgrid/jquery.jqGrid.min.js",
                "~/Scripts/plugin/jqgrid/grid.locale-en.min.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/forms").Include(
                "~/Scripts/plugin/jquery-form/jquery-form.min.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/smart-chat").Include(
                "~/Scripts/smart-chat-ui/smart.chat.ui.min.js",
                "~/Scripts/smart-chat-ui/smart.chat.manager.min.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/vector-map").Include(
                "~/Scripts/plugin/vectormap/jquery-jvectormap-1.2.2.min.js",
                "~/Scripts/plugin/vectormap/jquery-jvectormap-world-mill-en.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/site").Include(
                "~/Scripts/admin.js",
                "~/Scripts/site.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/kendo/kendo.core.min.js",
                "~/Scripts/kendo/kendo.data.min.js",
                "~/Scripts/kendo/kendo.data.odata.min.js",
                "~/Scripts/kendo/kendo.columnsorter.min.js",
                "~/Scripts/kendo/kendo.pager.min.js",
                "~/Scripts/kendo/kendo.userevents.min.js",
                "~/Scripts/kendo/kendo.selectable.min.js",
                "~/Scripts/kendo/kendo.grid.min.js",
                "~/Scripts/kendo/kendo.aspnetmvc.min.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/Account/AcceptTCs/Index").Include("~/Areas/Account/Views/AcceptTCs/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/PersonalDetails/Index").Include("~/Areas/Account/Views/PersonalDetails/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/PersonalDetails/AddMobileNumber").Include("~/Areas/Account/Views/PersonalDetails/AddMobileNumber.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/Login/Index").Include("~/Areas/Account/Views/Login/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/Forgot/Password").Include("~/Areas/Account/Views/Forgot/Password.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/Forgot/Reset").Include("~/Areas/Account/Views/Forgot/Reset.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/Forgot/Username").Include("~/Areas/Account/Views/Forgot/Username.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/Register/Index").Include("~/Areas/Account/Views/Register/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/RegisterAdmin/Index").Include("~/Areas/Account/Views/RegisterAdmin/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/Search/Index").Include("~/Areas/Account/Views/Search/Index.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Admin/Company/Provisional").Include("~/Areas/Admin/Views/Company/Provisional.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Company/Qualified").Include("~/Areas/Admin/Views/Company/Qualified.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Finance/_AmendCredit").Include("~/Areas/Admin/Views/Finance/_AmendCredit.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Finance/CreditHistory").Include("~/Areas/Admin/Views/Finance/CreditHistory.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Finance/OutstandingBankAccounts").Include("~/Areas/Admin/Views/Finance/OutstandingBankAccounts.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/InternalNotifications/Index").Include("~/Areas/Admin/Views/InternalNotifications/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Reporting/Index").Include("~/Areas/Admin/Views/Reporting/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Shared/_AddTempCompany").Include("~/Areas/Admin/Views/Shared/_AddTempCompany.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Shared/_EditCompany").Include("~/Areas/Admin/Views/Shared/_EditCompany.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Shared/_EmailLog").Include("~/Areas/Admin/Views/Shared/_EmailLog.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Shared/_GeneratePin").Include("~/Areas/Admin/Views/Shared/_GeneratePin.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Shared/_Verify").Include("~/Areas/Admin/Views/Shared/_Verify.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Shared/_RejectTempCompany").Include("~/Areas/Admin/Views/Shared/_RejectTempCompany.js"));

            bundles.Add(new ScriptBundle("~/Scripts/BankAccount/Account/Index").Include("~/Areas/BankAccount/Views/Account/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/BankAccount/Check/Index").Include("~/Areas/BankAccount/Views/Check/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/BankAccount/Shared/_AddBankAccount").Include("~/Areas/BankAccount/Views/Shared/_AddBankAccount.js"));

            bundles.Add(new ScriptBundle("~/Scripts/ProOrganisation/Credit/_TopUpCredit").Include("~/Areas/ProOrganisation/Views/Credit/_TopUpCredit.js"));
            bundles.Add(new ScriptBundle("~/Scripts/ProOrganisation/Products/_AddSmsTransaction").Include("~/Areas/ProOrganisation/Views/Products/_AddSmsTransaction.js"));
            bundles.Add(new ScriptBundle("~/Scripts/ProOrganisation/Products/Index").Include("~/Areas/ProOrganisation/Views/Products/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/ProOrganisation/Shared/_AddUser").Include("~/Areas/ProOrganisation/Views/Shared/_AddUser.js"));
            bundles.Add(new ScriptBundle("~/Scripts/ProOrganisation/Shared/_EditUser").Include("~/Areas/ProOrganisation/Views/Shared/_EditUser.js"));
            bundles.Add(new ScriptBundle("~/Scripts/ProOrganisation/Shared/_Reinstate").Include("~/Areas/ProOrganisation/Views/Shared/_Reinstate.js"));
            bundles.Add(new ScriptBundle("~/Scripts/ProOrganisation/Shared/_RevokeInvite").Include("~/Areas/ProOrganisation/Views/Shared/_RevokeInvite.js"));
            bundles.Add(new ScriptBundle("~/Scripts/ProOrganisation/Users/Invited").Include("~/Areas/ProOrganisation/Views/Users/Invited.js"));
            bundles.Add(new ScriptBundle("~/Scripts/ProOrganisation/Users/Registered").Include("~/Areas/ProOrganisation/Views/Users/Registered.js"));

            bundles.Add(new ScriptBundle("~/Scripts/SmsTransaction/AdditionalBuyer/_AddAdditionalBuyer").Include("~/Areas/SmsTransaction/Views/AdditionalBuyer/_AddAdditionalBuyer.js"));
            bundles.Add(new ScriptBundle("~/Scripts/SmsTransaction/Giftor/_AddGiftor").Include("~/Areas/SmsTransaction/Views/Giftor/_AddGiftor.js"));
            bundles.Add(new ScriptBundle("~/Scripts/SmsTransaction/Shared/_EditSmsTransaction").Include("~/Areas/SmsTransaction/Views/Shared/_EditSmsTransaction.js"));
            bundles.Add(new ScriptBundle("~/Scripts/SmsTransaction/Shared/_Purchase").Include("~/Areas/SmsTransaction/Views/Shared/_Purchase.js"));
            bundles.Add(new ScriptBundle("~/Scripts/SmsTransaction/Shared/_ViewGeneratePIN").Include("~/Areas/SmsTransaction/Views/Shared/_ViewGeneratePIN.js"));
            bundles.Add(new ScriptBundle("~/Scripts/SmsTransaction/Transaction/Index").Include("~/Areas/SmsTransaction/Views/Transaction/Index.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Buyer/SafeBuyer/Index").Include("~/Areas/Buyer/Views/SafeBuyer/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Buyer/SafeBuyer/_ConfirmDetails").Include("~/Areas/Buyer/Views/SafeBuyer/_ConfirmDetails.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Buyer/SafeBuyer/_CheckBankAccount").Include("~/Areas/Buyer/Views/SafeBuyer/_CheckBankAccount.js"));
            

            bundles.Add(new ScriptBundle("~/Scripts/Shared/_AddStatus").Include("~/Views/Shared/_AddStatus.js"));

            bundles.Add(new ScriptBundle("~/Scripts/daterange").Include("~/Scripts/Bec/bec.daterange.js"));
            bundles.Add(new ScriptBundle("~/Scripts/typeahead").Include("~/Scripts/typeahead.bundle.min.js"));            

            BundleTable.EnableOptimizations = true;
        }
    }
}
