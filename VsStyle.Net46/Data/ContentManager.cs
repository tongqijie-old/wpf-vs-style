namespace VsStyle.Data
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    class ContentManager : Util.INotifyPropertyChangedImpl
    {
        private static ContentManager _Manager = null;

        public static ContentManager Manager
        {
            get
            {
                if(_Manager == null)
                {
                    _Manager = new ContentManager();

                    _Manager.TabItems.Add(new Models.TabItem()
                    {
                        Id = 1,
                        Header = "MainWindow.xaml.cs",
                        Content = new Temporary.Apple("MainWindow.xaml.cs"),
                    });
                    _Manager.TabItems.Add(new Models.TabItem()
                    {
                        Id = 2,
                        Header = "MainWindow.xaml",
                        Content = new Temporary.Apple("MainWindow.xaml"),
                    });
                }
                return _Manager;
            }
        }

        private ObservableCollection<Models.TabItem> _TabItems = null;

        public IList<Models.TabItem> TabItems { get { return _TabItems ?? (_TabItems = new ObservableCollection<Models.TabItem>()); } }

        private Models.TabItem _SelectedTabItem = null;

        public Models.TabItem SelectedTabItem
        {
            get { return _SelectedTabItem; }
            set
            {
                if(_SelectedTabItem != value)
                {
                    _SelectedTabItem = value;
                    FirePropertiesChanged("SelectedTabItem");
                }
            }
        }

        public void Pin(Models.TabItem tabItem)
        {
            if (!tabItem.IsPinned)
            {
                var unpinnedTabItem = TabItems.FirstOrDefault(x => !x.IsPinned);
                if(unpinnedTabItem != null)
                {
                    var index = TabItems.IndexOf(unpinnedTabItem);

                    tabItem.IsPinned = true;
                    TabItems.Remove(tabItem);
                    TabItems.Insert(index, tabItem);
                }
            }
        }

        public void Unpin(Models.TabItem tabItem)
        {
            if (tabItem.IsPinned)
            {
                var unpinnedTabItem = TabItems.FirstOrDefault(x => !x.IsPinned);
                if (unpinnedTabItem != null)
                {
                    var index = TabItems.IndexOf(unpinnedTabItem);
                    tabItem.IsPinned = false;
                    TabItems.Remove(tabItem);
                    TabItems.Insert(index, tabItem);
                }
                else
                {
                    tabItem.IsPinned = false;
                    TabItems.Remove(tabItem);
                    TabItems.Insert(TabItems.Count, tabItem);
                }
            }
        }
    }
}
