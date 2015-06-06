using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
namespace DTcms.DAL  
	
{
	 	//StoreInGoodsWithVehicles
		public partial class StoreInGoodsWithVehicles
	{
   		     
		public bool Exists(int StoreInGoodsStoreInOrderId,int StoreInGoodsId,int StoreInGoodsVehicleId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreInGoodsWithVehicles");
			strSql.Append(" where ");
			                                       strSql.Append(" StoreInGoodsStoreInOrderId = @StoreInGoodsStoreInOrderId and  ");
                                                                   strSql.Append(" StoreInGoodsId = @StoreInGoodsId and  ");
                                                                   strSql.Append(" StoreInGoodsVehicleId = @StoreInGoodsVehicleId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4),
					new SqlParameter("@StoreInGoodsVehicleId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreInGoodsStoreInOrderId;
			parameters[1].Value = StoreInGoodsId;
			parameters[2].Value = StoreInGoodsVehicleId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DTcms.Model.StoreInGoodsWithVehicles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreInGoodsWithVehicles(");			
            strSql.Append("StoreInGoodsStoreInOrderId,StoreInGoodsId,StoreInGoodsVehicleId");
			strSql.Append(") values (");
            strSql.Append("@StoreInGoodsStoreInOrderId,@StoreInGoodsId,@StoreInGoodsVehicleId");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsVehicleId", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.StoreInGoodsStoreInOrderId;                        
            parameters[1].Value = model.StoreInGoodsId;                        
            parameters[2].Value = model.StoreInGoodsVehicleId;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.StoreInGoodsWithVehicles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreInGoodsWithVehicles set ");
			                        
            strSql.Append(" StoreInGoodsStoreInOrderId = @StoreInGoodsStoreInOrderId , ");                                    
            strSql.Append(" StoreInGoodsId = @StoreInGoodsId , ");                                    
            strSql.Append(" StoreInGoodsVehicleId = @StoreInGoodsVehicleId  ");            			
			strSql.Append(" where StoreInGoodsStoreInOrderId=@StoreInGoodsStoreInOrderId and StoreInGoodsId=@StoreInGoodsId and StoreInGoodsVehicleId=@StoreInGoodsVehicleId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsVehicleId", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.StoreInGoodsStoreInOrderId;                        
            parameters[1].Value = model.StoreInGoodsId;                        
            parameters[2].Value = model.StoreInGoodsVehicleId;                        
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
		
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StoreInGoodsStoreInOrderId,int StoreInGoodsId,int StoreInGoodsVehicleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreInGoodsWithVehicles ");
			strSql.Append(" where StoreInGoodsStoreInOrderId=@StoreInGoodsStoreInOrderId and StoreInGoodsId=@StoreInGoodsId and StoreInGoodsVehicleId=@StoreInGoodsVehicleId ");
						SqlParameter[] parameters = {
					new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4),
					new SqlParameter("@StoreInGoodsVehicleId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreInGoodsStoreInOrderId;
			parameters[1].Value = StoreInGoodsId;
			parameters[2].Value = StoreInGoodsVehicleId;


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
		
				
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DTcms.Model.StoreInGoodsWithVehicles GetModel(int StoreInGoodsStoreInOrderId,int StoreInGoodsId,int StoreInGoodsVehicleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StoreInGoodsStoreInOrderId, StoreInGoodsId, StoreInGoodsVehicleId  ");			
			strSql.Append("  from StoreInGoodsWithVehicles ");
			strSql.Append(" where StoreInGoodsStoreInOrderId=@StoreInGoodsStoreInOrderId and StoreInGoodsId=@StoreInGoodsId and StoreInGoodsVehicleId=@StoreInGoodsVehicleId ");
						SqlParameter[] parameters = {
					new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4),
					new SqlParameter("@StoreInGoodsVehicleId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreInGoodsStoreInOrderId;
			parameters[1].Value = StoreInGoodsId;
			parameters[2].Value = StoreInGoodsVehicleId;

			
			DTcms.Model.StoreInGoodsWithVehicles model=new DTcms.Model.StoreInGoodsWithVehicles();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["StoreInGoodsStoreInOrderId"].ToString()!="")
				{
					model.StoreInGoodsStoreInOrderId=int.Parse(ds.Tables[0].Rows[0]["StoreInGoodsStoreInOrderId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreInGoodsId"].ToString()!="")
				{
					model.StoreInGoodsId=int.Parse(ds.Tables[0].Rows[0]["StoreInGoodsId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreInGoodsVehicleId"].ToString()!="")
				{
					model.StoreInGoodsVehicleId=int.Parse(ds.Tables[0].Rows[0]["StoreInGoodsVehicleId"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM StoreInGoodsWithVehicles ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			strSql.Append(" FROM StoreInGoodsWithVehicles ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

