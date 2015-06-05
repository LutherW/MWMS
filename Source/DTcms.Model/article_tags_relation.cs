using System;
namespace DTcms.Model
{
    /// <summary>
    /// TAG标签关系
    /// </summary>
    [Serializable]
    public partial class article_tags_relation
    {
        public article_tags_relation()
        { }
        #region Model
        private int _id;
        private int _article_id;
        private int _tag_id;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 文章ID
        /// </summary>
        public int article_id
        {
            set { _article_id = value; }
            get { return _article_id; }
        }
        /// <summary>
        /// 标签ID
        /// </summary>
        public int tag_id
        {
            set { _tag_id = value; }
            get { return _tag_id; }
        }
        #endregion Model

    }
}