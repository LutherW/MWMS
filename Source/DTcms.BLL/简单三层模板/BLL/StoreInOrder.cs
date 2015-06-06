using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL .DTcms.BLL{
	 	//StoreInOrder
		public partial class StoreInOrder
	{
   		     
		private readonly Maticsoft.DAL.StoreInOrder dal=new Maticsoft.DAL.StoreInOrder();
		public StoreInOrder()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id,int CustomerId)
		{
			return dal.Exists(Id,CustomerId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(Maticsoft.Model.StoreInOrder model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.StoreInOrder model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id,int CustomerId)
		{
			
			return dal.Delete(Id,CustomerId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.StoreInOrder GetModel(int Id,int CustomerId)
		{
			
			return dal.GetModel(Id,CustomerId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.StoreInOrder GetModelByCache(int Id,int CustomerId)
		{
			
			string CacheKey = "StoreInOrderModel-" + Id+CustomerId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id,CustomerId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.StoreInOrder)objModel;
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
		public List<Maticsoft.Model.StoreInOrder> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.StoreInOrder> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.StoreInOrder> modelList = new List<Maticsoft.Model.StoreInOrder>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.StoreInOrder model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.StoreInOrder();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["CustomerId"].ToString()!="")
				{
					model.CustomerId=int.Parse(dt.Rows[n]["CustomerId"].ToString());
				}
																																if(dt.Rows[n]["Status"].ToString()!="")
				{
					model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
				}
																																if(dt.Rows[n]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
				}
																																if(dt.Rows[n]["BeginChargingTime"].ToString()!="")
				{
					model.BeginChargingTime=DateTime.Parse(dt.Rows[n]["BeginChargingTime"].ToString());
				}
																																if(dt.Rows[n]["ChargingTime"].ToString()!="")
				{
					model.ChargingTime=DateTime.Parse(dt.Rows[n]["ChargingTime"].ToString());
				}
																																				model.Admin= dt.Rows[n]["Admin"].ToString();
																												if(dt.Rows[n]["ChargingCount"].ToString()!="")
				{
					model.ChargingCount=decimal.Parse(dt.Rows[n]["ChargingCount"].ToString());
				}
																																				model.InspectionNumber= dt.Rows[n]["InspectionNumber"].ToString();
																																model.AccountNumber= dt.Rows[n]["AccountNumber"].ToString();
																												if(dt.Rows[n]["SuttleWeight"].ToString()!="")
				{
					model.SuttleWeight=decimal.Parse(dt.Rows[n]["SuttleWeight"].ToString());
				}
																																if(dt.Rows[n]["FreeDays"].ToString()!="")
				{
					model.FreeDays=int.Parse(dt.Rows[n]["FreeDays"].ToString());
				}
																																				model.Remark= dt.Rows[n]["Remark"].ToString();
																						
				
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