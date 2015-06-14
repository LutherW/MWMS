using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.DAL
{
    //StoreInOrder
    public partial class StoreInOrder
    {

        public bool Exists(int Id, int CustomerId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StoreInOrder");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id and  ");
            strSql.Append(" CustomerId = @CustomerId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4)			};
            parameters[0].Value = Id;
            parameters[1].Value = CustomerId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StoreInOrder");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4) };
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.StoreInOrder model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into StoreInOrder(");
                        strSql.Append("CustomerId,Status,CreateTime,BeginChargingTime,ChargingTime,Admin,ChargingCount,InspectionNumber,AccountNumber,SuttleWeight,Remark");
                        strSql.Append(") values (");
                        strSql.Append("@CustomerId,@Status,@CreateTime,@BeginChargingTime,@ChargingTime,@Admin,@ChargingCount,@InspectionNumber,@AccountNumber,@SuttleWeight,@Remark");
                        strSql.Append(") ");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
			                        new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@Status", SqlDbType.Int,4) ,            
                                    new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@BeginChargingTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@ChargingTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@ChargingCount", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@InspectionNumber", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@AccountNumber", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@SuttleWeight", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
                        };

                        parameters[0].Value = model.CustomerId;
                        parameters[1].Value = model.Status;
                        parameters[2].Value = model.CreateTime;
                        parameters[3].Value = model.BeginChargingTime;
                        parameters[4].Value = model.ChargingTime;
                        parameters[5].Value = model.Admin;
                        parameters[6].Value = model.ChargingCount;
                        parameters[7].Value = model.InspectionNumber;
                        parameters[8].Value = model.AccountNumber;
                        parameters[9].Value = model.SuttleWeight;
                        parameters[10].Value = model.Remark;

                        object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务
                        model.Id = Convert.ToInt32(obj);

                        #region 单价====================
                        if (model.UnitPrices.Count > 0)
                        {
                            StoreInUnitPrice unitPriceDAL = new StoreInUnitPrice();
                            foreach (Model.StoreInUnitPrice unitPrice in model.UnitPrices)
                            {
                                unitPrice.StoreInOrderId = model.Id;
                                unitPriceDAL.Add(conn, trans, unitPrice);
                            }
                        }
                        #endregion

                        #region 费用====================
                        if (model.StoreInCosts.Count > 0)
                        {
                            StoreInCost storeInCostDAL = new StoreInCost();
                            foreach (Model.StoreInCost storeInCost in model.StoreInCosts)
                            {
                                storeInCost.StoreInOrderId = model.Id;
                                storeInCostDAL.Add(conn, trans, storeInCost);
                            }
                        }
                        #endregion

                        #region 入库货物====================
                        if (model.StoreInGoods.Count > 0)
                        {
                            StoreInGoods storeInGoodsDAL = new StoreInGoods();
                            StoreWaitingGoods waitingGoodsDAL = new StoreWaitingGoods();
                            foreach (Model.StoreInGoods storeInGoods in model.StoreInGoods)
                            {
                                storeInGoods.StoreInOrderId = model.Id;
                                storeInGoodsDAL.Add(conn, trans, storeInGoods);
                                waitingGoodsDAL.UpdateStatus(conn, trans, storeInGoods.StoreWaitingGoodsId, 1);
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
        public bool Update(DTcms.Model.StoreInOrder model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update StoreInOrder set ");

                        strSql.Append(" CustomerId = @CustomerId , ");
                        strSql.Append(" BeginChargingTime = @BeginChargingTime , ");
                        strSql.Append(" ChargingTime = @ChargingTime , ");
                        strSql.Append(" Admin = @Admin , ");
                        strSql.Append(" ChargingCount = @ChargingCount , ");
                        strSql.Append(" InspectionNumber = @InspectionNumber , ");
                        strSql.Append(" AccountNumber = @AccountNumber , ");
                        strSql.Append(" SuttleWeight = @SuttleWeight , ");
                        strSql.Append(" Remark = @Remark  ");
                        strSql.Append(" where Id=@Id ");

                        SqlParameter[] parameters = {
			                        new SqlParameter("@Id", SqlDbType.Int,4) ,            
                                    new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@BeginChargingTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@ChargingTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@ChargingCount", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@InspectionNumber", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@AccountNumber", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@SuttleWeight", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
                        };

                        parameters[0].Value = model.Id;
                        parameters[1].Value = model.CustomerId;
                        parameters[2].Value = model.BeginChargingTime;
                        parameters[3].Value = model.ChargingTime;
                        parameters[4].Value = model.Admin;
                        parameters[5].Value = model.ChargingCount;
                        parameters[6].Value = model.InspectionNumber;
                        parameters[7].Value = model.AccountNumber;
                        parameters[8].Value = model.SuttleWeight;
                        parameters[9].Value = model.Remark;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        #region 单价
                        StoreInUnitPrice unitPriceDAL = new StoreInUnitPrice();
                        unitPriceDAL.Delete(conn, trans, model.Id);
                        if (model.UnitPrices.Count > 0)
                        {
                            foreach (Model.StoreInUnitPrice unitPrice in model.UnitPrices)
                            {
                                unitPrice.StoreInOrderId = model.Id;
                                unitPriceDAL.Add(conn, trans, unitPrice);
                            }
                        }
                        #endregion 

                        #region 费用
                        StoreInCost costDAL = new StoreInCost();
                        costDAL.Delete(conn, trans, model.Id);
                        if (model.StoreInCosts.Count > 0)
                        {
                            foreach (Model.StoreInCost cost in model.StoreInCosts)
                            {
                                cost.StoreInOrderId = model.Id;
                                costDAL.Add(conn, trans, cost);
                            }
                        }
                        #endregion 

                        #region 入库货物====================
                        StoreInGoods storeInGoodsDAL = new StoreInGoods();
                        storeInGoodsDAL.Delete(conn, trans, model.Id);
                        if (model.StoreInGoods.Count > 0)
                        {
                            StoreWaitingGoods waitingGoodsDAL = new StoreWaitingGoods();
                            foreach (Model.StoreInGoods storeInGoods in model.StoreInGoods)
                            {
                                storeInGoods.StoreInOrderId = model.Id;
                                storeInGoodsDAL.Add(conn, trans, storeInGoods);
                                waitingGoodsDAL.UpdateStatus(conn, trans, storeInGoods.StoreWaitingGoodsId, 1);
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
        /// 修改一列数据
        /// </summary>
        public int UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StoreInOrder set " + strValue);
            strSql.Append(" where Id=" + id);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public int UpdateField(SqlConnection conn, SqlTransaction trans, int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StoreInOrder set " + strValue);
            strSql.Append(" where Id=" + id);

            return DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString());
        }

        public int UpdateField(string strWhere, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StoreInOrder set " + strValue);
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }
            

            return DbHelperSQL.ExecuteSql(strSql.ToString());
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
                        strSql.Append("delete from StoreInOrder ");
                        strSql.Append(" where Id=@Id and Status != 2");
                        SqlParameter[] parameters = {
					            new SqlParameter("@Id", SqlDbType.Int,4)
			            };
                        parameters[0].Value = Id;

                        DbHelperSQL.ExecuteSql(conn, trans,strSql.ToString(), parameters);

                        new StoreInUnitPrice().Delete(conn, trans, Id);

                        new StoreInCost().Delete(conn, trans, Id);

                        new StoreInGoods().Delete(conn, trans, Id);

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
            strSql.Append("delete from StoreInOrder ");
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
        public DTcms.Model.StoreInOrder GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, CustomerId, Status, CreateTime, BeginChargingTime, ChargingTime, Admin, ChargingCount, InspectionNumber, AccountNumber, SuttleWeight, Remark  ");
            strSql.Append("  from StoreInOrder ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            DTcms.Model.StoreInOrder model = new DTcms.Model.StoreInOrder();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerId"].ToString() != "")
                {
                    model.CustomerId = int.Parse(ds.Tables[0].Rows[0]["CustomerId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BeginChargingTime"].ToString() != "")
                {
                    model.BeginChargingTime = DateTime.Parse(ds.Tables[0].Rows[0]["BeginChargingTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ChargingTime"].ToString() != "")
                {
                    model.ChargingTime = DateTime.Parse(ds.Tables[0].Rows[0]["ChargingTime"].ToString());
                }
                model.Admin = ds.Tables[0].Rows[0]["Admin"].ToString();
                if (ds.Tables[0].Rows[0]["ChargingCount"].ToString() != "")
                {
                    model.ChargingCount = decimal.Parse(ds.Tables[0].Rows[0]["ChargingCount"].ToString());
                }
                model.InspectionNumber = ds.Tables[0].Rows[0]["InspectionNumber"].ToString();
                model.AccountNumber = ds.Tables[0].Rows[0]["AccountNumber"].ToString();
                if (ds.Tables[0].Rows[0]["SuttleWeight"].ToString() != "")
                {
                    model.SuttleWeight = decimal.Parse(ds.Tables[0].Rows[0]["SuttleWeight"].ToString());
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
            strSql.Append(" FROM StoreInOrder ");
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
            strSql.Append(" FROM StoreInOrder ");
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
            strSql.Append("select A.Id AS Id, A.Status, A.BeginChargingTime, A.Admin, A.ChargingCount, A.AccountNumber, A.InspectionNumber, A.SuttleWeight, A.Remark AS Remark,B.Name AS CustomerName FROM StoreInOrder A, Customer B ");
            strSql.Append("where A.CustomerId = B.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}

