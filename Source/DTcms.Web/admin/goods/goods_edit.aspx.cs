using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using DTcms.Model;

namespace DTcms.Web.admin.goods
{
    public partial class goods_edit : Web.UI.ManagePage
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
                if (!new BLL.Goods().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("goods_manage", DTEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind(""); //绑定类别
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 绑定类别=================================
        private void TreeBind(string strWhere)
        {
            BLL.Customer customerBLL = new BLL.Customer();
            DataTable customerDT = customerBLL.GetList(0, strWhere, "Id desc").Tables[0];

            this.ddlCustomer.Items.Clear();
            this.ddlCustomer.Items.Add(new ListItem("所属客户", ""));
            foreach (DataRow dr in customerDT.Rows)
            {
                this.ddlCustomer.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }

            BLL.StoreMode storeModeBLL = new BLL.StoreMode();
            DataTable storeModeDT = storeModeBLL.GetList(0, strWhere, "Id desc").Tables[0];

            this.ddlStoreMode.Items.Clear();
            this.ddlStoreMode.Items.Add(new ListItem("存储方式", ""));
            foreach (DataRow dr in storeModeDT.Rows)
            {
                this.ddlStoreMode.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }

            BLL.HandlingMode handlingModeBLL = new BLL.HandlingMode();
            DataTable handlingModeDT = handlingModeBLL.GetList(0, strWhere, "Id desc").Tables[0];

            this.ddlHandlingMode.Items.Clear();
            this.ddlHandlingMode.Items.Add(new ListItem("装卸方式", ""));
            foreach (DataRow dr in handlingModeDT.Rows)
            {
                this.ddlHandlingMode.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }

            BLL.Unit unitBLL = new BLL.Unit();
            DataTable unitDT = unitBLL.GetList(0, strWhere, "Id desc").Tables[0];

            this.ddlUnit.Items.Clear();
            this.ddlUnit.Items.Add(new ListItem("计量单位", ""));
            foreach (DataRow dr in unitDT.Rows)
            {
                this.ddlUnit.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.Goods bll = new BLL.Goods();
            Model.Goods model = bll.GetModel(_id);

            ddlCustomer.SelectedValue = model.CustomerId.ToString();
            ddlStoreMode.SelectedValue = model.StoreModeId.ToString();
            ddlHandlingMode.SelectedValue = model.HandlingModeId.ToString();
            ddlUnit.SelectedValue = model.UnitId.ToString();
            txtName.Text = model.Name;

            BLL.GoodsAttributeValues attributeBLL = new BLL.GoodsAttributeValues();
            DataTable attributeDT = attributeBLL.GetList(" GoodsId = " + _id + "").Tables[0];
            this.rptAttributeList.DataSource = attributeDT;
            this.rptAttributeList.DataBind();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.Goods model = new Model.Goods();
            BLL.Goods bll = new BLL.Goods();

            model.CustomerId = int.Parse(ddlCustomer.SelectedValue);
            model.StoreModeId = int.Parse(ddlStoreMode.SelectedValue);
            model.HandlingModeId = int.Parse(ddlHandlingMode.SelectedValue);
            model.UnitId = int.Parse(ddlUnit.SelectedValue);
            model.Name = txtName.Text;

            string[] attributeNames = Request.Form.GetValues("AttributeName");
            string[] attributeValues = Request.Form.GetValues("AttributeValue");
            string[] attributeRemarks = Request.Form.GetValues("AttributeRemark");
            if (attributeNames != null && attributeValues != null && attributeRemarks != null
                && attributeNames.Length > 0 && attributeValues.Length > 0 && attributeRemarks.Length > 0)
            {
                for (int i = 0; i < attributeNames.Length; i++)
                {
                    model.AddAttributeValues(new GoodsAttributeValues(attributeNames[i], attributeValues[i], attributeRemarks[i]));
                }
            }
            if (bll.Add(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加客户:" + model.Name); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.Goods bll = new BLL.Goods();
            Model.Goods model = bll.GetModel(_id);

            model.CustomerId = int.Parse(ddlCustomer.SelectedValue);
            model.StoreModeId = int.Parse(ddlStoreMode.SelectedValue);
            model.HandlingModeId = int.Parse(ddlHandlingMode.SelectedValue);
            model.UnitId = int.Parse(ddlUnit.SelectedValue);
            model.Name = txtName.Text;

            string[] attributeNames = Request.Form.GetValues("AttributeName");
            string[] attributeValues = Request.Form.GetValues("AttributeValue");
            string[] attributeRemarks = Request.Form.GetValues("AttributeRemark");
            if (attributeNames != null && attributeValues != null && attributeRemarks != null
                && attributeNames.Length > 0 && attributeValues.Length > 0 && attributeRemarks.Length > 0)
            {
                for (int i = 0; i < attributeNames.Length; i++)
                {
                    model.AddAttributeValues(new GoodsAttributeValues(attributeNames[i], attributeValues[i], attributeRemarks[i]));
                }
            }

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改客户信息:" + model.Name); //记录日志
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
                ChkAdminLevel("goods_manage", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改客户成功！", "goods_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("goods_manage", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加客户成功！", "goods_list.aspx");
            }
        }

    }
}