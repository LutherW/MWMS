<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="text_edit.aspx.cs" Inherits="DTcms.Web.admin.weixin.text_edit" ValidateRequest="false" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑文本回复</title>
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
  <a href="text_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>应用管理</span>
  <i class="arrow"></i>
  <span>微信管理</span>
  <i class="arrow"></i>
  <span>编辑文本回复</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">编辑文本回复</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>搜索关键词</dt>
    <dd>
      <asp:TextBox ID="txtKeywords" runat="server" CssClass="input normal " datatype="*1-1000" 
           sucmsg=" " nullmsg="请填写关键词，多个关键词请用|格开：例如: 美丽|漂亮|好看"></asp:TextBox>
      <span class="Validform_checktip">*多个关键词请用|格开：例如: 美丽|漂亮|好看</span>
    </dd>
  </dl>
  <dl>
    <dt>关键词类型</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblIsLikeQuery" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
          <asp:ListItem Value="0" Selected="True">完全匹配</asp:ListItem>
          <asp:ListItem Value="1">包含匹配</asp:ListItem>
        </asp:RadioButtonList>
      </div>
      <span class="Validform_checktip">*包含匹配，当文字包含本关键词时触发</span>
    </dd>
  </dl>
  <dl>
    <dt>排序数字</dt>
    <dd>
      <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
      <span class="Validform_checktip">*数字，越小越向前</span>
    </dd>
  </dl>
  <dl>
    <dt>内容介绍</dt>
    <dd>
      <asp:TextBox ID="txtContent" runat="server" CssClass="input" TextMode="MultiLine" style="width:100%;height:250px;" datatype="*1-1000" sucmsg=" " nullmsg="请输入内容或简介"></asp:TextBox>
      <span class="Validform_checktip">*1000个字符以内</span></dd>
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
