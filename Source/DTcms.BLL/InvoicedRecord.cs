using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using DTcms.Common;
using DTcms.Model;
namespace DTcms.BLL{
	 	//InvoicedRecord
		public partial class InvoicedRecord
	{
   		     
		private readonly DTcms.DAL.InvoicedRecord dal=new DTcms.DAL.InvoicedRecord();
		public InvoicedRecord()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id,int ReceivedMoneyId,int StoreInOrderId,int CustomerId)
		{
			return dal.Exists(Id,ReceivedMoneyId,StoreInOrderId,CustomerId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(DTcms.Model.InvoicedRecord model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.InvoicedRecord model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id,int ReceivedMoneyId,int StoreInOrderId,int CustomerId)
		{
			
			return dal.Delete(Id,ReceivedMoneyId,StoreInOrderId,CustomerId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DTcms.Model.InvoicedRecord GetModel(int Id,int ReceivedMoneyId,int StoreInOrderId,int CustomerId)
		{
			
			return dal.GetModel(Id,ReceivedMoneyId,StoreInOrderId,CustomerId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public DTcms.Model.InvoicedRecord GetModelByCache(int Id,int ReceivedMoneyId,int StoreInOrderId,int CustomerId)
        //{
			
        //    string CacheKey = "InvoicedRecordModel-" + Id+ReceivedMoneyId+StoreInOrderId+CustomerId;
        //    object objModel = DTcms.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(Id,ReceivedMoneyId,StoreInOrderId,CustomerId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = DTcms.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                DTcms.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (DTcms.Model.InvoicedRecord)objModel;
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
		public List<DTcms.Model.InvoicedRecord> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DTcms.Model.InvoicedRecord> DataTableToList(DataTable dt)
		{
			List<DTcms.Model.InvoicedRecord> modelList = new List<DTcms.Model.InvoicedRecord>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DTcms.Model.InvoicedRecord model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DTcms.Model.InvoicedRecord();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["ReceivedMoneyId"].ToString()!="")
				{
					model.ReceivedMoneyId=int.Parse(dt.Rows[n]["ReceivedMoneyId"].ToString());
				}
																																if(dt.Rows[n]["StoreInOrderId"].ToString()!="")
				{
					model.StoreInOrderId=int.Parse(dt.Rows[n]["StoreInOrderId"].ToString());
				}
																																if(dt.Rows[n]["CustomerId"].ToString()!="")
				{
					model.CustomerId=int.Parse(dt.Rows[n]["CustomerId"].ToString());
				}
																																				model.Remark= dt.Rows[n]["Remark"].ToString();
																												if(dt.Rows[n]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
				}
																																				model.Admin= dt.Rows[n]["Admin"].ToString();
																												if(dt.Rows[n]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(dt.Rows[n]["Price"].ToString());
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