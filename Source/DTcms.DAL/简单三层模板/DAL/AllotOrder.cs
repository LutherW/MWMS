using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
	.DTcms.DAL
{
	 	//AllotOrder
		public partial class AllotOrder
	{
   		     
		public bool Exists(int Id,int PurposeStoreId,int SourceStoreId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AllotOrder");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = SQL2012Id and  ");
                                                                   strSql.Append(" PurposeStoreId = SQL2012PurposeStoreId and  ");
                                                                   strSql.Append(" SourceStoreId = SQL2012SourceStoreId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012PurposeStoreId", SqlDbType.Int,4),
					new SqlParameter("SQL2012SourceStoreId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = PurposeStoreId;
			parameters[2].Value = SourceStoreId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.AllotOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AllotOrder(");			
            strSql.Append("Id,PurposeStoreId,SourceStoreId,Remark,CreateTime,Admin");
			strSql.Append(") values (");
            strSql.Append("SQL2012Id,SQL2012PurposeStoreId,SQL2012SourceStoreId,SQL2012Remark,SQL2012CreateTime,SQL2012Admin");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012PurposeStoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012SourceStoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Admin", SqlDbType.VarChar,254)             
              
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
		public bool Update(Maticsoft.Model.AllotOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AllotOrder set ");
			                        
            strSql.Append(" Id = SQL2012Id , ");                                    
            strSql.Append(" PurposeStoreId = SQL2012PurposeStoreId , ");                                    
            strSql.Append(" SourceStoreId = SQL2012SourceStoreId , ");                                    
            strSql.Append(" Remark = SQL2012Remark , ");                                    
            strSql.Append(" CreateTime = SQL2012CreateTime , ");                                    
            strSql.Append(" Admin = SQL2012Admin  ");            			
			strSql.Append(" where Id=SQL2012Id and PurposeStoreId=SQL2012PurposeStoreId and SourceStoreId=SQL2012SourceStoreId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012PurposeStoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012SourceStoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Admin", SqlDbType.VarChar,254)             
              
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
			strSql.Append(" where Id=SQL2012Id and PurposeStoreId=SQL2012PurposeStoreId and SourceStoreId=SQL2012SourceStoreId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012PurposeStoreId", SqlDbType.Int,4),
					new SqlParameter("SQL2012SourceStoreId", SqlDbType.Int,4)			};
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
		public Maticsoft.Model.AllotOrder GetModel(int Id,int PurposeStoreId,int SourceStoreId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, PurposeStoreId, SourceStoreId, Remark, CreateTime, Admin  ");			
			strSql.Append("  from AllotOrder ");
			strSql.Append(" where Id=SQL2012Id and PurposeStoreId=SQL2012PurposeStoreId and SourceStoreId=SQL2012SourceStoreId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012PurposeStoreId", SqlDbType.Int,4),
					new SqlParameter("SQL2012SourceStoreId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = PurposeStoreId;
			parameters[2].Value = SourceStoreId;

			
			Maticsoft.Model.AllotOrder model=new Maticsoft.Model.AllotOrder();
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

