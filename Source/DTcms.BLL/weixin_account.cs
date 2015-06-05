using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
	/// <summary>
	/// ΢�Ź���ƽ̨�˻�
	/// </summary>
	public partial class weixin_account
	{
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.weixin_account dal;
		public weixin_account()
		{
            dal = new DAL.weixin_account(siteConfig.sysdatabaseprefix);
        }

        #region ��������===================================
        /// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists()
		{
			return dal.Exists();
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Model.weixin_account model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Model.weixin_account model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete()
		{
			return dal.Delete();
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Model.weixin_account GetModel()
		{
			return dal.GetModel();
		}
		#endregion

        #region ��չ����===================================
         /// <summary>
        /// �����˻�����
        /// </summary>
        public string GetName()
        {
            return dal.GetName();
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public string GetToken()
        {
            return dal.GetToken();
        }

        /// <summary>
        /// �����˻���ԭʼID�Ƿ��Ӧ
        /// </summary>
        public bool ExistsOriginalId(string originalid)
        {
            return dal.ExistsOriginalId(originalid);
        }
        #endregion
    }
}

