<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.useraddress_edit" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="DTcms.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by DTcms Template Engine at 2015/5/13 14:24:48.
		本页面代码由DTcms模板引擎生成于 2015/5/13 14:24:48. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);

	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n<title>收货地址 - ");
	templateBuilder.Append(Utils.ObjectToStr(site.name));
	templateBuilder.Append("</title>\r\n<meta name=\"keywords\" content=\"");
	templateBuilder.Append(Utils.ObjectToStr(site.seo_keyword));
	templateBuilder.Append("\" />\r\n<meta name=\"description\" content=\"");
	templateBuilder.Append(Utils.ObjectToStr(site.seo_description));
	templateBuilder.Append("\" />\r\n<link href=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<link href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("css/validate.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<link href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/artdialog/ui-dialog.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery-1.11.2.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery.form.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/PCASClass.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/artdialog/dialog-plus-min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/js/common.js\"></");
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<!--Header-->\r\n");

	templateBuilder.Append("<div class=\"header\">\r\n  <div class=\"header-wrap\">\r\n    <div class=\"section\">\r\n      <div class=\"left-box\">\r\n        <a class=\"logo\" href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\">");
	templateBuilder.Append(Utils.ObjectToStr(site.name));
	templateBuilder.Append("</a>\r\n        <p class=\"nav\">\r\n          <a href=\"");
	templateBuilder.Append(linkurl("news"));

	templateBuilder.Append("\">资讯</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("goods"));

	templateBuilder.Append("\">商城</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("video"));

	templateBuilder.Append("\">视频</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("photo"));

	templateBuilder.Append("\">图片</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("down"));

	templateBuilder.Append("\">下载</a>\r\n        </p>\r\n      </div>\r\n      <div class=\"search\">\r\n        <input id=\"keywords\" name=\"keywords\" class=\"input\" type=\"text\" onkeydown=\"if(event.keyCode==13){SiteSearch('");
	templateBuilder.Append(linkurl("search"));

	templateBuilder.Append("', '#keywords');return false};\" placeholder=\"输入回车搜索\" x-webkit-speech=\"\" />\r\n        <input class=\"submit\" type=\"submit\" onclick=\"SiteSearch('");
	templateBuilder.Append(linkurl("search"));

	templateBuilder.Append("', '#keywords');\" value=\"搜索\" />\r\n      </div>\r\n      <div class=\"right-box\">\r\n      <script type=\"text/javascript\">\r\n			$.ajax({\r\n				type: \"POST\",\r\n				url: \"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_check_login\",\r\n				dataType: \"json\",\r\n				timeout: 20000,\r\n				success: function (data, textStatus) {\r\n					if (data.status == 1) {\r\n						$(\"#menu\").prepend('<li class=\"line\"><a href=\"");
	templateBuilder.Append(linkurl("usercenter","exit"));

	templateBuilder.Append("\">退出</a></li>');\r\n						$(\"#menu\").prepend('<li class=\"login\"><em></em><a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\">会员中心</a></li>');\r\n					} else {\r\n						$(\"#menu\").prepend('<li class=\"line\"><a href=\"");
	templateBuilder.Append(linkurl("register"));

	templateBuilder.Append("\">注册</a></li>');\r\n						$(\"#menu\").prepend('<li class=\"login\"><em></em><a href=\"");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("\">登录</a></li>');\r\n					}\r\n				}\r\n			});\r\n		</");
	templateBuilder.Append("script>\r\n        <ul id=\"menu\">\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("cart"));

	templateBuilder.Append("\">购物车<span id=\"shoppingCartCount\"><script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=view_cart_count\"></");
	templateBuilder.Append("script></span>件</a>\r\n          </li>\r\n          <li><a href=\"");
	templateBuilder.Append(linkurl("content","contact"));

	templateBuilder.Append("\">联系我们</a></li>\r\n        </ul>\r\n      </div>\r\n    </div>\r\n  </div>\r\n</div>");


	templateBuilder.Append("\r\n<!--/Header-->\r\n\r\n<div class=\"section clearfix\">\r\n  <div class=\"line30\"></div>\r\n\r\n  <div class=\"info-wrap\">\r\n    <!--左侧导航-->\r\n    ");

	templateBuilder.Append("    <div class=\"info-box\">\r\n      <div class=\"avatar-box\">\r\n        <a href=\"");
	templateBuilder.Append(linkurl("usercenter","avatar"));

	templateBuilder.Append("\" class=\"img-box\">\r\n          ");
	if (userModel.avatar!="")
	{

	templateBuilder.Append("\r\n            <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.avatar));
	templateBuilder.Append("\" />\r\n          ");
	}
	else
	{

	templateBuilder.Append("\r\n            <img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/images/user-avatar.png\" />\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </a>\r\n        <h3>\r\n        ");
	if (userModel.nick_name!="")
	{

	templateBuilder.Append("\r\n          ");
	templateBuilder.Append(Utils.ObjectToStr(userModel.nick_name));
	templateBuilder.Append("\r\n        ");
	}
	else
	{

	templateBuilder.Append("\r\n          ");
	templateBuilder.Append(Utils.ObjectToStr(userModel.user_name));
	templateBuilder.Append("\r\n        ");
	}	//end for if

	templateBuilder.Append("\r\n        </h3>\r\n        <p>余额：");
	templateBuilder.Append(Utils.ObjectToStr(userModel.amount));
	templateBuilder.Append(" 元</p>\r\n        <p>积分：");
	templateBuilder.Append(Utils.ObjectToStr(userModel.point));
	templateBuilder.Append(" 分</p>					\r\n      </div>\r\n      <ul class=\"side-nav\">\r\n        <li>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("userorder","list"));

	templateBuilder.Append("\">订单管理</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("useraddress"));

	templateBuilder.Append("\">收货地址</a>\r\n        </li>\r\n        <li>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("useramount","recharge"));

	templateBuilder.Append("\">账户余额</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("userpoint","convert"));

	templateBuilder.Append("\">我的积分</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("usermessage","system"));

	templateBuilder.Append("\">站内消息</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("usercenter","invite"));

	templateBuilder.Append("\">邀请好友</a>\r\n        </li>\r\n        <li>\r\n          \r\n          <a href=\"");
	templateBuilder.Append(linkurl("usercenter","proinfo"));

	templateBuilder.Append("\">个人资料</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("usercenter","avatar"));

	templateBuilder.Append("\">头像设置</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("usercenter","password"));

	templateBuilder.Append("\">修改密码</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("usercenter","exit"));

	templateBuilder.Append("\">退出登录</a>\r\n        </li>\r\n      </ul>\r\n    </div>");


	templateBuilder.Append("\r\n    <!--/左侧导航-->\r\n    \r\n    <!--右侧内容-->\r\n    <div class=\"home-box\">\r\n      <script type=\"text/javascript\">\r\n		$(function(){\r\n		  //初始化表单\r\n		  AjaxInitForm('#editForm', '#btnSubmit', 1, '#turl');\r\n		});\r\n	  </");
	templateBuilder.Append("script>\r\n      <div class=\"u-tab-head\">\r\n        <p>\r\n          <a class=\"selected\" href=\"");
	templateBuilder.Append(linkurl("useraddress"));

	templateBuilder.Append("\">收货地址</a>\r\n        </p>\r\n        <span>\r\n          <a class=\"add\" href=\"javascript:history.back();\">返回</a>\r\n        </span>\r\n      </div>\r\n      \r\n      ");
	if (action=="edit")
	{

	templateBuilder.Append("\r\n      <!--编辑地址-->\r\n      <script type=\"text/javascript\">\r\n	    $(function(){\r\n			//初始化地区\r\n            var mypcas = new PCAS(\"txtProvince,所属省份\", \"txtCity,所属城市\", \"txtArea,所属地区\");\r\n			var areaArr = (\"");
	templateBuilder.Append(Utils.ObjectToStr(model.area));
	templateBuilder.Append("\").split(\",\");\r\n			if (areaArr.length == 3) {\r\n              mypcas.SetValue(areaArr[0], areaArr[1], areaArr[2]);\r\n            }\r\n		});\r\n	  </");
	templateBuilder.Append("script>\r\n      <div class=\"u-tab-content\">\r\n        <div class=\"title-div\">\r\n          <strong>编辑地址</strong>\r\n        </div>\r\n        <form id=\"editForm\" name=\"editForm\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_address_edit&id=");
	templateBuilder.Append(Utils.ObjectToStr(model.id));
	templateBuilder.Append("\">\r\n          <div class=\"form-box\">\r\n            <dl>\r\n              <dt>收件人姓名：</dt>\r\n              <dd>\r\n                <input name=\"txtAcceptName\" id=\"txtAcceptName\" type=\"text\" class=\"input txt\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(model.accept_name));
	templateBuilder.Append("\" datatype=\"s1-50\"  nullmsg=\"请填写收件人用户名\" sucmsg=\" \" />\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt>所属地区：</dt>\r\n              <dd>\r\n                <select id=\"txtProvince\" name=\"txtProvince\" class=\"select\"></select>\r\n                <select id=\"txtCity\" name=\"txtCity\" class=\"select\"></select>\r\n                <select id=\"txtArea\" name=\"txtArea\" class=\"select\" datatype=\"*\" nullmsg=\"请选择所属地区\" sucmsg=\" \"></select>\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt>详细地址：</dt>\r\n              <dd>\r\n                <input name=\"txtAddress\" id=\"txtAddress\" type=\"text\" class=\"input wide\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(model.address));
	templateBuilder.Append("\" datatype=\"*1-255\" nullmsg=\"请填写详细地址\" sucmsg=\" \" />\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt>手机号码：</dt>\r\n              <dd>\r\n                <input name=\"txtMobile\" id=\"txtMobile\" type=\"text\" class=\"input txt\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(model.mobile));
	templateBuilder.Append("\" datatype=\"m\" nullmsg=\"请填写手机号码\" sucmsg=\" \"  />\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt>联系电话：</dt>\r\n              <dd>\r\n                <input name=\"txtTelphone\" id=\"txtTelphone\" type=\"text\" class=\"input txt\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(model.telphone));
	templateBuilder.Append("\" maxlength=\"30\" datatype=\"*0-20\" sucmsg=\" \"  />\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt>电子邮箱：</dt>\r\n              <dd>\r\n                <input name=\"txtEmail\" id=\"txtEmail\" type=\"text\" class=\"input txt\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(model.email));
	templateBuilder.Append("\" datatype=\"*0-20\" sucmsg=\" \"  />\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt>邮政编码：</dt>\r\n              <dd>\r\n                <input name=\"txtPostCode\" id=\"txtPostCode\" type=\"text\" class=\"input txt\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(model.post_code));
	templateBuilder.Append("\" datatype=\"n0-10\" sucmsg=\" \"  />\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt></dt>\r\n              <dd>\r\n                <input id=\"txtCode\" name=\"txtCode\" class=\"input small\" type=\"text\" datatype=\"*\" sucmsg=\" \" style=\"ime-mode:disabled;text-transform:uppercase;\">\r\n                <a id=\"verifyCode\" href=\"javascript:;\" onclick=\"ToggleCode(this, '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx');return false;\"><img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx\" width=\"80\" height=\"22\" style=\"vertical-align:middle;\" /> 看不清楚？</a>\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt></dt>\r\n              <dd><input name=\"btnSubmit\" id=\"btnSubmit\" type=\"submit\" class=\"btn btn-success\" value=\"确认提交\" /></dd>\r\n            </dl>\r\n          </div>\r\n        </form>\r\n        <!--编辑地址-->\r\n        \r\n      ");
	}
	else
	{

	templateBuilder.Append("\r\n      <!--添加新地址-->\r\n      <script type=\"text/javascript\">\r\n	    $(function(){\r\n			//初始化地区\r\n            var mypcas = new PCAS(\"txtProvince,所属省份\", \"txtCity,所属城市\", \"txtArea,所属地区\");\r\n		});\r\n	  </");
	templateBuilder.Append("script>\r\n      <div class=\"u-tab-content\">\r\n        <div class=\"title-div\">\r\n          <strong>添加新地址</strong>\r\n        </div>\r\n        <form id=\"editForm\" name=\"editForm\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_address_edit\">\r\n          <div class=\"form-box\">\r\n            <dl>\r\n              <dt>收件人姓名：</dt>\r\n              <dd>\r\n                <input name=\"txtAcceptName\" id=\"txtAcceptName\" type=\"text\" class=\"input txt\" datatype=\"s1-50\"  nullmsg=\"请填写收件人用户名\" sucmsg=\" \" />\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt>所属地区：</dt>\r\n              <dd>\r\n                <select id=\"txtProvince\" name=\"txtProvince\" class=\"select\"></select>\r\n                <select id=\"txtCity\" name=\"txtCity\" class=\"select\"></select>\r\n                <select id=\"txtArea\" name=\"txtArea\" class=\"select\" datatype=\"*\" nullmsg=\"请选择所属地区\" sucmsg=\" \"></select>\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt>详细地址：</dt>\r\n              <dd>\r\n                <input name=\"txtAddress\" id=\"txtAddress\" type=\"text\" class=\"input wide\" maxlength=\"255\" datatype=\"*0-255\" nullmsg=\"请填写详细地址\" sucmsg=\" \" />\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt>手机号码：</dt>\r\n              <dd>\r\n                <input name=\"txtMobile\" id=\"txtMobile\" type=\"text\" class=\"input txt\" maxlength=\"30\" datatype=\"m\" nullmsg=\"请填写手机号码\" sucmsg=\" \"  />\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt>联系电话：</dt>\r\n              <dd>\r\n                <input name=\"txtTelphone\" id=\"txtTelphone\" type=\"text\" class=\"input txt\" maxlength=\"30\" datatype=\"*0-20\" sucmsg=\" \"  />\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt>电子邮箱：</dt>\r\n              <dd>\r\n                <input name=\"txtEmail\" id=\"txtEmail\" type=\"text\" class=\"input txt\" maxlength=\"30\" datatype=\"*0-30\" sucmsg=\" \"  />\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt>邮政编码：</dt>\r\n              <dd>\r\n                <input name=\"txtPostCode\" id=\"txtPostCode\" type=\"text\" class=\"input txt\" maxlength=\"30\" datatype=\"n0-10\" sucmsg=\" \"  />\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt></dt>\r\n              <dd>\r\n                <input id=\"txtCode\" name=\"txtCode\" class=\"input small\" type=\"text\" datatype=\"*\" sucmsg=\" \" style=\"ime-mode:disabled;text-transform:uppercase;\">\r\n                <a id=\"verifyCode\" href=\"javascript:;\" onclick=\"ToggleCode(this, '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx');return false;\"><img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx\" width=\"80\" height=\"22\" style=\"vertical-align:middle;\" /> 看不清楚？</a>\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt></dt>\r\n              <dd><input name=\"btnSubmit\" id=\"btnSubmit\" type=\"submit\" class=\"btn btn-success\" value=\"确认提交\" /></dd>\r\n            </dl>\r\n          </div>\r\n        </form>\r\n        <!--添加新地址-->\r\n        ");
	}	//end for if

	templateBuilder.Append("\r\n        <input id=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(linkurl("useraddress"));

	templateBuilder.Append("\" />\r\n      </div>\r\n      \r\n    </div>\r\n    <!--/右侧内容-->\r\n  </div>\r\n</div>\r\n\r\n<!--Footer-->\r\n");

	templateBuilder.Append("<div class=\"footer clearfix\">\r\n  <div class=\"foot-nav\">\r\n    <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\">首 页</a>|\r\n    <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("content","about"));

	templateBuilder.Append("\">关于我们</a>|\r\n    <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("news"));

	templateBuilder.Append("\">新闻资讯</a>|\r\n    <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("goods"));

	templateBuilder.Append("\">购物商城</a>|\r\n    <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("video"));

	templateBuilder.Append("\">视频专区</a>|\r\n    <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("down"));

	templateBuilder.Append("\">资源下载</a>|\r\n    <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("photo"));

	templateBuilder.Append("\">图片分享</a>|\r\n    <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("feedback"));

	templateBuilder.Append("\">留言反馈</a>|\r\n    <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("link"));

	templateBuilder.Append("\">友情链接</a>|\r\n    <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("content","contact"));

	templateBuilder.Append("\">联系我们</a>\r\n  </div>\r\n  <div class=\"copyright\">\r\n    <p>版权所有 ");
	templateBuilder.Append(site.company.ToString());

	templateBuilder.Append(" 粤ICP备11064298号 DTcms版本号：");
	templateBuilder.Append(Utils.GetVersion().ToString());

	templateBuilder.Append(" 旗舰版</p>\r\n    <p>Copyright &copy; 2009-2015 dtcms.net Corporation,All Rights Reserved.</p>\r\n    <p><script src=\"http://s24.cnzz.com/stat.php?id=1996164&web_id=1996164&show=pic\" language=\"javascript\"></");
	templateBuilder.Append("script></p>\r\n  </div>\r\n</div>");


	templateBuilder.Append("\r\n<!--/Footer-->\r\n</body>\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
