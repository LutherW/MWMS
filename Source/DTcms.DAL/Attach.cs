using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
namespace DTcms.DAL  
	
{
	 	//Attach
		public partial class Attach
	{
   		     
		public bool Exists(int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Attach");
			strSql.Append(" where ");
			                                       strSql.Append(" StoreInGoodsStoreInOrderId = @StoreInGoodsStoreInOrderId and  ");
                                                                   strSql.Append(" StoreInGoodsId = @StoreInGoodsId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreInGoodsStoreInOrderId;
			parameters[1].Value = StoreInGoodsId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DTcms.Model.Attach model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Attach(");			
            strSql.Append("StoreInGoodsStoreInOrderId,StoreInGoodsId,FilePath,CreateTime,Admin,Remark");
			strSql.Append(") values (");
            strSql.Append("@StoreInGoodsStoreInOrderId,@StoreInGoodsId,@FilePath,@CreateTime,@Admin,@Remark");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@FilePath", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };
			            
            parameters[0].Value = model.StoreInGoodsStoreInOrderId;                        
            parameters[1].Value = model.StoreInGoodsId;                        
            parameters[2].Value = model.FilePath;                        
            parameters[3].Value = model.CreateTime;                        
            parameters[4].Value = model.Admin;                        
            parameters[5].Value = model.Remark;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.Attach model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Attach set ");
			                        
            strSql.Append(" StoreInGoodsStoreInOrderId = @StoreInGoodsStoreInOrderId , ");                                    
            strSql.Append(" StoreInGoodsId = @StoreInGoodsId , ");                                    
            strSql.Append(" FilePath = @FilePath , ");                                    
            strSql.Append(" CreateTime = @CreateTime , ");                                    
            strSql.Append(" Admin = @Admin , ");                                    
            strSql.Append(" Remark = @Remark  ");            			
			strSql.Append(" where StoreInGoodsStoreInOrderId=@StoreInGoodsStoreInOrderId and StoreInGoodsId=@StoreInGoodsId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@FilePath", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };
						            
            parameters[0].Value = model.StoreInGoodsStoreInOrderId;                        
            parameters[1].Value = model.StoreInGoodsId;                        
            parameters[2].Value = model.FilePath;                        
            parameters[3].Value = model.CreateTime;                        
            parameters[4].Value = model.Admin;                        
            parameters[5].Value = model.Remark;                        
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
		public bool Delete(int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Attach ");
			strSql.Append(" where StoreInGoodsStoreInOrderId=@StoreInGoodsStoreInOrderId and StoreInGoodsId=@StoreInGoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreInGoodsStoreInOrderId;
			parameters[1].Value = StoreInGoodsId;


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
		public DTcms.Model.Attach GetModel(int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StoreInGoodsStoreInOrderId, StoreInGoodsId, FilePath, CreateTime, Admin, Remark  ");			
			strSql.Append("  from Attach ");
			strSql.Append(" where StoreInGoodsStoreInOrderId=@StoreInGoodsStoreInOrderId and StoreInGoodsId=@StoreInGoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreInGoodsStoreInOrderId;
			parameters[1].Value = StoreInGoodsId;

			
			DTcms.Model.Attach model=new DTcms.Model.Attach();
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
																																				model.FilePath= ds.Tables[0].Rows[0]["FilePath"].ToString();
																												if(ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
				}
																																				model.Admin= ds.Tables[0].Rows[0]["Admin"].ToString();
																																model.Remark= ds.Tables[0].Rows[0]["Remark"].ToString();
																										
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
			strSql.Append(" FROM Attach ");
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
			strSql.Append(" FROM Attach ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

