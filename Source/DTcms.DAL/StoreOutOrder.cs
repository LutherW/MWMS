using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.DAL
{
    //StoreOutOrder
    public partial class StoreOutOrder
    {

        public bool Exists(int Id, int CustomerId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StoreOutOrder");
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
            strSql.Append("select count(1) from StoreOutOrder");
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
        public bool Add(DTcms.Model.StoreOutOrder model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into StoreOutOrder(");
                        strSql.Append("CustomerId,StoreInOrderId,CreateTime,Admin,TotalMoney,InvoiceMoney,HasBeenInvoiced,Status,Remark,StoredOutTime,Count,UnitPrice,BeginChargingTime,EndChargingTime,UnitPriceDetails");
                        strSql.Append(") values (");
                        strSql.Append("@CustomerId,@StoreInUnitPriceStoreInOrderId,@CreateTime,@Admin,@TotalMoney,@InvoiceMoney,@HasBeenInvoiced,@Status,@Remark,@StoredOutTime,@Count,@UnitPrice,@BeginChargingTime,@EndChargingTime,@UnitPriceDetails");
                        strSql.Append(") ");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
			                        new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@StoreInUnitPriceStoreInOrderId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@TotalMoney", SqlDbType.Decimal) ,            
                                    new SqlParameter("@InvoiceMoney", SqlDbType.Decimal) ,            
                                    new SqlParameter("@HasBeenInvoiced", SqlDbType.Bit,1) ,            
                                    new SqlParameter("@Status", SqlDbType.Int,4) ,            
                                    new SqlParameter("@Remark", SqlDbType.VarChar,254) ,
                                    new SqlParameter("@StoredOutTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@Count", SqlDbType.Decimal) ,            
                                    new SqlParameter("@UnitPrice", SqlDbType.Decimal) ,
                                    new SqlParameter("@BeginChargingTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@EndChargingTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@UnitPriceDetails", SqlDbType.VarChar,1000) 
              
                        };

                        parameters[0].Value = model.CustomerId;
                        parameters[1].Value = model.StoreInOrderId;
                        parameters[2].Value = model.CreateTime;
                        parameters[3].Value = model.Admin;
                        parameters[4].Value = model.TotalMoney;
                        parameters[5].Value = model.InvoiceMoney;
                        parameters[6].Value = model.HasBeenInvoiced;
                        parameters[7].Value = model.Status;
                        parameters[8].Value = model.Remark;
                        parameters[9].Value = model.StoredOutTime;
                        parameters[10].Value = model.Count;
                        parameters[11].Value = model.UnitPrice;
                        parameters[12].Value = model.BeginChargingTime;
                        parameters[13].Value = model.EndChargingTime;
                        parameters[14].Value = model.UnitPriceDetails;

                        object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务
                        model.Id = Convert.ToInt32(obj);

                        new StoreInOrder().UpdateField(model.StoreInOrderId, "ChargingCount = ChargingCount - " + model.Count + "");


                        #region 费用====================
                        if (model.StoreOutCosts.Count > 0)
                        {
                            StoreOutCost storeOutCostDAL = new StoreOutCost();
                            foreach (Model.StoreOutCost storeInCost in model.StoreOutCosts)
                            {
                                storeInCost.StoreOutOrderId = model.Id;
                                storeOutCostDAL.Add(conn, trans, storeInCost);
                            }
                        }
                        #endregion

                        #region 入库货物====================
                        if (model.StoreOutGoods.Count > 0)
                        {
                            StoreOutGoods storeOutGoodsDAL = new StoreOutGoods();
                            foreach (Model.StoreOutGoods storeInGoods in model.StoreOutGoods)
                            {
                                storeInGoods.StoreOutOrderId = model.Id;
                                storeOutGoodsDAL.Add(conn, trans, storeInGoods);
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
        public bool Update(DTcms.Model.StoreOutOrder model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update StoreOutOrder set ");
                        strSql.Append(" CustomerId = @CustomerId , ");
                        strSql.Append(" StoreInOrderId = @StoreInOrderId , ");
                        strSql.Append(" Admin = @Admin , ");
                        strSql.Append(" TotalMoney = @TotalMoney , ");
                        strSql.Append(" InvoiceMoney = @InvoiceMoney , ");
                        strSql.Append(" Status = @Status , ");
                        strSql.Append(" StoredOutTime = @StoredOutTime , ");
                        strSql.Append(" Count = @Count , ");
                        strSql.Append(" UnitPrice = @UnitPrice , ");
                        strSql.Append(" Remark = @Remark,  ");
                        strSql.Append(" BeginChargingTime = @BeginChargingTime , ");
                        strSql.Append(" EndChargingTime = @EndChargingTime , ");
                        strSql.Append(" UnitPriceDetails = @UnitPriceDetails  ");
                        strSql.Append(" where Id=@Id ");

                        SqlParameter[] parameters = {
			                        new SqlParameter("@Id", SqlDbType.Int,4) ,            
                                    new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@TotalMoney", SqlDbType.Decimal) ,            
                                    new SqlParameter("@InvoiceMoney", SqlDbType.Decimal) ,            
                                    new SqlParameter("@Status", SqlDbType.Int,4) ,  
                                    new SqlParameter("@StoredOutTime", SqlDbType.DateTime) ,   
                                    new SqlParameter("@Count", SqlDbType.Decimal) ,   
                                    new SqlParameter("@UnitPrice", SqlDbType.Decimal) ,   
                                    new SqlParameter("@Remark", SqlDbType.VarChar,254),
                                    new SqlParameter("@BeginChargingTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@EndChargingTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@UnitPriceDetails", SqlDbType.VarChar,1000) 
              
                        };

                        parameters[0].Value = model.Id;
                        parameters[1].Value = model.CustomerId;
                        parameters[2].Value = model.StoreInOrderId;
                        parameters[3].Value = model.Admin;
                        parameters[4].Value = model.TotalMoney;
                        parameters[5].Value = model.InvoiceMoney;
                        parameters[6].Value = model.Status;
                        parameters[7].Value = model.StoredOutTime;
                        parameters[8].Value = model.Count;
                        parameters[9].Value = model.UnitPrice;
                        parameters[10].Value = model.Remark;
                        parameters[11].Value = model.BeginChargingTime;
                        parameters[12].Value = model.EndChargingTime;
                        parameters[13].Value = model.UnitPriceDetails;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        #region 费用====================

                        StoreOutCost storeOutCostDAL = new StoreOutCost();
                        storeOutCostDAL.Delete(conn, trans, model.Id);
                        if (model.StoreOutCosts.Count > 0)
                        {
                            foreach (Model.StoreOutCost storeInCost in model.StoreOutCosts)
                            {
                                storeInCost.StoreOutOrderId = model.Id;
                                storeOutCostDAL.Add(conn, trans, storeInCost);
                            }
                        }
                        #endregion

                        #region 出库货物====================
                        StoreOutGoods storeOutGoodsDAL = new StoreOutGoods();
                        storeOutGoodsDAL.Delete(conn, trans, model.Id);
                        if (model.StoreOutGoods.Count > 0)
                        {
                            foreach (Model.StoreOutGoods storeOutGoods in model.StoreOutGoods)
                            {
                                
                                storeOutGoods.StoreOutOrderId = model.Id;
                                storeOutGoodsDAL.Add(conn, trans, storeOutGoods);
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
            strSql.Append("update StoreOutOrder set " + strValue);
            strSql.Append(" where Id=" + id);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public int UpdateField(SqlConnection conn, SqlTransaction trans, int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StoreOutOrder set " + strValue);
            strSql.Append(" where Id=" + id);

            return DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString());
        }

        public int UpdateField(string strWhere, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StoreOutOrder set " + strValue);
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
                        strSql.Append("delete from StoreOutOrder ");
                        strSql.Append(" where Id=@Id");
                        SqlParameter[] parameters = {
					            new SqlParameter("@Id", SqlDbType.Int,4)
			            };
                        parameters[0].Value = Id;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        new StoreOutCost().Delete(conn, trans, Id);

                        new StoreOutGoods().Delete(conn, trans, Id);

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
            strSql.Append("delete from StoreOutOrder ");
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
        public DTcms.Model.StoreOutOrder GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from StoreOutOrder ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            DTcms.Model.StoreOutOrder model = new DTcms.Model.StoreOutOrder();
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
                if (ds.Tables[0].Rows[0]["StoreInOrderId"].ToString() != "")
                {
                    model.StoreInOrderId = int.Parse(ds.Tables[0].Rows[0]["StoreInOrderId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                model.Admin = ds.Tables[0].Rows[0]["Admin"].ToString();
                if (ds.Tables[0].Rows[0]["TotalMoney"].ToString() != "")
                {
                    model.TotalMoney = decimal.Parse(ds.Tables[0].Rows[0]["TotalMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InvoiceMoney"].ToString() != "")
                {
                    model.InvoiceMoney = decimal.Parse(ds.Tables[0].Rows[0]["InvoiceMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HasBeenInvoiced"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["HasBeenInvoiced"].ToString() == "1") || (ds.Tables[0].Rows[0]["HasBeenInvoiced"].ToString().ToLower() == "true"))
                    {
                        model.HasBeenInvoiced = true;
                    }
                    else
                    {
                        model.HasBeenInvoiced = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["StoringOutTime"].ToString() != "")
                {
                    model.StoringOutTime = DateTime.Parse(ds.Tables[0].Rows[0]["StoringOutTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoredOutTime"].ToString() != "")
                {
                    model.StoredOutTime = DateTime.Parse(ds.Tables[0].Rows[0]["StoredOutTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Count"].ToString() != "")
                {
                    model.Count = decimal.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UnitPrice"].ToString() != "")
                {
                    model.UnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["UnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndChargingTime"] != null && ds.Tables[0].Rows[0]["EndChargingTime"].ToString() != "")
                {
                    model.EndChargingTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndChargingTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BeginChargingTime"] != null && ds.Tables[0].Rows[0]["BeginChargingTime"].ToString() != "")
                {
                    model.BeginChargingTime = DateTime.Parse(ds.Tables[0].Rows[0]["BeginChargingTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UnitPriceDetails"] != null)
                {
                    model.UnitPriceDetails = ds.Tables[0].Rows[0]["UnitPriceDetails"].ToString();
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM StoreOutOrder ");
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
            strSql.Append(" FROM StoreOutOrder ");
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
            strSql.Append("select A.Id AS Id, A.Status, A.StoreInOrderId, A.StoredOutTime, A.TotalMoney, A.UnitPrice, A.InvoiceMoney, A.Admin, A.Count, A.BeginChargingTime, A.EndChargingTime, A.UnitPriceDetails, A.Remark AS Remark, C.Name AS CustomerName, B.AccountNumber FROM StoreOutOrder A, StoreInOrder B, Customer C ");
            strSql.Append("where A.StoreInOrderId = B.Id and A.CustomerId = C.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}

