using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
	/// <summary>
    /// ����ظ����
	/// </summary>
	public partial class weixin_request_rule
	{
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.weixin_request_rule dal;
		public weixin_request_rule()
		{
            dal = new DAL.weixin_request_rule(siteConfig.sysdatabaseprefix);
        }

        #region ��������===================================
        /// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(Model.weixin_request_rule model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Model.weixin_request_rule model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int id)
		{
			return dal.Delete(id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Model.weixin_request_rule GetModel(int id)
		{
			return dal.GetModel(id);
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
		#endregion

        #region ��չ����===================================
        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public Model.weixin_request_rule GetRequestTypeModel(int request_type)
        {
            return dal.GetRequestTypeModel(request_type);
        }
        #endregion

        #region ΢��ͨѶ����===============================
        /// <summary>
        /// �õ�����ID�Իظ�����
        /// </summary>
        public int GetRuleIdAndResponseType(string strWhere, out int response_type)
        {
            return dal.GetRuleIdAndResponseType(strWhere, out response_type);
        }

        /// <summary>
        /// �õ��ؽ��ֲ�ѯ�Ĺ���ID���ظ�����
        /// </summary>
        public int GetKeywordsRuleId(string keywords, out int response_type)
        {
            return dal.GetKeywordsRuleId(keywords, out response_type);
        }
        #endregion
    }
}

