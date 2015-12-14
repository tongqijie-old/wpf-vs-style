using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace VsStyle.Net46
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnActivated(EventArgs e)
        {
            var window = this.MainWindow as MainWindow;
            if (window != null)
            {
                window.Resources["BorderThemeColor"] = new SolidColorBrush(Color.FromArgb(0xFF, 0xCA, 0x51, 0x00));
            }

            base.OnActivated(e);
        }

        protected override void OnDeactivated(EventArgs e)
        {
            var window = this.MainWindow as MainWindow;
            if(window != null)
            {
                window.Resources["BorderThemeColor"] = new SolidColorBrush(Color.FromArgb(0xFF, 0x3C, 0x40, 0x47));
            }

            base.OnDeactivated(e);
        }
    }
}
