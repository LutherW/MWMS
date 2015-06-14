using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using DTcms.Model;

namespace DTcms.Web.admin.business
{
    public partial class store_out_order_edit : Web.UI.ManagePage
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
                if (!new BLL.StoreOutOrder().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("store_out_order", DTEnums.ActionEnum.View.ToString()); //检查权限
                
                TreeBind("Status = 2 "); //绑定类别
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else if (action == DTEnums.ActionEnum.Add.ToString())
                {
                    Model.manager manager = GetAdminInfo();
                    txtAdmin.Text = manager == null ? "" : manager.user_name;
                }
            }
        }

        #region 绑定类别=================================
        private void TreeBind(string strWhere)
        {
            BLL.StoreInOrder stroeInOrderBLL = new BLL.StoreInOrder();
            DataTable stroeInOrderDT = stroeInOrderBLL.GetList(0, strWhere, "Id desc").Tables[0];

            this.ddlStoreInOrder.Items.Clear();
            this.ddlStoreInOrder.Items.Add(new ListItem("选择入库单", ""));
            foreach (DataRow dr in stroeInOrderDT.Rows)
            {
                this.ddlStoreInOrder.Items.Add(new ListItem(dr["AccountNumber"].ToString(), dr["Id"].ToString()));
            }

            BLL.Store storeBLL = new BLL.Store();
            storeDT = storeBLL.GetAllList().Tables[0];
        }

        protected void ddlStoreInOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            int StoreOutOrderId;
            if (int.TryParse(ddlStoreInOrder.SelectedValue, out StoreOutOrderId))
            {
                StoreInInfoBind(StoreOutOrderId);
            }
        }

        private void StoreInInfoBind(int StoreInOrderId)
        {
            BLL.StoreInUnitPrice unitPriceBLL = new BLL.StoreInUnitPrice();
            DataTable unitPriceDT = unitPriceBLL.GetList(1, " StoreInOrderId = " + StoreInOrderId + " and BeginTime <= '" + DateTime.Now + "' and EndTime >= '" + DateTime.Now + "'", "BeginTime asc").Tables[0];
            if (unitPriceDT.Rows.Count == 1)
            {
                hidUnitPrice.Value = unitPriceDT.Rows[0]["Price"].ToString();
                labUnitPrice.Text = unitPriceDT.Rows[0]["Price"].ToString();
                txtTotalMoney.Text = string.Format("{0:N2}" ,Convert.ToDecimal(hidUnitPrice.Value) * Convert.ToDecimal(txtChargingCount.Text));
            }

            BLL.Customer customerBLL = new BLL.Customer();
            Customer customer = customerBLL.GetModelByStoreInOrder(StoreInOrderId);
            if (customer != null)
            {
                hidCustomerId.Value = customer.Id.ToString();
                labCustomerName.Text = customer.Name;
            }
        }

        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.StoreOutOrder bll = new BLL.StoreOutOrder();
            Model.StoreOutOrder model = bll.GetModel(_id);

            ddlStoreInOrder.SelectedValue = model.StoreInOrderId.ToString();
            hidUnitPrice.Value = model.UnitPrice.ToString();
            hidCustomerId.Value = model.CustomerId.ToString();
            labCustomerName.Text = GetCustomerName(model.CustomerId);
            txtChargingCount.Text = model.Count.ToString("0.00");
            txtTotalMoney.Text = model.TotalMoney.ToString("0.00");
            txtInvoiceMoney.Text = model.InvoiceMoney.ToString("0.00");
            labUnitPrice.Text = model.UnitPrice.ToString("0.00");
            txtStoredOutTime.Text = model.StoredOutTime.HasValue ? model.StoredOutTime.Value.ToString("yyyy-MM-dd") : "";
            txtAdmin.Text = model.Admin;
            txtRemark.Text = model.Remark;

            BLL.StoreOutCost costBLL = new BLL.StoreOutCost();
            DataTable costDT = costBLL.GetList(" StoreOutOrderId = " + _id + "").Tables[0];
            this.rptCostList.DataSource = costDT;
            this.rptCostList.DataBind();

            BLL.StoreOutGoods goodsBLL = new BLL.StoreOutGoods();
            DataTable goodsDT = goodsBLL.GetList(" and A.StoreOutOrderId = " + _id + " ").Tables[0];
            this.rptGoodsList.DataSource = goodsDT;
            this.rptGoodsList.DataBind();
        }

        private string GetCustomerName(int customerId)
        {
            Model.Customer customer = new BLL.Customer().GetModel(customerId);
            if (customer != null)
	        {
                return customer.Name;
	        }

            return "";
        }

        protected string GetStoreOptions(string storeId) 
        {
            string storeOptions = "";
            storeOptions += "<option value='0'>选择仓库</option>";
            if (storeDT != null)
            {
                foreach (DataRow dr in storeDT.Rows)
                {
                    if (dr["Id"].ToString().Equals(storeId))
                    {
                        storeOptions += "<option value='" + dr["Id"] + "' selected='selected'>" + dr["Name"] + "</option>";
                    }
                    else 
                    {
                        storeOptions += "<option value='" + dr["Id"] + "'>" + dr["Name"] + "</option>";
                    }
                }
            }

            return storeOptions;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.StoreOutOrder model = new Model.StoreOutOrder();
            BLL.StoreOutOrder bll = new BLL.StoreOutOrder();

            model.CustomerId = int.Parse(hidCustomerId.Value);
            model.StoreInOrderId = int.Parse(ddlStoreInOrder.SelectedValue);
            model.StoredOutTime = DateTime.Parse(txtStoredOutTime.Text);
            model.Count = decimal.Parse(txtChargingCount.Text);
            model.TotalMoney = decimal.Parse(txtTotalMoney.Text);
            model.InvoiceMoney = decimal.Parse(txtInvoiceMoney.Text);
            model.UnitPrice = decimal.Parse(hidUnitPrice.Value);
            model.HasBeenInvoiced = false;
            model.Admin = txtAdmin.Text;
            model.Remark = txtRemark.Text;
            model.Status = 0;
            model.CreateTime = DateTime.Now;

            #region 费用
            string[] costName = Request.Form.GetValues("CostName");
            string[] costCount = Request.Form.GetValues("CostCount");
            string[] costType = Request.Form.GetValues("CostType");
            string[] costTotalPrice = Request.Form.GetValues("CostTotalPrice");
            string[] costCustomer = Request.Form.GetValues("CostCustomer");
            if (costName != null && costCount != null && costType != null && costTotalPrice != null && costCustomer != null
                && costName.Length > 0 && costCount.Length > 0 && costType.Length > 0 && costTotalPrice.Length > 0 && costCustomer.Length > 0)
            {
                for (int i = 0; i < costName.Length; i++)
                {
                    decimal count, totalPrice;
                    if (decimal.TryParse(costCount[i], out count) && decimal.TryParse(costTotalPrice[i], out totalPrice))
                    {
                        if (costType[i].ToString().Equals("-"))
                        {
                            totalPrice *= -1;
                        }
                        model.AddStoreInCost(new StoreOutCost(costName[i], count, totalPrice, costCustomer[i], ""));
                    }
                }
            }
            #endregion

            #region 出库货物
            string[] storeOutWaitingGoodsIds = Request.Form.GetValues("StoreOutWaitingGoodsId");
            string[] storeInOrderIds = Request.Form.GetValues("StoreInOrderId");
            string[] storeInGoodsIds = Request.Form.GetValues("StoreInGoodsId");
            string[] storeOutCounts = Request.Form.GetValues("StoreOutCount");
            string[] storeOutGoodsRemark = Request.Form.GetValues("StoreOutGoodsRemark");
            if (storeOutWaitingGoodsIds != null && storeInOrderIds != null && storeOutCounts != null && storeOutGoodsRemark != null
                && storeOutWaitingGoodsIds.Length > 0 && storeInOrderIds.Length > 0 && storeOutCounts.Length > 0 && storeOutGoodsRemark.Length > 0)
            {
                for (int i = 0; i < storeOutWaitingGoodsIds.Length; i++)
                {
                    int storeOutWaitingGoodsId, storeInOrderId, storeInGoodsId;
                    decimal storeOutCount;
                    if (int.TryParse(storeOutWaitingGoodsIds[i], out storeOutWaitingGoodsId)
                        && int.TryParse(storeInOrderIds[i], out storeInOrderId)
                        && int.TryParse(storeInGoodsIds[i], out storeInGoodsId)
                        && decimal.TryParse(storeOutCounts[i], out storeOutCount))
                    {
                        model.AddStoreOutGoods(new StoreOutGoods(storeInOrderId, storeInGoodsId, storeOutWaitingGoodsId, storeOutCount, storeOutGoodsRemark[i]));
                    }
                }
            }
            #endregion

            if (bll.Add(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加出库单:" + model.Id); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.StoreOutOrder bll = new BLL.StoreOutOrder();
            Model.StoreOutOrder model = bll.GetModel(_id);

            model.CustomerId = int.Parse(hidCustomerId.Value);
            model.StoreInOrderId = int.Parse(ddlStoreInOrder.SelectedValue);
            model.StoredOutTime = DateTime.Parse(txtStoredOutTime.Text);
            model.Count = decimal.Parse(txtChargingCount.Text);
            model.TotalMoney = decimal.Parse(txtTotalMoney.Text);
            model.InvoiceMoney = decimal.Parse(txtInvoiceMoney.Text);
            model.UnitPrice = decimal.Parse(hidUnitPrice.Value);
            model.HasBeenInvoiced = false;
            model.Admin = txtAdmin.Text;
            model.Remark = txtRemark.Text;

            #region 费用
            string[] costName = Request.Form.GetValues("CostName");
            string[] costCount = Request.Form.GetValues("CostCount");
            string[] costType = Request.Form.GetValues("CostType");
            string[] costTotalPrice = Request.Form.GetValues("CostTotalPrice");
            string[] costCustomer = Request.Form.GetValues("CostCustomer");
            if (costName != null && costCount != null && costType != null && costTotalPrice != null && costCustomer != null
                && costName.Length > 0 && costCount.Length > 0 && costType.Length > 0 && costTotalPrice.Length > 0 && costCustomer.Length > 0)
            {
                for (int i = 0; i < costName.Length; i++)
                {
                    decimal count, totalPrice;
                    if (decimal.TryParse(costCount[i], out count) && decimal.TryParse(costTotalPrice[i], out totalPrice))
                    {
                        if (costType[i].ToString().Equals("-"))
                        {
                            totalPrice *= -1;
                        }
                        model.AddStoreInCost(new StoreOutCost(costName[i], count, totalPrice, costCustomer[i], ""));
                    }
                }
            }
            #endregion

            #region 出库货物
            string[] storeOutWaitingGoodsIds = Request.Form.GetValues("StoreOutWaitingGoodsId");
            string[] storeInOrderIds = Request.Form.GetValues("StoreInOrderId");
            string[] storeInGoodsIds = Request.Form.GetValues("StoreInGoodsId");
            string[] storeOutCounts = Request.Form.GetValues("StoreOutCount");
            string[] storeOutGoodsRemark = Request.Form.GetValues("StoreOutGoodsRemark");
            if (storeOutWaitingGoodsIds != null && storeInOrderIds != null && storeOutCounts != null && storeOutGoodsRemark != null
                && storeOutWaitingGoodsIds.Length > 0 && storeInOrderIds.Length > 0 && storeOutCounts.Length > 0 && storeOutGoodsRemark.Length > 0)
            {
                for (int i = 0; i < storeOutWaitingGoodsIds.Length; i++)
                {
                    int storeOutWaitingGoodsId, storeInOrderId, storeInGoodsId;
                    decimal storeOutCount;
                    if (int.TryParse(storeOutWaitingGoodsIds[i], out storeOutWaitingGoodsId)
                        && int.TryParse(storeInOrderIds[i], out storeInOrderId)
                        && int.TryParse(storeInGoodsIds[i], out storeInGoodsId)
                        && decimal.TryParse(storeOutCounts[i], out storeOutCount))
                    {
                        model.AddStoreOutGoods(new StoreOutGoods(storeInOrderId, storeInGoodsId, storeOutWaitingGoodsId, storeOutCount, storeOutGoodsRemark[i]));
                    }
                }
            }
            #endregion

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改出库单信息:" + model.Id); //记录日志
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
                ChkAdminLevel("store_out_order", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改出库单成功！", "store_out_order.aspx");
            }
            else //添加
            {
                ChkAdminLevel("store_out_order", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加出库单成功！", "store_out_order.aspx");
            }
        }

    }
}