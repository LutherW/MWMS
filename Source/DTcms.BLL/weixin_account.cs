using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
	/// <summary>
	/// 微信公众平台账户
	/// </summary>
	public partial class weixin_account
	{
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.weixin_account dal;
		public weixin_account()
		{
            dal = new DAL.weixin_account(siteConfig.sysdatabaseprefix);
        }

        #region 基本方法===================================
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists()
		{
			return dal.Exists();
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.weixin_account model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.weixin_account model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.weixin_account GetModel()
		{
			return dal.GetModel();
		}
		#endregion

        #region 扩展方法===================================
         /// <summary>
        /// 返回账户名称
        /// </summary>
        public string GetName()
        {
            return dal.GetName();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetToken()
        {
            return dal.GetToken();
        }

        /// <summary>
        /// 公众账户和原始ID是否对应
        /// </summary>
        public bool ExistsOriginalId(string originalid)
        {
            return dal.ExistsOriginalId(originalid);
        }
        #endregion
    }
}

