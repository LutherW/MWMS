<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.shopping" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<!--HTML5 doctype-->\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\">\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=0\">\r\n<meta name=\"apple-mobile-web-app-capable\" content=\"yes\" />\r\n<title>订单结算－");
	templateBuilder.Append(Utils.ObjectToStr(site.name));
	templateBuilder.Append("</title>\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/css/icons.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/css/af.ui.base.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("css/validate.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
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
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/PCASClass.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/base.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/cart.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\n	$(document).ready(function(e) {\r\n		$(\"#main_footer a.basket\").addClass(\"pressed\");\r\n		//初始化收货地址\r\n		initUserAddress(\"#userAddress\");\r\n		//初始化表单\r\n		 AjaxInitForm('#order_form', '#btnSubmit', 0);\r\n    });\r\n</");
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<div id=\"afui\">\r\n  <div id=\"content\">\r\n\r\n	<div id=\"mainPanel\" class=\"panel\" data-footer=\"main_footer\" style=\"padding-bottom:0;\">\r\n      <header>\r\n        <a href=\"javascript:;\" onclick=\"history.back(-1);\" class=\"backButton\">返回</a>\r\n        <h1>订单结算</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n      \r\n      <!--订单结算-->\r\n      <form name=\"order_form\" id=\"order_form\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=order_save&site=");
	templateBuilder.Append(Utils.ObjectToStr(site.build_path));
	templateBuilder.Append("\">\r\n        <div class=\"wrap-box\">\r\n          <h2>收货地址</h2>\r\n          ");
	if (userModel!=null)
	{

	templateBuilder.Append("\r\n            <!--用户地址-->\r\n            ");
	DataTable addrList = get_user_addr_book_list(0, "user_id="+userModel.id);

	templateBuilder.Append(" <!--取得一个DataTable-->\r\n            <ul id=\"userAddress\" class=\"address-list\">\r\n              ");
	foreach(DataRow dr in addrList.Rows)
	{

	if (Utils.ObjectToStr(dr["is_default"])=="1")
	{

	templateBuilder.Append("\r\n                <li class=\"selected\">\r\n                ");
	}
	else
	{

	templateBuilder.Append("\r\n                <li>\r\n                ");
	}	//end for if

	templateBuilder.Append("\r\n                  <span>" + Utils.ObjectToStr(dr["area"]) + "" + Utils.ObjectToStr(dr["address"]) + " (" + Utils.ObjectToStr(dr["accept_name"]) + " 收)</span>\r\n                  <em>" + Utils.ObjectToStr(dr["mobile"]) + "</em>\r\n                  <input name=\"user_book_id\" type=\"radio\" value=\"" + Utils.ObjectToStr(dr["id"]) + "\" />\r\n                  <input name=\"user_accept_name\" type=\"hidden\" value=\"" + Utils.ObjectToStr(dr["accept_name"]) + "\" />\r\n                  <input name=\"user_area\" type=\"hidden\" value=\"" + Utils.ObjectToStr(dr["area"]) + "\" />\r\n                  <input name=\"user_address\" type=\"hidden\" value=\"" + Utils.ObjectToStr(dr["address"]) + "\" />\r\n                  <input name=\"user_mobile\" type=\"hidden\" value=\"" + Utils.ObjectToStr(dr["mobile"]) + "\" />\r\n                  <input name=\"user_telphone\" type=\"hidden\" value=\"" + Utils.ObjectToStr(dr["telphone"]) + "\" />\r\n                  <input name=\"user_email\" type=\"hidden\" value=\"" + Utils.ObjectToStr(dr["email"]) + "\" />\r\n                  <input name=\"user_post_code\" type=\"hidden\" value=\"" + Utils.ObjectToStr(dr["post_code"]) + "\" />\r\n                </li>\r\n              ");
	}	//end for if

	templateBuilder.Append("\r\n            </ul>\r\n            <!--/用户地址-->\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n          \r\n          <div>\r\n            <div>\r\n              <input name=\"book_id\" id=\"book_id\" type=\"hidden\" value=\"0\" />\r\n              <input name=\"accept_name\" id=\"accept_name\" type=\"text\" placeholder=\"收货人姓名\" datatype=\"s2-20\" sucmsg=\" \" />\r\n            </div>\r\n            <div>\r\n              <select id=\"province\" name=\"province\" class=\"select\"></select>\r\n              <select id=\"city\" name=\"city\" class=\"select\"></select>\r\n              <select id=\"area\" name=\"area\" class=\"select\" datatype=\"*\" sucmsg=\" \"></select>\r\n            </div>\r\n            <div>\r\n              <input name=\"address\" id=\"address\" type=\"text\" placeholder=\"详细地址，除所属省市外的详细地址\" datatype=\"*2-100\" sucmsg=\" \" />\r\n            </div>\r\n            <div>\r\n              <input name=\"mobile\" id=\"mobile\" type=\"text\" placeholder=\"手机号码，方便短信通知，必填\" datatype=\"m\" sucmsg=\" \" />\r\n            </div>\r\n            <div>\r\n              <input name=\"telphone\" id=\"telphone\" type=\"text\" placeholder=\"联系电话，非必填\" />\r\n            </div>\r\n            <div>\r\n              <input name=\"email\" id=\"email\" type=\"text\" placeholder=\"电子邮箱，方便邮件通知，非必填\" />\r\n            </div>\r\n            <div>\r\n              <input name=\"post_code\" id=\"post_code\" type=\"text\" placeholder=\"邮政编码，非必填\" />\r\n            </div>\r\n          </div>\r\n        </div>\r\n        \r\n        <div class=\"wrap-box\">\r\n          <h2>支付配送</h2>\r\n          <div>\r\n            <select name=\"payment_id\" onchange=\"paymentAmountTotal(this);\" datatype=\"*\" sucmsg=\" \">\r\n              <option value=\"\" fee=\"0\">付款方式</option>\r\n              ");
	DataTable paymentList = get_payment_list(0, "is_lock=0 and (is_mobile=0 or is_mobile=2)");

	templateBuilder.Append(" <!--取得一个DataTable-->\r\n              ");
	foreach(DataRow dr in paymentList.Rows)
	{

	decimal poundage_amount = get_payment_poundage_amount(Utils.StrToInt(Utils.ObjectToStr(dr["id"]), 0),goodsTotal.real_amount);

	templateBuilder.Append("\r\n              <option value=\"" + Utils.ObjectToStr(dr["id"]) + "\" fee=\"");
	templateBuilder.Append(Utils.ObjectToStr(poundage_amount));
	templateBuilder.Append("\">" + Utils.ObjectToStr(dr["title"]) + "(手续费");
	templateBuilder.Append(Utils.ObjectToStr(poundage_amount));
	templateBuilder.Append("元)</option>\r\n              ");
	}	//end for if

	templateBuilder.Append("\r\n            </select>\r\n            \r\n            <select name=\"express_id\" onchange=\"freightAmountTotal(this);\" datatype=\"*\" sucmsg=\" \">\r\n              <option value=\"\" fee=\"0\">配送方式</option>\r\n              ");
	DataTable expressList = get_express_list(0, "is_lock=0");

	templateBuilder.Append(" <!--取得一个DataTable-->\r\n              ");
	foreach(DataRow dr in expressList.Rows)
	{

	templateBuilder.Append("\r\n              <option value=\"" + Utils.ObjectToStr(dr["id"]) + "\" fee=\"" + Utils.ObjectToStr(dr["express_fee"]) + "\">" + Utils.ObjectToStr(dr["title"]) + "(运费" + Utils.ObjectToStr(dr["express_fee"]) + "元)</option>\r\n              ");
	}	//end for if

	templateBuilder.Append("\r\n            </select>\r\n            \r\n            <input name=\"taxAmout\" id=\"taxAmout\" type=\"hidden\" value=\"");
	templateBuilder.Append(get_order_taxamount(goodsTotal.real_amount).ToString());

	templateBuilder.Append("\" />\r\n            <select name=\"is_invoice\" id=\"is_invoice\" onchange=\"taxAmoutTotal(this);\">\r\n              <option value=\"0\" selected>不需要开具发票</option>\r\n              <option value=\"1\">需要开具发票</option>\r\n            </select>\r\n            <div id=\"invoiceBox\" style=\"display:none;\">\r\n              <input name=\"invoice_title\" id=\"invoice_title\" type=\"text\" placeholder=\"发票抬头(100字符以内)\" />\r\n            </div>\r\n            <textarea name=\"message\" rows=\"2\" placeholder=\"若您对订单有特殊的要求，可在此备注\"></textarea>\r\n          </div>\r\n        </div>\r\n        \r\n        <div>\r\n          <ul class=\"car-list inset\">\r\n            ");
	foreach(DTcms.Model.cart_items modelt in goodsList)
	{

	templateBuilder.Append("\r\n            <li>\r\n              <a href=\"");
	templateBuilder.Append(linkurl("goods_show",modelt.article_id));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"img-box\" style=\"margin-left:0;\">\r\n                <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.img_url));
	templateBuilder.Append("\" />\r\n              </a>\r\n              <h2>");
	templateBuilder.Append(Utils.ObjectToStr(modelt.title));
	templateBuilder.Append("</h2>\r\n              ");
	if (modelt.spec_text!="")
	{

	templateBuilder.Append("\r\n                <p class=\"stxt\">");
	templateBuilder.Append(Utils.ObjectToStr(modelt.spec_text));
	templateBuilder.Append("</p>\r\n              ");
	}	//end for if

	templateBuilder.Append("\r\n              <div class=\"note\" style=\"margin-left:80px;\">\r\n                <span>共");
	templateBuilder.Append(Utils.ObjectToStr(modelt.quantity));
	templateBuilder.Append("件</span>\r\n                <i class=\"price\">￥");
	templateBuilder.Append((modelt.user_price*modelt.quantity).ToString());

	templateBuilder.Append("</i>\r\n              </div>\r\n            </li>\r\n            ");
	}	//end for if

	if (goodsList.Count==0)
	{

	templateBuilder.Append("\r\n            <div class=\"nodata\">\r\n              <h1></h1>\r\n              <p>购物车暂无商品</p>\r\n            </div>\r\n            ");
	}	//end for if

	templateBuilder.Append("\r\n          </ul>\r\n        </div>\r\n        \r\n        <div class=\"wrap-box\">\r\n          <h2>应付总金额：￥<b id=\"totalAmount\" class=\"red\">");
	templateBuilder.Append(Utils.ObjectToStr(goodsTotal.real_amount));
	templateBuilder.Append("</b></h2>\r\n          <p>运费：￥<b id=\"expressFee\">0.00</b>元，手续费：￥<b id=\"paymentFee\">0.00</b>元，税费：￥<b id=\"taxesFee\">0.00</b>元</p>\r\n          <p>商品：￥<b id=\"goodsAmount\">");
	templateBuilder.Append(Utils.ObjectToStr(goodsTotal.real_amount));
	templateBuilder.Append("</b>元，");
	templateBuilder.Append(Utils.ObjectToStr(goodsTotal.total_quantity));
	templateBuilder.Append("件，总积分：");
	templateBuilder.Append(Utils.ObjectToStr(goodsTotal.total_point));
	templateBuilder.Append("分</p>\r\n        </div>\r\n        \r\n        <div>\r\n          ");
	if (goodsTotal.total_quantity>0)
	{

	templateBuilder.Append("\r\n            <input id=\"btnSubmit\" name=\"btnSubmit\" type=\"submit\" value=\"确认提交\" class=\"btn red full\" />\r\n          ");
	}
	else
	{

	templateBuilder.Append("\r\n            <input id=\"btnSubmit\" name=\"btnSubmit\" type=\"submit\" value=\"确认提交\" class=\"btn gray full\" disabled=\"disabled\" />\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </div>\r\n      </form>\r\n      <!--/订单结算-->\r\n      \r\n      <!--版权信息-->\r\n      ");

	templateBuilder.Append("      <div class=\"copyright\">\r\n        <p><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" data-ignore=\"true\">触屏版</a> | <a href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.weburl));
	templateBuilder.Append("?m2w\" data-ignore=\"true\">电脑版</a> | <a href=\"javascript:;\" onclick=\"$.ui.scrollToTop('mainPanel')\">返回顶部</a></p>\r\n        <address>版权所有 深圳市动力启航软件有限公司 版本号 V");
	templateBuilder.Append(Utils.GetVersion().ToString());

	templateBuilder.Append("</address></p>\r\n      </div>");


	templateBuilder.Append("\r\n      <!--/版权信息-->\r\n	</div>\r\n  \r\n    <!--底部导航-->\r\n    ");

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
