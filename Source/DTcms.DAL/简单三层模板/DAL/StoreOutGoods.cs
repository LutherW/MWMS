using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
	.DTcms.DAL
{
	 	//StoreOutGoods
		public partial class StoreOutGoods
	{
   		     
		public bool Exists(int StoreOutOrderId,int Id,int GoodsId,int StoreInOrderId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreOutGoods");
			strSql.Append(" where ");
			                                       strSql.Append(" StoreOutOrderId = SQL2012StoreOutOrderId and  ");
                                                                   strSql.Append(" Id = SQL2012Id and  ");
                                                                   strSql.Append(" GoodsId = SQL2012GoodsId and  ");
                                                                   strSql.Append(" StoreInOrderId = SQL2012StoreInOrderId and  ");
                                                                   strSql.Append(" StoreInGoodsStoreInOrderId = SQL2012StoreInGoodsStoreInOrderId and  ");
                                                                   strSql.Append(" StoreInGoodsId = SQL2012StoreInGoodsId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012StoreOutOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreOutOrderId;
			parameters[1].Value = Id;
			parameters[2].Value = GoodsId;
			parameters[3].Value = StoreInOrderId;
			parameters[4].Value = StoreInGoodsStoreInOrderId;
			parameters[5].Value = StoreInGoodsId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.StoreOutGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreOutGoods(");			
            strSql.Append("StoreOutOrderId,Id,GoodsId,StoreInOrderId,StoreInGoodsStoreInOrderId,StoreInGoodsId,Remark,StoringOutTime,FactStoringOutTime,Status,Count");
			strSql.Append(") values (");
            strSql.Append("SQL2012StoreOutOrderId,SQL2012Id,SQL2012GoodsId,SQL2012StoreInOrderId,SQL2012StoreInGoodsStoreInOrderId,SQL2012StoreInGoodsId,SQL2012Remark,SQL2012StoringOutTime,SQL2012FactStoringOutTime,SQL2012Status,SQL2012Count");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012StoreOutOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012StoringOutTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012FactStoringOutTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Status", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Count", SqlDbType.Decimal,9)             
              
            };
			            
            parameters[0].Value = model.StoreOutOrderId;                        
            parameters[1].Value = model.Id;                        
            parameters[2].Value = model.GoodsId;                        
            parameters[3].Value = model.StoreInOrderId;                        
            parameters[4].Value = model.StoreInGoodsStoreInOrderId;                        
            parameters[5].Value = model.StoreInGoodsId;                        
            parameters[6].Value = model.Remark;                        
            parameters[7].Value = model.StoringOutTime;                        
            parameters[8].Value = model.FactStoringOutTime;                        
            parameters[9].Value = model.Status;                        
            parameters[10].Value = model.Count;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.StoreOutGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreOutGoods set ");
			                        
            strSql.Append(" StoreOutOrderId = SQL2012StoreOutOrderId , ");                                    
            strSql.Append(" Id = SQL2012Id , ");                                    
            strSql.Append(" GoodsId = SQL2012GoodsId , ");                                    
            strSql.Append(" StoreInOrderId = SQL2012StoreInOrderId , ");                                    
            strSql.Append(" StoreInGoodsStoreInOrderId = SQL2012StoreInGoodsStoreInOrderId , ");                                    
            strSql.Append(" StoreInGoodsId = SQL2012StoreInGoodsId , ");                                    
            strSql.Append(" Remark = SQL2012Remark , ");                                    
            strSql.Append(" StoringOutTime = SQL2012StoringOutTime , ");                                    
            strSql.Append(" FactStoringOutTime = SQL2012FactStoringOutTime , ");                                    
            strSql.Append(" Status = SQL2012Status , ");                                    
            strSql.Append(" Count = SQL2012Count  ");            			
			strSql.Append(" where StoreOutOrderId=SQL2012StoreOutOrderId and Id=SQL2012Id and GoodsId=SQL2012GoodsId and StoreInOrderId=SQL2012StoreInOrderId and StoreInGoodsStoreInOrderId=SQL2012StoreInGoodsStoreInOrderId and StoreInGoodsId=SQL2012StoreInGoodsId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012StoreOutOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012StoringOutTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012FactStoringOutTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Status", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Count", SqlDbType.Decimal,9)             
              
            };
						            
            parameters[0].Value = model.StoreOutOrderId;                        
            parameters[1].Value = model.Id;                        
            parameters[2].Value = model.GoodsId;                        
            parameters[3].Value = model.StoreInOrderId;                        
            parameters[4].Value = model.StoreInGoodsStoreInOrderId;                        
            parameters[5].Value = model.StoreInGoodsId;                        
            parameters[6].Value = model.Remark;                        
            parameters[7].Value = model.StoringOutTime;                        
            parameters[8].Value = model.FactStoringOutTime;                        
            parameters[9].Value = model.Status;                        
            parameters[10].Value = model.Count;                        
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
		public bool Delete(int StoreOutOrderId,int Id,int GoodsId,int StoreInOrderId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreOutGoods ");
			strSql.Append(" where StoreOutOrderId=SQL2012StoreOutOrderId and Id=SQL2012Id and GoodsId=SQL2012GoodsId and StoreInOrderId=SQL2012StoreInOrderId and StoreInGoodsStoreInOrderId=SQL2012StoreInGoodsStoreInOrderId and StoreInGoodsId=SQL2012StoreInGoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012StoreOutOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreOutOrderId;
			parameters[1].Value = Id;
			parameters[2].Value = GoodsId;
			parameters[3].Value = StoreInOrderId;
			parameters[4].Value = StoreInGoodsStoreInOrderId;
			parameters[5].Value = StoreInGoodsId;


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
		public Maticsoft.Model.StoreOutGoods GetModel(int StoreOutOrderId,int Id,int GoodsId,int StoreInOrderId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StoreOutOrderId, Id, GoodsId, StoreInOrderId, StoreInGoodsStoreInOrderId, StoreInGoodsId, Remark, StoringOutTime, FactStoringOutTime, Status, Count  ");			
			strSql.Append("  from StoreOutGoods ");
			strSql.Append(" where StoreOutOrderId=SQL2012StoreOutOrderId and Id=SQL2012Id and GoodsId=SQL2012GoodsId and StoreInOrderId=SQL2012StoreInOrderId and StoreInGoodsStoreInOrderId=SQL2012StoreInGoodsStoreInOrderId and StoreInGoodsId=SQL2012StoreInGoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012StoreOutOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Id", SqlDbType.Int,4),
					new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreOutOrderId;
			parameters[1].Value = Id;
			parameters[2].Value = GoodsId;
			parameters[3].Value = StoreInOrderId;
			parameters[4].Value = StoreInGoodsStoreInOrderId;
			parameters[5].Value = StoreInGoodsId;

			
			Maticsoft.Model.StoreOutGoods model=new Maticsoft.Model.StoreOutGoods();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["StoreOutOrderId"].ToString()!="")
				{
					model.StoreOutOrderId=int.Parse(ds.Tables[0].Rows[0]["StoreOutOrderId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["GoodsId"].ToString()!="")
				{
					model.GoodsId=int.Parse(ds.Tables[0].Rows[0]["GoodsId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreInOrderId"].ToString()!="")
				{
					model.StoreInOrderId=int.Parse(ds.Tables[0].Rows[0]["StoreInOrderId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreInGoodsStoreInOrderId"].ToString()!="")
				{
					model.StoreInGoodsStoreInOrderId=int.Parse(ds.Tables[0].Rows[0]["StoreInGoodsStoreInOrderId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreInGoodsId"].ToString()!="")
				{
					model.StoreInGoodsId=int.Parse(ds.Tables[0].Rows[0]["StoreInGoodsId"].ToString());
				}
																																				model.Remark= ds.Tables[0].Rows[0]["Remark"].ToString();
																												if(ds.Tables[0].Rows[0]["StoringOutTime"].ToString()!="")
				{
					model.StoringOutTime=DateTime.Parse(ds.Tables[0].Rows[0]["StoringOutTime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["FactStoringOutTime"].ToString()!="")
				{
					model.FactStoringOutTime=DateTime.Parse(ds.Tables[0].Rows[0]["FactStoringOutTime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=decimal.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
																														
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
			strSql.Append(" FROM StoreOutGoods ");
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
			strSql.Append(" FROM StoreOutGoods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

