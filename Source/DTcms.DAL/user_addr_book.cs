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
    /// 数据访问类:用户地址簿
    /// </summary>
    public partial class user_addr_book
    {
        private string databaseprefix; //数据库表名前缀
        public user_addr_book(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region 基本方法============================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "user_addr_book");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id,string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "user_addr_book");
            strSql.Append(" where id=@id and user_name=@user_name");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = id;
            parameters[1].Value = user_name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.user_addr_book model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "user_addr_book(");
            strSql.Append("user_id,user_name,accept_name,area,address,mobile,telphone,email,post_code,is_default,add_time)");
            strSql.Append(" values (");
            strSql.Append("@user_id,@user_name,@accept_name,@area,@address,@mobile,@telphone,@email,@post_code,@is_default,@add_time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@accept_name", SqlDbType.NVarChar,100),
					new SqlParameter("@area", SqlDbType.NVarChar,100),
					new SqlParameter("@address", SqlDbType.NVarChar,500),
					new SqlParameter("@mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@telphone", SqlDbType.NVarChar,30),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
					new SqlParameter("@post_code", SqlDbType.NVarChar,20),
					new SqlParameter("@is_default", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime)};
            parameters[0].Value = model.user_id;
            parameters[1].Value = model.user_name;
            parameters[2].Value = model.accept_name;
            parameters[3].Value = model.area;
            parameters[4].Value = model.address;
            parameters[5].Value = model.mobile;
            parameters[6].Value = model.telphone;
            parameters[7].Value = model.email;
            parameters[8].Value = model.post_code;
            parameters[9].Value = model.is_default;
            parameters[10].Value = model.add_time;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Model.user_addr_book model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "user_addr_book set ");
            strSql.Append("user_id=@user_id,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("accept_name=@accept_name,");
            strSql.Append("area=@area,");
            strSql.Append("address=@address,");
            strSql.Append("mobile=@mobile,");
            strSql.Append("telphone=@telphone,");
            strSql.Append("email=@email,");
            strSql.Append("post_code=@post_code,");
            strSql.Append("is_default=@is_default,");
            strSql.Append("add_time=@add_time");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@accept_name", SqlDbType.NVarChar,100),
					new SqlParameter("@area", SqlDbType.NVarChar,100),
					new SqlParameter("@address", SqlDbType.NVarChar,500),
					new SqlParameter("@mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@telphone", SqlDbType.NVarChar,30),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
					new SqlParameter("@post_code", SqlDbType.NVarChar,20),
					new SqlParameter("@is_default", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.user_id;
            parameters[1].Value = model.user_name;
            parameters[2].Value = model.accept_name;
            parameters[3].Value = model.area;
            parameters[4].Value = model.address;
            parameters[5].Value = model.mobile;
            parameters[6].Value = model.telphone;
            parameters[7].Value = model.email;
            parameters[8].Value = model.post_code;
            parameters[9].Value = model.is_default;
            parameters[10].Value = model.add_time;
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "user_addr_book ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

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
        /// 根据用户名删除一条数据
        /// </summary>
        public bool Delete(int id, string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "user_addr_book ");
            strSql.Append(" where id=@id and user_name=@user_name");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = id;
            parameters[1].Value = user_name;

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
        /// 得到一个对象实体
        /// </summary>
        public Model.user_addr_book GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,user_id,user_name,accept_name,area,address,mobile,telphone,email,post_code,is_default,add_time");
            strSql.Append(" from " + databaseprefix + "user_addr_book ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,user_id,user_name,accept_name,area,address,mobile,telphone,email,post_code,is_default,add_time ");
            strSql.Append(" FROM " + databaseprefix + "user_addr_book ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by add_time asc,id asc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,user_id,user_name,accept_name,area,address,mobile,telphone,email,post_code,is_default,add_time ");
            strSql.Append(" FROM " + databaseprefix + "user_addr_book ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            strSql.Append("select * FROM " + databaseprefix + "user_addr_book");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        #endregion

        #region 扩展方法============================
        /// <summary>
        /// 返回默认的地址
        /// </summary>
        public Model.user_addr_book GetDefault(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,user_id,user_name,accept_name,area,address,mobile,telphone,email,post_code,is_default,add_time");
            strSql.Append(" from " + databaseprefix + "user_addr_book ");
            strSql.Append(" where user_name=@user_name");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;

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
        /// 设置为默认的收货地址
        /// </summary>
        public void SetDefault(int id, string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "user_addr_book set is_default=0");
            strSql.Append(" where user_name=@user_name");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("update " + databaseprefix + "user_addr_book set is_default=1");
            strSql2.Append(" where id=@id and user_name=@user_name");
            SqlParameter[] parameters2 = {
                    new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters2[0].Value = id;
            parameters2[1].Value = user_name;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.user_addr_book DataRowToModel(DataRow row)
        {
            Model.user_addr_book model = new Model.user_addr_book();
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
                if (row["accept_name"] != null)
                {
                    model.accept_name = row["accept_name"].ToString();
                }
                if (row["area"] != null)
                {
                    model.area = row["area"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["mobile"] != null)
                {
                    model.mobile = row["mobile"].ToString();
                }
                if (row["telphone"] != null)
                {
                    model.telphone = row["telphone"].ToString();
                }
                if (row["email"] != null)
                {
                    model.email = row["email"].ToString();
                }
                if (row["post_code"] != null)
                {
                    model.post_code = row["post_code"].ToString();
                }
                if (row["is_default"] != null && row["is_default"].ToString() != "")
                {
                    model.is_default = int.Parse(row["is_default"].ToString());
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