$( document ).ready(function() {

	
	
    $(".downArrow").click(function(){
		$(".enterEmail").slideUp(500);
		$(".sendEmail").delay(500).slideDown(500);
		$('#div').show(0).delay(5000).hide(0);
    });

    
    $(".logOutSection").click(function () {       
        document.getElementById("divLogout").style.display = "none";
        document.getElementById("div_login_failure").style.display = "none";
        $(".loginSection").slideDown(500);
        $(".enterEmail").hide(0);
        $(".emailSuccess").hide(0);
        $(".emailfailure").hide(0);
        $(".sendEmail").hide(0);

    });
	
	
    $(".sendagnSection").click(function () {
        $(".emailSuccess").slideUp(500).hide(0);
        $(".emailfailure").slideUp(500).hide(0);
        $(".sendEmail").delay(1000).slideDown(500);
    });
	
	
});