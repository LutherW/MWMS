<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_goods_attach_list.aspx.cs" Inherits="DTcms.Web.admin.dialog.dialog_goods_attach_list" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>货物附件列表</title>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <div style="width: 500px; height: 280px; overflow: auto;">
            <div class="div-content">
                <asp:Repeater ID="rptList" runat="server">
                    <HeaderTemplate>
                        <table width="100%" bgoods="0" cellspacing="0" cellpadding="0" class="ltable">
                            <tr>
                                <th width="5%"></th>
                                <th align="left" width="20%">名称</th>
                                <th align="left" width="20%">上传时间</th>
                                <th align="left">备注</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                            </td>
                            <td><%#Eval("Admin")%></td>
                            <td><%#Eval("CreateTime")%></td>
                            <td><%#Eval("Remark")%></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"4\">暂无记录</td></tr>" : ""%>
</table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
