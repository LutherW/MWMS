using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
    /// <summary>
    /// 商品对应规格表
    /// </summary>
    public partial class article_goods_spec
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.article_goods_spec dal;

        public article_goods_spec()
        {
            dal = new DAL.article_goods_spec(siteConfig.sysdatabaseprefix);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.article_goods_spec> GetList(int article_id, string strWhere)
        {
            return dal.GetList(article_id, strWhere);
        }

    }
}
