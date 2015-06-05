<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.payment" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<!--HTML5 doctype-->\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\">\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=0\">\r\n<meta name=\"apple-mobile-web-app-capable\" content=\"yes\" />\r\n<title>支付中心－");
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
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<div id=\"afui\">\r\n  <div id=\"content\">\r\n\r\n	<div id=\"mainPanel\" class=\"panel\" data-footer=\"main_footer\">\r\n      <header>\r\n        <a href=\"javascript:;\" onclick=\"history.back(-1);\" class=\"backButton\">返回</a>\r\n        <h1>在线支付</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n      ");
	if (action=="confirm")
	{

	templateBuilder.Append("\r\n      <!--提交支付-->\r\n      <form id=\"pay_form\" name=\"pay_form\" method=\"post\" action=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("api/payment/");
	templateBuilder.Append(Utils.ObjectToStr(payModel.api_path));
	templateBuilder.Append("/index.aspx\" target=\"_blank\">\r\n        <input id=\"pay_order_no\" name=\"pay_order_no\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(order_no));
	templateBuilder.Append("\" />\r\n        <input id=\"pay_order_amount\" name=\"pay_order_amount\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(order_amount));
	templateBuilder.Append("\" />\r\n        <input id=\"pay_user_name\" name=\"pay_user_name\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.user_name));
	templateBuilder.Append("\" />\r\n        \r\n        ");
	if (order_type=="recharge")
	{

	templateBuilder.Append("\r\n        <!--充值订单-->\r\n        <div class=\"wrap-box\">\r\n          <h2>支付信息</h2>\r\n          <dl>\r\n            <dt>订单号</dt>\r\n            <dd>");
	templateBuilder.Append(Utils.ObjectToStr(order_no));
	templateBuilder.Append("</dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>充值金额</dt>\r\n            <dd>￥");
	templateBuilder.Append(Utils.ObjectToStr(order_amount));
	templateBuilder.Append("</dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>支付方式</dt>\r\n            <dd>");
	templateBuilder.Append(Utils.ObjectToStr(payModel.title));
	templateBuilder.Append("</dd>\r\n          </dl>\r\n        </div>\r\n        <input id=\"pay_subject\" name=\"pay_subject\" type=\"hidden\" value=\"账户充值\" />\r\n        \r\n        <div style=\"padding:0 0 15px 0;\">\r\n          <input id=\"btnSubmit\" name=\"btnSubmit\" type=\"submit\" value=\"确认付款\" class=\"btn orange full\" />\r\n        </div>\r\n      \r\n        ");
	}
	else if (order_type=="buygoods")
	{

	templateBuilder.Append("\r\n        <div class=\"wrap-box\">\r\n          <h2>支付信息</h2>\r\n          <dl>\r\n            <dt>订单号</dt>\r\n            <dd>");
	templateBuilder.Append(Utils.ObjectToStr(order_no));
	templateBuilder.Append("</dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>收货人姓名</dt>\r\n            <dd>");
	templateBuilder.Append(Utils.ObjectToStr(orderModel.accept_name));
	templateBuilder.Append("</dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>送货地址</dt>\r\n            <dd>");
	templateBuilder.Append(Utils.ObjectToStr(orderModel.address));
	templateBuilder.Append("</dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>手机号码</dt>\r\n            <dd>");
	templateBuilder.Append(Utils.ObjectToStr(orderModel.mobile));
	templateBuilder.Append("</dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>固定电话</dt>\r\n            <dd>");
	templateBuilder.Append(Utils.ObjectToStr(orderModel.telphone));
	templateBuilder.Append("</dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>备注留言</dt>\r\n            <dd>");
	templateBuilder.Append(Utils.ObjectToStr(orderModel.message));
	templateBuilder.Append("</dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>支付金额</dt>\r\n            <dd>￥");
	templateBuilder.Append(Utils.ObjectToStr(order_amount));
	templateBuilder.Append("</dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>支付方式</dt>\r\n            <dd>");
	templateBuilder.Append(Utils.ObjectToStr(payModel.title));
	templateBuilder.Append("</dd>\r\n          </dl>\r\n        </div>\r\n        <input id=\"pay_subject\" name=\"pay_subject\" type=\"hidden\" value=\"购买商品\" />\r\n        \r\n        <div style=\"padding:0 0 15px 0;\">\r\n          <input id=\"btnSubmit\" name=\"btnSubmit\" type=\"submit\" value=\"确认付款\" class=\"btn orange full\" />\r\n        </div>\r\n        \r\n        ");
	}	//end for if

	templateBuilder.Append("\r\n      </form>\r\n      \r\n      <!--/提交支付-->\r\n      ");
	}	//end for if

	if (action=="succeed")
	{

	templateBuilder.Append("\r\n      <!--支付成功-->\r\n      <div class=\"wrap-box\">\r\n        <h2>支付成功</h2>\r\n        <div class=\"tip\">\r\n          <span class=\"icon check\"></span>\r\n          <p>恭喜您，您的支付已经成功！</p>\r\n          <p>您可以点击这里进入<a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\" data-ignore=\"true\">会员中心</a>查看订单状态！</p>\r\n          <p>如有其它问题，请立即与我们客服人员联系。</p>\r\n        </div>\r\n      </div>\r\n      <!--/支付成功-->\r\n      ");
	}	//end for if

	if (action=="error")
	{

	templateBuilder.Append("\r\n      <!--支付出错-->\r\n      <div class=\"wrap-box\">\r\n        <h2>支付失败</h2>\r\n        <div class=\"tip\">\r\n          <span class=\"icon close\"></span>\r\n          <p>支付过程中发生意处错误！</p>\r\n          <p>您可以点击这里进入<a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\" data-ignore=\"true\">会员中心</a>查看订单状态！</p>\r\n          <p>如您确实已经支付，请与我们客服人员联系。</p>\r\n        </div>\r\n      </div>\r\n      <!--/支付出错-->\r\n      ");
	}	//end for if

	if (action=="login")
	{

	templateBuilder.Append("\r\n      <!--用户未登录-->\r\n      <div class=\"wrap-box\">\r\n        <h2>会员登录</h2>\r\n        <div class=\"tip\">\r\n          <span class=\"icon info\"></span>\r\n          <p>您尚未登录或已经超时啦！</p>\r\n          <p>已是会员用户，请<a href=\"");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("\" data-ignore=\"true\">点击这里登录</a>。</p>\r\n          <p>尚未注册会员，请<a href=\"");
	templateBuilder.Append(linkurl("register"));

	templateBuilder.Append("\" data-ignore=\"true\">点击这里注册</a>。</p>\r\n        </div>\r\n      </div>\r\n      <!--/用户未登录-->\r\n      ");
	}	//end for if

	if (action=="recharge")
	{

	templateBuilder.Append("\r\n      <!--用户余额不足-->\r\n      <div class=\"wrap-box\">\r\n        <h2>余额不足</h2>\r\n        <div class=\"tip\">\r\n          <span class=\"icon warning\"></span>\r\n          <p>对不起，您的余额不足本次支付！</p>\r\n          <p>如余额不足，请<a href=\"");
	templateBuilder.Append(linkurl("useramount","recharge"));

	templateBuilder.Append("\" data-ignore=\"true\">点击这里充值</a>后进行支付！</p>\r\n          <p>如果有任何问题，请与我们客服取得联系。</p>\r\n        </div>\r\n      </div>\r\n      <!--/用户余额不足-->\r\n      ");
	}	//end for if

	templateBuilder.Append("\r\n      \r\n      <!--版权信息-->\r\n      ");

	templateBuilder.Append("      <div class=\"copyright\">\r\n        <p><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" data-ignore=\"true\">触屏版</a> | <a href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.weburl));
	templateBuilder.Append("?m2w\" data-ignore=\"true\">电脑版</a> | <a href=\"javascript:;\" onclick=\"$.ui.scrollToTop('mainPanel')\">返回顶部</a></p>\r\n        <address>版权所有 深圳市动力启航软件有限公司 版本号 V");
	templateBuilder.Append(Utils.GetVersion().ToString());

	templateBuilder.Append("</address></p>\r\n      </div>");


	templateBuilder.Append("\r\n      <!--/版权信息-->\r\n    \r\n	</div>\r\n  \r\n    \r\n    <!--底部导航-->\r\n    ");

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
