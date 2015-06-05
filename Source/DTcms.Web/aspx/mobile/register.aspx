<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.register" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<!--HTML5 doctype-->\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\">\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=0\">\r\n<meta name=\"apple-mobile-web-app-capable\" content=\"yes\" />\r\n<title>会员注册 - ");
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
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<div id=\"afui\">\r\n  <div id=\"content\">\r\n\r\n	<div id=\"mainPanel\" class=\"panel\" data-footer=\"main_footer\">\r\n      <header>\r\n        <a href=\"javascript:;\" onclick=\"history.back(-1);\" class=\"backButton\">返回</a>\r\n        <h1>会员注册</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n      ");
	if (action=="")
	{

	templateBuilder.Append("\r\n      <!--用户注册-->\r\n      <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
	templateBuilder.Append("script>\r\n      <script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/register_validate.js\"></");
	templateBuilder.Append("script>\r\n      <div class=\"form-box\">\r\n        <form id=\"regform\" name=\"regform\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_register\">\r\n          ");
	if (uconfig.regstatus==4)
	{

	templateBuilder.Append("\r\n          <!--开启邀请注册-->\r\n            <div>\r\n              <input id=\"txtCode\" name=\"txtCode\" placeholder=\"请输入邀请码\" type=\"text\" datatype=\"*\" sucmsg=\" \" />\r\n            </div>\r\n          <!--/开启邀请注册-->\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n          <div>\r\n            <input id=\"txtUserName\" name=\"txtUserName\" type=\"text\" placeholder=\"用户名\" datatype=\"s3-50\" nullmsg=\"请输入用户名\" sucmsg=\" \" ajaxurl=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=validate_username\" />\r\n          </div>\r\n          <div>\r\n            <input id=\"txtPassword\" name=\"txtPassword\" type=\"password\" placeholder=\"登录密码\" datatype=\"*6-20\" nullmsg=\"请输入密码\" errormsg=\"密码范围在6-20位之间\" sucmsg=\" \" />\r\n          </div>\r\n          <div>\r\n            <input id=\"txtPassword1\" name=\"txtPassword1\" type=\"password\" placeholder=\"再次输入密码\" datatype=\"*\" recheck=\"txtPassword\" nullmsg=\"请再次输入密码\" errormsg=\"两次输入的密码不一致\" sucmsg=\" \" />\r\n          </div>\r\n          \r\n          ");
	if (uconfig.regstatus==1||uconfig.regstatus==2)
	{

	templateBuilder.Append("\r\n          <!--开放注册及手机注册-->\r\n            <div>\r\n              <input id=\"txtMobile\" name=\"txtMobile\" type=\"text\" placeholder=\"手机号码\" datatype=\"m\" nullmsg=\"请输入手机号码\" sucmsg=\" \" />\r\n            </div>\r\n          <!--/开放注册及手机注册-->\r\n          ");
	}	//end for if

	if (uconfig.regstatus==1||uconfig.regstatus==3||uconfig.regstatus==4)
	{

	templateBuilder.Append("\r\n          <!--开放注册及邮箱邀请注册-->\r\n          <div>\r\n            <input id=\"txtEmail\" name=\"txtEmail\" type=\"text\" placeholder=\"电子邮箱\" datatype=\"e\" nullmsg=\"请输入邮箱地址\" sucmsg=\" \" />\r\n          </div>\r\n          <!--/开放注册及邮箱邀请注册-->\r\n          ");
	}	//end for if

	if (uconfig.regstatus==2)
	{

	templateBuilder.Append("\r\n          <!--开启手机注册-->\r\n            <div>\r\n              <input id=\"txtCode\" name=\"txtCode\" class=\"input code\" type=\"text\" placeholder=\"请输入手机收到的确认码\" datatype=\"s4-20\" />\r\n              <a class=\"send\" href=\"javascript:;\" onclick=\"sendSMS(this,'#txtMobile','");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_verify_smscode&site=");
	templateBuilder.Append(Utils.ObjectToStr(site.build_path));
	templateBuilder.Append("');\">发送确认码</a>\r\n            </div>\r\n          <!--/开启手机注册-->\r\n          ");
	}	//end for if

	if (uconfig.regstatus==1)
	{

	templateBuilder.Append("\r\n          <!--开放注册-->\r\n            <div>\r\n              <input id=\"txtCode\" name=\"txtCode\" type=\"text\" placeholder=\"验证码\" class=\"input code\"  datatype=\"s4-20\" nullmsg=\"请输入验证码\" sucmsg=\" \">\r\n              <a id=\"verifyCode\" href=\"javascript:;\" onclick=\"ToggleCode(this, '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx');return false;\">\r\n                <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx\" width=\"80\" height=\"24\" style=\"display:inline-block;vertical-align:middle;font-size:12px;\" /> 看不清楚？\r\n              </a>\r\n            </div>\r\n          <!--开放注册-->\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n          \r\n          <div>\r\n            <input id=\"btnSubmit\" name=\"btnSubmit\" type=\"submit\" value=\"注册\" class=\"btn orange full\">\r\n          </div>\r\n        </form>\r\n      </div>\r\n      <!--/用户注册-->\r\n      ");
	}	//end for if

	if (action=="close")
	{

	templateBuilder.Append("\r\n      <!--关闭会员注册-->\r\n      <div class=\"wrap-box\">\r\n        <h2>系统暂停注册会员</h2>\r\n        <div class=\"tip\">\r\n          <span class=\"icon info\"></span>\r\n          <p>如对您造成不便，我们深感遗憾！</p>\r\n          <p>如需了解开放时间，请联系本站客服或管理员。</p>\r\n          <p>您可以点击这里返回 <a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" data-ignore=\"true\">网站首页</a></p>\r\n        </div>\r\n      </div>\r\n      <!--/关闭会员注册-->\r\n      ");
	}	//end for if

	if (action=="sendmail")
	{

	templateBuilder.Append("\r\n      <!--发送邮箱验证-->\r\n      <div class=\"wrap-box\">\r\n        <h2>发送邮箱验证</h2>\r\n        <div class=\"tip\">\r\n          <span class=\"icon check\"></span>\r\n          <p>注册成功，您的账户目前处于未验证状态！</p>\r\n          <p>请尽快登录您的注册邮箱激活该会员账户。</p>\r\n          <p>系统已为您发送了验证邮件，如长时间未收到，请点击这里<a href=\"javascript:;\" onclick=\"sendEmail('");
	templateBuilder.Append(Utils.ObjectToStr(username));
	templateBuilder.Append("', '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_verify_email&site=");
	templateBuilder.Append(Utils.ObjectToStr(site.build_path));
	templateBuilder.Append("');\">重新发送邮件</a>！</p>\r\n          <p>温馨提示：邮件验证有效期为\r\n          ");
	if (uconfig.regemailexpired>0)
	{

	templateBuilder.Append("\r\n          ");
	templateBuilder.Append(Utils.ObjectToStr(uconfig.regemailexpired));
	templateBuilder.Append("天\r\n          ");
	}
	else
	{

	templateBuilder.Append("\r\n          无限制\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n          </p>\r\n        </div>\r\n      </div>\r\n      <!--/发送邮箱验证-->\r\n      ");
	}	//end for if

	if (action=="checkmail")
	{

	templateBuilder.Append("\r\n      <!--邮箱验证成功-->\r\n      <div class=\"wrap-box\">\r\n        <h2>邮箱验证成功</h2>\r\n        <div class=\"tip\">\r\n          <span class=\"icon check\"></span>\r\n          <p>恭喜您");
	templateBuilder.Append(Utils.ObjectToStr(username));
	templateBuilder.Append("，已通过邮件激活会员账户</p>\r\n          <p>您的会员账户已经激活啦。</p>\r\n          <p>点击这里返回 <a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" data-ignore=\"true\">首页</a> 或 <a href=\"");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("\" data-ignore=\"true\">会员中心</a> </p>\r\n        </div>\r\n      </div>\r\n      <!--/邮箱验证成功-->\r\n      ");
	}	//end for if

	if (action=="checkerror")
	{

	templateBuilder.Append("\r\n      <!--注册验证失败-->\r\n      <div class=\"wrap-box\">\r\n        <h2>注册验证失败</h2>\r\n        <div class=\"tip\">\r\n          <span class=\"icon error\"></span>\r\n          <p>用户不存在或验证已过期！</p>\r\n          <p>用户名不存在或者验证码已经过期。</p>\r\n          <p>您可以点击这里 <a href=\"");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("\" data-ignore=\"true\">登录</a> </p>\r\n        </div>\r\n      </div>\r\n      <!--/注册验证失败-->\r\n      ");
	}	//end for if

	if (action=="verify")
	{

	templateBuilder.Append("\r\n      <!--人工审核-->\r\n      <div class=\"wrap-box\">\r\n        <h2>等待人工审核通过</h2>\r\n        <div class=\"tip\">\r\n          <span class=\"icon info\"></span>\r\n          <p>会员账户还没有审核通过呢，再等等吧！</p>\r\n          <p>本站开启人工审核，如对您造成不便敬请原谅。</p>\r\n          <p>您可以点击这里 <a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" data-ignore=\"true\">返回网站首页</a> </p>\r\n        </div>\r\n      </div>\r\n      <!--/人工审核-->\r\n      ");
	}	//end for if

	if (action=="succeed")
	{

	templateBuilder.Append("\r\n      <!--注册成功-->\r\n      <div class=\"wrap-box\">\r\n        <h2>恭喜您，注册成功</h2>\r\n        <div class=\"tip\">\r\n          <span class=\"icon check\"></span>\r\n          <p>恭喜您");
	templateBuilder.Append(Utils.ObjectToStr(username));
	templateBuilder.Append("成为本站会员！</p>\r\n          <p>从现在起，你可以享受更多的会员服务。</p>\r\n          <p>点击这里返回 <a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" data-ignore=\"true\">首页</a> 或 <a href=\"");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("\" data-ignore=\"true\">登录</a> 会员中心吧！</p>\r\n        </div>\r\n      </div>\r\n      <!--/注册成功-->\r\n      ");
	}	//end for if

	templateBuilder.Append("\r\n      \r\n      <!--版权信息-->\r\n      ");

	templateBuilder.Append("      <div class=\"copyright\">\r\n        <p><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" data-ignore=\"true\">触屏版</a> | <a href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.weburl));
	templateBuilder.Append("?m2w\" data-ignore=\"true\">电脑版</a> | <a href=\"javascript:;\" onclick=\"$.ui.scrollToTop('mainPanel')\">返回顶部</a></p>\r\n        <address>版权所有 深圳市动力启航软件有限公司 版本号 V");
	templateBuilder.Append(Utils.GetVersion().ToString());

	templateBuilder.Append("</address></p>\r\n      </div>");


	templateBuilder.Append("\r\n      <!--/版权信息-->\r\n    \r\n	</div>\r\n    \r\n    <!--底部导航-->\r\n    ");

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
