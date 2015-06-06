using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL .DTcms.BLL{
	 	//AllotGoods
		public partial class AllotGoods
	{
   		     
		private readonly Maticsoft.DAL.AllotGoods dal=new Maticsoft.DAL.AllotGoods();
		public AllotGoods()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AllotOrderId,int Id,int StoreInOrderId,int GoodsId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			return dal.Exists(AllotOrderId,Id,StoreInOrderId,GoodsId,StoreInGoodsStoreInOrderId,StoreInGoodsId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(Maticsoft.Model.AllotGoods model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.AllotGoods model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int AllotOrderId,int Id,int StoreInOrderId,int GoodsId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			return dal.Delete(AllotOrderId,Id,StoreInOrderId,GoodsId,StoreInGoodsStoreInOrderId,StoreInGoodsId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.AllotGoods GetModel(int AllotOrderId,int Id,int StoreInOrderId,int GoodsId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			return dal.GetModel(AllotOrderId,Id,StoreInOrderId,GoodsId,StoreInGoodsStoreInOrderId,StoreInGoodsId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.AllotGoods GetModelByCache(int AllotOrderId,int Id,int StoreInOrderId,int GoodsId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			string CacheKey = "AllotGoodsModel-" + AllotOrderId+Id+StoreInOrderId+GoodsId+StoreInGoodsStoreInOrderId+StoreInGoodsId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(AllotOrderId,Id,StoreInOrderId,GoodsId,StoreInGoodsStoreInOrderId,StoreInGoodsId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.AllotGoods)objModel;
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
		public List<Maticsoft.Model.AllotGoods> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.AllotGoods> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.AllotGoods> modelList = new List<Maticsoft.Model.AllotGoods>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.AllotGoods model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.AllotGoods();					
													if(dt.Rows[n]["AllotOrderId"].ToString()!="")
				{
					model.AllotOrderId=int.Parse(dt.Rows[n]["AllotOrderId"].ToString());
				}
																																if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["StoreInOrderId"].ToString()!="")
				{
					model.StoreInOrderId=int.Parse(dt.Rows[n]["StoreInOrderId"].ToString());
				}
																																if(dt.Rows[n]["GoodsId"].ToString()!="")
				{
					model.GoodsId=int.Parse(dt.Rows[n]["GoodsId"].ToString());
				}
																																if(dt.Rows[n]["StoreInGoodsStoreInOrderId"].ToString()!="")
				{
					model.StoreInGoodsStoreInOrderId=int.Parse(dt.Rows[n]["StoreInGoodsStoreInOrderId"].ToString());
				}
																																if(dt.Rows[n]["StoreInGoodsId"].ToString()!="")
				{
					model.StoreInGoodsId=int.Parse(dt.Rows[n]["StoreInGoodsId"].ToString());
				}
																																				model.Remark= dt.Rows[n]["Remark"].ToString();
																												if(dt.Rows[n]["Count"].ToString()!="")
				{
					model.Count=decimal.Parse(dt.Rows[n]["Count"].ToString());
				}
																																if(dt.Rows[n]["Status"].ToString()!="")
				{
					model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
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