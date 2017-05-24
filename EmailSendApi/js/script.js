$( document ).ready(function() {

	//$(".btn-login").click(function(){
	//	$(".loginSection").slideUp(500);
	//	$(".enterEmail").delay(500).slideDown(500);
	//});
	
    $(".downArrow").click(function(){
		$(".enterEmail").slideUp(500);
		$(".sendEmail").delay(500).slideDown(500);
		$('#div').show(0).delay(5000).hide(0);
	});
	
	//$(".btn-send").click(function(){
	//	$(".sendEmail").slideUp(500);
	//	$(".emailloading").delay(1000).slideDown(500).slideUp(500).hide(0);
	////	$(".emailSuccess").delay(2000).slideDown(500);
	//});
	
	$(".sendagnSection").click(function(){
	    $(".emailSuccess").slideUp(500).hide(0);
	    $(".emailfailure").slideUp(500).hide(0);
		$(".sendEmail").delay(1000).slideDown(500);
	})
	
	//$(".sendagnSection").click(function(){
	//	$(".emailfailure").slideUp(500).hide(0);
	//	$(".sendEmail").delay(1000).slideDown(500);
	//})
});