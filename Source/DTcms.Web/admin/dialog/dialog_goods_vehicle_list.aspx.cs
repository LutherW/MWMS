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
    public partial class dialog_goods_vehicle_list : Web.UI.ManagePage
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = DTRequest.GetQueryInt("goodsId");
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("store_waiting", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind("", "");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            BLL.StoreInGoodsVehicle goodsVehicleBLL = new BLL.StoreInGoodsVehicle();
            DataTable goodsVehicleDT = goodsVehicleBLL.GetList(" and A.StoreWaitingGoodsId = " + this.id + "").Tables[0];
            this.rptList.DataSource = goodsVehicleDT;
            this.rptList.DataBind();
        }
        #endregion

    }
}