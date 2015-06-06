using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
	.DTcms.DAL
{
	 	//StoreInGoods
		public partial class StoreInGoods
	{
   		     
		public bool Exists(int StoreInOrderId,int Id,int StoreId,int StoreModeId,int CustomerId,int GoodsId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreInGoods");
			strSql.Append(" where ");
			                                       strSql.Append(" StoreInOrderId = SQL2012StoreInOrderId and  ");
                                                                   strSql.Append(" Id = SQL2012Id and  ");
                                                                   strSql.Append(" StoreId = SQL2012StoreId and  ");
                                                                   strSql.Append(" StoreModeId = SQL2012StoreModeId and  ");
                                                                   strSql.Append(" CustomerId = SQL2012CustomerId and  ");
                                                                   strSql.Append(" GoodsId = SQL2012GoodsId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreModeId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4),
					new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreInOrderId;
			parameters[1].Value = Id;
			parameters[2].Value = StoreId;
			parameters[3].Value = StoreModeId;
			parameters[4].Value = CustomerId;
			parameters[5].Value = GoodsId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.StoreInGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreInGoods(");			
            strSql.Append("StoreInOrderId,Id,StoreId,StoreModeId,CustomerId,GoodsId,Status,Count,StoredInTime,Remark");
			strSql.Append(") values (");
            strSql.Append("SQL2012StoreInOrderId,SQL2012Id,SQL2012StoreId,SQL2012StoreModeId,SQL2012CustomerId,SQL2012GoodsId,SQL2012Status,SQL2012Count,SQL2012StoredInTime,SQL2012Remark");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreModeId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Status", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012StoredInTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
            };
			            
            parameters[0].Value = model.StoreInOrderId;                        
            parameters[1].Value = model.Id;                        
            parameters[2].Value = model.StoreId;                        
            parameters[3].Value = model.StoreModeId;                        
            parameters[4].Value = model.CustomerId;                        
            parameters[5].Value = model.GoodsId;                        
            parameters[6].Value = model.Status;                        
            parameters[7].Value = model.Count;                        
            parameters[8].Value = model.StoredInTime;                        
            parameters[9].Value = model.Remark;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.StoreInGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreInGoods set ");
			                        
            strSql.Append(" StoreInOrderId = SQL2012StoreInOrderId , ");                                    
            strSql.Append(" Id = SQL2012Id , ");                                    
            strSql.Append(" StoreId = SQL2012StoreId , ");                                    
            strSql.Append(" StoreModeId = SQL2012StoreModeId , ");                                    
            strSql.Append(" CustomerId = SQL2012CustomerId , ");                                    
            strSql.Append(" GoodsId = SQL2012GoodsId , ");                                    
            strSql.Append(" Status = SQL2012Status , ");                                    
            strSql.Append(" Count = SQL2012Count , ");                                    
            strSql.Append(" StoredInTime = SQL2012StoredInTime , ");                                    
            strSql.Append(" Remark = SQL2012Remark  ");            			
			strSql.Append(" where StoreInOrderId=SQL2012StoreInOrderId and Id=SQL2012Id and StoreId=SQL2012StoreId and StoreModeId=SQL2012StoreModeId and CustomerId=SQL2012CustomerId and GoodsId=SQL2012GoodsId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreModeId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Status", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012StoredInTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
            };
						            
            parameters[0].Value = model.StoreInOrderId;                        
            parameters[1].Value = model.Id;                        
            parameters[2].Value = model.StoreId;                        
            parameters[3].Value = model.StoreModeId;                        
            parameters[4].Value = model.CustomerId;                        
            parameters[5].Value = model.GoodsId;                        
            parameters[6].Value = model.Status;                        
            parameters[7].Value = model.Count;                        
            parameters[8].Value = model.StoredInTime;                        
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
		public bool Delete(int StoreInOrderId,int Id,int StoreId,int StoreModeId,int CustomerId,int GoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreInGoods ");
			strSql.Append(" where StoreInOrderId=SQL2012StoreInOrderId and Id=SQL2012Id and StoreId=SQL2012StoreId and StoreModeId=SQL2012StoreModeId and CustomerId=SQL2012CustomerId and GoodsId=SQL2012GoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreModeId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4),
					new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreInOrderId;
			parameters[1].Value = Id;
			parameters[2].Value = StoreId;
			parameters[3].Value = StoreModeId;
			parameters[4].Value = CustomerId;
			parameters[5].Value = GoodsId;


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
		public Maticsoft.Model.StoreInGoods GetModel(int StoreInOrderId,int Id,int StoreId,int StoreModeId,int CustomerId,int GoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StoreInOrderId, Id, StoreId, StoreModeId, CustomerId, GoodsId, Status, Count, StoredInTime, Remark  ");			
			strSql.Append("  from StoreInGoods ");
			strSql.Append(" where StoreInOrderId=SQL2012StoreInOrderId and Id=SQL2012Id and StoreId=SQL2012StoreId and StoreModeId=SQL2012StoreModeId and CustomerId=SQL2012CustomerId and GoodsId=SQL2012GoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreModeId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CustomerId", SqlDbType.Int,4),
					new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreInOrderId;
			parameters[1].Value = Id;
			parameters[2].Value = StoreId;
			parameters[3].Value = StoreModeId;
			parameters[4].Value = CustomerId;
			parameters[5].Value = GoodsId;

			
			Maticsoft.Model.StoreInGoods model=new Maticsoft.Model.StoreInGoods();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["StoreInOrderId"].ToString()!="")
				{
					model.StoreInOrderId=int.Parse(ds.Tables[0].Rows[0]["StoreInOrderId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreId"].ToString()!="")
				{
					model.StoreId=int.Parse(ds.Tables[0].Rows[0]["StoreId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreModeId"].ToString()!="")
				{
					model.StoreModeId=int.Parse(ds.Tables[0].Rows[0]["StoreModeId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CustomerId"].ToString()!="")
				{
					model.CustomerId=int.Parse(ds.Tables[0].Rows[0]["CustomerId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["GoodsId"].ToString()!="")
				{
					model.GoodsId=int.Parse(ds.Tables[0].Rows[0]["GoodsId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=decimal.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoredInTime"].ToString()!="")
				{
					model.StoredInTime=DateTime.Parse(ds.Tables[0].Rows[0]["StoredInTime"].ToString());
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
			strSql.Append(" FROM StoreInGoods ");
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
			strSql.Append(" FROM StoreInGoods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

