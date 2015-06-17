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
    public partial class dialog_allot_goods : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int storein_order_id;
        protected int storein_goods_id;
        protected string beginTime = string.Empty;
        protected string endTime = string.Empty;

        protected string storeOptions = string.Empty;

        private int allotOrderId;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.storein_order_id = DTRequest.GetQueryInt("storein_order_id");
            this.storein_goods_id = DTRequest.GetQueryInt("storein_goods_id");
            this.beginTime = DTRequest.GetQueryString("beginTime");
            this.endTime = DTRequest.GetQueryString("endTime");
            allotOrderId = DTRequest.GetQueryInt("orderId");
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("storeallot_goods", DTEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind("");
                RptBind(" and A.AllotOrderId = " + allotOrderId + " " + CombSqlTxt(this.storein_order_id, this.storein_goods_id, this.beginTime, this.endTime), "A.Id desc");
            }
        }

        private void TreeBind(string strWhere)
        {
            BLL.StoreInOrder customerBLL = new BLL.StoreInOrder();
            DataTable customerDT = customerBLL.GetList(0, " Status = 2 ", "Id desc").Tables[0];

            this.ddlStoreInOrder.Items.Clear();
            this.ddlStoreInOrder.Items.Add(new ListItem("入库单", ""));
            foreach (DataRow dr in customerDT.Rows)
            {
                this.ddlStoreInOrder.Items.Add(new ListItem(dr["AccountNumber"].ToString(), dr["Id"].ToString()));
            }

            BLL.StoreInGoods goodsBLL = new BLL.StoreInGoods();
            DataTable goodsDT = goodsBLL.GetSelectList(0, strWhere, "Id desc").Tables[0];

            this.ddlStoreInGoods.Items.Clear();
            this.ddlStoreInGoods.Items.Add(new ListItem("入库货物", ""));
            foreach (DataRow dr in goodsDT.Rows)
            {
                this.ddlStoreInGoods.Items.Add(new ListItem(dr["GoodsName"].ToString(), dr["Id"].ToString()));
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
            if (this.storein_goods_id > 0)
            {
                this.ddlStoreInGoods.SelectedValue = this.storein_goods_id.ToString();
            }

            BLL.AllotGoods bll = new BLL.AllotGoods();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _goodsby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("dialog_allot_goods.aspx", "storein_order_id={0}&storein_goods_id={1}&beginTime={2}&endTime={3}&page={4}",
                this.storein_order_id.ToString(), this.storein_goods_id.ToString(), this.beginTime.ToString(), this.endTime, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _storein_order_id, int _storein_goods_id, string _beginTime, string _endTime)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_storein_order_id > 0)
            {
                strTemp.Append(" and A.StoreInOrderId=" + _storein_order_id);
            }
            if (_storein_goods_id > 0)
            {
                strTemp.Append(" and A.StoreInGoodsId=" + _storein_goods_id);
            }
            //if (!string.IsNullOrEmpty(beginTime))
            //{
            //    strTemp.Append(" and A.StoringOutTime>='" + _beginTime + "'");
            //}
            //if (!string.IsNullOrEmpty(endTime))
            //{
            //    strTemp.Append(" and A.StoringOutTime <='" + _endTime + "'");
            //}

            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("storeallot_goods_page_size", "DTcmsPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion


        //待入库状态
        protected void ddlStoreInOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("dialog_allot_goods.aspx", "storein_order_id={0}&storein_goods_id={1}&beginTime={2}&endTime={3}",
                ddlStoreInOrder.SelectedValue, this.storein_goods_id.ToString(), this.beginTime, this.endTime));
        }

        //支付状态
        protected void ddlStoreInGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("dialog_allot_goods.aspx", "storein_order_id={0}&storein_goods_id={1}&beginTime={2}&endTime={3}",
                this.storein_order_id.ToString(), ddlStoreInGoods.SelectedValue, this.beginTime, this.endTime));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("storeallot_goods_page_size", "DTcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("dialog_allot_goods.aspx", "storein_order_id={0}&storein_goods_id={1}&beginTime={2}&endTime={3}",
                this.storein_order_id.ToString(), this.storein_goods_id.ToString(), this.beginTime.ToString(), this.endTime));
        }

    }
}