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
    public partial class check_record_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int customer_id;
        protected int goods_id;
        protected int vehicle_id;
        protected string beginTime = string.Empty;
        protected string endTime = string.Empty;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.customer_id = DTRequest.GetQueryInt("customer_id");
            this.goods_id = DTRequest.GetQueryInt("goods_id");
            this.vehicle_id = DTRequest.GetQueryInt("vehicle_id");
            this.beginTime = DTRequest.GetQueryString("beginTime");
            this.endTime = DTRequest.GetQueryString("endTime");
            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("check_record", DTEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind("");
                RptBind(CombSqlTxt(this.customer_id, this.goods_id, this.vehicle_id, this.beginTime, this.endTime, this.keywords), "A.CheckTime DESC");
            }
        }

        private void TreeBind(string strWhere)
        {
            BLL.Customer customerBLL = new BLL.Customer();
            DataTable customerDT = customerBLL.GetList(0, strWhere, "Id desc").Tables[0];

            this.ddlCustomer.Items.Clear();
            this.ddlCustomer.Items.Add(new ListItem("客户", ""));
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

            BLL.Vehicle vehicleBLL = new BLL.Vehicle();
            DataTable vehicleDT = vehicleBLL.GetList(0, strWhere, "Id desc").Tables[0];

            this.ddlVehicle.Items.Clear();
            this.ddlVehicle.Items.Add(new ListItem("车辆", ""));
            foreach (DataRow dr in vehicleDT.Rows)
            {
                this.ddlVehicle.Items.Add(new ListItem(dr["PlateNumber"].ToString(), dr["Id"].ToString()));
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _goodsby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            if (this.customer_id > 0)
            {
                ddlCustomer.SelectedValue = customer_id.ToString();
            }
            if (this.goods_id > 0)
            {
                ddlGoods.SelectedValue = goods_id.ToString();
            }
            if (this.vehicle_id > 0)
            {
                ddlVehicle.SelectedValue = vehicle_id.ToString();
            }
            txtBeginTime.Text = this.beginTime;
            txtEndTime.Text = this.endTime;
            txtKeyWord.Text = this.keywords;
            BLL.CheckRecord bll = new BLL.CheckRecord();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _goodsby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("check_record_list.aspx", "customer_id={0}&goods_id={1}&vehicle_id={2}&beginTime={3}&endTime={4}&keywords={5}&page={6}",
                this.customer_id.ToString(), this.goods_id.ToString(), this.vehicle_id.ToString(), this.beginTime.ToString(), this.endTime, this.keywords.ToString(), "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _customer_id, int _goods_id, int _vehicle_id, string _beginTime, string _endTime, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_customer_id > 0)
            {
                strTemp.Append(" and A.CustomerId>=" + _customer_id + "");
            }
            if (_goods_id > 0)
            {
                strTemp.Append(" and A.GoodsId=" + _goods_id + "");
            }
            if (_vehicle_id > 0)
            {
                strTemp.Append(" and A.VehicleId=" + _vehicle_id + "");
            }
            if (!string.IsNullOrEmpty(beginTime))
            {
                strTemp.Append(" and A.CheckTime>='" + _beginTime + "'");
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strTemp.Append(" and A.CheckTime <='" + _endTime + "'");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (A.InspectionNumber LIKE '%" + _keywords + "%' OR A.CaseNumber LIKE '%" + _keywords + "%' OR A.RealName LIKE '%" + _keywords + "%' OR A.LinkTel LIKE '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("check_record_page_size", "DTcmsPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("check_record_list.aspx", "customer_id={0}&goods_id={1}&vehicle_id={2}&beginTime={3}&endTime={4}&keywords={5}",
                this.customer_id.ToString(), this.goods_id.ToString(), this.vehicle_id.ToString(), txtBeginTime.Text, txtEndTime.Text, txtKeyWord.Text));
        }


        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("check_record_list.aspx", "customer_id={0}&goods_id={1}&vehicle_id={2}&beginTime={3}&endTime={4}&keywords={5}",
                ddlCustomer.SelectedValue, this.goods_id.ToString(), this.vehicle_id.ToString(), this.beginTime.ToString(), this.endTime, this.keywords.ToString()));
        }

        protected void ddlGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("check_record_list.aspx", "customer_id={0}&goods_id={1}&vehicle_id={2}&beginTime={3}&endTime={4}&keywords={5}",
                this.customer_id.ToString(), ddlGoods.SelectedValue, this.vehicle_id.ToString(), this.beginTime.ToString(), this.endTime, this.keywords.ToString()));
        }

        protected void ddlVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("check_record_list.aspx", "customer_id={0}&goods_id={1}&vehicle_id={2}&beginTime={3}&endTime={4}&keywords={5}",
                this.customer_id.ToString(), this.goods_id.ToString(), ddlVehicle.SelectedValue, this.beginTime.ToString(), this.endTime, this.keywords.ToString()));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("check_record_page_size", "DTcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("check_record_list.aspx", "customer_id={0}&goods_id={1}&vehicle_id={2}&beginTime={3}&endTime={4}&keywords={5}",
                this.customer_id.ToString(), this.goods_id.ToString(), this.vehicle_id.ToString(), this.beginTime.ToString(), this.endTime, this.keywords.ToString()));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("check_record", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.CheckRecord bll = new BLL.CheckRecord();
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
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除查验记录成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("check_record_list.aspx", "customer_id={0}&goods_id={1}&beginTime={2}&endTime={3}",
                this.customer_id.ToString(), this.goods_id.ToString(), this.beginTime.ToString(), this.endTime));
        }

    }
}