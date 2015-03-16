using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bec.TargetFramework.Entities;
using EnsureThat;
using ServiceStack.ServiceHost;
using Stimulsoft.Report.Events;
using System.Collections.Concurrent;
using Ext.Net;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;

namespace Bec.TargetFramework.UI.Web.Helpers
{
    public class WorkflowSessionHelper
    {
        private const string m_WorkflowStateSessionKey = "WorkflowState";

        public static Node GetWorkflowTree(IDataLogic logic,Guid workflowID,int versionNumber, string nodeToHighlight)
        {
            var tree = logic.GetWorkflowTree(workflowID,versionNumber);

            // create root node
            var rootNode= tree.Single(s => s.ParentID == null);

            Node node = new Node();
            node.NodeID = rootNode.WorkflowTreeStructureID.ToString();
            node.Text = rootNode.Name;
            


            // find next level
            tree.Where(s => s.ParentID != null && s.ParentID == rootNode.WorkflowTreeStructureID)
                .ToList()
                .ForEach(item =>
                {
                    Node node1 = new Node();
                    node1.NodeID = item.WorkflowTreeStructureID.ToString();
                    node1.Text = item.Name;
                    

                    if(tree.Any(s => s.ParentID != null && s.ParentID == item.WorkflowTreeStructureID))
                    {
                        tree.Where(s => s.ParentID != null && s.ParentID == item.WorkflowTreeStructureID)
                        .ToList()
                        .ForEach(item1 =>
                        {
                            Node node2 = new Node();
                            node2.NodeID = item1.WorkflowTreeStructureID.ToString();
                            node2.Text = item1.Name;
                           
                            if (tree.Any(s => s.ParentID != null && s.ParentID == item1.WorkflowTreeStructureID))
                            {
                                tree.Where(s => s.ParentID != null && s.ParentID == item1.WorkflowTreeStructureID)
                                .ToList()
                                .ForEach(item2 =>
                                {
                                    Node node3 = new Node();
                                    node3.NodeID = item2.WorkflowTreeStructureID.ToString();
                                    node3.Text = item2.Name;
                                 

                                    if (tree.Any(s => s.ParentID != null && s.ParentID == item2.WorkflowTreeStructureID))
                                    {
                                        tree.Where(s => s.ParentID != null && s.ParentID == item2.WorkflowTreeStructureID)
                                        .ToList()
                                        .ForEach(item3 =>
                                        {
                                            Node node4 = new Node();
                                            node4.NodeID = item3.WorkflowTreeStructureID.ToString();
                                            node4.Text = item3.Name;

                                            if (node4.Children == null || node4.Children.Count == 0)
                                                node4.Leaf = true;

                                            node3.Children.Add(node4);
                                        });
                                    }

                                    if (node3.Children == null || node3.Children.Count == 0)
                                        node3.Leaf = true;

                                    node2.Children.Add(node3);
                                });
                            }

                            if(node2.Children == null || node2.Children.Count == 0)
                                node2.Leaf = true;

                            node1.Children.Add(node2);


                        });
                    }

                    if(node1.Children == null || node1.Children.Count == 0)
                        node1.Leaf = true;

                    node.Children.Add(node1);
                });


            return node;

        }
        public static void CreateMockWorkflowState()
        {
            var dto = new WorkflowStateBaseDTO();

            dto.WorkflowDictionaryDto.WorkflowDictionary = new ConcurrentDictionary<string, object>();

            AddOrReplaceWorkflowStateToSession(dto);
        }
        public static bool DoesWorkflowStateExistInSession()
        {
            return (HttpContext.Current.Session[m_WorkflowStateSessionKey] != null);
        }

        public static void RemoveWorkflowStateFromSession()
        {
            if (HttpContext.Current.Session[m_WorkflowStateSessionKey] != null)
                HttpContext.Current.Session.Remove(m_WorkflowStateSessionKey);
        }

        public static void AddOrReplaceWorkflowStateToSession(WorkflowStateBaseDTO workflowStateDto)
        {
            // remove existing
            if(HttpContext.Current.Session[m_WorkflowStateSessionKey] != null)
                HttpContext.Current.Session.Remove(m_WorkflowStateSessionKey);

            HttpContext.Current.Session.Add(m_WorkflowStateSessionKey, workflowStateDto);
        }

        public static ConcurrentDictionary<string,object> GetWorkflowStateDataFromSession()
        {
            Ensure.That(HttpContext.Current.Session[m_WorkflowStateSessionKey]).IsNotNull();

            var state = HttpContext.Current.Session[m_WorkflowStateSessionKey] as WorkflowStateBaseDTO;

            return state.WorkflowDictionaryDto.WorkflowDictionary;
        }

        public static WorkflowStateBaseDTO GetWorkflowStateFromSession()
        {
            Ensure.That(HttpContext.Current.Session[m_WorkflowStateSessionKey]).IsNotNull();

            var state = HttpContext.Current.Session[m_WorkflowStateSessionKey] as WorkflowStateBaseDTO;

            return state;
        }
        public static T GetWorkflowStateDataItemFromSessionUsingKey<T>(string key) where T: class
        {
            Ensure.That(HttpContext.Current.Session[m_WorkflowStateSessionKey]).IsNotNull();

            var state = HttpContext.Current.Session[m_WorkflowStateSessionKey] as WorkflowStateBaseDTO;

            Ensure.That(state.WorkflowDictionaryDto.WorkflowDictionary.ContainsKey(key)).IsTrue();

            object value = null;

            if (!state.WorkflowDictionaryDto.WorkflowDictionary.TryGetValue(key, out value))
                throw new ArgumentException("Cannot get value:" + key  +  " from workflowstate in session");

            return value as T;
        }

        public static void AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<T>(string key,T data) where T : class
        {
            Ensure.That(HttpContext.Current.Session[m_WorkflowStateSessionKey]).IsNotNull();
            Ensure.That(key).IsNotNullOrEmpty();
            Ensure.That(data).IsNotNull();

            var state = HttpContext.Current.Session[m_WorkflowStateSessionKey] as WorkflowStateBaseDTO;

            object value = null;

            if (state.WorkflowDictionaryDto.WorkflowDictionary.ContainsKey(key))
                state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove(key, out value);

            state.WorkflowDictionaryDto.WorkflowDictionary.TryAdd(key, data);

            AddOrReplaceWorkflowStateToSession(state);
        }
    }
}