<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="storein_cost_list.aspx.cs" Inherits="DTcms.Web.admin.search.storein_cost_list" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>入库费用列表</title>
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
                url: '/admin/dialog/dialog_storein_cost_invoiced.aspx?id=' + id,
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
            <span>入库费用列表</span>
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
                                <asp:DropDownList ID="ddlStoreInOrder" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStoreInOrder_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                    <asp:ListItem Text="选择类型" Value=""></asp:ListItem>
                                    <asp:ListItem Text="收入" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="支出" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                    <asp:ListItem Text="选择状态" Value=""></asp:ListItem>
                                    <asp:ListItem Text="已付款" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="未付款" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="r-list">
                        <span class="lable">付款时间</span>
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
                            <th width="5%"></th>
                            <th align="left">收费名称</th>
                            <th align="left" width="10%">入库单</th>
                            <th align="left" width="10%">客户名称</th>
                            <th align="left">单价</th>
                            <th align="left" width="10%">数量</th>
                            <th align="left" width="8%">总价</th>
                            <th align="left" width="8%">付款时间</th>
                            <th width="8%" >操作人</th>
                            <th width="8%" >状态</th>
                            <th width="12%">发票</th>
                            <th width="8%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center"></td>
                        <td><%#Eval("Name")%></td>
                        <td><%#Eval("AccountNumber")%></td>
                        <td><%#Eval("Customer")%></td>
                        <td><%#Eval("UnitPrice")%></td>
                        <td><%#Eval("Count")%></td>
                        <td><%#Eval("TotalPrice")%></td>
                        <td><%#string.IsNullOrWhiteSpace(Eval("PaidTime").ToString()) ? "--" : Convert.ToDateTime(Eval("PaidTime")).ToString("yyyy-MM-dd")%></td>
                        <td><%#Eval("Admin")%></td>
                        <td><%#Eval("Status").ToString().Equals("1") ? "已付款" : "未付款"%></td>
                        <td align="center">
                            <%#Eval("HasBeenInvoiced").ToString().Equals("True") ? "<a href=\"javascript:void(0);\" onclick=\"showInvoicedDialog("+Eval("Id")+");\">发票详情</a>" : "未开发票" %>
                        </td>
                        <td align="center">
                            <a href="storein_cost_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("Id")%>">修改</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"12\">暂无记录</td></tr>" : ""%>
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
