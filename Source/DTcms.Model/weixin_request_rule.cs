using System;
using System.Collections.Generic;

namespace DTcms.Model
{
    /// <summary>
    /// �ظ�����:ʵ����
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
        /// ��������
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// ����ؼ���,���ŷָ�
        /// </summary>
        public string keywords
        {
            set { _keywords = value; }
            get { return _keywords; }
        }
        /// <summary>
        /// ��������(0Ĭ�ϻظ�1����2ͼƬ3����4����5����λ��6��ע7ȡ����ע8ɨ���������ά���¼�9�ϱ�����λ���¼�10�Զ���˵��¼���
        /// </summary>
        public int request_type
        {
            set { _request_type = value; }
            get { return _request_type; }
        }
        /// <summary>
        /// �ظ�����(1�ı�2ͼ��3����4��Ƶ5�������ӿ�)
        /// </summary>
        public int response_type
        {
            set { _response_type = value; }
            get { return _response_type; }
        }
        /// <summary>
        /// �Ƿ�ģ����ѯ
        /// </summary>
        public int is_like_query
        {
            set { _is_like_query = value; }
            get { return _is_like_query; }
        }
        /// <summary>
        /// �Ƿ�Ĭ�ϻظ�
        /// </summary>
        public int is_default
        {
            set { _is_default = value; }
            get { return _is_default; }
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

        private List<weixin_request_content> _contents;
        /// <summary>
        /// �������ݱ�
        /// </summary>
        public List<weixin_request_content> contents
        {
            set { _contents = value; }
            get { return _contents; }
        }
        #endregion Model

    }
}