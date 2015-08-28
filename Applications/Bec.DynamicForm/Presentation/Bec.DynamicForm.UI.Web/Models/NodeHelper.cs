using Bec.DynamicForm.Entities.DTO;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.DynamicForm.UI.Web.DTO
{
    public class NodeHelper
    {
        public static Node CreateNodeWithOutChildren(FormSectionDTO nodeModel,bool IsNodeHasChilds)
        {
            Node treeNode;

            if (nodeModel!=null)
            {
                treeNode = new Node();
            }
            else
            {
                treeNode = new Ext.Net.Node();               
            }

            treeNode.Leaf =!IsNodeHasChilds;
            treeNode.NodeID = "nds"+nodeModel.FormSectionId.ToString();
            treeNode.Text = nodeModel.SectionName;
            treeNode.Qtip = nodeModel.SectionDescription;
            treeNode.Icon = Icon.Folder;
            treeNode.AttributesObject = new { Name=nodeModel.SectionName };
          
            return treeNode;
        }
        public static Node CreateNodeWitChildren(QuestionDTO nodeModel)
        {
            Node treeNode;

            if (nodeModel != null)
            {
                treeNode = new Node();
            }
            else
            {
                treeNode = new Ext.Net.Node();
            }

            treeNode.Leaf = true;
            treeNode.NodeID = "ndq" + nodeModel.QuestionId.ToString();
            treeNode.Text = nodeModel.Description;
            treeNode.Qtip = nodeModel.HelpText;
            treeNode.Icon = Icon.Film;
            treeNode.AttributesObject = new { Name = nodeModel.Description };

            return treeNode;
        }
    }
}