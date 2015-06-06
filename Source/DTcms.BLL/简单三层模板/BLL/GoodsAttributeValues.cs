using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL .DTcms.BLL{
	 	//GoodsAttributeValues
		public partial class GoodsAttributeValues
	{
   		     
		private readonly Maticsoft.DAL.GoodsAttributeValues dal=new Maticsoft.DAL.GoodsAttributeValues();
		public GoodsAttributeValues()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int GoodsId)
		{
			return dal.Exists(GoodsId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(Maticsoft.Model.GoodsAttributeValues model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.GoodsAttributeValues model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int GoodsId)
		{
			
			return dal.Delete(GoodsId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.GoodsAttributeValues GetModel(int GoodsId)
		{
			
			return dal.GetModel(GoodsId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.GoodsAttributeValues GetModelByCache(int GoodsId)
		{
			
			string CacheKey = "GoodsAttributeValuesModel-" + GoodsId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(GoodsId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.GoodsAttributeValues)objModel;
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
		public List<Maticsoft.Model.GoodsAttributeValues> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.GoodsAttributeValues> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.GoodsAttributeValues> modelList = new List<Maticsoft.Model.GoodsAttributeValues>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.GoodsAttributeValues model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.GoodsAttributeValues();					
													if(dt.Rows[n]["GoodsId"].ToString()!="")
				{
					model.GoodsId=int.Parse(dt.Rows[n]["GoodsId"].ToString());
				}
																																				model.AttributeName= dt.Rows[n]["AttributeName"].ToString();
																																model.AttributeValue= dt.Rows[n]["AttributeValue"].ToString();
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