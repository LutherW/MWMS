using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
    public partial class article_goods
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得系统配置信息
        private readonly DAL.article_goods dal;

        public article_goods()
        {
            dal = new DAL.article_goods(siteConfig.sysdatabaseprefix);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int article_id, int goods_id)
        {
            return dal.Exists(article_id, goods_id);
        }

        /// <summary>
        /// 根据商品ID查询商品实体
        /// </summary>
        public Model.article_goods GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 根据规格列表查询商品实体
        /// </summary>
        public Model.article_goods GetModel(int article_id, string spec_ids)
        {
            return dal.GetModel(article_id, spec_ids);
        }

        /// <summary>
        /// 得到一个商品价格列表
        /// </summary>
        public List<Model.article_goods> GetList(int article_id)
        {
            return dal.GetList(article_id);
        }

    }
}
