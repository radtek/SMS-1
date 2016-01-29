using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bec.TargetFramework.Presentation.Web.App_Helpers
{
    public class IntroItem
    {
        public int Id { get; set; }
        public string PageURL { get; set; }
        public string TextManage { get; set; }
        public string ShowMeHowText { get; set; }
        public int IntroOrer { get; set; }
        public bool IsActive { get; set; }
        public string ElementSelector { get; set; }
        public string Direction { get; set; }
        public string TabActiveId { get; set; }
    }
    public class IntroHelper
    {

        public ISMHLogicClient smhClient { get; set; }

        static List<IntroItem> IntroDB;
        //public static List<IntroItem> IntroDB2;
        public static bool IsFirstLogin = true;

        static IntroHelper()
        {
            IntroDB = new List<IntroItem> { 
            //new IntroItem{Id= 1, ElementId="btnAddBankAccount", PageId ="BankAccount/Account", IntroOrer=1, ShowMeHowText="Demo Text", TextManage="Button 'Add Bank Account'", IsActive=true, ElementSelector="div.col-sm-4", Direction="bottom"},
            //new IntroItem{Id= 2, ElementId="baGrid", PageId ="BankAccount/Account", IntroOrer=2, ShowMeHowText="List of Bank Accounts", TextManage="Grid Account", IsActive=true, ElementSelector="div#content>div:nth-child(2)>div>div:nth-child(1)>div", Direction="top"},
            //new IntroItem{Id= 3, ElementId="markFraudSuspiciousButton", PageId ="BankAccount/Account", IntroOrer=3, ShowMeHowText="Demo Text", TextManage="Button 'Mark as Fraud Suspicious'", IsActive=true, ElementSelector="div.k-grid-pager>a:nth-child(4)", Direction="right"},
            //new IntroItem{Id= 4, ElementId="confirmPotentialButton", PageId ="BankAccount/Account", IntroOrer=4, ShowMeHowText="Demo Text Demo Text", TextManage="Button 'Confirm Potential Fraud'", IsActive=true, ElementSelector="div.k-grid-pager>a:nth-child(5)", Direction="left"},

            new IntroItem{Id= 1, PageURL="SMH:/ProOrganisation/Users/Invited",  IntroOrer=1, ShowMeHowText="Demo Text", TextManage="Button 'Add Bank Account'", IsActive=true, ElementSelector="a.inline-heading", Direction="bottom", TabActiveId=""},
            new IntroItem{Id= 2,PageURL="SMH:/ProOrganisation/Users/Invited",  IntroOrer=2, ShowMeHowText="Click here", TextManage="Grid Account", IsActive=true, ElementSelector="ul#myTab1>li:nth-child(1)>a", Direction="top", TabActiveId=""},
            new IntroItem{Id= 3,PageURL="SMH:/ProOrganisation/Users/Invited",  IntroOrer=3, ShowMeHowText="List of Bank Accounts", TextManage="Grid Account", IsActive=true, ElementSelector="div#s1>div:nth-child(1)>div>div", Direction="top", TabActiveId="s1"},
            new IntroItem{Id= 4,PageURL="SMH:/ProOrganisation/Users/Invited",  IntroOrer=4, ShowMeHowText="Demo Text", TextManage="Button 'Mark as Fraud Suspicious'", IsActive=true, ElementSelector="a#revokeButton1", Direction="right", TabActiveId="s1"},
            new IntroItem{Id= 5,PageURL="SMH:/ProOrganisation/Users/Invited",  IntroOrer=5, ShowMeHowText="Click here", TextManage="Button 'Confirm Potential Fraud'", IsActive=true, ElementSelector="ul#myTab1>li:nth-child(2)>a", Direction="left", TabActiveId=""},
            new IntroItem{Id= 6,PageURL="SMH:/ProOrganisation/Users/Invited",  IntroOrer=6, ShowMeHowText="Demo Text Demo Text", TextManage="Button 'Confirm Potential Fraud'", IsActive=true, ElementSelector="div#s2>div:nth-child(1)>div>div", Direction="left", TabActiveId="s2"},
            new IntroItem{Id= 7,PageURL="SMH:/ProOrganisation/Users/Invited",  IntroOrer=7, ShowMeHowText="Demo Text Demo Text", TextManage="Button 'Confirm Potential Fraud'", IsActive=true, ElementSelector="a#reinstateButton", Direction="left", TabActiveId="s2"},
           
            new IntroItem{Id= 1,PageURL="", IntroOrer=1, ShowMeHowText="Demo Text", TextManage="Button 'Add Bank Account'", IsActive=true, ElementSelector="nav.margin-top-5>ul>li:nth-child(4)>a", Direction="right", TabActiveId=""},
            new IntroItem{Id= 2,PageURL="", IntroOrer=2, ShowMeHowText="List of Bank Accounts", TextManage="Grid Account", IsActive=true, ElementSelector="nav.margin-top-5>ul>li:nth-child(2)>a", Direction="right", TabActiveId=""},
            new IntroItem{Id= 3,PageURL="", IntroOrer=3, ShowMeHowText="Demo Text", TextManage="Button 'Mark as Fraud Suspicious'", IsActive=true, ElementSelector="nav.margin-top-5>ul>li:nth-child(1)>a", Direction="right", TabActiveId=""},
            new IntroItem{Id= 4,PageURL="", IntroOrer=4, ShowMeHowText="Demo Text<br/>Demo Text", TextManage="Button 'Confirm Potential Fraud'", IsActive=true, ElementSelector="nav.margin-top-5>ul>li:nth-child(3)>a", Direction="right", TabActiveId=""},

            new IntroItem{Id= 1,PageURL="SMH:/Admin/Messages", ElementSelector="div#conversationsContainer", IntroOrer=1, ShowMeHowText="All Conversations will be listed here", TextManage="Conversation List Title", IsActive=true, Direction="right", TabActiveId=""},
            new IntroItem{Id= 2,PageURL="SMH:/Admin/Messages", ElementSelector="ul.conversations-list>li>div:not(h4)",IntroOrer=2, ShowMeHowText="This will be displayed incase no conversation was made", TextManage="List Conversation Empty", IsActive=true, Direction="right", TabActiveId=""},
            new IntroItem{Id= 3,PageURL="SMH:/Admin/Messages", ElementSelector="li.conversation-item",IntroOrer=3, ShowMeHowText="The conversation was made with you", TextManage="Conversation Item", IsActive=true,  Direction="right", TabActiveId=""},
            new IntroItem{Id= 4,PageURL="SMH:/Admin/Messages", ElementSelector="h3#conversationSubject",IntroOrer=4, ShowMeHowText="The Subject of Conversation will be displayed here", TextManage="Button 'Confirm Potential Fraud'", IsActive=true, Direction="right", TabActiveId=""},
            new IntroItem{Id= 5,PageURL="SMH:/Admin/Messages", ElementSelector="div.margin-bottom-10>span:nth-child(2)",IntroOrer=5, ShowMeHowText="People in the conversation", TextManage="Button 'Confirm Potential Fraud'", IsActive=true, Direction="right", TabActiveId=""},
            new IntroItem{Id= 6,PageURL="SMH:/Admin/Messages", ElementSelector="div#itemsContainer>div>div:nth-child(1)",IntroOrer=6, ShowMeHowText="Detail content of each message in converstaion", TextManage="Button 'Confirm Potential Fraud'", IsActive=true, Direction="right", TabActiveId=""},
            new IntroItem{Id= 7,PageURL="SMH:/Admin/Messages", ElementSelector="textarea#replyMessageTextArea",IntroOrer=7, ShowMeHowText="You can input your message in here the click Send.", TextManage="Button 'Confirm Potential Fraud'", IsActive=true, Direction="right", TabActiveId=""},
            new IntroItem{Id= 8,PageURL="SMH:/Admin/Messages", ElementSelector="div#upload",IntroOrer=8, ShowMeHowText="Drag & Drop the file you want to attach to the converstaion.", TextManage="Button 'Confirm Potential Fraud'", IsActive=true, Direction="right", TabActiveId=""},
            
            };
        }

        public static string GetPageURL(string url)
        {
            return String.Format("SMH:{0}", url);
        }

        public static string GetSystemURL()
        {
            return GetPageURL(String.Empty);
        }

        public static List<IntroItem> GetSource(string url)
        {
            var list = IntroDB.FindAll(item => item.PageURL.ToLower().Equals(url.ToLower()));

            return list;
        }        
    }
}