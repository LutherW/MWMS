using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
	/// <summary>
	/// ΢������ظ�������
	/// </summary>
	public partial class weixin_request_content
	{
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.weixin_request_content dal;
		public weixin_request_content()
		{
            dal = new DAL.weixin_request_content(siteConfig.sysdatabaseprefix);
        }

        /// <summary>
		/// �Ƿ���ڹ���ü�¼
		/// </summary>
		public bool Exists(int rule_id)
		{
            return dal.Exists(rule_id);
		}

		/// <summary>
		/// �õ�һ���������ʵ��
		/// </summary>
		public Model.weixin_request_content GetModel(int rule_id)
		{
			return dal.GetModel(rule_id);
		}

        /// <summary>
        /// ��ù���µ������б�
        /// </summary>
        public List<Model.weixin_request_content> GetModelList(int Top, int ruleId, string strWhere)
        {
            DataSet ds = dal.GetList(Top, ruleId, strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Model.weixin_request_content> DataTableToList(DataTable dt)
        {
            List<Model.weixin_request_content> modelList = new List<Model.weixin_request_content>();
            int rowsCount = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                Model.weixin_request_content model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// ���ع���ĵ�һ������
        /// </summary>
        public string GetTitle(int rule_id)
        {
            return dal.GetTitle(rule_id);
        }

        /// <summary>
        /// ���ع���ĵ�һ������
        /// </summary>
        public string GetContent(int rule_id)
        {
            return dal.GetContent(rule_id);
        }

        /// <summary>
        /// ���ع����������������
        /// </summary>
        public int GetCount(int rule_id)
        {
            return dal.GetCount(rule_id);
        }

    }
}

