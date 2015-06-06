using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
namespace DTcms.DAL  
	
{
	 	//GoodsAttributeValues
		public partial class GoodsAttributeValues
	{
   		     
		public bool Exists(int GoodsId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from GoodsAttributeValues");
			strSql.Append(" where ");
			                                       strSql.Append(" GoodsId = @GoodsId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@GoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = GoodsId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DTcms.Model.GoodsAttributeValues model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into GoodsAttributeValues(");			
            strSql.Append("GoodsId,AttributeName,AttributeValue,Remark");
			strSql.Append(") values (");
            strSql.Append("@GoodsId,@AttributeName,@AttributeValue,@Remark");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@AttributeName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@AttributeValue", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };
			            
            parameters[0].Value = model.GoodsId;                        
            parameters[1].Value = model.AttributeName;                        
            parameters[2].Value = model.AttributeValue;                        
            parameters[3].Value = model.Remark;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.GoodsAttributeValues model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update GoodsAttributeValues set ");
			                        
            strSql.Append(" GoodsId = @GoodsId , ");                                    
            strSql.Append(" AttributeName = @AttributeName , ");                                    
            strSql.Append(" AttributeValue = @AttributeValue , ");                                    
            strSql.Append(" Remark = @Remark  ");            			
			strSql.Append(" where GoodsId=@GoodsId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@AttributeName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@AttributeValue", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };
						            
            parameters[0].Value = model.GoodsId;                        
            parameters[1].Value = model.AttributeName;                        
            parameters[2].Value = model.AttributeValue;                        
            parameters[3].Value = model.Remark;                        
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
		public bool Delete(int GoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from GoodsAttributeValues ");
			strSql.Append(" where GoodsId=@GoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("@GoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = GoodsId;


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
		public DTcms.Model.GoodsAttributeValues GetModel(int GoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select GoodsId, AttributeName, AttributeValue, Remark  ");			
			strSql.Append("  from GoodsAttributeValues ");
			strSql.Append(" where GoodsId=@GoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("@GoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = GoodsId;

			
			DTcms.Model.GoodsAttributeValues model=new DTcms.Model.GoodsAttributeValues();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["GoodsId"].ToString()!="")
				{
					model.GoodsId=int.Parse(ds.Tables[0].Rows[0]["GoodsId"].ToString());
				}
																																				model.AttributeName= ds.Tables[0].Rows[0]["AttributeName"].ToString();
																																model.AttributeValue= ds.Tables[0].Rows[0]["AttributeValue"].ToString();
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
			strSql.Append(" FROM GoodsAttributeValues ");
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
			strSql.Append(" FROM GoodsAttributeValues ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

