using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
	.DTcms.DAL
{
	 	//Goods
		public partial class Goods
	{
   		     
		public bool Exists(int Id,int UnitId,int CustomerId,int StoreModeId,int HandlingModeId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Goods");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = SQL2012Id and  ");
                                                                   strSql.Append(" UnitId = SQL2012UnitId and  ");
                                                                   strSql.Append(" CustomerId = SQL2012CustomerId and  ");
                                                                   strSql.Append(" StoreModeId = SQL2012StoreModeId and  ");
                                                                   strSql.Append(" HandlingModeId = SQL2012HandlingModeId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012UnitId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreModeId", SqlDbType.Int,4),
					new SqlParameter("SQL2012HandlingModeId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = UnitId;
			parameters[2].Value = CustomerId;
			parameters[3].Value = StoreModeId;
			parameters[4].Value = HandlingModeId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.Goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Goods(");			
            strSql.Append("Id,UnitId,CustomerId,StoreModeId,HandlingModeId,Name");
			strSql.Append(") values (");
            strSql.Append("SQL2012Id,SQL2012UnitId,SQL2012CustomerId,SQL2012StoreModeId,SQL2012HandlingModeId,SQL2012Name");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012UnitId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreModeId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012HandlingModeId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Name", SqlDbType.VarChar,254)             
              
            };
			            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.UnitId;                        
            parameters[2].Value = model.CustomerId;                        
            parameters[3].Value = model.StoreModeId;                        
            parameters[4].Value = model.HandlingModeId;                        
            parameters[5].Value = model.Name;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Goods set ");
			                        
            strSql.Append(" Id = SQL2012Id , ");                                    
            strSql.Append(" UnitId = SQL2012UnitId , ");                                    
            strSql.Append(" CustomerId = SQL2012CustomerId , ");                                    
            strSql.Append(" StoreModeId = SQL2012StoreModeId , ");                                    
            strSql.Append(" HandlingModeId = SQL2012HandlingModeId , ");                                    
            strSql.Append(" Name = SQL2012Name  ");            			
			strSql.Append(" where Id=SQL2012Id and UnitId=SQL2012UnitId and CustomerId=SQL2012CustomerId and StoreModeId=SQL2012StoreModeId and HandlingModeId=SQL2012HandlingModeId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012UnitId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreModeId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012HandlingModeId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Name", SqlDbType.VarChar,254)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.UnitId;                        
            parameters[2].Value = model.CustomerId;                        
            parameters[3].Value = model.StoreModeId;                        
            parameters[4].Value = model.HandlingModeId;                        
            parameters[5].Value = model.Name;                        
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
		public bool Delete(int Id,int UnitId,int CustomerId,int StoreModeId,int HandlingModeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Goods ");
			strSql.Append(" where Id=SQL2012Id and UnitId=SQL2012UnitId and CustomerId=SQL2012CustomerId and StoreModeId=SQL2012StoreModeId and HandlingModeId=SQL2012HandlingModeId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012UnitId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreModeId", SqlDbType.Int,4),
					new SqlParameter("SQL2012HandlingModeId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = UnitId;
			parameters[2].Value = CustomerId;
			parameters[3].Value = StoreModeId;
			parameters[4].Value = HandlingModeId;


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
		public Maticsoft.Model.Goods GetModel(int Id,int UnitId,int CustomerId,int StoreModeId,int HandlingModeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, UnitId, CustomerId, StoreModeId, HandlingModeId, Name  ");			
			strSql.Append("  from Goods ");
			strSql.Append(" where Id=SQL2012Id and UnitId=SQL2012UnitId and CustomerId=SQL2012CustomerId and StoreModeId=SQL2012StoreModeId and HandlingModeId=SQL2012HandlingModeId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012UnitId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreModeId", SqlDbType.Int,4),
					new SqlParameter("SQL2012HandlingModeId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = UnitId;
			parameters[2].Value = CustomerId;
			parameters[3].Value = StoreModeId;
			parameters[4].Value = HandlingModeId;

			
			Maticsoft.Model.Goods model=new Maticsoft.Model.Goods();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UnitId"].ToString()!="")
				{
					model.UnitId=int.Parse(ds.Tables[0].Rows[0]["UnitId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CustomerId"].ToString()!="")
				{
					model.CustomerId=int.Parse(ds.Tables[0].Rows[0]["CustomerId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreModeId"].ToString()!="")
				{
					model.StoreModeId=int.Parse(ds.Tables[0].Rows[0]["StoreModeId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["HandlingModeId"].ToString()!="")
				{
					model.HandlingModeId=int.Parse(ds.Tables[0].Rows[0]["HandlingModeId"].ToString());
				}
																																				model.Name= ds.Tables[0].Rows[0]["Name"].ToString();
																										
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
			strSql.Append(" FROM Goods ");
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
			strSql.Append(" FROM Goods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

