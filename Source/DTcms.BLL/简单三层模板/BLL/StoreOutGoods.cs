using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL .DTcms.BLL{
	 	//StoreOutGoods
		public partial class StoreOutGoods
	{
   		     
		private readonly Maticsoft.DAL.StoreOutGoods dal=new Maticsoft.DAL.StoreOutGoods();
		public StoreOutGoods()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StoreOutOrderId,int Id,int GoodsId,int StoreInOrderId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			return dal.Exists(StoreOutOrderId,Id,GoodsId,StoreInOrderId,StoreInGoodsStoreInOrderId,StoreInGoodsId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(Maticsoft.Model.StoreOutGoods model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.StoreOutGoods model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StoreOutOrderId,int Id,int GoodsId,int StoreInOrderId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			return dal.Delete(StoreOutOrderId,Id,GoodsId,StoreInOrderId,StoreInGoodsStoreInOrderId,StoreInGoodsId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.StoreOutGoods GetModel(int StoreOutOrderId,int Id,int GoodsId,int StoreInOrderId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			return dal.GetModel(StoreOutOrderId,Id,GoodsId,StoreInOrderId,StoreInGoodsStoreInOrderId,StoreInGoodsId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.StoreOutGoods GetModelByCache(int StoreOutOrderId,int Id,int GoodsId,int StoreInOrderId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			string CacheKey = "StoreOutGoodsModel-" + StoreOutOrderId+Id+GoodsId+StoreInOrderId+StoreInGoodsStoreInOrderId+StoreInGoodsId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(StoreOutOrderId,Id,GoodsId,StoreInOrderId,StoreInGoodsStoreInOrderId,StoreInGoodsId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.StoreOutGoods)objModel;
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
		public List<Maticsoft.Model.StoreOutGoods> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.StoreOutGoods> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.StoreOutGoods> modelList = new List<Maticsoft.Model.StoreOutGoods>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.StoreOutGoods model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.StoreOutGoods();					
													if(dt.Rows[n]["StoreOutOrderId"].ToString()!="")
				{
					model.StoreOutOrderId=int.Parse(dt.Rows[n]["StoreOutOrderId"].ToString());
				}
																																if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["GoodsId"].ToString()!="")
				{
					model.GoodsId=int.Parse(dt.Rows[n]["GoodsId"].ToString());
				}
																																if(dt.Rows[n]["StoreInOrderId"].ToString()!="")
				{
					model.StoreInOrderId=int.Parse(dt.Rows[n]["StoreInOrderId"].ToString());
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
																												if(dt.Rows[n]["StoringOutTime"].ToString()!="")
				{
					model.StoringOutTime=DateTime.Parse(dt.Rows[n]["StoringOutTime"].ToString());
				}
																																if(dt.Rows[n]["FactStoringOutTime"].ToString()!="")
				{
					model.FactStoringOutTime=DateTime.Parse(dt.Rows[n]["FactStoringOutTime"].ToString());
				}
																																if(dt.Rows[n]["Status"].ToString()!="")
				{
					model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
				}
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