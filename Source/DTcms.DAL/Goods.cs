using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.DAL
{
    //Goods
    public partial class Goods
    {

        public bool Exists(int Id, int UnitId, int CustomerId, int StoreModeId, int HandlingModeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Goods");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id and  ");
            strSql.Append(" UnitId = @UnitId and  ");
            strSql.Append(" CustomerId = @CustomerId and  ");
            strSql.Append(" StoreModeId = @StoreModeId and  ");
            strSql.Append(" HandlingModeId = @HandlingModeId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@UnitId", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4),
					new SqlParameter("@StoreModeId", SqlDbType.Int,4),
					new SqlParameter("@HandlingModeId", SqlDbType.Int,4)			};
            parameters[0].Value = Id;
            parameters[1].Value = UnitId;
            parameters[2].Value = CustomerId;
            parameters[3].Value = StoreModeId;
            parameters[4].Value = HandlingModeId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Goods");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.Goods model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    //try
                    //{
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into Goods(");
                        strSql.Append("UnitId,CustomerId,StoreModeId,HandlingModeId,Name");
                        strSql.Append(") values (");
                        strSql.Append("@UnitId,@CustomerId,@StoreModeId,@HandlingModeId,@Name");
                        strSql.Append(");select @@IDENTITY");

                        SqlParameter[] parameters = {
                                    new SqlParameter("@UnitId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@StoreModeId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@HandlingModeId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@Name", SqlDbType.VarChar,254)             
                        };

                        parameters[0].Value = model.UnitId;
                        parameters[1].Value = model.CustomerId;
                        parameters[2].Value = model.StoreModeId;
                        parameters[3].Value = model.HandlingModeId;
                        parameters[4].Value = model.Name;

                        object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务
                        model.Id = Convert.ToInt32(obj);

                        #region 添加属性====================
                        if (model.AttributeValues.Count > 0)
                        {
                            StringBuilder strSql2;
                            foreach (Model.GoodsAttributeValues attribute in model.AttributeValues)
                            {
                                strSql2 = new StringBuilder();
                                strSql2.Append("insert into GoodsAttributeValues(");
                                strSql2.Append("GoodsId,AttributeName,AttributeValue,Remark");
                                strSql2.Append(") values (");
                                strSql2.Append("@GoodsId,@AttributeName,@AttributeValue,@Remark");
                                strSql2.Append(") ");

                                SqlParameter[] attributeParameters = {
			                                new SqlParameter("@GoodsId", SqlDbType.Int,4) ,            
                                            new SqlParameter("@AttributeName", SqlDbType.VarChar,254) ,            
                                            new SqlParameter("@AttributeValue", SqlDbType.VarChar,254) ,            
                                            new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
                                };

                                attributeParameters[0].Value = model.Id;
                                attributeParameters[1].Value = attribute.AttributeName;
                                attributeParameters[2].Value = attribute.AttributeValue;
                                attributeParameters[3].Value = attribute.Remark;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), attributeParameters); //带事务
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
        public bool Update(DTcms.Model.Goods model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                { 
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update Goods set ");
                        strSql.Append(" UnitId = @UnitId , ");
                        strSql.Append(" CustomerId = @CustomerId , ");
                        strSql.Append(" StoreModeId = @StoreModeId , ");
                        strSql.Append(" HandlingModeId = @HandlingModeId , ");
                        strSql.Append(" Name = @Name  ");
                        strSql.Append(" where Id=@Id ");

                        SqlParameter[] parameters = {
			                        new SqlParameter("@Id", SqlDbType.Int,4) ,            
                                    new SqlParameter("@UnitId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@StoreModeId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@HandlingModeId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@Name", SqlDbType.VarChar,254)             
                        };

                        parameters[0].Value = model.Id;
                        parameters[1].Value = model.UnitId;
                        parameters[2].Value = model.CustomerId;
                        parameters[3].Value = model.StoreModeId;
                        parameters[4].Value = model.HandlingModeId;
                        parameters[5].Value = model.Name;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        new GoodsAttributeValues().DeleteList(conn, trans, model.Id);

                        #region 添加属性====================
                        if (model.AttributeValues.Count > 0)
                        {
                            StringBuilder strSql2;
                            foreach (Model.GoodsAttributeValues attribute in model.AttributeValues)
                            {
                                strSql2 = new StringBuilder();
                                strSql2.Append("insert into GoodsAttributeValues(");
                                strSql2.Append("GoodsId,AttributeName,AttributeValue,Remark");
                                strSql2.Append(") values (");
                                strSql2.Append("@GoodsId,@AttributeName,@AttributeValue,@Remark");
                                strSql2.Append(") ");

                                SqlParameter[] attributeParameters = {
			                                new SqlParameter("@GoodsId", SqlDbType.Int,4) ,            
                                            new SqlParameter("@AttributeName", SqlDbType.VarChar,254) ,            
                                            new SqlParameter("@AttributeValue", SqlDbType.VarChar,254) ,            
                                            new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
                                };

                                attributeParameters[0].Value = model.Id;
                                attributeParameters[1].Value = attribute.AttributeName;
                                attributeParameters[2].Value = attribute.AttributeValue;
                                attributeParameters[3].Value = attribute.Remark;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), attributeParameters); //带事务
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
        public bool Delete(int Id, int UnitId, int CustomerId, int StoreModeId, int HandlingModeId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Goods ");
            strSql.Append(" where Id=@Id and UnitId=@UnitId and CustomerId=@CustomerId and StoreModeId=@StoreModeId and HandlingModeId=@HandlingModeId ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@UnitId", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4),
					new SqlParameter("@StoreModeId", SqlDbType.Int,4),
					new SqlParameter("@HandlingModeId", SqlDbType.Int,4)			};
            parameters[0].Value = Id;
            parameters[1].Value = UnitId;
            parameters[2].Value = CustomerId;
            parameters[3].Value = StoreModeId;
            parameters[4].Value = HandlingModeId;


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
                        strSql.Append("delete from Goods ");
                        strSql.Append(" where Id=@Id ");
                        SqlParameter[] parameters = {
					        new SqlParameter("@Id", SqlDbType.Int,4)			
                        };
                        parameters[0].Value = Id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        new GoodsAttributeValues().DeleteList(conn, trans, Id);

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
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.Goods GetModel(int Id, int UnitId, int CustomerId, int StoreModeId, int HandlingModeId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, UnitId, CustomerId, StoreModeId, HandlingModeId, Name  ");
            strSql.Append("  from Goods ");
            strSql.Append(" where Id=@Id and UnitId=@UnitId and CustomerId=@CustomerId and StoreModeId=@StoreModeId and HandlingModeId=@HandlingModeId ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@UnitId", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4),
					new SqlParameter("@StoreModeId", SqlDbType.Int,4),
					new SqlParameter("@HandlingModeId", SqlDbType.Int,4)			};
            parameters[0].Value = Id;
            parameters[1].Value = UnitId;
            parameters[2].Value = CustomerId;
            parameters[3].Value = StoreModeId;
            parameters[4].Value = HandlingModeId;


            DTcms.Model.Goods model = new DTcms.Model.Goods();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UnitId"].ToString() != "")
                {
                    model.UnitId = int.Parse(ds.Tables[0].Rows[0]["UnitId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerId"].ToString() != "")
                {
                    model.CustomerId = int.Parse(ds.Tables[0].Rows[0]["CustomerId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreModeId"].ToString() != "")
                {
                    model.StoreModeId = int.Parse(ds.Tables[0].Rows[0]["StoreModeId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HandlingModeId"].ToString() != "")
                {
                    model.HandlingModeId = int.Parse(ds.Tables[0].Rows[0]["HandlingModeId"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        public DTcms.Model.Goods GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, UnitId, CustomerId, StoreModeId, HandlingModeId, Name  ");
            strSql.Append("  from Goods ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            DTcms.Model.Goods model = new DTcms.Model.Goods();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UnitId"].ToString() != "")
                {
                    model.UnitId = int.Parse(ds.Tables[0].Rows[0]["UnitId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerId"].ToString() != "")
                {
                    model.CustomerId = int.Parse(ds.Tables[0].Rows[0]["CustomerId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreModeId"].ToString() != "")
                {
                    model.StoreModeId = int.Parse(ds.Tables[0].Rows[0]["StoreModeId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HandlingModeId"].ToString() != "")
                {
                    model.HandlingModeId = int.Parse(ds.Tables[0].Rows[0]["HandlingModeId"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();

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
            strSql.Append(" FROM Goods ");
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
            strSql.Append(" FROM Goods ");
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
            strSql.Append("select g.Id as Id, g.Name as Name, s.Name as StoreModeName, h.Name as HandlingModeName, u.Name as UnitName,c.Name as CustomerName FROM Goods as g, StoreMode as s, HandlingMode as h, Unit as u, Customer as c ");
            strSql.Append("where g.StoreModeId = s.Id and g.HandlingModeId = h.Id and g.UnitId = u.Id and g.CustomerId = c.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}

