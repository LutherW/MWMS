using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
	.DTcms.DAL
{
	 	//CheckRecord
		public partial class CheckRecord
	{
   		     
		public bool Exists(int Id,int VehicleId,int CustomerId,int HandlingModeId,int GoodsId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CheckRecord");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = SQL2012Id and  ");
                                                                   strSql.Append(" VehicleId = SQL2012VehicleId and  ");
                                                                   strSql.Append(" CustomerId = SQL2012CustomerId and  ");
                                                                   strSql.Append(" HandlingModeId = SQL2012HandlingModeId and  ");
                                                                   strSql.Append(" GoodsId = SQL2012GoodsId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012VehicleId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4),
					new SqlParameter("SQL2012HandlingModeId", SqlDbType.Int,4),
					new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = VehicleId;
			parameters[2].Value = CustomerId;
			parameters[3].Value = HandlingModeId;
			parameters[4].Value = GoodsId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.CheckRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CheckRecord(");			
            strSql.Append("Id,VehicleId,CustomerId,HandlingModeId,GoodsId,Status,CreateTime,Admin,InspectionNumber,CaseNumber,CheckResult,RealName,LinkMan,Remark");
			strSql.Append(") values (");
            strSql.Append("SQL2012Id,SQL2012VehicleId,SQL2012CustomerId,SQL2012HandlingModeId,SQL2012GoodsId,SQL2012Status,SQL2012CreateTime,SQL2012Admin,SQL2012InspectionNumber,SQL2012CaseNumber,SQL2012CheckResult,SQL2012RealName,SQL2012LinkMan,SQL2012Remark");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012VehicleId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012HandlingModeId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Status", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012InspectionNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012CaseNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012CheckResult", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012RealName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012LinkMan", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
            };
			            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.VehicleId;                        
            parameters[2].Value = model.CustomerId;                        
            parameters[3].Value = model.HandlingModeId;                        
            parameters[4].Value = model.GoodsId;                        
            parameters[5].Value = model.Status;                        
            parameters[6].Value = model.CreateTime;                        
            parameters[7].Value = model.Admin;                        
            parameters[8].Value = model.InspectionNumber;                        
            parameters[9].Value = model.CaseNumber;                        
            parameters[10].Value = model.CheckResult;                        
            parameters[11].Value = model.RealName;                        
            parameters[12].Value = model.LinkMan;                        
            parameters[13].Value = model.Remark;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.CheckRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CheckRecord set ");
			                        
            strSql.Append(" Id = SQL2012Id , ");                                    
            strSql.Append(" VehicleId = SQL2012VehicleId , ");                                    
            strSql.Append(" CustomerId = SQL2012CustomerId , ");                                    
            strSql.Append(" HandlingModeId = SQL2012HandlingModeId , ");                                    
            strSql.Append(" GoodsId = SQL2012GoodsId , ");                                    
            strSql.Append(" Status = SQL2012Status , ");                                    
            strSql.Append(" CreateTime = SQL2012CreateTime , ");                                    
            strSql.Append(" Admin = SQL2012Admin , ");                                    
            strSql.Append(" InspectionNumber = SQL2012InspectionNumber , ");                                    
            strSql.Append(" CaseNumber = SQL2012CaseNumber , ");                                    
            strSql.Append(" CheckResult = SQL2012CheckResult , ");                                    
            strSql.Append(" RealName = SQL2012RealName , ");                                    
            strSql.Append(" LinkMan = SQL2012LinkMan , ");                                    
            strSql.Append(" Remark = SQL2012Remark  ");            			
			strSql.Append(" where Id=SQL2012Id and VehicleId=SQL2012VehicleId and CustomerId=SQL2012CustomerId and HandlingModeId=SQL2012HandlingModeId and GoodsId=SQL2012GoodsId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012VehicleId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012HandlingModeId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Status", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012InspectionNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012CaseNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012CheckResult", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012RealName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012LinkMan", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.VehicleId;                        
            parameters[2].Value = model.CustomerId;                        
            parameters[3].Value = model.HandlingModeId;                        
            parameters[4].Value = model.GoodsId;                        
            parameters[5].Value = model.Status;                        
            parameters[6].Value = model.CreateTime;                        
            parameters[7].Value = model.Admin;                        
            parameters[8].Value = model.InspectionNumber;                        
            parameters[9].Value = model.CaseNumber;                        
            parameters[10].Value = model.CheckResult;                        
            parameters[11].Value = model.RealName;                        
            parameters[12].Value = model.LinkMan;                        
            parameters[13].Value = model.Remark;                        
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
		public bool Delete(int Id,int VehicleId,int CustomerId,int HandlingModeId,int GoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CheckRecord ");
			strSql.Append(" where Id=SQL2012Id and VehicleId=SQL2012VehicleId and CustomerId=SQL2012CustomerId and HandlingModeId=SQL2012HandlingModeId and GoodsId=SQL2012GoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012VehicleId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4),
					new SqlParameter("SQL2012HandlingModeId", SqlDbType.Int,4),
					new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = VehicleId;
			parameters[2].Value = CustomerId;
			parameters[3].Value = HandlingModeId;
			parameters[4].Value = GoodsId;


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
		public Maticsoft.Model.CheckRecord GetModel(int Id,int VehicleId,int CustomerId,int HandlingModeId,int GoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, VehicleId, CustomerId, HandlingModeId, GoodsId, Status, CreateTime, Admin, InspectionNumber, CaseNumber, CheckResult, RealName, LinkMan, Remark  ");			
			strSql.Append("  from CheckRecord ");
			strSql.Append(" where Id=SQL2012Id and VehicleId=SQL2012VehicleId and CustomerId=SQL2012CustomerId and HandlingModeId=SQL2012HandlingModeId and GoodsId=SQL2012GoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012VehicleId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4),
					new SqlParameter("SQL2012HandlingModeId", SqlDbType.Int,4),
					new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = VehicleId;
			parameters[2].Value = CustomerId;
			parameters[3].Value = HandlingModeId;
			parameters[4].Value = GoodsId;

			
			Maticsoft.Model.CheckRecord model=new Maticsoft.Model.CheckRecord();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["VehicleId"].ToString()!="")
				{
					model.VehicleId=int.Parse(ds.Tables[0].Rows[0]["VehicleId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CustomerId"].ToString()!="")
				{
					model.CustomerId=int.Parse(ds.Tables[0].Rows[0]["CustomerId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["HandlingModeId"].ToString()!="")
				{
					model.HandlingModeId=int.Parse(ds.Tables[0].Rows[0]["HandlingModeId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["GoodsId"].ToString()!="")
				{
					model.GoodsId=int.Parse(ds.Tables[0].Rows[0]["GoodsId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
				}
																																				model.Admin= ds.Tables[0].Rows[0]["Admin"].ToString();
																																model.InspectionNumber= ds.Tables[0].Rows[0]["InspectionNumber"].ToString();
																																model.CaseNumber= ds.Tables[0].Rows[0]["CaseNumber"].ToString();
																																model.CheckResult= ds.Tables[0].Rows[0]["CheckResult"].ToString();
																																model.RealName= ds.Tables[0].Rows[0]["RealName"].ToString();
																																model.LinkMan= ds.Tables[0].Rows[0]["LinkMan"].ToString();
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
			strSql.Append(" FROM CheckRecord ");
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
			strSql.Append(" FROM CheckRecord ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

