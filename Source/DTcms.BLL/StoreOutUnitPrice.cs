using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using DTcms.Common;
using DTcms.Model;
namespace DTcms.BLL{
	 	//StoreOutUnitPrice
		public partial class StoreOutUnitPrice
	{
   		     
		private readonly DTcms.DAL.StoreOutUnitPrice dal=new DTcms.DAL.StoreOutUnitPrice();
		public StoreOutUnitPrice()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StoreOutOrderId)
		{
			return dal.Exists(StoreOutOrderId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(DTcms.Model.StoreOutUnitPrice model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.StoreOutUnitPrice model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StoreOutOrderId)
		{
			
			return dal.Delete(StoreOutOrderId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DTcms.Model.StoreOutUnitPrice GetModel(int StoreOutOrderId)
		{
			
			return dal.GetModel(StoreOutOrderId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public DTcms.Model.StoreOutUnitPrice GetModelByCache(int StoreOutOrderId)
        //{
			
        //    string CacheKey = "StoreOutUnitPriceModel-" + StoreOutOrderId;
        //    object objModel = DTcms.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(StoreOutOrderId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = DTcms.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                DTcms.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (DTcms.Model.StoreOutUnitPrice)objModel;
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
		public List<DTcms.Model.StoreOutUnitPrice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DTcms.Model.StoreOutUnitPrice> DataTableToList(DataTable dt)
		{
			List<DTcms.Model.StoreOutUnitPrice> modelList = new List<DTcms.Model.StoreOutUnitPrice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DTcms.Model.StoreOutUnitPrice model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DTcms.Model.StoreOutUnitPrice();					
													if(dt.Rows[n]["StoreOutOrderId"].ToString()!="")
				{
					model.StoreOutOrderId=int.Parse(dt.Rows[n]["StoreOutOrderId"].ToString());
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