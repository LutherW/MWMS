<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_check_cost_list.aspx.cs" Inherits="DTcms.Web.admin.dialog.dialog_check_cost_list" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>入库费用列表</title>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <div style="width: 700px; overflow: auto;">
            <div class="div-content">
                <asp:Repeater ID="rptList" runat="server">
                    <HeaderTemplate>
                        <table width="100%" bgoods="0" cellspacing="0" cellpadding="0" class="ltable">
                            <tr>
                                <th width="5%"></th>
                                <th align="left" width="20%">名称</th>
                                <th align="left" width="20%">数量</th>
                                <th align="left" width="20%">类型</th>
                                <th align="left" width="20%">价格</th>
                                <th align="left">客户</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                            </td>
                            <td><%#Eval("Name")%></td>
                            <td><%#Eval("Count")%></td>
                            <td><%#Convert.ToDecimal(Eval("TotalPrice")) >= 0 ? "收入" : "支出"%></td>
                            <td><%#Math.Abs(Convert.ToDecimal(Eval("TotalPrice")))%></td>
                            <td><%#Eval("Customer")%></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\">暂无记录</td></tr>" : ""%>
</table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
