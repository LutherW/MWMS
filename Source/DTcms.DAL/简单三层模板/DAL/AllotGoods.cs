using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
	.DTcms.DAL
{
	 	//AllotGoods
		public partial class AllotGoods
	{
   		     
		public bool Exists(int AllotOrderId,int Id,int StoreInOrderId,int GoodsId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AllotGoods");
			strSql.Append(" where ");
			                                       strSql.Append(" AllotOrderId = SQL2012AllotOrderId and  ");
                                                                   strSql.Append(" Id = SQL2012Id and  ");
                                                                   strSql.Append(" StoreInOrderId = SQL2012StoreInOrderId and  ");
                                                                   strSql.Append(" GoodsId = SQL2012GoodsId and  ");
                                                                   strSql.Append(" StoreInGoodsStoreInOrderId = SQL2012StoreInGoodsStoreInOrderId and  ");
                                                                   strSql.Append(" StoreInGoodsId = SQL2012StoreInGoodsId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012AllotOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = AllotOrderId;
			parameters[1].Value = Id;
			parameters[2].Value = StoreInOrderId;
			parameters[3].Value = GoodsId;
			parameters[4].Value = StoreInGoodsStoreInOrderId;
			parameters[5].Value = StoreInGoodsId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.AllotGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AllotGoods(");			
            strSql.Append("AllotOrderId,Id,StoreInOrderId,GoodsId,StoreInGoodsStoreInOrderId,StoreInGoodsId,Remark,Count,Status");
			strSql.Append(") values (");
            strSql.Append("SQL2012AllotOrderId,SQL2012Id,SQL2012StoreInOrderId,SQL2012GoodsId,SQL2012StoreInGoodsStoreInOrderId,SQL2012StoreInGoodsId,SQL2012Remark,SQL2012Count,SQL2012Status");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012AllotOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012Status", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.AllotOrderId;                        
            parameters[1].Value = model.Id;                        
            parameters[2].Value = model.StoreInOrderId;                        
            parameters[3].Value = model.GoodsId;                        
            parameters[4].Value = model.StoreInGoodsStoreInOrderId;                        
            parameters[5].Value = model.StoreInGoodsId;                        
            parameters[6].Value = model.Remark;                        
            parameters[7].Value = model.Count;                        
            parameters[8].Value = model.Status;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.AllotGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AllotGoods set ");
			                        
            strSql.Append(" AllotOrderId = SQL2012AllotOrderId , ");                                    
            strSql.Append(" Id = SQL2012Id , ");                                    
            strSql.Append(" StoreInOrderId = SQL2012StoreInOrderId , ");                                    
            strSql.Append(" GoodsId = SQL2012GoodsId , ");                                    
            strSql.Append(" StoreInGoodsStoreInOrderId = SQL2012StoreInGoodsStoreInOrderId , ");                                    
            strSql.Append(" StoreInGoodsId = SQL2012StoreInGoodsId , ");                                    
            strSql.Append(" Remark = SQL2012Remark , ");                                    
            strSql.Append(" Count = SQL2012Count , ");                                    
            strSql.Append(" Status = SQL2012Status  ");            			
			strSql.Append(" where AllotOrderId=SQL2012AllotOrderId and Id=SQL2012Id and StoreInOrderId=SQL2012StoreInOrderId and GoodsId=SQL2012GoodsId and StoreInGoodsStoreInOrderId=SQL2012StoreInGoodsStoreInOrderId and StoreInGoodsId=SQL2012StoreInGoodsId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012AllotOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012Status", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.AllotOrderId;                        
            parameters[1].Value = model.Id;                        
            parameters[2].Value = model.StoreInOrderId;                        
            parameters[3].Value = model.GoodsId;                        
            parameters[4].Value = model.StoreInGoodsStoreInOrderId;                        
            parameters[5].Value = model.StoreInGoodsId;                        
            parameters[6].Value = model.Remark;                        
            parameters[7].Value = model.Count;                        
            parameters[8].Value = model.Status;                        
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
		public bool Delete(int AllotOrderId,int Id,int StoreInOrderId,int GoodsId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AllotGoods ");
			strSql.Append(" where AllotOrderId=SQL2012AllotOrderId and Id=SQL2012Id and StoreInOrderId=SQL2012StoreInOrderId and GoodsId=SQL2012GoodsId and StoreInGoodsStoreInOrderId=SQL2012StoreInGoodsStoreInOrderId and StoreInGoodsId=SQL2012StoreInGoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012AllotOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = AllotOrderId;
			parameters[1].Value = Id;
			parameters[2].Value = StoreInOrderId;
			parameters[3].Value = GoodsId;
			parameters[4].Value = StoreInGoodsStoreInOrderId;
			parameters[5].Value = StoreInGoodsId;


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
		public Maticsoft.Model.AllotGoods GetModel(int AllotOrderId,int Id,int StoreInOrderId,int GoodsId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AllotOrderId, Id, StoreInOrderId, GoodsId, StoreInGoodsStoreInOrderId, StoreInGoodsId, Remark, Count, Status  ");			
			strSql.Append("  from AllotGoods ");
			strSql.Append(" where AllotOrderId=SQL2012AllotOrderId and Id=SQL2012Id and StoreInOrderId=SQL2012StoreInOrderId and GoodsId=SQL2012GoodsId and StoreInGoodsStoreInOrderId=SQL2012StoreInGoodsStoreInOrderId and StoreInGoodsId=SQL2012StoreInGoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012AllotOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = AllotOrderId;
			parameters[1].Value = Id;
			parameters[2].Value = StoreInOrderId;
			parameters[3].Value = GoodsId;
			parameters[4].Value = StoreInGoodsStoreInOrderId;
			parameters[5].Value = StoreInGoodsId;

			
			Maticsoft.Model.AllotGoods model=new Maticsoft.Model.AllotGoods();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["AllotOrderId"].ToString()!="")
				{
					model.AllotOrderId=int.Parse(ds.Tables[0].Rows[0]["AllotOrderId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreInOrderId"].ToString()!="")
				{
					model.StoreInOrderId=int.Parse(ds.Tables[0].Rows[0]["StoreInOrderId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["GoodsId"].ToString()!="")
				{
					model.GoodsId=int.Parse(ds.Tables[0].Rows[0]["GoodsId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreInGoodsStoreInOrderId"].ToString()!="")
				{
					model.StoreInGoodsStoreInOrderId=int.Parse(ds.Tables[0].Rows[0]["StoreInGoodsStoreInOrderId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreInGoodsId"].ToString()!="")
				{
					model.StoreInGoodsId=int.Parse(ds.Tables[0].Rows[0]["StoreInGoodsId"].ToString());
				}
																																				model.Remark= ds.Tables[0].Rows[0]["Remark"].ToString();
																												if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=decimal.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
			strSql.Append(" FROM AllotGoods ");
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
			strSql.Append(" FROM AllotGoods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

