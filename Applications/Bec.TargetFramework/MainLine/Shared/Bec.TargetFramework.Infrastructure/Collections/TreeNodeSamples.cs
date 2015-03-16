using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.Collections
{
    class SampleSearching
    {
        static void Main(string[] args)
        {
            TreeNode<string> treeRoot = SampleData.GetSet1();
            TreeNode<string> found = treeRoot.FindTreeNode(node => node.Data != null && node.Data.Contains("210"));

            Console.WriteLine("Found: " + found);
        }
    }

    class SampleIterating
    {
        static void MainTest(string[] args)
        {
            TreeNode<string> treeRoot = SampleData.GetSet1();
            foreach (TreeNode<string> node in treeRoot)
            {
                string indent = CreateIndent(node.Level);
                Console.WriteLine(indent + (node.Data ?? "null"));
            }
        }

        private static String CreateIndent(int depth)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < depth; i++)
            {
                sb.Append(' ');
            }
            return sb.ToString();
        }
    }

    class SampleData
    {
        public static TreeNode<string> GetSet1()
        {
            TreeNode<string> root = new TreeNode<string>("root");
            {
                TreeNode<string> node0 = root.AddChild("node0");
                TreeNode<string> node1 = root.AddChild("node1");
                TreeNode<string> node2 = root.AddChild("node2");
                {
                    TreeNode<string> node20 = node2.AddChild(null);
                    TreeNode<string> node21 = node2.AddChild("node21");
                    {
                        TreeNode<string> node210 = node21.AddChild("node210");
                        TreeNode<string> node211 = node21.AddChild("node211");
                    }
                }
                TreeNode<string> node3 = root.AddChild("node3");
                {
                    TreeNode<string> node30 = node3.AddChild("node30");
                }
            }

            return root;
        }
    }
}
