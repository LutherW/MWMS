using System;
namespace DTcms.Model
{
    /// <summary>
    /// ����ظ�������
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
        /// ����ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// �����˻�ID
        /// </summary>
        public int account_id
        {
            set { _account_id = value; }
            get { return _account_id; }
        }
        /// <summary>
        /// ����ID
        /// </summary>
        public int rule_id
        {
            set { _rule_id = value; }
            get { return _rule_id; }
        }
        /// <summary>
        /// �ظ�����
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// �ظ�����
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// �������ӵ�ַ
        /// </summary>
        public string link_url
        {
            set { _link_url = value; }
            get { return _link_url; }
        }
        /// <summary>
        /// ͼƬ��ַ
        /// </summary>
        public string img_url
        {
            set { _img_url = value; }
            get { return _img_url; }
        }
        /// <summary>
        /// ��������Ƶ��ַ
        /// </summary>
        public string media_url
        {
            set { _media_url = value; }
            get { return _media_url; }
        }
        /// <summary>
        /// ��������������Ƶ��ַ
        /// </summary>
        public string meida_hd_url
        {
            set { _meida_hd_url = value; }
            get { return _meida_hd_url; }
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
        /// ����ʱ��
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model
    }
}