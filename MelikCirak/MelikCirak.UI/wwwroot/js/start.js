$(".opt").click(function () {
	$(this).attr("qselected", "true");
	$(this).attr("style", "border:1px solid orange;");
});

$("#btnBitir").click(function () {
	$.each($(".opt"), function (index, el) {
		var item = $(".opt").eq(index);
		if (item.attr("qd") == "true" && item.attr("qselected") == "true") {
			item.attr("style", "background-color:green;")
		}
		else if (item.attr("qd") == "false" && item.attr("qselected") == "true") {
			item.attr("style", "background-color:red;")
		}
		else if (item.attr("qd") == "true") {
			item.attr("style", "border:1px solid green;")
		}
	});
});