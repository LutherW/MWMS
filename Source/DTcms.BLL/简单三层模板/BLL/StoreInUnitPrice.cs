using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL .DTcms.BLL{
	 	//StoreInUnitPrice
		public partial class StoreInUnitPrice
	{
   		     
		private readonly Maticsoft.DAL.StoreInUnitPrice dal=new Maticsoft.DAL.StoreInUnitPrice();
		public StoreInUnitPrice()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StoreInOrderId)
		{
			return dal.Exists(StoreInOrderId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(Maticsoft.Model.StoreInUnitPrice model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.StoreInUnitPrice model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StoreInOrderId)
		{
			
			return dal.Delete(StoreInOrderId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.StoreInUnitPrice GetModel(int StoreInOrderId)
		{
			
			return dal.GetModel(StoreInOrderId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.StoreInUnitPrice GetModelByCache(int StoreInOrderId)
		{
			
			string CacheKey = "StoreInUnitPriceModel-" + StoreInOrderId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(StoreInOrderId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.StoreInUnitPrice)objModel;
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
		public List<Maticsoft.Model.StoreInUnitPrice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.StoreInUnitPrice> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.StoreInUnitPrice> modelList = new List<Maticsoft.Model.StoreInUnitPrice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.StoreInUnitPrice model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.StoreInUnitPrice();					
													if(dt.Rows[n]["StoreInOrderId"].ToString()!="")
				{
					model.StoreInOrderId=int.Parse(dt.Rows[n]["StoreInOrderId"].ToString());
				}
																																if(dt.Rows[n]["BeginTime"].ToString()!="")
				{
					model.BeginTime=DateTime.Parse(dt.Rows[n]["BeginTime"].ToString());
				}
																																if(dt.Rows[n]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(dt.Rows[n]["Price"].ToString());
				}
																																if(dt.Rows[n]["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(dt.Rows[n]["EndTime"].ToString());
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