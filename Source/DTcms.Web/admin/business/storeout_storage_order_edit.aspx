<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="storeout_storage_order_edit.aspx.cs" Inherits="DTcms.Web.admin.business.storeout_storage_order_edit" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,goods-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>编辑出库单</title>
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

            // 设置费用项
            $("#div_cost_container .attach-btn").click(function () {
                var liHtml = '<li>'
                + '<a href="javascript:;" onclick="delNode(this);" class="del" title="删除"></a>'
                + '<div class="btns">名称：<input type="text" name="CostName" value="" style="width: 70%;" /></div>'
                + '<div class="btns">单价：<input type="text" name="CostUnitPrice" onkeydown="return checkForFloat(this,event);" value="0.00" style="width: 50%;" /></div>'
                + '<div class="btns">数量：<input type="text" name="CostCount" onkeydown="return checkForFloat(this,event);" value="0.00" style="width: 70%;" /></div>'
                + '<div class="btns">类型：<select name="CostType"><option value="+" selected=\'selected\'>收入</option><option value="-">支出</option></select></div>'
                + '<div class="btns">总价：<input type="text" name="CostTotalPrice" onkeydown="return checkForFloat(this,event);" value="0.00" style="width: 70%;" /></div>'
                + '<div class="btns">客户：<input type="text" name="CostCustomer" value="" style="width: 70%;" /></div>'
                + '</li>';

                $("#showCostList ul").append(liHtml);
            });

            //设置出库货物
            $("#div_goods_container .attach-btn").click(function () {
                var vehicleDialog = top.dialog({
                    id: 'goodsDialogId',
                    title: "选择出库货物",
                    url: '/admin/dialog/dialog_storeout_waiting_goods.aspx?storein_order_id=' + $("#ddlStoreInOrder").val(),
                    width: 700,
                    onclose: function () {

                    }
                }).showModal();
                vehicleDialog.data = $("#showGoodsList ul");
            });

            $("#txtChargingCount").blur(function () {
                var val = $(this).val();
                if (!isNaN(val)) {
                    var totalMoney = $("#hidUnitPrice").val() * val;
                    $("#txtTotalMoney").val(totalMoney);
                }
            });

        });

        
        function delNode(obj) {
            $(obj).parent().remove();
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="store_out_order.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="store_out_order.aspx"><span>出库单管理</span></a>
            <i class="arrow"></i>
            <span>编辑出库单</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">基本信息</a></li>
                        <li><a href="javascript:;">费用项</a></li>
                        <li><a href="javascript:;">出库货物</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content" style="min-height: 800px;">
            <dl>
                <dt>出库时间</dt>
                <dd>
                    <asp:TextBox ID="txtStoredOutTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>出库数量</dt>
                <dd>
                    <asp:TextBox ID="txtChargingCount" runat="server" CssClass="input txt" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0.00</asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>入库单</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlStoreInOrder" runat="server" datatype="*" errormsg="请选择入库单" sucmsg=" " AutoPostBack="True" OnSelectedIndexChanged="ddlStoreInOrder_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>客户</dt>
                <dd>
                    <asp:HiddenField ID="hidCustomerId" runat="server" Value="0" />
                    <asp:Label ID="labCustomerName" runat="server" Text=""></asp:Label>
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
                <dt>总价</dt>
                <dd>
                    <asp:TextBox ID="txtTotalMoney" runat="server" CssClass="input txt" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0.00</asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>发票金额</dt>
                <dd>
                    <asp:TextBox ID="txtInvoiceMoney" runat="server" CssClass="input txt" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0.00</asp:TextBox>
                    <span class="Validform_checktip">*</span>
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

        <div class="tab-content" style="display: none;">
            <dl id="div_cost_container" runat="server">
                <dt>费用</dt>
                <dd>
                    <a class="icon-btn add attach-btn"><span>添加费用项</span></a>
                    <div id="showCostList" class="attach-list">
                        <ul>
                            <asp:Repeater ID="rptCostList" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <a href="javascript:;" onclick="delNode(this);" class="del" title="删除"></a>
                                        <div class="btns">
                                            名称：<input type="text" name="CostName" value="<%#Eval("Name")%>" style="width: 70%;" />
                                        </div>
                                        <div class="btns">
                                            单价：<input type="text" name="CostUnitPrice" onkeydown="return checkForFloat(this,event);" value="<%#Eval("UnitPrice") %>" style="width: 70%;" />
                                        </div>
                                        <div class="btns">
                                            数量：<input type="text" name="CostCount" onkeydown="return checkForFloat(this,event);" value="<%#Eval("Count") %>" style="width: 70%;" />
                                        </div>
                                        <div class="btns">
                                            类型：<select name="CostType"><option value="+" <%#Convert.ToDecimal(Eval("TotalPrice")) >= 0? "selected='selected'" : "" %>>收入</option>
                                                <option value="-" <%#Convert.ToDecimal(Eval("TotalPrice")) < 0? "selected='selected'" : "" %>>支出</option>
                                            </select>
                                        </div>
                                        <div class="btns">
                                            总价：<input type="text" name="CostTotalPrice" onkeydown="return checkForFloat(this,event);" value="<%#Math.Abs(Convert.ToDecimal(Eval("TotalPrice"))) %>" style="width: 70%;" />
                                        </div>
                                        <div class="btns">
                                            客户：<input type="text" name="CostCustomer" value="<%#Eval("Customer") %>" style="width: 70%;" />
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </dd>
            </dl>
        </div>
        <div class="tab-content" style="display: none;">
            <dl id="div_goods_container" runat="server">
                <dt>出库货物</dt>
                <dd>
                    <a class="icon-btn add attach-btn"><span>添加出库货物</span></a>
                    <div id="showGoodsList" class="attach-list">
                        <ul>
                            <asp:Repeater ID="rptGoodsList" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <a href="javascript:;" onclick="delNode(this);" class="del" title="删除"></a>
                                        <div class="btns">
                                            <input type="hidden" name="StoreOutWaitingGoodsId" value="<%#Eval("StoreOutWaitingGoodsId") %>" />
                                            <input type="hidden" name="StoreInOrderId" value="<%#Eval("StoreInOrderId") %>" />
                                            <input type="hidden" name="StoreInGoodsId" value="<%#Eval("StoreInGoodsId") %>" />
                                            货物：<%#Eval("GoodsName").ToString()%>
                                        </div>
                                        <div class="btns">
                                            库存量：<%#Eval("StoredInCount").ToString()%>
                                        </div>
                                        <div class="btns">
                                            出库量：<input type="text" name="StoreOutCount" value="<%#Eval("Count") %>" style="width: 70%;" />
                                        </div>
                                        <div class="btns">
                                            备注：<input type="text" name="StoreOutGoodsRemark" value="<%#Eval("Remark") %>" style="width: 70%;" />
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
