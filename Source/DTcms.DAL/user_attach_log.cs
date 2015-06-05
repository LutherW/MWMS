﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	/// <summary>
	/// 数据访问类:user_attach_log
	/// </summary>
	public partial class user_attach_log
	{
        private string databaseprefix; //数据库表名前缀
        public user_attach_log(string _databaseprefix)
		{
            databaseprefix = _databaseprefix;
        }

        #region 基本方法==============================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "user_attach_log");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.user_attach_log model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "user_attach_log(");
			strSql.Append("user_id,user_name,attach_id,file_name,add_time)");
			strSql.Append(" values (");
			strSql.Append("@user_id,@user_name,@attach_id,@file_name,@add_time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@attach_id", SqlDbType.Int,4),
					new SqlParameter("@file_name", SqlDbType.NVarChar,255),
					new SqlParameter("@add_time", SqlDbType.DateTime)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.user_name;
			parameters[2].Value = model.attach_id;
			parameters[3].Value = model.file_name;
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
		public bool Update(Model.user_attach_log model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update " + databaseprefix + "user_attach_log set ");
			strSql.Append("user_id=@user_id,");
			strSql.Append("user_name=@user_name,");
			strSql.Append("attach_id=@attach_id,");
			strSql.Append("file_name=@file_name,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@attach_id", SqlDbType.Int,4),
					new SqlParameter("@file_name", SqlDbType.NVarChar,255),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.user_name;
			parameters[2].Value = model.attach_id;
			parameters[3].Value = model.file_name;
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
		public bool Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "user_attach_log ");
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
		public Model.user_attach_log GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select top 1 id,user_id,user_name,attach_id,file_name,add_time from " + databaseprefix + "user_attach_log ");
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,user_id,user_name,attach_id,file_name,add_time ");
            strSql.Append(" FROM " + databaseprefix + "user_attach_log ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
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
			strSql.Append(" id,user_id,user_name,attach_id,file_name,add_time ");
            strSql.Append(" FROM " + databaseprefix + "user_attach_log ");
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
            strSql.Append("select * FROM " + databaseprefix + "user_attach_log");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
		#endregion

        #region 扩展方法==============================
        /// <summary>
        /// 将对象转换为实体
        /// </summary>
        public Model.user_attach_log DataRowToModel(DataRow row)
        {
            Model.user_attach_log model = new Model.user_attach_log();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["user_id"] != null && row["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(row["user_id"].ToString());
                }
                if (row["user_name"] != null)
                {
                    model.user_name = row["user_name"].ToString();
                }
                if (row["attach_id"] != null && row["attach_id"].ToString() != "")
                {
                    model.attach_id = int.Parse(row["attach_id"].ToString());
                }
                if (row["file_name"] != null)
                {
                    model.file_name = row["file_name"].ToString();
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

