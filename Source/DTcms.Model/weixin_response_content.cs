using System;
namespace DTcms.Model
{
    /// <summary>
    /// ����ƽ̨�ظ���Ϣ
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
        /// �û�΢��ID
        /// </summary>
        public string openid
        {
            set { _openid = value; }
            get { return _openid; }
        }
        /// <summary>
        /// �������� �ı���Ϣ��text ͼƬ��Ϣ:image ����λ����Ϣ:location ������Ϣ:link �¼�:event
        /// </summary>
        public string request_type
        {
            set { _request_type = value; }
            get { return _request_type; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string request_content
        {
            set { _request_content = value; }
            get { return _request_content; }
        }
        /// <summary>
        /// �ظ������� �ı���Ϣ��text ͼƬ��Ϣ:image ����λ����Ϣ:location ������Ϣ:link
        /// </summary>
        public string response_type
        {
            set { _response_type = value; }
            get { return _response_type; }
        }
        /// <summary>
        /// ϵͳ�ظ�������
        /// </summary>
        public string reponse_content
        {
            set { _reponse_content = value; }
            get { return _reponse_content; }
        }
        /// <summary>
        /// ��Ϣ����ʱ��
        /// </summary>
        public string create_time
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// xmlԭʼ����
        /// </summary>
        public string xml_content
        {
            set { _xml_content = value; }
            get { return _xml_content; }
        }
        /// <summary>
        /// ¼��ϵͳ��ʱ��
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model

    }
}