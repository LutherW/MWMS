using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
	.DTcms.DAL
{
	 	//StoreOutGoodsWithVehicles
		public partial class StoreOutGoodsWithVehicles
	{
   		     
		public bool Exists(int StoreOutGoodsStoreOutOrderId,int StoreOutGoodsId,int StoreOutGoodsVehicleId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreOutGoodsWithVehicles");
			strSql.Append(" where ");
			                                       strSql.Append(" StoreOutGoodsStoreOutOrderId = SQL2012StoreOutGoodsStoreOutOrderId and  ");
                                                                   strSql.Append(" StoreOutGoodsId = SQL2012StoreOutGoodsId and  ");
                                                                   strSql.Append(" StoreOutGoodsVehicleId = SQL2012StoreOutGoodsVehicleId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012StoreOutGoodsStoreOutOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreOutGoodsId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreOutGoodsVehicleId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreOutGoodsStoreOutOrderId;
			parameters[1].Value = StoreOutGoodsId;
			parameters[2].Value = StoreOutGoodsVehicleId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.StoreOutGoodsWithVehicles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreOutGoodsWithVehicles(");			
            strSql.Append("StoreOutGoodsStoreOutOrderId,StoreOutGoodsId,StoreOutGoodsVehicleId");
			strSql.Append(") values (");
            strSql.Append("SQL2012StoreOutGoodsStoreOutOrderId,SQL2012StoreOutGoodsId,SQL2012StoreOutGoodsVehicleId");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012StoreOutGoodsStoreOutOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreOutGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreOutGoodsVehicleId", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.StoreOutGoodsStoreOutOrderId;                        
            parameters[1].Value = model.StoreOutGoodsId;                        
            parameters[2].Value = model.StoreOutGoodsVehicleId;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.StoreOutGoodsWithVehicles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreOutGoodsWithVehicles set ");
			                        
            strSql.Append(" StoreOutGoodsStoreOutOrderId = SQL2012StoreOutGoodsStoreOutOrderId , ");                                    
            strSql.Append(" StoreOutGoodsId = SQL2012StoreOutGoodsId , ");                                    
            strSql.Append(" StoreOutGoodsVehicleId = SQL2012StoreOutGoodsVehicleId  ");            			
			strSql.Append(" where StoreOutGoodsStoreOutOrderId=SQL2012StoreOutGoodsStoreOutOrderId and StoreOutGoodsId=SQL2012StoreOutGoodsId and StoreOutGoodsVehicleId=SQL2012StoreOutGoodsVehicleId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012StoreOutGoodsStoreOutOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreOutGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreOutGoodsVehicleId", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.StoreOutGoodsStoreOutOrderId;                        
            parameters[1].Value = model.StoreOutGoodsId;                        
            parameters[2].Value = model.StoreOutGoodsVehicleId;                        
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
		public bool Delete(int StoreOutGoodsStoreOutOrderId,int StoreOutGoodsId,int StoreOutGoodsVehicleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreOutGoodsWithVehicles ");
			strSql.Append(" where StoreOutGoodsStoreOutOrderId=SQL2012StoreOutGoodsStoreOutOrderId and StoreOutGoodsId=SQL2012StoreOutGoodsId and StoreOutGoodsVehicleId=SQL2012StoreOutGoodsVehicleId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012StoreOutGoodsStoreOutOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreOutGoodsId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreOutGoodsVehicleId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreOutGoodsStoreOutOrderId;
			parameters[1].Value = StoreOutGoodsId;
			parameters[2].Value = StoreOutGoodsVehicleId;


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
		public Maticsoft.Model.StoreOutGoodsWithVehicles GetModel(int StoreOutGoodsStoreOutOrderId,int StoreOutGoodsId,int StoreOutGoodsVehicleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StoreOutGoodsStoreOutOrderId, StoreOutGoodsId, StoreOutGoodsVehicleId  ");			
			strSql.Append("  from StoreOutGoodsWithVehicles ");
			strSql.Append(" where StoreOutGoodsStoreOutOrderId=SQL2012StoreOutGoodsStoreOutOrderId and StoreOutGoodsId=SQL2012StoreOutGoodsId and StoreOutGoodsVehicleId=SQL2012StoreOutGoodsVehicleId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012StoreOutGoodsStoreOutOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreOutGoodsId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreOutGoodsVehicleId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreOutGoodsStoreOutOrderId;
			parameters[1].Value = StoreOutGoodsId;
			parameters[2].Value = StoreOutGoodsVehicleId;

			
			Maticsoft.Model.StoreOutGoodsWithVehicles model=new Maticsoft.Model.StoreOutGoodsWithVehicles();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["StoreOutGoodsStoreOutOrderId"].ToString()!="")
				{
					model.StoreOutGoodsStoreOutOrderId=int.Parse(ds.Tables[0].Rows[0]["StoreOutGoodsStoreOutOrderId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreOutGoodsId"].ToString()!="")
				{
					model.StoreOutGoodsId=int.Parse(ds.Tables[0].Rows[0]["StoreOutGoodsId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreOutGoodsVehicleId"].ToString()!="")
				{
					model.StoreOutGoodsVehicleId=int.Parse(ds.Tables[0].Rows[0]["StoreOutGoodsVehicleId"].ToString());
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
			strSql.Append(" FROM StoreOutGoodsWithVehicles ");
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
			strSql.Append(" FROM StoreOutGoodsWithVehicles ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

