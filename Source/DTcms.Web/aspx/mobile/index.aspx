<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.index" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<!--HTML5 doctype-->\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\">\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=0\">\r\n<meta name=\"apple-mobile-web-app-capable\" content=\"yes\" />\r\n<title>");
	templateBuilder.Append(Utils.ObjectToStr(site.seo_title));
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
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\n	$(document).ready(function(){\r\n		var mySwiper = new Swiper('.swiper-container',{\r\n			calculateHeight:true,\r\n			resizeReInit:true,\r\n			pagination:\".pagination\",\r\n			autoplay:5000,\r\n			paginationClickable:true\r\n		});\r\n		$(\"#afui #navbar a.home\").addClass(\"pressed\");\r\n	});\r\n</");
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<div id=\"afui\">\r\n  <div id=\"content\">\r\n    \r\n	<div id=\"mainPanel\" class=\"panel\" data-header=\"main_header\" data-footer=\"main_footer\">\r\n      <!--首页幻灯片-->\r\n      <div id=\"slider\" class=\"swiper-container\">\r\n        <div class=\"swiper-wrapper\">\r\n          <div class=\"swiper-slide\"><img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/banner1.jpg\"/></div>\r\n          <div class=\"swiper-slide\"><img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/banner2.jpg\"/></div>\r\n          <div class=\"swiper-slide\"><img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/banner3.jpg\"/></div>\r\n        </div>\r\n        <div class=\"pagination\"></div>\r\n      </div>\r\n      <!--/首页幻灯片-->\r\n      <!--首页图标导航-->\r\n      <div class=\"nav-list\">\r\n        <ul>\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("news"));

	templateBuilder.Append("\" data-ignore=\"true\">\r\n              <img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/icons/news.png\">\r\n              <span>新闻资讯</span>\r\n            </a>\r\n          </li>\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("goods"));

	templateBuilder.Append("\" data-ignore=\"true\">\r\n              <img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/icons/buy.png\">\r\n              <span>购物商城</span>\r\n            </a>\r\n          </li>\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("video"));

	templateBuilder.Append("\" data-ignore=\"true\">\r\n              <img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/icons/video.png\">\r\n              <span>视频专区</span>\r\n            </a>\r\n          </li>\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("photo"));

	templateBuilder.Append("\" data-ignore=\"true\">\r\n              <img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/icons/photo.png\">\r\n              <span>图片分享</span>\r\n            </a>\r\n          </li>\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("down"));

	templateBuilder.Append("\" data-ignore=\"true\">\r\n              <img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/icons/down.png\">\r\n              <span>资源下载</span>\r\n            </a>\r\n          </li>\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\" data-ignore=\"true\">\r\n              <img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/icons/user.png\">\r\n              <span>会员中心</span>\r\n            </a>\r\n          </li>\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("mfeedback"));

	templateBuilder.Append("\" data-ignore=\"true\">\r\n              <img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/icons/msg.png\">\r\n              <span>留言反馈</span>\r\n            </a>\r\n          </li>\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("content","contact"));

	templateBuilder.Append("\" data-ignore=\"true\">\r\n              <img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/icons/tel.png\">\r\n              <span>联系我们</span>\r\n            </a>\r\n          </li>\r\n        </ul>\r\n      </div>\r\n      <!--/首页图标导航-->\r\n      \r\n      <!--新闻资讯-->\r\n      <div class=\"section\">\r\n        <h1>新闻资讯</h1>\r\n      </div>\r\n      <div>\r\n        <ul class=\"list listview\">\r\n          ");
	DataTable newsList = get_article_list("news", 0, 8, "status=0");

	int newsdr__loop__id=0;
	foreach(DataRow newsdr in newsList.Rows)
	{
		newsdr__loop__id++;


	if (newsdr__loop__id<3)
	{

	templateBuilder.Append("\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(newsdr["id"])));

	templateBuilder.Append("\" data-ignore=\"true\">\r\n              ");
	if (Utils.ObjectToStr(newsdr["img_url"])!="")
	{

	templateBuilder.Append("\r\n              <img src=\"" + Utils.ObjectToStr(newsdr["img_url"]) + "\" />\r\n              ");
	}	//end for if

	templateBuilder.Append("\r\n              <h2>" + Utils.ObjectToStr(newsdr["title"]) + "</h2>\r\n              <p class=\"intro\">" + Utils.ObjectToStr(newsdr["zhaiyao"]) + "</p>\r\n            </a>\r\n          </li>\r\n          ");
	}
	else
	{

	templateBuilder.Append("\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(newsdr["id"])));

	templateBuilder.Append("\" data-ignore=\"true\">" + Utils.ObjectToStr(newsdr["title"]) + "</a>\r\n          </li>\r\n          ");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </div>\r\n      <!--/新闻资讯-->\r\n      \r\n      <!--购物商城-->\r\n      <div class=\"section\">\r\n        <h1>商品推荐</h1>\r\n      </div>\r\n      <div>\r\n        <ul class=\"list listview\">\r\n          ");
	DataTable redGoods = get_article_list("goods", 0, 5, "status=0 and is_red=1");

	foreach(DataRow dr in redGoods.Rows)
	{

	templateBuilder.Append("\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("goods_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\" data-ignore=\"true\">\r\n              <img src=\"" + Utils.ObjectToStr(dr["img_url"]) + "\" />\r\n              <h2>" + Utils.ObjectToStr(dr["title"]) + "</h2>\r\n              <div class=\"note\">\r\n                <p>" + Utils.ObjectToStr(dr["zhaiyao"]) + "</p>\r\n                <p><i class=\"hot\">" + Utils.ObjectToStr(dr["click"]) + "次</i><i class=\"price\">￥" + Utils.ObjectToStr(dr["sell_price"]) + "</i>元</p>\r\n              </div>\r\n            </a>\r\n          </li>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </div>\r\n      <!--/购物商城-->\r\n      \r\n      <!--视频专区-->\r\n      <div class=\"section\">\r\n        <h1>视频专区</h1>\r\n      </div>\r\n      <div>\r\n        <ul class=\"photo-list\">\r\n          ");
	DataTable redVideo = get_article_list("video", 0, 6, "is_red=1 and img_url<>''");

	foreach(DataRow dr in redVideo.Rows)
	{

	templateBuilder.Append("\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("video_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\" data-ignore=\"true\">\r\n              <img src=\"" + Utils.ObjectToStr(dr["img_url"]) + "\" alt=\"" + Utils.ObjectToStr(dr["title"]) + "\" />\r\n              <h2>" + Utils.ObjectToStr(dr["title"]) + "</h2>\r\n            </a>\r\n          </li>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </div>\r\n      <!--视频专区-->\r\n      \r\n      <!--图片分享-->\r\n      <div class=\"section\">\r\n        <h1>图片分享</h1>\r\n      </div>\r\n      <div>\r\n        <ul id=\"photo\" class=\"photo-list\">\r\n          ");
	DataTable redPhoto = get_article_list("photo", 0, 9, "status=0");

	foreach(DataRow dr in redPhoto.Rows)
	{

	templateBuilder.Append("\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("photo_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\" data-ignore=\"true\">\r\n              <img src=\"" + Utils.ObjectToStr(dr["img_url"]) + "\" alt=\"" + Utils.ObjectToStr(dr["title"]) + "\" />\r\n            </a>\r\n          </li>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </div>\r\n      <!--图片分享-->\r\n      \r\n      <!--资源下载-->\r\n      <div class=\"section\">\r\n        <h1>资源下载</h1>\r\n      </div>\r\n      <div>\r\n        <ul class=\"list listview\">\r\n          ");
	DataTable redDown = get_article_list("down", 0, 5, "is_red=1 and img_url<>''");

	foreach(DataRow dr in redDown.Rows)
	{

	templateBuilder.Append("\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("down_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\" data-ignore=\"true\">\r\n              <img src=\"" + Utils.ObjectToStr(dr["img_url"]) + "\" />\r\n              <h2>" + Utils.ObjectToStr(dr["title"]) + "</h2>\r\n              <div class=\"note\">\r\n                <p>" + Utils.ObjectToStr(dr["zhaiyao"]) + "</p>\r\n                <p><i class=\"hot\">" + Utils.ObjectToStr(dr["click"]) + "次</i><i class=\"date\">时间：");	templateBuilder.Append(Utils.ObjectToDateTime(Utils.ObjectToStr(dr["add_time"])).ToString("yyyy-MM-dd"));

	templateBuilder.Append("</i></p>\r\n              </div>\r\n            </a>\r\n          </li>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </div>\r\n      <!--资源下载-->\r\n      \r\n      <!--版权信息-->\r\n      ");

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


	templateBuilder.Append("\r\n    <!--/左侧导航-->\r\n      \r\n  </div>\r\n</div>\r\n</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
