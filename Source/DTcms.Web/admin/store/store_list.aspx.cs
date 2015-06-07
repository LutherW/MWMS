using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.store
{
    public partial class store_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int store_domain_id;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("store_list", DTEnums.ActionEnum.View.ToString()); //检查权限
            this.store_domain_id = DTRequest.GetQueryInt("store_domain_id");
            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                TreeBind(""); //绑定类别
                RptBind("id>0" + CombSqlTxt(this.store_domain_id, this.keywords), "id desc");
            }
        }

        #region 绑定组别=================================
        private void TreeBind(string strWhere)
        {
            BLL.StoreDomain bll = new BLL.StoreDomain();
            DataTable dt = bll.GetList(0, strWhere, "id desc").Tables[0];

            this.ddlStoreDomain.Items.Clear();
            this.ddlStoreDomain.Items.Add(new ListItem("所有仓库区域", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlStoreDomain.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            if (this.store_domain_id > 0)
            {
                this.ddlStoreDomain.SelectedValue = this.store_domain_id.ToString();
            }
            this.txtKeywords.Text = this.keywords;
            BLL.Store bll = new BLL.Store();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("store_list.aspx", "store_domain_id={0}&keywords={1}&page={2}",
                this.store_domain_id.ToString(), this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _store_domain_id, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_store_domain_id > 0)
            {
                strTemp.Append(" and StoreDomainId=" + _store_domain_id);
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (Name like '%" + _keywords + "%' or Manager like '%" + _keywords + "%' or Address like '%" + _keywords + "%')");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回仓库每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("store_list_page_size", "DTcmsPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("store_list.aspx", "store_domain_id={0}&keywords={1}",
                this.store_domain_id.ToString(), txtKeywords.Text));
        }

        //筛选类别
        protected void ddlStoreDomain_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("store_list.aspx", "store_domain_id={0}&keywords={1}",
                ddlStoreDomain.SelectedValue, this.keywords));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("store_list_page_size", "DTcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("store_list.aspx", "store_domain_id={0}&keywords={1}",
                this.store_domain_id.ToString(), this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("store_list", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.Store bll = new BLL.Store();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除仓库" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！",
                Utils.CombUrlTxt("store_list.aspx", "store_domain_id={0}&keywords={1}", this.store_domain_id.ToString(), this.keywords));
        }
    }
}