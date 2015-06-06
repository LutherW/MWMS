using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
namespace DTcms.DAL  
	
{
	 	//AllotOrder
		public partial class AllotOrder
	{
   		     
		public bool Exists(int Id,int PurposeStoreId,int SourceStoreId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AllotOrder");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = @Id and  ");
                                                                   strSql.Append(" PurposeStoreId = @PurposeStoreId and  ");
                                                                   strSql.Append(" SourceStoreId = @SourceStoreId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@PurposeStoreId", SqlDbType.Int,4),
					new SqlParameter("@SourceStoreId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = PurposeStoreId;
			parameters[2].Value = SourceStoreId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DTcms.Model.AllotOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AllotOrder(");			
            strSql.Append("Id,PurposeStoreId,SourceStoreId,Remark,CreateTime,Admin");
			strSql.Append(") values (");
            strSql.Append("@Id,@PurposeStoreId,@SourceStoreId,@Remark,@CreateTime,@Admin");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@PurposeStoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@SourceStoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254)             
              
            };
			            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.PurposeStoreId;                        
            parameters[2].Value = model.SourceStoreId;                        
            parameters[3].Value = model.Remark;                        
            parameters[4].Value = model.CreateTime;                        
            parameters[5].Value = model.Admin;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.AllotOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AllotOrder set ");
			                        
            strSql.Append(" Id = @Id , ");                                    
            strSql.Append(" PurposeStoreId = @PurposeStoreId , ");                                    
            strSql.Append(" SourceStoreId = @SourceStoreId , ");                                    
            strSql.Append(" Remark = @Remark , ");                                    
            strSql.Append(" CreateTime = @CreateTime , ");                                    
            strSql.Append(" Admin = @Admin  ");            			
			strSql.Append(" where Id=@Id and PurposeStoreId=@PurposeStoreId and SourceStoreId=@SourceStoreId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@PurposeStoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@SourceStoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.PurposeStoreId;                        
            parameters[2].Value = model.SourceStoreId;                        
            parameters[3].Value = model.Remark;                        
            parameters[4].Value = model.CreateTime;                        
            parameters[5].Value = model.Admin;                        
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
		public bool Delete(int Id,int PurposeStoreId,int SourceStoreId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AllotOrder ");
			strSql.Append(" where Id=@Id and PurposeStoreId=@PurposeStoreId and SourceStoreId=@SourceStoreId ");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@PurposeStoreId", SqlDbType.Int,4),
					new SqlParameter("@SourceStoreId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = PurposeStoreId;
			parameters[2].Value = SourceStoreId;


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
		public DTcms.Model.AllotOrder GetModel(int Id,int PurposeStoreId,int SourceStoreId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, PurposeStoreId, SourceStoreId, Remark, CreateTime, Admin  ");			
			strSql.Append("  from AllotOrder ");
			strSql.Append(" where Id=@Id and PurposeStoreId=@PurposeStoreId and SourceStoreId=@SourceStoreId ");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@PurposeStoreId", SqlDbType.Int,4),
					new SqlParameter("@SourceStoreId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = PurposeStoreId;
			parameters[2].Value = SourceStoreId;

			
			DTcms.Model.AllotOrder model=new DTcms.Model.AllotOrder();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["PurposeStoreId"].ToString()!="")
				{
					model.PurposeStoreId=int.Parse(ds.Tables[0].Rows[0]["PurposeStoreId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SourceStoreId"].ToString()!="")
				{
					model.SourceStoreId=int.Parse(ds.Tables[0].Rows[0]["SourceStoreId"].ToString());
				}
																																				model.Remark= ds.Tables[0].Rows[0]["Remark"].ToString();
																												if(ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
				}
																																				model.Admin= ds.Tables[0].Rows[0]["Admin"].ToString();
																										
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
			strSql.Append(" FROM AllotOrder ");
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
			strSql.Append(" FROM AllotOrder ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

