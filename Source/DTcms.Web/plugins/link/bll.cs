using System;
using System.Data;
using System.Collections.Generic;
using DTcms.Common;

namespace DTcms.Web.Plugin.Link.BLL
{
	/// <summary>
	/// link
	/// </summary>
	public partial class link
	{
        private readonly DTcms.Model.siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.link dal;
		public link()
		{
            dal = new DAL.link(siteConfig.sysdatabaseprefix);
        }

		#region Method
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
		public int  Add(Model.link model)
		{
			return dal.Add(model);
		}

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Model.link model)
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
		public Model.link GetModel(int id)
		{
			return dal.GetModel(id);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
        public DataSet GetList(int Top, string strWhere)
        {
            return dal.GetList(Top, strWhere);
        }

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

		#endregion  Method
	}
}

