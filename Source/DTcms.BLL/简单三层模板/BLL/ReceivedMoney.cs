using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL .DTcms.BLL{
	 	//ReceivedMoney
		public partial class ReceivedMoney
	{
   		     
		private readonly Maticsoft.DAL.ReceivedMoney dal=new Maticsoft.DAL.ReceivedMoney();
		public ReceivedMoney()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id,int StoreInOrderId,int CustomerId)
		{
			return dal.Exists(Id,StoreInOrderId,CustomerId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(Maticsoft.Model.ReceivedMoney model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.ReceivedMoney model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id,int StoreInOrderId,int CustomerId)
		{
			
			return dal.Delete(Id,StoreInOrderId,CustomerId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.ReceivedMoney GetModel(int Id,int StoreInOrderId,int CustomerId)
		{
			
			return dal.GetModel(Id,StoreInOrderId,CustomerId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.ReceivedMoney GetModelByCache(int Id,int StoreInOrderId,int CustomerId)
		{
			
			string CacheKey = "ReceivedMoneyModel-" + Id+StoreInOrderId+CustomerId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id,StoreInOrderId,CustomerId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.ReceivedMoney)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.ReceivedMoney> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.ReceivedMoney> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.ReceivedMoney> modelList = new List<Maticsoft.Model.ReceivedMoney>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.ReceivedMoney model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.ReceivedMoney();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["StoreInOrderId"].ToString()!="")
				{
					model.StoreInOrderId=int.Parse(dt.Rows[n]["StoreInOrderId"].ToString());
				}
																																if(dt.Rows[n]["CustomerId"].ToString()!="")
				{
					model.CustomerId=int.Parse(dt.Rows[n]["CustomerId"].ToString());
				}
																																				model.Name= dt.Rows[n]["Name"].ToString();
																												if(dt.Rows[n]["BeginChargingTime"].ToString()!="")
				{
					model.BeginChargingTime=DateTime.Parse(dt.Rows[n]["BeginChargingTime"].ToString());
				}
																																if(dt.Rows[n]["EndChargingTime2"].ToString()!="")
				{
					model.EndChargingTime2=DateTime.Parse(dt.Rows[n]["EndChargingTime2"].ToString());
				}
																																if(dt.Rows[n]["ChargingCount"].ToString()!="")
				{
					model.ChargingCount=decimal.Parse(dt.Rows[n]["ChargingCount"].ToString());
				}
																																if(dt.Rows[n]["TotalPrice"].ToString()!="")
				{
					model.TotalPrice=decimal.Parse(dt.Rows[n]["TotalPrice"].ToString());
				}
																																if(dt.Rows[n]["FactTotalPrice"].ToString()!="")
				{
					model.FactTotalPrice=decimal.Parse(dt.Rows[n]["FactTotalPrice"].ToString());
				}
																																if(dt.Rows[n]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
				}
																																				model.Admin= dt.Rows[n]["Admin"].ToString();
																																model.Remark= dt.Rows[n]["Remark"].ToString();
																												if(dt.Rows[n]["Status"].ToString()!="")
				{
					model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
				}
																										
				
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
#endregion
   
	}
}