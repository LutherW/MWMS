using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using DTcms.Common;
using DTcms.Model;
namespace DTcms.BLL{
	 	//StoreInGoods
		public partial class StoreInGoods
	{
   		     
		private readonly DTcms.DAL.StoreInGoods dal=new DTcms.DAL.StoreInGoods();
		public StoreInGoods()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StoreInOrderId,int Id,int StoreId,int StoreModeId,int CustomerId,int GoodsId)
		{
			return dal.Exists(StoreInOrderId,Id,StoreId,StoreModeId,CustomerId,GoodsId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(DTcms.Model.StoreInGoods model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.StoreInGoods model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StoreInOrderId,int Id,int StoreId,int StoreModeId,int CustomerId,int GoodsId)
		{
			
			return dal.Delete(StoreInOrderId,Id,StoreId,StoreModeId,CustomerId,GoodsId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DTcms.Model.StoreInGoods GetModel(int StoreInOrderId,int Id,int StoreId,int StoreModeId,int CustomerId,int GoodsId)
		{
			
			return dal.GetModel(StoreInOrderId,Id,StoreId,StoreModeId,CustomerId,GoodsId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public DTcms.Model.StoreInGoods GetModelByCache(int StoreInOrderId,int Id,int StoreId,int StoreModeId,int CustomerId,int GoodsId)
        //{
			
        //    string CacheKey = "StoreInGoodsModel-" + StoreInOrderId+Id+StoreId+StoreModeId+CustomerId+GoodsId;
        //    object objModel = DTcms.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(StoreInOrderId,Id,StoreId,StoreModeId,CustomerId,GoodsId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = DTcms.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                DTcms.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (DTcms.Model.StoreInGoods)objModel;
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
		public List<DTcms.Model.StoreInGoods> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DTcms.Model.StoreInGoods> DataTableToList(DataTable dt)
		{
			List<DTcms.Model.StoreInGoods> modelList = new List<DTcms.Model.StoreInGoods>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DTcms.Model.StoreInGoods model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DTcms.Model.StoreInGoods();					
													if(dt.Rows[n]["StoreInOrderId"].ToString()!="")
				{
					model.StoreInOrderId=int.Parse(dt.Rows[n]["StoreInOrderId"].ToString());
				}
																																if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["StoreId"].ToString()!="")
				{
					model.StoreId=int.Parse(dt.Rows[n]["StoreId"].ToString());
				}
																																if(dt.Rows[n]["StoreModeId"].ToString()!="")
				{
					model.StoreModeId=int.Parse(dt.Rows[n]["StoreModeId"].ToString());
				}
																																if(dt.Rows[n]["CustomerId"].ToString()!="")
				{
					model.CustomerId=int.Parse(dt.Rows[n]["CustomerId"].ToString());
				}
																																if(dt.Rows[n]["GoodsId"].ToString()!="")
				{
					model.GoodsId=int.Parse(dt.Rows[n]["GoodsId"].ToString());
				}
																																if(dt.Rows[n]["Status"].ToString()!="")
				{
					model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
				}
																																if(dt.Rows[n]["Count"].ToString()!="")
				{
					model.Count=decimal.Parse(dt.Rows[n]["Count"].ToString());
				}
																																if(dt.Rows[n]["StoredInTime"].ToString()!="")
				{
					model.StoredInTime=DateTime.Parse(dt.Rows[n]["StoredInTime"].ToString());
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