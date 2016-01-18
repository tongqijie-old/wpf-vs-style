using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VsStyle.Views
{
    /// <summary>
    /// Interaction logic for SolutionExplorer.xaml
    /// </summary>
    public partial class SolutionExplorer : UserControl
    {
        public SolutionExplorer()
        {
            InitializeComponent();
        }

        private void TreeViewItemMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                var treeViewItem = (sender as FrameworkElement).Tag as Models.TreeViewItem;
                if (!treeViewItem.HasChildItems)
                {
                    if (treeViewItem.DoubleClicked != null)
                    {
                        treeViewItem.DoubleClicked(treeViewItem);
                    }
                }
            }
        }
    }
}
