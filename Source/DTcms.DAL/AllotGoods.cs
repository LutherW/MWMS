using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
namespace DTcms.DAL  
	
{
	 	//AllotGoods
		public partial class AllotGoods
	{
   		     
		public bool Exists(int AllotOrderId,int Id,int StoreInOrderId,int GoodsId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AllotGoods");
			strSql.Append(" where ");
			                                       strSql.Append(" AllotOrderId = @AllotOrderId and  ");
                                                                   strSql.Append(" Id = @Id and  ");
                                                                   strSql.Append(" StoreInOrderId = @StoreInOrderId and  ");
                                                                   strSql.Append(" GoodsId = @GoodsId and  ");
                                                                   strSql.Append(" StoreInGoodsStoreInOrderId = @StoreInGoodsStoreInOrderId and  ");
                                                                   strSql.Append(" StoreInGoodsId = @StoreInGoodsId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@AllotOrderId", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@GoodsId", SqlDbType.Int,4),
					new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4)			};
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
		public void Add(DTcms.Model.AllotGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AllotGoods(");			
            strSql.Append("AllotOrderId,Id,StoreInOrderId,GoodsId,StoreInGoodsStoreInOrderId,StoreInGoodsId,Remark,Count,Status");
			strSql.Append(") values (");
            strSql.Append("@AllotOrderId,@Id,@StoreInOrderId,@GoodsId,@StoreInGoodsStoreInOrderId,@StoreInGoodsId,@Remark,@Count,@Status");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@AllotOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4)             
              
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
		public bool Update(DTcms.Model.AllotGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AllotGoods set ");
			                        
            strSql.Append(" AllotOrderId = @AllotOrderId , ");                                    
            strSql.Append(" Id = @Id , ");                                    
            strSql.Append(" StoreInOrderId = @StoreInOrderId , ");                                    
            strSql.Append(" GoodsId = @GoodsId , ");                                    
            strSql.Append(" StoreInGoodsStoreInOrderId = @StoreInGoodsStoreInOrderId , ");                                    
            strSql.Append(" StoreInGoodsId = @StoreInGoodsId , ");                                    
            strSql.Append(" Remark = @Remark , ");                                    
            strSql.Append(" Count = @Count , ");                                    
            strSql.Append(" Status = @Status  ");            			
			strSql.Append(" where AllotOrderId=@AllotOrderId and Id=@Id and StoreInOrderId=@StoreInOrderId and GoodsId=@GoodsId and StoreInGoodsStoreInOrderId=@StoreInGoodsStoreInOrderId and StoreInGoodsId=@StoreInGoodsId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@AllotOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4)             
              
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
			strSql.Append(" where AllotOrderId=@AllotOrderId and Id=@Id and StoreInOrderId=@StoreInOrderId and GoodsId=@GoodsId and StoreInGoodsStoreInOrderId=@StoreInGoodsStoreInOrderId and StoreInGoodsId=@StoreInGoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("@AllotOrderId", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@GoodsId", SqlDbType.Int,4),
					new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4)			};
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
		public DTcms.Model.AllotGoods GetModel(int AllotOrderId,int Id,int StoreInOrderId,int GoodsId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AllotOrderId, Id, StoreInOrderId, GoodsId, StoreInGoodsStoreInOrderId, StoreInGoodsId, Remark, Count, Status  ");			
			strSql.Append("  from AllotGoods ");
			strSql.Append(" where AllotOrderId=@AllotOrderId and Id=@Id and StoreInOrderId=@StoreInOrderId and GoodsId=@GoodsId and StoreInGoodsStoreInOrderId=@StoreInGoodsStoreInOrderId and StoreInGoodsId=@StoreInGoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("@AllotOrderId", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@GoodsId", SqlDbType.Int,4),
					new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = AllotOrderId;
			parameters[1].Value = Id;
			parameters[2].Value = StoreInOrderId;
			parameters[3].Value = GoodsId;
			parameters[4].Value = StoreInGoodsStoreInOrderId;
			parameters[5].Value = StoreInGoodsId;

			
			DTcms.Model.AllotGoods model=new DTcms.Model.AllotGoods();
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

