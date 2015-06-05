/* 
*作者：一些事情
*时间：2015-4-17
*购物车方法*需要结合jquery一起使用
----------------------------------------------------------*/
//商品数量加减一
function addCartNum(num){
	var numObj = $("#commoditySelectNum");
	var selectNum = 0;
	if(numObj.val().length > 0){
		selectNum = parseInt(numObj.val());
	}
	selectNum += num;
	//最小值
	if(selectNum < 1){
		selectNum = 1;
	}
	//最大值
	if(selectNum > parseInt(numObj.attr("maxValue"))){
		selectNum = parseInt(numObj.attr("maxValue"));
	}
	numObj.val(selectNum);
}
//初始化商品规格事件
function initGoodsSpec(sendUrl){
	//检查是否有规格
	if($("#goodsSpecBox dl").length == 0){
		$("#buyButton button").prop("disabled",false).removeClass("over");
	}
	//遍历规格属性
	$("#goodsSpecBox dl dd ul li a").each(function(){
		$(this).click(function(){
			if(!$(this).hasClass("selected")){
				//标签选中状态
				$(this).parent().siblings("li").children("a").removeClass("selected");
				$(this).addClass("selected");
				//获取商品价格
				if($("#goodsSpecBox dl dd ul li a.selected").length == $("#goodsSpecBox dl").length){
					var specIds = '';
					$("#goodsSpecBox dl dd ul li a.selected").each(function(i) {
						if(i == 0){
							specIds = ",";
						}
                        specIds += $(this).attr("specid") + ',';
                    });
					//发送异步请求
					$.ajax({
						type: "POST",
						url: sendUrl,
						dataType: "json",
						data: {
							"article_id": $("#commodityArticleId").val(),
							"ids": specIds
						},
						timeout: 20000,
						success: function(data, textStatus) {
							if (data.status == 1){
								$("#commodityGoodsId").val(data.goods_id);
								$("#commodityGoodsNo").text(data.goods_no);
								$("#commodityMarketPrice").text('¥' + data.market_price);
								$("#commoditySellPrice").text('¥' + data.sell_price);
								$("#commodityStockNum").text(data.stock_quantity);
								$("#commoditySelectNum").attr("maxValue",data.stock_quantity);
								//检查是否足够库存
								if(parseInt(data.stock_quantity) > 0){
									$("#buyButton button").prop("disabled",false).removeClass("over");
								}else{
									$("#buyButton button").prop("disabled",false).removeClass("over");
								}
							} else {
								alert(data.msg);
							}
						},
						error: function (XMLHttpRequest, textStatus, errorThrown) {
							alert("查询出错：" + textStatus + ",提示：" + errorThrown);
						}
					});
				}
			}
		});
	});
}

//删除元素
function hintRemove(obj){
	$(obj).remove();
}

