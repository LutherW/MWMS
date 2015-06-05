using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    /// <summary>
    /// 商品对应规格
    /// </summary>
    public partial class article_goods_spec
    {
        private string databaseprefix; //数据库表名前缀
        public article_goods_spec(string _databaseprefix)
		{
            databaseprefix = _databaseprefix;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.article_goods_spec> GetList(int article_id, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select article_id,spec_id,parent_id,title,img_url");
            strSql.Append(" FROM " + databaseprefix + "article_goods_spec ");
            strSql.Append(" where article_id=" + article_id);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            List<Model.article_goods_spec> modelList = new List<Model.article_goods_spec>();
            if (dt.Rows.Count > 0)
            {
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    Model.article_goods_spec model = new Model.article_goods_spec();
                    if (dt.Rows[n]["article_id"] != null && dt.Rows[n]["article_id"].ToString() != "")
                    {
                        model.article_id = int.Parse(dt.Rows[n]["article_id"].ToString());
                    }
                    if (dt.Rows[n]["spec_id"] != null && dt.Rows[n]["spec_id"].ToString() != "")
                    {
                        model.spec_id = int.Parse(dt.Rows[n]["spec_id"].ToString());
                    }
                    if (dt.Rows[n]["parent_id"] != null && dt.Rows[n]["parent_id"].ToString() != "")
                    {
                        model.parent_id = int.Parse(dt.Rows[n]["parent_id"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["img_url"] != null && dt.Rows[n]["img_url"].ToString() != "")
                    {
                        model.img_url = dt.Rows[n]["img_url"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
    }
}
