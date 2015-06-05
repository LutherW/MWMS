using System;
namespace DTcms.Model
{
    /// <summary>
    /// ΢�Ź���ƽ̨�˻�
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
        /// ����ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ���ں�����
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// ���ں�ԭʼID
        /// </summary>
        public string originalid
        {
            set { _originalid = value; }
            get { return _originalid; }
        }
        /// <summary>
        /// ΢�ź�
        /// </summary>
        public string wxcode
        {
            set { _wxcode = value; }
            get { return _wxcode; }
        }
        /// <summary>
        /// ���Ʊ�����΢��ƽ̨��Ӧ
        /// </summary>
        public string token
        {
            set { _token = value; }
            get { return _token; }
        }
        /// <summary>
        /// appid(�����ڸ߼��ӿ�)
        /// </summary>
        public string appid
        {
            set { _appid = value; }
            get { return _appid; }
        }
        /// <summary>
        /// appsecret(�����ڸ߼��ӿ�)
        /// </summary>
        public string appsecret
        {
            set { _appsecret = value; }
            get { return _appsecret; }
        }
        /// <summary>
        /// �Ƿ�֧����վ��������
        /// </summary>
        public int is_push
        {
            set { _is_push = value; }
            get { return _is_push; }
        }
        /// <summary>
        /// �����
        /// </summary>
        public int sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model

    }
}