using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.business
{
    public partial class storein_cost_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int storein_order_id;
        protected int type;
        protected int status;
        protected string keyword;
        protected string beginTime = string.Empty;
        protected string endTime = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.storein_order_id = DTRequest.GetQueryInt("storein_order_id");
            this.type = DTRequest.GetQueryInt("type");
            this.status = DTRequest.GetQueryInt("status");
            this.keyword = DTRequest.GetQueryString("keyword");
            this.beginTime = DTRequest.GetQueryString("beginTime");
            this.endTime = DTRequest.GetQueryString("endTime");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("storein_cost_manage", DTEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind("");
                RptBind(CombSqlTxt(this.storein_order_id, this.type, this.status, this.keyword, this.beginTime, this.endTime), "A.StoreInOrderId DESC");
            }
        }

        private void TreeBind(string strWhere)
        {
            BLL.StoreInOrder storeInOrderBLL = new BLL.StoreInOrder();
            DataTable storeInOrderDT = storeInOrderBLL.GetList(0, "Status > 1", "Id desc").Tables[0];

            this.ddlStoreInOrder.Items.Clear();
            this.ddlStoreInOrder.Items.Add(new ListItem("选择入库单", ""));
            foreach (DataRow dr in storeInOrderDT.Rows)
            {
                this.ddlStoreInOrder.Items.Add(new ListItem(dr["AccountNumber"].ToString(), dr["Id"].ToString()));
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _goodsby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            if (this.storein_order_id > 0)
            {
                this.ddlStoreInOrder.SelectedValue = this.storein_order_id.ToString();
            }
            this.ddlType.SelectedValue = this.type.ToString();
            this.ddlStatus.SelectedValue = this.status.ToString();
            txtKeyWord.Text = this.keyword;
            txtBeginTime.Text = this.beginTime;
            txtEndTime.Text = this.endTime;
            BLL.StoreInCost bll = new BLL.StoreInCost();
            this.rptList.DataSource = bll.GetSearchList(this.pageSize, this.page, _strWhere, _goodsby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("storein_cost_list.aspx", "storein_order_id={0}&type={1}&status={2}&keyword={3}&beginTime={4}&endTime={5}&page={6}",
                this.storein_order_id.ToString(), this.type.ToString(), this.status.ToString(), this.keyword.ToString(), this.beginTime.ToString(), this.endTime, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _storein_order_id, int _type, int _status, string _keyword, string _beginTime, string _endTime)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_storein_order_id > 0)
            {
                strTemp.Append(" and A.StoreInOrderId=" + _storein_order_id);
            }
            if (_type == 1)
            {
                strTemp.Append(" and A.TotalPrice >= 0");
            }
            else if (_type == 2)
            {
                strTemp.Append(" and A.TotalPrice < 0");
            }
            if (_status == 1)
            {
                strTemp.Append(" and A.Status = 1");
            }
            else if (_type == 2)
            {
                strTemp.Append(" and A.Status = 0");
            }
            if (!string.IsNullOrEmpty(_keyword))
            {
                strTemp.Append(" and (Name like '%" + _keyword + "%' or Customer like '%" + _keyword + "%' or A.Admin = '" + _keyword + "')");
            }
            if (!string.IsNullOrEmpty(beginTime))
            {
                strTemp.Append(" and A.PaidTime>='" + _beginTime + "'");
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strTemp.Append(" and A.PaidTime <='" + _endTime + "'");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("storein_cost_page_size", "DTcmsPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("storein_cost_list.aspx", "storein_order_id={0}&type={1}&status={2}&keyword={3}&beginTime={4}&endTime={5}",
                this.storein_order_id.ToString(), this.type.ToString(), this.status.ToString(), txtKeyWord.Text, txtBeginTime.Text, txtEndTime.Text));
        }

        //待入库状态
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("storein_cost_list.aspx", "storein_order_id={0}&type={1}&status={2}&keyword={3}&beginTime={4}&endTime={5}",
                this.storein_order_id.ToString(), ddlType.SelectedValue, this.status.ToString(), this.keyword, this.beginTime, this.endTime));
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("storein_cost_list.aspx", "storein_order_id={0}&type={1}&status={2}&keyword={3}&beginTime={4}&endTime={5}",
                this.storein_order_id.ToString(), this.type.ToString(), ddlStatus.SelectedValue, this.keyword, this.beginTime, this.endTime));
        }


        protected void ddlStoreInOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("storein_cost_list.aspx", "storein_order_id={0}&type={1}&status={2}&keyword={3}&beginTime={4}&endTime={5}",
                ddlStoreInOrder.SelectedValue, this.type.ToString(), this.status.ToString(), this.keyword, this.beginTime, this.endTime));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("storein_cost_page_size", "DTcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("storein_cost_list.aspx", "storein_order_id={0}&type={1}&status={2}&keyword={3}&beginTime={4}&endTime={5}",
                this.storein_order_id.ToString(), this.keyword.ToString(), this.beginTime.ToString(), this.endTime));
        }
    }
}