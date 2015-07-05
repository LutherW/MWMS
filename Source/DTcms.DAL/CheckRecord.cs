using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.DAL
{
    //CheckRecord
    public partial class CheckRecord
    {

        public bool Exists(int Id, int VehicleId, int CustomerId, int HandlingModeId, int GoodsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CheckRecord");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id and  ");
            strSql.Append(" VehicleId = @VehicleId and  ");
            strSql.Append(" CustomerId = @CustomerId and  ");
            strSql.Append(" HandlingModeId = @HandlingModeId and  ");
            strSql.Append(" GoodsId = @GoodsId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@VehicleId", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4),
					new SqlParameter("@HandlingModeId", SqlDbType.Int,4),
					new SqlParameter("@GoodsId", SqlDbType.Int,4)			};
            parameters[0].Value = Id;
            parameters[1].Value = VehicleId;
            parameters[2].Value = CustomerId;
            parameters[3].Value = HandlingModeId;
            parameters[4].Value = GoodsId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CheckRecord");
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
        public bool Add(DTcms.Model.CheckRecord model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into CheckRecord(");
                        strSql.Append("VehicleId,CustomerId,HandlingModeId,GoodsId,Status,CreateTime,Admin,InspectionNumber,CaseNumber,CheckResult,RealName,LinkTel,Remark,CheckTime");
                        strSql.Append(") values (");
                        strSql.Append("@VehicleId,@CustomerId,@HandlingModeId,@GoodsId,@Status,@CreateTime,@Admin,@InspectionNumber,@CaseNumber,@CheckResult,@RealName,@LinkTel,@Remark,@CheckTime");
                        strSql.Append(") ");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
			                        new SqlParameter("@VehicleId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@HandlingModeId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@GoodsId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@Status", SqlDbType.Int,4) ,            
                                    new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@InspectionNumber", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@CaseNumber", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@CheckResult", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@RealName", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@LinkTel", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@Remark", SqlDbType.VarChar,254) ,
                                    new SqlParameter("@CheckTime", SqlDbType.DateTime) , 
              
                        };

                        parameters[0].Value = model.VehicleId;
                        parameters[1].Value = model.CustomerId;
                        parameters[2].Value = model.HandlingModeId;
                        parameters[3].Value = model.GoodsId;
                        parameters[4].Value = model.Status;
                        parameters[5].Value = model.CreateTime;
                        parameters[6].Value = model.Admin;
                        parameters[7].Value = model.InspectionNumber;
                        parameters[8].Value = model.CaseNumber;
                        parameters[9].Value = model.CheckResult;
                        parameters[10].Value = model.RealName;
                        parameters[11].Value = model.LinkTel;
                        parameters[12].Value = model.Remark;
                        parameters[13].Value = model.CheckTime;

                        object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务
                        model.Id = Convert.ToInt32(obj);

                        #region 费用====================
                        if (model.CheckCosts.Count > 0)
                        {
                            CheckCost checkCostDAL = new CheckCost();
                            foreach (Model.CheckCost checkCost in model.CheckCosts)
                            {
                                checkCost.CheckRecordId = model.Id;
                                checkCostDAL.Add(conn, trans, checkCost);
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
        public bool Update(DTcms.Model.CheckRecord model)
        {

            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update CheckRecord set ");
                        strSql.Append(" VehicleId = @VehicleId , ");
                        strSql.Append(" CustomerId = @CustomerId , ");
                        strSql.Append(" HandlingModeId = @HandlingModeId , ");
                        strSql.Append(" GoodsId = @GoodsId , ");
                        strSql.Append(" Status = @Status , ");
                        strSql.Append(" CreateTime = @CreateTime , ");
                        strSql.Append(" Admin = @Admin , ");
                        strSql.Append(" InspectionNumber = @InspectionNumber , ");
                        strSql.Append(" CaseNumber = @CaseNumber , ");
                        strSql.Append(" CheckResult = @CheckResult , ");
                        strSql.Append(" RealName = @RealName , ");
                        strSql.Append(" LinkTel = @LinkTel , ");
                        strSql.Append(" Remark = @Remark,  ");
                        strSql.Append(" CheckTime = @CheckTime  ");
                        strSql.Append(" where Id=@Id ");

                        SqlParameter[] parameters = {
			                        new SqlParameter("@Id", SqlDbType.Int,4) ,            
                                    new SqlParameter("@VehicleId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@HandlingModeId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@GoodsId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@Status", SqlDbType.Int,4) ,            
                                    new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@InspectionNumber", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@CaseNumber", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@CheckResult", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@RealName", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@LinkTel", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@Remark", SqlDbType.VarChar,254)  ,            
                                    new SqlParameter("@CheckTime", SqlDbType.DateTime)            
              
                        };

                        parameters[0].Value = model.Id;
                        parameters[1].Value = model.VehicleId;
                        parameters[2].Value = model.CustomerId;
                        parameters[3].Value = model.HandlingModeId;
                        parameters[4].Value = model.GoodsId;
                        parameters[5].Value = model.Status;
                        parameters[6].Value = model.CreateTime;
                        parameters[7].Value = model.Admin;
                        parameters[8].Value = model.InspectionNumber;
                        parameters[9].Value = model.CaseNumber;
                        parameters[10].Value = model.CheckResult;
                        parameters[11].Value = model.RealName;
                        parameters[12].Value = model.LinkTel;
                        parameters[13].Value = model.Remark;
                        parameters[14].Value = model.CheckTime;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);


                        #region 费用
                        CheckCost checkCostDAL = new CheckCost();
                        checkCostDAL.Delete(conn, trans, model.Id);
                        if (model.CheckCosts.Count > 0)
                        {
                            foreach (Model.CheckCost checkCost in model.CheckCosts)
                            {
                                checkCost.CheckRecordId = model.Id;
                                checkCostDAL.Add(conn, trans, checkCost);
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


                return true;
            }
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
                        strSql.Append("delete from CheckRecord ");
                        strSql.Append(" where Id=@Id");
                        SqlParameter[] parameters = {
					            new SqlParameter("@Id", SqlDbType.Int,4)
			            };
                        parameters[0].Value = Id;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        new CheckCost().Delete(conn, trans, Id);

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
            strSql.Append("delete from CheckRecord ");
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
        public DTcms.Model.CheckRecord GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, VehicleId, CustomerId, HandlingModeId, GoodsId, Status, CreateTime, Admin, InspectionNumber, CaseNumber, CheckResult, RealName, LinkTel, Remark,CheckTime  ");
            strSql.Append("  from CheckRecord ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            DTcms.Model.CheckRecord model = new DTcms.Model.CheckRecord();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VehicleId"].ToString() != "")
                {
                    model.VehicleId = int.Parse(ds.Tables[0].Rows[0]["VehicleId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerId"].ToString() != "")
                {
                    model.CustomerId = int.Parse(ds.Tables[0].Rows[0]["CustomerId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HandlingModeId"].ToString() != "")
                {
                    model.HandlingModeId = int.Parse(ds.Tables[0].Rows[0]["HandlingModeId"].ToString());
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
                if (ds.Tables[0].Rows[0]["CheckTime"].ToString() != "")
                {
                    model.CheckTime = DateTime.Parse(ds.Tables[0].Rows[0]["CheckTime"].ToString());
                }
                model.Admin = ds.Tables[0].Rows[0]["Admin"].ToString();
                model.InspectionNumber = ds.Tables[0].Rows[0]["InspectionNumber"].ToString();
                model.CaseNumber = ds.Tables[0].Rows[0]["CaseNumber"].ToString();
                model.CheckResult = ds.Tables[0].Rows[0]["CheckResult"].ToString();
                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                model.LinkTel = ds.Tables[0].Rows[0]["LinkTel"].ToString();
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
            strSql.Append(" FROM CheckRecord ");
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
            strSql.Append(" FROM CheckRecord ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select A.Id as Id, B.Name as CustomerName, C.Name as GoodsName, D.PlateNumber as VehiclePlateNumber, A.InspectionNumber, A.CaseNumber, A.CheckResult, A.RealName, A.LinkTel, A.Admin, A.Remark as Remark, A.CheckTime, E.Name as HandlingModeName ");
            strSql.Append("from CheckRecord A, Customer B, Goods C, Vehicle D, HandlingMode E ");
            strSql.Append("where A.CustomerId = B.Id and A.GoodsId = C.Id and A.VehicleId = D.Id and A.HandlingModeId  = E.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}

