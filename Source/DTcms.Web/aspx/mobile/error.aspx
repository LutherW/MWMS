<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.error" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<!--HTML5 doctype-->\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\">\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=0\">\r\n<meta name=\"apple-mobile-web-app-capable\" content=\"yes\" />\r\n<title>提示信息</title>\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/css/icons.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/css/af.ui.base.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
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
	templateBuilder.Append("/js/base.js\"></");
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<div id=\"afui\">\r\n  <div id=\"content\">\r\n\r\n	<div id=\"mainPanel\" class=\"panel\" data-footer=\"none\">\r\n      <header>\r\n        <a href=\"javascript:;\" onclick=\"history.back(-1);\" class=\"backButton\">返回</a>\r\n        <h1>错误提示</h1>\r\n      </header>\r\n      \r\n      <div class=\"wrap-box\">\r\n        <h2>出错啦！</h2>\r\n        <div class=\"tip\">\r\n          <span class=\"icon close\"></span>\r\n          <p>");
	templateBuilder.Append(Utils.ObjectToStr(msg));
	templateBuilder.Append("</p>\r\n        </div>\r\n      </div>\r\n    \r\n	</div>\r\n      \r\n  </div>\r\n</div>\r\n</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
