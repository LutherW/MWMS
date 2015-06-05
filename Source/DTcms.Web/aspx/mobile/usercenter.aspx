<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.usercenter" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<!--HTML5 doctype-->\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\">\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=0\">\r\n<meta name=\"apple-mobile-web-app-capable\" content=\"yes\" />\r\n<title>会员中心 - ");
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
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\n	$(document).ready(function(e) {\r\n		$(\"#main_footer a.user\").addClass(\"pressed\");\r\n    });\r\n</");
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<div id=\"afui\">\r\n  <div id=\"content\">\r\n\r\n	<div id=\"mainPanel\" class=\"panel\" data-footer=\"main_footer\">\r\n      ");
	if (action=="index")
	{

	templateBuilder.Append("\r\n      <!--会员中心-->\r\n      <header>\r\n        <a href=\"javascript:;\" onclick=\"history.back(-1);\" class=\"backButton\">返回</a>\r\n        <h1>会员中心</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n      \r\n      <div class=\"head-box\">\r\n        <div class=\"avatar-box\">\r\n          ");
	if (userModel.avatar!="")
	{

	templateBuilder.Append("\r\n          <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.avatar));
	templateBuilder.Append("\" />\r\n          ");
	}
	else
	{

	templateBuilder.Append("\r\n          <img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/user_avatar.png\" alt=\"求真像\" />\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n          <h3>");
	templateBuilder.Append(Utils.ObjectToStr(userModel.user_name));
	templateBuilder.Append("</h3>\r\n          <p><span>会员等级：");
	templateBuilder.Append(Utils.ObjectToStr(groupModel.title));
	templateBuilder.Append("</span></p>\r\n          <p><span>个人成长值：");
	templateBuilder.Append(Utils.ObjectToStr(userModel.exp));
	templateBuilder.Append("点</span></p>\r\n        </div>\r\n        <div class=\"tip-box\">\r\n          <dl>\r\n            <dt>余额</dt>\r\n            <dd>￥");
	templateBuilder.Append(Utils.ObjectToStr(userModel.amount));
	templateBuilder.Append("</dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>积分</dt>\r\n            <dd>");
	templateBuilder.Append(Utils.ObjectToStr(userModel.point));
	templateBuilder.Append("</dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>订单</dt>\r\n            <dd>");
	templateBuilder.Append(get_user_order_count("status<3 and user_id="+userModel.id).ToString());

	templateBuilder.Append("</dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>短消息</dt>\r\n            <dd>");
	templateBuilder.Append(get_user_message_count("type<3 and is_read=0 and accept_user_name='"+userModel.user_name+"'").ToString());

	templateBuilder.Append("</dd>\r\n          </dl>\r\n        </div>\r\n      </div>\r\n      \r\n      <div>\r\n        <ul class=\"list inset listview\">\r\n          <li><a href=\"");
	templateBuilder.Append(linkurl("userorder","list"));

	templateBuilder.Append("\" data-ignore=\"true\">交易订单</a></li>\r\n          <li><a href=\"");
	templateBuilder.Append(linkurl("userorder","close"));

	templateBuilder.Append("\" data-ignore=\"true\">已关闭订单</a></li>\r\n        </ul>\r\n        <ul class=\"list inset listview\">\r\n          <li><a href=\"");
	templateBuilder.Append(linkurl("useramount","recharge"));

	templateBuilder.Append("\" data-ignore=\"true\">账户余额</a></li>\r\n          <li><a href=\"");
	templateBuilder.Append(linkurl("userpoint","convert"));

	templateBuilder.Append("\" data-ignore=\"true\">我的积分</a></li>\r\n          <li><a href=\"");
	templateBuilder.Append(linkurl("usermessage","system"));

	templateBuilder.Append("\" data-ignore=\"true\">站内短信</a></li>\r\n        </ul>\r\n        <ul class=\"list inset listview\">\r\n          <li><a href=\"");
	templateBuilder.Append(linkurl("usercenter","proinfo"));

	templateBuilder.Append("\" data-ignore=\"true\">个人资料</a></li>\r\n          <li><a href=\"");
	templateBuilder.Append(linkurl("usercenter","password"));

	templateBuilder.Append("\" data-ignore=\"true\">修改密码</a></li>\r\n          <li><a href=\"");
	templateBuilder.Append(linkurl("usercenter","exit"));

	templateBuilder.Append("\" data-ignore=\"true\">退出登录</a></li>\r\n        </ul>\r\n      </div>\r\n      <!--/会员中心-->\r\n      \r\n      ");
	}
	else if (action=="password")
	{

	templateBuilder.Append("\r\n      <!--修改密码-->\r\n      <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
	templateBuilder.Append("script>\r\n	  <script type=\"text/javascript\">\r\n        $(function(){\r\n          //初始化表单\r\n          AjaxInitForm('#pwd_form', '#btnSubmit', 1);\r\n        });\r\n      </");
	templateBuilder.Append("script>\r\n      <header>\r\n        <a onclick=\"history.back(-1);\" class=\"backButton\">返回</a>\r\n        <h1>修改密码</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n      <form name=\"pwd_form\" id=\"pwd_form\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_password_edit\">\r\n        <div class=\"form-box\">\r\n          <dl>\r\n            <dt>用户名</dt>\r\n            <dd>");
	templateBuilder.Append(Utils.ObjectToStr(userModel.user_name));
	templateBuilder.Append("</dd>\r\n          </dl>\r\n          <div><input name=\"txtOldPassword\" id=\"txtOldPassword\" type=\"password\" placeholder=\"请输入旧密码\" datatype=\"*6-20\" nullmsg=\"请输入旧密码\" errormsg=\"密码范围在6-20位之间\" sucmsg=\" \" /></div>\r\n          <div><input name=\"txtPassword\" id=\"txtPassword\" type=\"password\" placeholder=\"请输入新密码\" datatype=\"*6-20\" nullmsg=\"请输入密码\" errormsg=\"密码范围在6-20位之间\" sucmsg=\" \" /></div>\r\n          <div><input name=\"txtPassword1\" id=\"txtPassword1\" type=\"password\" placeholder=\"请再次输入新密码\" datatype=\"*\" recheck=\"txtPassword\" nullmsg=\"请再输入一次密码\" errormsg=\"两次输入的密码不一致\" sucmsg=\" \" /></div>\r\n          <div><input id=\"btnSubmit\" name=\"btnSubmit\" type=\"submit\" value=\"确认修改\" class=\"btn orange full\" /></div>\r\n        </div>\r\n      </form>\r\n      <!--/修改密码-->\r\n      \r\n      ");
	}
	else if (action=="proinfo")
	{

	templateBuilder.Append("\r\n      <!--修改资料-->\r\n      <link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mobiscroll.custom-2.6.2.min.css\" />\r\n	  <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mobiscroll.custom-2.6.2.min.js\"></");
	templateBuilder.Append("script>\r\n      <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
	templateBuilder.Append("script>\r\n      <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/PCASClass.js\"></");
	templateBuilder.Append("script>\r\n	  <script type=\"text/javascript\">\r\n        $(document).ready(function() {\r\n          //初始化表单\r\n          AjaxInitForm('#info_form', '#btnSubmit', 1);\r\n		  //初始化地区\r\n		  var mypcas = new PCAS(\"txtProvince,所属省份\", \"txtCity,所属城市\", \"txtArea,所属地区\");\r\n		  var areaArr = (\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.area));
	templateBuilder.Append("\").split(\",\");\r\n		  if (areaArr.length == 3) {\r\n			mypcas.SetValue(areaArr[0], areaArr[1], areaArr[2]);\r\n		  }\r\n		  //初始化日期选择控件\r\n		  var opt = {\r\n			preset: 'date', //日期\r\n			display: 'modal', //显示方式 \r\n			mode: 'scroller', //日期选择模式\r\n			dateFormat: 'yy-mm-dd', // 日期格式\r\n			setText: '确定', //确认按钮名称\r\n			cancelText: '取消',//取消按钮名籍我\r\n			dateOrder: 'yymmdd', //面板中日期排列格式\r\n			dayText: '日', monthText: '月', yearText: '年', //面板中年月日文字\r\n			endYear: new Date().getFullYear() //结束年份\r\n		  };\r\n		  $(\"#txtBirthday\").mobiscroll(opt).date(opt);\r\n        });\r\n	  </");
	templateBuilder.Append("script>\r\n      <header>\r\n        <a onclick=\"history.back(-1);\" class=\"backButton\">返回</a>\r\n        <h1>个人资料</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n      <form id=\"info_form\" name=\"info_form\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_info_edit\">\r\n        <div class=\"form-box\">\r\n          <dl>\r\n            <dt>用户名</dt>\r\n            <dd>");
	templateBuilder.Append(Utils.ObjectToStr(userModel.user_name));
	templateBuilder.Append("</dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>邮箱</dt>\r\n            <dd><input name=\"txtEmail\" id=\"txtEmail\" type=\"text\" maxlength=\"50\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.email));
	templateBuilder.Append("\" readonly datatype=\"e\" sucmsg=\" \" /></dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>昵称</dt>\r\n            <dd><input name=\"txtNickName\" id=\"txtNickName\" type=\"text\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.nick_name));
	templateBuilder.Append("\" datatype=\"*\" sucmsg=\" \" /></dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>性别</dt>\r\n            <dd>\r\n              <select name=\"rblSex\">\r\n                ");
	if (userModel.sex=="保密")
	{

	templateBuilder.Append("\r\n                <option value=\"保密\" selected>保密</option>\r\n                ");
	}
	else
	{

	templateBuilder.Append("\r\n                <option value=\"保密\">保密</option>\r\n                ");
	}	//end for if

	if (userModel.sex=="男")
	{

	templateBuilder.Append("\r\n                <option value=\"男\" selected>男</option>\r\n                ");
	}
	else
	{

	templateBuilder.Append("\r\n                <option value=\"男\">男</option>\r\n                ");
	}	//end for if

	if (userModel.sex=="女")
	{

	templateBuilder.Append("\r\n                <option value=\"女\" selected>女</option>\r\n                ");
	}
	else
	{

	templateBuilder.Append("\r\n                <option value=\"女\">女</option>\r\n                ");
	}	//end for if

	templateBuilder.Append("\r\n              </select>\r\n            </dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>生日</dt>\r\n            <dd>\r\n              ");
	if (userModel.birthday==null)
	{

	templateBuilder.Append("\r\n              <input name=\"txtBirthday\" id=\"txtBirthday\" type=\"text\" />\r\n              ");
	}
	else
	{

	templateBuilder.Append("\r\n              <input name=\"txtBirthday\" id=\"txtBirthday\" type=\"text\" value=\"");	templateBuilder.Append(Utils.ObjectToDateTime(userModel.birthday).ToString("yyyy-M-d"));

	templateBuilder.Append("\" />\r\n              ");
	}	//end for if

	templateBuilder.Append("\r\n            </dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>手机号码：</dt>\r\n            <dd><input name=\"txtMobile\" id=\"txtMobile\" type=\"text\" maxlength=\"20\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.mobile));
	templateBuilder.Append("\" datatype=\"*\" sucmsg=\" \" /></dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>联系电话：</dt>\r\n            <dd><input name=\"txtTelphone\" id=\"txtTelphone\" type=\"text\" maxlength=\"50\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.telphone));
	templateBuilder.Append("\" /></dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>在线QQ：</dt>\r\n            <dd><input name=\"txtQQ\" id=\"txtQQ\" type=\"text\" maxlength=\"20\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.qq));
	templateBuilder.Append("\" /></dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>所属地区：</dt>\r\n            <dd>\r\n              <select id=\"txtProvince\" name=\"txtProvince\" class=\"select\"></select>\r\n            </dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>&nbsp;</dt>\r\n            <dd>\r\n              <select id=\"txtCity\" name=\"txtCity\" class=\"select\"></select>\r\n            </dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>&nbsp;</dt>\r\n            <dd>\r\n              <select id=\"txtArea\" name=\"txtArea\" class=\"select\" datatype=\"*\" sucmsg=\" \"></select>\r\n            </dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>详细地址：</dt>\r\n            <dd><input name=\"txtAddress\" id=\"txtAddress\" type=\"text\" maxlength=\"250\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.address));
	templateBuilder.Append("\" /></dd>\r\n          </dl>\r\n        </div>\r\n        \r\n        <div>\r\n          <input id=\"btnSubmit\" name=\"btnSubmit\" type=\"submit\" value=\"确认修改\" class=\"btn orange full\" />\r\n        </div>\r\n      </form>\r\n      <!--/修改资料-->\r\n      ");
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
