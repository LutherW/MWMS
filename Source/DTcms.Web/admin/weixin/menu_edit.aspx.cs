﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.MP.Entities.Menu;
using DTcms.API.Weixin.Common;
using DTcms.Common;

namespace DTcms.Web.admin.weixin
{
    public partial class menu_edit : Web.UI.ManagePage
    {
        CRMComm cpp = new CRMComm(); //获取AccessToKen类
        MenuMgr mMrg = new MenuMgr(); //创建菜单类

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!new BLL.weixin_account().Exists())
            {
                JscriptMsg("请先添加公众账户！", "back");
                return;
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("weixin_custom_menu", DTEnums.ActionEnum.View.ToString()); //检查权限
                ShowInfo();
            }
        }

        #region 获取最新菜单=============================
        private void ShowInfo()
        {
            try
            {
                string error = string.Empty;
                string accessToken = cpp.GetAccessToken(out error);

                if (!string.IsNullOrEmpty(error))
                {
                    JscriptMsg(error, string.Empty);
                    return;
                }
                Senparc.Weixin.MP.Entities.GetMenuResult result = mMrg.GetMenu(accessToken);
                if (result == null)
                {
                    return;
                }
                var topButtonList = result.menu.button;
                int topNum = topButtonList.Count;
                TextBox txtName = new TextBox();
                TextBox txtKey = new TextBox();
                TextBox txtUrl = new TextBox();
                for (int i = 0; i < topNum; i++)
                {
                    var topButton = topButtonList[i];
                    if (topButton != null)
                    {
                        txtName = this.FindControl("txtTop" + (i + 1) + "Name") as TextBox;
                        txtKey = this.FindControl("txtTop" + (i + 1) + "Key") as TextBox;
                        txtUrl = this.FindControl("txtTop" + (i + 1) + "Url") as TextBox;
                        txtName.Text = topButton.name;

                        if (topButton.GetType() != typeof(SubButton))
                        {
                            //下面无子菜单
                            if (topButton.GetType() == typeof(SingleViewButton))
                                txtUrl.Text = ((SingleViewButton)topButton).url;
                        }
                        else
                        {
                            //下面有子菜单
                            IList<SingleButton> subButtonList = ((SubButton)topButton).sub_button;
                            if (subButtonList != null && subButtonList.Count > 0)
                            {
                                TextBox txtSubName = new TextBox();
                                TextBox txtSubKey = new TextBox();
                                TextBox txtSubUrl = new TextBox();
                                for (int j = 0; j < subButtonList.Count; j++)
                                {
                                    txtSubName = this.FindControl("txtMenu" + (i + 1) + (j + 1) + "Name") as TextBox;
                                    txtSubKey = this.FindControl("txtMenu" + (i + 1) + (j + 1) + "Key") as TextBox;
                                    txtSubUrl = this.FindControl("txtMenu" + (i + 1) + (j + 1) + "Url") as TextBox;

                                    if (subButtonList[j].GetType() == typeof(SingleViewButton))
                                    {
                                        SingleViewButton sub = (SingleViewButton)subButtonList[j];
                                        txtSubName.Text = sub.name;
                                        txtSubUrl.Text = sub.url;
                                    }
                                    else
                                    {
                                        SingleClickButton sub = (SingleClickButton)subButtonList[j];
                                        txtSubName.Text = sub.name;
                                        txtSubKey.Text = sub.key;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string error = string.Empty;
                string accessToken = cpp.GetAccessToken(out error);

                if (!string.IsNullOrEmpty(error))
                {
                    JscriptMsg(error, string.Empty);
                    return;
                }

                //重新整理按钮信息
                ButtonGroup bg = new ButtonGroup();
                TextBox txtName = new TextBox();
                TextBox txtKey = new TextBox();
                TextBox txtUrl = new TextBox();
                IList<BaseButton> topList = new List<BaseButton>();
                IList<SingleButton> subList = new List<SingleButton>();
                //菜单设置
                for (int i = 0; i < 3; i++)
                {
                    txtName = this.FindControl("txtTop" + (i + 1) + "Name") as TextBox;
                    txtKey = this.FindControl("txtTop" + (i + 1) + "Key") as TextBox;
                    txtUrl = this.FindControl("txtTop" + (i + 1) + "Url") as TextBox;
                    if (txtName.Text.Trim() == "")
                    {
                        // 如果名称为空，则忽略该菜单，以及下面的子菜单
                        continue;
                    }

                    subList = new List<SingleButton>();
                    TextBox txtSubName = new TextBox();
                    TextBox txtSubKey = new TextBox();
                    TextBox txtSubUrl = new TextBox();
                    for (int j = 0; j < 5; j++)
                    {
                        //子菜单的设置
                        txtSubName = this.FindControl("txtMenu" + (i + 1) + (j + 1) + "Name") as TextBox;
                        txtSubKey = this.FindControl("txtMenu" + (i + 1) + (j + 1) + "Key") as TextBox;
                        txtSubUrl = this.FindControl("txtMenu" + (i + 1) + (j + 1) + "Url") as TextBox;
                        if (txtSubName.Text.Trim() == "")
                        {
                            continue;
                        }

                        if (txtSubUrl.Text.Trim() != "")
                        {
                            SingleViewButton sub = new SingleViewButton();
                            sub.name = txtSubName.Text.Trim();
                            sub.url = txtSubUrl.Text.Trim();
                            subList.Add(sub);
                        }
                        else if (txtSubKey.Text.Trim() != "")
                        {
                            SingleClickButton sub = new SingleClickButton();
                            sub.name = txtSubName.Text.Trim();
                            sub.key = txtSubKey.Text.Trim();
                            subList.Add(sub);
                        }
                        else
                        {
                            //报错 :子菜单必须有key和name
                            JscriptMsg("二级菜单的名称和key或者url必填！", string.Empty);
                            return;
                        }
                    }
                    
                    if (subList != null && subList.Count > 0)
                    {
                        //有子菜单, 该一级菜单是SubButton
                        if (subList.Count < 1)
                        {
                            JscriptMsg("子菜单个数必须为2至5个！", string.Empty);
                            return;
                        }
                        SubButton topButton = new SubButton(Utils.CutString(txtName.Text.Trim(), 16));
                        topButton.sub_button.AddRange(subList);
                        topList.Add(topButton);
                    }
                    else
                    {
                        // 无子菜单
                        if (txtKey.Text.Trim() == "" && txtUrl.Text.Trim() == "")
                        {
                            JscriptMsg("如无子菜单，必须填写Key或者URL值！", string.Empty);
                            return;
                        }

                        if (txtUrl.Text.Trim() != "")
                        {  //view 页面跳转
                            SingleViewButton topSingleButton = new SingleViewButton();
                            topSingleButton.name = txtName.Text.Trim();
                            topSingleButton.url = txtUrl.Text.Trim();
                            topList.Add(topSingleButton);
                        }
                        else if (txtKey.Text.Trim() != "")
                        {
                            SingleClickButton topSingleButton = new SingleClickButton();
                            topSingleButton.name = txtName.Text.Trim();
                            topSingleButton.key = txtKey.Text.Trim();
                            topList.Add(topSingleButton);
                        }
                    }
                }

                bg.button.AddRange(topList);
                var result = mMrg.CreateMenu(accessToken, bg);
                JscriptMsg("自定义菜单保存成功！", "menu_edit.aspx");
            }
            catch (Exception ex)
            {
                JscriptMsg("出错了：" + ex.Message, string.Empty);
            }
        }
    }
}