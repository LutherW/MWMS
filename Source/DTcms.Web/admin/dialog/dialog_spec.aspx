<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_spec.aspx.cs" Inherits="DTcms.Web.admin.dialog.dialog_spec" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>商品规格</title>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    var api = top.dialog.get(window); //获取父窗体对象
    //页面加载完成执行
    $(function () {
        //设置按钮及事件
        api.button([{
            value: '确定',
            callback: function () {
                execSpecHtml();
            },
            autofocus: true
        }, {
            value: '取消',
            callback: function () { return true; }
        }
        ]);
        //初始化上传控件
        $(".upload-img").InitUploader({ sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf" });
        //修改状态，赋值给表单
        if ($(api.data).length > 0) {
            var parentObj = $(api.data).parent().parent();
            $("#txtTitle").val(parentObj.find("input[name='item_title']").val());
            $("#txtImgUrl").val(parentObj.find("input[name='item_imgurl']").val());
            $("#txtSortId").val(parentObj.find("input[name='item_sortid']").val());
        }
    });

    //创建选项节点
    function execSpecHtml() {
        var currDocument = $(document); //当前文档
        if ($("#txtTitle").val() == "") {
            top.dialog({
                title: '提示',
                content: '规格标题文字不可为空！',
                okValue: '确定',
                ok: function () { },
                onclose: function () {
                    $("#txtTitle", currDocument).focus();
                }
            }).showModal(api);
            return false;
        }
        if ($("#txtSortId").val() == "") {
            top.dialog({
                title: '提示',
                content: '规格排序不可为空！',
                okValue: '确定',
                ok: function () { },
                onclose: function () {
                    $("#txtSortId", currDocument).focus();
                }
            }).showModal(api);
            return false;
        }
        //创建选项节点的HTML
        if ($(api.data).length > 0) {
            var parentObj = $(api.data).parent().parent();
            parentObj.find("input[name='item_title']").val($("#txtTitle").val());
            parentObj.find(".item_title").html($("#txtTitle").val());
            parentObj.find("input[name='item_imgurl']").val($("#txtImgUrl").val());
            if ($("#txtImgUrl").val() == "") {
                parentObj.find(".item_imgurl").html("-");
            } else {
                parentObj.find(".item_imgurl").html('<img src="' + $("#txtImgUrl").val() + '" width="32" height="32" />');
            }
            parentObj.find("input[name='item_sortid']").val($("#txtSortId").val());
            parentObj.find(".item_sortid").html($("#txtSortId").val());
            api.close();
        } else {
            var imgHtml = "-";
            if ($("#txtImgUrl").val() != "") {
                imgHtml = '<img src="' + $("#txtImgUrl").val() + '" />';
            }
            var liHtml = '<tr class="td_c">'
            + '<td><input type="hidden" name="item_id" value="0" />'
            + '<input type="hidden" name="item_title" value="' + $("#txtTitle").val() + '" />'
            + '<span class="item_title">' + $("#txtTitle").val() + '</span></td>'
            + '<td><input type="hidden" name="item_imgurl" value="' + $("#txtImgUrl").val() + '" />'
            + '<span class="item_imgurl img-box">' + imgHtml + '</span></td>'
            + '<td><input type="hidden" name="item_sortid" value="' + $("#txtSortId").val() + '" />'
            + '<span class="item_sortid">' + $("#txtSortId").val() + '</span></td>'
            + '<td><a title="编辑" class="img-btn edit operator" onclick="showSpecDialog(this);">编辑</a>'
            + '<a title="删除" class="img-btn del operator" onclick="delItemTr(this);">删除</a></td>';
            api.close(liHtml).remove();
        }
        return false;
    }
</script>
</head>

<body>
<form id="form1" runat="server">
<div class="div-content">
  <dl>
    <dt>标题文字</dt>
    <dd><input type="text" id="txtTitle" class="input txt" /></dd>
  </dl>
  <dl>
    <dt>规格图片</dt>
    <dd>
      <input type="text" id="txtImgUrl" class="input txt upload-path" />
      <div class="upload-box upload-img"></div>
    </dd>
  </dl>
  <dl>
    <dt>排序数字</dt>
    <dd><input type="text" id="txtSortId" value="99" class="input txt small" onkeydown="return checkNumber(event);" /></dd>
  </dl>
  <dl>
    <dt></dt>
    <dd>提示：未上传图片则显示文字选项</dd>
  </dl>
</div>
</form>
</body>
</html>