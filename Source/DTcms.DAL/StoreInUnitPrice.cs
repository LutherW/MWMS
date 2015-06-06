using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
namespace DTcms.DAL  
	
{
	 	//StoreInUnitPrice
		public partial class StoreInUnitPrice
	{
   		     
		public bool Exists(int StoreInOrderId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreInUnitPrice");
			strSql.Append(" where ");
			                                       strSql.Append(" StoreInOrderId = @StoreInOrderId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreInOrderId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DTcms.Model.StoreInUnitPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreInUnitPrice(");			
            strSql.Append("StoreInOrderId,BeginTime,Price,EndTime,Remark");
			strSql.Append(") values (");
            strSql.Append("@StoreInOrderId,@BeginTime,@Price,@EndTime,@Remark");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@BeginTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@EndTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };
			            
            parameters[0].Value = model.StoreInOrderId;                        
            parameters[1].Value = model.BeginTime;                        
            parameters[2].Value = model.Price;                        
            parameters[3].Value = model.EndTime;                        
            parameters[4].Value = model.Remark;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.StoreInUnitPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreInUnitPrice set ");
			                        
            strSql.Append(" StoreInOrderId = @StoreInOrderId , ");                                    
            strSql.Append(" BeginTime = @BeginTime , ");                                    
            strSql.Append(" Price = @Price , ");                                    
            strSql.Append(" EndTime = @EndTime , ");                                    
            strSql.Append(" Remark = @Remark  ");            			
			strSql.Append(" where StoreInOrderId=@StoreInOrderId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@BeginTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@EndTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };
						            
            parameters[0].Value = model.StoreInOrderId;                        
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
		public bool Delete(int StoreInOrderId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreInUnitPrice ");
			strSql.Append(" where StoreInOrderId=@StoreInOrderId ");
						SqlParameter[] parameters = {
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreInOrderId;


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
		public DTcms.Model.StoreInUnitPrice GetModel(int StoreInOrderId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StoreInOrderId, BeginTime, Price, EndTime, Remark  ");			
			strSql.Append("  from StoreInUnitPrice ");
			strSql.Append(" where StoreInOrderId=@StoreInOrderId ");
						SqlParameter[] parameters = {
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreInOrderId;

			
			DTcms.Model.StoreInUnitPrice model=new DTcms.Model.StoreInUnitPrice();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["StoreInOrderId"].ToString()!="")
				{
					model.StoreInOrderId=int.Parse(ds.Tables[0].Rows[0]["StoreInOrderId"].ToString());
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
			strSql.Append(" FROM StoreInUnitPrice ");
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
			strSql.Append(" FROM StoreInUnitPrice ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

