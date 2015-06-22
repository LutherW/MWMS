<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allot_goods_list.aspx.cs" Inherits="DTcms.Web.admin.search.allot_goods_list" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>调拨货物列表</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        function showVehicleDialog(id) {
            var vehicleDialog = top.dialog({
                id: 'vehicleDialogId',
                title: "调拨货物运输车辆",
                url: '/admin/dialog/dialog_storeout_vehicle_list.aspx?goodsId=' + id,
                width: 700,
                onclose: function () {

                }
            }).showModal();
        }

        function showRemarkDialog(remark) {
            var remarkDialog = top.dialog({
                id: 'remarkDialogId',
                title: "备注信息",
                content: remark,
                width: 500
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
            <span>调拨货物列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <div class="menu-list">
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlCustomer" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlStoreInOrder" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStoreInOrder_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="r-list">
                        <span class="lable">调拨时间</span>
                        <asp:TextBox ID="txtBeginTime" runat="server" CssClass="keyword" onfocus="WdatePicker({ maxDate:'#F{$dp.$D(\'txtEndTime\',{d:-1})}'})"/>
                        <span class="lable">-</span>
                        <asp:TextBox ID="txtEndTime" runat="server" Text="" CssClass="keyword" onfocus="WdatePicker({ minDate:'#F{$dp.$D(\'txtBeginTime\',{d:0})}'})"/>
                        <span class="lable">关键字</span>
                        <asp:TextBox ID="txtKeyWord" runat="server" Text="" CssClass="keyword"/>
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
                            <th width="2%"></th>
                            <th align="left">货物</th>
                            <th align="left" width="10%">入库单</th>
                            <th align="left">原仓库</th>
                            <th align="left" width="10%">现仓库</th>
                            <th align="left" width="8%">调拨数量</th>
                            <th align="left" width="8%">调拨时间</th>
                            <th width="8%" >操作员</th>
                            <th width="12%">备注</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center"></td>
                        <td><%#Eval("GoodsName")%></td>
                        <td><%#Eval("AccountNumber")%></td>
                        <td><%#Eval("SourceStoreName")%></td>
                        <td><%#Eval("PurposeStoreName")%></td>
                        <td><%#Eval("AllotCount")%></td>
                        <td><%#Convert.ToDateTime(Eval("AllotTime")).ToString("yyyy-MM-dd")%></td>
                        <td align="center"><%#Eval("Admin")%></td>
                        <td align="center">
                            <a href="javascript:void(0);" onclick="showRemarkDialog('<%#Eval("Remark") %>');">备注</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
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
