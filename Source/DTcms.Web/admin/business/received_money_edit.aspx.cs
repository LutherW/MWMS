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
    public partial class received_money_edit : Web.UI.ManagePage
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
                if (!new BLL.ReceivedMoney().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("received_money", DTEnums.ActionEnum.View.ToString()); //检查权限
                
                TreeBind(""); //绑定类别
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
            this.ddlCustomer.Items.Add(new ListItem("选择客户", ""));
            foreach (DataRow dr in customerDT.Rows)
            {
                this.ddlCustomer.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }

            this.ddlSotreInOrder.Items.Clear();
            this.ddlSotreInOrder.Items.Add(new ListItem("选择入库单", ""));
        }

        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            StoreInOrderBind(ddlCustomer.SelectedValue);
        }

        private void StoreInOrderBind(string customerId)
        {
            int _customerId;
            if (int.TryParse(customerId, out _customerId))
            {
                BLL.StoreInOrder storeInOrderBLL = new BLL.StoreInOrder();
                DataTable storeInOrderDT = storeInOrderBLL.GetList(0, " CustomerId = " + _customerId + " and Status = 2 ", "Id desc").Tables[0];

                this.ddlSotreInOrder.Items.Clear();
                this.ddlSotreInOrder.Items.Add(new ListItem("选择入库单", ""));
                foreach (DataRow dr in storeInOrderDT.Rows)
                {
                    string chargingTime = dr["ChargingTime"].ToString();
                    string itemText = string.Format("{0}(收费时间：{1})", dr["AccountNumber"].ToString(), chargingTime);
                    this.ddlSotreInOrder.Items.Add(new ListItem(itemText, string.Format("{0}|{1}|{2}", dr["Id"].ToString(), chargingTime, dr["ChargingCount"])));
                }
            }
        }

        protected void ddlSotreInOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnitPriceBind(ddlSotreInOrder.SelectedValue);
        }

        private void UnitPriceBind(string storeInOrderValue) 
        {
            string[] storeInOrderValues = storeInOrderValue.Split('|');

            int _storeInOrderId;
            DateTime _chargingTime;
            decimal _chargingCount;
            DateTime _receivedEndTime = DateTime.Now;
            DateTime _receivedBeginTime = DateTime.Now;
            if (int.TryParse(storeInOrderValues[0], out _storeInOrderId)
                && DateTime.TryParse(storeInOrderValues[1], out _chargingTime)
                && Decimal.TryParse(storeInOrderValues[2], out _chargingCount))
            {
                BLL.StoreInUnitPrice unitPriceBLL = new BLL.StoreInUnitPrice();
                DataTable unitPriceDT = unitPriceBLL.GetList(0, "StoreInOrderId = " + _storeInOrderId + "", "BeginTime asc").Tables[0];
                int rowsCount = unitPriceDT.Rows.Count;
                StringBuilder unitPriceText = new StringBuilder();
                decimal totalPrice = 0.00M;
                for (int i = 0; i < rowsCount; i++)
                {
                    DateTime beginTime = Convert.ToDateTime(unitPriceDT.Rows[i]["BeginTime"]);
                    DateTime endTime = Convert.ToDateTime(unitPriceDT.Rows[i]["EndTime"]);
                    decimal totalUnitPrice = 0.00M;
                    if (i == 0)
                    {
                        beginTime = _chargingTime;
                        _receivedBeginTime = beginTime;
                    }
                    if (i == rowsCount - 1)
                    {
                        DateTime et;
                        if (!DateTime.TryParse(txtReceivedTime.Text, out et))
                        {
                            et = DateTime.Now;
                        }
                        endTime = new DateTime(et.Year, et.Month, et.Day);
                        _receivedEndTime = endTime;
                    }

                    totalUnitPrice = Convert.ToDecimal(unitPriceDT.Rows[i]["Price"]) * (endTime - beginTime).Days * _chargingCount;

                    unitPriceText.AppendFormat("{0}、时间：{1}-{2}，天数：{3}，单价：{4}，数量：{5}，费用：{6}\r\n",
                        i + 1, beginTime, endTime, 
                        (endTime - beginTime).Days,
                        Convert.ToDecimal(unitPriceDT.Rows[i]["Price"]),
                        _chargingCount,
                        string.Format("{0:N2}", totalUnitPrice));

                    totalPrice += totalUnitPrice;
                }
                txtChargingCount.Text = _chargingCount.ToString("f2");
                txtTotalMoney.Text = totalPrice.ToString("f2");
                txtInvoiceMoney.Text = totalPrice.ToString("f2");
                hidReceivedBeginTime.Value = _receivedBeginTime.ToString();
                hidReceivedEndTime.Value = _receivedEndTime.ToString();
                txtUnitPriceDetails.Text = unitPriceText.ToString();
            }
            else 
            {
                txtUnitPriceDetails.Text = "该入库单下没有单价，无法进行结账。";
            }
        }
  
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.ReceivedMoney bll = new BLL.ReceivedMoney();
            Model.ReceivedMoney model = bll.GetModel(_id);

            txtName.Text = model.Name;
            ddlCustomer.SelectedValue = model.CustomerId.ToString();
            StoreInOrderBind(model.CustomerId.ToString());
            ddlSotreInOrder.SelectedValue = model.StoreInOrderId.ToString() + "|" + model.ReceivedTime.ToString() + "|" + model.ChargingCount.ToString();
            hidReceivedBeginTime.Value = model.BeginChargingTime.ToString();
            hidReceivedEndTime.Value = model.EndChargingTime.ToString();
            txtReceivedTime.Text = model.ReceivedTime.ToString("yyyy-MM-dd");
            txtChargingCount.Text = model.ChargingCount.ToString();
            txtTotalMoney.Text = model.TotalPrice.ToString();
            txtInvoiceMoney.Text = model.InvoicedPrice.ToString();
            txtAdmin.Text = model.Admin;
            txtRemark.Text = model.Remark;
            rblHasBeenInvoiced.Checked = model.HasBeenInvoiced;
            txtInvoicedTime.Text = model.InvoicedTime.HasValue ? model.InvoicedTime.Value.ToString("yyyy-MM-dd") : "";
            txtInvoicedOperator.Text = model.InvoicedOperator;
            txtUnitPriceDetails.Text = model.UnitPriceDetails;

        }

        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            string[] storeInOrderValues = ddlSotreInOrder.SelectedValue.Split('|');
            Model.ReceivedMoney model = new Model.ReceivedMoney();
            BLL.ReceivedMoney bll = new BLL.ReceivedMoney();

            model.Name = txtName.Text;
            model.CustomerId = int.Parse(ddlCustomer.SelectedValue);
            model.StoreInOrderId = int.Parse(storeInOrderValues[0]);
            model.BeginChargingTime = DateTime.Parse(hidReceivedBeginTime.Value);
            model.EndChargingTime = DateTime.Parse(hidReceivedEndTime.Value);
            model.ReceivedTime = DateTime.Parse(txtReceivedTime.Text);
            model.ChargingCount = decimal.Parse(txtChargingCount.Text);
            model.TotalPrice = decimal.Parse(txtTotalMoney.Text);
            model.InvoicedPrice = decimal.Parse(txtInvoiceMoney.Text);
            model.HasBeenInvoiced = rblHasBeenInvoiced.Checked;
            if (!string.IsNullOrWhiteSpace(txtReceivedTime.Text))
            {
                model.InvoicedTime = DateTime.Parse(txtReceivedTime.Text);
            }
            model.Admin = txtAdmin.Text;
            model.InvoicedOperator = txtInvoicedOperator.Text;
            model.UnitPriceDetails = txtUnitPriceDetails.Text;
            model.Remark = txtRemark.Text;
            model.Status = 0;
            model.CreateTime = DateTime.Now;

            if (bll.Add(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加收款记录:" + model.Id); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            string[] storeInOrderValues = ddlSotreInOrder.SelectedValue.Split('|');
            BLL.ReceivedMoney bll = new BLL.ReceivedMoney();
            Model.ReceivedMoney model = bll.GetModel(_id);

            model.Name = txtName.Text;
            model.CustomerId = int.Parse(ddlCustomer.SelectedValue);
            model.StoreInOrderId = int.Parse(storeInOrderValues[0]);
            model.BeginChargingTime = DateTime.Parse(hidReceivedBeginTime.Value);
            model.EndChargingTime = DateTime.Parse(hidReceivedEndTime.Value);
            model.ReceivedTime = DateTime.Parse(txtReceivedTime.Text);
            model.ChargingCount = decimal.Parse(txtChargingCount.Text);
            model.TotalPrice = decimal.Parse(txtTotalMoney.Text);
            model.InvoicedPrice = decimal.Parse(txtInvoiceMoney.Text);
            model.HasBeenInvoiced = rblHasBeenInvoiced.Checked;
            if (!string.IsNullOrWhiteSpace(txtReceivedTime.Text))
            {
                model.InvoicedTime = DateTime.Parse(txtReceivedTime.Text);
            }
            model.Admin = txtAdmin.Text;
            model.InvoicedOperator = txtInvoicedOperator.Text;
            model.UnitPriceDetails = txtUnitPriceDetails.Text;
            model.Remark = txtRemark.Text;

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改收款记录信息:" + model.Id); //记录日志
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
                ChkAdminLevel("received_money", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改收款记录成功！", "received_money_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("received_money", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加收款记录成功！", "received_money_list.aspx");
            }
        }

    }
}