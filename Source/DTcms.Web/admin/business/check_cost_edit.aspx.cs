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
    public partial class check_cost_edit : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

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
                if (!new BLL.CheckCost().ExistsById(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("check_cost_manage", DTEnums.ActionEnum.View.ToString()); //检查权限
                
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
        }
  
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.CheckCost bll = new BLL.CheckCost();
            Model.CheckCost model = bll.GetModelById(_id);

            txtCustomer.Text = model.Customer;
            labCount.Text = model.Count.ToString();
            ddlType.SelectedValue = model.TotalPrice >= 0 ? "+" : "-";
            txtTotalPrice.Text = Math.Abs(model.TotalPrice).ToString();
            txtName.Text = model.Name;
            rblStatus.Checked = model.Status == 1;
            txtPaidTime.Text = model.PaidTime.HasValue ? model.PaidTime.Value.ToString("yyyy-MM-dd") : "";
            rblHasBeenInvoiced.Checked = model.HasBeenInvoiced;
            txtInvoicedTime.Text = model.InvoicedTime.HasValue ? model.InvoicedTime.Value.ToString("yyyy-MM-dd") : "";
            txtInvoicedOperator.Text = model.InvoicedOperator;
            txtAdmin.Text = model.Admin;
            txtRemark.Text = model.Remark;

        }

        private string GetAccountNumber(int storeInOrderId) 
        {
            Model.StoreInOrder storeInOrder = new BLL.StoreInOrder().GetModel(storeInOrderId);
            if (storeInOrder != null)
            {
                return storeInOrder.AccountNumber;
            }

            return "";
        }

        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.CheckCost bll = new BLL.CheckCost();
            Model.CheckCost model = bll.GetModelById(_id);

            model.Name = txtName.Text;
            model.TotalPrice = ddlType.SelectedValue.Equals("-") ? Convert.ToDecimal(txtTotalPrice.Text) * -1 : Convert.ToDecimal(txtTotalPrice.Text) * 1;
            model.Customer = txtCustomer.Text;
            model.Status = rblStatus.Checked ? 1 : 0;
            if (!string.IsNullOrWhiteSpace(txtPaidTime.Text))
            {
                model.PaidTime = Convert.ToDateTime(txtPaidTime.Text);
            }
            model.HasBeenInvoiced = rblHasBeenInvoiced.Checked;
            if (!string.IsNullOrWhiteSpace(txtInvoicedTime.Text))
            {
                model.InvoicedTime = Convert.ToDateTime(txtInvoicedTime.Text);
            }
            model.InvoicedOperator = txtInvoicedOperator.Text;
            model.Admin = txtAdmin.Text;
            model.Remark = txtRemark.Text;

            if (bll.Update(model, _id))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改入库费用信息:" + model.Name); //记录日志
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
                ChkAdminLevel("check_cost_manage", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改入库费用成功！", "check_cost_list.aspx");
            }
        }

    }
}