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

namespace VsStyle.Temporary
{
    /// <summary>
    /// Interaction logic for Apple.xaml
    /// </summary>
    public partial class Apple : UserControl
    {
        public Apple(string label)
        {
            Label = label;
            DataContext = this;

            InitializeComponent();
        }

        public string Label { get; set; }
    }
}
