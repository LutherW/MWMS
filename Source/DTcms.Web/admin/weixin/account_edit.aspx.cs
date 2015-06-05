using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.weixin
{
    public partial class account_edit : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("weixin_account_manage", DTEnums.ActionEnum.View.ToString()); //检查权限
                ShowInfo();
            }
        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
            BLL.weixin_account bll = new BLL.weixin_account();
            Model.weixin_account model = bll.GetModel();
            if (model != null)
            {
                txtName.Text = model.name;
                txtOriginalId.Text = model.originalid;
                txtWxCode.Text = model.wxcode;
                txtToKen.Text = model.token;
                txtAppId.Text = model.appid;
                txtAppSecret.Text = model.appsecret;
                if (model.is_push == 1)
                {
                    cbIsPush.Checked = true;
                }
                else
                {
                    cbIsPush.Checked = false;
                }
            }
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL.weixin_account bll = new BLL.weixin_account();
            Model.weixin_account model = bll.GetModel();
            if (model == null)
            {
                model = new Model.weixin_account();
            }
            model.name = txtName.Text.Trim();
            model.originalid = txtOriginalId.Text.Trim();
            model.wxcode = txtWxCode.Text.Trim();
            model.token = txtToKen.Text.Trim();
            model.appid = txtAppId.Text.Trim();
            model.appsecret = txtAppSecret.Text.Trim();
            if (cbIsPush.Checked == true)
            {
                model.is_push = 1;
            }
            else
            {
                model.is_push = 0;
            }
            //保存数据
            if (model.id > 0)
            {
                if (bll.Update(model))
                {
                    AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "编辑公众账户:" + model.name); //记录日志
                    JscriptMsg("编辑公众账户成功！", "account_edit.aspx");
                    return;
                }
            }
            else
            {
                if (bll.Add(model) > 0)
                {
                    AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "增加公众账户:" + model.name); //记录日志
                    JscriptMsg("编辑公众账户成功！", "account_edit.aspx");
                    return;
                }
            }
            JscriptMsg("保存过程中发生错误！", string.Empty);
            return;
        }

    }
}