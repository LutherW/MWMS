using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
	.DTcms.DAL
{
	 	//Attach
		public partial class Attach
	{
   		     
		public bool Exists(int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Attach");
			strSql.Append(" where ");
			                                       strSql.Append(" StoreInGoodsStoreInOrderId = SQL2012StoreInGoodsStoreInOrderId and  ");
                                                                   strSql.Append(" StoreInGoodsId = SQL2012StoreInGoodsId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreInGoodsStoreInOrderId;
			parameters[1].Value = StoreInGoodsId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.Attach model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Attach(");			
            strSql.Append("StoreInGoodsStoreInOrderId,StoreInGoodsId,FilePath,CreateTime,Admin,Remark");
			strSql.Append(") values (");
            strSql.Append("SQL2012StoreInGoodsStoreInOrderId,SQL2012StoreInGoodsId,SQL2012FilePath,SQL2012CreateTime,SQL2012Admin,SQL2012Remark");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012FilePath", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
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
		public bool Update(Maticsoft.Model.Attach model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Attach set ");
			                        
            strSql.Append(" StoreInGoodsStoreInOrderId = SQL2012StoreInGoodsStoreInOrderId , ");                                    
            strSql.Append(" StoreInGoodsId = SQL2012StoreInGoodsId , ");                                    
            strSql.Append(" FilePath = SQL2012FilePath , ");                                    
            strSql.Append(" CreateTime = SQL2012CreateTime , ");                                    
            strSql.Append(" Admin = SQL2012Admin , ");                                    
            strSql.Append(" Remark = SQL2012Remark  ");            			
			strSql.Append(" where StoreInGoodsStoreInOrderId=SQL2012StoreInGoodsStoreInOrderId and StoreInGoodsId=SQL2012StoreInGoodsId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012FilePath", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
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
			strSql.Append(" where StoreInGoodsStoreInOrderId=SQL2012StoreInGoodsStoreInOrderId and StoreInGoodsId=SQL2012StoreInGoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4)			};
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
		public Maticsoft.Model.Attach GetModel(int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StoreInGoodsStoreInOrderId, StoreInGoodsId, FilePath, CreateTime, Admin, Remark  ");			
			strSql.Append("  from Attach ");
			strSql.Append(" where StoreInGoodsStoreInOrderId=SQL2012StoreInGoodsStoreInOrderId and StoreInGoodsId=SQL2012StoreInGoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreInGoodsStoreInOrderId;
			parameters[1].Value = StoreInGoodsId;

			
			Maticsoft.Model.Attach model=new Maticsoft.Model.Attach();
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

