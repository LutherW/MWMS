/**
 * Slide menu plugin for App Framework UI
 * @copyright Intel
 *
 */;
(function($) {
    var startX, startY, dx, dy, blocking = false,
        checking = false,
        doMenu = true,
        showHide = false;
    $.ui.slideSideMenu = true;
    $.ui.fixedSideMenuWidth = 768;
    var keepOpen=false;
    $.ui.ready(function() {
        //  $("head").append("<style>#afui #menu {display:block !important}</style>");
        if ($.os.ie) return; //ie has the menu at the bottom
        // return;
		var afuiObj=document.getElementById('afui');
        var elems = $("#content, #header, #navbar");
        var $menu = $("#menu");
        var max = $("#menu").width();
        var slideOver = max/3;
        var menuState;
        var transTime = $.ui.transitionTime;
        $.ui.toggleSideMenu(false, null, 0);
        window.addEventListener("resize", function(e) {
            max = $("#menu").width();
        });
		
		afuiObj.addEventListener("touchstart",function(e){
        //$("#afui").bind("touchstart", function(e) {
			//alert("touchstart");
            startX = e.touches[0].pageX;
            startY = e.touches[0].pageY;

            checking = false;
            doMenu=false;
            keepOpen=false;
            if (window.innerWidth >= $.ui.fixedSideMenuWidth)
                doMenu = false,keepOpen=true;
            else
                doMenu = true;
            max = $("#menu").width();
			var menuStyleStr = $menu.attr("style");
			if(menuStyleStr.indexOf("display:none")>0 || menuStyleStr.indexOf("display: none")>0){
				menuState = false;
			}else{
				menuState = true;
			}
            //menuState = $menu.css("display") == "block";
			//console.log($("#menu").attr("style").indexOf("display: none"));
        },true);
		afuiObj.addEventListener("touchmove",function(e){
        //$("#afui").bind("touchmove", function(e) {
            if (!$.ui.isSideMenuEnabled()) return true;
            if (!$.ui.slideSideMenu||keepOpen) return true;
            dx = e.touches[0].pageX;
            dy = e.touches[0].pageY;
            if (!menuState && dx < startX) return true;
            if (menuState && dx > startX) return true;
            if (dx-startX > max) return true;
            if (startX-dx > max) return true;
            if (Math.abs(dy - startY) > Math.abs(dx - startX)) return true;
            
            if (!checking) {
                checking = true;
                doMenu=false;
                return true;
            } else { 
                doMenu=true;
            }
            
            showHide = dx - startX > 0 ? 2 : false;
            var thePlace = Math.abs(dx - startX);

            if (!showHide) {
                thePlace = max - thePlace;
                transTime = (thePlace / max) * numOnly($.ui.transitionTime);
            } else {
                transTime = ((max - thePlace) / max) * numOnly($.ui.transitionTime);
            }

            elems.cssTranslate(thePlace + "px,0");
            e.preventDefault();
            e.stopPropagation();
            
            if( Math.abs(dx-startX) < slideOver){
                showHide = showHide ? false : 2;
            }

        },false);
		afuiObj.addEventListener("touchend",function(e){
        //$("#afui").bind("touchend", function(e) {
            if (doMenu && checking&&!keepOpen) {
                $.ui.toggleSideMenu(showHide, null, transTime);
            }
            checking = false;
            doMenu = false;
            keepOpen=false;
        },false);
    });
})(af);
