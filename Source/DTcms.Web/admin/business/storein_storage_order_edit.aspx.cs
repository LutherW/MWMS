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
    public partial class storein_storage_order_edit : Web.UI.ManagePage
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
                if (!new BLL.StoreInOrder().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("storein_storage_order", DTEnums.ActionEnum.View.ToString()); //检查权限
                
                TreeBind("Status = 0 "); //绑定类别
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
            BLL.Customer customerBLL = new BLL.Customer();
            DataTable customerDT = customerBLL.GetList(0, strWhere, "Id desc").Tables[0];

            this.ddlCustomer.Items.Clear();
            this.ddlCustomer.Items.Add(new ListItem("客户", ""));
            foreach (DataRow dr in customerDT.Rows)
            {
                this.ddlCustomer.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }

            BLL.Store storeBLL = new BLL.Store();
            storeDT = storeBLL.GetAllList().Tables[0];

        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.StoreInOrder bll = new BLL.StoreInOrder();
            Model.StoreInOrder model = bll.GetModel(_id);

            ddlCustomer.SelectedValue = model.CustomerId.ToString();
            txtAccountNumber.Text = model.AccountNumber;
            txtInspectionNumber.Text = model.InspectionNumber;
            txtBeginChargingTime.Text = model.BeginChargingTime.ToString("yyyy-MM-dd");
            txtChargingCount.Text = model.ChargingCount.ToString();
            txtSuttleWeight.Text = model.SuttleWeight.ToString("0.00");
            txtAdmin.Text = model.Admin;
            txtRemark.Text = model.Remark;

            BLL.StoreInUnitPrice unitpriceBLL = new BLL.StoreInUnitPrice();
            DataTable unitpriceDT = unitpriceBLL.GetList(" StoreInOrderId = " + _id + "").Tables[0];
            this.rptUnitPriceList.DataSource = unitpriceDT;
            this.rptUnitPriceList.DataBind();

            BLL.StoreInCost costBLL = new BLL.StoreInCost();
            DataTable costDT = costBLL.GetList(" StoreInOrderId = " + _id + "").Tables[0];
            this.rptCostList.DataSource = costDT;
            this.rptCostList.DataBind();

            BLL.StoreInGoods goodsBLL = new BLL.StoreInGoods();
            DataTable goodsDT = goodsBLL.GetList(" and A.StoreInOrderId = " + _id + " ").Tables[0];
            this.rptGoodsList.DataSource = goodsDT;
            this.rptGoodsList.DataBind();
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
            Model.StoreInOrder model = new Model.StoreInOrder();
            BLL.StoreInOrder bll = new BLL.StoreInOrder();

            model.CustomerId = int.Parse(ddlCustomer.SelectedValue);
            model.BeginChargingTime = DateTime.Parse(txtBeginChargingTime.Text);
            model.ChargingTime = new DateTime(model.BeginChargingTime.Year, model.BeginChargingTime.Month, model.BeginChargingTime.Day + 1);
            model.AccountNumber = txtAccountNumber.Text;
            model.InspectionNumber = txtInspectionNumber.Text;
            model.ChargingCount = decimal.Parse(txtChargingCount.Text);
            model.SuttleWeight = decimal.Parse(txtSuttleWeight.Text);
            model.Admin = txtAdmin.Text;
            model.Remark = txtRemark.Text;
            model.Status = 1;
            model.CreateTime = DateTime.Now;

            #region 单价
            string[] unitpriceBeginTime = Request.Form.GetValues("UnitpriceBeginTime");
            string[] unitpriceEndTime = Request.Form.GetValues("UnitpriceEndTime");
            string[] unitprice = Request.Form.GetValues("Unitprice");
            string[] unitpriceRemark = Request.Form.GetValues("UnitpriceRemark");
            if (unitpriceBeginTime != null && unitpriceEndTime != null && unitprice != null && unitpriceRemark != null
                && unitpriceBeginTime.Length > 0 && unitpriceEndTime.Length > 0 && unitprice.Length > 0 && unitpriceRemark.Length > 0)
            {
                for (int i = 0; i < unitpriceBeginTime.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(unitpriceBeginTime[i]))
                    {
                        unitpriceBeginTime[i] = DTDateTime.MinDateTime.ToString();
                    }
                    if (string.IsNullOrWhiteSpace(unitpriceEndTime[i]))
                    {
                        unitpriceEndTime[i] = DTDateTime.MaxDateTime.ToString();
                    }
                    decimal price;
                    DateTime begintime, endtime;
                    if (DateTime.TryParse(unitpriceBeginTime[i], out begintime) && DateTime.TryParse(unitpriceEndTime[i], out endtime)
                        && decimal.TryParse(unitprice[i], out price))
                    {
                        model.AddUnitPrice(new StoreInUnitPrice(begintime, endtime, price, unitpriceRemark[i]));
                    }
                }
            }
            #endregion

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
                        model.AddStoreInCost(new StoreInCost(costName[i], count, totalPrice, costCustomer[i], ""));
                    }
                }
            }
            #endregion

            #region 入库货物
            string[] storeWaitingGoodsIds = Request.Form.GetValues("StoreWaitingGoodsId");
            string[] customerIds = Request.Form.GetValues("CustomerId");
            string[] goodsIds = Request.Form.GetValues("GoodsId");
            string[] storeIds = Request.Form.GetValues("StoreId");
            string[] storeInCounts = Request.Form.GetValues("Count");
            string[] storeInGoodsRemark = Request.Form.GetValues("StoreInGoodsRemark");
            if (storeWaitingGoodsIds != null && customerIds != null && storeIds != null && storeInCounts != null && storeInGoodsRemark != null
                && storeWaitingGoodsIds.Length > 0 && customerIds.Length > 0 && storeIds.Length > 0 && storeInCounts.Length > 0 && storeInGoodsRemark.Length > 0)
            {
                for (int i = 0; i < storeWaitingGoodsIds.Length; i++)
                {
                    int storeWaitingGoodsId, customerId, storeId, goodsId;
                    decimal storeInCount;
                    if (int.TryParse(storeWaitingGoodsIds[i], out storeWaitingGoodsId) && int.TryParse(customerIds[i], out customerId)
                        && int.TryParse(storeIds[i], out storeId) && decimal.TryParse(storeInCounts[i], out storeInCount) 
                        && int.TryParse(goodsIds[i], out goodsId))
                    {
                        model.AddStoreInGoods(new StoreInGoods(storeId, storeWaitingGoodsId, customerId, goodsId, storeInCount, storeInGoodsRemark[i]));
                    }
                }
            }
            #endregion

            if (bll.Add(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加入库单:" + model.AccountNumber); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.StoreInOrder bll = new BLL.StoreInOrder();
            Model.StoreInOrder model = bll.GetModel(_id);

            model.CustomerId = int.Parse(ddlCustomer.SelectedValue);
            model.BeginChargingTime = DateTime.Parse(txtBeginChargingTime.Text);
            model.ChargingTime = new DateTime(model.BeginChargingTime.Year, model.BeginChargingTime.Month, model.BeginChargingTime.Day + 1);
            model.AccountNumber = txtAccountNumber.Text;
            model.InspectionNumber = txtInspectionNumber.Text;
            model.ChargingCount = decimal.Parse(txtChargingCount.Text);
            model.SuttleWeight = decimal.Parse(txtSuttleWeight.Text);
            model.Admin = txtAdmin.Text;
            model.Remark = txtRemark.Text;
            //model.Status = 1;
            //model.CreateTime = DateTime.Now;

            #region 单价
            string[] unitpriceBeginTime = Request.Form.GetValues("UnitpriceBeginTime");
            string[] unitpriceEndTime = Request.Form.GetValues("UnitpriceEndTime");
            string[] unitprice = Request.Form.GetValues("Unitprice");
            string[] unitpriceRemark = Request.Form.GetValues("UnitpriceRemark");

            if (unitpriceBeginTime != null && unitpriceEndTime != null && unitprice != null && unitpriceRemark != null
                && unitpriceBeginTime.Length > 0 && unitpriceEndTime.Length > 0 && unitprice.Length > 0 && unitpriceRemark.Length > 0)
            {
                for (int i = 0; i < unitpriceBeginTime.Length; i++)
                {
                    decimal price;
                    DateTime begintime, endtime;
                    if (string.IsNullOrWhiteSpace(unitpriceBeginTime[i]))
                    {
                        unitpriceBeginTime[i] = DTDateTime.MinDateTime.ToString();
                    }
                    if (string.IsNullOrWhiteSpace(unitpriceEndTime[i]))
                    {
                        unitpriceEndTime[i] = DTDateTime.MaxDateTime.ToString();
                    }
                    if (DateTime.TryParse(unitpriceBeginTime[i], out begintime) && DateTime.TryParse(unitpriceEndTime[i], out endtime)
                        && decimal.TryParse(unitprice[i], out price))
                    {
                        model.AddUnitPrice(new StoreInUnitPrice(begintime, endtime, price, unitpriceRemark[i]));
                    }
                }
            }
            #endregion

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
                        model.AddStoreInCost(new StoreInCost(costName[i], count, totalPrice, costCustomer[i], ""));
                    }
                }
            }
            #endregion

            #region 入库货物
            string[] storeWaitingGoodsIds = Request.Form.GetValues("StoreWaitingGoodsId");
            string[] customerIds = Request.Form.GetValues("CustomerId");
            string[] goodsIds = Request.Form.GetValues("GoodsId");
            string[] storeIds = Request.Form.GetValues("StoreId");
            string[] storeInCounts = Request.Form.GetValues("Count");
            string[] storeInGoodsRemark = Request.Form.GetValues("StoreInGoodsRemark");
            if (storeWaitingGoodsIds != null && customerIds != null && storeIds != null && storeInCounts != null && storeInGoodsRemark != null
                && storeWaitingGoodsIds.Length > 0 && customerIds.Length > 0 && storeIds.Length > 0 && storeInCounts.Length > 0 && storeInGoodsRemark.Length > 0)
            {
                for (int i = 0; i < storeWaitingGoodsIds.Length; i++)
                {
                    int storeWaitingGoodsId, customerId, storeId, goodsId;
                    decimal storeInCount;
                    if (int.TryParse(storeWaitingGoodsIds[i], out storeWaitingGoodsId) && int.TryParse(customerIds[i], out customerId)
                        && int.TryParse(storeIds[i], out storeId) && decimal.TryParse(storeInCounts[i], out storeInCount)
                        && int.TryParse(goodsIds[i], out goodsId))
                    {
                        model.AddStoreInGoods(new StoreInGoods(storeId, storeWaitingGoodsId, customerId, goodsId, storeInCount, storeInGoodsRemark[i]));
                    }
                }
            }
            #endregion

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改入库单信息:" + model.AccountNumber); //记录日志
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
                ChkAdminLevel("storein_storage_order", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改入库单成功！", "storein_storage_order.aspx");
            }
            else //添加
            {
                ChkAdminLevel("storein_storage_order", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加入库单成功！", "storein_storage_order.aspx");
            }
        }

    }
}