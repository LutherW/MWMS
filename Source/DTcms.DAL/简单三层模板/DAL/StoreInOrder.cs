using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
	.DTcms.DAL
{
	 	//StoreInOrder
		public partial class StoreInOrder
	{
   		     
		public bool Exists(int Id,int CustomerId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreInOrder");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = SQL2012Id and  ");
                                                                   strSql.Append(" CustomerId = SQL2012CustomerId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = CustomerId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.StoreInOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreInOrder(");			
            strSql.Append("Id,CustomerId,Status,CreateTime,BeginChargingTime,ChargingTime,Admin,ChargingCount,InspectionNumber,AccountNumber,SuttleWeight,FreeDays,Remark");
			strSql.Append(") values (");
            strSql.Append("SQL2012Id,SQL2012CustomerId,SQL2012Status,SQL2012CreateTime,SQL2012BeginChargingTime,SQL2012ChargingTime,SQL2012Admin,SQL2012ChargingCount,SQL2012InspectionNumber,SQL2012AccountNumber,SQL2012SuttleWeight,SQL2012FreeDays,SQL2012Remark");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Status", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012BeginChargingTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012ChargingTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012ChargingCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012InspectionNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012AccountNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012SuttleWeight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012FreeDays", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
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
            parameters[11].Value = model.FreeDays;                        
            parameters[12].Value = model.Remark;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.StoreInOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreInOrder set ");
			                        
            strSql.Append(" Id = SQL2012Id , ");                                    
            strSql.Append(" CustomerId = SQL2012CustomerId , ");                                    
            strSql.Append(" Status = SQL2012Status , ");                                    
            strSql.Append(" CreateTime = SQL2012CreateTime , ");                                    
            strSql.Append(" BeginChargingTime = SQL2012BeginChargingTime , ");                                    
            strSql.Append(" ChargingTime = SQL2012ChargingTime , ");                                    
            strSql.Append(" Admin = SQL2012Admin , ");                                    
            strSql.Append(" ChargingCount = SQL2012ChargingCount , ");                                    
            strSql.Append(" InspectionNumber = SQL2012InspectionNumber , ");                                    
            strSql.Append(" AccountNumber = SQL2012AccountNumber , ");                                    
            strSql.Append(" SuttleWeight = SQL2012SuttleWeight , ");                                    
            strSql.Append(" FreeDays = SQL2012FreeDays , ");                                    
            strSql.Append(" Remark = SQL2012Remark  ");            			
			strSql.Append(" where Id=SQL2012Id and CustomerId=SQL2012CustomerId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Status", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012BeginChargingTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012ChargingTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012ChargingCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012InspectionNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012AccountNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012SuttleWeight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012FreeDays", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
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
            parameters[11].Value = model.FreeDays;                        
            parameters[12].Value = model.Remark;                        
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
		public bool Delete(int Id,int CustomerId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreInOrder ");
			strSql.Append(" where Id=SQL2012Id and CustomerId=SQL2012CustomerId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = CustomerId;


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
		public Maticsoft.Model.StoreInOrder GetModel(int Id,int CustomerId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, CustomerId, Status, CreateTime, BeginChargingTime, ChargingTime, Admin, ChargingCount, InspectionNumber, AccountNumber, SuttleWeight, FreeDays, Remark  ");			
			strSql.Append("  from StoreInOrder ");
			strSql.Append(" where Id=SQL2012Id and CustomerId=SQL2012CustomerId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = CustomerId;

			
			Maticsoft.Model.StoreInOrder model=new Maticsoft.Model.StoreInOrder();
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
																																if(ds.Tables[0].Rows[0]["FreeDays"].ToString()!="")
				{
					model.FreeDays=int.Parse(ds.Tables[0].Rows[0]["FreeDays"].ToString());
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

