<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account_edit.aspx.cs" Inherits="DTcms.Web.admin.weixin.account_edit" ValidateRequest="false" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑公众账户</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>应用管理</span>
  <i class="arrow"></i>
  <span>微信管理</span>
  <i class="arrow"></i>
  <span>编辑公众账户</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">公众账户信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>微信认证URL</dt>
    <dd><%=siteConfig.weburl + "/api/weixin/wx.aspx"%></dd>
  </dl>
  <dl>
    <dt>公众号名称</dt>
    <dd>
      <asp:TextBox ID="txtName" runat="server" CssClass="input normal"  datatype="s2-100" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*公众平台账号名称。</span>
    </dd>
  </dl>
  <dl>
    <dt>公众号原始ID</dt>
    <dd>
      <asp:TextBox ID="txtOriginalId" runat="server" CssClass="input normal"  datatype="s1-50" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*公众平台账号原始ID。</span>
    </dd>
  </dl>
  <dl>
    <dt>公众平台微信号</dt>
    <dd>
      <asp:TextBox ID="txtWxCode" runat="server" CssClass="input normal"  datatype="s1-50" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*公众平台微信号。</span>
    </dd>
  </dl>
  <dl>
    <dt>ToKen</dt>
    <dd>
      <asp:TextBox ID="txtToKen" runat="server" CssClass="input normal"  datatype="*" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*ToKen值必须与公众平台对应。</span>
    </dd>
  </dl>
  <dl>
    <dt>AppId</dt>
    <dd>
      <asp:TextBox ID="txtAppId" runat="server" CssClass="input normal"  datatype="*0-100" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*非必填，仅用于高级接口。</span>
    </dd>
  </dl>
  <dl>
    <dt>AppSecret</dt>
    <dd>
      <asp:TextBox ID="txtAppSecret" runat="server" CssClass="input normal"  datatype="*0-150" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*非必填，仅用于高级接口。</span>
    </dd>
  </dl>
  <dl>
    <dt>内容推送</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsPush" runat="server" />
      </div>
      <span class="Validform_checktip">*网站内容推送至微信(备用)</span>
    </dd>
  </dl>
</div>
<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-wrap">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
</div>
<!--/工具栏-->

</form>
</body>
</html>
