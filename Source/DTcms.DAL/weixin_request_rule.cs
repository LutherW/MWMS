using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	/// <summary>
    /// 数据访问类:请求回复规格
	/// </summary>
	public partial class weixin_request_rule
	{
        private string databaseprefix; //数据库表名前缀
        public weixin_request_rule(string _databaseprefix)
		{
            databaseprefix = _databaseprefix;
        }

        #region 基本方法================================
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "weixin_request_rule");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.weixin_request_rule model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "weixin_request_rule(");
            strSql.Append("is_default,sort_id,add_time,account_id,name,keywords,request_type,response_type,is_like_query)");
            strSql.Append(" values (");
            strSql.Append("@is_default,@sort_id,@add_time,@account_id,@name,@keywords,@request_type,@response_type,@is_like_query)");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@is_default", SqlDbType.TinyInt,1),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@account_id", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,200),
					new SqlParameter("@keywords", SqlDbType.NVarChar,2000),
					new SqlParameter("@request_type", SqlDbType.Int,4),
					new SqlParameter("@response_type", SqlDbType.Int,4),
					new SqlParameter("@is_like_query", SqlDbType.TinyInt,1),
					new SqlParameter("@ReturnValue",SqlDbType.Int)};
            parameters[0].Value = model.is_default;
            parameters[1].Value = model.sort_id;
            parameters[2].Value = model.add_time;
            parameters[3].Value = model.account_id;
            parameters[4].Value = model.name;
            parameters[5].Value = model.keywords;
            parameters[6].Value = model.request_type;
            parameters[7].Value = model.response_type;
            parameters[8].Value = model.is_like_query;
            parameters[9].Direction = ParameterDirection.Output;
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            if (model.contents != null)
            {
                StringBuilder strSql2;
                foreach (Model.weixin_request_content models in model.contents)
                {
                    strSql2 = new StringBuilder();
                    strSql2.Append("insert into " + databaseprefix + "weixin_request_content(");
                    strSql2.Append("sort_id,add_time,account_id,rule_id,title,content,link_url,img_url,media_url,meida_hd_url)");
                    strSql2.Append(" values (");
                    strSql2.Append("@sort_id,@add_time,@account_id,@rule_id,@title,@content,@link_url,@img_url,@media_url,@meida_hd_url)");
                    SqlParameter[] parameters2 = {
						    new SqlParameter("@sort_id", SqlDbType.Int,4),
						    new SqlParameter("@add_time", SqlDbType.DateTime),
						    new SqlParameter("@account_id", SqlDbType.Int,4),
						    new SqlParameter("@rule_id", SqlDbType.Int,4),
						    new SqlParameter("@title", SqlDbType.NVarChar,500),
						    new SqlParameter("@content", SqlDbType.NText),
						    new SqlParameter("@link_url", SqlDbType.NVarChar,500),
						    new SqlParameter("@img_url", SqlDbType.NVarChar,500),
						    new SqlParameter("@media_url", SqlDbType.NVarChar,500),
						    new SqlParameter("@meida_hd_url", SqlDbType.NVarChar,500)};
                    parameters2[0].Value = models.sort_id;
                    parameters2[1].Value = models.add_time;
                    parameters2[2].Value = models.account_id;
                    parameters2[3].Direction = ParameterDirection.InputOutput;
                    parameters2[4].Value = models.title;
                    parameters2[5].Value = models.content;
                    parameters2[6].Value = models.link_url;
                    parameters2[7].Value = models.img_url;
                    parameters2[8].Value = models.media_url;
                    parameters2[9].Value = models.meida_hd_url;

                    cmd = new CommandInfo(strSql2.ToString(), parameters2);
                    sqllist.Add(cmd);
                }
            }

            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[9].Value;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Model.weixin_request_rule model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        #region 主表信息============================
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update " + databaseprefix + "weixin_request_rule set ");
                        strSql.Append("account_id=@account_id,");
                        strSql.Append("name=@name,");
                        strSql.Append("keywords=@keywords,");
                        strSql.Append("request_type=@request_type,");
                        strSql.Append("response_type=@response_type,");
                        strSql.Append("is_like_query=@is_like_query,");
                        strSql.Append("is_default=@is_default,");
                        strSql.Append("sort_id=@sort_id,");
                        strSql.Append("add_time=@add_time");
                        strSql.Append(" where id=@id");
                        SqlParameter[] parameters = {
					            new SqlParameter("@account_id", SqlDbType.Int,4),
					            new SqlParameter("@name", SqlDbType.NVarChar,200),
					            new SqlParameter("@keywords", SqlDbType.NVarChar,2000),
					            new SqlParameter("@request_type", SqlDbType.Int,4),
					            new SqlParameter("@response_type", SqlDbType.Int,4),
					            new SqlParameter("@is_like_query", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_default", SqlDbType.TinyInt,1),
					            new SqlParameter("@sort_id", SqlDbType.Int,4),
					            new SqlParameter("@add_time", SqlDbType.DateTime),
					            new SqlParameter("@id", SqlDbType.Int,4)};
                        parameters[0].Value = model.account_id;
                        parameters[1].Value = model.name;
                        parameters[2].Value = model.keywords;
                        parameters[3].Value = model.request_type;
                        parameters[4].Value = model.response_type;
                        parameters[5].Value = model.is_like_query;
                        parameters[6].Value = model.is_default;
                        parameters[7].Value = model.sort_id;
                        parameters[8].Value = model.add_time;
                        parameters[9].Value = model.id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
                        #endregion

                        #region 添加规则内容========================
                        //先删除的规则内容
                        DbHelperSQL.ExecuteSql(conn, trans, "delete from " + databaseprefix + "weixin_request_content where rule_id=" + model.id);
                        //添加/修改规则内容
                        if (model.contents != null)
                        {
                            StringBuilder strSql2;
                            foreach (Model.weixin_request_content modelt in model.contents)
                            {
                                strSql2 = new StringBuilder();
                                strSql2.Append("insert into " + databaseprefix + "weixin_request_content(");
                                strSql2.Append("account_id,rule_id,title,content,link_url,img_url,media_url,meida_hd_url,sort_id,add_time)");
                                strSql2.Append(" values (");
                                strSql2.Append("@account_id,@rule_id,@title,@content,@link_url,@img_url,@media_url,@meida_hd_url,@sort_id,@add_time)");
                                SqlParameter[] parameters2 = {
					                    new SqlParameter("@account_id", SqlDbType.Int,4),
					                    new SqlParameter("@rule_id", SqlDbType.Int,4),
					                    new SqlParameter("@title", SqlDbType.NVarChar,500),
					                    new SqlParameter("@content", SqlDbType.NText),
					                    new SqlParameter("@link_url", SqlDbType.NVarChar,500),
					                    new SqlParameter("@img_url", SqlDbType.NVarChar,500),
					                    new SqlParameter("@media_url", SqlDbType.NVarChar,500),
					                    new SqlParameter("@meida_hd_url", SqlDbType.NVarChar,500),
					                    new SqlParameter("@sort_id", SqlDbType.Int,4),
					                    new SqlParameter("@add_time", SqlDbType.DateTime)};
                                parameters2[0].Value = modelt.account_id;
                                parameters2[1].Value = modelt.rule_id;
                                parameters2[2].Value = modelt.title;
                                parameters2[3].Value = modelt.content;
                                parameters2[4].Value = modelt.link_url;
                                parameters2[5].Value = modelt.img_url;
                                parameters2[6].Value = modelt.media_url;
                                parameters2[7].Value = modelt.meida_hd_url;
                                parameters2[8].Value = modelt.sort_id;
                                parameters2[9].Value = modelt.add_time;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                            }
                        }
                        #endregion

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete " + databaseprefix + "weixin_request_content ");
            strSql2.Append(" where rule_id=@rule_id ");
            SqlParameter[] parameters2 = {
					new SqlParameter("@rule_id", SqlDbType.Int,4)};
            parameters2[0].Value = id;
            CommandInfo cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete " + databaseprefix + "weixin_request_rule ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.weixin_request_rule GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 id,account_id,name,keywords,request_type,response_type,is_like_query,is_default,sort_id,add_time");
            strSql.Append(" from " + databaseprefix + "weixin_request_rule ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,account_id,name,keywords,request_type,response_type,is_like_query,is_default,sort_id,add_time ");
            strSql.Append(" FROM " + databaseprefix + "weixin_request_rule ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "weixin_request_rule");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
		#endregion

        #region 扩展方法================================
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "weixin_request_rule set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Model.weixin_request_rule GetRequestTypeModel(int request_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,account_id,name,keywords,request_type,response_type,is_like_query,is_default,sort_id,add_time");
            strSql.Append(" from " + databaseprefix + "weixin_request_rule");
            strSql.Append(" where request_type=@request_type");
            SqlParameter[] parameters = {
                    new SqlParameter("@request_type", SqlDbType.Int,4)};
            parameters[0].Value = request_type;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.weixin_request_rule DataRowToModel(DataRow row)
        {
            Model.weixin_request_rule model = new Model.weixin_request_rule();
            if (row != null)
            {
                #region 主表信息======================
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["account_id"] != null && row["account_id"].ToString() != "")
                {
                    model.account_id = int.Parse(row["account_id"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["keywords"] != null)
                {
                    model.keywords = row["keywords"].ToString();
                }
                if (row["request_type"] != null && row["request_type"].ToString() != "")
                {
                    model.request_type = int.Parse(row["request_type"].ToString());
                }
                if (row["response_type"] != null && row["response_type"].ToString() != "")
                {
                    model.response_type = int.Parse(row["response_type"].ToString());
                }
                if (row["is_like_query"] != null && row["is_like_query"].ToString() != "")
                {
                    model.is_like_query = int.Parse(row["is_like_query"].ToString());
                }
                if (row["is_default"] != null && row["is_default"].ToString() != "")
                {
                    model.is_default = int.Parse(row["is_default"].ToString());
                }
                if (row["sort_id"] != null && row["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(row["sort_id"].ToString());
                }
                if (row["add_time"] != null && row["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(row["add_time"].ToString());
                }
                #endregion

                #region 子表信息======================
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select id,account_id,rule_id,title,content,link_url,img_url,media_url,meida_hd_url,sort_id,add_time");
                strSql2.Append(" from " + databaseprefix + "weixin_request_content");
                strSql2.Append(" where rule_id=@rule_id");
                SqlParameter[] parameters2 = {
					new SqlParameter("@rule_id", SqlDbType.Int,4)};
                parameters2[0].Value = model.id;

                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    List<Model.weixin_request_content> ls = new List<Model.weixin_request_content>();
                    for (int n = 0; n < ds2.Tables[0].Rows.Count; n++)
                    {
                        Model.weixin_request_content modelt = new Model.weixin_request_content();
                        if (ds2.Tables[0].Rows[n]["id"] != null && ds2.Tables[0].Rows[n]["id"].ToString() != "")
                        {
                            modelt.id = int.Parse(ds2.Tables[0].Rows[n]["id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["account_id"] != null && ds2.Tables[0].Rows[n]["account_id"].ToString() != "")
                        {
                            modelt.account_id = int.Parse(ds2.Tables[0].Rows[n]["account_id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["rule_id"] != null && ds2.Tables[0].Rows[n]["rule_id"].ToString() != "")
                        {
                            modelt.rule_id = int.Parse(ds2.Tables[0].Rows[n]["rule_id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["title"] != null)
                        {
                            modelt.title = ds2.Tables[0].Rows[n]["title"].ToString();
                        }
                        if (ds2.Tables[0].Rows[n]["content"] != null)
                        {
                            modelt.content = ds2.Tables[0].Rows[n]["content"].ToString();
                        }
                        if (ds2.Tables[0].Rows[n]["link_url"] != null)
                        {
                            modelt.link_url = ds2.Tables[0].Rows[n]["link_url"].ToString();
                        }
                        if (ds2.Tables[0].Rows[n]["img_url"] != null)
                        {
                            modelt.img_url = ds2.Tables[0].Rows[n]["img_url"].ToString();
                        }
                        if (ds2.Tables[0].Rows[n]["media_url"] != null)
                        {
                            modelt.media_url = ds2.Tables[0].Rows[n]["media_url"].ToString();
                        }
                        if (ds2.Tables[0].Rows[n]["meida_hd_url"] != null)
                        {
                            modelt.meida_hd_url = ds2.Tables[0].Rows[n]["meida_hd_url"].ToString();
                        }
                        if (ds2.Tables[0].Rows[n]["sort_id"] != null && ds2.Tables[0].Rows[n]["sort_id"].ToString() != "")
                        {
                            modelt.sort_id = int.Parse(ds2.Tables[0].Rows[n]["sort_id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["add_time"] != null && ds2.Tables[0].Rows[n]["add_time"].ToString() != "")
                        {
                            modelt.add_time = DateTime.Parse(ds2.Tables[0].Rows[n]["add_time"].ToString());
                        }
                        ls.Add(modelt);
                    }
                    model.contents = ls;
                }
                #endregion
            }
            return model;
        }
        #endregion

        #region 微信通讯方法============================
        /// <summary>
        /// 得到规则ID以及回复类型
        /// </summary>
        public int GetRuleIdAndResponseType(string strWhere, out int response_type)
        {
            int rule_id = 0;
            response_type = 0;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,response_type from " + databaseprefix + "weixin_request_rule");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }
            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString());

            while (sr.Read())
            {
                rule_id = int.Parse(sr["id"].ToString());
                response_type = int.Parse(sr["response_type"].ToString());
            }
            sr.Close();

            return rule_id;
        }

        /// <summary>
        /// 得到关健字查询的规则ID及回复类型(如需提高效率可使用存储过程)
        /// </summary>
        public int GetKeywordsRuleId(string keywords, out int response_type)
        {
            int rule_id = 0;
            //精确匹配
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("select top 1 id,response_type from " + databaseprefix + "weixin_request_rule");
            strSql3.Append(" where request_type=1");
            strSql3.Append(" and(keywords like '" + keywords + "|%' or keywords='%|" + keywords + "' or keywords like '%|" + keywords + "|%' or keywords='" + keywords + "')");
            strSql3.Append(" order by sort_id asc,add_time desc");
            DataSet ds3 = DbHelperSQL.Query(strSql3.ToString());
            if (ds3.Tables[0].Rows.Count > 0)
            {
                rule_id = int.Parse(ds3.Tables[0].Rows[0][0].ToString());
                response_type = int.Parse(ds3.Tables[0].Rows[0][1].ToString());
                return rule_id;
            }
            //模糊匹配
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("select top 1 id,response_type from " + databaseprefix + "weixin_request_rule");
            strSql2.Append(" where request_type=1 and keywords like '%" + keywords + "%'");
            strSql2.Append(" order by sort_id asc,add_time desc");
            DataSet ds2 = DbHelperSQL.Query(strSql2.ToString());
            if (ds2.Tables[0].Rows.Count > 0)
            {
                rule_id = int.Parse(ds2.Tables[0].Rows[0][0].ToString());
                response_type = int.Parse(ds2.Tables[0].Rows[0][1].ToString());
                return rule_id;
            }
            //默认回复
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("select top 1 id,response_type from " + databaseprefix + "weixin_request_rule");
            strSql1.Append(" where request_type=0");
            strSql1.Append(" order by sort_id asc,add_time desc");
            DataSet ds1 = DbHelperSQL.Query(strSql1.ToString());
            if (ds1.Tables[0].Rows.Count > 0)
            {
                rule_id = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                response_type = int.Parse(ds1.Tables[0].Rows[0][1].ToString());
                return rule_id;
            }
            response_type = 0;
            return rule_id;
        }
        #endregion
    }
}

