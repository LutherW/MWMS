<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="received_money_edit.aspx.cs" Inherits="DTcms.Web.admin.business.received_money_edit" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,goods-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>编辑收款记录</title>
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
            <a href="received_money_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="received_money_list.aspx"><span>收款记录管理</span></a>
            <i class="arrow"></i>
            <span>编辑收款记录</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">基本信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content" style="min-height: 800px;">
            <dl>
                <dt>收款时间</dt>
                <dd>
                    <asp:TextBox ID="txtReceivedTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>客户</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlCustomer" runat="server" datatype="n" errormsg="请选择客户" sucmsg=" " AutoPostBack="True" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>入库单</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlSotreInOrder" runat="server" datatype="*" errormsg="请选择入库单" sucmsg=" " AutoPostBack="True" OnSelectedIndexChanged="ddlSotreInOrder_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>单价明细</dt>
                <dd>
                    <asp:HiddenField ID="hidReceivedEndTime" runat="server" Value="" />
                    <asp:HiddenField ID="hidReceivedBeginTime" runat="server" Value="" />
                    <asp:TextBox ID="txtUnitPriceDetails" runat="server" CssClass="input" TextMode="MultiLine"  ReadOnly="true" style="width:600px;" />
                </dd>
            </dl>
            <dl>
                <dt>计费数量</dt>
                <dd>
                    <asp:TextBox ID="txtChargingCount" runat="server" CssClass="input txt" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" " ReadOnly="true">0.00</asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>总价</dt>
                <dd>
                    <asp:TextBox ID="txtTotalMoney" runat="server" CssClass="input txt" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0.00</asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>实收金额</dt>
                <dd>
                    <asp:TextBox ID="txtInvoiceMoney" runat="server" CssClass="input txt" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0.00</asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>名称</dt>
                <dd>
                    <asp:TextBox ID="txtName" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " Text=""></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>是否已开发票：</dt>
                <dd>
                  <div class="rule-single-checkbox">
                    <asp:CheckBox ID="rblHasBeenInvoiced" runat="server" />
                  </div>
                  <span class="Validform_checktip"></span>
                </dd>
              </dl>
            <dl>
                <dt>开发票时间</dt>
                <dd>
                    <asp:TextBox ID="txtInvoicedTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>开发票人姓名</dt>
                <dd>
                    <asp:TextBox ID="txtInvoicedOperator" runat="server" CssClass="input normal" />
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>操作员</dt>
                <dd>
                    <asp:TextBox ID="txtAdmin" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " Text=""></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>描述说明</dt>
                <dd>
                    <asp:TextBox ID="txtRemark" runat="server" CssClass="input normal" TextMode="MultiLine" />
                    <span class="Validform_checktip"></span>
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
