using System;
namespace DTcms.Web.Plugin.Feedback.Model
{
	/// <summary>
	/// ��������:ʵ����
	/// </summary>
    [Serializable]
    public partial class feedback
    {
        public feedback()
        { }
        #region Model
        private int _id;
        private string _site_path;
        private string _title = "";
        private string _content = "";
        private string _user_name = "";
        private string _user_tel = "";
        private string _user_qq = "";
        private string _user_email;
        private DateTime _add_time = DateTime.Now;
        private string _reply_content = "";
        private DateTime? _reply_time;
        private int _is_lock = 0;
        /// <summary>
        /// ����D
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// վ��Ŀ¼
        /// </summary>
        public string site_path
        {
            set { _site_path = value; }
            get { return _site_path; }
        }
        /// <summary>
        /// ���Ա���
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// �û���
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public string user_tel
        {
            set { _user_tel = value; }
            get { return _user_tel; }
        }
        /// <summary>
        /// ��ϵQQ
        /// </summary>
        public string user_qq
        {
            set { _user_qq = value; }
            get { return _user_qq; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string user_email
        {
            set { _user_email = value; }
            get { return _user_email; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        /// <summary>
        /// �ظ�����
        /// </summary>
        public string reply_content
        {
            set { _reply_content = value; }
            get { return _reply_content; }
        }
        /// <summary>
        /// �ظ�ʱ��
        /// </summary>
        public DateTime? reply_time
        {
            set { _reply_time = value; }
            get { return _reply_time; }
        }
        /// <summary>
        /// �Ƿ�����1��0��
        /// </summary>
        public int is_lock
        {
            set { _is_lock = value; }
            get { return _is_lock; }
        }
        #endregion Model

    }
}

