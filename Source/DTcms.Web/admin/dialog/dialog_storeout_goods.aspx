<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_storeout_goods.aspx.cs" Inherits="DTcms.Web.admin.dialog.dialog_storeout_goods" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>出库货物列表</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
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
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--列表-->
        <div class="table-container">
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable" id="table_list">
                        <tr>
                            <%--<th width="8%">选择</th>--%>
                            <th align="left" width="20%">入库单</th>
                            <th align="left" width="20%">货物</th>
                            <th align="left" width="15%">仓库</th>
                            <th align="left" width="10%">库存量</th>
                            <th align="left" width="10%">出库量</th>
                            <th>明细</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("AccountNumber")%></td>
                        <td><%#Eval("GoodsName")%></td>
                        <td><%#Eval("StoreName")%></td>
                        <td><%#Eval("StoredInCount")%></td>
                        <td><%#Eval("StoredOutCount")%></td>
                        <td align="center">
                            <a href="javascript:void(0);" onclick="showVehicleDialog(<%#Eval("StoreOutWaitingGoodsId") %>, '<%#Eval("GoodsName") %>');">运输车辆</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\">暂无记录</td></tr>" : ""%>
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
