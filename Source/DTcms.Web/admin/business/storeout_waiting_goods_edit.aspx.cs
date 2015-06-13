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
    public partial class storeout_waiting_goods_edit : Web.UI.ManagePage
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
                if (!new BLL.StoreOutWaitingGoods().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("storeout_waiting_manage", DTEnums.ActionEnum.View.ToString()); //检查权限
                
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
            BLL.StoreInOrder storeInOrderBLL = new BLL.StoreInOrder();
            DataTable storeInOrderDT = storeInOrderBLL.GetList(0, "Status = 2", "Id desc").Tables[0];

            this.ddlStoreInOrder.Items.Clear();
            this.ddlStoreInOrder.Items.Add(new ListItem("选择入库单", ""));
            foreach (DataRow dr in storeInOrderDT.Rows)
            {
                this.ddlStoreInOrder.Items.Add(new ListItem(dr["AccountNumber"].ToString(), dr["Id"].ToString()));
            }
        }

        protected void ddlStoreInOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            int storeInOrderId;
            if (int.TryParse(ddlStoreInOrder.SelectedValue, out storeInOrderId))
            {
                StoreInGoodsBind(storeInOrderId);
            }
        }

        private void StoreInGoodsBind(int storeInOrderId) 
        {
            BLL.StoreInGoods storeInGoodsBLL = new BLL.StoreInGoods();
            DataTable storeInGoodsDT = storeInGoodsBLL.GetSelectList(0, " and A.StoreInOrderId = " + storeInOrderId + " and A.Count  > 0 ", "A.StoredInTime asc").Tables[0];

            this.ddlStoreInGoods.Items.Clear();
            this.ddlStoreInGoods.Items.Add(new ListItem("选择入库货物", ""));
            foreach (DataRow dr in storeInGoodsDT.Rows)
            {
                this.ddlStoreInGoods.Items.Add(new ListItem(string.Format("{0}(客户：{1},库存：{2})", dr["GoodsName"].ToString(), dr["CustomerName"].ToString(), dr["StoredInCount"].ToString()), string.Format("{0}|{1}", dr["Id"].ToString(), dr["GoodsId"].ToString())));
            }
        }

   
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.StoreOutWaitingGoods bll = new BLL.StoreOutWaitingGoods();
            Model.StoreOutWaitingGoods model = bll.GetModel(_id);

            ddlStoreInOrder.SelectedValue = model.StoreInOrderId.ToString();
            StoreInGoodsBind(model.StoreInOrderId);
            ddlStoreInGoods.SelectedValue = model.StoreInGoodsId.ToString() + "|" + model.GoodsId.ToString();
            txtStoringTime.Text = model.StoringOutTime.ToString("yyyy-MM-dd");
            txtAdmin.Text = model.Admin;
            txtRemark.Text = model.Remark;

            BLL.StoreOutGoodsVehicle goodsVehicleBLL = new BLL.StoreOutGoodsVehicle();
            DataTable goodsVehicleDT = goodsVehicleBLL.GetList(" and A.StoreOutWaitingGoodsId = " + _id + "").Tables[0];
            this.rptGoodsVehicleList.DataSource = goodsVehicleDT;
            this.rptGoodsVehicleList.DataBind();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.StoreOutWaitingGoods model = new Model.StoreOutWaitingGoods();
            BLL.StoreOutWaitingGoods bll = new BLL.StoreOutWaitingGoods();

            string[] ids = ddlStoreInGoods.SelectedValue.Split('|');
            model.GoodsId = int.Parse(ids[1]);
            model.StoreInOrderId = int.Parse(ddlStoreInOrder.SelectedValue);
            model.StoreInGoodsId = int.Parse(ids[0]);
            model.StoringOutTime = DateTime.Parse(txtStoringTime.Text);
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
                        model.AddGoodsVehicle(new StoreOutGoodsVehicle(vehicleId, vehicleRemark[i], count));
                    }
                }
            }

            if (bll.Add(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加待出库货物:" + model.GoodsId); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.StoreOutWaitingGoods bll = new BLL.StoreOutWaitingGoods();
            Model.StoreOutWaitingGoods model = bll.GetModel(_id);

            string[] ids = ddlStoreInGoods.SelectedValue.Split('|');
            model.GoodsId = int.Parse(ids[1]);
            model.StoreInOrderId = int.Parse(ddlStoreInOrder.SelectedValue);
            model.StoreInGoodsId = int.Parse(ids[0]);
            model.StoringOutTime = DateTime.Parse(txtStoringTime.Text);
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
                        model.AddGoodsVehicle(new StoreOutGoodsVehicle(vehicleId, vehicleRemark[i], count));
                    }
                }
            }

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改待出库货物信息:" + model.GoodsId); //记录日志
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
                ChkAdminLevel("storeout_waiting_manage", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改待出库货物成功！", "storeout_waiting_goods.aspx");
            }
            else //添加
            {
                ChkAdminLevel("storeout_waiting_manage", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加待出库货物成功！", "storeout_waiting_goods.aspx");
            }
        }

    }
}