//添加进购物车
function cartAdd(obj, webpath, linktype, linkurl){
	var articleId = parseInt($("#commodityArticleId").val());
	var goodsId = parseInt($("#commodityGoodsId").val());
	var selectNum = parseInt($("#commoditySelectNum").val());
	if($(obj).prop("disabled") == true){
		return false;
	}
	//检查文章ID
	if(isNaN(articleId)){
		alert("商品参数不正确！");
		return false;
	}
	//检查商品是否有规格
	if(goodsId == 0 && $("#goodsSpecBox dl").length > 0){
		alert("请先选择商品规格！");
		return false;
	}
	//检查购买数量
	if(isNaN(selectNum) || selectNum == 0){
		alert("购买数量不能为零！");
		return false;
	}
	//检查库存数量
	if(parseInt(selectNum) > parseInt($("#commodityStockNum").text())){
		alert("购买数量大于库存数量，库存不足！");
		return false;
	}
	//记住按钮文字
	var buttonText = $(obj).text();
	//如果是立即购买
	if(linktype == 1){
		var jsondata = '[{"article_id":'+articleId+', "goods_id":'+goodsId+', "quantity":'+selectNum+'}]'; //结合商品参数
		$.ajax({
			type: "post",
			url: webpath + "tools/submit_ajax.ashx?action=cart_goods_buy",
			data: { "jsondata": jsondata },
			dataType: "json",
			beforeSend: function(XMLHttpRequest) {
				//发送前动作
				$(obj).prop("disabled",true).text("请稍候...");
			},
			success: function(data, textStatus) {
				if (data.status == 1) {
					location.href = linkurl;
				}else{
					alert("尝试加入购物清单失败，请重试！");
				}
			},
			error: function (XMLHttpRequest, textStatus, errorThrown) {
				alert("状态：" + textStatus + "；出错提示：" + errorThrown);
			},
			complete: function (XMLHttpRequest, textStatus) {
				$(obj).prop("disabled",false).text(buttonText);
			},
			timeout: 20000
		});
		return false;
	}else{
		$.ajax({
			type: "post",
			url: webpath + "tools/submit_ajax.ashx?action=cart_goods_add",
			data: {
				"article_id" : articleId,
				"goods_id" : goodsId,
				"quantity" : selectNum
			},
			dataType: "json",
			beforeSend: function(XMLHttpRequest) {
				//发送前动作
				$(obj).prop("disabled",true).text("请稍候...");
			},
			success: function(data, textStatus) {
				if (data.status == 1) {
					$("#cartInfoHint").remove();
					var HintHtml = '<div id="cartInfoHint" class="msg-tips cart-info">'
						+ '<div class="ico"></div>'
						+ '<div class="msg">'
						+ '<strong>商品已成功添加到购物车！</strong>'
						+ '<p>购物车共有<b>' + data.quantity + '</b>件商品，合计：<b class="red">' + data.amount + '</b>元</p>'
						+ '<a class="btn btn-success" title="去购物车结算" href="' + linkurl + '">去结算</a>&nbsp;&nbsp;'
						+ '<a title="再逛逛" href="javascript:;" onclick="hintRemove(\'#cartInfoHint\');">再逛逛</a>'
						+ '<i class="close" title="关闭" onclick="hintRemove(\'#cartInfoHint\');"><span>关闭</span></i>'
						+ '</div>'
						+ '</div>'
					$(obj).after(HintHtml); //添加节点
					$("#shoppingCartCount").text(data.quantity); //赋值给显示购物车数量的元素
				} else {
					$("#cartInfoHint").remove();
					var HintHtml = '<div id="cartInfoHint" class="msg-tips cart-info">'
						+ '<div class="ico error"></div>'
						+ '<div class="msg">'
						+ '<strong>商品添加到购物车失败！</strong>'
						+ '<p>' + data.msg + '</p>'
						+ '<i class="close" title="关闭" onclick="hintRemove(\'#cartInfoHint\');"><span>关闭</span></i>'
						+ '</div>'
						+ '</div>'
					$(obj).after(HintHtml); //添加节点
				}
			},
			error: function (XMLHttpRequest, textStatus, errorThrown) {
				alert("状态：" + textStatus + "；出错提示：" + errorThrown);
			},
			complete: function (XMLHttpRequest, textStatus) {
				$(obj).prop("disabled",false).text(buttonText);
			},
			timeout: 20000
		});
		return false;
	}
}

//修改购物车数量
function updateCart(obj, webpath, num){
	var objInput;
	var goodsQuantity; //购买数量
	var stockQuantity = parseInt($(obj).parents("tr").find("input[name='hideStockQuantity']").val()); //库存数量
	var articleId = $(obj).parents("tr").find("input[name='hideArticleId']").val(); //文章ID
	var goodsId = $(obj).parents("tr").find("input[name='hideGoodsId']").val(); //商品ID
	var goodsPrice = $(obj).parents("tr").find("input[name='hideGoodsPrice']").val(); //商品单价
	var goodsPoint = $(obj).parents("tr").find("input[name='hidePoint']").val(); //商品积分
	if(arguments.length == 2){
		objInput = $(obj);
		goodsQuantity = parseInt(objInput.val());
	}else{
		objInput = $(obj).siblings("input[name='goodsQuantity']");
		goodsQuantity = parseInt(objInput.val()) + parseInt(num);
	}
	if(isNaN(goodsQuantity)){
		alert('商品数量只能输入数字!');
		return false;
	}
	if(isNaN(stockQuantity)){
		alert('检测不到商品库存数量!');
		return false;
	}
	if(goodsQuantity < 1){
		goodsQuantity = 1;
	}
	if(goodsQuantity > stockQuantity){
		alert('购买数量不能大于库存数量!');
		goodsQuantity = stockQuantity;
	}
	$.ajax({
		type: "post",
		url: webpath + "tools/submit_ajax.ashx?action=cart_goods_update",
		data: {
			"article_id" : articleId,
			"goods_id" : goodsId,
			"quantity" : goodsQuantity
		},
		dataType: "json",
		beforeSend: function(XMLHttpRequest) {
			//发送前动作
		},
		success: function(data, textStatus) {
			if (data.status == 1) {
				objInput.val(goodsQuantity);
				var totalPrice = parseFloat(goodsPrice)*goodsQuantity; //金额
				var totalPoint = parseFloat(goodsPoint)*goodsQuantity; //积分
				$(obj).parents("tr").find("label[name='amountCount']").text(totalPrice.toFixed(2));
				if(totalPoint > 0){
					$(obj).parents("tr").find("label[name='pointCount']").text("+"+totalPoint);
				}else{
					$(obj).parents("tr").find("label[name='pointCount']").text(totalPoint);
				}
				cartAmountTotal(); //重新统计
			} else {
				alert(data.msg);
			}
		},
		error: function (XMLHttpRequest, textStatus, errorThrown) {
			alert("状态：" + textStatus + "；出错提示：" + errorThrown);
		},
		timeout: 20000
	});
	return false;
}

