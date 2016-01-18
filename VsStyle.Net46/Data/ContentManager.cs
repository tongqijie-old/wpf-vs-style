namespace VsStyle.Data
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    class ContentManager : Util.INotifyPropertyChangedImpl
    {
        private static ContentManager _Manager = null;

        public static ContentManager Manager { get { return _Manager ?? (_Manager = new ContentManager()); } }

        public Models.TabItem AppendTabItem(Models.TabItem appendedTabItem)
        {
            var existedTabItem = TabItems.FirstOrDefault(x => x.Id == appendedTabItem.Id);
            if (existedTabItem == null)
            {
                existedTabItem = appendedTabItem;
                TabItems.Add(existedTabItem);
            }
            SelectedTabItem = existedTabItem;
            return existedTabItem;
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
                    var selected = SelectedTabItem == tabItem;

                    var index = TabItems.IndexOf(unpinnedTabItem);

                    tabItem.IsPinned = true;
                    TabItems.Remove(tabItem);
                    TabItems.Insert(index, tabItem);
                    if (selected)
                    {
                        SelectedTabItem = tabItem;
                    }
                }
            }
        }

        public void Unpin(Models.TabItem tabItem)
        {
            if (tabItem.IsPinned)
            {
                var unpinnedTabItem = TabItems.FirstOrDefault(x => !x.IsPinned);

                var selected = SelectedTabItem == tabItem;

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

                if (selected)
                {
                    SelectedTabItem = tabItem;
                }
            }
        }

        public void MoveLeft(Models.TabItem tabItem)
        {
            if (!tabItem.IsPinned)
            {
                var index = TabItems.IndexOf(tabItem);
                if (index > 0 && !TabItems[index - 1].IsPinned)
                {
                    TabItems.Remove(tabItem);
                    TabItems.Insert(index - 1, tabItem);
                }
            }
        }

        public void MoveRight(Models.TabItem tabItem)
        {
            if (!tabItem.IsPinned)
            {
                var index = TabItems.IndexOf(tabItem);
                if(index >= 0 && index < TabItems.Count - 1)
                {
                    TabItems.Remove(tabItem);
                    TabItems.Insert(index + 1, tabItem);
                }
            }
        }
    }
}
