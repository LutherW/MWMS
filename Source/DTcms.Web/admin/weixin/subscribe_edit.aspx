<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="subscribe_edit.aspx.cs" Inherits="DTcms.Web.admin.weixin.subscribe_edit" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>回复消息</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
        //初始化上传控件
        $(".upload-img").InitUploader({ filesize: "<%=siteConfig.imgsize %>", sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf", filetypes: "<%=siteConfig.fileextension %>" });
        $(".upload-video").InitUploader({ filesize: "<%=siteConfig.videosize %>", sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf", filetypes: "<%=siteConfig.videoextension %>" });
        //添加按钮(点击绑定)
        $("#itemAddButton").click(function () {
            showImgDialog();
        });
        //显示相关的容器
        showItemBox();
        //点击类型
        $("input[name='rblResponseType']").click(function () {
            showItemBox($(this).val());
        });
    });

    //显示相关的容器
    function showItemBox(num) {
        var objNum = arguments.length;
        var selectVal = $("input[name='rblResponseType']:checked").val();
        if (objNum == 1) {
            selectVal = num;
        }
        switch (selectVal) {
            case "1": //图文
                $(".text").hide();
                $(".sound").hide();
                $(".picture").show();
                break;
            case "2": //语音
                $(".text").hide();
                $(".sound").show();
                $(".picture").hide();
                break;
            default: //文字
                $(".text").show();
                $(".sound").hide();
                $(".picture").hide();
                break;
        }
    }

    //创建窗口
    function showImgDialog(obj) {
        var objNum = arguments.length;
        var d = top.dialog({
            width: 500,
            title: '添加图片',
            url: 'dialog/dialog_picture.aspx',
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
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>应用管理</span>
  <i class="arrow"></i>
  <span>微信管理</span>
  <i class="arrow"></i>
  <span><asp:Literal ID="litPosition1" runat="server" Text="关注回复"></asp:Literal></span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li>
          <a class="selected" href="javascript:;">
            <asp:Literal ID="litPosition2" runat="server" Text="关注回复"></asp:Literal>
          </a>
        </li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>消息类型</dt>
    <dd>
      <asp:HiddenField ID="hideId" runat="server" Value="0" />
      <asp:HiddenField ID="hideReqestType" runat="server" Value="0" />
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblResponseType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
          <asp:ListItem Value="0" Selected="True">文本回复</asp:ListItem>
          <asp:ListItem Value="1">图文回复</asp:ListItem>
          <asp:ListItem Value="2">语音回复</asp:ListItem>
         </asp:RadioButtonList>
       </div>
    </dd>
  </dl>

  <dl class="text">
    <dt>回复内容</dt>
    <dd>
      <asp:TextBox ID="txtContent" runat="server" CssClass="input" TextMode="MultiLine" style="width:100%;height:300px;" datatype="*0-1000" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*最多1000个字符</span>
    </dd>
  </dl>

  <dl class="sound" style="display:none;">
    <dt>语音标题</dt>
    <dd>
      <asp:TextBox ID="txtSoundTitle" runat="server" CssClass="input normal" datatype="*0-255" sucmsg=" " />
      <span class="Validform_checktip">*最多30个字符</span>
    </dd>
  </dl>
  <dl class="sound" style="display:none;">
    <dt>文件地址</dt>
    <dd>
      <asp:TextBox ID="txtSoundUrl" runat="server" CssClass="input normal upload-path" />
      <div class="upload-box upload-video"></div>
      <span class="Validform_checktip">*MP3格式，填写链接或本地上传！</span>
    </dd>
  </dl>
  <dl class="sound" style="display:none;">
    <dt>语音描述</dt>
    <dd>
      <asp:TextBox ID="txtSoundContent" runat="server" CssClass="input" TextMode="MultiLine" datatype="*0-500" sucmsg=" " />
    </dd>
  </dl>

  <dl class="picture" style="display:none;">
    <dt>图文列表</dt>
    <dd><a id="itemAddButton" class="icon-btn add"><i></i><span>添加图片</span></a></dd>
  </dl>
  <dl class="picture" style="display:none;">
    <dt></dt>
    <dd>
      <div class="table-container">
        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
          <thead>
              <tr>
                <th width="12%">图片</th>
                <th width="20%">标题</th>
                <th width="40%">链接</th>
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
                  <input type="hidden" name="item_content" value="<%#Eval("content")%>" />
                  <input type="hidden" name="item_imgurl" value="<%#Eval("img_url")%>" />
                  <span class="item_imgurl img-box"><%#Eval("img_url").ToString() == "" ? "-" : "<img src=\"" + Eval("img_url") + "\" />"%></span>
                </td>
                <td>
                  <input type="hidden" name="item_title" value="<%#Eval("title")%>" />
                  <span class="item_title"><%#Eval("title")%></span>
                </td>
                <td>
                  <input type="hidden" name="item_linkurl" value="<%#Eval("link_url")%>" />
                  <span class="item_linkurl"><%#Eval("link_url")%></span>
                </td>
                <td>
                  <input type="hidden" name="item_sortid" value="<%#Eval("sort_id")%>" />
                  <span class="item_sortid"><%#Eval("sort_id")%></span>
                </td>
                <td>
                  <a title="编辑" class="img-btn edit operator" onclick="showImgDialog(this);">编辑</a>
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
    <asp:Button ID="btnDelete" runat="server" Text="删除消息" CssClass="btn green" onclick="btnDelete_Click" Visible="false" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
</div>
<!--/工具栏-->

</form>
</body>
</html>
