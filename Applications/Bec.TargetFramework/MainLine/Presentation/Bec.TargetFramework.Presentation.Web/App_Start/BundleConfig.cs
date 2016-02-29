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
                "~/content/css/toastr.min.css",
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

            bundles.Add(new ScriptBundle("~/bundles/scripts/smartadmin").Include(
                "~/Scripts/app.config.js",
                "~/Scripts/plugin/jquery-touch/jquery.ui.touch-punch.min.js",
                "~/Scripts/bootstrap/bootstrap.min.js",
                "~/Scripts/notification/SmartNotification.min.js",
                "~/Scripts/smartwidgets/jarvis.widget.min.js",
                "~/Scripts/plugin/jquery-validate/jquery.validate.min.js",
                "~/Scripts/plugin/select2/select2.min.js",
                "~/Scripts/plugin/bootstrap-slider/bootstrap-slider.min.js",
                "~/Scripts/plugin/bootstrap-progressbar/bootstrap-progressbar.min.js",
                "~/Scripts/plugin/msie-fix/jquery.mb.browser.min.js",
                "~/Scripts/plugin/fastclick/fastclick.min.js",
                "~/Scripts/plugin/moment/moment.min.js",
                "~/Scripts/app.js",
                "~/Scripts/Libs/handlebars-v4.0.5.js",
                "~/Scripts/Libs/handlebars-helper-x.js",
                "~/Scripts/Libs/lodash.js",
                "~/Scripts/Libs/jquery.bootstrap.wizard.js",
                "~/Scripts/Libs/accounting.js",
                "~/Scripts/Libs/toastr.min.js",
                "~/Scripts/Libs/jquery.scrollTo.js",
                "~/Scripts/Libs/toastr.min.js",
                "~/Scripts/Bec/bec.jquery.validate.rules.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/scripts/websitelayout").Include(
                "~/Scripts/Libs/lodash.js",
                "~/Scripts/bootstrap/bootstrap.min.js",
                "~/Scripts/plugin/jquery-validate/jquery.validate.min.js",
                "~/Scripts/site.js",
                "~/Scripts/Libs/handlebars-v4.0.5.js",
                "~/Scripts/Libs/handlebars-helper-x.js",
                "~/Scripts/Bec/bec.jquery.validate.rules.js"
                ));

          
            bundles.Add(new ScriptBundle("~/bundles/scripts/site").Include(
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
                "~/Scripts/kendo/kendo.aspnetmvc.min.js",
                "~/Scripts/dropzone/dropzone.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/Account/AcceptTCs/Index").Include("~/Areas/Account/Views/AcceptTCs/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/PersonalDetails/Index").Include("~/Areas/Account/Views/PersonalDetails/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/PersonalDetails/AddMobileNumber").Include("~/Areas/Account/Views/PersonalDetails/AddMobileNumber.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/Login/Index").Include("~/Areas/Account/Views/Login/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/Forgot/Password").Include("~/Areas/Account/Views/Forgot/Password.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/Forgot/Reset").Include("~/Areas/Account/Views/Forgot/Reset.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/Forgot/Username").Include("~/Areas/Account/Views/Forgot/Username.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/Register/Index").Include("~/Areas/Account/Views/Register/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/RegisterAdmin/Conveyancer").Include("~/Areas/Account/Views/RegisterAdmin/Conveyancer.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/RegisterAdmin/MortgageBroker").Include("~/Areas/Account/Views/RegisterAdmin/MortgageBroker.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/Search/Index").Include("~/Areas/Account/Views/Search/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Account/MyAccount/ChangePassword").Include("~/Areas/Account/Views/MyAccount/ChangePassword.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Admin/Company/Provisional").Include("~/Areas/Admin/Views/Company/Provisional.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Company/Qualified").Include("~/Areas/Admin/Views/Company/Qualified.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Finance/OutstandingBankAccounts").Include("~/Areas/Admin/Views/Finance/OutstandingBankAccounts.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Messages/Index").Include("~/Areas/Admin/Views/Messages/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Messages/_Conversations").Include("~/Areas/Admin/Views/Messages/_Conversations.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/MessagesNotifications/_LatestConversationsContainer").Include("~/Areas/Admin/Views/MessagesNotifications/_LatestConversationsContainer.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/NewsArticle/Index").Include("~/Areas/Admin/Views/NewsArticle/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/NewsArticle/_AddNewsArticle").Include("~/Areas/Admin/Views/NewsArticle/_AddNewsArticle.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/NewsArticle/_EditNewsArticle").Include("~/Areas/Admin/Views/NewsArticle/_EditNewsArticle.js"));
            
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Reporting/Transactions").Include("~/Areas/Admin/Views/Reporting/Transactions.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Reporting/Firms").Include("~/Areas/Admin/Views/Reporting/Firms.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Reporting/Users").Include("~/Areas/Admin/Views/Reporting/Users.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Shared/_AddTempCompany").Include("~/Areas/Admin/Views/Shared/_AddTempCompany.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Shared/_GeneratePin").Include("~/Areas/Admin/Views/Shared/_GeneratePin.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Shared/_Verify").Include("~/Areas/Admin/Views/Shared/_Verify.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Shared/_RejectTempCompany").Include("~/Areas/Admin/Views/Shared/_RejectTempCompany.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Shared/_AddNotes").Include("~/Areas/Admin/Views/Shared/_AddNotes.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Shared/_RegisterLender").Include("~/Areas/Admin/Views/Shared/_RegisterLender.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Admin/Shared/_Unverify").Include("~/Areas/Admin/Views/Shared/_Unverify.js"));

            bundles.Add(new ScriptBundle("~/Scripts/BankAccount/Account/Index").Include("~/Areas/BankAccount/Views/Account/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/BankAccount/Check/Index").Include("~/Areas/BankAccount/Views/Check/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/BankAccount/Shared/_AddBankAccount").Include("~/Areas/BankAccount/Views/Shared/_AddBankAccount.js"));

            bundles.Add(new ScriptBundle("~/Scripts/ProOrganisation/Products/Index").Include("~/Areas/ProOrganisation/Views/Products/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/ProOrganisation/Shared/_AddUser").Include("~/Areas/ProOrganisation/Views/Shared/_AddUser.js"));
            bundles.Add(new ScriptBundle("~/Scripts/ProOrganisation/Shared/_EditUser").Include("~/Areas/ProOrganisation/Views/Shared/_EditUser.js"));
            bundles.Add(new ScriptBundle("~/Scripts/ProOrganisation/Shared/_Reinstate").Include("~/Areas/ProOrganisation/Views/Shared/_Reinstate.js"));
            bundles.Add(new ScriptBundle("~/Scripts/ProOrganisation/Shared/_RevokeInvite").Include("~/Areas/ProOrganisation/Views/Shared/_RevokeInvite.js"));
            bundles.Add(new ScriptBundle("~/Scripts/ProOrganisation/Users/Invited").Include("~/Areas/ProOrganisation/Views/Users/Invited.js"));
            bundles.Add(new ScriptBundle("~/Scripts/ProOrganisation/Users/Registered").Include("~/Areas/ProOrganisation/Views/Users/Registered.js"));

            bundles.Add(new ScriptBundle("~/Scripts/SmsTransaction/AdditionalBuyer/_AddAdditionalBuyer").Include("~/Areas/SmsTransaction/Views/AdditionalBuyer/_AddAdditionalBuyer.js"));
            bundles.Add(new ScriptBundle("~/Scripts/SmsTransaction/Giftor/_AddGiftor").Include("~/Areas/SmsTransaction/Views/Giftor/_AddGiftor.js"));
            bundles.Add(new ScriptBundle("~/Scripts/SmsTransaction/Transaction/_AddSmsTransaction").Include("~/Areas/SmsTransaction/Views/Transaction/_AddSmsTransaction.js"));
            bundles.Add(new ScriptBundle("~/Scripts/SmsTransaction/Transaction/_AdviseProduct").Include("~/Areas/SmsTransaction/Views/Transaction/_AdviseProduct.js"));
            bundles.Add(new ScriptBundle("~/Scripts/SmsTransaction/Shared/_EditSmsTransaction").Include("~/Areas/SmsTransaction/Views/Shared/_EditSmsTransaction.js"));
            bundles.Add(new ScriptBundle("~/Scripts/SmsTransaction/Shared/_ViewGeneratePIN").Include("~/Areas/SmsTransaction/Views/Shared/_ViewGeneratePIN.js"));
            bundles.Add(new ScriptBundle("~/Scripts/SmsTransaction/Transaction/Index").Include("~/Areas/SmsTransaction/Views/Transaction/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/SmsTransaction/Shared/_ViewSendQuote").Include("~/Areas/SmsTransaction/Views/Shared/_ViewSendQuote.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Buyer/SafeBuyer/Index").Include("~/Areas/Buyer/Views/SafeBuyer/Index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Buyer/SafeBuyer/IndexSelectTransaction").Include("~/Areas/Buyer/Views/SafeBuyer/IndexSelectTransaction.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Buyer/SafeBuyer/_ConfirmDetails").Include("~/Areas/Buyer/Views/SafeBuyer/_ConfirmDetails.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Buyer/SafeBuyer/_CheckBankAccount").Include("~/Areas/Buyer/Views/SafeBuyer/_CheckBankAccount.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Buyer/SafeBuyer/_NoMatch").Include("~/Areas/Buyer/Views/SafeBuyer/_NoMatch.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Buyer/SafeBuyer/_Match").Include("~/Areas/Buyer/Views/SafeBuyer/_Match.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Buyer/SafeBuyer/_PurchaseProduct").Include("~/Areas/Buyer/Views/SafeBuyer/_PurchaseProduct.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Buyer/SafeBuyer/_DeclineProduct").Include("~/Areas/Buyer/Views/SafeBuyer/_DeclineProduct.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Shared/_AddStatus").Include("~/Views/Shared/_AddStatus.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Shared/_Toastr").Include("~/Views/Shared/_Toastr.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Shared/_PostcodeLookup").Include("~/Views/Shared/_PostcodeLookup.js"));

            bundles.Add(new ScriptBundle("~/Scripts/daterange").Include("~/Scripts/Bec/bec.daterange.js"));
            bundles.Add(new ScriptBundle("~/Scripts/typeahead").Include("~/Scripts/typeahead.bundle.js"));
            bundles.Add(new ScriptBundle("~/Scripts/lendersearch").Include("~/Scripts/Bec/bec.lendersearch.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Lender/Transaction/Index").Include("~/Areas/Lender/Views/Transaction/Index.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
