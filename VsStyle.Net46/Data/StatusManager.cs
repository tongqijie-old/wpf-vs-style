namespace VsStyle.Data
{
    class StatusManager : Util.INotifyPropertyChangedImpl
    {
        private static StatusManager _Manager = null;

        public static StatusManager Manager { get { return _Manager ?? (_Manager = new StatusManager()); } }

        public string _Text = null;

        public string Text
        {
            get { return _Text; }
            set
            {
                if (_Text != value)
                {
                    _Text = value;
                    FirePropertiesChanged("Text");
                }
            }
        }
    }
}
