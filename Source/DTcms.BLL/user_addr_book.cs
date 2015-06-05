using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
	/// <summary>
	/// 收货地址簿
	/// </summary>
	public partial class user_addr_book
	{
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.user_addr_book dal;
		public user_addr_book()
		{
            dal = new DAL.user_addr_book(siteConfig.sysdatabaseprefix);
        }

        #region 基本方法============================
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id, string user_name)
        {
            return dal.Exists(id, user_name);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.user_addr_book model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.user_addr_book model)
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
        /// 根据用户名删除一条数据
        /// </summary>
        public bool Delete(int id, string user_name)
        {
            return dal.Delete(id, user_name);
        }
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.user_addr_book GetModel(int id)
		{
			return dal.GetModel(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
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

        #region 扩展方法============================
        /// <summary>
        /// 返回默认的地址
        /// </summary>
        public Model.user_addr_book GetDefault(string user_name)
        {
            return dal.GetDefault(user_name);
        }

        /// <summary>
        /// 设置为默认的收货地址
        /// </summary>
        public void SetDefault(int id, string user_name)
        {
            dal.SetDefault(id, user_name);
        }
        #endregion
    }
}

