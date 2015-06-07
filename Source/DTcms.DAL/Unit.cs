using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
namespace DTcms.DAL
{
    //Unit
    public partial class Unit
    {

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Unit");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.Unit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Unit(");
            strSql.Append("Name,Remark");
            strSql.Append(") values (");
            strSql.Append("@Name,@Remark");
            strSql.Append(") ");

            SqlParameter[] parameters = {
       
                        new SqlParameter("@Name", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };


            parameters[0].Value = model.Name;
            parameters[1].Value = model.Remark;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.Unit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Unit set ");

            strSql.Append(" Name = @Name , ");
            strSql.Append(" Remark = @Remark  ");
            strSql.Append(" where Id=@Id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Remark;
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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Unit ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
            parameters[0].Value = Id;


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
        public DTcms.Model.Unit GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Name, Remark  ");
            strSql.Append("  from Unit ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
            parameters[0].Value = Id;


            DTcms.Model.Unit model = new DTcms.Model.Unit();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();

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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Unit ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
            strSql.Append(" * ");
            strSql.Append(" FROM Unit ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

