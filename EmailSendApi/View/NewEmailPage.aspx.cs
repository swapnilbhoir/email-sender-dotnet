using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmailSender;
using System.Web.UI.HtmlControls;
using System.Threading.Tasks;
using RestSharp;
using EmailSendApi.Model.Response;
using System.Text.RegularExpressions;
using EmailSendApi.Model.Request;

namespace EmailSendApi.View
{
    public partial class NewEmailPage : System.Web.UI.Page
    {
        #region Variable
        public bool isTokenExpire = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region SendMailClick
        protected async void BtnSubmit_Click(object sender, EventArgs e)
        {
            BtnSubmitId.Disabled = true;
                      
            string toEmail = String.Format("{0}", Request.Form["toEmail"]);
            string mailSubject = String.Format("{0}", Request.Form["subjectEmail"]);
            string mailBody = String.Format("{0}", Request.Form["composeEmail"]);

            if (!string.IsNullOrEmpty(toEmail) && !string.IsNullOrEmpty(mailSubject) && !string.IsNullOrEmpty(mailBody))
            {
                if (IsValidEmailInput(toEmail))
                {
                  
                    if (!await SendSparkPostEmail(toEmail, mailSubject, mailBody))
                    {
                        if (!SendMailGunEmail(toEmail, mailSubject, mailBody))
                        {
                            //failure in sending mail from both email api

                            if (!await SendEmail(toEmail, mailSubject, mailBody))
                            {
                                if (isTokenExpire)
                                {
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SessionExpire", "SessionExpire();", true);
                                }
                                else
                                {
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "failureMail", "failureMail();", true);
                                }
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "successMail", "successMail();", true);
                            }
                            
                        }
                        else
                        {
                            
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "successMail", "successMail();", true);
                            
                        }
                    }
                    else
                    {
                        //mail send sucessfully using SparkPost

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "successMail", "successMail();", true);
                       
                    }

                    //BtnSendEmail.Enabled = true;
                }
                else
                {
                    //loginHide
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "loginHide", "loginHide();", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "loginHide", "loginHide();", true);
            }

            BtnSubmitId.Disabled = false;

           
           // BtnSubmitId.Disabled = false;
        }
        #endregion

        #region SendSparkPostEmail
        private async Task<bool> SendSparkPostEmail(string toEmail, string mailSubject, string mailBody)
        {
            bool result = false;

            SendSparkpostEmailRequest request = new SendSparkpostEmailRequest();
            request.content = new EmailSender.Content();
            request.content.from = "sandbox@sparkpostbox.com";
            request.content.subject = mailSubject;
            request.content.text = mailBody;

            request.options = new Options();
            request.options.sandbox = true;

            string[] Emails = toEmail.Split(',').ToArray();

            if (Emails.Length >= 1)
            {
                request.recipients = new List<Recipient>();

                for (int i = 0; i < Emails.Length; i++)
                {
                    Recipient receiver = new Recipient();
                    receiver.address = Emails[i];
                    request.recipients.Add(receiver);
                }
            }


            SendSparkpostEmailResponse response = await WebServiceUtil.SendEmailSparkPostApi(request);

            if (response != null)
            {
                if (response.results.total_accepted_recipients == Emails.Length)
                {
                    result = true;
                }
            }

            return result;
        }
        #endregion

        #region SendMailGunEmail
        private bool SendMailGunEmail(string toEmail, string mailSubject, string mailBody)
        {
            bool result = false;

            string[] Emails = toEmail.Split(',').ToArray();

            if (Emails.Length >= 1)
            {
                IRestResponse response = MailGunEmail.SendSimpleMessage(Emails, mailSubject, mailBody);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = true;
                }
            }

            return result;
        }
        #endregion

        #region SendEmailViaOwn

        private async Task<bool> SendEmail(string toEmail, string mailSubject, string mailBody)
        {
            bool result = false;

            EmailerRequest request = new EmailerRequest();
           
            request.from = "punchbhuja@gmail.com";
            request.subject = mailSubject;
            request.body = mailBody;

           

            string[] Emails = toEmail.Split(',').ToArray();

            if (Emails.Length >= 1)
            {
                request.to = new List<string>();

                for (int i = 0; i < Emails.Length; i++)
                {                    
                    request.to.Add(Emails[i]);
                }
            }


            EmailerResponse response = await WebServiceUtil.SendEmailApi(request);

            if (response != null)
            {
                if (response.code==2000)
                {                  
                    result = true;
                }
                else if (response.code == 402 || response.code == 401)
                {
                    isTokenExpire = true;
                  
                }
            }

            return result;
        }

        #endregion

        #region Login

        private async Task<bool> PerformLogin(string username,string password)
        {

            LoginResponse response = await WebServiceUtil.Login(username, password);
           
            if(response!=null)
            {
                if(response.code==2000)
                {
                    isTokenExpire = false;
                    WebServiceUtil.MailToken = response.data.token;

                    divLogout.Attributes.Add("style", "display:block");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "loginClick", "loginClick();", true);

                }
                else
                {
                    div_login_failure.InnerText = response.msg;
                    div_login_failure.Attributes.Add("style", "display:block");
                    divLogout.Attributes.Add("style", "display:none");
                }
            }
            else
            {
                div_login_failure.InnerText = "No Response From Server";
                divLogout.Attributes.Add("style", "display:none");
                div_login_failure.Attributes.Add("style", "display:block");
            }

            return true;
        }

        protected async void login_id_ServerClick(object sender, EventArgs e)
        {
            login_id.Disabled = true;

            string username = String.Format("{0}", Request.Form["userNametxt"]);
            string password = String.Format("{0}", Request.Form["userPasstxt"]);

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {

                div_login_failure.InnerText = "Invalid username or password";
                div_login_failure.Attributes.Add("style", "display:block");
                divLogout.Attributes.Add("style", "display:none");
            }
            else
            {
               await PerformLogin(username, password);
            }


            login_id.Disabled = false;
        }

        #endregion

        #region MailValidation

        private bool IsValidEmailInput(string toEmail)
        {
            bool result = true;

                Regex emailReg = new Regex(@"^((\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*([,])*)*$");
                if (!emailReg.IsMatch(toEmail))
                {
                    result = false;                  
                }

                return result;
        }

        #endregion
    }
}