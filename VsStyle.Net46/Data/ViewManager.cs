namespace VsStyle.Data
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    class ViewManager : Util.INotifyPropertyChangedImpl
    {
        private static ViewManager _Manager = null;

        public static ViewManager Manager
        {
            get
            {
                if(_Manager == null)
                {
                    _Manager = new ViewManager();
                    _Manager.Subviews.Add(new Models.Subview()
                    {
                        Id = 1,
                        Title = "Solution Explorer",
                        Position = Models.DockPosition.Left,
                        Content = new Views.SolutionExplorer(),
                    });
                    _Manager.Subviews.Add(new Models.Subview()
                    {
                        Id = 2,
                        Title = "Team Explorer",
                        Position = Models.DockPosition.Left,
                    });
                }
                return _Manager;
            }
        }

        private ObservableCollection<Models.Subview> _Subviews = null;

        public IList<Models.Subview> Subviews { get { return _Subviews ?? (_Subviews = new ObservableCollection<Models.Subview>()); } }

        private Models.Subview _LeftDockSubView = null;

        public Models.Subview LeftDockSubview
        {
            get { return _LeftDockSubView; }
            set
            {
                if (_LeftDockSubView != value)
                {
                    _LeftDockSubView = value;
                    FirePropertiesChanged("LeftDockSubview");
                }
            }
        }
    }
}
