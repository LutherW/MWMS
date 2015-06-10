<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_vehicle_list.aspx.cs" Inherits="DTcms.Web.admin.dialog.dialog_vehicle_list" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>车辆列表管理</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        var api = top.dialog.get(window);//获取父窗体对象
        var vehicles = [];
        $(function () {
            api.button([{
                value: '确定',
                callback: function () {
                    createGoodsVehicleHtml();
                },
                autofocus: true
            }, {
                value: '取消',
                callback: function () { }
            }]);

        });

        function createGoodsVehicleHtml() {
            var html = "";
            $.each($("#table_list tr input:checked"), function (i, n) {
                var val = $(this).val();
                var name = $(this).attr("data-vehicle-name");
                html += "<li>";
                html += '<a href="javascript:;" onclick="delNode(this);" class="del" title="删除"></a>';
                html += '<div class="btns">';
                html += '<input type="hidden" name="VehicleId" value="' + val + '" style="width: 70%;" />';
                html += '车牌号：' + name + '';
                html += '</div>';
                html += '<div class="btns">';
                html += '数&nbsp;&nbsp;&nbsp;量：<input type="text" name="Count" value="0.00" style="width: 70%;" />';
                html += '</div>';
                html += '<div class="btns">';
                html += '备&nbsp;&nbsp;&nbsp;注：<input type="text" name="GoodsVehicleRemark" value="" style="width: 70%;" />';
                html += '</div>';
                html += '</li>';
            });

            api.data.append(html);
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap" style="margin-top: 0;">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="r-list">
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
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
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable" id="table_list">
                        <tr>
                            <th width="8%">选择</th>
                            <th width="10%" align="left">车牌号码</th>
                            <th width="10%">司机</th>
                            <th width="10%">联系电话</th>
                            <th width="15%">联系地址</th>
                            <th>备注</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <input type="checkbox" name="VehicleId" value="<%#Eval("Id")%>" data-vehicle-name="<%#Eval("PlateNumber")%>" class="checkall" />

                        </td>
                        <td>
                            <%#Eval("PlateNumber")%>
                        </td>
                        <td align="center"><%#Eval("Driver")%></td>
                        <td align="center"><%#Eval("LinkTel")%></td>
                        <td align="center"><%#Eval("LinkAddress")%></td>
                        <td align="center"><%#Eval("Remark")%></td>
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
