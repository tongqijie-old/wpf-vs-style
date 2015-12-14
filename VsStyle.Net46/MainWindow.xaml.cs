using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VsStyle.Net46
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

    private void WindowBorderDragDelta(object sender, DragDeltaEventArgs e)
    {
        var source = e.Source as System.Windows.Controls.Primitives.Thumb;
        if (source == null) { return; }

        var row = Grid.GetRow(source.Parent as UIElement);
        var column = Grid.GetColumn(source.Parent as UIElement);

        if (row == 0 && column == 0)
        {
            // Left Top 
            if (this.Width - e.HorizontalChange < this.MinWidth)
            {
                this.Width = this.MinWidth;
                this.Left += this.Width - this.MinWidth;
            }
            else
            {
                this.Width -= e.HorizontalChange;
                this.Left += e.HorizontalChange;
            }

            if (this.Height - e.VerticalChange < this.MinHeight)
            {
                this.Height = this.MinHeight;
                this.Top += this.Height - this.MinHeight;
            }
            else
            {
                this.Height -= e.VerticalChange;
                this.Top += e.VerticalChange;
            }
        }
        else if(row == 0 && column == 1)
        {
            // Top
            if (this.Height - e.VerticalChange < this.MinHeight)
            {
                this.Height = this.MinHeight;
                this.Top += this.Height - this.MinHeight;
            }
            else
            {
                this.Height -= e.VerticalChange;
                this.Top += e.VerticalChange;
            }
        }
        else if(row == 0 && column == 2)
        {
            // Top Right
            if (this.Height - e.VerticalChange < this.MinHeight)
            {
                this.Height = this.MinHeight;
                this.Top += this.Height - this.MinHeight;
            }
            else
            {
                this.Height -= e.VerticalChange;
                this.Top += e.VerticalChange;
            }

            if (this.Width + e.HorizontalChange < this.MinWidth)
            {
                this.Width = this.MinWidth;
            }
            else
            {
                this.Width += e.HorizontalChange;
            }
        }
        else if(row == 1 && column == 0)
        {
            // Left
            if (this.Width - e.HorizontalChange < this.MinWidth)
            {
                this.Width = this.MinWidth;
                this.Left += this.Width - this.MinWidth;
            }
            else
            {
                this.Width -= e.HorizontalChange;
                this.Left += e.HorizontalChange;
            }
        }
        else if(row == 1 && column == 2)
        {
            // Right
            if (this.Width + e.HorizontalChange < this.MinWidth)
            {
                this.Width = this.MinWidth;
            }
            else
            {
                this.Width += e.HorizontalChange;
            }
        }
        else if(row == 2 && column == 0)
        {
            // Left Bottom
            if (this.Width - e.HorizontalChange < this.MinWidth)
            {
                this.Width = this.MinWidth;
                this.Left += this.Width - this.MinWidth;
            }
            else
            {
                this.Width -= e.HorizontalChange;
                this.Left += e.HorizontalChange;
            }

            if (this.Height + e.VerticalChange < this.MinHeight)
            {
                this.Height = this.MinHeight;
            }
            else
            {
                this.Height += e.VerticalChange;
            }
        }
        else if(row == 2 && column == 1)
        {
            // Bottom
            if (this.Height + e.VerticalChange < this.MinHeight)
            {
                this.Height = this.MinHeight;
            }
            else
            {
                this.Height += e.VerticalChange;
            }
        }
        else if(row == 2 && column == 2)
        {
            // Right Bottom
            if (this.Width + e.HorizontalChange < this.MinWidth)
            {
                this.Width = this.MinWidth;
            }
            else
            {
                this.Width += e.HorizontalChange;
            }

            if (this.Height + e.VerticalChange < this.MinHeight)
            {
                this.Height = this.MinHeight;
            }
            else
            {
                this.Height += e.VerticalChange;
            }
        }
    }
    }
}
