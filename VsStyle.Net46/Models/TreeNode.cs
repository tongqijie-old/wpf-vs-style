namespace VsStyle.Models
{
    using System.Collections.Generic;

    public class TreeNode
    {
        public TreeNode(TreeNode parentNode)
        {
            if(parentNode != null)
            {
                Level = parentNode.Level + 1;
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
        /// 节点相对于根节点的级数，根节点级数为0，依次递增
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// 节点是否开启
        /// </summary>
        public bool IsDisabled { get; set; }

        /// <summary>
        /// 是否隐藏箭头
        /// </summary>
        public bool IsHideArrow { get; set; }

        /// <summary>
        /// 节点图片URI
        /// </summary>
        public string ImageUri { get; set; }

        /// <summary>
        /// 是否展开
        /// </summary>
        public bool IsExpanded { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public TreeNode ParentNode { get; set; }

        private System.Collections.ObjectModel.ObservableCollection<TreeNode> _ChildNodes = null;

        /// <summary>
        /// 子节点集合
        /// </summary>
        public IList<TreeNode> ChildNodes
        {
            get { return _ChildNodes ?? (_ChildNodes = new System.Collections.ObjectModel.ObservableCollection<TreeNode>()); }
        }
    }
}
