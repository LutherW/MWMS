<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.article" ValidateRequest="false" %>
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
	const string channel = "news";

	templateBuilder.Append("<!DOCTYPE html>\r\n<!--HTML5 doctype-->\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\">\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=0\">\r\n<meta name=\"apple-mobile-web-app-capable\" content=\"yes\" />\r\n<title>新闻资讯 - ");
	templateBuilder.Append(Utils.ObjectToStr(site.name));
	templateBuilder.Append("</title>\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/css/icons.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/css/af.ui.base.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/idangerous.swiper.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n<!--jqMobi主JS-->\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
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
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/idangerous.swiper-2.1.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/base.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\n	$(document).ready(function(){\r\n	  var mySwiper = new Swiper('.swiper-container',{\r\n		calculateHeight:true,\r\n		resizeReInit:true,\r\n		pagination:\".pagination\",\r\n		autoplay:5000,\r\n		paginationClickable:true\r\n	  });\r\n	});\r\n</");
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<div id=\"afui\">\r\n  <div id=\"content\">\r\n    \r\n	<div id=\"mainPanel\" class=\"panel\" data-header=\"main_header\" data-footer=\"main_footer\">\r\n      <!--筛选按钮-->\r\n      <div class=\"select-bar\">\r\n        <div class=\"col\">\r\n          <a href=\"javascript:;\" class=\"icon-back\" onclick=\"history.back(-1)\">返回上一页</a>\r\n        </div>\r\n        <div class=\"col\">\r\n          <a href=\"#categoryPanel\" class=\"icon-carat-r\">资讯类别</a>\r\n        </div>\r\n      </div>\r\n      <!--/筛选按钮-->\r\n      <!--幻灯片-->\r\n      <div id=\"slider\" class=\"swiper-container\">\r\n        <div class=\"swiper-wrapper\">\r\n          ");
	DataTable focusNews = get_article_list(channel, 0, 8, "status=0 and is_slide=1");

	foreach(DataRow dr in focusNews.Rows)
	{

	templateBuilder.Append("\r\n          <div class=\"swiper-slide\"><a href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\" data-ignore=\"true\"><img src=\"" + Utils.ObjectToStr(dr["img_url"]) + "\" alt=\"" + Utils.ObjectToStr(dr["title"]) + "\" /></a></div>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </div>\r\n        <div class=\"pagination\"></div>\r\n      </div>\r\n      <!--/幻灯片-->\r\n      \r\n      <!--最新资讯-->\r\n      <div class=\"section\">\r\n        <h1>最新资讯</h1>\r\n      </div>\r\n      <div>\r\n        <ul class=\"list listview\">\r\n          ");
	DataTable newList = get_article_list(channel, 0, 8, "status=0");

	int newdr__loop__id=0;
	foreach(DataRow newdr in newList.Rows)
	{
		newdr__loop__id++;


	templateBuilder.Append("\r\n          <li>\r\n            ");
	if (newdr__loop__id==1)
	{

	templateBuilder.Append("\r\n            <a href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(newdr["id"])));

	templateBuilder.Append("\" data-ignore=\"true\">\r\n              <img src=\"" + Utils.ObjectToStr(newdr["img_url"]) + "\" />\r\n              <h2>" + Utils.ObjectToStr(newdr["title"]) + "</h2>\r\n              <p class=\"intro\">" + Utils.ObjectToStr(newdr["zhaiyao"]) + "</p>\r\n            </a>\r\n            ");
	}
	else
	{

	templateBuilder.Append("\r\n            <a href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(newdr["id"])));

	templateBuilder.Append("\" data-ignore=\"true\">\r\n              " + Utils.ObjectToStr(newdr["title"]) + "\r\n            </a>\r\n            ");
	}	//end for if

	templateBuilder.Append("\r\n          </li>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </div>\r\n      <!--/新闻资讯-->\r\n      \r\n      <!--图片新闻-->\r\n      <div class=\"section\">\r\n        <h1>图片新闻</h1>\r\n      </div>\r\n      <div>\r\n        <ul class=\"list listview\">\r\n          ");
	DataTable picNews = get_article_list(channel, 0, 5, "status=0 and img_url<>''");

	foreach(DataRow dr in picNews.Rows)
	{

	templateBuilder.Append("\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\" data-ignore=\"true\">\r\n              <img src=\"" + Utils.ObjectToStr(dr["img_url"]) + "\" />\r\n              <h2>" + Utils.ObjectToStr(dr["title"]) + "</h2>\r\n              <div class=\"note\">\r\n                <p>" + Utils.ObjectToStr(dr["zhaiyao"]) + "</p>\r\n                <p><i class=\"hot\">" + Utils.ObjectToStr(dr["click"]) + "次</i><i class=\"date\">时间：");	templateBuilder.Append(Utils.ObjectToDateTime(Utils.ObjectToStr(dr["add_time"])).ToString("yyyy-MM-dd"));

	templateBuilder.Append("</i></p>\r\n              </div>\r\n            </a>\r\n          </li>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </div>\r\n      <!--/图片新闻-->\r\n      \r\n      <!--人气排行-->\r\n      <div class=\"section\">\r\n        <h1>人气排行</h1>\r\n      </div>\r\n      <div>\r\n        <ul class=\"list listview\">\r\n          ");
	DataTable hotNews = get_article_list(channel, 0, 10, "status=0", "click desc");

	int hotdr__loop__id=0;
	foreach(DataRow hotdr in hotNews.Rows)
	{
		hotdr__loop__id++;


	templateBuilder.Append("\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(hotdr["id"])));

	templateBuilder.Append("\" data-ignore=\"true\">\r\n              <i class=\"number\">");
	templateBuilder.Append(Utils.ObjectToStr(hotdr__loop__id));
	templateBuilder.Append("</i><span class=\"text\">" + Utils.ObjectToStr(hotdr["title"]) + "</span>\r\n            </a>\r\n          </li>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </div>\r\n      <!--人气排行-->\r\n      \r\n      <!--版权信息-->\r\n      ");

	templateBuilder.Append("      <div class=\"copyright\">\r\n        <p><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" data-ignore=\"true\">触屏版</a> | <a href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.weburl));
	templateBuilder.Append("?m2w\" data-ignore=\"true\">电脑版</a> | <a href=\"javascript:;\" onclick=\"$.ui.scrollToTop('mainPanel')\">返回顶部</a></p>\r\n        <address>版权所有 深圳市动力启航软件有限公司 版本号 V");
	templateBuilder.Append(Utils.GetVersion().ToString());

	templateBuilder.Append("</address></p>\r\n      </div>");


	templateBuilder.Append("\r\n      <!--/版权信息-->\r\n    \r\n	</div>\r\n    \r\n    <!--页面头部-->\r\n    ");

	templateBuilder.Append("    <header id=\"main_header\">\r\n      <h2 class=\"logo\"><img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/logo.png\" /></h2>\r\n      <a onclick=\"af.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n    </header>");


	templateBuilder.Append("\r\n    <!--/页面头部-->\r\n    \r\n    <!--底部导航-->\r\n    ");

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


	templateBuilder.Append("\r\n    <!--/左侧导航-->\r\n    \r\n    <!--分类筛选-->\r\n    <div id=\"categoryPanel\" class=\"panel\" data-footer=\"none\">\r\n      <header>\r\n        <a onclick=\"$.ui.goBack();\" class=\"backButton\">返回</a>\r\n        <h1>资讯类别</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n    \r\n      <ul class=\"category-bar\">\r\n        <!--大类-->\r\n        ");
	DataTable category_list1 = get_category_child_list(channel, 0);

	int cdr1__loop__id=0;
	foreach(DataRow cdr1 in category_list1.Rows)
	{
		cdr1__loop__id++;


	templateBuilder.Append("\r\n        <li>\r\n          <h2><a href=\"");
	templateBuilder.Append(linkurl("news_list",Utils.ObjectToStr(cdr1["id"])));

	templateBuilder.Append("\" data-ignore=\"true\">" + Utils.ObjectToStr(cdr1["title"]) + "</a></h2>\r\n          <p>\r\n            <!--小类-->\r\n            ");
	DataTable category_list2 = get_category_child_list(channel, Utils.StrToInt(Utils.ObjectToStr(cdr1["id"]), 0));

	int cdr2__loop__id=0;
	foreach(DataRow cdr2 in category_list2.Rows)
	{
		cdr2__loop__id++;


	templateBuilder.Append("\r\n            <a href=\"");
	templateBuilder.Append(linkurl("news_list",Utils.ObjectToStr(cdr2["id"])));

	templateBuilder.Append("\" data-ignore=\"true\">" + Utils.ObjectToStr(cdr2["title"]) + "</a>\r\n            ");
	}	//end for if

	templateBuilder.Append("\r\n            <!--/小类-->\r\n          </p>\r\n        </li>\r\n        ");
	}	//end for if

	templateBuilder.Append("\r\n        <!--/大类-->\r\n      </ul>\r\n    </div>\r\n    <!--/分类筛选-->\r\n      \r\n  </div>\r\n</div>\r\n</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
