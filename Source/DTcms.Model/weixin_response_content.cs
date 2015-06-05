using System;
namespace DTcms.Model
{
    /// <summary>
    /// 公众平台回复信息
    /// </summary>
    [Serializable]
    public partial class weixin_response_content
    {
        public weixin_response_content()
        { }

        #region Model
        private int _id;
        private int _account_id;
        private string _openid;
        private string _request_type;
        private string _request_content;
        private string _response_type;
        private string _reponse_content;
        private string _create_time;
        private string _xml_content;
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
        /// 用户微信ID
        /// </summary>
        public string openid
        {
            set { _openid = value; }
            get { return _openid; }
        }
        /// <summary>
        /// 数据类型 文本消息：text 图片消息:image 地理位置消息:location 链接消息:link 事件:event
        /// </summary>
        public string request_type
        {
            set { _request_type = value; }
            get { return _request_type; }
        }
        /// <summary>
        /// 数据内容
        /// </summary>
        public string request_content
        {
            set { _request_content = value; }
            get { return _request_content; }
        }
        /// <summary>
        /// 回复的类型 文本消息：text 图片消息:image 地理位置消息:location 链接消息:link
        /// </summary>
        public string response_type
        {
            set { _response_type = value; }
            get { return _response_type; }
        }
        /// <summary>
        /// 系统回复的内容
        /// </summary>
        public string reponse_content
        {
            set { _reponse_content = value; }
            get { return _reponse_content; }
        }
        /// <summary>
        /// 消息创建时间
        /// </summary>
        public string create_time
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// xml原始内容
        /// </summary>
        public string xml_content
        {
            set { _xml_content = value; }
            get { return _xml_content; }
        }
        /// <summary>
        /// 录入系统的时间
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model

    }
}