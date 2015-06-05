<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="spec_edit.aspx.cs" Inherits="DTcms.Web.admin.channel.spec_edit" ValidateRequest="false" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑规格</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
        //添加按钮(点击绑定)
        $("#itemAddButton").click(function () {
            showSpecDialog();
        });
    });

    //创建窗口
    function showSpecDialog(obj) {
        var objNum = arguments.length;
        var d = top.dialog({
            width: 500,
            height: 180,
            title: '商品规格',
            url: 'dialog/dialog_spec.aspx',
            onclose: function () {
                var trHtml = this.returnValue;
                if (trHtml.length > 0) {
                    $("#item_box").append(trHtml);
                }
            }
        }).showModal();
        //检查是否修改状态
        if (objNum == 1) {
            d.data = obj;
        }
    }

    //删除节点
    function delItemTr(obj) {
        $(obj).parent().parent().remove();
    }
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="spec_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="spec_list.aspx"><span>规格管理</span></a>
  <i class="arrow"></i>
  <span>编辑规格</span>
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

<div class="tab-content">
  <dl>
    <dt>规格名称</dt>
    <dd>
      <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal"  datatype="s2-100" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*规格的中文名称。</span>
    </dd>
  </dl>
  <dl>
    <dt>备注说明</dt>
    <dd>
      <asp:TextBox ID="txtRemark" runat="server" CssClass="input" TextMode="MultiLine" datatype="*0-255" sucmsg=" " />
      <span class="Validform_checktip">非必填，最多255字符</span>
    </dd>
  </dl>
  <dl>
    <dt>排序数字</dt>
    <dd>
      <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
      <span class="Validform_checktip">*数字，越小越向前</span>
    </dd>
  </dl>
  <dl>
    <dt>规格选项</dt>
    <dd><a id="itemAddButton" class="icon-btn add"><i></i><span>添加选项</span></a></dd>
  </dl>
  <dl>
    <dt></dt>
    <dd>
      <div class="table-container">
        <table border="0" cellspacing="0" cellpadding="0" class="border-table">
          <thead>
              <tr>
                <th width="12%">文字</th>
                <th width="16%">图片</th>
                <th width="12%">排序</th>
                <th width="10%">操作</th>
              </tr>
            </thead>
            <tbody id="item_box">
              <asp:Repeater ID="rptList" runat="server">
              <ItemTemplate>
              <tr class="td_c">
                <td>
                  <input type="hidden" name="item_id" value="<%#Eval("id")%>" />
                  <input type="hidden" name="item_title" value="<%#Eval("title")%>" />
                  <span class="item_title"><%#Eval("title")%></span>
                </td>
                <td>
                  <input type="hidden" name="item_imgurl" value="<%#Eval("img_url")%>" />
                  <span class="item_imgurl img-box"><%#Eval("img_url").ToString() == "" ? "-" : "<img src=\"" + Eval("img_url") + "\" />"%></span>
                </td>
                <td>
                  <input type="hidden" name="item_sortid" value="<%#Eval("sort_id")%>" />
                  <span class="item_sortid"><%#Eval("sort_id")%></span>
                </td>
                <td>
                  <a title="编辑" class="img-btn edit operator" onclick="showSpecDialog(this);">编辑</a>
                  <a title="删除" class="img-btn del operator" onclick="delItemTr(this);">删除</a>
                </td>
              </tr>
              </ItemTemplate>
              </asp:Repeater>
            </tbody>
        </table>
      </div>
    </dd>
  </dl>
</div>
<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-wrap">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
</div>
<!--/工具栏-->

</form>
</body>
</html>
