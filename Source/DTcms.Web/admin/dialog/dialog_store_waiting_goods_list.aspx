<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_store_waiting_goods_list.aspx.cs" Inherits="DTcms.Web.admin.dialog.dialog_store_waiting_goods_list" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>待入库货物列表</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
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
            var storeOptions = "<%=storeOptions%>";
            $.each($("#table_list tr input:checked"), function (i, n) {
                var id = $(this).val();
                var customerId = $(this).attr("data-customer-id")
                var goodsId = $(this).attr("data-goods-id")
                var goodsName = $(this).attr("data-goods-name") + '(' + $(this).attr("data-customer-name") + ')';
                html += "<li>";
                html += '<a href="javascript:;" onclick="delNode(this);" class="del" title="删除"></a>';
                html += '<div class="btns">';
                html += '<input type="hidden" name="StoreWaitingGoodsId" value="' + id + '" />';
                html += '<input type="hidden" name="CustomerId" value="' + customerId + '" />';
                html += '<input type="hidden" name="GoodsId" value="' + goodsId + '" />';
                html += '货物：' + goodsName + '';
                html += '</div>';
                html += '<div class="btns">';
                html += '仓库：<select name="StoreId">' + storeOptions + '</select>';
                html += '</div>';
                html += '<div class="btns">';
                html += '数量：<input type="text" name="Count" value="0.00" style="width: 70%;" />';
                html += '</div>';
                html += '<div class="btns">';
                html += '备注：<input type="text" name="StoreInGoodsRemark" value="" style="width: 70%;" />';
                html += '</div>';
                html += '</li>';
            });

            api.data.append(html);
        }

        function checkMyAll(chkobj) {
            if ($(chkobj).text() == "全选") {
                $(chkobj).children("span").text("取消");
                $(".checkall:checkbox").prop("checked", true);
            } else {
                $(chkobj).children("span").text("全选");
                $(".checkall:checkbox").prop("checked", false);
            }
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="all" href="javascript:;" onclick="checkMyAll(this);"><i></i><span>全选</span></a></li>
                        </ul>
                        <div class="menu-list">
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlCustomer" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlGoods" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGoods_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="r-list">
                        <span class="lable">计划入库时间</span>
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
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable" id="table_list">
                        <tr>
                            <th width="5%">选择</th>
                            <th align="left" width="25%">货物名称</th>
                            <th align="left" width="25%">客户</th>
                            <th align="left" width="15%">计划入库时间</th>
                            <th align="left" width="10%">操作员</th>
                            <th>备注</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <input type="checkbox" name="StoreWaitingGoodsId" value="<%#Eval("Id")%>" 
                                data-goods-name="<%#Eval("GoodsName")%>" 
                                data-customer-name="<%#Eval("CustomerName")%>" 
                                data-customer-id="<%#Eval("CustomerId")%>" 
                                data-goods-id="<%#Eval("GoodsId")%>" 
                                class="checkall" />
                        </td>
                        <td><%#Eval("GoodsName")%></td>
                        <td><%#Eval("CustomerName")%></td>
                        <td><%#Convert.ToDateTime(Eval("StoringTime")).ToString("yyyy-MM-dd")%></td>
                        <td><%#Eval("Admin")%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"5\">暂无记录</td></tr>" : ""%>
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
