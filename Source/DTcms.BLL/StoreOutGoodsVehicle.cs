using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using DTcms.Common;
using DTcms.Model;
namespace DTcms.BLL{
	 	//StoreOutGoodsVehicle
		public partial class StoreOutGoodsVehicle
	{
   		     
		private readonly DTcms.DAL.StoreOutGoodsVehicle dal=new DTcms.DAL.StoreOutGoodsVehicle();
		public StoreOutGoodsVehicle()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id,int VehicleId)
		{
			return dal.Exists(Id,VehicleId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(DTcms.Model.StoreOutGoodsVehicle model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.StoreOutGoodsVehicle model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id,int VehicleId)
		{
			
			return dal.Delete(Id,VehicleId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DTcms.Model.StoreOutGoodsVehicle GetModel(int Id,int VehicleId)
		{
			
			return dal.GetModel(Id,VehicleId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public DTcms.Model.StoreOutGoodsVehicle GetModelByCache(int Id,int VehicleId)
        //{
			
        //    string CacheKey = "StoreOutGoodsVehicleModel-" + Id+VehicleId;
        //    object objModel = DTcms.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(Id,VehicleId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = DTcms.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                DTcms.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (DTcms.Model.StoreOutGoodsVehicle)objModel;
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
		public List<DTcms.Model.StoreOutGoodsVehicle> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DTcms.Model.StoreOutGoodsVehicle> DataTableToList(DataTable dt)
		{
			List<DTcms.Model.StoreOutGoodsVehicle> modelList = new List<DTcms.Model.StoreOutGoodsVehicle>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DTcms.Model.StoreOutGoodsVehicle model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DTcms.Model.StoreOutGoodsVehicle();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
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