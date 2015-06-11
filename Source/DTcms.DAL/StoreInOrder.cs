using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
namespace DTcms.DAL
{
	 	//StoreInOrder
		public partial class StoreInOrder
	{
   		     
		public bool Exists(int Id,int CustomerId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreInOrder");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = @Id and  ");
                                                                   strSql.Append(" CustomerId = @CustomerId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@CustomerId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = CustomerId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StoreInOrder");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4) };
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }		
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DTcms.Model.StoreInOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreInOrder(");			
            strSql.Append("CustomerId,Status,CreateTime,BeginChargingTime,ChargingTime,Admin,ChargingCount,InspectionNumber,AccountNumber,SuttleWeight,Remark");
			strSql.Append(") values (");
            strSql.Append("@CustomerId,@Status,@CreateTime,@BeginChargingTime,@ChargingTime,@Admin,@ChargingCount,@InspectionNumber,@AccountNumber,@SuttleWeight,@Remark");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@BeginChargingTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ChargingTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@ChargingCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@InspectionNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@AccountNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@SuttleWeight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };
			            
            parameters[0].Value = model.CustomerId;                        
            parameters[1].Value = model.Status;                        
            parameters[2].Value = model.CreateTime;                        
            parameters[3].Value = model.BeginChargingTime;                        
            parameters[4].Value = model.ChargingTime;                        
            parameters[5].Value = model.Admin;                        
            parameters[6].Value = model.ChargingCount;                        
            parameters[7].Value = model.InspectionNumber;                        
            parameters[8].Value = model.AccountNumber;                        
            parameters[9].Value = model.SuttleWeight;                        
            parameters[10].Value = model.Remark;                        
			   
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);			
			if (obj == null)
			{
				return 0;
			}
			else
			{
				                    
            	return Convert.ToInt32(obj);
                                                                  
			}			   
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.StoreInOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreInOrder set ");
			                                                
            strSql.Append(" CustomerId = @CustomerId , ");                                    
            strSql.Append(" Status = @Status , ");                                    
            strSql.Append(" CreateTime = @CreateTime , ");                                    
            strSql.Append(" BeginChargingTime = @BeginChargingTime , ");                                    
            strSql.Append(" ChargingTime = @ChargingTime , ");                                    
            strSql.Append(" Admin = @Admin , ");                                    
            strSql.Append(" ChargingCount = @ChargingCount , ");                                    
            strSql.Append(" InspectionNumber = @InspectionNumber , ");                                    
            strSql.Append(" AccountNumber = @AccountNumber , ");                                    
            strSql.Append(" SuttleWeight = @SuttleWeight , ");                                    
            strSql.Append(" Remark = @Remark  ");            			
			strSql.Append(" where Id=@Id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@BeginChargingTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ChargingTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@ChargingCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@InspectionNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@AccountNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@SuttleWeight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.CustomerId;                        
            parameters[2].Value = model.Status;                        
            parameters[3].Value = model.CreateTime;                        
            parameters[4].Value = model.BeginChargingTime;                        
            parameters[5].Value = model.ChargingTime;                        
            parameters[6].Value = model.Admin;                        
            parameters[7].Value = model.ChargingCount;                        
            parameters[8].Value = model.InspectionNumber;                        
            parameters[9].Value = model.AccountNumber;                        
            parameters[10].Value = model.SuttleWeight;                        
            parameters[11].Value = model.Remark;                        
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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreInOrder ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;


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
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreInOrder ");
			strSql.Append(" where ID in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public DTcms.Model.StoreInOrder GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, CustomerId, Status, CreateTime, BeginChargingTime, ChargingTime, Admin, ChargingCount, InspectionNumber, AccountNumber, SuttleWeight, Remark  ");			
			strSql.Append("  from StoreInOrder ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			
			DTcms.Model.StoreInOrder model=new DTcms.Model.StoreInOrder();
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
																																if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["BeginChargingTime"].ToString()!="")
				{
					model.BeginChargingTime=DateTime.Parse(ds.Tables[0].Rows[0]["BeginChargingTime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["ChargingTime"].ToString()!="")
				{
					model.ChargingTime=DateTime.Parse(ds.Tables[0].Rows[0]["ChargingTime"].ToString());
				}
																																				model.Admin= ds.Tables[0].Rows[0]["Admin"].ToString();
																												if(ds.Tables[0].Rows[0]["ChargingCount"].ToString()!="")
				{
					model.ChargingCount=decimal.Parse(ds.Tables[0].Rows[0]["ChargingCount"].ToString());
				}
																																				model.InspectionNumber= ds.Tables[0].Rows[0]["InspectionNumber"].ToString();
																																model.AccountNumber= ds.Tables[0].Rows[0]["AccountNumber"].ToString();
																												if(ds.Tables[0].Rows[0]["SuttleWeight"].ToString()!="")
				{
					model.SuttleWeight=decimal.Parse(ds.Tables[0].Rows[0]["SuttleWeight"].ToString());
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
			strSql.Append(" FROM StoreInOrder ");
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
			strSql.Append(" FROM StoreInOrder ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

