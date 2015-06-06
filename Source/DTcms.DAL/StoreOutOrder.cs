using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
namespace DTcms.DAL  
	
{
	 	//StoreOutOrder
		public partial class StoreOutOrder
	{
   		     
		public bool Exists(int Id,int CustomerId,int StoreInUnitPriceStoreInOrderId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreOutOrder");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = @Id and  ");
                                                                   strSql.Append(" CustomerId = @CustomerId and  ");
                                                                   strSql.Append(" StoreInUnitPriceStoreInOrderId = @StoreInUnitPriceStoreInOrderId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4),
					new SqlParameter("@StoreInUnitPriceStoreInOrderId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = CustomerId;
			parameters[2].Value = StoreInUnitPriceStoreInOrderId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DTcms.Model.StoreOutOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreOutOrder(");			
            strSql.Append("Id,CustomerId,StoreInUnitPriceStoreInOrderId,CreateTime,Admin,InvoiceMoney,HasBeenInvoiced,Status,Remark");
			strSql.Append(") values (");
            strSql.Append("@Id,@CustomerId,@StoreInUnitPriceStoreInOrderId,@CreateTime,@Admin,@InvoiceMoney,@HasBeenInvoiced,@Status,@Remark");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInUnitPriceStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@InvoiceMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@HasBeenInvoiced", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };
			            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.CustomerId;                        
            parameters[2].Value = model.StoreInUnitPriceStoreInOrderId;                        
            parameters[3].Value = model.CreateTime;                        
            parameters[4].Value = model.Admin;                        
            parameters[5].Value = model.InvoiceMoney;                        
            parameters[6].Value = model.HasBeenInvoiced;                        
            parameters[7].Value = model.Status;                        
            parameters[8].Value = model.Remark;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.StoreOutOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreOutOrder set ");
			                        
            strSql.Append(" Id = @Id , ");                                    
            strSql.Append(" CustomerId = @CustomerId , ");                                    
            strSql.Append(" StoreInUnitPriceStoreInOrderId = @StoreInUnitPriceStoreInOrderId , ");                                    
            strSql.Append(" CreateTime = @CreateTime , ");                                    
            strSql.Append(" Admin = @Admin , ");                                    
            strSql.Append(" InvoiceMoney = @InvoiceMoney , ");                                    
            strSql.Append(" HasBeenInvoiced = @HasBeenInvoiced , ");                                    
            strSql.Append(" Status = @Status , ");                                    
            strSql.Append(" Remark = @Remark  ");            			
			strSql.Append(" where Id=@Id and CustomerId=@CustomerId and StoreInUnitPriceStoreInOrderId=@StoreInUnitPriceStoreInOrderId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInUnitPriceStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@InvoiceMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@HasBeenInvoiced", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.CustomerId;                        
            parameters[2].Value = model.StoreInUnitPriceStoreInOrderId;                        
            parameters[3].Value = model.CreateTime;                        
            parameters[4].Value = model.Admin;                        
            parameters[5].Value = model.InvoiceMoney;                        
            parameters[6].Value = model.HasBeenInvoiced;                        
            parameters[7].Value = model.Status;                        
            parameters[8].Value = model.Remark;                        
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
		public bool Delete(int Id,int CustomerId,int StoreInUnitPriceStoreInOrderId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreOutOrder ");
			strSql.Append(" where Id=@Id and CustomerId=@CustomerId and StoreInUnitPriceStoreInOrderId=@StoreInUnitPriceStoreInOrderId ");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4),
					new SqlParameter("@StoreInUnitPriceStoreInOrderId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = CustomerId;
			parameters[2].Value = StoreInUnitPriceStoreInOrderId;


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
		public DTcms.Model.StoreOutOrder GetModel(int Id,int CustomerId,int StoreInUnitPriceStoreInOrderId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, CustomerId, StoreInUnitPriceStoreInOrderId, CreateTime, Admin, InvoiceMoney, HasBeenInvoiced, Status, Remark  ");			
			strSql.Append("  from StoreOutOrder ");
			strSql.Append(" where Id=@Id and CustomerId=@CustomerId and StoreInUnitPriceStoreInOrderId=@StoreInUnitPriceStoreInOrderId ");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4),
					new SqlParameter("@StoreInUnitPriceStoreInOrderId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = CustomerId;
			parameters[2].Value = StoreInUnitPriceStoreInOrderId;

			
			DTcms.Model.StoreOutOrder model=new DTcms.Model.StoreOutOrder();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CustomerId"].ToString()!="")
				{
					model.CustomerId=int.Parse(ds.Tables[0].Rows[0]["CustomerId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreInUnitPriceStoreInOrderId"].ToString()!="")
				{
					model.StoreInUnitPriceStoreInOrderId=int.Parse(ds.Tables[0].Rows[0]["StoreInUnitPriceStoreInOrderId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
				}
																																				model.Admin= ds.Tables[0].Rows[0]["Admin"].ToString();
																												if(ds.Tables[0].Rows[0]["InvoiceMoney"].ToString()!="")
				{
					model.InvoiceMoney=decimal.Parse(ds.Tables[0].Rows[0]["InvoiceMoney"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["HasBeenInvoiced"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["HasBeenInvoiced"].ToString()=="1")||(ds.Tables[0].Rows[0]["HasBeenInvoiced"].ToString().ToLower()=="true"))
					{
					model.HasBeenInvoiced= true;
					}
					else
					{
					model.HasBeenInvoiced= false;
					}
				}
																if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
			strSql.Append(" FROM StoreOutOrder ");
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
			strSql.Append(" FROM StoreOutOrder ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

