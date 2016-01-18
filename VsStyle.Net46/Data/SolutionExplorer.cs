namespace VsStyle.Data
{
    using System.Collections.Generic;

    class SolutionExplorer
    {
        private static SolutionExplorer _Explorer = null;

        public static SolutionExplorer Explorer
        {
            get
            {
                if(_Explorer == null)
                {
                    _Explorer = new SolutionExplorer();

                    var node_0 = new Models.TreeViewItem(1, "/Assets/Images/icon.solution.dark.png", "Utility");
                    
                    var node_0_1 = new Models.TreeViewItem(2, "/Assets/Images/icon.properties.dark.png", "Editor", node_0)
                    {
                        DoubleClicked = (sender) =>
                        {
                            ContentManager.Manager.AppendTabItem(new Models.TabItem(sender.Id, sender.Label, new Contents.BlogEditor(Net46.MainWindow.MainFrame)));
                        },
                    };

                    _Explorer.RootNodes.Add(node_0);
                }
                return _Explorer;
            }
        }

        private System.Collections.ObjectModel.ObservableCollection<Models.TreeViewItem> _RootNodes = null;

        public IList<Models.TreeViewItem> RootNodes
        {
            get { return _RootNodes ?? (_RootNodes = new System.Collections.ObjectModel.ObservableCollection<Models.TreeViewItem>()); }
        }
    }
}
