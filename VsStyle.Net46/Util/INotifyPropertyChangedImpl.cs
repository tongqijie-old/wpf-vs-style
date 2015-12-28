namespace VsStyle.Util
{
    using System.ComponentModel;

    class INotifyPropertyChangedImpl : INotifyPropertyChanged
    {
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
    }
}
