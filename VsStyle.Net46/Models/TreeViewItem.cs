namespace VsStyle.Models
{
    using System.Collections.Generic;
    using System.Linq;

    class TreeViewItem
    {
        public TreeViewItem()
        {
            //DataContext = this;
        }

        public TreeViewItem(int id, string imageUri, string label) 
            : this()
        {
            Id = id;
            ImageUri = imageUri;
            Label = label;
        }

        public TreeViewItem(int id, string imageUri, string label, TreeViewItem parentItem)
            : this(id, imageUri, label)
        {
            ParentItem = parentItem;
            if (parentItem.ChildItems.FirstOrDefault(x => x.Id == id) == null)
            {
                parentItem.ChildItems.Add(this);
            }
        }

        /// <summary>
        /// 用于唯一地标记节点
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 节点显示的名称
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 是否隐藏箭头
        /// </summary>
        public bool IsArrowHidden { get; set; }

        /// <summary>
        /// 节点图片URI
        /// </summary>
        public string ImageUri { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public TreeViewItem ParentItem { get; set; }

        public delegate void TreeViewItemDoubleClicked(TreeViewItem sender);

        /// <summary>
        /// 双击时执行
        /// </summary>
        public TreeViewItemDoubleClicked DoubleClicked { get; set; }

        /// <summary>
        /// 保存展开状态，不建议用户修改该值
        /// </summary>
        public bool IsExpanded { get; set; }

        /// <summary>
        /// 层次级别，根节点级数为0，依次递增
        /// </summary>
        public int HierarchicalLevel
        {
            get
            {
                var level = 0;
                TreeViewItem treeViewItem = this;
                while ((treeViewItem = treeViewItem.ParentItem) != null)
                {
                    level++;
                }
                return level;
            }
        }

        /// <summary>
        /// 是否包含子节点
        /// </summary>
        public bool HasChildItems { get { return ChildItems.Count > 0; } }

        private System.Collections.ObjectModel.ObservableCollection<TreeViewItem> _ChildItems = null;

        /// <summary>
        /// 子节点集合
        /// </summary>
        public IList<TreeViewItem> ChildItems
        {
            get { return _ChildItems ?? (_ChildItems = new System.Collections.ObjectModel.ObservableCollection<TreeViewItem>()); }
        }
    }
}
