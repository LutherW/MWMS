using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.DAL
{
    //Vehicle
    public partial class Vehicle
    {

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Vehicle");
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
        public bool Add(DTcms.Model.Vehicle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Vehicle(");
            strSql.Append("PlateNumber,Driver,LinkTel,LinkAddress,Remark");
            strSql.Append(") values (");
            strSql.Append("@PlateNumber,@Driver,@LinkTel,@LinkAddress,@Remark");
            strSql.Append(") ");

            SqlParameter[] parameters = {
     
                        new SqlParameter("@PlateNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Driver", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkTel", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.PlateNumber;
            parameters[1].Value = model.Driver;
            parameters[2].Value = model.LinkTel;
            parameters[3].Value = model.LinkAddress;
            parameters[4].Value = model.Remark;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.Vehicle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Vehicle set ");

            strSql.Append(" PlateNumber = @PlateNumber , ");
            strSql.Append(" Driver = @Driver , ");
            strSql.Append(" LinkTel = @LinkTel , ");
            strSql.Append(" LinkAddress = @LinkAddress , ");
            strSql.Append(" Remark = @Remark  ");
            strSql.Append(" where Id=@Id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@PlateNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Driver", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkTel", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.PlateNumber;
            parameters[2].Value = model.Driver;
            parameters[3].Value = model.LinkTel;
            parameters[4].Value = model.LinkAddress;
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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Vehicle ");
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
        public DTcms.Model.Vehicle GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, PlateNumber, Driver, LinkTel, LinkAddress, Remark  ");
            strSql.Append("  from Vehicle ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
            parameters[0].Value = Id;


            DTcms.Model.Vehicle model = new DTcms.Model.Vehicle();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.PlateNumber = ds.Tables[0].Rows[0]["PlateNumber"].ToString();
                model.Driver = ds.Tables[0].Rows[0]["Driver"].ToString();
                model.LinkTel = ds.Tables[0].Rows[0]["LinkTel"].ToString();
                model.LinkAddress = ds.Tables[0].Rows[0]["LinkAddress"].ToString();
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
            strSql.Append(" FROM Vehicle ");
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
            strSql.Append(" FROM Vehicle ");
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
            strSql.Append("select * FROM Vehicle");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}

