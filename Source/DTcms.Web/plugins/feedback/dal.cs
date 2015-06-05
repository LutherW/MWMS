using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.Web.Plugin.Feedback.DAL
{
	/// <summary>
	/// 数据访问类:在线留言
	/// </summary>
	public partial class feedback
	{
        private string databaseprefix; //数据库表名前缀
        public feedback(string _databaseprefix)
		{
            databaseprefix = _databaseprefix;
        }

		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "feedback");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.feedback model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "feedback(");
            strSql.Append("site_path,title,content,user_name,user_tel,user_qq,user_email,add_time,is_lock)");
			strSql.Append(" values (");
            strSql.Append("@site_path,@title,@content,@user_name,@user_tel,@user_qq,@user_email,@add_time,@is_lock)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
                    new SqlParameter("@site_path", SqlDbType.NVarChar,100),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@user_tel", SqlDbType.NVarChar,30),
					new SqlParameter("@user_qq", SqlDbType.NVarChar,30),
					new SqlParameter("@user_email", SqlDbType.NVarChar,100),
					new SqlParameter("@add_time", SqlDbType.DateTime),
                    new SqlParameter("@is_lock", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.site_path;
            parameters[1].Value = model.title;
			parameters[2].Value = model.content;
			parameters[3].Value = model.user_name;
			parameters[4].Value = model.user_tel;
			parameters[5].Value = model.user_qq;
			parameters[6].Value = model.user_email;
			parameters[7].Value = model.add_time;
            parameters[8].Value = model.is_lock;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "feedback set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.feedback model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "feedback set ");
            strSql.Append("site_path=@site_path,");
            strSql.Append("title=@title,");
            strSql.Append("content=@content,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("user_tel=@user_tel,");
            strSql.Append("user_qq=@user_qq,");
            strSql.Append("user_email=@user_email,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("reply_content=@reply_content,");
            strSql.Append("reply_time=@reply_time,");
            strSql.Append("is_lock=@is_lock");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@site_path", SqlDbType.NVarChar,100),
                    new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@user_tel", SqlDbType.NVarChar,30),
					new SqlParameter("@user_qq", SqlDbType.NVarChar,30),
					new SqlParameter("@user_email", SqlDbType.NVarChar,100),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@reply_content", SqlDbType.NText),
					new SqlParameter("@reply_time", SqlDbType.DateTime),
					new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.site_path;
            parameters[1].Value = model.title;
            parameters[2].Value = model.content;
            parameters[3].Value = model.user_name;
            parameters[4].Value = model.user_tel;
            parameters[5].Value = model.user_qq;
            parameters[6].Value = model.user_email;
            parameters[7].Value = model.add_time;
            parameters[8].Value = model.reply_content;
            parameters[9].Value = model.reply_time;
            parameters[10].Value = model.is_lock;
            parameters[11].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "feedback ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
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
        public Model.feedback GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,site_path,title,content,user_name,user_tel,user_qq,user_email,add_time,reply_content,reply_time,is_lock");
            strSql.Append(" from " + databaseprefix + "feedback ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.feedback model = new Model.feedback();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["site_path"] != null && ds.Tables[0].Rows[0]["site_path"].ToString() != "")
                {
                    model.site_path = ds.Tables[0].Rows[0]["site_path"].ToString();
                }
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["content"] != null && ds.Tables[0].Rows[0]["content"].ToString() != "")
                {
                    model.content = ds.Tables[0].Rows[0]["content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_name"] != null && ds.Tables[0].Rows[0]["user_name"].ToString() != "")
                {
                    model.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_tel"] != null && ds.Tables[0].Rows[0]["user_tel"].ToString() != "")
                {
                    model.user_tel = ds.Tables[0].Rows[0]["user_tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_qq"] != null && ds.Tables[0].Rows[0]["user_qq"].ToString() != "")
                {
                    model.user_qq = ds.Tables[0].Rows[0]["user_qq"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_email"] != null && ds.Tables[0].Rows[0]["user_email"].ToString() != "")
                {
                    model.user_email = ds.Tables[0].Rows[0]["user_email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["reply_content"] != null && ds.Tables[0].Rows[0]["reply_content"].ToString() != "")
                {
                    model.reply_content = ds.Tables[0].Rows[0]["reply_content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["reply_time"] != null && ds.Tables[0].Rows[0]["reply_time"].ToString() != "")
                {
                    model.reply_time = DateTime.Parse(ds.Tables[0].Rows[0]["reply_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_lock"] != null && ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,site_path,title,content,user_name,user_tel,user_qq,user_email,add_time,reply_content,reply_time,is_lock ");
            strSql.Append(" FROM " + databaseprefix + "feedback ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by add_time desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "feedback");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

		#endregion  Method
	}
}

