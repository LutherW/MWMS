using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.DAL
{
    //AllotGoods
    public partial class AllotGoods
    {

        public bool Exists(int Id, int AllotOrderId, int StoreInOrderId, int StoreInGoodsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AllotGoods");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id and  ");
            strSql.Append(" AllotOrderId = @AllotOrderId and  ");
            strSql.Append(" StoreInOrderId = @StoreInOrderId and  ");
            strSql.Append(" StoreInGoodsId = @StoreInGoodsId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@AllotOrderId", SqlDbType.Int,4),
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4)			};
            parameters[0].Value = Id;
            parameters[1].Value = AllotOrderId;
            parameters[2].Value = StoreInOrderId;
            parameters[3].Value = StoreInGoodsId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.AllotGoods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AllotGoods(");
            strSql.Append("AllotOrderId,StoreInOrderId,StoreInGoodsId,Remark,Count,Status");
            strSql.Append(") values (");
            strSql.Append("@AllotOrderId,@StoreInOrderId,@StoreInGoodsId,@Remark,@Count,@Status");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@AllotOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.AllotOrderId;
            parameters[1].Value = model.StoreInOrderId;
            parameters[2].Value = model.StoreInGoodsId;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.Count;
            parameters[5].Value = model.Status;

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

        public int Add(SqlConnection conn, SqlTransaction trans, DTcms.Model.AllotGoods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AllotGoods(");
            strSql.Append("AllotOrderId,StoreInOrderId,StoreInGoodsId,Remark,Count,Status,SourceStoreId,PurposeStoreId ");
            strSql.Append(") values (");
            strSql.Append("@AllotOrderId,@StoreInOrderId,@StoreInGoodsId,@Remark,@Count,@Status,@SourceStoreId,@PurposeStoreId");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@AllotOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4),
                        new SqlParameter("@SourceStoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@PurposeStoreId", SqlDbType.Int,4) 
              
            };

            parameters[0].Value = model.AllotOrderId;
            parameters[1].Value = model.StoreInOrderId;
            parameters[2].Value = model.StoreInGoodsId;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.Count;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.SourceStoreId;
            parameters[7].Value = model.PurposeStoreId;

            object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters);

            StoreInGoods storeInGoodsDAL = new StoreInGoods();
            Model.StoreInGoods storeInGoods = storeInGoodsDAL.GetModel(model.StoreInGoodsId);
            if (storeInGoods != null)
	        {
                storeInGoodsDAL.UpdateField(conn, trans, model.StoreInGoodsId, " Count = Count - " + model.Count + "");

                Model.StoreInGoods newStoreInGoods = new Model.StoreInGoods(model.PurposeStoreId, storeInGoods.StoreWaitingGoodsId, storeInGoods.CustomerId, storeInGoods.GoodsId, model.Count, "调拨货物");
                newStoreInGoods.StoreInOrderId = model.StoreInOrderId;
                newStoreInGoods.Status = 1;
                storeInGoodsDAL.Add(conn, trans, newStoreInGoods);
	        }


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
        public bool Update(DTcms.Model.AllotGoods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AllotGoods set ");

            strSql.Append(" AllotOrderId = @AllotOrderId , ");
            strSql.Append(" StoreInOrderId = @StoreInOrderId , ");
            strSql.Append(" StoreInGoodsStoreInOrderId = @StoreInGoodsStoreInOrderId , ");
            strSql.Append(" StoreInGoodsId = @StoreInGoodsId , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" Count = @Count , ");
            strSql.Append(" Status = @Status  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@AllotOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.AllotOrderId;
            parameters[2].Value = model.StoreInOrderId;
            //parameters[3].Value = model.StoreInGoodsStoreInOrderId;
            parameters[4].Value = model.StoreInGoodsId;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.Count;
            parameters[7].Value = model.Status;
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
            strSql.Append("delete from AllotGoods ");
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

        public bool Delete(SqlConnection conn, SqlTransaction trans, int allotOrderId)
        {
            DataTable allotGoodsDT = GetList(0, "AllotOrderId = " + allotOrderId + "", "Id desc").Tables[0];
            if (allotGoodsDT.Rows.Count > 0)
            {
                StoreInGoods storeInGoodsDAL = new StoreInGoods();

                foreach (DataRow dr in allotGoodsDT.Rows)
                {
                    int storeInOrderId = Convert.ToInt32(dr["StoreInOrderId"]);
                    int storeInGoodsId = Convert.ToInt32(dr["StoreInGoodsId"]);
                    int status = Convert.ToInt32(dr["Status"]);
                    decimal count = Convert.ToInt32(dr["Count"]);

                    storeInGoodsDAL.UpdateField(conn, trans, storeInGoodsId, "Count = Count + " + count + "");

                    storeInGoodsDAL.Delete(conn, trans, " StoreInOrderId = " + storeInOrderId + " and Status = 1 ");
                }
            }
            


            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AllotGoods ");
            strSql.Append(" where AllotOrderId=@AllotOrderId");
            SqlParameter[] parameters = {
					new SqlParameter("@AllotOrderId", SqlDbType.Int,4)
			};
            parameters[0].Value = allotOrderId;



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
            strSql.Append("delete from AllotGoods ");
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
        public DTcms.Model.AllotGoods GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, AllotOrderId, StoreInOrderId, StoreInGoodsStoreInOrderId, StoreInGoodsId, Remark, Count, Status  ");
            strSql.Append("  from AllotGoods ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            DTcms.Model.AllotGoods model = new DTcms.Model.AllotGoods();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AllotOrderId"].ToString() != "")
                {
                    model.AllotOrderId = int.Parse(ds.Tables[0].Rows[0]["AllotOrderId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreInOrderId"].ToString() != "")
                {
                    model.StoreInOrderId = int.Parse(ds.Tables[0].Rows[0]["StoreInOrderId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreInGoodsId"].ToString() != "")
                {
                    model.StoreInGoodsId = int.Parse(ds.Tables[0].Rows[0]["StoreInGoodsId"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["Count"].ToString() != "")
                {
                    model.Count = decimal.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
            strSql.Append("select A.Id as Id, A.Count as Count, A.Remark as Remark, A.SourceStoreId, A.PurposeStoreId, A.StoreInOrderId, A.StoreInGoodsId, B.AccountNumber,D.Name as GoodsName, E.Name as SourceStoreName ");
            strSql.Append("from AllotGoods A, StoreInOrder B, StoreInGoods C, Goods D, Store E ");
            strSql.Append("where A.StoreInOrderId = B.Id and A.StoreInGoodsId = C.Id and C.GoodsId = D.Id and A.SourceStoreId = E.Id ");
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
            strSql.Append(" FROM AllotGoods ");
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
            strSql.Append("select A.Id as Id, A.Count as Count, A.Remark as Remark, B.AccountNumber,D.Name as GoodsName, E.Name as SourceStoreName , F.Name as PurposeStoreName");
            strSql.Append("from AllotGoods A, StoreInOrder B, StoreInGoods C, Goods D, Store E, Store F  ");
            strSql.Append("where A.StoreInOrderId = B.Id and A.StoreInGoodsId = C.Id and C.GoodsId = D.Id and A.SourceStoreId = E.Id and A.PurposeStoreId = F.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}

