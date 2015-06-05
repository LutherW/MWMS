﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using DTcms.Common;

namespace DTcms.Web.UI.Page
{
    public partial class userorder_show : Web.UI.UserPage
    {
        protected int id;
        protected string expressdetail = string.Empty; //物流跟踪信息
        protected Model.orders model;
        protected Model.payment payModel;
        

        /// <summary>
        /// 重写虚方法,此方法在Init事件执行
        /// </summary>
        protected override void InitPage()
        {
            id = DTRequest.GetQueryInt("id");
            BLL.orders bll = new BLL.orders();
            if (!bll.Exists(id))
            {
                HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode("出错了，您要浏览的页面不存在或已删除！")));
                return;
            }
            model = bll.GetModel(id);
            if (model.user_id != userModel.id)
            {
                HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode("出错了，您所查看的并非自己的订单信息！")));
                return;
            }
            payModel = new BLL.payment().GetModel(model.payment_id);
            if (payModel == null)
            {
                payModel = new Model.payment();
            }
            //根据订单状态和物流单号跟踪物流信息
            if (model.status > 1 && model.status < 4 && model.express_status == 2 && model.express_no.Trim().Length > 0)
            {
                Model.express modelt = new BLL.express().GetModel(model.express_id);
                Model.orderconfig orderConfig = new BLL.orderconfig().loadConfig();
                if (modelt != null && modelt.express_code.Trim().Length > 0 && orderConfig.kuaidiapi != "")
                {
                    string apiurl = orderConfig.kuaidiapi + "?id=" + orderConfig.kuaidikey + "&com=" + modelt.express_code + "&nu=" + model.express_no + "&show=" + orderConfig.kuaidishow + "&muti=" + orderConfig.kuaidimuti + "&order=" + orderConfig.kuaidiorder;
                    string detail = Utils.HttpGet(@apiurl);
                    if (detail != null)
                    {
                        expressdetail = Utils.ToHtml(detail);
                    }
                }
            }
        }

    }
}
