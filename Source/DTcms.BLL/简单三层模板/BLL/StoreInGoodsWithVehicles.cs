using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL .DTcms.BLL{
	 	//StoreInGoodsWithVehicles
		public partial class StoreInGoodsWithVehicles
	{
   		     
		private readonly Maticsoft.DAL.StoreInGoodsWithVehicles dal=new Maticsoft.DAL.StoreInGoodsWithVehicles();
		public StoreInGoodsWithVehicles()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StoreInGoodsStoreInOrderId,int StoreInGoodsId,int StoreInGoodsVehicleId)
		{
			return dal.Exists(StoreInGoodsStoreInOrderId,StoreInGoodsId,StoreInGoodsVehicleId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(Maticsoft.Model.StoreInGoodsWithVehicles model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.StoreInGoodsWithVehicles model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StoreInGoodsStoreInOrderId,int StoreInGoodsId,int StoreInGoodsVehicleId)
		{
			
			return dal.Delete(StoreInGoodsStoreInOrderId,StoreInGoodsId,StoreInGoodsVehicleId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.StoreInGoodsWithVehicles GetModel(int StoreInGoodsStoreInOrderId,int StoreInGoodsId,int StoreInGoodsVehicleId)
		{
			
			return dal.GetModel(StoreInGoodsStoreInOrderId,StoreInGoodsId,StoreInGoodsVehicleId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.StoreInGoodsWithVehicles GetModelByCache(int StoreInGoodsStoreInOrderId,int StoreInGoodsId,int StoreInGoodsVehicleId)
		{
			
			string CacheKey = "StoreInGoodsWithVehiclesModel-" + StoreInGoodsStoreInOrderId+StoreInGoodsId+StoreInGoodsVehicleId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(StoreInGoodsStoreInOrderId,StoreInGoodsId,StoreInGoodsVehicleId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.StoreInGoodsWithVehicles)objModel;
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
		public List<Maticsoft.Model.StoreInGoodsWithVehicles> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.StoreInGoodsWithVehicles> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.StoreInGoodsWithVehicles> modelList = new List<Maticsoft.Model.StoreInGoodsWithVehicles>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.StoreInGoodsWithVehicles model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.StoreInGoodsWithVehicles();					
													if(dt.Rows[n]["StoreInGoodsStoreInOrderId"].ToString()!="")
				{
					model.StoreInGoodsStoreInOrderId=int.Parse(dt.Rows[n]["StoreInGoodsStoreInOrderId"].ToString());
				}
																																if(dt.Rows[n]["StoreInGoodsId"].ToString()!="")
				{
					model.StoreInGoodsId=int.Parse(dt.Rows[n]["StoreInGoodsId"].ToString());
				}
																																if(dt.Rows[n]["StoreInGoodsVehicleId"].ToString()!="")
				{
					model.StoreInGoodsVehicleId=int.Parse(dt.Rows[n]["StoreInGoodsVehicleId"].ToString());
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