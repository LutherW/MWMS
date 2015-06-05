using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.channel
{
    public partial class spec_edit : Web.UI.ManagePage
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
                if (!new BLL.article_spec().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_goods_spec", DTEnums.ActionEnum.View.ToString()); //检查权限
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.article_spec bll = new BLL.article_spec();
            Model.article_spec model = bll.GetModel(_id);

            txtTitle.Text = model.title;
            txtRemark.Text = model.remark;
            txtSortId.Text = model.sort_id.ToString();
            //绑定规格选项
            rptList.DataSource = model.values;
            rptList.DataBind();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.article_spec model = new Model.article_spec();
            BLL.article_spec bll = new BLL.article_spec();

            model.title = txtTitle.Text.Trim();
            model.remark = txtRemark.Text.Trim();
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);

            #region 保存规格选项
            string[] itemIdArr = Request.Form.GetValues("item_id");
            string[] itemTitleArr = Request.Form.GetValues("item_title");
            string[] itemImgUrlArr = Request.Form.GetValues("item_imgurl");
            string[] itemSortIdArr = Request.Form.GetValues("item_sortid");
            if (itemIdArr != null && itemTitleArr != null && itemImgUrlArr != null && itemSortIdArr != null)
            {
                if ((itemIdArr.Length == itemTitleArr.Length) && (itemTitleArr.Length == itemImgUrlArr.Length) && (itemImgUrlArr.Length == itemSortIdArr.Length))
                {
                    List<Model.article_spec_value> ls = new List<Model.article_spec_value>();
                    for (int i = 0; i < itemIdArr.Length; i++)
                    {
                        Model.article_spec_value modelt = new Model.article_spec_value();
                        modelt.id = Utils.StrToInt(itemIdArr[i].Trim(), 0);
                        modelt.title = itemTitleArr[i].Trim();
                        modelt.img_url = itemImgUrlArr[i].Trim();
                        modelt.sort_id = Utils.StrToInt(itemSortIdArr[i].Trim(), 99);
                        ls.Add(modelt);
                    }
                    model.values = ls;
                }
            }
            #endregion

            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加商品规格:" + model.title); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.article_spec bll = new BLL.article_spec();
            Model.article_spec model = bll.GetModel(_id);

            model.title = txtTitle.Text.Trim();
            model.remark = txtRemark.Text.Trim();
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);

            #region 保存规格选项
            string[] itemIdArr = Request.Form.GetValues("item_id");
            string[] itemTitleArr = Request.Form.GetValues("item_title");
            string[] itemImgUrlArr = Request.Form.GetValues("item_imgurl");
            string[] itemSortIdArr = Request.Form.GetValues("item_sortid");
            if (itemIdArr != null && itemTitleArr != null && itemImgUrlArr != null && itemSortIdArr != null)
            {
                if ((itemIdArr.Length == itemTitleArr.Length) && (itemTitleArr.Length == itemImgUrlArr.Length) && (itemImgUrlArr.Length == itemSortIdArr.Length))
                {
                    List<Model.article_spec_value> ls = new List<Model.article_spec_value>();
                    for (int i = 0; i < itemIdArr.Length; i++)
                    {
                        Model.article_spec_value modelt = new Model.article_spec_value();
                        modelt.id = Utils.StrToInt(itemIdArr[i].Trim(), 0);
                        modelt.parent_id = model.id;
                        modelt.title = itemTitleArr[i].Trim();
                        modelt.img_url = itemImgUrlArr[i].Trim();
                        modelt.sort_id = Utils.StrToInt(itemSortIdArr[i].Trim(), 99);
                        ls.Add(modelt);
                    }
                    model.values = ls;
                }
            }
            #endregion

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改商品规格:" + model.title); //记录日志
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
                ChkAdminLevel("sys_goods_spec", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改规格成功！", "spec_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("sys_goods_spec", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加规格成功！", "spec_list.aspx");
            }
        }

    }
}