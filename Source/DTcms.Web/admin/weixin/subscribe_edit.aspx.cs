using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.weixin
{
    public partial class subscribe_edit : Web.UI.ManagePage
    {
        private string action = string.Empty; //消息类型

        protected void Page_Load(object sender, EventArgs e)
        {
            this.action = DTRequest.GetQueryString("action"); //获取消息类型
            if (action.ToLower() == "default")
            {
                ChkAdminLevel("weixin_subscribe_default", DTEnums.ActionEnum.View.ToString()); //检查权限
                hideReqestType.Value = "0"; //默认回复
                litPosition1.Text = litPosition2.Text = "默认回复";
            }
            else if (action.ToLower() == "cancel")
            {
                ChkAdminLevel("weixin_subscribe_cancel", DTEnums.ActionEnum.View.ToString()); //检查权限
                hideReqestType.Value = "7"; //取消关注
                litPosition1.Text = litPosition2.Text = "取消回复";
            }
            else
            {
                ChkAdminLevel("weixin_subscribe_subscribe", DTEnums.ActionEnum.View.ToString()); //检查权限
                hideReqestType.Value = "6"; //关注回复
                litPosition1.Text = litPosition2.Text = "关注回复";
            }

            if (!Page.IsPostBack)
            {
                ShowInfo();
            }
        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
            Model.weixin_request_rule ruleModel = new BLL.weixin_request_rule().GetRequestTypeModel(Utils.StrToInt(hideReqestType.Value, 0)); //获取规则
            if (ruleModel != null)
            {
                hideId.Value = ruleModel.id.ToString(); //规则ID
                switch (ruleModel.response_type)
                {
                    case 1: //纯文本
                        rblResponseType.SelectedValue = "0";
                        txtContent.Text = ruleModel.contents[0].content;
                        break;
                    case 2: //图文
                        rblResponseType.SelectedValue = "1";
                        rptList.DataSource = ruleModel.contents;
                        rptList.DataBind();
                        break;
                    case 3: //语音
                        rblResponseType.SelectedValue = "2";
                        txtSoundTitle.Text = ruleModel.contents[0].title;
                        txtSoundUrl.Text = ruleModel.contents[0].media_url;
                        txtSoundContent.Text = ruleModel.contents[0].content;
                        break;
                    default:
                        rblResponseType.SelectedValue = "0";
                        break;
                }
                btnDelete.Visible = true; // 显示删除按钮
            }
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //检查权限
            switch (this.action.ToLower())
            {
                case "default":
                    ChkAdminLevel("weixin_subscribe_default", DTEnums.ActionEnum.Edit.ToString());
                    break;
                case "cancel":
                    ChkAdminLevel("weixin_subscribe_cancel", DTEnums.ActionEnum.Edit.ToString());
                    break;
                default:
                    ChkAdminLevel("weixin_subscribe_subscribe", DTEnums.ActionEnum.Edit.ToString());
                    break;
            }
            //开始保存数据
            string ruleName = string.Empty; //规格名称
            int ruleId = Utils.StrToInt(hideId.Value, 0); //规则ID
            int requestType = int.Parse(hideReqestType.Value);//请求的类别
            int responseType = int.Parse(rblResponseType.SelectedItem.Value); //回复的类别
            if (requestType == 6)
            {
                ruleName = "关注时的触发内容";
            }
            else if (requestType == 0)
            {
                ruleName = "默认回复内容";
            }
            else if (requestType == 7)
            {
                ruleName = "取消关注时的触发内容";
            }
            Model.weixin_request_rule model = new BLL.weixin_request_rule().GetModel(ruleId);
            if (model == null)
            {
                model = new Model.weixin_request_rule();
            }
            model.name = ruleName;
            model.request_type = requestType;
            model.is_default = 0;
            model.add_time = DateTime.Now;

            if (responseType == 0) //纯文本
            {
                if (txtContent.Text.Trim().Length == 0)
                {
                    JscriptMsg("回复内容不能为空！", string.Empty);
                    return;
                }
                model.response_type = 1;//回复的类型:文本1，图文2，语音3，视频4,第三方接口5
                List<Model.weixin_request_content> ls = new List<Model.weixin_request_content>();
                ls.Add(new Model.weixin_request_content() { rule_id = ruleId, content = txtContent.Text.Trim() });
                model.contents = ls;
            }
            else if (rblResponseType.SelectedItem.Value == "1") //图文
            {
                model.response_type = 2;//回复的类型:文本1，图文2，语音3，视频4,第三方接口5

                #region 赋值规则图片
                string[] itemIdArr = Request.Form.GetValues("item_id");
                string[] itemTitleArr = Request.Form.GetValues("item_title");
                string[] itemContentArr = Request.Form.GetValues("item_content");
                string[] itemImgUrlArr = Request.Form.GetValues("item_imgurl");
                string[] itemLinkUrlArr = Request.Form.GetValues("item_linkurl");
                string[] itemSortIdArr = Request.Form.GetValues("item_sortid");
                if (itemIdArr != null && itemTitleArr != null && itemImgUrlArr != null && itemLinkUrlArr != null && itemSortIdArr != null && itemContentArr != null)
                {
                    if ((itemIdArr.Length == itemTitleArr.Length) && (itemTitleArr.Length == itemImgUrlArr.Length) && (itemImgUrlArr.Length == itemLinkUrlArr.Length)
                        && (itemLinkUrlArr.Length == itemSortIdArr.Length) && (itemSortIdArr.Length == itemContentArr.Length))
                    {
                        List<Model.weixin_request_content> ls = new List<Model.weixin_request_content>();
                        for (int i = 0; i < itemIdArr.Length; i++)
                        {
                            Model.weixin_request_content modelt = new Model.weixin_request_content();
                            modelt.id = Utils.StrToInt(itemIdArr[i].Trim(), 0);
                            modelt.rule_id = ruleId;
                            modelt.title = itemTitleArr[i].Trim();
                            modelt.content = itemContentArr[i].Trim();
                            modelt.img_url = itemImgUrlArr[i].Trim();
                            modelt.link_url = itemLinkUrlArr[i].Trim();
                            modelt.sort_id = Utils.StrToInt(itemSortIdArr[i].Trim(), 99);
                            ls.Add(modelt);
                        }
                        model.contents = ls;
                    }
                }
                else
                {
                    model.contents = null;
                }
                #endregion
            }
            else if (rblResponseType.SelectedItem.Value == "2") //语音
            {
                if (txtSoundTitle.Text.Trim().Length == 0)
                {
                    JscriptMsg("语音标题不能为空！", string.Empty);
                    return;
                }
                if (txtSoundUrl.Text.Trim().Length == 0)
                {
                    JscriptMsg("文件地址不能为空！", string.Empty);
                    return;
                }
                model.response_type = 3;//回复的类型:文本1，图文2，语音3，视频4,第三方接口5
                List<Model.weixin_request_content> ls = new List<Model.weixin_request_content>();
                ls.Add(new Model.weixin_request_content() { rule_id = ruleId, 
                    title = txtSoundTitle.Text.Trim(), media_url = txtSoundUrl.Text.Trim(), content = txtSoundContent.Text.Trim() });
                model.contents = ls;
            }
            //判断是新增还是修改
            if (model.id > 0 && new BLL.weixin_request_rule().Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "新增微信" + ruleName); //记录日志
                JscriptMsg("编辑" + ruleName + "成功！", "subscribe_edit.aspx?action=" + this.action);
                return;
            }
            else if (new BLL.weixin_request_rule().Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "编辑微信" + ruleName); //记录日志
                JscriptMsg("新增" + ruleName + "成功！", "subscribe_edit.aspx?action=" + this.action);
                return;
            }
            JscriptMsg("保存" + ruleName + "失败！", string.Empty);
            return;
        }

        //删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //检查权限
            switch (this.action.ToLower())
            {
                case "default":
                    ChkAdminLevel("weixin_subscribe_default", DTEnums.ActionEnum.Delete.ToString());

                    break;
                case "cancel":
                    ChkAdminLevel("weixin_subscribe_cancel", DTEnums.ActionEnum.Delete.ToString());

                    break;
                default:
                    ChkAdminLevel("weixin_subscribe_subscribe", DTEnums.ActionEnum.Delete.ToString());

                    break;
            }
            //删除操作
            Model.weixin_request_rule ruleModel = new BLL.weixin_request_rule().GetRequestTypeModel(Utils.StrToInt(hideReqestType.Value, 0)); //获取规则
            if (ruleModel != null)
            {
                bool result = new BLL.weixin_request_rule().Delete(ruleModel.id);
                if (result)
                {
                    AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除微信" + ruleModel.name); //记录日志
                    JscriptMsg("删除消息成功！", Utils.CombUrlTxt("subscribe_edit.aspx", "action={0}", this.action));
                    return;
                }

                JscriptMsg("删除消息失败！", Utils.CombUrlTxt("subscribe_edit.aspx", "action={0}", this.action));
                return;
            }
        }
    }
}