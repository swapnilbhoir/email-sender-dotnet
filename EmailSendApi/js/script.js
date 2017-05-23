$( document ).ready(function() {
    $("#ccLink").click(function(){
		$("#ccSection").show();
	});

	$("#bccLink").click(function(){
		$("#bccSection").show();
	});


	$("#BtnSubmit").click(function () {
	    $("#div_loader").show();
	});
});