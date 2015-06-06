using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL .DTcms.BLL{
	 	//StoreOutCost
		public partial class StoreOutCost
	{
   		     
		private readonly Maticsoft.DAL.StoreOutCost dal=new Maticsoft.DAL.StoreOutCost();
		public StoreOutCost()
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
		public void  Add(Maticsoft.Model.StoreOutCost model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.StoreOutCost model)
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
		public Maticsoft.Model.StoreOutCost GetModel(int StoreOutOrderId)
		{
			
			return dal.GetModel(StoreOutOrderId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.StoreOutCost GetModelByCache(int StoreOutOrderId)
		{
			
			string CacheKey = "StoreOutCostModel-" + StoreOutOrderId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(StoreOutOrderId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.StoreOutCost)objModel;
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
		public List<Maticsoft.Model.StoreOutCost> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.StoreOutCost> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.StoreOutCost> modelList = new List<Maticsoft.Model.StoreOutCost>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.StoreOutCost model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.StoreOutCost();					
													if(dt.Rows[n]["StoreOutOrderId"].ToString()!="")
				{
					model.StoreOutOrderId=int.Parse(dt.Rows[n]["StoreOutOrderId"].ToString());
				}
																																				model.Name= dt.Rows[n]["Name"].ToString();
																												if(dt.Rows[n]["Count"].ToString()!="")
				{
					model.Count=decimal.Parse(dt.Rows[n]["Count"].ToString());
				}
																																if(dt.Rows[n]["UnitPrice"].ToString()!="")
				{
					model.UnitPrice=decimal.Parse(dt.Rows[n]["UnitPrice"].ToString());
				}
																																if(dt.Rows[n]["TotalPrice"].ToString()!="")
				{
					model.TotalPrice=decimal.Parse(dt.Rows[n]["TotalPrice"].ToString());
				}
																																if(dt.Rows[n]["Status"].ToString()!="")
				{
					model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
				}
																																if(dt.Rows[n]["PaidTime"].ToString()!="")
				{
					model.PaidTime=DateTime.Parse(dt.Rows[n]["PaidTime"].ToString());
				}
																																				model.Admin= dt.Rows[n]["Admin"].ToString();
																																model.Customer= dt.Rows[n]["Customer"].ToString();
																																												if(dt.Rows[n]["HasBeenInvoiced"].ToString()!="")
				{
					if((dt.Rows[n]["HasBeenInvoiced"].ToString()=="1")||(dt.Rows[n]["HasBeenInvoiced"].ToString().ToLower()=="true"))
					{
					model.HasBeenInvoiced= true;
					}
					else
					{
					model.HasBeenInvoiced= false;
					}
				}
																if(dt.Rows[n]["InvoicedTime"].ToString()!="")
				{
					model.InvoicedTime=DateTime.Parse(dt.Rows[n]["InvoicedTime"].ToString());
				}
																																				model.InvoicedOperator= dt.Rows[n]["InvoicedOperator"].ToString();
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