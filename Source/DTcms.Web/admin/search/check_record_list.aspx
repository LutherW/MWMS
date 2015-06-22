<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="check_record_list.aspx.cs" Inherits="DTcms.Web.admin.search.check_record_list" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>查验记录列表</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        function showInvoicedDialog(id) {
            var invoicedDialog = top.dialog({
                id: 'vehicleDialogId',
                title: "发票信息",
                url: '/admin/dialog/dialog_storein_received_invoiced.aspx?id=' + id,
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
            <span>查验记录列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <div class="menu-list">
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlCustomer" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlGoods" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGoods_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlVehicle" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVehicle_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="r-list">
                        <span class="lable">查验时间</span>
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
                            <th width="3%"></th>
                            <th align="left">货物</th>
                            <th align="left" width="10%">客户</th>
                            <th align="left">车辆</th>
                            <th align="left" width="8%">装卸方式</th>
                            <th align="left" width="8%">查验时间</th>
                            <th align="left" width="8%">报检号</th>
                            <th width="8%" >箱号</th>
                            <th width="8%" >查验结果</th>
                            <th width="8%">姓名</th>
                            <th width="8%">联系电话</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center"></td>
                        <td><%#Eval("GoodsName")%></td>
                        <td><%#Eval("CustomerName")%></td>
                        <td><%#Eval("VehiclePlateNumber")%></td>
                        <td>
                            <%#Eval("HandlingModeName")%>
                        </td>
                        <td><%#Convert.ToDateTime(Eval("CheckTime")).ToString("yyyy-MM-dd")%></td>
                        <td>
                            <%#Eval("InspectionNumber")%>
                        </td>
                        <td align="center"><%#Eval("CaseNumber")%></td>
                        <td align="center"><%#Eval("CheckResult")%></td>
                        <td align="center">
                            <%#Eval("RealName")%>
                        </td>
                        <td align="center">
                            <%#Eval("LinkTel")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
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
