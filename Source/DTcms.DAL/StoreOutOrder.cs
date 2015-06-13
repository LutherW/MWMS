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



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.StoreOutOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StoreOutOrder(");
            strSql.Append("CustomerId,StoreInUnitPriceStoreInOrderId,CreateTime,Admin,TotalMoney,InvoiceMoney,HasBeenInvoiced,Status,Remark");
            strSql.Append(") values (");
            strSql.Append("@CustomerId,@StoreInUnitPriceStoreInOrderId,@CreateTime,@Admin,@TotalMoney,@InvoiceMoney,@HasBeenInvoiced,@Status,@Remark");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInUnitPriceStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@TotalMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@InvoiceMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@HasBeenInvoiced", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.CustomerId;
            parameters[1].Value = model.StoreInUnitPriceStoreInOrderId;
            parameters[2].Value = model.CreateTime;
            parameters[3].Value = model.Admin;
            parameters[4].Value = model.TotalMoney;
            parameters[5].Value = model.InvoiceMoney;
            parameters[6].Value = model.HasBeenInvoiced;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.Remark;

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
        public bool Update(DTcms.Model.StoreOutOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StoreOutOrder set ");

            strSql.Append(" CustomerId = @CustomerId , ");
            strSql.Append(" StoreInUnitPriceStoreInOrderId = @StoreInUnitPriceStoreInOrderId , ");
            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" Admin = @Admin , ");
            strSql.Append(" TotalMoney = @TotalMoney , ");
            strSql.Append(" InvoiceMoney = @InvoiceMoney , ");
            strSql.Append(" HasBeenInvoiced = @HasBeenInvoiced , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" Remark = @Remark  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInUnitPriceStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@TotalMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@InvoiceMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@HasBeenInvoiced", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.CustomerId;
            parameters[2].Value = model.StoreInUnitPriceStoreInOrderId;
            parameters[3].Value = model.CreateTime;
            parameters[4].Value = model.Admin;
            parameters[5].Value = model.TotalMoney;
            parameters[6].Value = model.InvoiceMoney;
            parameters[7].Value = model.HasBeenInvoiced;
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
            strSql.Append("delete from StoreOutOrder ");
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
            strSql.Append("select Id, CustomerId, StoreInUnitPriceStoreInOrderId, CreateTime, Admin, TotalMoney, InvoiceMoney, HasBeenInvoiced, Status, Remark  ");
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
                if (ds.Tables[0].Rows[0]["StoreInUnitPriceStoreInOrderId"].ToString() != "")
                {
                    model.StoreInUnitPriceStoreInOrderId = int.Parse(ds.Tables[0].Rows[0]["StoreInUnitPriceStoreInOrderId"].ToString());
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
            strSql.Append("select A.Id AS Id, A.Status, A.BeginChargingTime, A.Admin, A.ChargingCount, A.AccountNumber, A.InspectionNumber, A.SuttleWeight, A.Remark AS Remark,B.Name AS CustomerName FROM StoreOutOrder A, Customer B, StoreInOrder C ");
            strSql.Append("where A.CustomerId = B.Id, A.StoreInOrderId = C.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}

