using System;

namespace DTcms.Model
{
    /// <summary>
    /// 商品对应规格
    /// </summary>
    [Serializable]
    public partial class article_goods_spec
    {
        public article_goods_spec()
        { }
        #region Model
        private int _article_id;
        private int _spec_id;
        private int _parent_id;
        private string _title;
        private string _img_url;
        /// <summary>
        /// 文章ID
        /// </summary>
        public int article_id
        {
            set { _article_id = value; }
            get { return _article_id; }
        }
        /// <summary>
        /// 规格ID
        /// </summary>
        public int spec_id
        {
            set { _spec_id = value; }
            get { return _spec_id; }
        }
        /// <summary>
        /// 规格父ID
        /// </summary>
        public int parent_id
        {
            set { _parent_id = value; }
            get { return _parent_id; }
        }
        /// <summary>
        /// 规格标题
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 规格图片
        /// </summary>
        public string img_url
        {
            set { _img_url = value; }
            get { return _img_url; }
        }
        #endregion Model

    }
}