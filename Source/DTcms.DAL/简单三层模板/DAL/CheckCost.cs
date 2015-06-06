using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
	.DTcms.DAL
{
	 	//CheckCost
		public partial class CheckCost
	{
   		     
		public bool Exists(int CheckRecordId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CheckCost");
			strSql.Append(" where ");
			                                       strSql.Append(" CheckRecordId = SQL2012CheckRecordId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CheckRecordId", SqlDbType.Int,4)			};
			parameters[0].Value = CheckRecordId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.CheckCost model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CheckCost(");			
            strSql.Append("CheckRecordId,Name,Count,UnitPrice,TotalPrice,Status,PaidTime,Admin,Customer,HasBeenInvoiced,InvoicedTime,InvoicedOperator,Remark");
			strSql.Append(") values (");
            strSql.Append("SQL2012CheckRecordId,SQL2012Name,SQL2012Count,SQL2012UnitPrice,SQL2012TotalPrice,SQL2012Status,SQL2012PaidTime,SQL2012Admin,SQL2012Customer,SQL2012HasBeenInvoiced,SQL2012InvoicedTime,SQL2012InvoicedOperator,SQL2012Remark");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012CheckRecordId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Name", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012UnitPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012TotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012Status", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012PaidTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Customer", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012HasBeenInvoiced", SqlDbType.Bit,1) ,            
                        new SqlParameter("SQL2012InvoicedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012InvoicedOperator", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
            };
			            
            parameters[0].Value = model.CheckRecordId;                        
            parameters[1].Value = model.Name;                        
            parameters[2].Value = model.Count;                        
            parameters[3].Value = model.UnitPrice;                        
            parameters[4].Value = model.TotalPrice;                        
            parameters[5].Value = model.Status;                        
            parameters[6].Value = model.PaidTime;                        
            parameters[7].Value = model.Admin;                        
            parameters[8].Value = model.Customer;                        
            parameters[9].Value = model.HasBeenInvoiced;                        
            parameters[10].Value = model.InvoicedTime;                        
            parameters[11].Value = model.InvoicedOperator;                        
            parameters[12].Value = model.Remark;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.CheckCost model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CheckCost set ");
			                        
            strSql.Append(" CheckRecordId = SQL2012CheckRecordId , ");                                    
            strSql.Append(" Name = SQL2012Name , ");                                    
            strSql.Append(" Count = SQL2012Count , ");                                    
            strSql.Append(" UnitPrice = SQL2012UnitPrice , ");                                    
            strSql.Append(" TotalPrice = SQL2012TotalPrice , ");                                    
            strSql.Append(" Status = SQL2012Status , ");                                    
            strSql.Append(" PaidTime = SQL2012PaidTime , ");                                    
            strSql.Append(" Admin = SQL2012Admin , ");                                    
            strSql.Append(" Customer = SQL2012Customer , ");                                    
            strSql.Append(" HasBeenInvoiced = SQL2012HasBeenInvoiced , ");                                    
            strSql.Append(" InvoicedTime = SQL2012InvoicedTime , ");                                    
            strSql.Append(" InvoicedOperator = SQL2012InvoicedOperator , ");                                    
            strSql.Append(" Remark = SQL2012Remark  ");            			
			strSql.Append(" where CheckRecordId=SQL2012CheckRecordId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012CheckRecordId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Name", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012UnitPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012TotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012Status", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012PaidTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Customer", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012HasBeenInvoiced", SqlDbType.Bit,1) ,            
                        new SqlParameter("SQL2012InvoicedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012InvoicedOperator", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
            };
						            
            parameters[0].Value = model.CheckRecordId;                        
            parameters[1].Value = model.Name;                        
            parameters[2].Value = model.Count;                        
            parameters[3].Value = model.UnitPrice;                        
            parameters[4].Value = model.TotalPrice;                        
            parameters[5].Value = model.Status;                        
            parameters[6].Value = model.PaidTime;                        
            parameters[7].Value = model.Admin;                        
            parameters[8].Value = model.Customer;                        
            parameters[9].Value = model.HasBeenInvoiced;                        
            parameters[10].Value = model.InvoicedTime;                        
            parameters[11].Value = model.InvoicedOperator;                        
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
		public bool Delete(int CheckRecordId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CheckCost ");
			strSql.Append(" where CheckRecordId=SQL2012CheckRecordId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012CheckRecordId", SqlDbType.Int,4)			};
			parameters[0].Value = CheckRecordId;


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
		public Maticsoft.Model.CheckCost GetModel(int CheckRecordId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CheckRecordId, Name, Count, UnitPrice, TotalPrice, Status, PaidTime, Admin, Customer, HasBeenInvoiced, InvoicedTime, InvoicedOperator, Remark  ");			
			strSql.Append("  from CheckCost ");
			strSql.Append(" where CheckRecordId=SQL2012CheckRecordId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012CheckRecordId", SqlDbType.Int,4)			};
			parameters[0].Value = CheckRecordId;

			
			Maticsoft.Model.CheckCost model=new Maticsoft.Model.CheckCost();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["CheckRecordId"].ToString()!="")
				{
					model.CheckRecordId=int.Parse(ds.Tables[0].Rows[0]["CheckRecordId"].ToString());
				}
																																				model.Name= ds.Tables[0].Rows[0]["Name"].ToString();
																												if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=decimal.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UnitPrice"].ToString()!="")
				{
					model.UnitPrice=decimal.Parse(ds.Tables[0].Rows[0]["UnitPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["TotalPrice"].ToString()!="")
				{
					model.TotalPrice=decimal.Parse(ds.Tables[0].Rows[0]["TotalPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["PaidTime"].ToString()!="")
				{
					model.PaidTime=DateTime.Parse(ds.Tables[0].Rows[0]["PaidTime"].ToString());
				}
																																				model.Admin= ds.Tables[0].Rows[0]["Admin"].ToString();
																																model.Customer= ds.Tables[0].Rows[0]["Customer"].ToString();
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
																if(ds.Tables[0].Rows[0]["InvoicedTime"].ToString()!="")
				{
					model.InvoicedTime=DateTime.Parse(ds.Tables[0].Rows[0]["InvoicedTime"].ToString());
				}
																																				model.InvoicedOperator= ds.Tables[0].Rows[0]["InvoicedOperator"].ToString();
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
			strSql.Append(" FROM CheckCost ");
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
			strSql.Append(" FROM CheckCost ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

