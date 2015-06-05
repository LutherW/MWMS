using System;
using System.Collections.Generic;

namespace DTcms.Model
{
    /// <summary>
    /// 回复规则:实体类
    /// </summary>
    [Serializable]
    public partial class weixin_request_rule
    {
        public weixin_request_rule()
        { }

        #region Model
        private int _id = 0;
        private int _account_id;
        private string _name;
        private string _keywords;
        private int _request_type;
        private int _response_type;
        private int _is_like_query = 0;
        private int _is_default = 0;
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
        /// 规则名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 请求关键词,逗号分隔
        /// </summary>
        public string keywords
        {
            set { _keywords = value; }
            get { return _keywords; }
        }
        /// <summary>
        /// 请求类型(0默认回复1文字2图片3语音4链接5地理位置6关注7取消关注8扫描带参数二维码事件9上报地理位置事件10自定义菜单事件）
        /// </summary>
        public int request_type
        {
            set { _request_type = value; }
            get { return _request_type; }
        }
        /// <summary>
        /// 回复类型(1文本2图文3语音4视频5第三方接口)
        /// </summary>
        public int response_type
        {
            set { _response_type = value; }
            get { return _response_type; }
        }
        /// <summary>
        /// 是否模糊查询
        /// </summary>
        public int is_like_query
        {
            set { _is_like_query = value; }
            get { return _is_like_query; }
        }
        /// <summary>
        /// 是否默认回复
        /// </summary>
        public int is_default
        {
            set { _is_default = value; }
            get { return _is_default; }
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

        private List<weixin_request_content> _contents;
        /// <summary>
        /// 规则内容表
        /// </summary>
        public List<weixin_request_content> contents
        {
            set { _contents = value; }
            get { return _contents; }
        }
        #endregion Model

    }
}