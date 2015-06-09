<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goods_edit.aspx.cs" Inherits="DTcms.Web.admin.goods.goods_edit" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,goods-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>编辑货物</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
</script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="goods_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="goods_list.aspx"><span>货物管理</span></a>
            <i class="arrow"></i>
            <span>编辑货物</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">基本资料</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content" style="min-height:800px;">
            <dl>
                <dt>所属客户</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlCustomer" runat="server" datatype="*" errormsg="请选择客户" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>存储方式</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlStoreMode" runat="server" datatype="*" errormsg="请选择存储方式" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>装卸方式</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlHandlingMode" runat="server" datatype="*" errormsg="请选择装卸方式" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>计量单位</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlUnit" runat="server" datatype="*" errormsg="请选择计量单位" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>货物名称</dt>
                <dd>
                    <asp:TextBox ID="txtName" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            
        </div>

        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>
