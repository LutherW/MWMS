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
    public partial class store_waiting_edit : Web.UI.ManagePage
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
                if (!new BLL.StoreWaitingGoods().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("store_waiting", DTEnums.ActionEnum.View.ToString()); //检查权限
                
                TreeBind(""); //绑定类别
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else if (action == DTEnums.ActionEnum.Add.ToString())
                {
                    Model.manager manager = GetAdminInfo();
                    txtStoringTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtAdmin.Text = manager == null ? "" : manager.user_name;
                }
            }
        }

        #region 绑定类别=================================
        private void TreeBind(string strWhere)
        {
            BLL.Goods goodsBLL = new BLL.Goods();
            DataTable customerDT = goodsBLL.GetList(0, strWhere, "Id desc").Tables[0];

            this.ddlGoods.Items.Clear();
            this.ddlGoods.Items.Add(new ListItem("货物", ""));
            foreach (DataRow dr in customerDT.Rows)
            {
                this.ddlGoods.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.StoreWaitingGoods bll = new BLL.StoreWaitingGoods();
            Model.StoreWaitingGoods model = bll.GetModel(_id);

            ddlGoods.SelectedValue = model.GoodsId.ToString();
            txtStoringTime.Text = model.StoringTime.ToString("yyyy-MM-dd");
            txtAdmin.Text = model.Admin;
            txtRemark.Text = model.Remark;

            BLL.StoreInGoodsVehicle goodsVehicleBLL = new BLL.StoreInGoodsVehicle();
            DataTable goodsVehicleDT = goodsVehicleBLL.GetList(" and A.StoreWaitingGoodsId = " + _id + "").Tables[0];
            this.rptGoodsVehicleList.DataSource = goodsVehicleDT;
            this.rptGoodsVehicleList.DataBind();

            BLL.Attach attachBLL = new BLL.Attach();
            DataTable attachDT = attachBLL.GetList(" StoreWaitingGoodsId = " + _id + "").Tables[0];
            this.rptAttachList.DataSource = attachDT;
            this.rptAttachList.DataBind();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            if (string.IsNullOrWhiteSpace(txtStoringTime.Text))
            {
                JscriptMsg("计划入库时间不能为空！", "");
                return false;
            }
            Model.StoreWaitingGoods model = new Model.StoreWaitingGoods();
            BLL.StoreWaitingGoods bll = new BLL.StoreWaitingGoods();

            model.GoodsId = int.Parse(ddlGoods.SelectedValue);
            model.StoringTime = DateTime.Parse(txtStoringTime.Text);
            model.Admin = txtAdmin.Text;
            model.Remark = txtRemark.Text;
            model.Status = 0;
            model.CreateTime = DateTime.Now;

            string[] vehicleIds = Request.Form.GetValues("VehicleId");
            string[] vehicleCount = Request.Form.GetValues("Count");
            string[] vehicleRemark = Request.Form.GetValues("GoodsVehicleRemark");
            if (vehicleIds != null && vehicleCount != null && vehicleRemark != null
                && vehicleIds.Length > 0 && vehicleCount.Length > 0 && vehicleRemark.Length > 0)
            {
                for (int i = 0; i < vehicleIds.Length; i++)
                {
                    decimal count;
                    int vehicleId;
                    if (int.TryParse(vehicleIds[i], out vehicleId) && decimal.TryParse(vehicleCount[i], out count))
                    {
                        model.AddGoodsVehicle(new StoreInGoodsVehicle(vehicleId, vehicleRemark[i], count));
                    }
                }
            }


            string[] fileNames = Request.Form.GetValues("hid_attach_filename");
            string[] filePaths = Request.Form.GetValues("hid_attach_filepath");
            string[] attachRemark = Request.Form.GetValues("txt_attach_remark");
            if (fileNames != null && filePaths != null && attachRemark != null
                && fileNames.Length > 0 && filePaths.Length > 0 && attachRemark.Length > 0)
            {
                for (int i = 0; i < fileNames.Length; i++)
                {
                    model.AddAttach(new Attach(filePaths[i], fileNames[i], attachRemark[i]));
                }
            }

            if (bll.Add(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加待入库货物:" + model.GoodsId); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            if (string.IsNullOrWhiteSpace(txtStoringTime.Text))
            {
                JscriptMsg("计划入库时间不能为空！", "");
                return false;
            }
            BLL.StoreWaitingGoods bll = new BLL.StoreWaitingGoods();
            Model.StoreWaitingGoods model = bll.GetModel(_id);

            model.GoodsId = int.Parse(ddlGoods.SelectedValue);
            model.StoringTime = DateTime.Parse(txtStoringTime.Text);
            model.Admin = txtAdmin.Text;
            model.Remark = txtRemark.Text;

            string[] vehicleIds = Request.Form.GetValues("VehicleId");
            string[] vehicleCount = Request.Form.GetValues("Count");
            string[] vehicleRemark = Request.Form.GetValues("GoodsVehicleRemark");
            if (vehicleIds != null && vehicleCount != null && vehicleRemark != null
                && vehicleIds.Length > 0 && vehicleCount.Length > 0 && vehicleRemark.Length > 0)
            {
                model.GoodsVehicles.Clear();
                for (int i = 0; i < vehicleIds.Length; i++)
                {
                    decimal count;
                    int vehicleId;
                    if (int.TryParse(vehicleIds[i], out vehicleId) && decimal.TryParse(vehicleCount[i], out count))
                    {
                        model.AddGoodsVehicle(new StoreInGoodsVehicle(vehicleId, vehicleRemark[i], count));
                    }
                }
            }


            string[] fileNames = Request.Form.GetValues("hid_attach_filename");
            string[] filePaths = Request.Form.GetValues("hid_attach_filepath");
            string[] attachRemark = Request.Form.GetValues("txt_attach_remark");
            if (fileNames != null && filePaths != null && attachRemark != null
                && fileNames.Length > 0 && filePaths.Length > 0 && attachRemark.Length > 0)
            {
                for (int i = 0; i < fileNames.Length; i++)
                {
                    model.AddAttach(new Attach(filePaths[i], fileNames[i], attachRemark[i]));
                }
            }

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改待入库货物信息:" + model.GoodsId); //记录日志
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
                ChkAdminLevel("store_waiting", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改待入库货物成功！", "store_waiting.aspx");
            }
            else //添加
            {
                ChkAdminLevel("store_waiting", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加待入库货物成功！", "store_waiting.aspx");
            }
        }

    }
}