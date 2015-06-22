using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.dialog
{
    public partial class dialog_storein_received_invoiced : Web.UI.ManagePage
    {
        private int id = 0;
        protected Model.ReceivedMoney model = new Model.ReceivedMoney();

        protected void Page_Load(object sender, EventArgs e)
        {
            id = DTRequest.GetQueryInt("id");
            if (id < 1)
            {
                JscriptMsg("传输参数不正确！", "back");
                return;
            }
            if (!new BLL.ReceivedMoney().Exists(id))
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
            BLL.ReceivedMoney bll = new BLL.ReceivedMoney();
            model = bll.GetModel(_id);
        }
        #endregion
    }
}