using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.DAL
{
    //ReceivedMoney
    public partial class ReceivedMoney
    {
        public ReceivedMoney()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ReceivedMoney");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.ReceivedMoney model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into ReceivedMoney(");
                        strSql.Append("StoreInOrderId,CustomerId,Name,EndChargingTime,BeginChargingTime,ReceivedTime,ChargingCount,TotalPrice,InvoicedPrice,CreateTime,Admin,Remark,Status,HasBeenInvoiced,InvoicedTime,InvoicedOperator,UnitPriceDetails)");
                        strSql.Append(" values (");
                        strSql.Append("@StoreInOrderId,@CustomerId,@Name,@EndChargingTime,@BeginChargingTime,@ReceivedTime,@ChargingCount,@TotalPrice,@InvoicedPrice,@CreateTime,@Admin,@Remark,@Status,@HasBeenInvoiced,@InvoicedTime,@InvoicedOperator,@UnitPriceDetails)");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
					        new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					        new SqlParameter("@CustomerId", SqlDbType.Int,4),
					        new SqlParameter("@Name", SqlDbType.VarChar,254),
					        new SqlParameter("@EndChargingTime", SqlDbType.DateTime),
					        new SqlParameter("@BeginChargingTime", SqlDbType.DateTime),
					        new SqlParameter("@ReceivedTime", SqlDbType.DateTime),
					        new SqlParameter("@ChargingCount", SqlDbType.Decimal,9),
					        new SqlParameter("@TotalPrice", SqlDbType.Decimal,9),
					        new SqlParameter("@InvoicedPrice", SqlDbType.Decimal,9),
					        new SqlParameter("@CreateTime", SqlDbType.DateTime),
					        new SqlParameter("@Admin", SqlDbType.VarChar,254),
					        new SqlParameter("@Remark", SqlDbType.VarChar,254),
					        new SqlParameter("@Status", SqlDbType.Int,4),
					        new SqlParameter("@HasBeenInvoiced", SqlDbType.Bit,1),
					        new SqlParameter("@InvoicedTime", SqlDbType.DateTime),
					        new SqlParameter("@InvoicedOperator", SqlDbType.VarChar,254),
					        new SqlParameter("@UnitPriceDetails", SqlDbType.VarChar,1000)};
                        parameters[0].Value = model.StoreInOrderId;
                        parameters[1].Value = model.CustomerId;
                        parameters[2].Value = model.Name;
                        parameters[3].Value = model.EndChargingTime;
                        parameters[4].Value = model.BeginChargingTime;
                        parameters[5].Value = model.ReceivedTime;
                        parameters[6].Value = model.ChargingCount;
                        parameters[7].Value = model.TotalPrice;
                        parameters[8].Value = model.InvoicedPrice;
                        parameters[9].Value = model.CreateTime;
                        parameters[10].Value = model.Admin;
                        parameters[11].Value = model.Remark;
                        parameters[12].Value = model.Status;
                        parameters[13].Value = model.HasBeenInvoiced;
                        parameters[14].Value = model.InvoicedTime;
                        parameters[15].Value = model.InvoicedOperator;
                        parameters[16].Value = model.UnitPriceDetails;

                        object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务
                        model.Id = Convert.ToInt32(obj);

                        new StoreInOrder().UpdateField(conn, trans, model.StoreInOrderId, "ChargingTime = '" + model.ReceivedTime + "'");
   

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
        public bool Update(DTcms.Model.ReceivedMoney model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update ReceivedMoney set ");
                        strSql.Append("StoreInOrderId=@StoreInOrderId,");
                        strSql.Append("CustomerId=@CustomerId,");
                        strSql.Append("Name=@Name,");
                        strSql.Append("EndChargingTime=@EndChargingTime,");
                        strSql.Append("BeginChargingTime=@BeginChargingTime,");
                        strSql.Append("ReceivedTime=@ReceivedTime,");
                        strSql.Append("ChargingCount=@ChargingCount,");
                        strSql.Append("TotalPrice=@TotalPrice,");
                        strSql.Append("InvoicedPrice=@InvoicedPrice,");
                        strSql.Append("CreateTime=@CreateTime,");
                        strSql.Append("Admin=@Admin,");
                        strSql.Append("Remark=@Remark,");
                        strSql.Append("Status=@Status,");
                        strSql.Append("HasBeenInvoiced=@HasBeenInvoiced,");
                        strSql.Append("InvoicedTime=@InvoicedTime,");
                        strSql.Append("InvoicedOperator=@InvoicedOperator,");
                        strSql.Append("UnitPriceDetails=@UnitPriceDetails");
                        strSql.Append(" where Id=@Id");
                        SqlParameter[] parameters = {
					            new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					            new SqlParameter("@CustomerId", SqlDbType.Int,4),
					            new SqlParameter("@Name", SqlDbType.VarChar,254),
					            new SqlParameter("@EndChargingTime", SqlDbType.DateTime),
					            new SqlParameter("@BeginChargingTime", SqlDbType.DateTime),
					            new SqlParameter("@ReceivedTime", SqlDbType.DateTime),
					            new SqlParameter("@ChargingCount", SqlDbType.Decimal,9),
					            new SqlParameter("@TotalPrice", SqlDbType.Decimal,9),
					            new SqlParameter("@InvoicedPrice", SqlDbType.Decimal,9),
					            new SqlParameter("@CreateTime", SqlDbType.DateTime),
					            new SqlParameter("@Admin", SqlDbType.VarChar,254),
					            new SqlParameter("@Remark", SqlDbType.VarChar,254),
					            new SqlParameter("@Status", SqlDbType.Int,4),
					            new SqlParameter("@HasBeenInvoiced", SqlDbType.Bit,1),
					            new SqlParameter("@InvoicedTime", SqlDbType.DateTime),
					            new SqlParameter("@InvoicedOperator", SqlDbType.VarChar,254),
					            new SqlParameter("@UnitPriceDetails", SqlDbType.VarChar,1000),
					            new SqlParameter("@Id", SqlDbType.Int,4)};
                        parameters[0].Value = model.StoreInOrderId;
                        parameters[1].Value = model.CustomerId;
                        parameters[2].Value = model.Name;
                        parameters[3].Value = model.EndChargingTime;
                        parameters[4].Value = model.BeginChargingTime;
                        parameters[5].Value = model.ReceivedTime;
                        parameters[6].Value = model.ChargingCount;
                        parameters[7].Value = model.TotalPrice;
                        parameters[8].Value = model.InvoicedPrice;
                        parameters[9].Value = model.CreateTime;
                        parameters[10].Value = model.Admin;
                        parameters[11].Value = model.Remark;
                        parameters[12].Value = model.Status;
                        parameters[13].Value = model.HasBeenInvoiced;
                        parameters[14].Value = model.InvoicedTime;
                        parameters[15].Value = model.InvoicedOperator;
                        parameters[16].Value = model.UnitPriceDetails;
                        parameters[17].Value = model.Id;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        new StoreInOrder().UpdateField(conn, trans, model.StoreInOrderId, "ChargingTime = '" + model.ReceivedTime + "'");

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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ReceivedMoney ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ReceivedMoney ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
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
        public DTcms.Model.ReceivedMoney GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,StoreInOrderId,CustomerId,Name,EndChargingTime,BeginChargingTime,ReceivedTime,ChargingCount,TotalPrice,InvoicedPrice,CreateTime,Admin,Remark,Status,HasBeenInvoiced,InvoicedTime,InvoicedOperator,UnitPriceDetails from ReceivedMoney ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            DTcms.Model.ReceivedMoney model = new DTcms.Model.ReceivedMoney();
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
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.ReceivedMoney DataRowToModel(DataRow row)
        {
            DTcms.Model.ReceivedMoney model = new DTcms.Model.ReceivedMoney();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["StoreInOrderId"] != null && row["StoreInOrderId"].ToString() != "")
                {
                    model.StoreInOrderId = int.Parse(row["StoreInOrderId"].ToString());
                }
                if (row["CustomerId"] != null && row["CustomerId"].ToString() != "")
                {
                    model.CustomerId = int.Parse(row["CustomerId"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["EndChargingTime"] != null && row["EndChargingTime"].ToString() != "")
                {
                    model.EndChargingTime = DateTime.Parse(row["EndChargingTime"].ToString());
                }
                if (row["BeginChargingTime"] != null && row["BeginChargingTime"].ToString() != "")
                {
                    model.BeginChargingTime = DateTime.Parse(row["BeginChargingTime"].ToString());
                }
                if (row["ReceivedTime"] != null && row["ReceivedTime"].ToString() != "")
                {
                    model.ReceivedTime = DateTime.Parse(row["ReceivedTime"].ToString());
                }
                if (row["ChargingCount"] != null && row["ChargingCount"].ToString() != "")
                {
                    model.ChargingCount = decimal.Parse(row["ChargingCount"].ToString());
                }
                if (row["TotalPrice"] != null && row["TotalPrice"].ToString() != "")
                {
                    model.TotalPrice = decimal.Parse(row["TotalPrice"].ToString());
                }
                if (row["InvoicedPrice"] != null && row["InvoicedPrice"].ToString() != "")
                {
                    model.InvoicedPrice = decimal.Parse(row["InvoicedPrice"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["Admin"] != null)
                {
                    model.Admin = row["Admin"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["HasBeenInvoiced"] != null && row["HasBeenInvoiced"].ToString() != "")
                {
                    if ((row["HasBeenInvoiced"].ToString() == "1") || (row["HasBeenInvoiced"].ToString().ToLower() == "true"))
                    {
                        model.HasBeenInvoiced = true;
                    }
                    else
                    {
                        model.HasBeenInvoiced = false;
                    }
                }
                if (row["InvoicedTime"] != null && row["InvoicedTime"].ToString() != "")
                {
                    model.InvoicedTime = DateTime.Parse(row["InvoicedTime"].ToString());
                }
                if (row["InvoicedOperator"] != null)
                {
                    model.InvoicedOperator = row["InvoicedOperator"].ToString();
                }
                if (row["UnitPriceDetails"] != null)
                {
                    model.UnitPriceDetails = row["UnitPriceDetails"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,StoreInOrderId,CustomerId,Name,EndChargingTime,BeginChargingTime,ReceivedTime,ChargingCount,TotalPrice,InvoicedPrice,CreateTime,Admin,Remark,Status,HasBeenInvoiced,InvoicedTime,InvoicedOperator,UnitPriceDetails ");
            strSql.Append(" FROM ReceivedMoney ");
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
            strSql.Append(" Id,StoreInOrderId,CustomerId,Name,EndChargingTime,BeginChargingTime,ReceivedTime,ChargingCount,TotalPrice,InvoicedPrice,CreateTime,Admin,Remark,Status,HasBeenInvoiced,InvoicedTime,InvoicedOperator,UnitPriceDetails ");
            strSql.Append(" FROM ReceivedMoney ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ReceivedMoney ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from ReceivedMoney T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "ReceivedMoney";
            parameters[1].Value = "Id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod


        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select A.Id as Id, A.Remark as Remark, A.StoreInOrderId, A.CustomerId, A.Name as Name, A.ReceivedTime, A.ChargingCount, A.TotalPrice, A.InvoicedPrice, A.Admin, A.HasBeenInvoiced, B.AccountNumber, C.Name as CustomerName ");
            strSql.Append("from ReceivedMoney A, StoreInOrder B, Customer C ");
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

