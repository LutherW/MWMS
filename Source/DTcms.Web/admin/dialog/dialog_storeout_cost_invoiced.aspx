<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_storeout_cost_invoiced.aspx.cs" Inherits="DTcms.Web.admin.dialog.dialog_storeout_cost_invoiced" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitionalDTd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>打印订单窗口</title>
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        var api = top.dialog.get(window); //获取父窗体对象
        //页面加载完成执行
        $(function () {
            //设置按钮及事件
            //api.button([{
            //    value: '确认打印',
            //    callback: function () {
            //        printWin();
            //    },
            //    autofocus: true
            //}, {
            //    value: '取消',
            //    callback: function () { }
            //}]);
        });
        //打印方法
        function printWin() {
            var oWin = window.open("", "_blank");
            oWin.document.write(document.getElementById("content").innerHTML);
            oWin.focus();
            oWin.document.close();
            oWin.print();
            oWin.close();
            return false;
        }
    </script>
</head>

<body style="margin: 0;">
    <form id="form1" runat="server">
        <div id="content">
            <table width="800" border="0" align="center" cellpadding="3" cellspacing="0" style="font-size: 12px; font-family: '微软雅黑'; background: #fff;">
                <tr>
                    <td width="346" height="50" style="font-size: 16px;"><%=model.Name%>发票信息</td>
                    <td width="216">开票金额：￥<%=string.Format("{0:N2}", model.TotalPrice)%><br />
                        日&nbsp;&nbsp; 期：<%=model.InvoicedTime.Value.ToString("yyyy-MM-dd")%></td>
                    <td width="220">操&nbsp; 作 人：<%=model.InvoicedOperator%><br />
                        打印时间：<%=DateTime.Now%></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