//删除购物车商品
function deleteCart(webpath, obj){
	if(!confirm("您确认要从购物车中移除吗？")){
		return false;
	}
	//组合参数
	var datastr;
	var arglength = arguments.length; //参数个数
	if(arglength == 1){
		datastr = {"clear": 1}
	}else{
		var articleId = $(obj).parents("tr").find("input[name='hideArticleId']").val();
		var goodsId = $(obj).parents("tr").find("input[name='hideGoodsId']").val();
		datastr = {"article_id": articleId, "goods_id": goodsId}
	}
	$.ajax({
		type: "post",
		url: webpath + "tools/submit_ajax.ashx?action=cart_goods_delete",
		data: datastr,
		dataType: "json",
		beforeSend: function(XMLHttpRequest) {
			//发送前动作
		},
		success: function(data, textStatus) {
			if (data.status == 1) {
				if(arglength == 1){
					location.reload();
				}else{
					$(obj).parents("tr").remove();
					cartAmountTotal(); //重新统计
				}
			} else {
				alert(data.msg);
			}
		},
		error: function (XMLHttpRequest, textStatus, errorThrown) {
			alert("状态：" + textStatus + "；出错提示：" + errorThrown);
		},
		timeout: 20000
	});
	return false;
}

//选择商品
function selectCart(obj){
	var arglength = arguments.length; //参数个数
	if(arglength == 1){
		if($(obj).text()=="全选"){
			$(obj).text("取消");
			$(".checkall").prop("checked", true);
		}else{
			$(obj).text("全选");
			$(".checkall").prop("checked", false);
		}
	}
	cartAmountTotal(); //统计商品
}

//计算购物车金额
function cartAmountTotal(){
	var jsondata = ""; //商品组合参数
	var totalAmount = 0; //商品总计
	$(".checkall:checked").each(function(i) {
		var articleId = $(this).parents("tr").find("input[name='hideArticleId']").val(); //文章ID
		var goodsId = $(this).parents("tr").find("input[name='hideGoodsId']").val(); //商品ID
        var goodsPrice = $(this).parents("tr").find("input[name='hideGoodsPrice']").val(); //商品单价
		var goodsQuantity = $(this).parents("tr").find("input[name='goodsQuantity']").val(); //购买数量
		totalAmount += parseFloat(goodsPrice) * parseFloat(goodsQuantity);
		jsondata += '{"article_id":"'+articleId+'", "goods_id":"'+goodsId+'", "quantity":"'+goodsQuantity+'"}';
		if(i < $(".checkall:checked").length-1){
			jsondata += ',';
		}
    });
	$("#totalQuantity").text($(".checkall:checked").length);
	$("#totalAmount").text(totalAmount.toFixed(2));
	if(jsondata.length > 0){
		jsondata = '[' + jsondata + ']';
	}
	$("#jsondata").val(jsondata);
}

