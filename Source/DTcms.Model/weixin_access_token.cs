using System;
namespace DTcms.Model
{
    /// <summary>
    /// 公众平台AccessToken存储
    /// </summary>
    [Serializable]
    public partial class weixin_access_token
    {
        public weixin_access_token()
        { }
        #region Model
        private int _id;
        private int _account_id = 0;
        private string _access_token;
        private int _expires_in = 0;
        private int _count = 0;
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
        /// access_token值
        /// </summary>
        public string access_token
        {
            set { _access_token = value; }
            get { return _access_token; }
        }
        /// <summary>
        /// 有效期(秒)
        /// </summary>
        public int expires_in
        {
            set { _expires_in = value; }
            get { return _expires_in; }
        }
        /// <summary>
        /// 总数
        /// </summary>
        public int count
        {
            set { _count = value; }
            get { return _count; }
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