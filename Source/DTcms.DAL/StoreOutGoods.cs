using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
namespace DTcms.DAL
{
	 	//StoreOutGoods
		public partial class StoreOutGoods
	{
   		     
		public bool Exists(int Id,int StoreOutOrderId,int StoreInOrderId,int StoreInGoodsId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreOutGoods");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = @Id and  ");
                                                                   strSql.Append(" StoreOutOrderId = @StoreOutOrderId and  ");
                                                                   strSql.Append(" StoreInOrderId = @StoreInOrderId and  ");
                                                                   strSql.Append(" StoreInGoodsId = @StoreInGoodsId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@StoreOutOrderId", SqlDbType.Int,4),
					new SqlParameter("@StoreInOrderId", SqlDbType.Int,4),
					new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = StoreOutOrderId;
			parameters[2].Value = StoreInOrderId;
			parameters[3].Value = StoreInGoodsId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DTcms.Model.StoreOutGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreOutGoods(");			
            strSql.Append("StoreOutOrderId,StoreInOrderId,StoreInGoodsStoreInOrderId,StoreInGoodsId,Remark,StoringOutTime,FactStoringOutTime,Status,Count");
			strSql.Append(") values (");
            strSql.Append("@StoreOutOrderId,@StoreInOrderId,@StoreInGoodsStoreInOrderId,@StoreInGoodsId,@Remark,@StoringOutTime,@FactStoringOutTime,@Status,@Count");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@StoreOutOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@StoringOutTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@FactStoringOutTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9)             
              
            };
			            
            parameters[0].Value = model.StoreOutOrderId;                        
            parameters[1].Value = model.StoreInOrderId;                        
            parameters[2].Value = model.StoreInGoodsStoreInOrderId;                        
            parameters[3].Value = model.StoreInGoodsId;                        
            parameters[4].Value = model.Remark;                        
            parameters[5].Value = model.StoringOutTime;                        
            parameters[6].Value = model.FactStoringOutTime;                        
            parameters[7].Value = model.Status;                        
            parameters[8].Value = model.Count;                        
			   
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);			
			if (obj == null)
			{
				return 0;
			}
			else
			{
				                    
            	return Convert.ToInt32(obj);
                                                                  
			}			   
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.StoreOutGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreOutGoods set ");
			                                                
            strSql.Append(" StoreOutOrderId = @StoreOutOrderId , ");                                    
            strSql.Append(" StoreInOrderId = @StoreInOrderId , ");                                    
            strSql.Append(" StoreInGoodsStoreInOrderId = @StoreInGoodsStoreInOrderId , ");                                    
            strSql.Append(" StoreInGoodsId = @StoreInGoodsId , ");                                    
            strSql.Append(" Remark = @Remark , ");                                    
            strSql.Append(" StoringOutTime = @StoringOutTime , ");                                    
            strSql.Append(" FactStoringOutTime = @FactStoringOutTime , ");                                    
            strSql.Append(" Status = @Status , ");                                    
            strSql.Append(" Count = @Count  ");            			
			strSql.Append(" where Id=@Id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreOutOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsStoreInOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreInGoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@StoringOutTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@FactStoringOutTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.StoreOutOrderId;                        
            parameters[2].Value = model.StoreInOrderId;                        
            parameters[3].Value = model.StoreInGoodsStoreInOrderId;                        
            parameters[4].Value = model.StoreInGoodsId;                        
            parameters[5].Value = model.Remark;                        
            parameters[6].Value = model.StoringOutTime;                        
            parameters[7].Value = model.FactStoringOutTime;                        
            parameters[8].Value = model.Status;                        
            parameters[9].Value = model.Count;                        
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
			strSql.Append("delete from StoreOutGoods ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
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

        public bool Delete(SqlConnection conn, SqlTransaction trans, int storeOutOrderId)
        {
            DataSet storeOutGoodsDS = GetList("StoreOutOderId = " + storeOutOrderId + "");
            if (storeOutGoodsDS != null)
            {
                StoreInGoods storeInGoodsDAL = new StoreInGoods();
                foreach (DataRow dr in storeOutGoodsDS.Tables[0].Rows)
                {
                    storeInGoodsDAL.UpdateField(conn, trans, Convert.ToInt32(dr["StoreInGoodsId"]), "Count = Count + " + Convert.ToDecimal(dr["Count"]) + "");
                }
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from StoreOutGoods ");
                strSql.Append(" where StoreOutOrderId=@StoreOutOrderId");
                SqlParameter[] parameters = {
					    new SqlParameter("@StoreOutOrderId", SqlDbType.Int,4)
			    };
                parameters[0].Value = storeOutOrderId;


                int rows = DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

		
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreOutGoods ");
			strSql.Append(" where ID in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public DTcms.Model.StoreOutGoods GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, StoreOutOrderId, StoreInOrderId, StoreInGoodsStoreInOrderId, StoreInGoodsId, Remark, StoringOutTime, FactStoringOutTime, Status, Count  ");			
			strSql.Append("  from StoreOutGoods ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			
			DTcms.Model.StoreOutGoods model=new DTcms.Model.StoreOutGoods();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StoreOutOrderId"].ToString()!="")
				{
					model.StoreOutOrderId=int.Parse(ds.Tables[0].Rows[0]["StoreOutOrderId"].ToString());
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

