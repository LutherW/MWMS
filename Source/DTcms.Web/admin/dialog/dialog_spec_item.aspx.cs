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
    public partial class dialog_spec_item : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RptBind("parent_id=0", "sort_id asc,id desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            BLL.article_spec bll = new BLL.article_spec();
            this.rptList.DataSource = bll.GetList(0, _strWhere, _orderby);
            this.rptList.DataBind();
        }
        #endregion

        //嵌套绑定
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            BLL.article_spec bll = new BLL.article_spec();
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Repeater rptSpecItem = (Repeater)e.Item.FindControl("rptSpecItem");
                //找到关联的数据项 
                DataRowView drv = (DataRowView)e.Item.DataItem;
                //提取父ID 
                int parentId = Convert.ToInt32(drv["id"]);
                //根据父ID查询并绑定
                rptSpecItem.DataSource = bll.GetList(0, "parent_id=" + parentId, "sort_id asc,id desc");
                rptSpecItem.DataBind();
            }
        }

    }
}