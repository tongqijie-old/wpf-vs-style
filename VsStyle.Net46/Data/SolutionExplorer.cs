namespace VsStyle.Data
{
    using System.Collections.Generic;

    public class SolutionExplorer
    {
        private static SolutionExplorer _Explorer = null;

        public static SolutionExplorer Explorer
        {
            get
            {
                if(_Explorer == null)
                {
                    _Explorer = new SolutionExplorer();

                    var rootNode = new Models.TreeNode(null)
                    {
                        Label = "Solution 'wpf-vs-style'(1 project)",
                        IsHideArrow = true,
                        ImageUri = "/Assets/Images/icon.solution.dark.png",
                    };
                    _Explorer.RootNodes.Add(rootNode);

                    var node1 = new Models.TreeNode(rootNode)
                    {
                        Label = "VsStyle.Net46",
                        ImageUri = "/Assets/Images/icon.project.dark.png",
                    };
                    rootNode.ChildNodes.Add(node1);

                    var node1_1 = new Models.TreeNode(node1)
                    {
                        Label = "Properties",
                        ImageUri = "/Assets/Images/icon.properties.dark.png",
                    };

                    var node1_2 = new Models.TreeNode(node1)
                    {
                        Label = "References",
                        ImageUri = "/Assets/Images/icon.references.dark.png",
                    };

                    var node1_3 = new Models.TreeNode(node1)
                    {
                        Label = "Assets",
                        ImageUri = "/Assets/Images/icon.folder.dark.png",
                    };

                    var node1_3_1 = new Models.TreeNode(node1_3)
                    {
                        Label = "Images",
                        ImageUri = "/Assets/Images/icon.folder.dark.png",
                    };

                    node1_3.ChildNodes.Add(node1_3_1);

                    var node1_4 = new Models.TreeNode(node1)
                    {
                        Label = "Converters",
                        ImageUri = "/Assets/Images/icon.folder.dark.png",
                    };

                    var node1_5 = new Models.TreeNode(node1)
                    {
                        Label = "Data",
                        ImageUri = "/Assets/Images/icon.folder.dark.png",
                    };

                    node1.ChildNodes.Add(node1_1);
                    node1.ChildNodes.Add(node1_2);
                    node1.ChildNodes.Add(node1_3);
                    node1.ChildNodes.Add(node1_4);
                    node1.ChildNodes.Add(node1_5);
                }
                return _Explorer;
            }
        }

        private System.Collections.ObjectModel.ObservableCollection<Models.TreeNode> _RootNodes = null;

        public IList<Models.TreeNode> RootNodes
        {
            get { return _RootNodes ?? (_RootNodes = new System.Collections.ObjectModel.ObservableCollection<Models.TreeNode>()); }
        }
    }
}
