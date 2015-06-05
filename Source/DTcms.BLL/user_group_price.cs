using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
	/// <summary>
	/// ��Ա��۸�
	/// </summary>
	public partial class user_group_price
	{
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.user_group_price dal;
        public user_group_price()
        {
            dal = new DAL.user_group_price(siteConfig.sysdatabaseprefix);
        }

        #region ��������===============================
        /// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public Model.user_group_price GetModel(int goods_id, int group_id)
        {
            return dal.GetModel(goods_id, group_id);
        }
		#endregion
	}
}

