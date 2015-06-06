using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
namespace DTcms.DAL  
	
{
	 	//StoreInGoods
		public partial class StoreInGoods
	{
   		     
		public bool Exists(int StoreInOrderId,int Id,int StoreId,int StoreModeId,int CustomerId,int GoodsId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreInGoods");
			strSql.Append(" where ");
			                                       strSql.Append(" StoreInOrderId = @StoreInOrderId and  ");
                                                                   strSql.Append(" Id = @Id and  ");
                                                                   strSql.Append(" StoreId = @StoreId and  ");
                                                                   strSql.Append(" StoreModeId = @StoreModeId and  ");
                                                                   strSql.Append(" CustomerId = @CustomerId and  ");
                                                                   strSql.Append(" GoodsId = @GoodsId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@StoreId", SqlDbType.Int,4),
					new SqlParameter("@StoreModeId", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4),
					new SqlParameter("@GoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreInOrderId;
			parameters[1].Value = Id;
			parameters[2].Value = StoreId;
			parameters[3].Value = StoreModeId;
			parameters[4].Value = CustomerId;
			parameters[5].Value = GoodsId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DTcms.Model.StoreInGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreInGoods(");			
            strSql.Append("StoreInOrderId,Id,StoreId,StoreModeId,CustomerId,GoodsId,Status,Count,StoredInTime,Remark");
			strSql.Append(") values (");
            strSql.Append("@StoreInOrderId,@Id,@StoreId,@StoreModeId,@CustomerId,@GoodsId,@Status,@Count,@StoredInTime,@Remark");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreModeId", SqlDbType.Int,4) ,            
                        new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("@GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@StoredInTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };
			            
            parameters[0].Value = model.StoreInOrderId;                        
            parameters[1].Value = model.Id;                        
            parameters[2].Value = model.StoreId;                        
            parameters[3].Value = model.StoreModeId;                        
            parameters[4].Value = model.CustomerId;                        
            parameters[5].Value = model.GoodsId;                        
            parameters[6].Value = model.Status;                        
            parameters[7].Value = model.Count;                        
            parameters[8].Value = model.StoredInTime;                        
            parameters[9].Value = model.Remark;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.StoreInGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreInGoods set ");
			                        
            strSql.Append(" StoreInOrderId = @StoreInOrderId , ");                                    
            strSql.Append(" Id = @Id , ");                                    
            strSql.Append(" StoreId = @StoreId , ");                                    
            strSql.Append(" StoreModeId = @StoreModeId , ");                                    
            strSql.Append(" CustomerId = @CustomerId , ");                                    
            strSql.Append(" GoodsId = @GoodsId , ");                                    
            strSql.Append(" Status = @Status , ");                                    
            strSql.Append(" Count = @Count , ");                                    
            strSql.Append(" StoredInTime = @StoredInTime , ");                                    
            strSql.Append(" Remark = @Remark  ");            			
			strSql.Append(" where StoreInOrderId=@StoreInOrderId and Id=@Id and StoreId=@StoreId and StoreModeId=@StoreModeId and CustomerId=@CustomerId and GoodsId=@GoodsId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreModeId", SqlDbType.Int,4) ,            
                        new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("@GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@StoredInTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };
						            
            parameters[0].Value = model.StoreInOrderId;                        
            parameters[1].Value = model.Id;                        
            parameters[2].Value = model.StoreId;                        
            parameters[3].Value = model.StoreModeId;                        
            parameters[4].Value = model.CustomerId;                        
            parameters[5].Value = model.GoodsId;                        
            parameters[6].Value = model.Status;                        
            parameters[7].Value = model.Count;                        
            parameters[8].Value = model.StoredInTime;                        
            parameters[9].Value = model.Remark;                        
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
		public bool Delete(int StoreInOrderId,int Id,int StoreId,int StoreModeId,int CustomerId,int GoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreInGoods ");
			strSql.Append(" where StoreInOrderId=@StoreInOrderId and Id=@Id and StoreId=@StoreId and StoreModeId=@StoreModeId and CustomerId=@CustomerId and GoodsId=@GoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@StoreId", SqlDbType.Int,4),
					new SqlParameter("@StoreModeId", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4),
					new SqlParameter("@GoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreInOrderId;
			parameters[1].Value = Id;
			parameters[2].Value = StoreId;
			parameters[3].Value = StoreModeId;
			parameters[4].Value = CustomerId;
			parameters[5].Value = GoodsId;


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
		public DTcms.Model.StoreInGoods GetModel(int StoreInOrderId,int Id,int StoreId,int StoreModeId,int CustomerId,int GoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StoreInOrderId, Id, StoreId, StoreModeId, CustomerId, GoodsId, Status, Count, StoredInTime, Remark  ");			
			strSql.Append("  from StoreInGoods ");
			strSql.Append(" where StoreInOrderId=@StoreInOrderId and Id=@Id and StoreId=@StoreId and StoreModeId=@StoreModeId and CustomerId=@CustomerId and GoodsId=@GoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@StoreId", SqlDbType.Int,4),
					new SqlParameter("@StoreModeId", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4),
					new SqlParameter("@GoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreInOrderId;
			parameters[1].Value = Id;
			parameters[2].Value = StoreId;
			parameters[3].Value = StoreModeId;
			parameters[4].Value = CustomerId;
			parameters[5].Value = GoodsId;

			
			DTcms.Model.StoreInGoods model=new DTcms.Model.StoreInGoods();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["StoreInOrderId"].ToString()!="")
				{
					model.StoreInOrderId=int.Parse(ds.Tables[0].Rows[0]["StoreInOrderId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreId"].ToString()!="")
				{
					model.StoreId=int.Parse(ds.Tables[0].Rows[0]["StoreId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreModeId"].ToString()!="")
				{
					model.StoreModeId=int.Parse(ds.Tables[0].Rows[0]["StoreModeId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CustomerId"].ToString()!="")
				{
					model.CustomerId=int.Parse(ds.Tables[0].Rows[0]["CustomerId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["GoodsId"].ToString()!="")
				{
					model.GoodsId=int.Parse(ds.Tables[0].Rows[0]["GoodsId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=decimal.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoredInTime"].ToString()!="")
				{
					model.StoredInTime=DateTime.Parse(ds.Tables[0].Rows[0]["StoredInTime"].ToString());
				}
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
			strSql.Append(" FROM StoreInGoods ");
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
			strSql.Append(" FROM StoreInGoods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

