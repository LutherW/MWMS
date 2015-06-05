using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
	/// <summary>
	/// 会员组价格
	/// </summary>
	public partial class user_group_price
	{
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.user_group_price dal;
        public user_group_price()
        {
            dal = new DAL.user_group_price(siteConfig.sysdatabaseprefix);
        }

        #region 基本方法===============================
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Model.user_group_price GetModel(int goods_id, int group_id)
        {
            return dal.GetModel(goods_id, group_id);
        }
		#endregion
	}
}

