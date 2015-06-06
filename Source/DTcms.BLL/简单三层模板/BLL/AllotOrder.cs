using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL .DTcms.BLL{
	 	//AllotOrder
		public partial class AllotOrder
	{
   		     
		private readonly Maticsoft.DAL.AllotOrder dal=new Maticsoft.DAL.AllotOrder();
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
		public void  Add(Maticsoft.Model.AllotOrder model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.AllotOrder model)
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
		public Maticsoft.Model.AllotOrder GetModel(int Id,int PurposeStoreId,int SourceStoreId)
		{
			
			return dal.GetModel(Id,PurposeStoreId,SourceStoreId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.AllotOrder GetModelByCache(int Id,int PurposeStoreId,int SourceStoreId)
		{
			
			string CacheKey = "AllotOrderModel-" + Id+PurposeStoreId+SourceStoreId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id,PurposeStoreId,SourceStoreId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.AllotOrder)objModel;
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
		public List<Maticsoft.Model.AllotOrder> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.AllotOrder> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.AllotOrder> modelList = new List<Maticsoft.Model.AllotOrder>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.AllotOrder model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.AllotOrder();					
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