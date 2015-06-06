using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
namespace DTcms.DAL  
	
{
	 	//InvoicedRecord
		public partial class InvoicedRecord
	{
   		     
		public bool Exists(int Id,int ReceivedMoneyId,int StoreInOrderId,int CustomerId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from InvoicedRecord");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = @Id and  ");
                                                                   strSql.Append(" ReceivedMoneyId = @ReceivedMoneyId and  ");
                                                                   strSql.Append(" StoreInOrderId = @StoreInOrderId and  ");
                                                                   strSql.Append(" CustomerId = @CustomerId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@ReceivedMoneyId", SqlDbType.Int,4),
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = ReceivedMoneyId;
			parameters[2].Value = StoreInOrderId;
			parameters[3].Value = CustomerId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DTcms.Model.InvoicedRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into InvoicedRecord(");			
            strSql.Append("Id,ReceivedMoneyId,StoreInOrderId,CustomerId,Remark,CreateTime,Admin,Price");
			strSql.Append(") values (");
            strSql.Append("@Id,@ReceivedMoneyId,@StoreInOrderId,@CustomerId,@Remark,@CreateTime,@Admin,@Price");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@ReceivedMoneyId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Price", SqlDbType.Decimal,9)             
              
            };
			            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.ReceivedMoneyId;                        
            parameters[2].Value = model.StoreInOrderId;                        
            parameters[3].Value = model.CustomerId;                        
            parameters[4].Value = model.Remark;                        
            parameters[5].Value = model.CreateTime;                        
            parameters[6].Value = model.Admin;                        
            parameters[7].Value = model.Price;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.InvoicedRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update InvoicedRecord set ");
			                        
            strSql.Append(" Id = @Id , ");                                    
            strSql.Append(" ReceivedMoneyId = @ReceivedMoneyId , ");                                    
            strSql.Append(" StoreInOrderId = @StoreInOrderId , ");                                    
            strSql.Append(" CustomerId = @CustomerId , ");                                    
            strSql.Append(" Remark = @Remark , ");                                    
            strSql.Append(" CreateTime = @CreateTime , ");                                    
            strSql.Append(" Admin = @Admin , ");                                    
            strSql.Append(" Price = @Price  ");            			
			strSql.Append(" where Id=@Id and ReceivedMoneyId=@ReceivedMoneyId and StoreInOrderId=@StoreInOrderId and CustomerId=@CustomerId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@ReceivedMoneyId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Price", SqlDbType.Decimal,9)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.ReceivedMoneyId;                        
            parameters[2].Value = model.StoreInOrderId;                        
            parameters[3].Value = model.CustomerId;                        
            parameters[4].Value = model.Remark;                        
            parameters[5].Value = model.CreateTime;                        
            parameters[6].Value = model.Admin;                        
            parameters[7].Value = model.Price;                        
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
		public bool Delete(int Id,int ReceivedMoneyId,int StoreInOrderId,int CustomerId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from InvoicedRecord ");
			strSql.Append(" where Id=@Id and ReceivedMoneyId=@ReceivedMoneyId and StoreInOrderId=@StoreInOrderId and CustomerId=@CustomerId ");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@ReceivedMoneyId", SqlDbType.Int,4),
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = ReceivedMoneyId;
			parameters[2].Value = StoreInOrderId;
			parameters[3].Value = CustomerId;


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
		public DTcms.Model.InvoicedRecord GetModel(int Id,int ReceivedMoneyId,int StoreInOrderId,int CustomerId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, ReceivedMoneyId, StoreInOrderId, CustomerId, Remark, CreateTime, Admin, Price  ");			
			strSql.Append("  from InvoicedRecord ");
			strSql.Append(" where Id=@Id and ReceivedMoneyId=@ReceivedMoneyId and StoreInOrderId=@StoreInOrderId and CustomerId=@CustomerId ");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@ReceivedMoneyId", SqlDbType.Int,4),
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = ReceivedMoneyId;
			parameters[2].Value = StoreInOrderId;
			parameters[3].Value = CustomerId;

			
			DTcms.Model.InvoicedRecord model=new DTcms.Model.InvoicedRecord();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["ReceivedMoneyId"].ToString()!="")
				{
					model.ReceivedMoneyId=int.Parse(ds.Tables[0].Rows[0]["ReceivedMoneyId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreInOrderId"].ToString()!="")
				{
					model.StoreInOrderId=int.Parse(ds.Tables[0].Rows[0]["StoreInOrderId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CustomerId"].ToString()!="")
				{
					model.CustomerId=int.Parse(ds.Tables[0].Rows[0]["CustomerId"].ToString());
				}
																																				model.Remark= ds.Tables[0].Rows[0]["Remark"].ToString();
																												if(ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
				}
																																				model.Admin= ds.Tables[0].Rows[0]["Admin"].ToString();
																												if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
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
			strSql.Append(" FROM InvoicedRecord ");
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
			strSql.Append(" FROM InvoicedRecord ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

