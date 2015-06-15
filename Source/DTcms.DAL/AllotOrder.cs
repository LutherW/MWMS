using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.DAL
{
    //AllotOrder
    public partial class AllotOrder
    {

        public bool Exists(int Id, int SourceStoreId, int PurposeStoreId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AllotOrder");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id and  ");
            strSql.Append(" SourceStoreId = @SourceStoreId and  ");
            strSql.Append(" PurposeStoreId = @PurposeStoreId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@SourceStoreId", SqlDbType.Int,4),
					new SqlParameter("@PurposeStoreId", SqlDbType.Int,4)			};
            parameters[0].Value = Id;
            parameters[1].Value = SourceStoreId;
            parameters[2].Value = PurposeStoreId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AllotOrder");
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
        public bool Add(DTcms.Model.AllotOrder model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    //try
                    //{
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into AllotOrder(");
                        strSql.Append("AllotTime,Status,Remark,CreateTime,Admin");
                        strSql.Append(") values (");
                        strSql.Append("@AllotTime,@Status,@Remark,@CreateTime,@Admin");
                        strSql.Append(") ");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
			                        new SqlParameter("@AllotTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@Status", SqlDbType.Int,4) ,            
                                    new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@Admin", SqlDbType.VarChar,254)             
                        };

                        parameters[0].Value = model.AllotTime;
                        parameters[1].Value = model.Status;
                        parameters[2].Value = model.Remark;
                        parameters[3].Value = model.CreateTime;
                        parameters[4].Value = model.Admin;

                        object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务
                        model.Id = Convert.ToInt32(obj);

 
                        #region 调拨货物====================
                        if (model.AllotGoods.Count > 0)
                        {
                            AllotGoods allotGoodsDAL = new AllotGoods();
                            foreach (Model.AllotGoods allotGoods in model.AllotGoods)
                            {
                                allotGoods.AllotOrderId = model.Id;
                                allotGoodsDAL.Add(conn, trans, allotGoods);
                            }
                        }
                        #endregion

                        trans.Commit();
                    //}
                    //catch
                    //{
                    //    trans.Rollback();
                    //    return false;
                    //}
                }
            }

            return model.Id > 0;

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.AllotOrder model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    //try
                    //{
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update AllotOrder set ");
                        strSql.Append(" Remark = @Remark , ");
                        strSql.Append(" AllotTime = @AllotTime , ");
                        strSql.Append(" Admin = @Admin  ");
                        strSql.Append(" where Id=@Id ");

                        SqlParameter[] parameters = {
			                        new SqlParameter("@Id", SqlDbType.Int,4) ,            
                                    new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@AllotTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@Admin", SqlDbType.VarChar,254)             
              
                        };

                        parameters[0].Value = model.Id;
                        parameters[1].Value = model.Remark;
                        parameters[2].Value = model.AllotTime;
                        parameters[3].Value = model.Admin;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);


                        #region 调拨货物====================
                        AllotGoods allotGoodsDAL = new AllotGoods();

                        allotGoodsDAL.Delete(conn, trans, model.Id);

                        if (model.AllotGoods.Count > 0)
                        {
                            foreach (Model.AllotGoods allotGoods in model.AllotGoods)
                            {
                                allotGoods.AllotOrderId = model.Id;
                                allotGoodsDAL.Add(conn, trans, allotGoods);
                            }
                        }
                        #endregion


                        trans.Commit();
                    //}
                    //catch
                    //{
                    //    trans.Rollback();
                    //    return false;
                    //}
                }
            }

            return true;
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AllotOrder ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AllotOrder ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public DTcms.Model.AllotOrder GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, SourceStoreId, PurposeStoreId, Remark, CreateTime, Admin  ");
            strSql.Append("  from AllotOrder ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            DTcms.Model.AllotOrder model = new DTcms.Model.AllotOrder();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                model.Admin = ds.Tables[0].Rows[0]["Admin"].ToString();

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
            strSql.Append(" FROM AllotOrder ");
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
            strSql.Append(" FROM AllotOrder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select A.* ");
            strSql.Append("from AllotOrder A ");
            strSql.Append("where A.Id > 0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}

