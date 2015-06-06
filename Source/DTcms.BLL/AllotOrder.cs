using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using DTcms.Common;
using DTcms.Model;
namespace DTcms.BLL{
	 	//AllotOrder
		public partial class AllotOrder
	{
   		     
		private readonly DTcms.DAL.AllotOrder dal=new DTcms.DAL.AllotOrder();
		public AllotOrder()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id,int PurposeStoreId,int SourceStoreId)
		{
			return dal.Exists(Id,PurposeStoreId,SourceStoreId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(DTcms.Model.AllotOrder model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.AllotOrder model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id,int PurposeStoreId,int SourceStoreId)
		{
			
			return dal.Delete(Id,PurposeStoreId,SourceStoreId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DTcms.Model.AllotOrder GetModel(int Id,int PurposeStoreId,int SourceStoreId)
		{
			
			return dal.GetModel(Id,PurposeStoreId,SourceStoreId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public DTcms.Model.AllotOrder GetModelByCache(int Id,int PurposeStoreId,int SourceStoreId)
        //{
			
        //    string CacheKey = "AllotOrderModel-" + Id+PurposeStoreId+SourceStoreId;
        //    object objModel = DTcms.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(Id,PurposeStoreId,SourceStoreId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = DTcms.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                DTcms.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (DTcms.Model.AllotOrder)objModel;
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
		public List<DTcms.Model.AllotOrder> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DTcms.Model.AllotOrder> DataTableToList(DataTable dt)
		{
			List<DTcms.Model.AllotOrder> modelList = new List<DTcms.Model.AllotOrder>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DTcms.Model.AllotOrder model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DTcms.Model.AllotOrder();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["PurposeStoreId"].ToString()!="")
				{
					model.PurposeStoreId=int.Parse(dt.Rows[n]["PurposeStoreId"].ToString());
				}
																																if(dt.Rows[n]["SourceStoreId"].ToString()!="")
				{
					model.SourceStoreId=int.Parse(dt.Rows[n]["SourceStoreId"].ToString());
				}
																																				model.Remark= dt.Rows[n]["Remark"].ToString();
																												if(dt.Rows[n]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
				}
																																				model.Admin= dt.Rows[n]["Admin"].ToString();
																						
				
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