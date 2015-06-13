using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:StoreOutWaitingGoods
    /// </summary>
    public partial class StoreOutWaitingGoods
    {
        public StoreOutWaitingGoods()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "StoreOutWaitingGoods");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StoreOutWaitingGoods");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.StoreOutWaitingGoods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StoreOutWaitingGoods(");
            strSql.Append("Id,CreateTime,StoringOutTime,StoredOutTime,Admin,Status,Remark,StoreInGoodsId,GoodsId,StoreInOrderId)");
            strSql.Append(" values (");
            strSql.Append("@Id,@CreateTime,@StoringOutTime,@StoredOutTime,@Admin,@Status,@Remark,@StoreInGoodsId,@GoodsId,@StoreInOrderId)");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@StoringOutTime", SqlDbType.DateTime),
					new SqlParameter("@StoredOutTime", SqlDbType.DateTime),
					new SqlParameter("@Admin", SqlDbType.NVarChar,254),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,254),
					new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4),
					new SqlParameter("@GoodsId", SqlDbType.Int,4),
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.CreateTime;
            parameters[2].Value = model.StoringOutTime;
            parameters[3].Value = model.StoredOutTime;
            parameters[4].Value = model.Admin;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.StoreInGoodsId;
            parameters[8].Value = model.GoodsId;
            parameters[9].Value = model.StoreInOrderId;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.StoreOutWaitingGoods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StoreOutWaitingGoods set ");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("StoringOutTime=@StoringOutTime,");
            strSql.Append("StoredOutTime=@StoredOutTime,");
            strSql.Append("Admin=@Admin,");
            strSql.Append("Status=@Status,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("StoreInGoodsId=@StoreInGoodsId,");
            strSql.Append("GoodsId=@GoodsId,");
            strSql.Append("StoreInOrderId=@StoreInOrderId");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@StoringOutTime", SqlDbType.DateTime),
					new SqlParameter("@StoredOutTime", SqlDbType.DateTime),
					new SqlParameter("@Admin", SqlDbType.NVarChar,254),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,254),
					new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4),
					new SqlParameter("@GoodsId", SqlDbType.Int,4),
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.CreateTime;
            parameters[1].Value = model.StoringOutTime;
            parameters[2].Value = model.StoredOutTime;
            parameters[3].Value = model.Admin;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.StoreInGoodsId;
            parameters[7].Value = model.GoodsId;
            parameters[8].Value = model.StoreInOrderId;
            parameters[9].Value = model.Id;

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
            strSql.Append("delete from StoreOutWaitingGoods ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StoreOutWaitingGoods ");
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
        public DTcms.Model.StoreOutWaitingGoods GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,CreateTime,StoringOutTime,StoredOutTime,Admin,Status,Remark,StoreInGoodsId,GoodsId,StoreInOrderId from StoreOutWaitingGoods ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
            parameters[0].Value = Id;

            DTcms.Model.StoreOutWaitingGoods model = new DTcms.Model.StoreOutWaitingGoods();
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
        public DTcms.Model.StoreOutWaitingGoods DataRowToModel(DataRow row)
        {
            DTcms.Model.StoreOutWaitingGoods model = new DTcms.Model.StoreOutWaitingGoods();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["StoringOutTime"] != null && row["StoringOutTime"].ToString() != "")
                {
                    model.StoringOutTime = DateTime.Parse(row["StoringOutTime"].ToString());
                }
                if (row["StoredOutTime"] != null && row["StoredOutTime"].ToString() != "")
                {
                    model.StoredOutTime = DateTime.Parse(row["StoredOutTime"].ToString());
                }
                if (row["Admin"] != null)
                {
                    model.Admin = row["Admin"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["StoreInGoodsId"] != null && row["StoreInGoodsId"].ToString() != "")
                {
                    model.StoreInGoodsId = int.Parse(row["StoreInGoodsId"].ToString());
                }
                if (row["GoodsId"] != null && row["GoodsId"].ToString() != "")
                {
                    model.GoodsId = int.Parse(row["GoodsId"].ToString());
                }
                if (row["StoreInOrderId"] != null && row["StoreInOrderId"].ToString() != "")
                {
                    model.StoreInOrderId = int.Parse(row["StoreInOrderId"].ToString());
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
            strSql.Append("select Id,CreateTime,StoringOutTime,StoredOutTime,Admin,Status,Remark,StoreInGoodsId,GoodsId,StoreInOrderId ");
            strSql.Append(" FROM StoreOutWaitingGoods ");
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
            strSql.Append(" Id,CreateTime,StoringOutTime,StoredOutTime,Admin,Status,Remark,StoreInGoodsId,GoodsId,StoreInOrderId ");
            strSql.Append(" FROM StoreOutWaitingGoods ");
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
            strSql.Append("select count(1) FROM StoreOutWaitingGoods ");
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
            strSql.Append(")AS Row, T.*  from StoreOutWaitingGoods T ");
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
            parameters[0].Value = "StoreOutWaitingGoods";
            parameters[1].Value = "Id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
