using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.DAL
{
    //StoreWaitingGoods
    public partial class StoreWaitingGoods
    {

        public bool Exists(int Id, int GoodsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StoreWaitingGoods");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id and  ");
            strSql.Append(" GoodsId = @GoodsId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@GoodsId", SqlDbType.Int,4)			};
            parameters[0].Value = Id;
            parameters[1].Value = GoodsId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StoreWaitingGoods");
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
        public bool Add(DTcms.Model.StoreWaitingGoods model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into StoreWaitingGoods(");
                        strSql.Append("GoodsId,Status,Remark,CreateTime,StoringTime,Admin");
                        strSql.Append(") values (");
                        strSql.Append("@GoodsId,@Status,@Remark,@CreateTime,@StoringTime,@Admin");
                        strSql.Append(") ");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
			                        new SqlParameter("@GoodsId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@Status", SqlDbType.Int,4) ,            
                                    new SqlParameter("@Remark", SqlDbType.VarChar,254),
                                    new SqlParameter("@CreateTime", SqlDbType.DateTime) , 
                                    new SqlParameter("@StoringTime", SqlDbType.DateTime)  ,
                                    new SqlParameter("@Admin", SqlDbType.VarChar,254)  
                        };

                        parameters[0].Value = model.GoodsId;
                        parameters[1].Value = model.Status;
                        parameters[2].Value = model.Remark;
                        parameters[3].Value = DateTime.Now;
                        parameters[4].Value = model.StoringTime;
                        parameters[5].Value = model.Admin;

                        object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务
                        model.Id = Convert.ToInt32(obj);

                        #region 车辆====================
                        if (model.GoodsVehicles.Count > 0)
                        {
                            StringBuilder strSql2 = new StringBuilder();
                            foreach (Model.StoreInGoodsVehicle goodsVehicle in model.GoodsVehicles)
                            {
                                strSql2.Append("insert into StoreInGoodsVehicle(");
                                strSql2.Append("StoreWaitingGoodsId,VehicleId,Remark,Count");
                                strSql2.Append(") values (");
                                strSql2.Append("@StoreWaitingGoodsId,@VehicleId,@Remark,@Count");
                                strSql2.Append(") ");

                                SqlParameter[] vehicleParameters = {
			                                new SqlParameter("@StoreWaitingGoodsId", SqlDbType.Int,4) ,            
                                            new SqlParameter("@VehicleId", SqlDbType.Int,4) ,            
                                            new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                                            new SqlParameter("@Count", SqlDbType.Decimal,9)             
              
                                };

                                vehicleParameters[0].Value = model.Id;
                                vehicleParameters[1].Value = goodsVehicle.VehicleId;
                                vehicleParameters[2].Value = goodsVehicle.Remark;
                                vehicleParameters[3].Value = goodsVehicle.Count;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), vehicleParameters); //带事务
                            }
                        }
                        #endregion

                        #region 附件====================
                        if (model.Attachs.Count > 0)
                        {
                            StringBuilder strSql3;
                            foreach (Model.Attach attach in model.Attachs)
                            {
                                strSql3 = new StringBuilder();
                                strSql3.Append("insert into Attach(");
                                strSql3.Append("StoreWaitingGoodsId,FilePath,CreateTime,Admin,Remark");
                                strSql3.Append(") values (");
                                strSql3.Append("@StoreWaitingGoodsId,@FilePath,@CreateTime,@Admin,@Remark");
                                strSql3.Append(") ");

                                SqlParameter[] attachParameters = {
                                            new SqlParameter("@StoreWaitingGoodsId", SqlDbType.Int,4) ,            
                                            new SqlParameter("@FilePath", SqlDbType.VarChar,254) ,            
                                            new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                                            new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                                            new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
                                };

                                attachParameters[0].Value = model.Id;
                                attachParameters[1].Value = attach.FilePath;
                                attachParameters[2].Value = attach.CreateTime;
                                attachParameters[3].Value = attach.Admin;
                                attachParameters[4].Value = attach.Remark;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), attachParameters); //带事务
                            }
                        }
                        
                        #endregion


                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }

            return model.Id > 0;

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.StoreWaitingGoods model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update StoreWaitingGoods set ");

                        strSql.Append(" GoodsId = @GoodsId , ");
                        strSql.Append(" StoringTime = @StoringTime , ");
                        strSql.Append(" Admin = @Admin , ");
                        strSql.Append(" Remark = @Remark  ");
                        strSql.Append(" where Id=@Id ");

                        SqlParameter[] parameters = {
			                        new SqlParameter("@Id", SqlDbType.Int,4) ,            
                                    new SqlParameter("@GoodsId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@StoringTime", SqlDbType.DateTime) ,
                                    new SqlParameter("@Admin", SqlDbType.VarChar,254) ,   
                                    new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
                        };

                        parameters[0].Value = model.Id;
                        parameters[1].Value = model.GoodsId;
                        parameters[2].Value = model.StoringTime;
                        parameters[3].Value = model.Admin;
                        parameters[4].Value = model.Remark;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);



                        #region 车辆====================

                        new StoreInGoodsVehicle().DeleteList(conn, trans, model.Id);

                        if (model.GoodsVehicles.Count > 0)
                        {
                            StringBuilder strSql2 = new StringBuilder();
                            foreach (Model.StoreInGoodsVehicle goodsVehicle in model.GoodsVehicles)
                            {
                                strSql2.Append("insert into StoreInGoodsVehicle(");
                                strSql2.Append("StoreWaitingGoodsId,VehicleId,Remark,Count");
                                strSql2.Append(") values (");
                                strSql2.Append("@StoreWaitingGoodsId,@VehicleId,@Remark,@Count");
                                strSql2.Append(") ");

                                SqlParameter[] vehicleParameters = {
			                                new SqlParameter("@StoreWaitingGoodsId", SqlDbType.Int,4) ,            
                                            new SqlParameter("@VehicleId", SqlDbType.Int,4) ,            
                                            new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                                            new SqlParameter("@Count", SqlDbType.Decimal,9)             
              
                                };

                                vehicleParameters[0].Value = model.Id;
                                vehicleParameters[1].Value = goodsVehicle.VehicleId;
                                vehicleParameters[2].Value = goodsVehicle.Remark;
                                vehicleParameters[3].Value = goodsVehicle.Count;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), vehicleParameters); //带事务
                            }
                        }
                        #endregion

                        #region 附件====================
                        new Attach().DeleteList(conn, trans, model.Id);

                        if (model.Attachs.Count > 0)
                        {
                            StringBuilder strSql3;
                            foreach (Model.Attach attach in model.Attachs)
                            {
                                strSql3 = new StringBuilder();
                                strSql3.Append("insert into Attach(");
                                strSql3.Append("StoreWaitingGoodsId,FilePath,CreateTime,Admin,Remark");
                                strSql3.Append(") values (");
                                strSql3.Append("@StoreWaitingGoodsId,@FilePath,@CreateTime,@Admin,@Remark");
                                strSql3.Append(") ");

                                SqlParameter[] attachParameters = {
			                                new SqlParameter("@StoreWaitingGoodsId", SqlDbType.Int,4) ,            
                                            new SqlParameter("@FilePath", SqlDbType.VarChar,254) ,            
                                            new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                                            new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                                            new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
                                };

                                attachParameters[0].Value = model.Id;
                                attachParameters[1].Value = attach.FilePath;
                                attachParameters[2].Value = attach.CreateTime;
                                attachParameters[3].Value = attach.Admin;
                                attachParameters[4].Value = attach.Remark;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), attachParameters); //带事务
                            }
                        }
                        #endregion


                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }

            return true;
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>

        public bool Delete(int Id)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("delete from StoreWaitingGoods ");
                        strSql.Append(" where Id=@Id");
                        SqlParameter[] parameters = {
					            new SqlParameter("@Id", SqlDbType.Int,4)
			            };
                        parameters[0].Value = Id;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        new StoreInGoodsVehicle().DeleteList(conn, trans, Id);
                        new Attach().DeleteList(conn, trans, Id);

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();

                        return false;
                    }
                }
            }

            return true;
        }




        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StoreWaitingGoods ");
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
        public DTcms.Model.StoreWaitingGoods GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from StoreWaitingGoods ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            DTcms.Model.StoreWaitingGoods model = new DTcms.Model.StoreWaitingGoods();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GoodsId"].ToString() != "")
                {
                    model.GoodsId = int.Parse(ds.Tables[0].Rows[0]["GoodsId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoringTime"].ToString() != "")
                {
                    model.StoringTime = DateTime.Parse(ds.Tables[0].Rows[0]["StoringTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoredTime"].ToString() != "")
                {
                    model.StoredTime = DateTime.Parse(ds.Tables[0].Rows[0]["StoredTime"].ToString());
                }
                model.Admin = ds.Tables[0].Rows[0]["Admin"].ToString();
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
            strSql.Append(" FROM StoreWaitingGoods ");
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
            strSql.Append(" FROM StoreWaitingGoods ");
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
            strSql.Append("select A.GoodsId, A.Id AS Id, A.StoringTime, A.Admin, B.Name AS GoodsName, C.Name AS CustomerName FROM StoreWaitingGoods A, Goods B, Customer C ");
            strSql.Append("where A.GoodsId = B.Id and b.CustomerId = c.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}

