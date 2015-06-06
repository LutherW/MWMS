using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL .DTcms.BLL{
	 	//ReceivedUnitPrice
		public partial class ReceivedUnitPrice
	{
   		     
		private readonly Maticsoft.DAL.ReceivedUnitPrice dal=new Maticsoft.DAL.ReceivedUnitPrice();
		public ReceivedUnitPrice()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ReceivedMoneyId)
		{
			return dal.Exists(ReceivedMoneyId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(Maticsoft.Model.ReceivedUnitPrice model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.ReceivedUnitPrice model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ReceivedMoneyId)
		{
			
			return dal.Delete(ReceivedMoneyId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.ReceivedUnitPrice GetModel(int ReceivedMoneyId)
		{
			
			return dal.GetModel(ReceivedMoneyId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.ReceivedUnitPrice GetModelByCache(int ReceivedMoneyId)
		{
			
			string CacheKey = "ReceivedUnitPriceModel-" + ReceivedMoneyId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ReceivedMoneyId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.ReceivedUnitPrice)objModel;
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
		public List<Maticsoft.Model.ReceivedUnitPrice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.ReceivedUnitPrice> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.ReceivedUnitPrice> modelList = new List<Maticsoft.Model.ReceivedUnitPrice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.ReceivedUnitPrice model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.ReceivedUnitPrice();					
													if(dt.Rows[n]["ReceivedMoneyId"].ToString()!="")
				{
					model.ReceivedMoneyId=int.Parse(dt.Rows[n]["ReceivedMoneyId"].ToString());
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