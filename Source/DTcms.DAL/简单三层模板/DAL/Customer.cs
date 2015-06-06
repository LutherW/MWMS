using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
	.DTcms.DAL
{
	 	//Customer
		public partial class Customer
	{
   		     
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Customer");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = SQL2012Id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4)			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.Customer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Customer(");			
            strSql.Append("Id,Code,Name,LinkMan,LinkTel,LinkAddress,Email,Fax,Status,Remark");
			strSql.Append(") values (");
            strSql.Append("SQL2012Id,SQL2012Code,SQL2012Name,SQL2012LinkMan,SQL2012LinkTel,SQL2012LinkAddress,SQL2012Email,SQL2012Fax,SQL2012Status,SQL2012Remark");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Name", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012LinkMan", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012LinkTel", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012LinkAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Email", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Fax", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Status", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
            };
			            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.Code;                        
            parameters[2].Value = model.Name;                        
            parameters[3].Value = model.LinkMan;                        
            parameters[4].Value = model.LinkTel;                        
            parameters[5].Value = model.LinkAddress;                        
            parameters[6].Value = model.Email;                        
            parameters[7].Value = model.Fax;                        
            parameters[8].Value = model.Status;                        
            parameters[9].Value = model.Remark;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Customer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Customer set ");
			                        
            strSql.Append(" Id = SQL2012Id , ");                                    
            strSql.Append(" Code = SQL2012Code , ");                                    
            strSql.Append(" Name = SQL2012Name , ");                                    
            strSql.Append(" LinkMan = SQL2012LinkMan , ");                                    
            strSql.Append(" LinkTel = SQL2012LinkTel , ");                                    
            strSql.Append(" LinkAddress = SQL2012LinkAddress , ");                                    
            strSql.Append(" Email = SQL2012Email , ");                                    
            strSql.Append(" Fax = SQL2012Fax , ");                                    
            strSql.Append(" Status = SQL2012Status , ");                                    
            strSql.Append(" Remark = SQL2012Remark  ");            			
			strSql.Append(" where Id=SQL2012Id  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Name", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012LinkMan", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012LinkTel", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012LinkAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Email", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Fax", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Status", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.Code;                        
            parameters[2].Value = model.Name;                        
            parameters[3].Value = model.LinkMan;                        
            parameters[4].Value = model.LinkTel;                        
            parameters[5].Value = model.LinkAddress;                        
            parameters[6].Value = model.Email;                        
            parameters[7].Value = model.Fax;                        
            parameters[8].Value = model.Status;                        
            parameters[9].Value = model.Remark;                        
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
			strSql.Append("delete from Customer ");
			strSql.Append(" where Id=SQL2012Id ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4)			};
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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Customer GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, Code, Name, LinkMan, LinkTel, LinkAddress, Email, Fax, Status, Remark  ");			
			strSql.Append("  from Customer ");
			strSql.Append(" where Id=SQL2012Id ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4)			};
			parameters[0].Value = Id;

			
			Maticsoft.Model.Customer model=new Maticsoft.Model.Customer();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																				model.Code= ds.Tables[0].Rows[0]["Code"].ToString();
																																model.Name= ds.Tables[0].Rows[0]["Name"].ToString();
																																model.LinkMan= ds.Tables[0].Rows[0]["LinkMan"].ToString();
																																model.LinkTel= ds.Tables[0].Rows[0]["LinkTel"].ToString();
																																model.LinkAddress= ds.Tables[0].Rows[0]["LinkAddress"].ToString();
																																model.Email= ds.Tables[0].Rows[0]["Email"].ToString();
																																model.Fax= ds.Tables[0].Rows[0]["Fax"].ToString();
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
			strSql.Append(" FROM Customer ");
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
			strSql.Append(" FROM Customer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

