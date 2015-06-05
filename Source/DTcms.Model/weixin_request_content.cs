using System;
namespace DTcms.Model
{
    /// <summary>
    /// 请求回复的内容
    /// </summary>
    [Serializable]
    public partial class weixin_request_content
    {
        public weixin_request_content()
        { }

        #region Model
        private int _id;
        private int _account_id;
        private int _rule_id;
        private string _title;
        private string _content;
        private string _link_url;
        private string _img_url;
        private string _media_url;
        private string _meida_hd_url;
        private int _sort_id = 99;
        private DateTime _add_time = DateTime.Now;

        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 公众账户ID
        /// </summary>
        public int account_id
        {
            set { _account_id = value; }
            get { return _account_id; }
        }
        /// <summary>
        /// 规则ID
        /// </summary>
        public int rule_id
        {
            set { _rule_id = value; }
            get { return _rule_id; }
        }
        /// <summary>
        /// 回复标题
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 详情链接地址
        /// </summary>
        public string link_url
        {
            set { _link_url = value; }
            get { return _link_url; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string img_url
        {
            set { _img_url = value; }
            get { return _img_url; }
        }
        /// <summary>
        /// 语音或视频地址
        /// </summary>
        public string media_url
        {
            set { _media_url = value; }
            get { return _media_url; }
        }
        /// <summary>
        /// 高清语音或者视频地址
        /// </summary>
        public string meida_hd_url
        {
            set { _meida_hd_url = value; }
            get { return _meida_hd_url; }
        }
        /// <summary>
        /// 排序号
        /// </summary>
        public int sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model
    }
}