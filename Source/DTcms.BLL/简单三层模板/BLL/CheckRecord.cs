using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL .DTcms.BLL{
	 	//CheckRecord
		public partial class CheckRecord
	{
   		     
		private readonly Maticsoft.DAL.CheckRecord dal=new Maticsoft.DAL.CheckRecord();
		public CheckRecord()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id,int VehicleId,int CustomerId,int HandlingModeId,int GoodsId)
		{
			return dal.Exists(Id,VehicleId,CustomerId,HandlingModeId,GoodsId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(Maticsoft.Model.CheckRecord model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.CheckRecord model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id,int VehicleId,int CustomerId,int HandlingModeId,int GoodsId)
		{
			
			return dal.Delete(Id,VehicleId,CustomerId,HandlingModeId,GoodsId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.CheckRecord GetModel(int Id,int VehicleId,int CustomerId,int HandlingModeId,int GoodsId)
		{
			
			return dal.GetModel(Id,VehicleId,CustomerId,HandlingModeId,GoodsId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.CheckRecord GetModelByCache(int Id,int VehicleId,int CustomerId,int HandlingModeId,int GoodsId)
		{
			
			string CacheKey = "CheckRecordModel-" + Id+VehicleId+CustomerId+HandlingModeId+GoodsId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id,VehicleId,CustomerId,HandlingModeId,GoodsId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.CheckRecord)objModel;
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
		public List<Maticsoft.Model.CheckRecord> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.CheckRecord> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.CheckRecord> modelList = new List<Maticsoft.Model.CheckRecord>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.CheckRecord model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.CheckRecord();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["VehicleId"].ToString()!="")
				{
					model.VehicleId=int.Parse(dt.Rows[n]["VehicleId"].ToString());
				}
																																if(dt.Rows[n]["CustomerId"].ToString()!="")
				{
					model.CustomerId=int.Parse(dt.Rows[n]["CustomerId"].ToString());
				}
																																if(dt.Rows[n]["HandlingModeId"].ToString()!="")
				{
					model.HandlingModeId=int.Parse(dt.Rows[n]["HandlingModeId"].ToString());
				}
																																if(dt.Rows[n]["GoodsId"].ToString()!="")
				{
					model.GoodsId=int.Parse(dt.Rows[n]["GoodsId"].ToString());
				}
																																if(dt.Rows[n]["Status"].ToString()!="")
				{
					model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
				}
																																if(dt.Rows[n]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
				}
																																				model.Admin= dt.Rows[n]["Admin"].ToString();
																																model.InspectionNumber= dt.Rows[n]["InspectionNumber"].ToString();
																																model.CaseNumber= dt.Rows[n]["CaseNumber"].ToString();
																																model.CheckResult= dt.Rows[n]["CheckResult"].ToString();
																																model.RealName= dt.Rows[n]["RealName"].ToString();
																																model.LinkMan= dt.Rows[n]["LinkMan"].ToString();
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