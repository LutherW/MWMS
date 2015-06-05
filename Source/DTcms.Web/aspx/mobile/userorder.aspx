<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.userorder" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="DTcms.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by DTcms Template Engine at 2015/5/13 14:24:53.
		本页面代码由DTcms模板引擎生成于 2015/5/13 14:24:53. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);

	templateBuilder.Append("<!DOCTYPE html>\r\n<!--HTML5 doctype-->\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\">\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=0\">\r\n<meta name=\"apple-mobile-web-app-capable\" content=\"yes\" />\r\n<title>我的订单 - ");
	templateBuilder.Append(Utils.ObjectToStr(site.name));
	templateBuilder.Append("</title>\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/css/icons.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/css/af.ui.base.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/artdialog/ui-dialog.css\" />\r\n<!--jqMobi主JS-->\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery-1.11.2.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/jq.appframework.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/ui/appframework.ui.js\"></");
	templateBuilder.Append("script>\r\n<!--jqMobi插件-->\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/plugins/jq.slidemenu.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/artdialog/dialog-plus-min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/base.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\n	$(document).ready(function(e) {\r\n        $(\".page-list a\").attr(\"data-ignore\",true);\r\n    });\r\n</");
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<div id=\"afui\">\r\n  <div id=\"content\">\r\n\r\n	<div id=\"mainPanel\" class=\"panel\" data-footer=\"main_footer\">\r\n      ");
	if (action=="list")
	{

	templateBuilder.Append("\r\n      <!--交易订单-->\r\n      <header>\r\n        <a href=\"javascript:;\" onclick=\"history.back(-1);\" class=\"backButton\">返回</a>\r\n        <h1>交易订单</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n      \r\n      ");
	DataTable list = get_order_list(10, page, "user_id="+userModel.id+" and status<=3", out totalcount);

	string pagelist = get_page_link(10, page, totalcount, "userorder", action, "__id__");

	templateBuilder.Append(" <!--取得分页页码列表-->\r\n      ");
	foreach(DataRow dr in list.Rows)
	{

	templateBuilder.Append("\r\n      <div class=\"wrap-box\">\r\n        <h2><span>");
	templateBuilder.Append(get_order_status(Utils.StrToInt(Utils.ObjectToStr(dr["id"]), 0)).ToString());

	templateBuilder.Append("</span>订单号：" + Utils.ObjectToStr(dr["order_no"]) + "</h2>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("userorder_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\" class=\"img-list\" data-ignore=\"true\">\r\n          ");
	List<DTcms.Model.article> ls = get_order_goods_list(Utils.StrToInt(Utils.ObjectToStr(dr["id"]), 0));

	if (ls!=null)
	{

	foreach(DTcms.Model.article modelt in ls)
	{

	templateBuilder.Append("\r\n          <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.img_url));
	templateBuilder.Append("\" />\r\n          ");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n        </a>\r\n        <div class=\"note\">\r\n          <p>时间：" + Utils.ObjectToStr(dr["add_time"]) + "</p>\r\n          <p>金额：<b class=\"red\">￥" + Utils.ObjectToStr(dr["order_amount"]) + "</b></p>\r\n        </div>\r\n      </div>\r\n      ");
	}	//end for if

	if (totalcount<1)
	{

	templateBuilder.Append("\r\n      <div style=\"margin:0 10px;line-height:50px;text-align:center;\">暂无记录</div>\r\n      ");
	}	//end for if

	templateBuilder.Append("\r\n      \r\n      <!--分页页码-->\r\n      <div class=\"page-list\">");
	templateBuilder.Append(Utils.ObjectToStr(pagelist));
	templateBuilder.Append("</div>\r\n      <!--/分页页码-->\r\n      \r\n      <!--/交易订单-->\r\n      \r\n      ");
	}
	else if (action=="close")
	{

	templateBuilder.Append("\r\n      <!--已关闭订单-->\r\n      <header>\r\n        <a href=\"javascript:;\" onclick=\"history.back(-1);\" class=\"backButton\">返回</a>\r\n        <h1>已关闭订单</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n      \r\n      ");
	DataTable list = get_order_list(10, page, "user_id="+userModel.id+" and status>3", out totalcount);

	string pagelist = get_page_link(10, page, totalcount, "userorder", action, "__id__");

	templateBuilder.Append(" <!--取得分页页码列表-->\r\n      ");
	foreach(DataRow dr in list.Rows)
	{

	templateBuilder.Append("\r\n      <div class=\"wrap-box\">\r\n        <h2><span>");
	templateBuilder.Append(get_order_status(Utils.StrToInt(Utils.ObjectToStr(dr["id"]), 0)).ToString());

	templateBuilder.Append("</span>订单号：" + Utils.ObjectToStr(dr["order_no"]) + "</h2>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("userorder_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\" class=\"img-list\" data-ignore=\"true\">\r\n          ");
	List<DTcms.Model.article> ls = get_order_goods_list(Utils.StrToInt(Utils.ObjectToStr(dr["id"]), 0));

	if (ls!=null)
	{

	foreach(DTcms.Model.article modelt in ls)
	{

	templateBuilder.Append("\r\n          <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.img_url));
	templateBuilder.Append("\" />\r\n          ");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n        </a>\r\n        <div class=\"note\">\r\n          <p>时间：" + Utils.ObjectToStr(dr["add_time"]) + "</p>\r\n          <p>金额：<b class=\"red\">￥" + Utils.ObjectToStr(dr["order_amount"]) + "</b></p>\r\n        </div>\r\n      </div>\r\n      ");
	}	//end for if

	if (totalcount<1)
	{

	templateBuilder.Append("\r\n      <div style=\"margin:0 10px;line-height:50px;text-align:center;\">暂无记录</div>\r\n      ");
	}	//end for if

	templateBuilder.Append("\r\n      \r\n      <!--分页页码-->\r\n      <div class=\"page-list\">");
	templateBuilder.Append(Utils.ObjectToStr(pagelist));
	templateBuilder.Append("</div>\r\n      <!--/分页页码-->\r\n      \r\n      <!--已关闭订单-->\r\n      ");
	}	//end for if

	templateBuilder.Append("\r\n      \r\n      <!--版权信息-->\r\n      ");

	templateBuilder.Append("      <div class=\"copyright\">\r\n        <p><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" data-ignore=\"true\">触屏版</a> | <a href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.weburl));
	templateBuilder.Append("?m2w\" data-ignore=\"true\">电脑版</a> | <a href=\"javascript:;\" onclick=\"$.ui.scrollToTop('mainPanel')\">返回顶部</a></p>\r\n        <address>版权所有 深圳市动力启航软件有限公司 版本号 V");
	templateBuilder.Append(Utils.GetVersion().ToString());

	templateBuilder.Append("</address></p>\r\n      </div>");


	templateBuilder.Append("\r\n      <!--/版权信息-->\r\n    \r\n	</div>\r\n  \r\n    <!--底部导航-->\r\n    ");

	templateBuilder.Append("    <footer id=\"main_footer\">\r\n      <a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" class=\"icon home\" data-ignore=\"true\">首页</a>\r\n      <a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\" class=\"icon user\" data-ignore=\"true\">会员</a>\r\n      <a href=\"");
	templateBuilder.Append(linkurl("cart"));

	templateBuilder.Append("\" class=\"icon basket\" data-ignore=\"true\">购物车 <span class=\"af-badge lr\"><script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=view_cart_count\"></");
	templateBuilder.Append("script></span></a>\r\n      <a href=\"");
	templateBuilder.Append(linkurl("search"));

	templateBuilder.Append("\" class=\"icon magnifier\" data-ignore=\"true\">搜索</a>\r\n      <a href=\"");
	templateBuilder.Append(linkurl("content","contact"));

	templateBuilder.Append("\" class=\"icon phone\" data-ignore=\"true\">电话</a>\r\n    </footer>");


	templateBuilder.Append("\r\n    <!--/底部导航-->\r\n	\r\n    <!--左侧导航-->\r\n    ");

	templateBuilder.Append("    <nav>\r\n      <ul class=\"list\">\r\n        <li class=\"divider\">网站导航</li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" class=\"icon home\" data-ignore=\"true\">网站首页</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("news"));

	templateBuilder.Append("\" class=\"icon tv\" data-ignore=\"true\">新闻资讯</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("goods"));

	templateBuilder.Append("\" class=\"icon basket\" data-ignore=\"true\">购物商城</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("video"));

	templateBuilder.Append("\" class=\"icon camera\" data-ignore=\"true\">视频专区</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("photo"));

	templateBuilder.Append("\" class=\"icon picture\" data-ignore=\"true\">图片分享</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("down"));

	templateBuilder.Append("\" class=\"icon download\" data-ignore=\"true\">资源下载</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\" class=\"icon user\" data-ignore=\"true\">会员中心</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("content","about"));

	templateBuilder.Append("\" class=\"icon info\" data-ignore=\"true\">关于我们</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("mfeedback"));

	templateBuilder.Append("\" class=\"icon message\" data-ignore=\"true\">在线留言</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("content","contact"));

	templateBuilder.Append("\" class=\"icon phone\" data-ignore=\"true\">联系我们</a></li>\r\n      </ul>\r\n    </nav>");


	templateBuilder.Append("\r\n    <!--/左侧导航-->\r\n      \r\n  </div>\r\n</div>\r\n</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
