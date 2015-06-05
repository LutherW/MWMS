using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
	/// <summary>
    /// 请求回复规格
	/// </summary>
	public partial class weixin_request_rule
	{
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.weixin_request_rule dal;
		public weixin_request_rule()
		{
            dal = new DAL.weixin_request_rule(siteConfig.sysdatabaseprefix);
        }

        #region 基本方法===================================
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.weixin_request_rule model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.weixin_request_rule model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			return dal.Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.weixin_request_rule GetModel(int id)
		{
			return dal.GetModel(id);
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
		#endregion

        #region 扩展方法===================================
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Model.weixin_request_rule GetRequestTypeModel(int request_type)
        {
            return dal.GetRequestTypeModel(request_type);
        }
        #endregion

        #region 微信通讯方法===============================
        /// <summary>
        /// 得到规则ID以回复类型
        /// </summary>
        public int GetRuleIdAndResponseType(string strWhere, out int response_type)
        {
            return dal.GetRuleIdAndResponseType(strWhere, out response_type);
        }

        /// <summary>
        /// 得到关健字查询的规则ID及回复类型
        /// </summary>
        public int GetKeywordsRuleId(string keywords, out int response_type)
        {
            return dal.GetKeywordsRuleId(keywords, out response_type);
        }
        #endregion
    }
}

