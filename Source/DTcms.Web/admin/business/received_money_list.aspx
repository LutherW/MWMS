<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="received_money_list.aspx.cs" Inherits="DTcms.Web.admin.business.received_money_list" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>收款记录管理</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        function showCostDialog(id) {
            var costDialog = top.dialog({
                id: 'costDialogId',
                title: "费用项",
                url: 'dialog/dialog_check_cost_list.aspx?id=' + id,
                width: 700
            }).showModal();
        }

        function showContentDialog(title, content) {
            var contentDialog = top.dialog({
                "id": 'contentDialogId',
                "title": title,
                "content": content,
                "width": 500
            }).showModal();
        }

        function doInvoiced(id) {
            if (!id || id < 1) {
                top.dialog({
                    title: '提示',
                    content: '对不起，ID不能为空！',
                    okValue: '确定',
                    ok: function () { }
                }).showModal();
                return false;
            }

            var invoicedContent = "";
            invoicedContent += "开票的时间：<input type='text' id='txtInvoicedTime' onfocus=\"WdatePicker({readonly:true,dateFmt:'yyyy-MM-dd'})\" value=''><br/><br/>";
            invoicedContent += "开票人姓名：<input type='text' id='txtInvoicedOperator'  value=''>";

            var smsdialog = parent.dialog({
                title: '填写发票信息',
                content: invoicedContent,
                okValue: '确定',
                ok: function () {
                    var invoicedTime = $("#txtInvoicedTime", parent.document).val();
                    var invoicedOperator = $("#txtInvoicedOperator", parent.document).val();
                    if (invoicedTime == "") {
                        top.dialog({
                            title: '提示',
                            content: '对不起，请填写开发票时间！',
                            okValue: '确定',
                            ok: function () { }
                        }).showModal(smsdialog);
                        return false;
                    }
                    if (invoicedOperator == "") {
                        top.dialog({
                            title: '提示',
                            content: '对不起，请填写开发票人姓名！',
                            okValue: '确定',
                            ok: function () { }
                        }).showModal(smsdialog);
                        return false;
                    }
                    var postData = { "id": id, "invoicedTime": invoicedTime, "invoicedOperator": invoicedOperator };
                    //发送AJAX请求
                    $.ajax({
                        type: "post",
                        url: "../../tools/admin_ajax.ashx?action=doInvoiced",
                        data: postData,
                        dataType: "json",
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            top.dialog({
                                title: '提示',
                                content: '尝试发送失败，错误信息：' + errorThrown,
                                okValue: '确定',
                                ok: function () { }
                            }).showModal(smsdialog);
                        },
                        success: function (data, textStatus) {
                            if (data.status == 1) {
                                smsdialog.close().remove();
                                var d = top.dialog({ content: data.msg }).show();
                                setTimeout(function () {
                                    d.close().remove();
                                    location.reload();
                                }, 2000);
                            } else {
                                top.dialog({
                                    title: '提示',
                                    content: '错误提示：' + data.msg,
                                    okValue: '确定',
                                    ok: function () { }
                                }).showModal(smsdialog);
                            }
                        }
                    });
                    return false;
                },
                cancelValue: '取消',
                cancel: function () { }
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
            <span>收款记录列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="received_money_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','只允许删除未出库货物，是否继续？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
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
                        <span class="lable">收款时间</span>
                        <asp:TextBox ID="txtBeginTime" runat="server" CssClass="keyword" onfocus="WdatePicker({ maxDate:'#F{$dp.$D(\'txtEndTime\',{d:-1})}'})"/>
                        <span class="lable">-</span>
                        <asp:TextBox ID="txtEndTime" runat="server" Text="bbb" CssClass="keyword" onfocus="WdatePicker({ minDate:'#F{$dp.$D(\'txtBeginTime\',{d:0})}'})"/>
                        <span class="lable">名称</span>
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
                            <th width="5%">选择</th>
                            <th align="left">客户</th>
                            <th align="left" width="8%">入库单号</th>
                            <th align="left" width="8%">名称</th>
                            <th align="left" width="8%">收款时间</th>
                            <th align="left" width="8%">计费数量</th>
                            <th align="left" width="10%">单价细则</th>
                            <th align="left" width="10%">总价</th>
                            <th align="left" width="8%">实收价格</th>
                            <th align="left" width="5%">操作人</th>
                            <th align="left" width="5%">备注</th>
                            <th align="left" width="5%">发票</th>
                            <th width="5%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Enabled='True' Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("Id")%>' runat="server" />
                        </td>
                        <td><%#Eval("CustomerName")%></td>
                        <td><%#Eval("AccountNumber")%></td>
                        <td><%#Eval("Name")%></td>
                        <td><%#Eval("ReceivedTime")%></td>
                        <td><%#Eval("ChargingCount")%></td>
                        <td><a href="javascript:void(0);" onclick="showContentDialog('单价明细','<%#Eval("UnitPriceDetails").ToString().Replace("\r\n", "")%>');">单价</a></td>
                        <td><%#Eval("TotalPrice")%></td>
                        <td><%#Eval("InvoicedPrice")%></td>
                        <td><%#Eval("Admin")%></td>
                        <td>
                            <a href="javascript:void(0);" onclick="showContentDialog('备注信息','<%#Eval("Remark").ToString()%>');">备注</a>
                        </td>
                        <td>
                            <%#Eval("HasBeenInvoiced").ToString().Equals("True")? "<a href=\"javascript:void(0);\" onclick=\"showContentDialog('发票信息', '开票时间："+Eval("InvoicedTime")+",开票人："+Eval("InvoicedOperator")+",价格："+Eval("InvoicedPrice")+"');\">发票</a>" : "<a href=\"javascript:void(0);\" onclick=\"doInvoiced("+Eval("Id")+");\">开发票</a>"%>
                        </td>
                        <td align="center">
                            <a href="received_money_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("Id")%>">修改</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"13\">暂无记录</td></tr>" : ""%>
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
