using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
	.DTcms.DAL
{
	 	//Store
		public partial class Store
	{
   		     
		public bool Exists(int Id,int StoreDomainId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Store");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = SQL2012Id and  ");
                                                                   strSql.Append(" StoreDomainId = SQL2012StoreDomainId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreDomainId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = StoreDomainId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.Store model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Store(");			
            strSql.Append("Id,StoreDomainId,Name,Manager,Address,Remark");
			strSql.Append(") values (");
            strSql.Append("SQL2012Id,SQL2012StoreDomainId,SQL2012Name,SQL2012Manager,SQL2012Address,SQL2012Remark");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreDomainId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Name", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Manager", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Address", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
            };
			            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.StoreDomainId;                        
            parameters[2].Value = model.Name;                        
            parameters[3].Value = model.Manager;                        
            parameters[4].Value = model.Address;                        
            parameters[5].Value = model.Remark;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Store model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Store set ");
			                        
            strSql.Append(" Id = SQL2012Id , ");                                    
            strSql.Append(" StoreDomainId = SQL2012StoreDomainId , ");                                    
            strSql.Append(" Name = SQL2012Name , ");                                    
            strSql.Append(" Manager = SQL2012Manager , ");                                    
            strSql.Append(" Address = SQL2012Address , ");                                    
            strSql.Append(" Remark = SQL2012Remark  ");            			
			strSql.Append(" where Id=SQL2012Id and StoreDomainId=SQL2012StoreDomainId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreDomainId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Name", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Manager", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Address", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.StoreDomainId;                        
            parameters[2].Value = model.Name;                        
            parameters[3].Value = model.Manager;                        
            parameters[4].Value = model.Address;                        
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
		public bool Delete(int Id,int StoreDomainId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Store ");
			strSql.Append(" where Id=SQL2012Id and StoreDomainId=SQL2012StoreDomainId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreDomainId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = StoreDomainId;


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
		public Maticsoft.Model.Store GetModel(int Id,int StoreDomainId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, StoreDomainId, Name, Manager, Address, Remark  ");			
			strSql.Append("  from Store ");
			strSql.Append(" where Id=SQL2012Id and StoreDomainId=SQL2012StoreDomainId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreDomainId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = StoreDomainId;

			
			Maticsoft.Model.Store model=new Maticsoft.Model.Store();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreDomainId"].ToString()!="")
				{
					model.StoreDomainId=int.Parse(ds.Tables[0].Rows[0]["StoreDomainId"].ToString());
				}
																																				model.Name= ds.Tables[0].Rows[0]["Name"].ToString();
																																model.Manager= ds.Tables[0].Rows[0]["Manager"].ToString();
																																model.Address= ds.Tables[0].Rows[0]["Address"].ToString();
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
			strSql.Append(" FROM Store ");
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
			strSql.Append(" FROM Store ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

