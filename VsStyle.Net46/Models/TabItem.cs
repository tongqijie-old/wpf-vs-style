namespace VsStyle.Models
{
    using System.ComponentModel;
    using System.Windows.Controls;

    class TabItem : System.Windows.Controls.TabItem, INotifyPropertyChanged
    {
        public TabItem()
        {
            DataContext = this;
        }

        public TabItem(int id, string header, ContentControl content)
            : this()
        {
            Id = id;
            Header = header;
            Content = content;
        }

        /// <summary>
        /// 唯一值，用于区分不同的选项卡
        /// </summary>
        public int Id { get; set; }

        private bool _IsPinned = false;

        /// <summary>
        /// 是否固定
        /// </summary>
        public bool IsPinned
        {
            get { return _IsPinned; }
            set
            {
                if(_IsPinned != value)
                {
                    _IsPinned = value;
                    FirePropertiesChanged("IsPinned");
                }
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void FirePropertiesChanged(params string[] properties)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                foreach (string property in properties)
                {
                    handler.Invoke(this, new PropertyChangedEventArgs(property));
                }
            }
        }

        #endregion
    }
}
