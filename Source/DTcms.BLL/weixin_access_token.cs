using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
	/// <summary>
	/// ����ƽ̨AccessTokenֵ
	/// </summary>
	public partial class weixin_access_token
	{
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.weixin_access_token dal;
		public weixin_access_token()
		{
            dal = new DAL.weixin_access_token(siteConfig.sysdatabaseprefix);
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
        /// ��������һ������
        /// </summary>
        public int Add(string access_token)
        {
            Model.weixin_access_token model = new Model.weixin_access_token();
            model.access_token = access_token;
            model.count = 1;
            model.expires_in = 1200; //1200��
            model.add_time = DateTime.Now;
            return dal.Add(model);
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Model.weixin_access_token model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Model.weixin_access_token model)
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
		public Model.weixin_access_token GetModel()
		{
			return dal.GetModel();
		}
		#endregion

    }
}

