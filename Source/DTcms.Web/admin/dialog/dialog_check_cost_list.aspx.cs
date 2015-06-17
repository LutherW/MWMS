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
    public partial class dialog_check_cost_list : Web.UI.ManagePage
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = DTRequest.GetQueryInt("id");
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("store_in_order", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind("CheckRecordId = " + this.id + "", "CheckRecordId asc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            BLL.CheckCost bll = new BLL.CheckCost();
            this.rptList.DataSource = bll.GetList(0, _strWhere, _orderby);
            this.rptList.DataBind();
        }
        #endregion

    }
}