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
	/// 数据访问类:规格
	/// </summary>
	public partial class article_spec
	{
        private string databaseprefix; //数据库表名前缀
        public article_spec(string _databaseprefix)
		{
            databaseprefix = _databaseprefix;
        }

        #region 基本方法========================
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "article_spec");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.article_spec model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "article_spec(");
			strSql.Append("parent_id,title,remark,sort_id)");
			strSql.Append(" values (");
			strSql.Append("@parent_id,@title,@remark,@sort_id)");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@parent_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@remark", SqlDbType.NVarChar,255),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
                    new SqlParameter("@ReturnValue",SqlDbType.Int)};
			parameters[0].Value = model.parent_id;
			parameters[1].Value = model.title;
			parameters[2].Value = model.remark;
			parameters[3].Value = model.sort_id;
            parameters[4].Direction = ParameterDirection.Output;
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //规格值列表
            if (model.values != null)
            {
                 StringBuilder strSql2;
                 foreach (Model.article_spec_value modelt in model.values)
                 {
                     strSql2 = new StringBuilder();
                     strSql2.Append("insert into " + databaseprefix + "article_spec(");
                     strSql2.Append("parent_id,title,img_url,sort_id)");
                     strSql2.Append(" values (");
                     strSql2.Append("@parent_id,@title,@img_url,@sort_id)");
                     SqlParameter[] parameters2 = {
                            new SqlParameter("@parent_id", SqlDbType.Int,4),
					        new SqlParameter("@title", SqlDbType.NVarChar,100),
					        new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					        new SqlParameter("@sort_id", SqlDbType.Int,4)};
                     parameters2[0].Direction = ParameterDirection.InputOutput;
                     parameters2[1].Value = modelt.title;
                     parameters2[2].Value = modelt.img_url;
                     parameters2[3].Value = modelt.sort_id;
                     cmd = new CommandInfo(strSql2.ToString(), parameters2);
                     sqllist.Add(cmd);
                 }
            }
            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[4].Value;
		}

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "article_spec set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.article_spec model)
		{
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        #region 主表信息============================
                        StringBuilder strSql=new StringBuilder();
                        strSql.Append("update " + databaseprefix + "article_spec set ");
			            strSql.Append("parent_id=@parent_id,");
			            strSql.Append("title=@title,");
			            strSql.Append("remark=@remark,");
			            strSql.Append("sort_id=@sort_id");
			            strSql.Append(" where id=@id");
			            SqlParameter[] parameters = {
					            new SqlParameter("@parent_id", SqlDbType.Int,4),
					            new SqlParameter("@title", SqlDbType.NVarChar,100),
					            new SqlParameter("@remark", SqlDbType.NVarChar,255),
					            new SqlParameter("@sort_id", SqlDbType.Int,4),
					            new SqlParameter("@id", SqlDbType.Int,4)};
			            parameters[0].Value = model.parent_id;
			            parameters[1].Value = model.title;
			            parameters[2].Value = model.remark;
			            parameters[3].Value = model.sort_id;
			            parameters[4].Value = model.id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
                        #endregion

                        #region 修改规格值==========================
                        //删除已删除的规格值
                        DeleteList(conn, trans, model.values, model.id);
                        //添加/修改规格值
                        if (model.values != null)
                        {
                            StringBuilder strSql2;
                            foreach (Model.article_spec_value modelt in model.values)
                            {
                                strSql2 = new StringBuilder();
                                if (modelt.id > 0)
                                {
                                    strSql2.Append("update " + databaseprefix + "article_spec set ");
                                    strSql2.Append("parent_id=@parent_id,");
                                    strSql2.Append("title=@title,");
                                    strSql2.Append("img_url=@img_url,");
                                    strSql2.Append("sort_id=@sort_id");
                                    strSql2.Append(" where id=@id");
                                    SqlParameter[] parameters2 = {
					                        new SqlParameter("@parent_id", SqlDbType.Int,4),
					                        new SqlParameter("@title", SqlDbType.NVarChar,100),
					                        new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					                        new SqlParameter("@sort_id", SqlDbType.Int,4),
					                        new SqlParameter("@id", SqlDbType.Int,4)};
                                    parameters2[0].Value = modelt.parent_id;
                                    parameters2[1].Value = modelt.title;
                                    parameters2[2].Value = modelt.img_url;
                                    parameters2[3].Value = modelt.sort_id;
                                    parameters2[4].Value = modelt.id;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                                }
                                else
                                {
                                    strSql2 = new StringBuilder();
                                    strSql2.Append("insert into " + databaseprefix + "article_spec(");
                                    strSql2.Append("parent_id,title,img_url,sort_id)");
                                    strSql2.Append(" values (");
                                    strSql2.Append("@parent_id,@title,@img_url,@sort_id)");
                                    SqlParameter[] parameters2 = {
                                            new SqlParameter("@parent_id", SqlDbType.Int,4),
					                        new SqlParameter("@title", SqlDbType.NVarChar,100),
					                        new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					                        new SqlParameter("@sort_id", SqlDbType.Int,4)};
                                    parameters2[0].Value = modelt.parent_id;
                                    parameters2[1].Value = modelt.title;
                                    parameters2[2].Value = modelt.img_url;
                                    parameters2[3].Value = modelt.sort_id;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                                }
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
            //删除规格值
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("delete from " + databaseprefix + "article_spec");
            strSql1.Append(" where parent_id=@parent_id");
            SqlParameter[] parameters1 = {
					new SqlParameter("@parent_id", SqlDbType.Int,4)};
            parameters1[0].Value = id;
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql1.ToString(), parameters1);
            sqllist.Add(cmd);

            //删除规格
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "article_spec ");
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
        public Model.article_spec GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,parent_id,title,remark,sort_id from " + databaseprefix + "article_spec");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.article_spec model = new Model.article_spec();
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
        public Model.article_spec DataRowToModel(DataRow row)
        {
            Model.article_spec model = new Model.article_spec();
            if (row != null)
            {
                #region 主表信息======================
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["parent_id"] != null && row["parent_id"].ToString() != "")
                {
                    model.parent_id = int.Parse(row["parent_id"].ToString());
                }
                if (row["title"] != null)
                {
                    model.title = row["title"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["sort_id"] != null && row["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(row["sort_id"].ToString());
                }
                #endregion

                #region 子表信息======================
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select id,parent_id,title,img_url,sort_id from " + databaseprefix + "article_spec");
                strSql2.Append(" where parent_id=@parent_id ");
                SqlParameter[] parameters2 = {
					    new SqlParameter("@parent_id", SqlDbType.Int,4)};
                parameters2[0].Value = model.id;
                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    List<Model.article_spec_value> ls = new List<Model.article_spec_value>();
                    for (int n = 0; n < ds2.Tables[0].Rows.Count; n++)
                    {
                        Model.article_spec_value modelt = new Model.article_spec_value();
                        if (ds2.Tables[0].Rows[n]["id"] != null && ds2.Tables[0].Rows[n]["id"].ToString() != "")
                        {
                            modelt.id = int.Parse(ds2.Tables[0].Rows[n]["id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["parent_id"] != null && ds2.Tables[0].Rows[n]["parent_id"].ToString() != "")
                        {
                            modelt.parent_id = int.Parse(ds2.Tables[0].Rows[n]["parent_id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["title"] != null)
                        {
                            modelt.title = ds2.Tables[0].Rows[n]["title"].ToString();
                        }
                        if (ds2.Tables[0].Rows[n]["img_url"] != null)
                        {
                            modelt.img_url = ds2.Tables[0].Rows[n]["img_url"].ToString();
                        }
                        if (ds2.Tables[0].Rows[n]["sort_id"] != null && ds2.Tables[0].Rows[n]["sort_id"].ToString() != "")
                        {
                            modelt.sort_id = int.Parse(ds2.Tables[0].Rows[n]["sort_id"].ToString());
                        }
                        ls.Add(modelt);
                    }
                    model.values = ls;
                }
                #endregion
            }
            return model;
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
			strSql.Append(" id,parent_id,title,img_url,remark,sort_id ");
            strSql.Append(" FROM " + databaseprefix + "article_spec");
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
            strSql.Append("select * FROM " + databaseprefix + "article_spec");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
		#endregion

        #region 扩展方法========================
        /// <summary>
        /// 根据频道和分类ID筛选出规格(慎用)
        /// </summary>
        /// <param name="channel_name">频道名称</param>
        /// <param name="category_id">类别ID</param>
        /// <returns>DataSet</returns>
        public DataSet GetParentList(string channel_name, int category_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,parent_id,title,img_url,remark,sort_id from " + databaseprefix + "article_spec where id in(");
            strSql.Append("select spec_id from " + databaseprefix + "article_goods_spec where parent_id=0 and article_id in(");
            strSql.Append("select id from view_channel_" + channel_name + " where category_id in(");
            strSql.Append("select id from " + databaseprefix + "article_category");
            if (category_id > 0)
            {
                strSql.Append(" where class_list like '%," + category_id + ",%'");
            }
            strSql.Append(")) group by spec_id)");
            strSql.Append(" order by sort_id asc");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 私有方法========================
        /// <summary>
        /// 查找不存在的规格值并删除
        /// </summary>
        private void DeleteList(SqlConnection conn, SqlTransaction trans, List<Model.article_spec_value> models, int parentId)
        {
            StringBuilder idList = new StringBuilder();
            if (models != null)
            {
                foreach (Model.article_spec_value modelt in models)
                {
                    if (modelt.id > 0)
                    {
                        idList.Append(modelt.id + ",");
                    }
                }
                string id_list = Utils.DelLastChar(idList.ToString(), ",");
                if (!string.IsNullOrEmpty(id_list))
                {
                    DbHelperSQL.ExecuteSql(conn, trans, "delete from " + databaseprefix + "article_spec where parent_id=" + parentId + " and id not in(" + id_list + ")");
                }
            }
        }
        #endregion
    }
}

