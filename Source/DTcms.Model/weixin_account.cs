using System;
namespace DTcms.Model
{
    /// <summary>
    /// 微信公众平台账户
    /// </summary>
    [Serializable]
    public partial class weixin_account
    {
        public weixin_account()
        { }
        #region Model
        private int _id = 0;
        private string _name;
        private string _originalid;
        private string _wxcode;
        private string _token;
        private string _appid;
        private string _appsecret;
        private int _is_push = 0;
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
        /// 公众号名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 公众号原始ID
        /// </summary>
        public string originalid
        {
            set { _originalid = value; }
            get { return _originalid; }
        }
        /// <summary>
        /// 微信号
        /// </summary>
        public string wxcode
        {
            set { _wxcode = value; }
            get { return _wxcode; }
        }
        /// <summary>
        /// 令牌必须与微信平台对应
        /// </summary>
        public string token
        {
            set { _token = value; }
            get { return _token; }
        }
        /// <summary>
        /// appid(仅用于高级接口)
        /// </summary>
        public string appid
        {
            set { _appid = value; }
            get { return _appid; }
        }
        /// <summary>
        /// appsecret(仅用于高级接口)
        /// </summary>
        public string appsecret
        {
            set { _appsecret = value; }
            get { return _appsecret; }
        }
        /// <summary>
        /// 是否支持网站内容推送
        /// </summary>
        public int is_push
        {
            set { _is_push = value; }
            get { return _is_push; }
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
        /// 添加时间
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model

    }
}