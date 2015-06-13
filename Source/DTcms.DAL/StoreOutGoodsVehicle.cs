using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
namespace DTcms.DAL
{
	 	//StoreOutGoodsVehicle
		public partial class StoreOutGoodsVehicle
	{
   		     
		public bool Exists(int StoreOutWaitingGoodsId,int VehicleId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreOutGoodsVehicle");
			strSql.Append(" where ");
			                                       strSql.Append(" StoreOutWaitingGoodsId = @StoreOutWaitingGoodsId and  ");
                                                                   strSql.Append(" VehicleId = @VehicleId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@StoreOutWaitingGoodsId", SqlDbType.Int,4),
					new SqlParameter("@VehicleId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreOutWaitingGoodsId;
			parameters[1].Value = VehicleId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DTcms.Model.StoreOutGoodsVehicle model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StoreOutGoodsVehicle(");
            strSql.Append("StoreOutWaitingGoodsId,VehicleId,Remark,Count");
            strSql.Append(") values (");
            strSql.Append("@StoreOutWaitingGoodsId,@VehicleId,@Remark,@Count");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@StoreOutWaitingGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@VehicleId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9)             
            };

            parameters[0].Value = model.StoreOutWaitingGoodsId;
            parameters[1].Value = model.VehicleId;
            parameters[2].Value = model.Remark;
            parameters[3].Value = model.Count;
                      
			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}

        public void Add(SqlConnection conn, SqlTransaction trans, DTcms.Model.StoreOutGoodsVehicle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StoreOutGoodsVehicle(");
            strSql.Append("StoreOutWaitingGoodsId,VehicleId,Remark,Count");
            strSql.Append(") values (");
            strSql.Append("@StoreOutWaitingGoodsId,@VehicleId,@Remark,@Count");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@StoreOutWaitingGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@VehicleId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9)             
            };

            parameters[0].Value = model.StoreOutWaitingGoodsId;
            parameters[1].Value = model.VehicleId;
            parameters[2].Value = model.Remark;
            parameters[3].Value = model.Count;

            DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
        }
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.StoreOutGoodsVehicle model)
		{
            throw new NotImplementedException();
		}
		
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StoreOutWaitingGoodsId,int VehicleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreOutGoodsVehicle ");
			strSql.Append(" where StoreOutWaitingGoodsId=@StoreOutWaitingGoodsId and VehicleId=@VehicleId ");
						SqlParameter[] parameters = {
					new SqlParameter("@StoreOutWaitingGoodsId", SqlDbType.Int,4),
					new SqlParameter("@VehicleId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreOutWaitingGoodsId;
			parameters[1].Value = VehicleId;


			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

        public bool Delete(SqlConnection conn, SqlTransaction trans, int storeOutWaitingGoodsId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StoreOutGoodsVehicle ");
            strSql.Append(" where StoreOutWaitingGoodsId=@StoreOutWaitingGoodsId ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreOutWaitingGoodsId", SqlDbType.Int,4) };
            parameters[0].Value = storeOutWaitingGoodsId;

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
		/// 得到一个对象实体
		/// </summary>
		public DTcms.Model.StoreOutGoodsVehicle GetModel(int StoreOutWaitingGoodsId,int VehicleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StoreOutGoodsStoreOutOrderId, StoreOutWaitingGoodsId, VehicleId, Remark, Count  ");			
			strSql.Append("  from StoreOutGoodsVehicle ");
			strSql.Append(" where StoreOutWaitingGoodsId=@StoreOutWaitingGoodsId and VehicleId=@VehicleId ");
						SqlParameter[] parameters = {
					new SqlParameter("@StoreOutWaitingGoodsId", SqlDbType.Int,4),
					new SqlParameter("@VehicleId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreOutWaitingGoodsId;
			parameters[1].Value = VehicleId;

			
			DTcms.Model.StoreOutGoodsVehicle model=new DTcms.Model.StoreOutGoodsVehicle();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																																if(ds.Tables[0].Rows[0]["StoreOutWaitingGoodsId"].ToString()!="")
				{
					model.StoreOutWaitingGoodsId=int.Parse(ds.Tables[0].Rows[0]["StoreOutWaitingGoodsId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["VehicleId"].ToString()!="")
				{
					model.VehicleId=int.Parse(ds.Tables[0].Rows[0]["VehicleId"].ToString());
				}
																																				model.Remark= ds.Tables[0].Rows[0]["Remark"].ToString();
																												if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=decimal.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
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
            strSql.Append("select A.Count, A.Remark AS Remark, B.PlateNumber AS VehicleName, B.Id AS VehicleId ");
            strSql.Append(" FROM StoreOutGoodsVehicle A, Vehicle B where A.VehicleId = B.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM StoreOutGoodsVehicle ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

