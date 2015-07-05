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
    public partial class check_record_edit : Web.UI.ManagePage
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
                if (!new BLL.CheckRecord().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("check_record", DTEnums.ActionEnum.View.ToString()); //检查权限
                
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

            this.ddlGoods.Items.Clear();
            this.ddlGoods.Items.Add(new ListItem("选择货物", ""));

            BLL.Vehicle vehicleBLL = new BLL.Vehicle();
            DataTable vehicleDT = vehicleBLL.GetList(0, strWhere, "Id desc").Tables[0];

            this.ddlVehicle.Items.Clear();
            this.ddlVehicle.Items.Add(new ListItem("选择车辆", ""));
            foreach (DataRow dr in vehicleDT.Rows)
            {
                this.ddlVehicle.Items.Add(new ListItem(dr["PlateNumber"].ToString(), dr["Id"].ToString()));
            }

            BLL.HandlingMode handlingModeBLL = new BLL.HandlingMode();
            DataTable handlingModeDT = handlingModeBLL.GetList(0, strWhere, "Id desc").Tables[0];

            this.ddlHandlingMode.Items.Clear();
            this.ddlHandlingMode.Items.Add(new ListItem("选择装卸方式", ""));
            foreach (DataRow dr in handlingModeDT.Rows)
            {
                this.ddlHandlingMode.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }
        }

        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int customerId;
            if (int.TryParse(ddlCustomer.SelectedValue, out customerId))
            {
                GoodsBind(customerId);
            }
        }

        private void GoodsBind(int customerId) 
        {
            BLL.Goods goodsBLL = new BLL.Goods();
            DataTable goodsDT = goodsBLL.GetList(0, "CustomerId = " + customerId + "", "Id desc").Tables[0];

            this.ddlGoods.Items.Clear();
            this.ddlGoods.Items.Add(new ListItem("选择货物", ""));
            foreach (DataRow dr in goodsDT.Rows)
            {
                this.ddlGoods.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }
        }
  
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.CheckRecord bll = new BLL.CheckRecord();
            Model.CheckRecord model = bll.GetModel(_id);

            ddlCustomer.SelectedValue = model.CustomerId.ToString();
            GoodsBind(model.CustomerId);
            ddlGoods.SelectedValue = model.GoodsId.ToString();
            ddlVehicle.SelectedValue = model.VehicleId.ToString();
            ddlHandlingMode.SelectedValue = model.HandlingModeId.ToString();
            txtCheckTime.Text = model.CheckTime.ToString("yyyy-MM-dd");
            txtInspectionNumber.Text = model.InspectionNumber;
            txtCaseNumber.Text = model.CaseNumber;
            txtCheckResult.Text = model.CheckResult;
            txtRealName.Text = model.RealName;
            txtLinkTel.Text = model.LinkTel;
            txtAdmin.Text = model.Admin;
            txtRemark.Text = model.Remark;

            BLL.CheckCost checkCostBLL = new BLL.CheckCost();
            DataTable checkCostDT = checkCostBLL.GetList(" CheckRecordId = " + _id + "").Tables[0];
            this.rptCostList.DataSource = checkCostDT;
            this.rptCostList.DataBind();
        }

        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.CheckRecord model = new Model.CheckRecord();
            BLL.CheckRecord bll = new BLL.CheckRecord();

            model.CustomerId = int.Parse(ddlCustomer.SelectedValue);
            model.GoodsId = int.Parse(ddlGoods.SelectedValue);
            model.VehicleId = int.Parse(ddlVehicle.SelectedValue);
            model.HandlingModeId = int.Parse(ddlHandlingMode.SelectedValue);
            model.InspectionNumber = txtInspectionNumber.Text;
            model.CaseNumber = txtCaseNumber.Text;
            model.CheckResult = txtCheckResult.Text;
            model.RealName = txtRealName.Text;
            model.LinkTel = txtLinkTel.Text;
            model.CheckTime = DateTime.Parse(txtCheckTime.Text);
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
            string[] costUnitPrices = Request.Form.GetValues("CostUnitPrice");
            if (costName != null && costCount != null && costType != null && costTotalPrice != null && costCustomer != null && costUnitPrices != null
                && costName.Length > 0 && costCount.Length > 0 && costType.Length > 0 && costTotalPrice.Length > 0 && costCustomer.Length > 0 && costUnitPrices.Length > 0)
            {
                for (int i = 0; i < costName.Length; i++)
                {
                    decimal count, totalPrice, unitPrice;
                    if (decimal.TryParse(costCount[i], out count)
                        && decimal.TryParse(costTotalPrice[i], out totalPrice)
                        && decimal.TryParse(costUnitPrices[i], out unitPrice))
                    {
                        if (costType[i].ToString().Equals("-"))
                        {
                            totalPrice *= -1;
                        }
                        model.AddCheckCost(new CheckCost(costName[i], unitPrice, count, totalPrice, costCustomer[i], ""));
                    }
                }
            }
            #endregion

            if (bll.Add(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加查验记录:" + model.Id); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.CheckRecord bll = new BLL.CheckRecord();
            Model.CheckRecord model = bll.GetModel(_id);

            model.CustomerId = int.Parse(ddlCustomer.SelectedValue);
            model.GoodsId = int.Parse(ddlGoods.SelectedValue);
            model.VehicleId = int.Parse(ddlVehicle.SelectedValue);
            model.HandlingModeId = int.Parse(ddlHandlingMode.SelectedValue);
            model.InspectionNumber = txtInspectionNumber.Text;
            model.CaseNumber = txtCaseNumber.Text;
            model.CheckResult = txtCheckResult.Text;
            model.RealName = txtRealName.Text;
            model.LinkTel = txtLinkTel.Text;
            model.CheckTime = DateTime.Parse(txtCheckTime.Text);
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
            string[] costUnitPrices = Request.Form.GetValues("CostUnitPrice");
            if (costName != null && costCount != null && costType != null && costTotalPrice != null && costCustomer != null && costUnitPrices != null
                && costName.Length > 0 && costCount.Length > 0 && costType.Length > 0 && costTotalPrice.Length > 0 && costCustomer.Length > 0 && costUnitPrices.Length > 0)
            {
                for (int i = 0; i < costName.Length; i++)
                {
                    decimal count, totalPrice, unitPrice;
                    if (decimal.TryParse(costCount[i], out count)
                        && decimal.TryParse(costTotalPrice[i], out totalPrice)
                        && decimal.TryParse(costUnitPrices[i], out unitPrice))
                    {
                        if (costType[i].ToString().Equals("-"))
                        {
                            totalPrice *= -1;
                        }
                        model.AddCheckCost(new CheckCost(costName[i], unitPrice, count, totalPrice, costCustomer[i], ""));
                    }
                }
            }
            #endregion

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改查验记录信息:" + model.Id); //记录日志
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
                ChkAdminLevel("check_record", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改查验记录成功！", "check_record_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("check_record", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加查验记录成功！", "check_record_list.aspx");
            }
        }

    }
}