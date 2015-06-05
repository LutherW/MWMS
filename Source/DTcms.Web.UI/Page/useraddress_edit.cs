using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using DTcms.Common;

namespace DTcms.Web.UI.Page
{
    public partial class useraddress_edit : Web.UI.UserPage
    {
        protected string action;
        protected int id;
        protected Model.user_addr_book model = new Model.user_addr_book();

        /// <summary>
        /// 重写虚方法,此方法在Init事件执行
        /// </summary>
        protected override void InitPage()
        {
            action = DTRequest.GetQueryString("action");
            id = DTRequest.GetQueryInt("id");
            if (action.ToLower() == DTEnums.ActionEnum.Edit.ToString().ToLower())
            {
                BLL.user_addr_book bll = new BLL.user_addr_book();
                if (!bll.Exists(id))
                {
                    HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode("出错了，您要浏览的页面不存在或已删除！")));
                    return;
                }
                model = bll.GetModel(id);
                if (model.user_id != userModel.id)
                {
                    HttpContext.Current.Response.Redirect(linkurl("error", "error.aspx?msg=" + Utils.UrlEncode("出错了，您所要修改的并非自己的地址！")));
                    return;
                }
            }
        }
    }
}
