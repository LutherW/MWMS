using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.DAL
{
    //Customer
    public partial class Customer
    {

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Customer");
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
        public bool Add(DTcms.Model.Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Customer(");
            strSql.Append("Code,Name,LinkMan,LinkTel,LinkAddress,Email,Fax,Status,Remark");
            strSql.Append(") values (");
            strSql.Append("@Code,@Name,@LinkMan,@LinkTel,@LinkAddress,@Email,@Fax,@Status,@Remark");
            strSql.Append(") ");

            SqlParameter[] parameters = {
         
                        new SqlParameter("@Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkMan", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkTel", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Email", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Fax", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.Code;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.LinkMan;
            parameters[3].Value = model.LinkTel;
            parameters[4].Value = model.LinkAddress;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.Fax;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.Remark;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Customer set ");
            strSql.Append(" Code = @Code , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" LinkMan = @LinkMan , ");
            strSql.Append(" LinkTel = @LinkTel , ");
            strSql.Append(" LinkAddress = @LinkAddress , ");
            strSql.Append(" Email = @Email , ");
            strSql.Append(" Fax = @Fax , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" Remark = @Remark  ");
            strSql.Append(" where Id=@Id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkMan", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkTel", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Email", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Fax", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.LinkMan;
            parameters[4].Value = model.LinkTel;
            parameters[5].Value = model.LinkAddress;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.Fax;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.Remark;
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
            strSql.Append("delete from Customer ");
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
        public DTcms.Model.Customer GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Code, Name, LinkMan, LinkTel, LinkAddress, Email, Fax, Status, Remark  ");
            strSql.Append("  from Customer ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
            parameters[0].Value = Id;


            DTcms.Model.Customer model = new DTcms.Model.Customer();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.LinkMan = ds.Tables[0].Rows[0]["LinkMan"].ToString();
                model.LinkTel = ds.Tables[0].Rows[0]["LinkTel"].ToString();
                model.LinkAddress = ds.Tables[0].Rows[0]["LinkAddress"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Fax = ds.Tables[0].Rows[0]["Fax"].ToString();
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
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
            strSql.Append(" FROM Customer ");
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
            strSql.Append(" FROM Customer ");
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
            strSql.Append("select * FROM Customer");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}

