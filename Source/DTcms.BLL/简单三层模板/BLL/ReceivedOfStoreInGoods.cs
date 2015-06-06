using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL .DTcms.BLL{
	 	//ReceivedOfStoreInGoods
		public partial class ReceivedOfStoreInGoods
	{
   		     
		private readonly Maticsoft.DAL.ReceivedOfStoreInGoods dal=new Maticsoft.DAL.ReceivedOfStoreInGoods();
		public ReceivedOfStoreInGoods()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ReceivedMoneyId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			return dal.Exists(ReceivedMoneyId,StoreInGoodsStoreInOrderId,StoreInGoodsId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(Maticsoft.Model.ReceivedOfStoreInGoods model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.ReceivedOfStoreInGoods model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ReceivedMoneyId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			return dal.Delete(ReceivedMoneyId,StoreInGoodsStoreInOrderId,StoreInGoodsId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.ReceivedOfStoreInGoods GetModel(int ReceivedMoneyId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			return dal.GetModel(ReceivedMoneyId,StoreInGoodsStoreInOrderId,StoreInGoodsId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.ReceivedOfStoreInGoods GetModelByCache(int ReceivedMoneyId,int StoreInGoodsStoreInOrderId,int StoreInGoodsId)
		{
			
			string CacheKey = "ReceivedOfStoreInGoodsModel-" + ReceivedMoneyId+StoreInGoodsStoreInOrderId+StoreInGoodsId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ReceivedMoneyId,StoreInGoodsStoreInOrderId,StoreInGoodsId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.ReceivedOfStoreInGoods)objModel;
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
		public List<Maticsoft.Model.ReceivedOfStoreInGoods> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.ReceivedOfStoreInGoods> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.ReceivedOfStoreInGoods> modelList = new List<Maticsoft.Model.ReceivedOfStoreInGoods>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.ReceivedOfStoreInGoods model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.ReceivedOfStoreInGoods();					
													if(dt.Rows[n]["ReceivedMoneyId"].ToString()!="")
				{
					model.ReceivedMoneyId=int.Parse(dt.Rows[n]["ReceivedMoneyId"].ToString());
				}
																																if(dt.Rows[n]["StoreInGoodsStoreInOrderId"].ToString()!="")
				{
					model.StoreInGoodsStoreInOrderId=int.Parse(dt.Rows[n]["StoreInGoodsStoreInOrderId"].ToString());
				}
																																if(dt.Rows[n]["StoreInGoodsId"].ToString()!="")
				{
					model.StoreInGoodsId=int.Parse(dt.Rows[n]["StoreInGoodsId"].ToString());
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