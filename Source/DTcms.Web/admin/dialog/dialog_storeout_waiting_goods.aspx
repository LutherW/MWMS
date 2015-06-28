<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_storeout_waiting_goods.aspx.cs" Inherits="DTcms.Web.admin.dialog.dialog_storeout_waiting_goods" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>待出库货物列表</title>
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
                var orderId = $(this).attr("data-storein-order-id")
                var goodsId = $(this).attr("data-storein-goods-id")
                var goodsName = $(this).attr("data-goods-name");
                var goodsCount = $(this).attr("data-goods-count");
                html += "<li>";
                html += '<a href="javascript:;" onclick="delNode(this);" class="del" title="删除"></a>';
                html += '<div class="btns">';
                html += '<input type="hidden" name="StoreOutWaitingGoodsId" value="' + id + '" />';
                html += '<input type="hidden" name="StoreInOrderId" value="' + orderId + '" />';
                html += '<input type="hidden" name="StoreInGoodsId" value="' + goodsId + '" />';
                html += '货物：' + goodsName + '';
                html += '</div>';
                html += '<div class="btns">';
                html += '库存量：' + goodsCount + '';
                html += '</div>';
                html += '<div class="btns">';
                html += '出库量：<input type="text" name="StoreOutCount" value="0.00" style="width: 70%;" />';
                html += '</div>';
                html += '<div class="btns">';
                html += '备注：<input type="text" name="StoreOutGoodsRemark" value="" style="width: 70%;" />';
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
                                <asp:DropDownList ID="ddlStoreInOrder" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStoreInOrder_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlStoreInGoods" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStoreInGoods_SelectedIndexChanged">
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
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable" id="table_list">
                        <tr>
                            <th width="5%">选择</th>
                            <th align="left" width="10%">货物名称</th>
                            <th align="left" width="10%">仓库</th>
                            <th align="left" width="10%">库存量</th>
                            <th align="left" width="15%">计划出库时间</th>
                            <th align="left" width="10%">操作员</th>
                            <th>备注</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <input type="checkbox" name="StoreWaitingGoodsId" value="<%#Eval("Id")%>" 
                                data-goods-name="<%#Eval("GoodsName")%>" 
                                data-storein-order-id="<%#Eval("StoreInOrderId")%>" 
                                data-storein-goods-id="<%#Eval("StoreInGoodsId")%>" 
                                data-goods-id="<%#Eval("GoodsId")%>" 
                                data-goods-count="<%#Eval("StoredInCount")%>" 
                                class="checkall" />
                        </td>
                        <td><%#Eval("GoodsName")%></td>
                        <td><%#Eval("StoreName")%></td>
                        <td><%#Eval("StoredInCount")%></td>
                        <td><%#Convert.ToDateTime(Eval("StoringOutTime")).ToString("yyyy-MM-dd")%></td>
                        <td><%#Eval("Admin")%></td>
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
