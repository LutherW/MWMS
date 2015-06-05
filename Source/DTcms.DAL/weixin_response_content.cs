using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	/// <summary>
    /// 数据访问类:公众平台回复信息
	/// </summary>
	public partial class weixin_response_content
	{
        private string databaseprefix; //数据库表名前缀
        public weixin_response_content(string _databaseprefix)
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
            strSql.Append("select count(1) from " + databaseprefix + "weixin_response_content");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.weixin_response_content model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "weixin_response_content(");
			strSql.Append("account_id,openid,request_type,request_content,response_type,reponse_content,create_time,xml_content,add_time)");
			strSql.Append(" values (");
			strSql.Append("@account_id,@openid,@request_type,@request_content,@response_type,@reponse_content,@create_time,@xml_content,@add_time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@account_id", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.NVarChar,100),
					new SqlParameter("@request_type", SqlDbType.NVarChar,50),
					new SqlParameter("@request_content", SqlDbType.NVarChar,2000),
					new SqlParameter("@response_type", SqlDbType.NVarChar,50),
					new SqlParameter("@reponse_content", SqlDbType.NVarChar,2000),
					new SqlParameter("@create_time", SqlDbType.NVarChar,50),
					new SqlParameter("@xml_content", SqlDbType.NVarChar,2000),
					new SqlParameter("@add_time", SqlDbType.DateTime)};
			parameters[0].Value = model.account_id;
			parameters[1].Value = model.openid;
			parameters[2].Value = model.request_type;
			parameters[3].Value = model.request_content;
			parameters[4].Value = model.response_type;
			parameters[5].Value = model.reponse_content;
			parameters[6].Value = model.create_time;
			parameters[7].Value = model.xml_content;
			parameters[8].Value = model.add_time;

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
		public bool Update(Model.weixin_response_content model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update " + databaseprefix + "weixin_response_content set ");
			strSql.Append("account_id=@account_id,");
			strSql.Append("openid=@openid,");
			strSql.Append("request_type=@request_type,");
			strSql.Append("request_content=@request_content,");
			strSql.Append("response_type=@response_type,");
			strSql.Append("reponse_content=@reponse_content,");
			strSql.Append("create_time=@create_time,");
			strSql.Append("xml_content=@xml_content,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@account_id", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.NVarChar,100),
					new SqlParameter("@request_type", SqlDbType.NVarChar,50),
					new SqlParameter("@request_content", SqlDbType.NVarChar,2000),
					new SqlParameter("@response_type", SqlDbType.NVarChar,50),
					new SqlParameter("@reponse_content", SqlDbType.NVarChar,2000),
					new SqlParameter("@create_time", SqlDbType.NVarChar,50),
					new SqlParameter("@xml_content", SqlDbType.NVarChar,2000),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.account_id;
			parameters[1].Value = model.openid;
			parameters[2].Value = model.request_type;
			parameters[3].Value = model.request_content;
			parameters[4].Value = model.response_type;
			parameters[5].Value = model.reponse_content;
			parameters[6].Value = model.create_time;
			parameters[7].Value = model.xml_content;
			parameters[8].Value = model.add_time;
			parameters[9].Value = model.id;

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
		public bool Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "weixin_response_content ");
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
		public Model.weixin_response_content GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,account_id,openid,request_type,request_content,response_type,reponse_content,create_time,xml_content,add_time");
            strSql.Append(" from " + databaseprefix + "weixin_response_content ");
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
			strSql.Append(" id,account_id,openid,request_type,request_content,response_type,reponse_content,create_time,xml_content,add_time ");
            strSql.Append(" FROM " + databaseprefix + "weixin_response_content");
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
            strSql.Append("select * FROM " + databaseprefix + "weixin_response_content");
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
        /// 得到一个对象实体
        /// </summary>
        public Model.weixin_response_content DataRowToModel(DataRow row)
        {
            DTcms.Model.weixin_response_content model = new Model.weixin_response_content();
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
                if (row["openid"] != null)
                {
                    model.openid = row["openid"].ToString();
                }
                if (row["request_type"] != null)
                {
                    model.request_type = row["request_type"].ToString();
                }
                if (row["request_content"] != null)
                {
                    model.request_content = row["request_content"].ToString();
                }
                if (row["response_type"] != null)
                {
                    model.response_type = row["response_type"].ToString();
                }
                if (row["reponse_content"] != null)
                {
                    model.reponse_content = row["reponse_content"].ToString();
                }
                if (row["create_time"] != null)
                {
                    model.create_time = row["create_time"].ToString();
                }
                if (row["xml_content"] != null)
                {
                    model.xml_content = row["xml_content"].ToString();
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

