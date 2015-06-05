using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.Common;
using DTcms.DBUtility;

namespace DTcms.Web.Plugin.Link.DAL
{
	/// <summary>
	/// 数据访问类:link
	/// </summary>
	public partial class link
	{
        private string databaseprefix; //数据库表名前缀
        public link(string _databaseprefix)
		{
            databaseprefix = _databaseprefix;
        }

		#region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "link");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.link model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "link(");
            strSql.Append("site_path,title,user_name,user_tel,email,site_url,img_url,is_image,sort_id,is_red,is_lock,add_time)");
			strSql.Append(" values (");
            strSql.Append("@site_path,@title,@user_name,@user_tel,@email,@site_url,@img_url,@is_image,@sort_id,@is_red,@is_lock,@add_time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
                    new SqlParameter("@site_path", SqlDbType.NVarChar,100),
					new SqlParameter("@title", SqlDbType.NVarChar,255),
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@user_tel", SqlDbType.NVarChar,20),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
					new SqlParameter("@site_url", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@is_image", SqlDbType.Int,4),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@is_red", SqlDbType.TinyInt,1),
					new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime)};
            parameters[0].Value = model.site_path;
            parameters[1].Value = model.title;
			parameters[2].Value = model.user_name;
			parameters[3].Value = model.user_tel;
			parameters[4].Value = model.email;
			parameters[5].Value = model.site_url;
			parameters[6].Value = model.img_url;
			parameters[7].Value = model.is_image;
			parameters[8].Value = model.sort_id;
			parameters[9].Value = model.is_red;
			parameters[10].Value = model.is_lock;
			parameters[11].Value = model.add_time;

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
            strSql.Append("update " + databaseprefix + "link set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.link model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update " + databaseprefix + "link set ");
            strSql.Append("site_path=@site_path,");
			strSql.Append("title=@title,");
			strSql.Append("user_name=@user_name,");
			strSql.Append("user_tel=@user_tel,");
			strSql.Append("email=@email,");
			strSql.Append("site_url=@site_url,");
			strSql.Append("img_url=@img_url,");
			strSql.Append("is_image=@is_image,");
			strSql.Append("sort_id=@sort_id,");
			strSql.Append("is_red=@is_red,");
			strSql.Append("is_lock=@is_lock,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
                    new SqlParameter("@site_path", SqlDbType.NVarChar,100),
					new SqlParameter("@title", SqlDbType.NVarChar,255),
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@user_tel", SqlDbType.NVarChar,20),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
					new SqlParameter("@site_url", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@is_image", SqlDbType.Int,4),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@is_red", SqlDbType.TinyInt,1),
					new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.site_path;
            parameters[1].Value = model.title;
			parameters[2].Value = model.user_name;
			parameters[3].Value = model.user_tel;
			parameters[4].Value = model.email;
			parameters[5].Value = model.site_url;
			parameters[6].Value = model.img_url;
			parameters[7].Value = model.is_image;
			parameters[8].Value = model.sort_id;
			parameters[9].Value = model.is_red;
			parameters[10].Value = model.is_lock;
			parameters[11].Value = model.add_time;
			parameters[12].Value = model.id;

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
            strSql.Append("delete from " + databaseprefix + "link ");
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
		public Model.link GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,site_path,title,user_name,user_tel,email,site_url,img_url,is_image,sort_id,is_red,is_lock,add_time from " + databaseprefix + "link ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Model.link model=new Model.link();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
                if (ds.Tables[0].Rows[0]["site_path"] != null && ds.Tables[0].Rows[0]["site_path"].ToString() != "")
                {
                    model.site_path = ds.Tables[0].Rows[0]["site_path"].ToString();
                }
				if(ds.Tables[0].Rows[0]["title"]!=null && ds.Tables[0].Rows[0]["title"].ToString()!="")
				{
					model.title=ds.Tables[0].Rows[0]["title"].ToString();
				}
				if(ds.Tables[0].Rows[0]["user_name"]!=null && ds.Tables[0].Rows[0]["user_name"].ToString()!="")
				{
					model.user_name=ds.Tables[0].Rows[0]["user_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["user_tel"]!=null && ds.Tables[0].Rows[0]["user_tel"].ToString()!="")
				{
					model.user_tel=ds.Tables[0].Rows[0]["user_tel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["email"]!=null && ds.Tables[0].Rows[0]["email"].ToString()!="")
				{
					model.email=ds.Tables[0].Rows[0]["email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["site_url"]!=null && ds.Tables[0].Rows[0]["site_url"].ToString()!="")
				{
					model.site_url=ds.Tables[0].Rows[0]["site_url"].ToString();
				}
				if(ds.Tables[0].Rows[0]["img_url"]!=null && ds.Tables[0].Rows[0]["img_url"].ToString()!="")
				{
					model.img_url=ds.Tables[0].Rows[0]["img_url"].ToString();
				}
				if(ds.Tables[0].Rows[0]["is_image"]!=null && ds.Tables[0].Rows[0]["is_image"].ToString()!="")
				{
					model.is_image=int.Parse(ds.Tables[0].Rows[0]["is_image"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sort_id"]!=null && ds.Tables[0].Rows[0]["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["is_red"]!=null && ds.Tables[0].Rows[0]["is_red"].ToString()!="")
				{
					model.is_red=int.Parse(ds.Tables[0].Rows[0]["is_red"].ToString());
				}
				if(ds.Tables[0].Rows[0]["is_lock"]!=null && ds.Tables[0].Rows[0]["is_lock"].ToString()!="")
				{
					model.is_lock=int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["add_time"]!=null && ds.Tables[0].Rows[0]["add_time"].ToString()!="")
				{
					model.add_time=DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,site_path,title,user_name,user_tel,email,site_url,img_url,is_image,sort_id,is_red,is_lock,add_time ");
            strSql.Append(" FROM " + databaseprefix + "link ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" id,site_path,title,user_name,user_tel,email,site_url,img_url,is_image,sort_id,is_red,is_lock,add_time ");
            strSql.Append(" FROM " + databaseprefix + "link ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by sort_id asc,add_time desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "link");
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

