<%@ Page Language="C#" AutoEventWireup="true"  Async="true"    CodeBehind="NewEmailPage.aspx.cs" Inherits="EmailSendApi.View.NewEmailPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" runat="server">

<head runat="server">

    <meta charset="utf-8"/>
		<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
		<meta name="viewport" content="width=device-width, initial-scale=1"/>
		<!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
		<meta name="description" content=""/>
		<meta name="author" content=""/>
		<link rel="icon" href="../../favicon.ico"/>		
		<!-- Bootstrap core CSS -->
		<link href="../css/bootstrap.css" rel="stylesheet"/>
		<!-- My Custom CSS -->
		<link href="../css/style.css" rel="stylesheet"/>
		<link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet"/>

    <title>Email Service</title>
   
</head>
<body>
    
            <!-- Container Start -->

    <form id="form1" runat="server">
        

		<div class="container">
			<div class="col-lg-4 col-lg-offset-4 col-md-4 col-md-offset-4 col-sm-12 col-xs-12 loginSection">
				<div class="row text-center">
					<h3 class="messagetxt">Log In</h3>
				</div>
				<div class="loginCard">
					<%--<form name="emailForm"  method="post" id="loginForm">--%>
						<div class="row">
							<div class="col-lg-12 col-md-12 col-sm-12 colxs-12">
								<div class="form-group">
									<input type="text" class="form-control" name="userNametxt" id="userNametxt" placeholder="User name" required="required"  />
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-12 col-md-12 col-sm-12 colxs-12">
								<div class="form-group">
									<input type="password" class="form-control" name="userPasstxt" id="userPasstxt" placeholder="Password" required="required"/>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-12 col-md-12 col-sm-12 colxs-12">
								<button type="submit"  class="col-lg-4 col-md-4 btn btn-primary btn-login" runat="server" id="login_id" name="login_id" onserverclick="login_id_ServerClick" >Login</button>

                               <%-- <asp:Button  class="col-lg-4 col-md-4 btn btn-primary btn-login" runat="server" id="loginid" name="loginid" Text="login"   OnClick="login_Click"  />--%>

							</div>
						</div>

                    <%--<div class="row">&nbsp; </div>--%>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 colxs-12">
                            <div class="alert alert-danger text-center" style="display:none" role="alert" id="div_login_failure" runat="server" >Login Failed</div>
                        </div>
                     </div>
                       
					<%--</form>--%>
				</div>
			</div>

            <div id="divLogout" runat="server" style="display:none;" class="row" >
                <div class="col-lg-12 col-md-12 colsm-12 colxs-12 text-right logOutSection">
                    <a href="#" class="logoutBtn"  >Logout</a>
                </div>
            </div>

			<div class="col-lg-6 col-lg-offset-3 col-md-6 col-md-offset-3 col-sm-12 col-xs-12 enterEmail">
				<div class="row">
					<div class="col-lg-12 text-center">
						<h3 class="messagetxt">Welcome to email platform</h3>
					</div>
				</div>
				<div class="card">
                    <div class="row text-center">
						<img class="emailImg" src="../images/email-icon.png"/>
					</div>

					<div class="row text-center proceedSection">
						<span class="cardHeadMess">Welcome to our email sending panel. Please click on the down arrow below the email icon to proceed further.</span>
					</div>
					
					<div class="row text-center downArrowSection">
						<span class="downArrow"><img src="../images/down-arow.png" /></span>
					</div>
				</div>
			</div>

			<div class="col-lg-6 col-lg-offset-3 col-md-6 col-md-offset-3 col-sm-12 col-xs-12 sendEmail">
				<div class="row text-center">
					<h3 class="messagetxt">Compose Email</h3>
				</div>
				<div class="card">
					<%--<form name="emailForm" method="post" id="emailForm">--%>
						<div class="row">
							<div class="col-lg-12 col-md-12 col-sm-12 colxs-12">
								<div class="form-group">
             
									<input type="email" class="form-control"  name="toEmail" id="toEmail" placeholder="To"  required="required"   onkeydown="Validate()" onblur="EmailValidateOnBlur()"/>                        

								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-12 col-md-12 col-sm-12 colxs-12">
								<div class="form-group">
									<input type="text" class="form-control" name="subjectEmail" id="subjectEmail" placeholder="Subject" required="required" onkeydown="Validate()" onblur="SubjectValidateOnBlur()" />
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-12 col-md-12 col-sm-12 colxs-12">
								<div class="form-group">
									<textarea class="form-control" name="composeEmail" id="composeEmail" rows="5" placeholder="Compose" required="required" onkeydown="Validate()" onblur="BodyValidateOnBlur()"></textarea>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-12 col-md-12 col-sm-12 colxs-12">
								<button type="submit" disabled="disabled" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 btn btn-primary btn-send" id="BtnSubmitId" name="BtnSubmitId" runat="server" onserverclick="BtnSubmit_Click"  ><img src="../images/email-send.png"/> Send</button>

                               

