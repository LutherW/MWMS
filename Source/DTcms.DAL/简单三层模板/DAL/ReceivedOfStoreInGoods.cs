using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
	.DTcms.DAL
{
	 	//ReceivedOfStoreInGoods
		public partial class ReceivedOfStoreInGoods
	{
   		     
		public bool Exists(int ReceivedMoneyId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ReceivedOfStoreInGoods");
			strSql.Append(" where ");
			                                       strSql.Append(" ReceivedMoneyId = SQL2012ReceivedMoneyId and  ");
                                                                   strSql.Append(" StoreInGoodsStoreInOrderId = SQL2012StoreInGoodsStoreInOrderId and  ");
                                                                   strSql.Append(" StoreInGoodsId = SQL2012StoreInGoodsId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ReceivedMoneyId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = ReceivedMoneyId;
			parameters[1].Value = StoreInGoodsStoreInOrderId;
			parameters[2].Value = StoreInGoodsId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.ReceivedOfStoreInGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ReceivedOfStoreInGoods(");			
            strSql.Append("ReceivedMoneyId,StoreInGoodsStoreInOrderId,StoreInGoodsId");
			strSql.Append(") values (");
            strSql.Append("SQL2012ReceivedMoneyId,SQL2012StoreInGoodsStoreInOrderId,SQL2012StoreInGoodsId");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012ReceivedMoneyId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.ReceivedMoneyId;                        
            parameters[1].Value = model.StoreInGoodsStoreInOrderId;                        
            parameters[2].Value = model.StoreInGoodsId;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.ReceivedOfStoreInGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ReceivedOfStoreInGoods set ");
			                        
            strSql.Append(" ReceivedMoneyId = SQL2012ReceivedMoneyId , ");                                    
            strSql.Append(" StoreInGoodsStoreInOrderId = SQL2012StoreInGoodsStoreInOrderId , ");                                    
            strSql.Append(" StoreInGoodsId = SQL2012StoreInGoodsId  ");            			
			strSql.Append(" where ReceivedMoneyId=SQL2012ReceivedMoneyId and StoreInGoodsStoreInOrderId=SQL2012StoreInGoodsStoreInOrderId and StoreInGoodsId=SQL2012StoreInGoodsId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012ReceivedMoneyId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.ReceivedMoneyId;                        
            parameters[1].Value = model.StoreInGoodsStoreInOrderId;                        
            parameters[2].Value = model.StoreInGoodsId;                        
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
		public bool Delete(int ReceivedMoneyId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ReceivedOfStoreInGoods ");
			strSql.Append(" where ReceivedMoneyId=SQL2012ReceivedMoneyId and StoreInGoodsStoreInOrderId=SQL2012StoreInGoodsStoreInOrderId and StoreInGoodsId=SQL2012StoreInGoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012ReceivedMoneyId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = ReceivedMoneyId;
			parameters[1].Value = StoreInGoodsStoreInOrderId;
			parameters[2].Value = StoreInGoodsId;


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
		public Maticsoft.Model.ReceivedOfStoreInGoods GetModel(int ReceivedMoneyId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ReceivedMoneyId, StoreInGoodsStoreInOrderId, StoreInGoodsId  ");			
			strSql.Append("  from ReceivedOfStoreInGoods ");
			strSql.Append(" where ReceivedMoneyId=SQL2012ReceivedMoneyId and StoreInGoodsStoreInOrderId=SQL2012StoreInGoodsStoreInOrderId and StoreInGoodsId=SQL2012StoreInGoodsId ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012ReceivedMoneyId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsStoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("SQL2012StoreInGoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = ReceivedMoneyId;
			parameters[1].Value = StoreInGoodsStoreInOrderId;
			parameters[2].Value = StoreInGoodsId;

			
			Maticsoft.Model.ReceivedOfStoreInGoods model=new Maticsoft.Model.ReceivedOfStoreInGoods();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["ReceivedMoneyId"].ToString()!="")
				{
					model.ReceivedMoneyId=int.Parse(ds.Tables[0].Rows[0]["ReceivedMoneyId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreInGoodsStoreInOrderId"].ToString()!="")
				{
					model.StoreInGoodsStoreInOrderId=int.Parse(ds.Tables[0].Rows[0]["StoreInGoodsStoreInOrderId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreInGoodsId"].ToString()!="")
				{
					model.StoreInGoodsId=int.Parse(ds.Tables[0].Rows[0]["StoreInGoodsId"].ToString());
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
			strSql.Append(" FROM ReceivedOfStoreInGoods ");
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
			strSql.Append(" FROM ReceivedOfStoreInGoods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

