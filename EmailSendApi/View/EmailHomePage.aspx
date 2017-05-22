<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeFile="EmailHomePage.aspx.cs" MasterPageFile="~/View/MasterPage.master" Inherits="EmailSender.View_EmailHomePage"  %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">

		<!-- Container Start -->
		<div class="row pageBar">
			<div class="col-lg-12 text-center">
				<h3>Send Email</h3>
			</div>
		</div>
		<div class="container">
			<div class="col-lg-6 col-lg-offset-3 col-md-6 col-md-offset-3 col-sm-12 col-xs-12">
				<div class="card">
					
						<div class="row">
							<div class="col-lg-12 col-md-12 col-sm-12 colxs-12">
								<div class="form-group">
									<input type="email" class="form-control" name="toEmail" id="toEmail" placeholder="To" required="required" />
									<div class="text-right">
										<span><a href="#" id="ccLink">Cc</a></span>
										<span><a href="#" id="bccLink">Bcc</a></span>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-6 col-md-6 col-sm-12 colxs-12" id="ccSection">
								<div class="form-group">
									<input type="email" class="form-control" name="ccEmail" id="ccEmail" placeholder="Cc"/>
								</div>
							</div>
							<div class="col-lg-6 col-md-6 col-sm-12 colxs-12" id="bccSection">
								<div class="form-group">
									<input type="email" class="form-control" name="bccEmail" id="bccEmail" placeholder="Bcc"/>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-12 col-md-12 col-sm-12 colxs-12">
								<div class="form-group">
									<input type="text" class="form-control" name="subjectEmail" id="subjectEmail" placeholder="Subject" required="required" />
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-12 col-md-12 col-sm-12 colxs-12">
								<div class="form-group">
									<textarea class="form-control" name="composeEmail" id="composeEmail" rows="5" placeholder="Compose" required="required"></textarea>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-12 col-md-12 col-sm-12 colxs-12">
								<div class="form-group">
									<label for="exampleInputFile">Attachment</label>
									<input type="file" id="exampleInputFile"/>
								</div>
								<%--<button type="submit" name="BtnSubmit" id="BtnSubmit"  class="btn btn-primary" runat="server" onserverclick="submit_ServerClick"  >Send</button>--%>
							
                            <asp:Button type="submit" name="BtnSubmit" id="BtnSubmit"  class="btn btn-primary" runat="server" Text="Send" OnClick="BtnSubmit_Click" ></asp:Button>
                            </div>
						</div>
				
				</div>
			</div>
		</div>
		


    </asp:Content>
