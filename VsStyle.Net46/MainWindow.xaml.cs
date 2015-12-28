﻿using System;
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
            else if (row == 0 && column == 1)
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
            else if (row == 0 && column == 2)
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
            else if (row == 1 && column == 0)
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
            else if (row == 1 && column == 2)
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
            else if (row == 2 && column == 0)
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
            else if (row == 2 && column == 1)
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
            else if (row == 2 && column == 2)
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

        private DateTime MouseDownTimeOnTitleBar { get; set; }

        private void MouseDownOnCaptionBar(object sender, MouseButtonEventArgs e)
        {
            if ((DateTime.Now - MouseDownTimeOnTitleBar) < TimeSpan.FromSeconds(0.5))
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                }
                else
                {
                    WindowState = WindowState.Maximized;
                }
                return;
            }
            else
            {
                MouseDownTimeOnTitleBar = DateTime.Now;
            }

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void WindowStateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                MaximizeButtonImage.Source = new BitmapImage(new Uri("Assets/Images/icon.restore.png", UriKind.RelativeOrAbsolute));
            }
            else if (WindowState == WindowState.Normal)
            {
                MaximizeButtonImage.Source = new BitmapImage(new Uri("Assets/Images/icon.maximize.png", UriKind.RelativeOrAbsolute));
            }
        }

        private void MinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeButtonClick(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CloseTabItemButtonClick(object sender, RoutedEventArgs e)
        {
            var tabItem = (sender as FrameworkElement).Tag as Models.TabItem;
            if(tabItem != null)
            {
                Data.ContentManager.Manager.TabItems.Remove(tabItem);
            }
        }

        private void DockTabItemButtonClick(object sender, RoutedEventArgs e)
        {
            var tabItem = (sender as FrameworkElement).Tag as Models.TabItem;
            if(tabItem != null)
            {
                if(tabItem.IsPinned)
                {
                    Data.ContentManager.Manager.Unpin(tabItem);
                }
                else
                {
                    Data.ContentManager.Manager.Pin(tabItem);
                }
            }
        }

        private object MouseDownObject { get; set; }

        private void MouseDownOnTabItem(object sender, MouseButtonEventArgs e)
        {
            MouseDownObject = sender;
        }

        private void MouseLeaveOnTabItem(object sender, MouseEventArgs e)
        {
            if(sender == MouseDownObject)
            {
                var tabItem = (sender as FrameworkElement).Tag as Models.TabItem;
                if (tabItem != null)
                {
                    if (e.LeftButton == MouseButtonState.Pressed)
                    {
                        var point = e.GetPosition(tabItem);

                        if (point.X < 0 && point.Y < tabItem.ActualHeight && point.Y > 0)
                        {
                            Data.ContentManager.Manager.MoveLeft(tabItem);
                        }
                        else if (point.X > tabItem.ActualWidth && point.Y < tabItem.ActualHeight && point.Y > 0)
                        {
                            Data.ContentManager.Manager.MoveRight(tabItem);
                        }
                    }
                }
            }
        }

        private void TabControlComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var tabItem = e.AddedItems[0] as Models.TabItem;
                if(tabItem != null)
                {
                    Data.ContentManager.Manager.SelectedTabItem = tabItem;
                }
            }
        }
    }
}
