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
    public partial class storeout_storage_order : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int customer_id;
        protected string keyword;
        protected string beginTime = string.Empty;
        protected string endTime = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.customer_id = DTRequest.GetQueryInt("customer_id");
            this.keyword = DTRequest.GetQueryString("keyword");
            this.beginTime = DTRequest.GetQueryString("beginTime");
            this.endTime = DTRequest.GetQueryString("endTime");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("storeout_storage_order", DTEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind("");
                RptBind(CombSqlTxt(this.customer_id, this.keyword, this.beginTime, this.endTime), "A.CreateTime DESC");
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
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _goodsby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            if (this.customer_id > 0)
            {
                this.ddlCustomer.SelectedValue = this.customer_id.ToString();
            }
            txtKeyWord.Text = this.keyword;
            txtBeginTime.Text = this.beginTime;
            txtEndTime.Text = this.endTime;
            BLL.StoreOutOrder bll = new BLL.StoreOutOrder();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _goodsby, out this.totalCount);
            this.rptList.DataBind();
            
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("storeout_storage_order.aspx", "customer_id={0}&keyword={1}&beginTime={2}&endTime={3}&page={4}",
                this.customer_id.ToString(), this.keyword.ToString(), this.beginTime.ToString(), this.endTime, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _customer_id, string _keyword, string _beginTime, string _endTime)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.Append(" and A.Status=0");
            if (_customer_id > 0)
            {
                strTemp.Append(" and A.CustomerId=" + _customer_id);
            }
            if (!string.IsNullOrEmpty(_keyword))
            {
                strTemp.Append(" and (A.Admin='" + _keyword + "' or A.Remark = '" + _keyword + "')");
            }
            if (!string.IsNullOrEmpty(beginTime))
            {
                strTemp.Append(" and A.StoredOutTime>='" + _beginTime + "'");
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strTemp.Append(" and A.StoredOutTime <='" + _endTime + "'");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("store_out_order_page_size", "DTcmsPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("storeout_storage_order.aspx", "customer_id={0}&keyword={1}&beginTime={2}&endTime={3}",
                this.customer_id.ToString(), txtKeyWord.Text, txtBeginTime.Text, txtEndTime.Text));
        }

        //待出库状态
        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("storeout_storage_order.aspx", "customer_id={0}&keyword={1}&beginTime={2}&endTime={3}",
                ddlCustomer.SelectedValue, this.keyword, this.beginTime, this.endTime));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("store_out_order_page_size", "DTcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("user_list.aspx", "customer_id={0}&keyword={1}&beginTime={2}&endTime={3}",
                this.customer_id.ToString(), this.keyword.ToString(), this.beginTime.ToString(), this.endTime));
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("storeout_storage_order", DTEnums.ActionEnum.Confirm.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.StoreOutOrder bll = new BLL.StoreOutOrder();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.UpdateField("id = " + id + " and Status = 0", "Status=1") > 0)
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Audit.ToString(), "确认出库单成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("确认出库单成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("storeout_storage_order.aspx", "customer_id={0}&keyword={1}&beginTime={2}&endTime={3}",
                this.customer_id.ToString(), this.keyword.ToString(), this.beginTime.ToString(), this.endTime));
        }

        protected string GetStatus(string status)
        {
            switch (status)
            {
                case "0":
                    return "等待仓库确认";
                case "1":
                    return "等待财务确认";
                case "2":
                    return "完成";
                default:
                    throw new NotImplementedException("未定义的状态");
            }
        }

    }
}