<%--                                <asp:Button  class="col-lg-12 col-md-12 col-sm-12 col-xs-12 btn btn-primary btn-send"  runat="server" ID="BtnSubmitId1"  Text="Send" OnClick="BtnSubmit_Click" CausesValidation="false"></asp:Button>--%>

                                    

							</div>
						</div>

                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 colxs-12">
                            <div class="alert alert-danger text-center" style="display:none" role="alert" id="div_email_validation_msg" runat="server" >All Three Parameters Required</div>
                        </div>
                     </div>

					<%--</form>--%>
				</div>
			</div>

			<div class="col-lg-6 col-lg-offset-3 col-md-6 col-md-offset-3 col-sm-12 col-xs-12 text-center emailSuccess">
				<div class="card">
					<div class="row">
						<div class="iconSection">
							<img src="../images/checked.png"/>
						</div>
					</div>
					<div class="row">
						<div class="text-center notifyTxt">Mail Successfully Send</div>
					</div>
					<div class="row sendagnSection">
						<div class="col-lg-8 col-lg-offset-2 col-md-8 col-md-offset-2">
							<div class="btn-enter">Send Another Mail</div>
						</div>
					</div>
				</div>
			</div>

			<div class="col-lg-6 col-lg-offset-3 col-md-6 col-md-offset-3 col-sm-12 col-xs-12 text-center emailfailure">
				<div class="card">
					<div class="iconSection">
						<img src="../images/error.png"/>
					</div>
					<%--<div class="alert alert-danger text-center" role="alert">Mail Send Failed</div>--%>
                    <div class="row">
						<div class="text-center notifyTxt">Mail Send Failed</div>
					</div>
					<div class="row sendagnSection">
						<div class="col-lg-8 col-lg-offset-2 col-md-8 col-md-offset-2">
							<div class="btn-enter">Send Another Mail</div>
						</div>
					</div>
				</div>
			</div>

          
			<div class="col-lg-6 col-lg-offset-3 col-md-6 col-md-offset-3 col-sm-12 col-xs-12 text-center emailloading">
				<div class="card">
					<div class="loader text-center">
						<img src="../images/loading.gif"  />
                        <br />
                        <span>Processing...</span>
					</div>

				</div>
			</div>

           



		</div>
		<!-- Container End -->

        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script> 
        <script type="text/javascript">         

            function loginClick() {
                
                $(".loginSection").slideUp(500);
                $(".enterEmail").delay(500).slideDown(500);
                $(".loginSection").hide(0);
            }

            function loginHide()
            {
                $(".loginSection").hide(0);
                $(".sendEmail").slideDown(500);
                               
            }
           
           

            function loading() {
                $(".loginSection").hide(0);
                $(".sendEmail").slideUp(500);
                $(".emailloading").delay(500).slideDown(500);
             
            }

            function SessionExpire() {
                document.getElementById("divLogout").style.display = "none";
                document.getElementById("div_login_failure").style.display = "block";
                document.getElementById("div_login_failure").innerText = "Email Token Expired";
                $(".loginSection").slideDown(500);
                $(".enterEmail").hide(0);
                $(".emailSuccess").hide(0);
                $(".emailfailure").hide(0);
                $(".sendEmail").hide(0);
                $(".emailloading").hide(0);
            }

            function successMail()
            {
                $(".loginSection").hide(0);
                $(".emailloading").slideUp(500);;
                $(".emailSuccess").delay(1500).slideDown(500);
               
            }

            function failureMail()
            {
                $(".loginSection").hide(0);
                $(".emailloading").slideUp(500);;
                $(".emailfailure").delay(1500).slideDown(500);
            }

            function Validate()
            {               
                if(document.getElementById("toEmail").value==""  || document.getElementById("subjectEmail").value=="" || document.getElementById("composeEmail").value=="")
                {                    
                    document.getElementById("BtnSubmitId").disabled = true;                                                
                }
                else
                {
                    if (validateEmail(document.getElementById("toEmail").value))
                    {
                        document.getElementById("div_email_validation_msg").style.display = "none";
                        document.getElementById("BtnSubmitId").disabled = false;
                    }
                    else
                    {
                        document.getElementById("BtnSubmitId").disabled = true;
                    }
                }

            }


            function EmailValidateOnBlur()
            {
                if(document.getElementById("toEmail").value=="")
                {
                    document.getElementById("div_email_validation_msg").style.display = "block";
                    document.getElementById("div_email_validation_msg").innerText = "Email Field Is Required";
                    
                }
                else if (!validateEmail(document.getElementById("toEmail").value))
                {
                   
                        document.getElementById("div_email_validation_msg").style.display = "block";
                        document.getElementById("div_email_validation_msg").innerText = "Kindly Provide Proper Email Id";                    
                }
                else
                {
                    document.getElementById("div_email_validation_msg").style.display = "none";
                }
          
            }


            function SubjectValidateOnBlur()
            {
                if(document.getElementById("subjectEmail").value=="")
                {
                    document.getElementById("div_email_validation_msg").style.display = "block";
                    document.getElementById("div_email_validation_msg").innerText = "Email Subject Is Required";
                }
                else
                {
                    document.getElementById("div_email_validation_msg").style.display = "none";
                }
            }


            function BodyValidateOnBlur()
            {
                if (document.getElementById("composeEmail").value == "")
                {
                    document.getElementById("div_email_validation_msg").style.display = "block";
                    document.getElementById("div_email_validation_msg").innerText = "Email Body Is Required";
                }
                else {
                    document.getElementById("div_email_validation_msg").style.display = "none";
                }
            }


            function validateEmail(email)
            {
                var re = /^((\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*([,])*)*$/;

               // var re = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/;
                
                return re.test(email);
            }

           

         </script>


        
            

        </form>

     


   <%-- </form>--%>

    <script src="../js/jquery-3.2.1.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/script.js"></script>


   
</body>
</html>
