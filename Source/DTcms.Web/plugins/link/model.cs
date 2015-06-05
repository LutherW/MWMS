using System;
namespace DTcms.Web.Plugin.Link.Model
{
    /// <summary>
    /// ��������:ʵ����
    /// </summary>
    [Serializable]
    public partial class link
    {
        public link()
        { }
        #region Model
        private int _id;
        private string _site_path = string.Empty;
        private string _title = string.Empty;
        private string _user_name = string.Empty;
        private string _user_tel = string.Empty;
        private string _email = string.Empty;
        private string _site_url = string.Empty;
        private string _img_url = string.Empty;
        private int _is_image = 0;
        private int _sort_id = 99;
        private int _is_red = 0;
        private int _is_lock = 0;
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
        /// վ��Ŀ¼
        /// </summary>
        public string site_path
        {
            set { _site_path = value; }
            get { return _site_path; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
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
        /// ����
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// ��ַ
        /// </summary>
        public string site_url
        {
            set { _site_url = value; }
            get { return _site_url; }
        }
        /// <summary>
        /// ͼƬ·��
        /// </summary>
        public string img_url
        {
            set { _img_url = value; }
            get { return _img_url; }
        }
        /// <summary>
        /// �Ƿ�ΪͼƬ
        /// </summary>
        public int is_image
        {
            set { _is_image = value; }
            get { return _is_image; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public int sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        /// <summary>
        /// �Ƿ��Ƽ�
        /// </summary>
        public int is_red
        {
            set { _is_red = value; }
            get { return _is_red; }
        }
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public int is_lock
        {
            set { _is_lock = value; }
            get { return _is_lock; }
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