using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
namespace DTcms.DAL  
	
{
	 	//ReceivedMoney
		public partial class ReceivedMoney
	{
   		     
		public bool Exists(int Id,int StoreInOrderId,int CustomerId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ReceivedMoney");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = @Id and  ");
                                                                   strSql.Append(" StoreInOrderId = @StoreInOrderId and  ");
                                                                   strSql.Append(" CustomerId = @CustomerId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = StoreInOrderId;
			parameters[2].Value = CustomerId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DTcms.Model.ReceivedMoney model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ReceivedMoney(");			
            strSql.Append("Id,StoreInOrderId,CustomerId,Name,BeginChargingTime,EndChargingTime2,ChargingCount,TotalPrice,FactTotalPrice,CreateTime,Admin,Remark,Status");
			strSql.Append(") values (");
            strSql.Append("@Id,@StoreInOrderId,@CustomerId,@Name,@BeginChargingTime,@EndChargingTime2,@ChargingCount,@TotalPrice,@FactTotalPrice,@CreateTime,@Admin,@Remark,@Status");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@BeginChargingTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@EndChargingTime2", SqlDbType.DateTime) ,            
                        new SqlParameter("@ChargingCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactTotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.StoreInOrderId;                        
            parameters[2].Value = model.CustomerId;                        
            parameters[3].Value = model.Name;                        
            parameters[4].Value = model.BeginChargingTime;                        
            parameters[5].Value = model.EndChargingTime2;                        
            parameters[6].Value = model.ChargingCount;                        
            parameters[7].Value = model.TotalPrice;                        
            parameters[8].Value = model.FactTotalPrice;                        
            parameters[9].Value = model.CreateTime;                        
            parameters[10].Value = model.Admin;                        
            parameters[11].Value = model.Remark;                        
            parameters[12].Value = model.Status;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.ReceivedMoney model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ReceivedMoney set ");
			                        
            strSql.Append(" Id = @Id , ");                                    
            strSql.Append(" StoreInOrderId = @StoreInOrderId , ");                                    
            strSql.Append(" CustomerId = @CustomerId , ");                                    
            strSql.Append(" Name = @Name , ");                                    
            strSql.Append(" BeginChargingTime = @BeginChargingTime , ");                                    
            strSql.Append(" EndChargingTime2 = @EndChargingTime2 , ");                                    
            strSql.Append(" ChargingCount = @ChargingCount , ");                                    
            strSql.Append(" TotalPrice = @TotalPrice , ");                                    
            strSql.Append(" FactTotalPrice = @FactTotalPrice , ");                                    
            strSql.Append(" CreateTime = @CreateTime , ");                                    
            strSql.Append(" Admin = @Admin , ");                                    
            strSql.Append(" Remark = @Remark , ");                                    
            strSql.Append(" Status = @Status  ");            			
			strSql.Append(" where Id=@Id and StoreInOrderId=@StoreInOrderId and CustomerId=@CustomerId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@BeginChargingTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@EndChargingTime2", SqlDbType.DateTime) ,            
                        new SqlParameter("@ChargingCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactTotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.StoreInOrderId;                        
            parameters[2].Value = model.CustomerId;                        
            parameters[3].Value = model.Name;                        
            parameters[4].Value = model.BeginChargingTime;                        
            parameters[5].Value = model.EndChargingTime2;                        
            parameters[6].Value = model.ChargingCount;                        
            parameters[7].Value = model.TotalPrice;                        
            parameters[8].Value = model.FactTotalPrice;                        
            parameters[9].Value = model.CreateTime;                        
            parameters[10].Value = model.Admin;                        
            parameters[11].Value = model.Remark;                        
            parameters[12].Value = model.Status;                        
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
		public bool Delete(int Id,int StoreInOrderId,int CustomerId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ReceivedMoney ");
			strSql.Append(" where Id=@Id and StoreInOrderId=@StoreInOrderId and CustomerId=@CustomerId ");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = StoreInOrderId;
			parameters[2].Value = CustomerId;


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
		public DTcms.Model.ReceivedMoney GetModel(int Id,int StoreInOrderId,int CustomerId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, StoreInOrderId, CustomerId, Name, BeginChargingTime, EndChargingTime2, ChargingCount, TotalPrice, FactTotalPrice, CreateTime, Admin, Remark, Status  ");			
			strSql.Append("  from ReceivedMoney ");
			strSql.Append(" where Id=@Id and StoreInOrderId=@StoreInOrderId and CustomerId=@CustomerId ");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = StoreInOrderId;
			parameters[2].Value = CustomerId;

			
			DTcms.Model.ReceivedMoney model=new DTcms.Model.ReceivedMoney();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreInOrderId"].ToString()!="")
				{
					model.StoreInOrderId=int.Parse(ds.Tables[0].Rows[0]["StoreInOrderId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CustomerId"].ToString()!="")
				{
					model.CustomerId=int.Parse(ds.Tables[0].Rows[0]["CustomerId"].ToString());
				}
																																				model.Name= ds.Tables[0].Rows[0]["Name"].ToString();
																												if(ds.Tables[0].Rows[0]["BeginChargingTime"].ToString()!="")
				{
					model.BeginChargingTime=DateTime.Parse(ds.Tables[0].Rows[0]["BeginChargingTime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["EndChargingTime2"].ToString()!="")
				{
					model.EndChargingTime2=DateTime.Parse(ds.Tables[0].Rows[0]["EndChargingTime2"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["ChargingCount"].ToString()!="")
				{
					model.ChargingCount=decimal.Parse(ds.Tables[0].Rows[0]["ChargingCount"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["TotalPrice"].ToString()!="")
				{
					model.TotalPrice=decimal.Parse(ds.Tables[0].Rows[0]["TotalPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["FactTotalPrice"].ToString()!="")
				{
					model.FactTotalPrice=decimal.Parse(ds.Tables[0].Rows[0]["FactTotalPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
				}
																																				model.Admin= ds.Tables[0].Rows[0]["Admin"].ToString();
																																model.Remark= ds.Tables[0].Rows[0]["Remark"].ToString();
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
			strSql.Append(" FROM ReceivedMoney ");
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
			strSql.Append(" FROM ReceivedMoney ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

