using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using System;
using EnsureThat;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.UI.Web.Helpers;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.UI.Web.Controllers
{
    [AllowAnonymous]
    public class ReferenceController : Controller
    {
      
        public ReferenceController(IClassificationDataLogic logic,IDataLogic datalogic,IOrganisationLogic organisationlogic)
         
        {
            m_ClassificationDataLogic = logic;
            m_DataLogic = datalogic;
            m_OrganisationLogic = organisationlogic;
        }

        private IClassificationDataLogic m_ClassificationDataLogic;
        private IDataLogic m_DataLogic;
        private IOrganisationLogic m_OrganisationLogic;

        public ActionResult ReadData(StoreRequestParameters parameters, bool getAll = false, string name = null)
        
        {
            var list = m_ClassificationDataLogic.GetRootClassificationDataForTypeName(name);

            return this.Store(list, list.Count);
        }

        public ActionResult GetCountryList()
        {
            var list = m_ClassificationDataLogic.GetCountries();

            return this.Store(list, list.Count);
        }

        public ActionResult GetBranchStatus()
        {
            var list = m_DataLogic.GetStatusType(StatusTypeEnum.Branch.GetStringValue());    

           return this.Store(list, list.Count);
        }

        public ActionResult GetUserStatus()
        {
            var list = m_DataLogic.GetStatusType(StatusTypeEnum.UserOrganisation.GetStringValue());    

            return this.Store(list, list.Count);
        }

        public ActionResult GetFirmBranch()//to start with no parameter but lateron public ActionResult GetFirmBranch(Guid organisationId)
        {
            Guid organisationId = Guid.NewGuid();//remove this code lateron
           // Ensure.That(organisationId).IsNotNull();
            
            var list = m_OrganisationLogic.GetOrganisationBranches(organisationId);

            return this.Store(list, list.Count);
            
        }

        public StoreResult GetTreeStructure()
        {
            /*
            /// coding this just for test reasons.
            //WorkflowSessionHelper.CreateMockWorkflowState();
           // var state = WorkflowSessionHelper.GetWorkflowStateFromSession();
            //TemporaryAccountDTO tempdata = new TemporaryAccountDTO() { WorkflowID = Guid.Parse("65f20e50-334e-11e4-a213-a7824e493dd5"), WorkflowVersionNumber = 1, EmailAddress = "s.anumalsetty@beconsultancy.co.uk" };
            //WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<TemporaryAccountDTO>(WorkflowDataEnum.TemporaryAccountData.ToString(), tempdata);

            TreeStructureVisibilityDTO tsVisibilityData = new TreeStructureVisibilityDTO() { IAmCO = tempdata.IsColp, Editable = false, PaymentWithPreAuth = false };
          //Need to uncomment when the list object works with session   WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<TreeStructureVisibilityDTO>(WorkflowDataEnum.TreeStructureVisibilityData.ToString(), tsVisibilityData);

             //Guid.Parse("65f8766e-334e-11e4-860c-9f04d739c014"); //getting this from workflowsession for current actionid and reloading this for each workflowaction change
            /// coding this just for test reasons.
            ///
            mocking data finish*/
            Guid currentActionID = WorkflowSessionHelper.GetWorkflowStateFromSession().CurrentWorkflowComponentID;
            var sessionWorkflowTempAccountData = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<TemporaryAccountDTO>(WorkflowDataEnum.TemporaryAccountData.GetStringValue());
            TreeStructureVisibilityDTO tsVisibilityData = new TreeStructureVisibilityDTO() { IAmCO = sessionWorkflowTempAccountData.IsColp, Editable = false, PaymentWithPreAuth = false , IsPaymentSuccessful = sessionWorkflowTempAccountData.IsPaymentSuccessful};
            WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<TreeStructureVisibilityDTO>(WorkflowDataEnum.TreeStructureVisibilityData.ToString(), tsVisibilityData);

            var tree = m_DataLogic.GetWorkflowTree(sessionWorkflowTempAccountData.WorkflowID, sessionWorkflowTempAccountData.WorkflowVersionNumber);
            NodeCollection nodes = new NodeCollection();

            var rootTreeItem = tree.Single(s => s.ParentID == null && (s.IsVisible));
            var rootNode = new Node();
            rootNode.NodeID = rootTreeItem.WorkflowTreeStructureID.ToString();
            rootNode.Text = rootTreeItem.Name;
            rootNode.Cls = (rootTreeItem.WorkflowActionID == currentActionID ? "x-selectedtreenode" : "");
            tree.Where(s => s.ParentID != null && s.ParentID == rootTreeItem.WorkflowTreeStructureID && IsShow(s.ConditionString,s.IsVisible)).ToList().ForEach(item =>
                {
                    //Level1
                    Node node = new Node();
                    node.NodeID = item.WorkflowTreeStructureID.ToString();
                    node.Text = item.Name;
                    node.Cls = (item.WorkflowActionID == currentActionID ? "x-selectedtreenode" : "");
                    tree.Where(s => s.ParentID != null && s.ParentID == item.WorkflowTreeStructureID && IsShow(s.ConditionString,s.IsVisible)).ToList().ForEach(item1 =>
                        {
                            //Level2
                            Node node1 = new Node();
                            node1.NodeID = item1.WorkflowTreeStructureID.ToString();
                            node1.Text = item1.Name;
                            node1.Cls = (item1.WorkflowActionID == currentActionID ? "x-selectedtreenode" : "");
                            tree.Where(s => s.ParentID != null && s.ParentID == item1.WorkflowTreeStructureID && IsShow(s.ConditionString,s.IsVisible)).ToList().ForEach(item2 =>
                           
                                {
                                    //Level3
                                    Node node2 = new Node();
                                    node2.NodeID = item2.WorkflowTreeStructureID.ToString();
                                    node2.Text = item2.Name;
                                    node2.Leaf = true;
                                    node2.Cls = (item2.WorkflowActionID == currentActionID ? "x-selectedtreenode" : "");
                                    node1.Children.Add(node2);
                                });

                            if (node1.Children.Count > 0)
                                node1.Leaf = false;
                            else
                                node1.Leaf = true;
                            node.Children.Add(node1);
                        });
                    if (node.Children.Count > 0)
                        node.Leaf = false;
                    else
                        node.Leaf = true;
                    rootNode.Children.Add(node);
                });

            nodes.Add(rootNode);          

            return this.Store(nodes);

        }


        private bool IsShow(string condition, bool IsVisible)
        {         

           var tsvisibiltydata = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<TreeStructureVisibilityDTO>(WorkflowDataEnum.TreeStructureVisibilityData.GetStringValue());
            if (condition != null)
            {
                var conditiondic = condition.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(part => part.Split(':')).ToDictionary(split => split[0].ToLower(), split => split[1].ToLower());

                string iamcovalue = string.Empty;               
                string editablevalue = string.Empty;  
                //string paymentwithpreauthvalue = string.Empty;
                string ispaymentsuccessfulvalue = string.Empty;

                if (conditiondic.ContainsKey("iamco"))
                {
                    conditiondic.TryGetValue("iamco", out iamcovalue);
                }

                if (conditiondic.ContainsKey("editable"))
                {
                    conditiondic.TryGetValue("editable", out editablevalue);
                }

                if (conditiondic.ContainsKey("ispaymentsuccessful"))
                {
                    conditiondic.TryGetValue("ispaymentsuccessful", out ispaymentsuccessfulvalue);
                }

                //if (conditiondic.ContainsKey("paymentwithpreauth"))
                //{
                //    conditiondic.TryGetValue("paymentwithpreauth", out paymentwithpreauthvalue);
                //}

                
                bool show = iamcovalue == String.Empty?(editablevalue == String.Empty ?((ispaymentsuccessfulvalue == String.Empty) ? false: ispaymentsuccessfulvalue.ToLower() == tsvisibiltydata.IsPaymentSuccessful.ToString().ToLower()):editablevalue.ToLower() == tsvisibiltydata.Editable.ToString().ToLower() && ((ispaymentsuccessfulvalue == String.Empty) ? true : ispaymentsuccessfulvalue.ToLower() == tsvisibiltydata.IsPaymentSuccessful.ToString().ToLower()))
                                                     :(iamcovalue.ToLower() == tsvisibiltydata.IAmCO.ToString().ToLower() && 
                                                                                                    (editablevalue == String.Empty ?((ispaymentsuccessfulvalue == String.Empty) ? true: ispaymentsuccessfulvalue.ToLower() == tsvisibiltydata.IsPaymentSuccessful.ToString().ToLower())
                                                                                                    :editablevalue.ToLower() == tsvisibiltydata.Editable.ToString().ToLower() && ((ispaymentsuccessfulvalue == String.Empty) ? true : ispaymentsuccessfulvalue.ToLower() == tsvisibiltydata.IsPaymentSuccessful.ToString().ToLower())) );
               
                return show;
                
            }

            return IsVisible ;
        }
       
    }
}
