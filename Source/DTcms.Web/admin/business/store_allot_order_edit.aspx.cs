using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using DTcms.Model;
using System.Text;

namespace DTcms.Web.admin.business
{
    public partial class store_allot_order_edit : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        private DataTable storeDT = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.AllotOrder().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("store_allot_order", DTEnums.ActionEnum.View.ToString()); //检查权限
                
                TreeBind(""); //绑定类别
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else if (action == DTEnums.ActionEnum.Add.ToString())
                {
                    Model.manager manager = GetAdminInfo();
                    txtAllotTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtAdmin.Text = manager == null ? "" : manager.user_name;
                }
            }
        }

        #region 绑定类别=================================
        private void TreeBind(string strWhere)
        {
            storeDT = new BLL.Store().GetAllList().Tables[0];
        }

  
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.AllotOrder bll = new BLL.AllotOrder();
            Model.AllotOrder model = bll.GetModel(_id);

            txtAllotTime.Text = model.AllotTime.ToString("yyyy-MM-dd");
            txtAdmin.Text = model.Admin;
            txtRemark.Text = model.Remark;

            BLL.AllotGoods goodsVehicleBLL = new BLL.AllotGoods();
            DataTable goodsVehicleDT = goodsVehicleBLL.GetList(" and A.AllotOrderId = " + _id + "").Tables[0];
            this.rptAllotGoodsList.DataSource = goodsVehicleDT;
            this.rptAllotGoodsList.DataBind();
        }

        protected string GetStoreOptions(string storeId) 
        {
            StringBuilder sb = new StringBuilder();
            if (storeDT != null)
            {
                foreach (DataRow dr in storeDT.Rows)
                {
                    sb.AppendFormat("<option value='{0}'>{1}</option>", dr["Id"], dr["Name"]);
                }
            }

            return sb.ToString();
        }

        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            if (string.IsNullOrWhiteSpace(txtAllotTime.Text))
            {
                JscriptMsg("调拨时间不能为空！", "");
                return false;
            }
            Model.AllotOrder model = new Model.AllotOrder();
            BLL.AllotOrder bll = new BLL.AllotOrder();

            model.AllotTime = DateTime.Parse(txtAllotTime.Text);
            model.Admin = txtAdmin.Text;
            model.Remark = txtRemark.Text;
            model.Status = 0;
            model.CreateTime = DateTime.Now;

            string[] storeInOrderIds = Request.Form.GetValues("StoreInOrderId");
            string[] storeInGoodsIds = Request.Form.GetValues("StoreInGoodsId");
            string[] sourceStoreIds = Request.Form.GetValues("SourceStoreId");
            string[] purposeStoreIds = Request.Form.GetValues("PurposeStoreId");
            string[] allotCounts = Request.Form.GetValues("AllotCount");
            string[] allotRemarks = Request.Form.GetValues("AllotRemark");
            if (storeInOrderIds != null && storeInGoodsIds != null && sourceStoreIds != null
                && purposeStoreIds != null && allotCounts != null && allotRemarks != null
                && storeInOrderIds.Length > 0 && storeInGoodsIds.Length > 0 && sourceStoreIds.Length > 0
                && purposeStoreIds.Length > 0 && allotCounts.Length > 0 && allotRemarks.Length > 0)
            {
                for (int i = 0; i < storeInOrderIds.Length; i++)
                {
                    decimal allotCount;
                    int storeInOrderId, storeInGoodsId, sourceStoreId, purposeStoreId;
                    if (int.TryParse(storeInOrderIds[i], out storeInOrderId)
                        && int.TryParse(storeInGoodsIds[i], out storeInGoodsId)
                        && int.TryParse(sourceStoreIds[i], out sourceStoreId)
                        && int.TryParse(purposeStoreIds[i], out purposeStoreId)
                        && decimal.TryParse(allotCounts[i], out allotCount))
                    {
                        model.AddAllotGoods(new AllotGoods(storeInOrderId, storeInGoodsId, sourceStoreId, purposeStoreId, allotCount, allotRemarks[i]));
                    }
                }
            }

            if (bll.Add(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加调拨货物:" + model.Id); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            if (string.IsNullOrWhiteSpace(txtAllotTime.Text))
            {
                JscriptMsg("调拨时间不能为空！", "");
                return false;
            }
            BLL.AllotOrder bll = new BLL.AllotOrder();
            Model.AllotOrder model = bll.GetModel(_id);

            model.AllotTime = DateTime.Parse(txtAllotTime.Text);
            model.Admin = txtAdmin.Text;
            model.Remark = txtRemark.Text;

            string[] storeInOrderIds = Request.Form.GetValues("StoreInOrderId");
            string[] storeInGoodsIds = Request.Form.GetValues("StoreInGoodsId");
            string[] sourceStoreIds = Request.Form.GetValues("SourceStoreId");
            string[] purposeStoreIds = Request.Form.GetValues("PurposeStoreId");
            string[] allotCounts = Request.Form.GetValues("AllotCount");
            string[] allotRemarks = Request.Form.GetValues("AllotRemark");
            if (storeInOrderIds != null && storeInGoodsIds != null && sourceStoreIds != null
                && purposeStoreIds != null && allotCounts != null && allotRemarks != null
                && storeInOrderIds.Length > 0 && storeInGoodsIds.Length > 0 && sourceStoreIds.Length > 0
                && purposeStoreIds.Length > 0 && allotCounts.Length > 0 && allotRemarks.Length > 0)
            {
                for (int i = 0; i < storeInOrderIds.Length; i++)
                {
                    decimal allotCount;
                    int storeInOrderId, storeInGoodsId, sourceStoreId, purposeStoreId;
                    if (int.TryParse(storeInOrderIds[i], out storeInOrderId)
                        && int.TryParse(storeInGoodsIds[i], out storeInGoodsId)
                        && int.TryParse(sourceStoreIds[i], out sourceStoreId)
                        && int.TryParse(purposeStoreIds[i], out purposeStoreId)
                        && decimal.TryParse(allotCounts[i], out allotCount))
                    {
                        model.AddAllotGoods(new AllotGoods(storeInOrderId, storeInGoodsId, sourceStoreId, purposeStoreId, allotCount, allotRemarks[i]));
                    }
                }
            }

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改调拨货物信息:" + model.Id); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("store_allot_order", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改调拨货物成功！", "store_allot_order.aspx");
            }
            else //添加
            {
                ChkAdminLevel("store_allot_order", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加调拨货物成功！", "store_allot_order.aspx");
            }
        }

    }
}