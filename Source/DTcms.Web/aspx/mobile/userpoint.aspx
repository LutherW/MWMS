<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.userpoint" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<!--HTML5 doctype-->\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\">\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=0\">\r\n<meta name=\"apple-mobile-web-app-capable\" content=\"yes\" />\r\n<title>我的积分 - ");
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
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<div id=\"afui\">\r\n  <div id=\"content\">\r\n\r\n	<div id=\"mainPanel\" class=\"panel\">\r\n    ");
	if (action=="convert")
	{

	templateBuilder.Append("\r\n    <!--积分兑换-->\r\n      <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
	templateBuilder.Append("script>\r\n      <script type=\"text/javascript\">\r\n      $(function(){\r\n        //初始化表单\r\n        AjaxInitForm('#point_form', '#btnSubmit', 1, '#turl');\r\n      });\r\n    </");
	templateBuilder.Append("script>\r\n      <header>\r\n        <a href=\"javascript:;\" onclick=\"history.back(-1);\" class=\"backButton\">返回</a>\r\n        <h1>积分兑换</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n      <form id=\"point_form\" name=\"point_form\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_point_convert\">\r\n        <div class=\"form-box\">\r\n          <dl>\r\n            <dt>账户余额</dt>\r\n            <dd>￥");
	templateBuilder.Append(Utils.ObjectToStr(userModel.amount));
	templateBuilder.Append("</dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>账户积分</dt>\r\n            <dd>");
	templateBuilder.Append(Utils.ObjectToStr(userModel.point));
	templateBuilder.Append(" 分</dd>\r\n          </dl>\r\n          <dl>\r\n            <dt>兑换说明</dt>\r\n            <dd>积分兑换最少金额为1元，兑换比例为：1元等于");
	templateBuilder.Append(Utils.ObjectToStr(uconfig.pointcashrate));
	templateBuilder.Append("个积分</dd>\r\n          </dl>\r\n          <div><input name=\"txtAmount\" id=\"txtAmount\" type=\"text\" placeholder=\"请输入兑换积分金额(元)\" datatype=\"n\"  nullmsg=\"请输入金额\" sucmsg=\" \" /></div>\r\n          <div><input name=\"txtPassword\" id=\"txtPassword\" type=\"password\" placeholder=\"请输入登录密码\" datatype=\"*6-20\" nullmsg=\"请输入密码\" sucmsg=\" \"></div>\r\n          <div><input id=\"btnSubmit\" name=\"btnSubmit\" type=\"submit\" value=\"确认兑换\" class=\"btn orange full\" /></div>\r\n        </div>\r\n      </form>\r\n      <input id=\"turl\" name=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(linkurl("userpoint","convert"));

	templateBuilder.Append("\" />\r\n      \r\n      <!--版权信息-->\r\n      ");

	templateBuilder.Append("      <div class=\"copyright\">\r\n        <p><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" data-ignore=\"true\">触屏版</a> | <a href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.weburl));
	templateBuilder.Append("?m2w\" data-ignore=\"true\">电脑版</a> | <a href=\"javascript:;\" onclick=\"$.ui.scrollToTop('mainPanel')\">返回顶部</a></p>\r\n        <address>版权所有 深圳市动力启航软件有限公司 版本号 V");
	templateBuilder.Append(Utils.GetVersion().ToString());

	templateBuilder.Append("</address></p>\r\n      </div>");


	templateBuilder.Append("\r\n      <!--/版权信息-->\r\n      \r\n      <footer>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("userpoint","convert"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon tag pressed\">积分兑换</a>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("userpoint","list"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon clock\">积分明细</a>\r\n      </footer>\r\n    <!--/积分兑换-->\r\n    \r\n    ");
	}
	else if (action=="list")
	{

	templateBuilder.Append("\r\n    <!--积分明细-->\r\n      <script type=\"text/javascript\">\r\n		  function ExecPostBack(checkValue) {\r\n			  if (arguments.length == 1) {\r\n				  ExecDelete('");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_point_delete', checkValue, '#turl');\r\n			  }else{\r\n				  var valueArr = '';\r\n				  $(\"input[name='checkId']:checked\").each(function(i){\r\n					  valueArr += $(this).val();\r\n					  if(i < $(\"input[name='checkId']:checked\").length - 1){\r\n						  valueArr += \",\"\r\n					  }\r\n				  });\r\n				  ExecDelete('");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_point_delete', valueArr, '#turl');\r\n			  }\r\n		  }\r\n	  </");
	templateBuilder.Append("script>\r\n      <header>\r\n        <a href=\"javascript:;\" onclick=\"history.back(-1);\" class=\"backButton\">返回</a>\r\n        <h1>积分明细</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n      \r\n      <!--操作按钮-->\r\n      <div class=\"select-bar\">\r\n        <div class=\"col\">\r\n          <a href=\"javascript:;\" onclick=\"checkAll(this);\" class=\"icon-check\">全选</a>\r\n        </div>\r\n        <div class=\"col\">\r\n          <a href=\"javascript:;\" onclick=\"ExecPostBack();\" class=\"icon-trash\">删除</a>\r\n        </div>\r\n      </div>\r\n      <!--/操作按钮-->\r\n      \r\n      <div>\r\n        <ul class=\"detail-list\">\r\n          ");
	DataTable list = get_user_point_list(10, page, "user_id="+userModel.id, out totalcount);

	templateBuilder.Append(" <!--取得一个DataTable-->\r\n          ");
	string pagelist = get_page_link(10, page, totalcount, "userpoint", action, "__id__");

	templateBuilder.Append(" <!--取得分页页码列表-->\r\n          ");
	foreach(DataRow dr in list.Rows)
	{

	templateBuilder.Append("\r\n          <li>\r\n            <input id=\"checkId-" + Utils.ObjectToStr(dr["id"]) + "\" name=\"checkId\" class=\"checkall\" type=\"checkbox\" value=\"" + Utils.ObjectToStr(dr["id"]) + "\" >\r\n            <label for=\"checkId-" + Utils.ObjectToStr(dr["id"]) + "\">\r\n              <h4><span>\r\n              ");
	if (Utils.StrToInt(Utils.ObjectToStr(dr["value"]), 0)>0)
	{

	templateBuilder.Append("\r\n              +" + Utils.ObjectToStr(dr["value"]) + "\r\n              ");
	}
	else
	{

	templateBuilder.Append("\r\n              " + Utils.ObjectToStr(dr["value"]) + "\r\n              ");
	}	//end for if

	templateBuilder.Append("\r\n              </span>" + Utils.ObjectToStr(dr["remark"]) + "</h4>\r\n              <p>" + Utils.ObjectToStr(dr["add_time"]) + "</p>\r\n            </label>\r\n          </li>\r\n           ");
	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </div>\r\n      <input id=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(linkurl("userpoint","list"));

	templateBuilder.Append("\" />\r\n      \r\n      <!--分页页码-->\r\n      <div class=\"page-list\">");
	templateBuilder.Append(Utils.ObjectToStr(pagelist));
	templateBuilder.Append("</div>\r\n      <!--/分页页码-->\r\n      \r\n      <!--版权信息-->\r\n      ");

	templateBuilder.Append("      <div class=\"copyright\">\r\n        <p><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" data-ignore=\"true\">触屏版</a> | <a href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.weburl));
	templateBuilder.Append("?m2w\" data-ignore=\"true\">电脑版</a> | <a href=\"javascript:;\" onclick=\"$.ui.scrollToTop('mainPanel')\">返回顶部</a></p>\r\n        <address>版权所有 深圳市动力启航软件有限公司 版本号 V");
	templateBuilder.Append(Utils.GetVersion().ToString());

	templateBuilder.Append("</address></p>\r\n      </div>");


	templateBuilder.Append("\r\n      <!--/版权信息-->\r\n      \r\n      <footer>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("userpoint","convert"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon tag\">积分兑换</a>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("userpoint","list"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon clock pressed\">积分明细</a>\r\n      </footer>\r\n      \r\n    <!--/积分明细-->\r\n    ");
	}	//end for if

	templateBuilder.Append("\r\n    \r\n	</div>\r\n    \r\n    <!--左侧导航-->\r\n    ");

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
