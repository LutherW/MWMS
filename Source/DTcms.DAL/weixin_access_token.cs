using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;

namespace DTcms.DAL
{
	/// <summary>
    /// 数据访问类:账户存储AccessToKen值
	/// </summary>
	public partial class weixin_access_token
	{
        private string databaseprefix; //数据库表名前缀
        public weixin_access_token(string _databaseprefix)
		{
            databaseprefix = _databaseprefix;
        }

        #region 基本方法================================
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "weixin_access_token");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.weixin_access_token model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "weixin_access_token(");
			strSql.Append("account_id,access_token,expires_in,count,add_time)");
			strSql.Append(" values (");
			strSql.Append("@account_id,@access_token,@expires_in,@count,@add_time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@account_id", SqlDbType.Int,4),
					new SqlParameter("@access_token", SqlDbType.NVarChar,1000),
					new SqlParameter("@expires_in", SqlDbType.Int,4),
					new SqlParameter("@count", SqlDbType.Int,4),
					new SqlParameter("@add_time", SqlDbType.DateTime)};
			parameters[0].Value = model.account_id;
			parameters[1].Value = model.access_token;
			parameters[2].Value = model.expires_in;
			parameters[3].Value = model.count;
			parameters[4].Value = model.add_time;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.weixin_access_token model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update " + databaseprefix + "weixin_access_token set ");
			strSql.Append("account_id=@account_id,");
			strSql.Append("access_token=@access_token,");
			strSql.Append("expires_in=@expires_in,");
			strSql.Append("count=@count,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@account_id", SqlDbType.Int,4),
					new SqlParameter("@access_token", SqlDbType.NVarChar,1000),
					new SqlParameter("@expires_in", SqlDbType.Int,4),
					new SqlParameter("@count", SqlDbType.Int,4),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.account_id;
			parameters[1].Value = model.access_token;
			parameters[2].Value = model.expires_in;
			parameters[3].Value = model.count;
			parameters[4].Value = model.add_time;
			parameters[5].Value = model.id;

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
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
            int rows = DbHelperSQL.ExecuteSql("delete from " + databaseprefix + "weixin_access_token");
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
		public Model.weixin_access_token GetModel()
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select top 1 id,account_id,access_token,expires_in,count,add_time from " + databaseprefix + "weixin_access_token");
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}
		#endregion

        #region 扩展方法================================
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.weixin_access_token DataRowToModel(DataRow row)
        {
            Model.weixin_access_token model = new Model.weixin_access_token();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["account_id"] != null && row["account_id"].ToString() != "")
                {
                    model.account_id = int.Parse(row["account_id"].ToString());
                }
                if (row["access_token"] != null)
                {
                    model.access_token = row["access_token"].ToString();
                }
                if (row["expires_in"] != null && row["expires_in"].ToString() != "")
                {
                    model.expires_in = int.Parse(row["expires_in"].ToString());
                }
                if (row["count"] != null && row["count"].ToString() != "")
                {
                    model.count = int.Parse(row["count"].ToString());
                }
                if (row["add_time"] != null && row["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(row["add_time"].ToString());
                }
            }
            return model;
        }
        #endregion
    }
}