//进入结算中心
function formSubmit(obj, webpath, linkurl){
	var jsondata = $("#jsondata").val();
	if(jsondata == ""){
		alert("未选中要购买的商品，请选中后提交！");
		return false;
	}
	//记住按钮文字
	var buttonText = $(obj).text();
	//加入购物清单
	$.ajax({
		type: "post",
		url: webpath + "tools/submit_ajax.ashx?action=cart_goods_buy",
		data: { "jsondata": jsondata },
		dataType: "json",
		beforeSend: function(XMLHttpRequest) {
			//发送前动作
			$(obj).prop("disabled",true).text("请稍候...");
		},
		success: function(data, textStatus) {
			if (data.status == 1) {
				location.href = linkurl;
			}else{
				$(obj).prop("disabled",false).text(buttonText);
				alert("尝试进入结算中心失败，请重试！");
			}
		},
		error: function (XMLHttpRequest, textStatus, errorThrown) {
			$(obj).prop("disabled",false).text(buttonText);
			alert("状态：" + textStatus + "；出错提示：" + errorThrown);
		},
		timeout: 20000
	});
	return false;
}

/*初始化收货地址*/
function initUserAddress(obj){
	//初始化省市区
	var mypcas = new PCAS("province,所属省份","city,所属城市","area,所属地区");
	//初始化地址
	$(obj).children("li").each(function() {
		//初始化值
		if($(this).hasClass("selected")){
			$("#book_id").val($(this).find("input[name='user_book_id']").val());
			$("#accept_name").val($(this).find("input[name='user_accept_name']").val());
			$("#address").val($(this).find("input[name='user_address']").val());
			$("#mobile").val($(this).find("input[name='user_mobile']").val());
			$("#telphone").val($(this).find("input[name='user_telphone']").val());
			$("#email").val($(this).find("input[name='user_email']").val());
			$("#post_code").val($(this).find("input[name='user_post_code']").val());
			$(this).find("input[name='user_book_id']").prop("checked", true); //设置选中
			//改变省市区
			var areaArr = $(this).find("input[name='user_area']").val().split(",");
			if (areaArr.length == 3) {
				mypcas.SetValue(areaArr[0], areaArr[1], areaArr[2]);
			} else {
				mypcas.SetValue();
			}
		}
		//初始化事件
        $(this).click(function(){
			$(this).siblings("li").removeClass("selected");
			$(this).addClass("selected");
			$("#book_id").val($(this).find("input[name='user_book_id']").val());
			$("#accept_name").val($(this).find("input[name='user_accept_name']").val());
			$("#address").val($(this).find("input[name='user_address']").val());
			$("#mobile").val($(this).find("input[name='user_mobile']").val());
			$("#telphone").val($(this).find("input[name='user_telphone']").val());
			$("#email").val($(this).find("input[name='user_email']").val());
			$("#post_code").val($(this).find("input[name='user_post_code']").val());
			$(this).find("input[name='user_book_id']").prop("checked", true); //设置选中
			//改变省市区
			var areaArr = $(this).find("input[name='user_area']").val().split(",");
			if (areaArr.length == 3) {
				mypcas.SetValue(areaArr[0], areaArr[1], areaArr[2]);
			} else {
				mypcas.SetValue();
			}
		});
    });
}

//计算支付手续费总金额
function paymentAmountTotal(obj){
	var paymentPrice = $(obj).siblings("input[name='payment_price']").val();
	$("#paymentFee").text(paymentPrice); //运费
	orderAmountTotal();
}
//计算配送费用总金额
function freightAmountTotal(obj){
	var expressPrice = $(obj).siblings("input[name='express_price']").val();
	$("#expressFee").text(expressPrice); //运费
	orderAmountTotal();
}

//计算税金
function taxAmoutTotal(obj){
	var taxesFee = 0 //税费
	if($(obj).prop("checked") == true){
		taxesFee = parseFloat($("#taxAmout").val());
		$("#invoiceBox").show();
	}else{
		$("#invoiceBox").hide();
	}
	$("#taxesFee").text(taxesFee.toFixed(2));
	orderAmountTotal();
}

//计算订单总金额
function orderAmountTotal(){
	var goodsAmount = $("#goodsAmount").text(); //商品总金额
	var paymentFee = $("#paymentFee").text(); //手续费
	var expressFee = $("#expressFee").text(); //运费
	var taxesFee = 0 //税费
	if($("#is_invoice").prop("checked") == true){
		taxesFee = parseFloat($("#taxAmout").val());
	}
	//订单总金额 = 商品金额 + 手续费 + 运费 + 税费
	var totalAmount = parseFloat(goodsAmount) + parseFloat(paymentFee) + parseFloat(expressFee) + parseFloat(taxesFee);
	$("#totalAmount").text(totalAmount.toFixed(2));
}