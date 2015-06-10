<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="store_in_order_edit.aspx.cs" Inherits="DTcms.Web.admin.business.store_in_order_edit" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,goods-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>编辑待入库货物</title>
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
            $("#div_vehicle_container .attach-btn").click(function () {
                var vehicleDialog = top.dialog({
                    id: 'vehilcleDialogId',
                    title: "选择运输车辆",
                    url: '/admin/dialog/dialog_vehicle_list.aspx',
                    width: 700,
                    onclose: function () {

                    }
                }).showModal();
                vehicleDialog.data = $("#showVehicleList ul");
            });

            $("#div_attach_container .attach-btn").click(function () {
                showAttachDialog();
            });
        });

        //初始化附件窗口
        function showAttachDialog(obj) {
            var objNum = arguments.length;
            var attachDialog = top.dialog({
                id: 'attachDialogId',
                title: "上传附件",
                url: '/admin/dialog/dialog_attach.aspx',
                width: 500,
                height: 180,
                onclose: function () {
                    var liHtml = this.returnValue; //获取返回值
                    if (liHtml.length > 0) {
                        $("#showAttachList").children("ul").append(liHtml);
                    }
                }
            }).showModal();
            //如果是修改状态，将对象传进去
            if (objNum == 1) {
                attachDialog.data = obj;
            }
        }
        //删除附件节点
        function delAttachNode(obj) {
            $(obj).parent().remove();
        }

        function delNode(obj) {
            $(obj).parent().remove();
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="store_waiting.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="store_waiting.aspx"><span>待入库货物管理</span></a>
            <i class="arrow"></i>
            <span>编辑待入库货物</span>
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
                <dt>货物</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlGoods" runat="server" datatype="*" errormsg="请选择客户" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>计划入库时间</dt>
                <dd>
                    <asp:TextBox ID="txtStoringTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
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
            <dl id="div_vehicle_container">
                <dt>运输车辆</dt>
                <dd>
                    <a class="icon-btn add attach-btn"><span>选择车辆</span></a>
                    <div id="showVehicleList" class="attach-list">
                        <ul>
                            <asp:Repeater ID="rptGoodsVehicleList" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <a href="javascript:;" onclick="delNode(this);" class="del" title="删除"></a>
                                        <div class="btns">
                                            <input type="hidden" name="VehicleId" value="<%#Eval("VehicleId") %>" style="width: 70%;" />
                                            车牌号：<%#Eval("VehicleName") %>
                                        </div>
                                        <div class="btns">
                                            数&nbsp;&nbsp;&nbsp;量：<input type="text" name="Count" value="<%#Eval("Count") %>" style="width: 70%;" />
                                        </div>
                                        <div class="btns">
                                            备&nbsp;&nbsp;&nbsp;注：<input type="text" name="GoodsVehicleRemark" value="<%#Eval("Remark") %>" style="width: 70%;" />
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </dd>
            </dl>
            <dl id="div_attach_container" runat="server">
                <dt>上传附件</dt>
                <dd>
                    <a class="icon-btn add attach-btn"><span>添加附件</span></a>
                    <div id="showAttachList" class="attach-list">
                        <ul>
                            <asp:Repeater ID="rptAttachList" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <input name="hid_attach_filename" type="hidden" value="<%#Eval("Admin")%>" />
                                        <input name="hid_attach_filepath" type="hidden" value="<%#Eval("FilePath")%>" />
                                        <i class="icon"></i>
                                        <a href="javascript:;" onclick="delAttachNode(this);" class="del" title="删除附件"></a>
                                        <a href="javascript:;" onclick="showAttachDialog(this);" class="edit" title="更新附件"></a>
                                        <div class="title"><%#Eval("Admin")%></div>
                                        <div class="btns">备注：<input type="text" name="txt_attach_remark" value="<%#Eval("Remark") %>" style="width: 70%;"/></div>
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
