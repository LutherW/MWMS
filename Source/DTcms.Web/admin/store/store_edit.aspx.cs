using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.store
{
    public partial class store_edit : Web.UI.ManagePage
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
                if (!new BLL.Store().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("store", DTEnums.ActionEnum.View.ToString()); //检查权限
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
            BLL.StoreDomain bll = new BLL.StoreDomain();
            DataTable dt = bll.GetList(0, strWhere, "Id desc").Tables[0];

            this.ddlStoreDomain.Items.Clear();
            this.ddlStoreDomain.Items.Add(new ListItem("请选择仓库区域...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlStoreDomain.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.Store bll = new BLL.Store();
            Model.Store model = bll.GetModel(_id);

            ddlStoreDomain.SelectedValue = model.StoreDomainId.ToString();
            txtName.Text = model.Name;
            txtManager.Text = model.Manager;
            txtAddress.Text = model.Address;
            txtRemark.Text = model.Remark;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.Store model = new Model.Store();
            BLL.Store bll = new BLL.Store();

            model.StoreDomainId = int.Parse(ddlStoreDomain.SelectedValue);
            model.Name = txtName.Text;
            model.Manager = txtManager.Text;
            model.Address = txtAddress.Text;
            model.Remark = txtRemark.Text;

            if (bll.Add(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加仓库:" + model.Name); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.Store bll = new BLL.Store();
            Model.Store model = bll.GetModel(_id);

            model.StoreDomainId = int.Parse(ddlStoreDomain.SelectedValue);
            model.Name = txtName.Text;
            model.Manager = txtManager.Text;
            model.Address = txtAddress.Text;
            model.Remark = txtRemark.Text;

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改仓库信息:" + model.Name); //记录日志
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
                ChkAdminLevel("store", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改仓库成功！", "store_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("store", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加仓库成功！", "store_list.aspx");
            }
        }

    }
}