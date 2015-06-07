using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.customer
{
    public partial class customer_edit : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //取到操作类型
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
                if (!new BLL.Customer().Exists(this.id))
                {
                    JscriptMsg("客户不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("customer_manage", DTEnums.ActionEnum.View.ToString()); //检查权限
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.Customer bll = new BLL.Customer();
            Model.Customer model = bll.GetModel(_id);
            txtCode.Text = model.Code;
            txtName.Text = model.Name;
            txtLinkMan.Text = model.LinkMan;
            txtLinkTel.Text = model.LinkTel;
            txtLinkAddress.Text = model.LinkAddress;
            txtEmail.Text = model.Email;
            txtFax.Text = model.Fax;
            rblStatus.SelectedValue = model.Status.ToString();
            txtRemark.Text = model.Remark;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.Customer model = new Model.Customer();
            BLL.Customer bll = new BLL.Customer();

            model.Code = txtCode.Text;
            model.Name = txtName.Text;
            model.LinkMan = txtLinkMan.Text;
            model.LinkTel = txtLinkTel.Text;
            model.LinkAddress = txtLinkAddress.Text;
            model.Email = txtEmail.Text;
            model.Fax = txtFax.Text;
            model.Status = Convert.ToInt32(rblStatus.SelectedValue);
            model.Remark = txtRemark.Text;
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
            BLL.Customer bll = new BLL.Customer();
            Model.Customer model = bll.GetModel(_id);

            model.Code = txtCode.Text;
            model.Name = txtName.Text;
            model.LinkMan = txtLinkMan.Text;
            model.LinkTel = txtLinkTel.Text;
            model.LinkAddress = txtLinkAddress.Text;
            model.Email = txtEmail.Text;
            model.Fax = txtFax.Text;
            model.Status = Convert.ToInt32(rblStatus.SelectedValue);
            model.Remark = txtRemark.Text;
            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改客户:" + model.Name); //记录日志
                result = true;
            }

            return result;
        }
        #endregion


        // 提交保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("customer_manage", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改客户成功！", "customer_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("customer_manage", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加客户成功！", "customer_list.aspx");
            }
        }

    }
}