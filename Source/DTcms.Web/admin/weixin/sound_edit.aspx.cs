using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.weixin
{
    public partial class sound_edit : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
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
                if (!new BLL.weixin_request_rule().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("weixin_response_sound", DTEnums.ActionEnum.View.ToString()); //检查权限
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.weixin_request_rule bll = new BLL.weixin_request_rule();
            Model.weixin_request_rule model = bll.GetModel(_id);

            txtSortId.Text = model.sort_id.ToString();
            txtKeywords.Text = model.keywords;
            rblIsLikeQuery.SelectedValue = model.is_like_query.ToString();
            txtTitle.Text = model.contents[0].title;
            txtMediaUrl.Text = model.contents[0].media_url;
            txtContent.Text = model.contents[0].content;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.weixin_request_rule model = new Model.weixin_request_rule();
            BLL.weixin_request_rule bll = new BLL.weixin_request_rule();

            model.name = "语音回复";
            model.request_type = 1;
            model.response_type = 3;
            model.keywords = txtKeywords.Text.Trim();
            model.is_like_query = Utils.StrToInt(rblIsLikeQuery.SelectedValue, 0);
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            List<Model.weixin_request_content> ls = new List<Model.weixin_request_content>();
            ls.Add(new Model.weixin_request_content() { account_id = model.account_id, title = txtTitle.Text.Trim(), media_url = txtMediaUrl.Text.Trim(), content = txtContent.Text.Trim() });
            model.contents = ls;

            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加微信语音回复，关健字:" + model.keywords); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.weixin_request_rule bll = new BLL.weixin_request_rule();
            Model.weixin_request_rule model = bll.GetModel(_id);

            model.keywords = txtKeywords.Text.Trim();
            model.is_like_query = Utils.StrToInt(rblIsLikeQuery.SelectedValue, 0);
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            List<Model.weixin_request_content> ls = new List<Model.weixin_request_content>();
            ls.Add(new Model.weixin_request_content() { account_id = model.account_id, rule_id = model.id, title = txtTitle.Text.Trim(), media_url = txtMediaUrl.Text.Trim(), content = txtContent.Text.Trim() });
            model.contents = ls;

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改微信语音回复，关健字:" + model.keywords); //记录日志
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
                ChkAdminLevel("weixin_response_sound", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", string.Empty);
                    return;
                }
                JscriptMsg("修改语音回复成功！", "sound_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("weixin_response_sound", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", string.Empty);
                    return;
                }
                JscriptMsg("添加语音回复成功！", "sound_list.aspx");
            }
        }

    }
}