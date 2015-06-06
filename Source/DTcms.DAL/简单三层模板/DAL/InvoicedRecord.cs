using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
	.DTcms.DAL
{
	 	//InvoicedRecord
		public partial class InvoicedRecord
	{
   		     
		public bool Exists(int Id,int ReceivedMoneyId,int StoreInOrderId,int CustomerId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from InvoicedRecord");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = SQL2012Id and  ");
                                                                   strSql.Append(" ReceivedMoneyId = SQL2012ReceivedMoneyId and  ");
                                                                   strSql.Append(" StoreInOrderId = SQL2012StoreInOrderId and  ");
                                                                   strSql.Append(" CustomerId = SQL2012CustomerId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012ReceivedMoneyId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = ReceivedMoneyId;
			parameters[2].Value = StoreInOrderId;
			parameters[3].Value = CustomerId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.InvoicedRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into InvoicedRecord(");			
            strSql.Append("Id,ReceivedMoneyId,StoreInOrderId,CustomerId,Remark,CreateTime,Admin,Price");
			strSql.Append(") values (");
            strSql.Append("SQL2012Id,SQL2012ReceivedMoneyId,SQL2012StoreInOrderId,SQL2012CustomerId,SQL2012Remark,SQL2012CreateTime,SQL2012Admin,SQL2012Price");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012ReceivedMoneyId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Price", SqlDbType.Decimal,9)             
              
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
		public bool Update(Maticsoft.Model.InvoicedRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update InvoicedRecord set ");
			                        
            strSql.Append(" Id = SQL2012Id , ");                                    
            strSql.Append(" ReceivedMoneyId = SQL2012ReceivedMoneyId , ");                                    
            strSql.Append(" StoreInOrderId = SQL2012StoreInOrderId , ");                                    
            strSql.Append(" CustomerId = SQL2012CustomerId , ");                                    
            strSql.Append(" Remark = SQL2012Remark , ");                                    
            strSql.Append(" CreateTime = SQL2012CreateTime , ");                                    
            strSql.Append(" Admin = SQL2012Admin , ");                                    
            strSql.Append(" Price = SQL2012Price  ");            			
			strSql.Append(" where Id=SQL2012Id and ReceivedMoneyId=SQL2012ReceivedMoneyId and StoreInOrderId=SQL2012StoreInOrderId and CustomerId=SQL2012CustomerId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012ReceivedMoneyId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Price", SqlDbType.Decimal,9)             
              
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
			strSql.Append(" where Id=SQL2012Id and ReceivedMoneyId=SQL2012ReceivedMoneyId and StoreInOrderId=SQL2012StoreInOrderId and CustomerId=SQL2012CustomerId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012ReceivedMoneyId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4)			};
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
		public Maticsoft.Model.InvoicedRecord GetModel(int Id,int ReceivedMoneyId,int StoreInOrderId,int CustomerId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, ReceivedMoneyId, StoreInOrderId, CustomerId, Remark, CreateTime, Admin, Price  ");			
			strSql.Append("  from InvoicedRecord ");
			strSql.Append(" where Id=SQL2012Id and ReceivedMoneyId=SQL2012ReceivedMoneyId and StoreInOrderId=SQL2012StoreInOrderId and CustomerId=SQL2012CustomerId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012ReceivedMoneyId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = ReceivedMoneyId;
			parameters[2].Value = StoreInOrderId;
			parameters[3].Value = CustomerId;

			
			Maticsoft.Model.InvoicedRecord model=new Maticsoft.Model.InvoicedRecord();
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

