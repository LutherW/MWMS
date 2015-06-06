using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using DTcms.Common;
using DTcms.Model;
namespace DTcms.BLL{
	 	//Attach
		public partial class Attach
	{
   		     
		private readonly DTcms.DAL.Attach dal=new DTcms.DAL.Attach();
		public Attach()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			return dal.Exists(StoreInGoodsStoreInOrderId,StoreInGoodsId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(DTcms.Model.Attach model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.Attach model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			return dal.Delete(StoreInGoodsStoreInOrderId,StoreInGoodsId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DTcms.Model.Attach GetModel(int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			return dal.GetModel(StoreInGoodsStoreInOrderId,StoreInGoodsId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public DTcms.Model.Attach GetModelByCache(int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
        //{
			
        //    string CacheKey = "AttachModel-" + StoreInGoodsStoreInOrderId+StoreInGoodsId;
        //    object objModel = DTcms.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(StoreInGoodsStoreInOrderId,StoreInGoodsId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = DTcms.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                DTcms.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (DTcms.Model.Attach)objModel;
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
		public List<DTcms.Model.Attach> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DTcms.Model.Attach> DataTableToList(DataTable dt)
		{
			List<DTcms.Model.Attach> modelList = new List<DTcms.Model.Attach>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DTcms.Model.Attach model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DTcms.Model.Attach();					
													if(dt.Rows[n]["StoreInGoodsStoreInOrderId"].ToString()!="")
				{
					model.StoreInGoodsStoreInOrderId=int.Parse(dt.Rows[n]["StoreInGoodsStoreInOrderId"].ToString());
				}
																																if(dt.Rows[n]["StoreInGoodsId"].ToString()!="")
				{
					model.StoreInGoodsId=int.Parse(dt.Rows[n]["StoreInGoodsId"].ToString());
				}
																																				model.FilePath= dt.Rows[n]["FilePath"].ToString();
																												if(dt.Rows[n]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
				}
																																				model.Admin= dt.Rows[n]["Admin"].ToString();
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