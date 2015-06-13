using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.DAL
{
    //StoreInGoods
    public partial class StoreInGoods
    {

        public bool Exists(int StoreInOrderId, int Id, int StoreId, int CustomerId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StoreInGoods");
            strSql.Append(" where ");
            strSql.Append(" StoreInOrderId = @StoreInOrderId and  ");
            strSql.Append(" Id = @Id and  ");
            strSql.Append(" StoreId = @StoreId and  ");
            strSql.Append(" CustomerId = @CustomerId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@StoreId", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4)			};
            parameters[0].Value = StoreInOrderId;
            parameters[1].Value = Id;
            parameters[2].Value = StoreId;
            parameters[3].Value = CustomerId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.StoreInGoods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StoreInGoods(");
            strSql.Append("StoreInOrderId,StoreId,StoreWaitingGoodsId,CustomerId,Status,Count,StoredInTime,Remark");
            strSql.Append(") values (");
            strSql.Append("@StoreInOrderId,@StoreId,@StoreWaitingGoodsId,@CustomerId,@Status,@Count,@StoredInTime,@Remark");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreWaitingGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@StoredInTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.StoreInOrderId;
            parameters[1].Value = model.StoreId;
            parameters[2].Value = model.StoreWaitingGoodsId;
            parameters[3].Value = model.CustomerId;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.Count;
            parameters[6].Value = model.StoredInTime;
            parameters[7].Value = model.Remark;

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

        public void Add(SqlConnection conn, SqlTransaction trans, DTcms.Model.StoreInGoods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StoreInGoods(");
            strSql.Append("StoreInOrderId,StoreId,StoreWaitingGoodsId,CustomerId,Status,Count,StoredInTime,Remark,GoodsId");
            strSql.Append(") values (");
            strSql.Append("@StoreInOrderId,@StoreId,@StoreWaitingGoodsId,@CustomerId,@Status,@Count,@StoredInTime,@Remark,@GoodsId");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreWaitingGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@StoredInTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)  ,           
                        new SqlParameter("@GoodsId", SqlDbType.Int,4) ,  
            };

            parameters[0].Value = model.StoreInOrderId;
            parameters[1].Value = model.StoreId;
            parameters[2].Value = model.StoreWaitingGoodsId;
            parameters[3].Value = model.CustomerId;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.Count;
            parameters[6].Value = model.StoredInTime;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.GoodsId;

            DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.StoreInGoods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StoreInGoods set ");

            strSql.Append(" StoreInOrderId = @StoreInOrderId , ");
            strSql.Append(" StoreId = @StoreId , ");
            strSql.Append(" StoreWaitingGoodsId = @StoreWaitingGoodsId , ");
            strSql.Append(" CustomerId = @CustomerId , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" Count = @Count , ");
            strSql.Append(" StoredInTime = @StoredInTime , ");
            strSql.Append(" Remark = @Remark  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreWaitingGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@StoredInTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.StoreInOrderId;
            parameters[1].Value = model.Id;
            parameters[2].Value = model.StoreId;
            parameters[3].Value = model.StoreWaitingGoodsId;
            parameters[4].Value = model.CustomerId;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.Count;
            parameters[7].Value = model.StoredInTime;
            parameters[8].Value = model.Remark;
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


        public int UpdateField(SqlConnection conn, SqlTransaction trans, int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StoreInOrder set " + strValue);
            strSql.Append(" where Id=" + id);

            return DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString());
        }



        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StoreInGoods ");
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

        public bool Delete(SqlConnection conn, SqlTransaction trans, int storeInOrderId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StoreInGoods ");
            strSql.Append(" where StoreInOrderId=@StoreInOrderId");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4)
			};
            parameters[0].Value = storeInOrderId;


            int rows = DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
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
            strSql.Append("delete from StoreInGoods ");
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
        public DTcms.Model.StoreInGoods GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StoreInOrderId, Id, StoreId, StoreWaitingGoodsId, CustomerId, Status, Count, StoredInTime, Remark  ");
            strSql.Append("  from StoreInGoods ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            DTcms.Model.StoreInGoods model = new DTcms.Model.StoreInGoods();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StoreInOrderId"].ToString() != "")
                {
                    model.StoreInOrderId = int.Parse(ds.Tables[0].Rows[0]["StoreInOrderId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreId"].ToString() != "")
                {
                    model.StoreId = int.Parse(ds.Tables[0].Rows[0]["StoreId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreWaitingGoodsId"].ToString() != "")
                {
                    model.StoreWaitingGoodsId = int.Parse(ds.Tables[0].Rows[0]["StoreWaitingGoodsId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerId"].ToString() != "")
                {
                    model.CustomerId = int.Parse(ds.Tables[0].Rows[0]["CustomerId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Count"].ToString() != "")
                {
                    model.Count = decimal.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoredInTime"].ToString() != "")
                {
                    model.StoredInTime = DateTime.Parse(ds.Tables[0].Rows[0]["StoredInTime"].ToString());
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
            strSql.Append("select A.StoreWaitingGoodsId, A.CustomerId, A.StoreId, A.Count, A.Remark as Remark, C.Name as GoodsName, C.Id as GoodsId, D.Name as CustomerName ");
            strSql.Append(" FROM StoreInGoods A, StoreWaitingGoods B, Goods C, Customer D");
            strSql.Append(" where A.StoreWaitingGoodsId = B.Id and B.GoodsId = C.Id and A.CustomerId = D.Id");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
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
            strSql.Append(" FROM StoreInGoods ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetSelectList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" A.Id, A.Count as StoredInCount, A.GoodsId, B.Name as GoodsName, C.Name as CustomerName ");
            strSql.Append(" from StoreInGoods A, Goods B, Customer C ");
            strSql.Append(" where A.GoodsId = B.Id and A.CustomerId = C.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select A.Status, A.Id AS Id, A.Count, A.StoredInTime, A.Remark, A.StoreWaitingGoodsId, B.Name AS GoodsName, C.Name AS CustomerName, D.Name AS StoreName FROM StoreInGoods A, Goods B, Customer C, Store D ");
            strSql.Append("where A.GoodsId = B.Id and b.CustomerId = c.Id and A.StoreId = D.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}

