<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="center.aspx.cs" Inherits="DTcms.Web.admin.center" %>
<%@ Import namespace="DTcms.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>管理首页</title>
<link href="skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="js/layindex.js"></script>
<script type="text/javascript" charset="utf-8" src="js/common.js"></script>
    <style type="text/css">
        .process{padding:30px 50px;}
        .process span{display:inline-block;width:64px;height:64px;line-height:56px;background:url("skin/default/color.png") no-repeat 0 -575px scroll; text-align:center;}
        .process a{color:#fff;font-size:12px;}
        .process .arr{background-position:20px -808px;height:48px;}
        .process .bg1{background-position:0 0;}
        .process .bg2{background-position:0 -67px;}
        .process .bg3{background-position:0 -135px;}
        .process .bg4{background-position:0 -200px;}
        .process .bg5{background-position:0 -266px;}
        .process .bg6{background-position:0 -401px;}
        .process .bg7{background-position:0 -468px;}
        .process .bg8{background-position:0 -536px;}
        .process .bg9{background-position:0 -603px;}
        .process .bg10{background-position:0 -669px;}
        .process .bg11{background-position:0 -736px;}
    </style>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>管理中心</span>
</div>
<!--/导航栏-->

<!--内容-->
<div class="line10"></div>
<div class="nlist-2">
  <h3><i></i>登录记录</h3>
  <ul>
    <li>本次登录IP：<asp:Literal ID="litIP" runat="server" Text="-" /></li>
    <li>上次登录IP：<asp:Literal ID="litBackIP" runat="server" Text="-" /></li>
    <li>上次登录时间：<asp:Literal ID="litBackTime" runat="server" Text="-" /></li>
  </ul>
</div>
<div class="line20"></div>
<div class="nlist-2">
  <h3><i></i>入库操作流程</h3>
    <div class="process">
        <table border="0">
            <tr>
                <td><span class="bg3"><a href="business/store_waiting.aspx">待入库货物</a></span></td>
                <td><span class="arr"></span></td>
                <td><span class="bg6"><a href="business/storein_storage_order.aspx">仓库入库</a></span></td>
                <td><span class="arr"></span></td>
                <td><span class="bg4"><a href="business/store_in_order.aspx">办公室审核</a></span></td>
                <td><span class="arr"></span></td>
                <td><span class="bg1"><a href="javascript:;">入库完成</a></span></td>
            </tr>
        </table>
        <div class="line20"></div>
        <table border="0">
            <tr>
                <td><span class="bg3"><a href="business/store_waiting.aspx">待入库货物</a></span></td>
                <td><span class="arr"></span></td>
                <td><span class="bg7"><a href="business/store_in_order.aspx">办公室入库</a></span></td>
                <td><span class="arr"></span></td>
                <td><span class="bg10"><a href="business/storein_storage_order.aspx">仓库确认</a></span></td>
                <td><span class="arr"></span></td>
                <td><span class="bg4"><a href="business/store_in_order.aspx">办公室审核</a></span></td>
                <td><span class="arr"></span></td>
                <td><span class="bg1"><a href="javascript:;">入库完成</a></span></td>
            </tr>
        </table>
    </div>
</div>
<div class="line20"></div>
<div class="nlist-2">
  <h3><i></i>出库操作流程</h3>
    <div class="process">
        <table border="0">
            <tr>
                <td><span class="bg8"><a href="business/storeout_waiting_goods.aspx">待出库货物</a></span></td>
                <td><span class="arr"></span></td>
                <td><span class="bg2"><a href="business/storeout_storage_order.aspx">仓库出库</a></span></td>
                <td><span class="arr"></span></td>
                <td><span class="bg11"><a href="business/storeout_financial_order.aspx">财务确认</a></span></td>
                <td><span class="arr"></span></td>
                <td><span class="bg1"><a href="javascript:;">出库完成</a></span></td>
            </tr>
        </table>
        <div class="line20"></div>
        <table border="0">
            <tr>
                <td><span class="bg8"><a href="business/storeout_waiting_goods.aspx">待出库货物</a></span></td>
                <td><span class="arr"></span></td>
                <td><span class="bg5"><a href="business/store_out_order.aspx">办公室出库</a></span></td>
                <td><span class="arr"></span></td>
                <td><span class="bg9"><a href="business/store_out_order.aspx">仓库完善</a></span></td>
                <td><span class="arr"></span></td>
                <td><span class="bg11"><a href="business/storeout_financial_order.aspx">财务确认</a></span></td>
                <td><span class="arr"></span></td>
                <td><span class="bg1"><a href="javascript:;">出库完成</a></span></td>
            </tr>
        </table>
    </div>
</div>
<%--<div class="nlist-3">
  <ul>
    <li><a onclick="parent.linkMenuTree(true, 'sys_config');" class="icon-setting" href="javascript:;"></a><span>系统设置</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'sys_site_manage');" class="icon-channel" href="javascript:;"></a><span>站点管理</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'sys_site_templet');" class="icon-templet" href="javascript:;"></a><span>模板管理</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'sys_builder_html');" class="icon-mark" href="javascript:;"></a><span>生成静态</span></li>
    <li><a onclick="parent.linkMenuTree(true, ' sys_plugin_config ');" class="icon-plugin" href="javascript:;"></a><span>插件配置</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'user_list');" class="icon-user" href="javascript:;"></a><span>会员管理</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'manager_list');" class="icon-manaer" href="javascript:;"></a><span>管理员</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'manager_log');" class="icon-log" href="javascript:;"></a><span>系统日志</span></li>
  </ul>
</div>

<div class="nlist-4">
  <h3><i class="site"></i>建站三步曲</h3>
  <ul>
    <li>1、进入后台管理中心，点击“系统设置”修改网站配置信息；</li>
    <li>2、点击“站点管理”进行系统划分站点、建立频道、扩展字段等信息；</li>
    <li>3、制作好网站模板，上传到站点templates目录下，点击“模板管理”生成模板；</li>
  </ul>
  <h3><i class="msg"></i>官方消息</h3>
  <ul>
    <asp:Literal ID="LitNotice" runat="server"/>
  </ul>
</div>--%>
<!--/内容-->

</form>
</body>
</html>
