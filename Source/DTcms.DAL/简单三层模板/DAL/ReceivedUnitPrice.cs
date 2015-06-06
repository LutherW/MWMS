using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
	.DTcms.DAL
{
	 	//ReceivedUnitPrice
		public partial class ReceivedUnitPrice
	{
   		     
		public bool Exists(int ReceivedMoneyId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ReceivedUnitPrice");
			strSql.Append(" where ");
			                                       strSql.Append(" ReceivedMoneyId = SQL2012ReceivedMoneyId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ReceivedMoneyId", SqlDbType.Int,4)			};
			parameters[0].Value = ReceivedMoneyId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.ReceivedUnitPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ReceivedUnitPrice(");			
            strSql.Append("ReceivedMoneyId,BeginTime,Price,EndTime,Remark");
			strSql.Append(") values (");
            strSql.Append("SQL2012ReceivedMoneyId,SQL2012BeginTime,SQL2012Price,SQL2012EndTime,SQL2012Remark");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012ReceivedMoneyId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012BeginTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012EndTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
            };
			            
            parameters[0].Value = model.ReceivedMoneyId;                        
            parameters[1].Value = model.BeginTime;                        
            parameters[2].Value = model.Price;                        
            parameters[3].Value = model.EndTime;                        
            parameters[4].Value = model.Remark;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.ReceivedUnitPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ReceivedUnitPrice set ");
			                        
            strSql.Append(" ReceivedMoneyId = SQL2012ReceivedMoneyId , ");                                    
            strSql.Append(" BeginTime = SQL2012BeginTime , ");                                    
            strSql.Append(" Price = SQL2012Price , ");                                    
            strSql.Append(" EndTime = SQL2012EndTime , ");                                    
            strSql.Append(" Remark = SQL2012Remark  ");            			
			strSql.Append(" where ReceivedMoneyId=SQL2012ReceivedMoneyId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012ReceivedMoneyId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012BeginTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012EndTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
            };
						            
            parameters[0].Value = model.ReceivedMoneyId;                        
            parameters[1].Value = model.BeginTime;                        
            parameters[2].Value = model.Price;                        
            parameters[3].Value = model.EndTime;                        
            parameters[4].Value = model.Remark;                        
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
		public bool Delete(int ReceivedMoneyId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ReceivedUnitPrice ");
			strSql.Append(" where ReceivedMoneyId=SQL2012ReceivedMoneyId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012ReceivedMoneyId", SqlDbType.Int,4)			};
			parameters[0].Value = ReceivedMoneyId;


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
		public Maticsoft.Model.ReceivedUnitPrice GetModel(int ReceivedMoneyId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ReceivedMoneyId, BeginTime, Price, EndTime, Remark  ");			
			strSql.Append("  from ReceivedUnitPrice ");
			strSql.Append(" where ReceivedMoneyId=SQL2012ReceivedMoneyId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012ReceivedMoneyId", SqlDbType.Int,4)			};
			parameters[0].Value = ReceivedMoneyId;

			
			Maticsoft.Model.ReceivedUnitPrice model=new Maticsoft.Model.ReceivedUnitPrice();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["ReceivedMoneyId"].ToString()!="")
				{
					model.ReceivedMoneyId=int.Parse(ds.Tables[0].Rows[0]["ReceivedMoneyId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["BeginTime"].ToString()!="")
				{
					model.BeginTime=DateTime.Parse(ds.Tables[0].Rows[0]["BeginTime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
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
			strSql.Append(" FROM ReceivedUnitPrice ");
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
			strSql.Append(" FROM ReceivedUnitPrice ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

