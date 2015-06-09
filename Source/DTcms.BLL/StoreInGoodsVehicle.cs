using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using DTcms.Common;
using DTcms.Model;
namespace DTcms.BLL{
	 	//StoreInGoodsVehicle
		public partial class StoreInGoodsVehicle
	{
   		     
		private readonly DTcms.DAL.StoreInGoodsVehicle dal=new DTcms.DAL.StoreInGoodsVehicle();
		public StoreInGoodsVehicle()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StoreWaitingGoodsId,int VehicleId)
		{
			return dal.Exists(StoreWaitingGoodsId,VehicleId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(DTcms.Model.StoreInGoodsVehicle model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.StoreInGoodsVehicle model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StoreWaitingGoodsId,int VehicleId)
		{
			
			return dal.Delete(StoreWaitingGoodsId,VehicleId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DTcms.Model.StoreInGoodsVehicle GetModel(int StoreWaitingGoodsId,int VehicleId)
		{
			
			return dal.GetModel(StoreWaitingGoodsId,VehicleId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public DTcms.Model.StoreInGoodsVehicle GetModelByCache(int StoreWaitingGoodsId,int VehicleId)
        //{
			
        //    string CacheKey = "StoreInGoodsVehicleModel-" + StoreWaitingGoodsId+VehicleId;
        //    object objModel = DTcms.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(StoreWaitingGoodsId,VehicleId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = DTcms.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                DTcms.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (DTcms.Model.StoreInGoodsVehicle)objModel;
        //}

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
		public List<DTcms.Model.StoreInGoodsVehicle> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DTcms.Model.StoreInGoodsVehicle> DataTableToList(DataTable dt)
		{
			List<DTcms.Model.StoreInGoodsVehicle> modelList = new List<DTcms.Model.StoreInGoodsVehicle>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DTcms.Model.StoreInGoodsVehicle model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DTcms.Model.StoreInGoodsVehicle();					
													if(dt.Rows[n]["StoreWaitingGoodsId"].ToString()!="")
				{
					model.StoreWaitingGoodsId=int.Parse(dt.Rows[n]["StoreWaitingGoodsId"].ToString());
				}
																																if(dt.Rows[n]["VehicleId"].ToString()!="")
				{
					model.VehicleId=int.Parse(dt.Rows[n]["VehicleId"].ToString());
				}
																																				model.Remark= dt.Rows[n]["Remark"].ToString();
																												if(dt.Rows[n]["Count"].ToString()!="")
				{
					model.Count=decimal.Parse(dt.Rows[n]["Count"].ToString());
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