using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.dialog
{
    public partial class dialog_check_cost_invoiced : Web.UI.ManagePage
    {
        private int id = 0;
        protected Model.CheckCost model = new Model.CheckCost();

        protected void Page_Load(object sender, EventArgs e)
        {
            id = DTRequest.GetQueryInt("id");
            if (id < 1)
            {
                JscriptMsg("传输参数不正确！", "back");
                return;
            }
            if (!new BLL.CheckCost().ExistsById(id))
            {
                JscriptMsg("数据不存在或已被删除！", "back");
                return;
            }
            if (!Page.IsPostBack)
            {
                ShowInfo(id);
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.CheckCost bll = new BLL.CheckCost();
            model = bll.GetModelById(_id);
        }
        #endregion
    }
}