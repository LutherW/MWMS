using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL .DTcms.BLL{
	 	//Goods
		public partial class Goods
	{
   		     
		private readonly Maticsoft.DAL.Goods dal=new Maticsoft.DAL.Goods();
		public Goods()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id,int UnitId,int CustomerId,int StoreModeId,int HandlingModeId)
		{
			return dal.Exists(Id,UnitId,CustomerId,StoreModeId,HandlingModeId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(Maticsoft.Model.Goods model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Goods model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id,int UnitId,int CustomerId,int StoreModeId,int HandlingModeId)
		{
			
			return dal.Delete(Id,UnitId,CustomerId,StoreModeId,HandlingModeId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Goods GetModel(int Id,int UnitId,int CustomerId,int StoreModeId,int HandlingModeId)
		{
			
			return dal.GetModel(Id,UnitId,CustomerId,StoreModeId,HandlingModeId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.Goods GetModelByCache(int Id,int UnitId,int CustomerId,int StoreModeId,int HandlingModeId)
		{
			
			string CacheKey = "GoodsModel-" + Id+UnitId+CustomerId+StoreModeId+HandlingModeId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id,UnitId,CustomerId,StoreModeId,HandlingModeId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.Goods)objModel;
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
		public List<Maticsoft.Model.Goods> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.Goods> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.Goods> modelList = new List<Maticsoft.Model.Goods>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.Goods model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.Goods();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["UnitId"].ToString()!="")
				{
					model.UnitId=int.Parse(dt.Rows[n]["UnitId"].ToString());
				}
																																if(dt.Rows[n]["CustomerId"].ToString()!="")
				{
					model.CustomerId=int.Parse(dt.Rows[n]["CustomerId"].ToString());
				}
																																if(dt.Rows[n]["StoreModeId"].ToString()!="")
				{
					model.StoreModeId=int.Parse(dt.Rows[n]["StoreModeId"].ToString());
				}
																																if(dt.Rows[n]["HandlingModeId"].ToString()!="")
				{
					model.HandlingModeId=int.Parse(dt.Rows[n]["HandlingModeId"].ToString());
				}
																																				model.Name= dt.Rows[n]["Name"].ToString();
																						
				
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