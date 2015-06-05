<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_map.aspx.cs" Inherits="DTcms.Web.admin.dialog.dialog_map" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>坐标地址标注</title>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="http://api.map.baidu.com/api?v=2.0&ak=826e806b86676d155282de3d37188137"></script>
<script type="text/javascript" charset="utf-8" src="http://api.map.baidu.com/library/MarkerTool/1.2/src/MarkerTool_min.js"></script>
<script type="text/javascript" charset="utf-8" src="http://api.map.baidu.com/library/CityList/1.4/src/CityList_min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<style type="text/css">
	.content{position:relative;width:550px;height:350px;}
	#f_container{border:1px solid #999999;position:absolute;top:10px;left:10px;z-index:1000;font-size:14px;}
	#container{width:290px;overflow:hidden;height:20px;background:#F2F3F5;border:5px solid #F2F3F5;}
	#container select{border:1px solid #ccc;font-size:14px;}
</style>
<script type="text/javascript">
    var api = top.dialog.get(window); //获取父窗体对象
    //页面加载完成执行
    $(function () {
        //设置按钮及事件
        api.button([{
            value: '确定',
            callback: function () {
                $(api.data).parents("body").find("#txtXPoint").val($("#lat").val());
                $(api.data).parents("body").find("#txtYPoint").val($("#lng").val());
            },
            autofocus: true
        }, {
            value: '取消',
            callback: function () { return true; }
        }
        ]);
    });
</script>
</head>

<body>
<div class="content">
  <div id="f_container">
    <div id="container"></div>
  </div>
  <div id="allmap" style="width:550px;height:350px;"></div>
  <input type="hidden" id="lat" />
  <input type="hidden" id="lng" />
</div>
</body>
</html>
<script type="text/javascript">
    // 百度地图API功能
    var map = new BMap.Map("allmap");            // 创建Map实例
    map.enableScrollWheelZoom(true);
    map.addControl(new BMap.ScaleControl({ anchor: BMAP_ANCHOR_BOTTOM_RIGHT }));    // 右下比例尺
    map.setDefaultCursor("Crosshair"); //鼠标样式
    map.addControl(new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_RIGHT }));  //右上角，仅包含平移和缩放按钮
    var cityList = new BMapLib.CityList({
        container: 'container',
        map: map
    });
    map.addEventListener("click", showInfo);
    function showInfo(e) {
        map.clearOverlays();
        marker = new BMap.Marker(new BMap.Point(e.point.lng, e.point.lat));  // 创建标注
        map.addOverlay(marker);
        //获取经纬度
        document.getElementById("lng").value = e.point.lng;
        document.getElementById("lat").value = e.point.lat;
    }
</script>