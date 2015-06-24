using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DTcms.Common;
using DTcms.Model;
namespace DTcms.BLL
{
    //CheckCost
    public partial class CheckCost
    {

        private readonly DTcms.DAL.CheckCost dal = new DTcms.DAL.CheckCost();
        public CheckCost()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CheckRecordId)
        {
            return dal.Exists(CheckRecordId);
        }

        public bool ExistsById(int id)
        {
            return dal.ExistsById(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(DTcms.Model.CheckCost model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.CheckCost model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int CheckRecordId)
        {

            return dal.Delete(CheckRecordId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.CheckCost GetModel(int CheckRecordId)
        {

            return dal.GetModel(CheckRecordId);
        }

        public DTcms.Model.CheckCost GetModelById(int id)
        {
            return dal.GetModelById(id);
        }

        public bool Update(DTcms.Model.CheckCost model, int id)
        {
            return dal.Update(model, id);
        }


        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public DTcms.Model.CheckCost GetModelByCache(int CheckRecordId)
        //{

        //    string CacheKey = "CheckCostModel-" + CheckRecordId;
        //    object objModel = DTcms.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(CheckRecordId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = DTcms.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                DTcms.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (DTcms.Model.CheckCost)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetSearchList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetSearchList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DTcms.Model.CheckCost> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DTcms.Model.CheckCost> DataTableToList(DataTable dt)
        {
            List<DTcms.Model.CheckCost> modelList = new List<DTcms.Model.CheckCost>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DTcms.Model.CheckCost model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DTcms.Model.CheckCost();
                    if (dt.Rows[n]["CheckRecordId"].ToString() != "")
                    {
                        model.CheckRecordId = int.Parse(dt.Rows[n]["CheckRecordId"].ToString());
                    }
                    model.Name = dt.Rows[n]["Name"].ToString();
                    if (dt.Rows[n]["Count"].ToString() != "")
                    {
                        model.Count = decimal.Parse(dt.Rows[n]["Count"].ToString());
                    }
                    if (dt.Rows[n]["UnitPrice"].ToString() != "")
                    {
                        model.UnitPrice = decimal.Parse(dt.Rows[n]["UnitPrice"].ToString());
                    }
                    if (dt.Rows[n]["TotalPrice"].ToString() != "")
                    {
                        model.TotalPrice = decimal.Parse(dt.Rows[n]["TotalPrice"].ToString());
                    }
                    if (dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["PaidTime"].ToString() != "")
                    {
                        model.PaidTime = DateTime.Parse(dt.Rows[n]["PaidTime"].ToString());
                    }
                    model.Admin = dt.Rows[n]["Admin"].ToString();
                    model.Customer = dt.Rows[n]["Customer"].ToString();
                    if (dt.Rows[n]["HasBeenInvoiced"].ToString() != "")
                    {
                        if ((dt.Rows[n]["HasBeenInvoiced"].ToString() == "1") || (dt.Rows[n]["HasBeenInvoiced"].ToString().ToLower() == "true"))
                        {
                            model.HasBeenInvoiced = true;
                        }
                        else
                        {
                            model.HasBeenInvoiced = false;
                        }
                    }
                    if (dt.Rows[n]["InvoicedTime"].ToString() != "")
                    {
                        model.InvoicedTime = DateTime.Parse(dt.Rows[n]["InvoicedTime"].ToString());
                    }
                    model.InvoicedOperator = dt.Rows[n]["InvoicedOperator"].ToString();
                    model.Remark = dt.Rows[n]["Remark"].ToString();


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