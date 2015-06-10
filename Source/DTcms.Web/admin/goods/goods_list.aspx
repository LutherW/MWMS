<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goods_list.aspx.cs" Inherits="DTcms.Web.admin.goods.goods_list" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>货物管理</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        function showAttributeDialog(goodsId, goodsName) {
            var attachDialog = top.dialog({
                id: 'attachDialogId',
                title: goodsName + "属性",
                url: 'dialog/goods_attribute_list.aspx?goodsId=' + goodsId,
                width: 500,
                height: 180,
                onclose: function () {

                }
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
            <span>货物列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="goods_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','只允许删除已作废货物，是否继续？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                        <div class="menu-list">
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlCustomer" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlStoreMode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStoreMode_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlHandlingMode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlHandlingMode_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
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
                    <table width="100%" bgoods="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th width="8%">选择</th>
                            <th align="left">名称</th>
                            <th align="left" width="20%">客户</th>
                            <th align="left" width="10%">存储方式</th>
                            <th align="left" width="10%">装卸方式</th>
                            <th width="8%">计量单位</th>
                            <th width="8%">属性</th>
                            <th width="8%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Enabled='True' Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("Id")%>' runat="server" />
                        </td>
                        <td><a href="goods_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("Id")%>"><%#Eval("Name")%></a></td>
                        <td><%#Eval("CustomerName")%></td>
                        <td><%#Eval("StoreModeName")%></td>
                        <td><%#Eval("HandlingModeName")%></td>
                        <td align="center"><%#Eval("UnitName")%></td>
                        <td align="center">
                            <a href="javascript:void(0);" onclick="showAttributeDialog(<%#Eval("Id") %>, '<%#Eval("Name") %>');">属性</a>
                        </td>
                        <td align="center">
                            <a href="goods_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("Id")%>">修改</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
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
