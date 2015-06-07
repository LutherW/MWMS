using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.DAL
{
    //Store
    public partial class Store
    {

        public bool Exists(int Id, int StoreDomainId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Store");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id and  ");
            strSql.Append(" StoreDomainId = @StoreDomainId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@StoreDomainId", SqlDbType.Int,4)			};
            parameters[0].Value = Id;
            parameters[1].Value = StoreDomainId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Store");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.Store model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Store(");
            strSql.Append("StoreDomainId,Name,Manager,Address,Remark");
            strSql.Append(") values (");
            strSql.Append("@StoreDomainId,@Name,@Manager,@Address,@Remark");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@StoreDomainId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Manager", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Address", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.StoreDomainId;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Manager;
            parameters[3].Value = model.Address;
            parameters[4].Value = model.Remark;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.Store model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Store set ");
            strSql.Append(" StoreDomainId = @StoreDomainId , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" Manager = @Manager , ");
            strSql.Append(" Address = @Address , ");
            strSql.Append(" Remark = @Remark  ");
            strSql.Append(" where Id=@Id and StoreDomainId=@StoreDomainId  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreDomainId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Manager", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Address", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.StoreDomainId;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Manager;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.Remark;
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
        public bool Delete(int Id, int StoreDomainId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Store ");
            strSql.Append(" where Id=@Id and StoreDomainId=@StoreDomainId ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@StoreDomainId", SqlDbType.Int,4)			};
            parameters[0].Value = Id;
            parameters[1].Value = StoreDomainId;


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

        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Store ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
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
        public DTcms.Model.Store GetModel(int Id, int StoreDomainId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, StoreDomainId, Name, Manager, Address, Remark  ");
            strSql.Append("  from Store ");
            strSql.Append(" where Id=@Id and StoreDomainId=@StoreDomainId ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@StoreDomainId", SqlDbType.Int,4)			};
            parameters[0].Value = Id;
            parameters[1].Value = StoreDomainId;


            DTcms.Model.Store model = new DTcms.Model.Store();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreDomainId"].ToString() != "")
                {
                    model.StoreDomainId = int.Parse(ds.Tables[0].Rows[0]["StoreDomainId"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Manager = ds.Tables[0].Rows[0]["Manager"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        public DTcms.Model.Store GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, StoreDomainId, Name, Manager, Address, Remark  ");
            strSql.Append("  from Store ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;


            DTcms.Model.Store model = new DTcms.Model.Store();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreDomainId"].ToString() != "")
                {
                    model.StoreDomainId = int.Parse(ds.Tables[0].Rows[0]["StoreDomainId"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Manager = ds.Tables[0].Rows[0]["Manager"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
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
            strSql.Append(" FROM Store ");
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
            strSql.Append(" FROM Store ");
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
            strSql.Append("select * FROM Store");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}

