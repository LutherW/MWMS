﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="storeout_waiting_goods.aspx.cs" Inherits="DTcms.Web.admin.business.storeout_waiting_goods" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>待出库货物管理</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        function showVehicleDialog(id, name) {
            var objNum = arguments.length;
            var attachDialog = top.dialog({
                id: 'vehicleDialogId',
                title: name + "的运输车辆",
                url: '/admin/dialog/dialog_storeout_vehicle_list.aspx?goodsId=' + id,
                width: 700,
                onclose: function () {

                }
            }).showModal();
        }

        function showAttributeDialog(goodsId, goodsName) {
            var attachDialog = top.dialog({
                id: 'attachDialogId',
                title: goodsName + "属性",
                url: 'dialog/goods_attribute_list.aspx?goodsId=' + goodsId,
                width: 700
            }).showModal();
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>待出库货物列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="storeout_waiting_goods_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','只允许删除未出库货物，是否继续？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                        <div class="menu-list">
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlStoreInOrder" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStoreInOrder_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlGoods" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGoods_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="r-list">
                        <span class="lable">计划出库时间</span>
                        <asp:TextBox ID="txtBeginTime" runat="server" CssClass="keyword" onfocus="WdatePicker({ maxDate:'#F{$dp.$D(\'txtEndTime\',{d:-1})}'})"/>
                        <span class="lable">-</span>
                        <asp:TextBox ID="txtEndTime" runat="server" Text="bbb" CssClass="keyword" onfocus="WdatePicker({ minDate:'#F{$dp.$D(\'txtBeginTime\',{d:0})}'})"/>
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <div class="table-container">
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table width="100%" bgoods="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th width="5%">选择</th>
                            <th align="left" width="10%">入库单号</th>
                            <th align="left" width="10%">货物名称</th>
                            <th align="left" width="10%">仓库</th>
                            <th align="left" width="10%">库存量</th>
                            <th align="left" width="15%">入库时间</th>
                            <th align="left" width="15%">计划出库时间</th>
                            <th align="left" width="10%">操作员</th>
                            <th width="8%">明细</th>
                            <th width="8%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Enabled='True' Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("Id")%>' runat="server" />
                        </td>
                        <td><%#Eval("AccountNumber")%></td>
                        <td><%#Eval("GoodsName")%></td>
                        <td><%#Eval("StoreName")%></td>
                        <td><%#Eval("StoredInCount")%></td>
                        <td><%#Eval("StoredInTime")%></td>
                        <td><%#Eval("StoringOutTime")%></td>
                        <td><%#Eval("Admin")%></td>
                        <td align="center">
                            <%--<a href="javascript:void(0);" onclick="showAttachDialog(<%#Eval("GoodsId") %>, '<%#Eval("GoodsName") %>');">附件</a>&nbsp;|&nbsp;--%>
                            <a href="javascript:void(0);" onclick="showAttributeDialog(<%#Eval("GoodsId") %>, '<%#Eval("GoodsName") %>');">属性</a>&nbsp;|&nbsp;
                            <a href="javascript:void(0);" onclick="showVehicleDialog(<%#Eval("Id") %>, '<%#Eval("GoodsName") %>');">车辆</a>
                        </td>
                        <td align="center">
                            <a href="storeout_waiting_goods_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("Id")%>">修改</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
</table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <div class="pagelist">
            <div class="l-btns">
                <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                    OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
            </div>
            <div id="PageContent" runat="server" class="default"></div>
        </div>
        <!--/内容底部-->

    </form>
</body>
</html>
