<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.usermessage" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<!--HTML5 doctype-->\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\">\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=0\">\r\n<meta name=\"apple-mobile-web-app-capable\" content=\"yes\" />\r\n<title>站内短信息 - ");
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
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\n	function ExecPostBack(checkValue) {\r\n		if (arguments.length == 1) {\r\n			ExecDelete('");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_message_delete', checkValue, '#turl');\r\n		}else{\r\n			var valueArr = '';\r\n			$(\"input[name='checkId']:checked\").each(function(i){\r\n				valueArr += $(this).val();\r\n				if(i < $(\"input[name='checkId']:checked\").length - 1){\r\n					valueArr += \",\"\r\n				}\r\n			});\r\n			ExecDelete('");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_message_delete', valueArr, '#turl');\r\n		}\r\n    }\r\n	//分页链接不使用异步\r\n	$(document).ready(function(e) {\r\n        $(\".page-list a\").attr(\"data-ignore\",true);\r\n    });\r\n</");
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<div id=\"afui\">\r\n  <div id=\"content\">\r\n\r\n	<div id=\"mainPanel\" class=\"panel\">\r\n      ");
	if (action=="add")
	{

	templateBuilder.Append("\r\n      <!--写短消息-->\r\n      <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
	templateBuilder.Append("script>\r\n	  <script type=\"text/javascript\">\r\n        $(function(){\r\n          //初始化表单\r\n          AjaxInitForm('#add_form', '#btnSubmit', 1, '#turl');\r\n        });\r\n      </");
	templateBuilder.Append("script>\r\n      <header>\r\n        <a href=\"javascript:;\" onclick=\"history.back(-1);\" class=\"backButton\">返回</a>\r\n        <h1>写短消息</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n      <form id=\"add_form\" name=\"add_form\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_message_add\">\r\n        <div class=\"form-box\">\r\n          <div><input name=\"txtUserName\" id=\"txtUserName\" type=\"text\" placeholder=\"收件人用户名\" datatype=\"s1-50\"  nullmsg=\"请填写收件人用户名\" sucmsg=\" \" /></div>\r\n          <div><input name=\"txtTitle\" id=\"txtTitle\" type=\"text\" placeholder=\"短消息标题\" datatype=\"*1-50\" sucmsg=\" \" /></div>\r\n          <div><textarea name=\"txtContent\" rows=\"3\" placeholder=\"短消息内容\" datatype=\"*\" sucmsg=\" \"></textarea></div>\r\n          <div><input id=\"sendSave\" name=\"sendSave\" type=\"checkbox\" value=\"true\" checked=\"checked\" /><label for=\"sendSave\">保存到发件箱</label></div>\r\n          <div><input id=\"txtCode\" name=\"txtCode\" type=\"text\" placeholder=\"验证码\" style=\"width:100px;\" datatype=\"*\" sucmsg=\" \" />\r\n          <a id=\"verifyCode\" href=\"javascript:;\" onclick=\"ToggleCode(this, '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx');return false;\" style=\"display:inline-block;\"><img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx\" width=\"80\" height=\"30\" style=\"vertical-align:middle;\" /> 看不清楚？</a>\r\n          </div>\r\n          <div><input id=\"btnSubmit\" name=\"btnSubmit\" type=\"submit\" value=\"确认发布\" class=\"btn orange full\" /></div>\r\n        </div>\r\n      </form>\r\n      <input id=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(linkurl("usermessage","add"));

	templateBuilder.Append("\" />\r\n      \r\n      <!--版权信息-->\r\n      ");

	templateBuilder.Append("      <div class=\"copyright\">\r\n        <p><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" data-ignore=\"true\">触屏版</a> | <a href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.weburl));
	templateBuilder.Append("?m2w\" data-ignore=\"true\">电脑版</a> | <a href=\"javascript:;\" onclick=\"$.ui.scrollToTop('mainPanel')\">返回顶部</a></p>\r\n        <address>版权所有 深圳市动力启航软件有限公司 版本号 V");
	templateBuilder.Append(Utils.GetVersion().ToString());

	templateBuilder.Append("</address></p>\r\n      </div>");


	templateBuilder.Append("\r\n      <!--/版权信息-->\r\n      \r\n      <footer>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("usermessage","add"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon pencil pressed\">写消息</a>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("usermessage","system"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon mail\">系统消息</a>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("usermessage","accept"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon message\">收件箱</a>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("usermessage","send"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon target\">发件箱</a>\r\n      </footer>\r\n      <!--/写短消息-->\r\n      \r\n      ");
	}
	else if (action=="system")
	{

	templateBuilder.Append("\r\n      <!--系统消息-->\r\n      <header>\r\n        <a href=\"javascript:;\" onclick=\"history.back(-1);\" class=\"backButton\">返回</a>\r\n        <h1>系统消息</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n      <!--操作按钮-->\r\n      <div class=\"select-bar\">\r\n        <div class=\"col\">\r\n          <a href=\"javascript:;\" onclick=\"checkAll(this);\" class=\"icon-check\">全选</a>\r\n        </div>\r\n        <div class=\"col\">\r\n          <a href=\"javascript:;\" onclick=\"ExecPostBack();\" class=\"icon-trash\">删除</a>\r\n        </div>\r\n      </div>\r\n      <!--/操作按钮-->\r\n      \r\n      <div>\r\n        <ul class=\"detail-list\">\r\n          ");
	DataTable list = get_user_message_list(10, page, "accept_user_name='"+userModel.user_name+"' and type=1", out totalcount);

	string pagelist = get_page_link(10, page, totalcount, "usermessage", action, "__id__");

	templateBuilder.Append(" <!--取得分页页码列表-->\r\n          ");
	foreach(DataRow dr in list.Rows)
	{

	templateBuilder.Append("\r\n          <li>\r\n            <input id=\"checkId-" + Utils.ObjectToStr(dr["id"]) + "\" name=\"checkId\" class=\"checkall\" type=\"checkbox\" value=\"" + Utils.ObjectToStr(dr["id"]) + "\" >\r\n            <label for=\"checkId-" + Utils.ObjectToStr(dr["id"]) + "\">\r\n              <a href=\"");
	templateBuilder.Append(linkurl("usermessage_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\"  data-ignore=\"true\">\r\n                <h4>" + Utils.ObjectToStr(dr["title"]) + "</h4>\r\n                <p><span>\r\n                ");
	if (Utils.ObjectToStr(dr["is_read"])=="1")
	{

	templateBuilder.Append("\r\n                已阅读\r\n                ");
	}
	else
	{

	templateBuilder.Append("\r\n                未阅读\r\n                ");
	}	//end for if

	templateBuilder.Append("\r\n                </span>" + Utils.ObjectToStr(dr["post_time"]) + "</p>\r\n              </a>\r\n            </label>\r\n          </li>\r\n          ");
	}	//end for if

	if (list.Rows.Count<1)
	{

	templateBuilder.Append("\r\n          <div class=\"nodata\">暂无记录</div>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </div>\r\n      <input id=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(linkurl("usermessage","system"));

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
	templateBuilder.Append(linkurl("usermessage","add"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon pencil\">写消息</a>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("usermessage","system"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon mail pressed\">系统消息</a>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("usermessage","accept"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon message\">收件箱</a>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("usermessage","send"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon target\">发件箱</a>\r\n      </footer>\r\n      <!--/系统消息-->\r\n      \r\n      ");
	}
	else if (action=="accept")
	{

	templateBuilder.Append("\r\n      <!--收件箱-->\r\n      <header>\r\n        <a onclick=\"history.back(-1);\" class=\"backButton\">返回</a>\r\n        <h1>收件箱</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n      <!--操作按钮-->\r\n      <div class=\"select-bar\">\r\n        <div class=\"col\">\r\n          <a href=\"javascript:;\" onclick=\"checkAll(this);\" class=\"icon-check\">全选</a>\r\n        </div>\r\n        <div class=\"col\">\r\n          <a href=\"javascript:;\" onclick=\"ExecPostBack();\" class=\"icon-trash\">删除</a>\r\n        </div>\r\n      </div>\r\n      <!--/操作按钮-->\r\n      \r\n      <div>\r\n        <ul class=\"detail-list\">\r\n          ");
	DataTable list = get_user_message_list(10, page, "accept_user_name='"+userModel.user_name+"' and type=2", out totalcount);

	string pagelist = get_page_link(10, page, totalcount, "usermessage", action, "__id__");

	templateBuilder.Append(" <!--取得分页页码列表-->\r\n          ");
	foreach(DataRow dr in list.Rows)
	{

	templateBuilder.Append("\r\n          <li>\r\n            <input id=\"checkId-" + Utils.ObjectToStr(dr["id"]) + "\" name=\"checkId\" class=\"checkall\" type=\"checkbox\" value=\"" + Utils.ObjectToStr(dr["id"]) + "\" >\r\n            <label for=\"checkId-" + Utils.ObjectToStr(dr["id"]) + "\">\r\n              <a href=\"");
	templateBuilder.Append(linkurl("usermessage_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\"  data-ignore=\"true\">\r\n                <h4><span>" + Utils.ObjectToStr(dr["post_user_name"]) + "</span>" + Utils.ObjectToStr(dr["title"]) + "</h4>\r\n                <p><span>\r\n                ");
	if (Utils.ObjectToStr(dr["is_read"])=="1")
	{

	templateBuilder.Append("\r\n                已阅读\r\n                ");
	}
	else
	{

	templateBuilder.Append("\r\n                未阅读\r\n                ");
	}	//end for if

	templateBuilder.Append("\r\n                </span>" + Utils.ObjectToStr(dr["post_time"]) + "</p>\r\n              </a>\r\n            </label>\r\n          </li>\r\n          ");
	}	//end for if

	if (list.Rows.Count<1)
	{

	templateBuilder.Append("\r\n          <div class=\"nodata\">暂无记录</div>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </div>\r\n      <input id=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(linkurl("usermessage","accept"));

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
	templateBuilder.Append(linkurl("usermessage","add"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon pencil\">写消息</a>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("usermessage","system"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon mail\">系统消息</a>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("usermessage","accept"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon message pressed\">收件箱</a>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("usermessage","send"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon target\">发件箱</a>\r\n      </footer>\r\n      <!--/收件箱-->\r\n      \r\n      ");
	}
	else if (action=="send")
	{

	templateBuilder.Append("\r\n      <!--发件箱-->\r\n      <header>\r\n        <a onclick=\"history.back(-1);\" class=\"backButton\">返回</a>\r\n        <h1>发件箱</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n      <!--操作按钮-->\r\n      <div class=\"select-bar\">\r\n        <div class=\"col\">\r\n          <a href=\"javascript:;\" onclick=\"checkAll(this);\" class=\"icon-check\">全选</a>\r\n        </div>\r\n        <div class=\"col\">\r\n          <a href=\"javascript:;\" onclick=\"ExecPostBack();\" class=\"icon-trash\">删除</a>\r\n        </div>\r\n      </div>\r\n      <!--/操作按钮-->\r\n      \r\n      <div>\r\n        <ul class=\"detail-list\">\r\n          ");
	DataTable list = get_user_message_list(10, page, "post_user_name='"+userModel.user_name+"' and type=3", out totalcount);

	string pagelist = get_page_link(10, page, totalcount, "usermessage", action, "__id__");

	templateBuilder.Append(" <!--取得分页页码列表-->\r\n          ");
	foreach(DataRow dr in list.Rows)
	{

	templateBuilder.Append("\r\n          <li>\r\n            <input id=\"checkId-" + Utils.ObjectToStr(dr["id"]) + "\" name=\"checkId\" class=\"checkall\" type=\"checkbox\" value=\"" + Utils.ObjectToStr(dr["id"]) + "\" >\r\n            <label for=\"checkId-" + Utils.ObjectToStr(dr["id"]) + "\">\r\n              <a href=\"");
	templateBuilder.Append(linkurl("usermessage_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\"  data-ignore=\"true\">\r\n                <h4><span>" + Utils.ObjectToStr(dr["accept_user_name"]) + "</span>" + Utils.ObjectToStr(dr["title"]) + "</h4>\r\n                <p><span>\r\n                ");
	if (Utils.ObjectToStr(dr["is_read"])=="1")
	{

	templateBuilder.Append("\r\n                已阅读\r\n                ");
	}
	else
	{

	templateBuilder.Append("\r\n                未阅读\r\n                ");
	}	//end for if

	templateBuilder.Append("\r\n                </span>" + Utils.ObjectToStr(dr["post_time"]) + "</p>\r\n              </a>\r\n            </label>\r\n          </li>\r\n          ");
	}	//end for if

	if (list.Rows.Count<1)
	{

	templateBuilder.Append("\r\n          <div class=\"nodata\">暂无记录</div>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </div>\r\n      <input id=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(linkurl("usermessage","send"));

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
	templateBuilder.Append(linkurl("usermessage","add"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon pencil\">写消息</a>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("usermessage","system"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon mail\">系统消息</a>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("usermessage","accept"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon message\">收件箱</a>\r\n        <a href=\"");
	templateBuilder.Append(linkurl("usermessage","send"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"icon target pressed\">发件箱</a>\r\n      </footer>\r\n      <!--/发件箱-->\r\n      ");
	}	//end for if

	templateBuilder.Append("\r\n	</div>\r\n    \r\n    <!--左侧导航-->\r\n    ");

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
