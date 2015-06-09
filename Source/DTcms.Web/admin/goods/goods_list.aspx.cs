using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.goods
{
    public partial class goods_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int customer_id;
        protected int store_mode_id;
        protected int handling_mode_id;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.customer_id = DTRequest.GetQueryInt("customer_id");
            this.store_mode_id = DTRequest.GetQueryInt("store_mode_id");
            this.handling_mode_id = DTRequest.GetQueryInt("handling_mode_id");
            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("goods_manage", DTEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind("");
                RptBind(CombSqlTxt(this.customer_id, this.store_mode_id, this.handling_mode_id, this.keywords), "g.Id desc");
            }
        }

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
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _goodsby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            if (this.customer_id > 0)
            {
                this.ddlCustomer.SelectedValue = this.customer_id.ToString();
            }
            if (this.store_mode_id > 0)
            {
                this.ddlStoreMode.SelectedValue = this.store_mode_id.ToString();
            }
            if (this.handling_mode_id > 0)
            {
                this.ddlHandlingMode.SelectedValue = this.handling_mode_id.ToString();
            }
            txtKeywords.Text = this.keywords;
            BLL.Goods bll = new BLL.Goods();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _goodsby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("goods_list.aspx", "customer_id={0}&store_mode_id={1}&handling_mode_id={2}&keywords={3}&page={4}",
                this.customer_id.ToString(), this.store_mode_id.ToString(), this.handling_mode_id.ToString(), this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _customer_id, int _store_mode_id, int _handling_mode_id, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_customer_id > 0)
            {
                strTemp.Append(" and g.CustomerId=" + _customer_id);
            }
            if (_store_mode_id > 0)
            {
                strTemp.Append(" and g.StoreModeId=" + _store_mode_id);
            }
            if (_handling_mode_id > 0)
            {
                strTemp.Append(" and g.HandlingModeId=" + _handling_mode_id);
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (g.Name like '%" + _keywords + "%' )");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("goods_list_page_size", "DTcmsPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("goods_list.aspx", "customer_id={0}&store_mode_id={1}&handling_mode_id={2}&keywords={3}",
                this.customer_id.ToString(), this.store_mode_id.ToString(), this.handling_mode_id.ToString(), txtKeywords.Text));
        }

        //货物状态
        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("goods_list.aspx", "customer_id={0}&store_mode_id={1}&handling_mode_id={2}&keywords={3}",
                ddlCustomer.SelectedValue, this.store_mode_id.ToString(), this.handling_mode_id.ToString(), this.keywords));
        }

        //支付状态
        protected void ddlStoreMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("goods_list.aspx", "customer_id={0}&store_mode_id={1}&handling_mode_id={2}&keywords={3}",
                this.customer_id.ToString(), ddlStoreMode.SelectedValue, this.handling_mode_id.ToString(), this.keywords));
        }

        //发货状态
        protected void ddlHandlingMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("goods_list.aspx", "customer_id={0}&store_mode_id={1}&handling_mode_id={2}&keywords={3}",
                this.customer_id.ToString(), this.store_mode_id.ToString(), ddlHandlingMode.SelectedValue, this.keywords));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("goods_list_page_size", "DTcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("user_list.aspx", "customer_id={0}&store_mode_id={1}&handling_mode_id={2}&keywords={3}",
                this.customer_id.ToString(), this.store_mode_id.ToString(), this.handling_mode_id.ToString(), this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("goods_", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.Goods bll = new BLL.Goods();
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
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除货物成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("goods_list.aspx", "customer_id={0}&store_mode_id={1}&handling_mode_id={2}&keywords={3}",
                this.customer_id.ToString(), this.store_mode_id.ToString(), this.handling_mode_id.ToString(), this.keywords));
        }

    }
}