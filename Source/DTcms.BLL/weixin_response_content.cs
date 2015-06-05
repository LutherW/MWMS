using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
	/// <summary>
	/// 微信平台回复信息
	/// </summary>
	public partial class weixin_response_content
	{
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.weixin_response_content dal;
		public weixin_response_content()
		{
            dal = new DAL.weixin_response_content(siteConfig.sysdatabaseprefix);
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
		public int  Add(Model.weixin_response_content model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.weixin_response_content model)
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
		public Model.weixin_response_content GetModel(int id)
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
       /// 增加一条记录
       /// </summary>
       /// <param name="openid">请求的用户openid</param>
        /// <param name="request_type">用户请求的类型：文本消息：text 图片消息:image 地理位置消息:location 链接消息:link 事件:event</param>
        /// <param name="request_content">用户请求的数据内容</param>
        /// <param name="response_type"> 系统回复的类型：文本消息：text ,图文消息:txtpic ,语音music, 地理位置消息:location 链接消息:link,未取到数据none</param>
        /// <param name="reponse_content">系统回复的内容</param>
        /// <param name="ToUserName">由于取不到xml内容，我们将toUserName存入</param>
        public int Add(string openid, string request_type, string request_content, string response_type, string reponse_content, string xml_content)
        {
            int result = 0;
            try
            {
                Model.weixin_response_content model = new Model.weixin_response_content();
                model.openid = openid;
                model.request_type = request_type;
                model.request_content = request_content;
                model.response_type = response_type;
                model.reponse_content = reponse_content;
                model.xml_content = xml_content;
                model.add_time = DateTime.Now;
                result = dal.Add(model);
            }
            catch
            {
                return 0;
            }
            return result;
        }
        #endregion
    }
}

