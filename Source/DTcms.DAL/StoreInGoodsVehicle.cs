using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
namespace DTcms.DAL  
	
{
	 	//StoreInGoodsVehicle
		public partial class StoreInGoodsVehicle
	{
   		     
		public bool Exists(int Id,int VehicleId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreInGoodsVehicle");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = @Id and  ");
                                                                   strSql.Append(" VehicleId = @VehicleId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@VehicleId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = VehicleId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DTcms.Model.StoreInGoodsVehicle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreInGoodsVehicle(");			
            strSql.Append("Id,VehicleId,Remark,Count");
			strSql.Append(") values (");
            strSql.Append("@Id,@VehicleId,@Remark,@Count");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@VehicleId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9)             
              
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
		public bool Update(DTcms.Model.StoreInGoodsVehicle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreInGoodsVehicle set ");
			                        
            strSql.Append(" Id = @Id , ");                                    
            strSql.Append(" VehicleId = @VehicleId , ");                                    
            strSql.Append(" Remark = @Remark , ");                                    
            strSql.Append(" Count = @Count  ");            			
			strSql.Append(" where Id=@Id and VehicleId=@VehicleId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@VehicleId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9)             
              
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
			strSql.Append(" where Id=@Id and VehicleId=@VehicleId ");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@VehicleId", SqlDbType.Int,4)			};
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
		public DTcms.Model.StoreInGoodsVehicle GetModel(int Id,int VehicleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, VehicleId, Remark, Count  ");			
			strSql.Append("  from StoreInGoodsVehicle ");
			strSql.Append(" where Id=@Id and VehicleId=@VehicleId ");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@VehicleId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = VehicleId;

			
			DTcms.Model.StoreInGoodsVehicle model=new DTcms.Model.StoreInGoodsVehicle();
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

