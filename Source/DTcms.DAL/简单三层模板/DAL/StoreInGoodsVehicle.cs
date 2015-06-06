using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
	.DTcms.DAL
{
	 	//StoreInGoodsVehicle
		public partial class StoreInGoodsVehicle
	{
   		     
		public bool Exists(int Id,int VehicleId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreInGoodsVehicle");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = SQL2012Id and  ");
                                                                   strSql.Append(" VehicleId = SQL2012VehicleId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012VehicleId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = VehicleId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.StoreInGoodsVehicle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreInGoodsVehicle(");			
            strSql.Append("Id,VehicleId,Remark,Count");
			strSql.Append(") values (");
            strSql.Append("SQL2012Id,SQL2012VehicleId,SQL2012Remark,SQL2012Count");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012VehicleId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Count", SqlDbType.Decimal,9)             
              
            };
			            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.VehicleId;                        
            parameters[2].Value = model.Remark;                        
            parameters[3].Value = model.Count;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.StoreInGoodsVehicle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreInGoodsVehicle set ");
			                        
            strSql.Append(" Id = SQL2012Id , ");                                    
            strSql.Append(" VehicleId = SQL2012VehicleId , ");                                    
            strSql.Append(" Remark = SQL2012Remark , ");                                    
            strSql.Append(" Count = SQL2012Count  ");            			
			strSql.Append(" where Id=SQL2012Id and VehicleId=SQL2012VehicleId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012VehicleId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Count", SqlDbType.Decimal,9)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.VehicleId;                        
            parameters[2].Value = model.Remark;                        
            parameters[3].Value = model.Count;                        
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
		public bool Delete(int Id,int VehicleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreInGoodsVehicle ");
			strSql.Append(" where Id=SQL2012Id and VehicleId=SQL2012VehicleId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012VehicleId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
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
		
				
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.StoreInGoodsVehicle GetModel(int Id,int VehicleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, VehicleId, Remark, Count  ");			
			strSql.Append("  from StoreInGoodsVehicle ");
			strSql.Append(" where Id=SQL2012Id and VehicleId=SQL2012VehicleId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012VehicleId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = VehicleId;

			
			Maticsoft.Model.StoreInGoodsVehicle model=new Maticsoft.Model.StoreInGoodsVehicle();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM StoreInGoodsVehicle ");
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
			strSql.Append(" FROM StoreInGoodsVehicle ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

