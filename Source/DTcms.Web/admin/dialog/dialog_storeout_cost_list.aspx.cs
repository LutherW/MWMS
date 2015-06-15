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
    public partial class dialog_storeout_cost_list : Web.UI.ManagePage
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = DTRequest.GetQueryInt("orderId");
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("store_in_order", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind("StoreOutOrderId = " + this.id + "", "StoreOutOrderId asc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            BLL.StoreOutCost bll = new BLL.StoreOutCost();
            this.rptList.DataSource = bll.GetList(0, _strWhere, _orderby);
            this.rptList.DataBind();
        }
        #endregion

    }
}