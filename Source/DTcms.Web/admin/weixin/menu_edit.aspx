<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu_edit.aspx.cs" Inherits="DTcms.Web.admin.weixin.menu_edit" ValidateRequest="false" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑自定义菜单</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
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
  <a href="account_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>应用管理</span>
  <i class="arrow"></i>
  <span>微信管理</span>
  <i class="arrow"></i>
  <span>编辑自定义菜单</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">自定义菜单</a></li>
        <li><a href="javascript:;">使用说明</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>一级菜单</dt>
    <dd>
      <div class="table-container">
        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
          <thead>
            <tr>
              <th width="33.333%" colspan="2">第一列</th>
              <th width="33.333%" colspan="2">第二列</th>
              <th width="33.333%" colspan="2">第三列</th>
            </tr>
          </thead>
          <tbody>
            <tr class="td_c">
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtTop1Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtTop2Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtTop3Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
            <tr class="td_c">
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtTop1Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtTop2Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtTop3Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
            <tr class="td_c">
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtTop1Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtTop2Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtTop3Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>二级菜单NO.1</dt>
    <dd>
      <div class="table-container">
        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
          <tbody>
            <tr class="td_c">
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtMenu11Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtMenu21Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtMenu31Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
            <tr class="td_c">
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtMenu11Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtMenu21Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtMenu31Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
            <tr class="td_c">
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtMenu11Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtMenu21Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtMenu31Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>二级菜单NO.2</dt>
    <dd>
      <div class="table-container">
        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
          <tbody>
            <tr class="td_c">
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtMenu12Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtMenu22Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtMenu32Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
            <tr class="td_c">
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtMenu12Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtMenu22Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtMenu32Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
            <tr class="td_c">
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtMenu12Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtMenu22Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtMenu32Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>二级菜单NO.3</dt>
    <dd>
      <div class="table-container">
        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
          <tbody>
            <tr class="td_c">
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtMenu13Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtMenu23Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtMenu33Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
            <tr class="td_c">
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtMenu13Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtMenu23Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtMenu33Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
            <tr class="td_c">
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtMenu13Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtMenu23Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtMenu33Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>二级菜单NO.4</dt>
    <dd>
      <div class="table-container">
        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
          <tbody>
            <tr class="td_c">
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtMenu14Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtMenu24Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtMenu34Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
            <tr class="td_c">
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtMenu14Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtMenu24Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtMenu34Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
            <tr class="td_c">
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtMenu14Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtMenu24Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtMenu34Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>二级菜单NO.5</dt>
    <dd>
      <div class="table-container">
        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
          <tbody>
            <tr class="td_c">
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtMenu15Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtMenu25Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">名称：</td>
              <td>
                <asp:TextBox ID="txtMenu35Name" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
            <tr class="td_c">
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtMenu15Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtMenu25Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">KEY：</td>
              <td>
                <asp:TextBox ID="txtMenu35Key" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
            <tr class="td_c">
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtMenu15Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtMenu25Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
              <td width="10%">URL：</td>
              <td>
                <asp:TextBox ID="txtMenu35Url" runat="server" class="td-input" Width="95%"></asp:TextBox>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
   </dd>
  </dl>
</div>

<div class="tab-content" style="display:none">
  <dl>
    <dt>注意事项说明</dt>
    <dd>
      <p>1、自定义菜单最多包括3个一级菜单，每个一级菜单最多包含5个二级菜单。</p>
      <p>2、一级菜单最多4个汉字，二级菜单最多7个汉字，多出来的部分将会以“...”代替。</p>
      <p>3、创建自定义菜单后，由于微信客户端缓存，需要24小时微信客户端才会展现出来。测试时可以尝试取消关注公众账号后再次关注，则可以看到创建后的效果。</p>
    </dd>
  </dl>
  <dl>
    <dt>按钮类型说明</dt>
    <dd>
      <p><b>1、click：点击推事件</b></p>
      <p>用户点击click类型按钮后，微信服务器会通过消息接口推送消息类型为event的结构给开发者（参考消息接口指南），并且带上按钮中开发者填写的key值，开发者可以通过自定义的key值与用户进行交互；
      <p><b>2、view：跳转URL</b></p>
      <p>用户点击view类型按钮后，微信客户端将会打开开发者在按钮中填写的网页URL，可与网页授权获取用户基本信息接口结合，获得用户基本信息。</p>
      <p><b>3、scancode_push：扫码推事件</b></p>
      <p>用户点击按钮后，微信客户端将调起扫一扫工具，完成扫码操作后显示扫描结果（如果是URL，将进入URL），且会将扫码的结果传给开发者，开发者可以下发消息。</p>
      <p><b>4、scancode_waitmsg：扫码推事件且弹出“消息接收中”提示框</b></p>
      <p>用户点击按钮后，微信客户端将调起扫一扫工具，完成扫码操作后，将扫码的结果传给开发者，同时收起扫一扫工具，然后弹出“消息接收中”提示框，随后可能会收到开发者下发的消息。</p>
      <p><b>5、pic_sysphoto：弹出系统拍照发图</b></p>
      <p>用户点击按钮后，微信客户端将调起系统相机，完成拍照操作后，会将拍摄的相片发送给开发者，并推送事件给开发者，同时收起系统相机，随后可能会收到开发者下发的消息。</p>
      <p><b>6、pic_photo_or_album：弹出拍照或者相册发图</b></p>
      <p>用户点击按钮后，微信客户端将弹出选择器供用户选择“拍照”或者“从手机相册选择”。用户选择后即走其他两种流程。</p>
      <p><b>7、pic_weixin：弹出微信相册发图器</b></p>
      <p>用户点击按钮后，微信客户端将调起微信相册，完成选择操作后，将选择的相片发送给开发者的服务器，并推送事件给开发者，同时收起相册，随后可能会收到开发者下发的消息。</p>
      <p><b>8、location_select：弹出地理位置选择器</b></p>
      <p>用户点击按钮后，微信客户端将调起地理位置选择工具，完成选择操作后，将选择的地理位置发送给开发者的服务器，同时收起位置选择工具，随后可能会收到开发者下发的消息。</p>
      <p><b>9、media_id：下发消息（除文本消息）</b></p>
      <p>用户点击media_id类型按钮后，微信服务器会将开发者填写的永久素材id对应的素材下发给用户，永久素材类型可以是图片、音频、视频、图文消息。请注意：永久素材id必须是在“素材管理/新增永久素材”接口上传后获得的合法id。</p>
      <p><b>10、view_limited：跳转图文消息URL</b></p>
      <p>用户点击view_limited类型按钮后，微信客户端将打开开发者在按钮中填写的永久素材id对应的图文消息URL，永久素材类型只支持图文消息。请注意：永久素材id必须是在“素材管理/新增永久素材”接口上传后获得的合法id。</p>
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
