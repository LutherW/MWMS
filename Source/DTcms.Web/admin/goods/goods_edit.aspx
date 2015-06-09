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

            //创建上传附件
            $(".attach-btn").click(function () {
                var liHtml = '<li>'
                + '<a href="javascript:;" onclick="delAttributeNode(this);" class="del" title="删除属性"></a>'
                + '<div class="btns">属性名：<input type="text" name="AttributeName" value="" style="width:70%;"/></div>'
                + '<div class="btns">属性值：<input type="text" name="AttributeValue" value="" style="width:70%;"/></div>'
                + '<div class="btns">备&nbsp;&nbsp;&nbsp;注：<input type="text" name="AttributeRemark" value="" style="width:70%;"/></div>'
                + '</li>';

                $("#showAttachList ul").append(liHtml);
            });
        });

        function delAttributeNode(obj) {
            $(obj).parent().remove();
        }
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

        <div class="tab-content" style="min-height: 800px;">
            <dl>
                <dt>所属客户</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlCustomer" runat="server" datatype="*" errormsg="请选择客户" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>货物名称</dt>
                <dd>
                    <asp:TextBox ID="txtName" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
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
            <dl id="div_attach_container">
                <dt>货物属性</dt>
                <dd>
                    <a class="icon-btn add attach-btn"><span>添加属性</span></a>
                    <div id="showAttachList" class="attach-list">
                        <ul>
                            <asp:Repeater ID="rptAttributeList" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <a href="javascript:;" onclick="delAttributeNode(this);" class="del" title="删除属性"></a>
                                        <div class="btns">
                                            属性名：<input type="text" name="AttributeName" value="<%#Eval("AttributeName") %>" style="width: 70%;" />
                                        </div>
                                        <div class="btns">
                                            属性值：<input type="text" name="AttributeValue" value="<%#Eval("AttributeValue") %>" style="width: 70%;" />
                                        </div>
                                        <div class="btns">
                                            备&nbsp;&nbsp;&nbsp;注：<input type="text" name="AttributeRemark" value="<%#Eval("Remark") %>" style="width: 70%;" />
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </dd>
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
