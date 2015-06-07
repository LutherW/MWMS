using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DTcms.Common;
using DTcms.Model;
namespace DTcms.BLL
{
    //Customer
    public partial class Customer
    {

        private readonly DTcms.DAL.Customer dal = new DTcms.DAL.Customer();
        public Customer()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.Customer model)
        {
           return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.Customer model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.Customer GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public DTcms.Model.Customer GetModelByCache(int Id)
        //{

        //    string CacheKey = "CustomerModel-" + Id;
        //    object objModel = DTcms.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(Id);
        //            if (objModel != null)
        //            {
        //                int ModelCache = DTcms.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                DTcms.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (DTcms.Model.Customer)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DTcms.Model.Customer> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DTcms.Model.Customer> DataTableToList(DataTable dt)
        {
            List<DTcms.Model.Customer> modelList = new List<DTcms.Model.Customer>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DTcms.Model.Customer model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DTcms.Model.Customer();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.Code = dt.Rows[n]["Code"].ToString();
                    model.Name = dt.Rows[n]["Name"].ToString();
                    model.LinkMan = dt.Rows[n]["LinkMan"].ToString();
                    model.LinkTel = dt.Rows[n]["LinkTel"].ToString();
                    model.LinkAddress = dt.Rows[n]["LinkAddress"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    model.Fax = dt.Rows[n]["Fax"].ToString();
                    if (dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
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

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion

    }
}