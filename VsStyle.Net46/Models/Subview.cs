namespace VsStyle.Models
{
    using System.Windows.Controls;

    enum DockPosition
    {
        Left,

        Right,

        Bottom,
    }

    class Subview
    {
        /// <summary>
        /// 子视图ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 子视图标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 停靠位置
        /// </summary>
        public DockPosition Position { get; set; }

        /// <summary>
        /// 是否自动隐藏
        /// </summary>
        public bool AutoHide { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ContentControl Content { get; set; }
    }
}
