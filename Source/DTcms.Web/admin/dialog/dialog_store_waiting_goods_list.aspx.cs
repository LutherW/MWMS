using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.dialog
{
    public partial class dialog_store_waiting_goods_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int customer_id;
        protected int goods_id;
        protected string beginTime = string.Empty;
        protected string endTime = string.Empty;

        protected string storeOptions = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.customer_id = DTRequest.GetQueryInt("customer_id");
            this.goods_id = DTRequest.GetQueryInt("goods_id");
            this.beginTime = DTRequest.GetQueryString("beginTime");
            this.endTime = DTRequest.GetQueryString("endTime");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("store_waiting", DTEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind("");
                RptBind(" and A.Status = 0 " + CombSqlTxt(this.customer_id, this.goods_id, this.beginTime, this.endTime), "A.StoringTime ASC");
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

            BLL.Goods goodsBLL = new BLL.Goods();
            DataTable goodsDT = goodsBLL.GetList(0, strWhere, "Id desc").Tables[0];

            this.ddlGoods.Items.Clear();
            this.ddlGoods.Items.Add(new ListItem("货物", ""));
            foreach (DataRow dr in goodsDT.Rows)
            {
                this.ddlGoods.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }

            BLL.Store storeBLL = new BLL.Store();
            DataTable storeDT = storeBLL.GetAllList().Tables[0];
            storeOptions += "<option value='0'>选择仓库</option>";
            foreach (DataRow dr in storeDT.Rows)
            {
                storeOptions += "<option value='" + dr["Id"] + "'>" + dr["Name"] + "</option>";
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
            if (this.goods_id > 0)
            {
                this.ddlGoods.SelectedValue = this.goods_id.ToString();
            }
            txtBeginTime.Text = this.beginTime;
            txtEndTime.Text = this.endTime;
            BLL.StoreWaitingGoods bll = new BLL.StoreWaitingGoods();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _goodsby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("dialog_store_waiting_goods_list.aspx", "customer_id={0}&goods_id={1}&beginTime={2}&endTime={3}&page={4}",
                this.customer_id.ToString(), this.goods_id.ToString(), this.beginTime.ToString(), this.endTime, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _customer_id, int _goods_id, string _beginTime, string _endTime)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_customer_id > 0)
            {
                strTemp.Append(" and B.CustomerId=" + _customer_id);
            }
            if (_goods_id > 0)
            {
                strTemp.Append(" and A.GoodsId=" + _goods_id);
            }
            if (!string.IsNullOrEmpty(beginTime))
            {
                strTemp.Append(" and A.StoringTime>='" + _beginTime + "'");
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strTemp.Append(" and A.StoringTime <='" + _endTime + "'");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("store_waiting_page_size", "DTcmsPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("dialog_store_waiting_goods_list.aspx", "customer_id={0}&goods_id={1}&beginTime={2}&endTime={3}",
                this.customer_id.ToString(), this.goods_id.ToString(), txtBeginTime.Text, txtEndTime.Text));
        }

        //待入库状态
        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("dialog_store_waiting_goods_list.aspx", "customer_id={0}&goods_id={1}&beginTime={2}&endTime={3}",
                ddlCustomer.SelectedValue, this.goods_id.ToString(), this.beginTime, this.endTime));
        }

        //支付状态
        protected void ddlGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("dialog_store_waiting_goods_list.aspx", "customer_id={0}&goods_id={1}&beginTime={2}&endTime={3}",
                this.customer_id.ToString(), ddlGoods.SelectedValue, this.beginTime, this.endTime));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("store_waiting_page_size", "DTcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("dialog_store_waiting_goods_list.aspx", "customer_id={0}&goods_id={1}&beginTime={2}&endTime={3}",
                this.customer_id.ToString(), this.goods_id.ToString(), this.beginTime.ToString(), this.endTime));
        }

    }
}