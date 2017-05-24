using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;
using RestSharp.Authenticators;
using System.Web.UI.HtmlControls;

namespace EmailSender
{

    public partial class View_EmailHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        #region SendMailClick
        protected async void BtnSubmit_Click(object sender, EventArgs e)
        {
            Button BtnSendEmail = sender as Button;     

         HtmlContainerControl divLoader= this.Master.FindControl("div_loader") as HtmlContainerControl;
         divLoader.Visible = true;

         HtmlContainerControl divSucess = this.Master.FindControl("div_success") as HtmlContainerControl;
         divSucess.Visible = false;
         HtmlContainerControl divFailure = this.Master.FindControl("div_failure") as HtmlContainerControl;
         divFailure.Visible = false;     

            BtnSendEmail.Enabled = false;

            string toEmail = String.Format("{0}", Request.Form["toEmail"]);
            string mailSubject = String.Format("{0}", Request.Form["subjectEmail"]);
            string mailBody = String.Format("{0}", Request.Form["composeEmail"]);

            if (!await SendSparkPostEmail(toEmail, mailSubject, mailBody))
            {
                if (!SendMailGunEmail(toEmail, mailSubject, mailBody))
                {
                    //failure in sending mail from both email api

                    divLoader.Visible = false;
                    divFailure.Visible = true;
                    divSucess.Visible = false;
                }
                else
                {
                    //mail send sucessfully using MailGun
                    divLoader.Visible = false;
                    divFailure.Visible = false;
                    divSucess.Visible = true;
                }
            }
            else
            {
                //mail send sucessfully using SparkPost
                divLoader.Visible = false;
                divFailure.Visible = false;
                divSucess.Visible = true;
            }

            BtnSendEmail.Enabled = true;
        }
        #endregion

        #region SendSparkPostEmail
        private async Task<bool> SendSparkPostEmail(string toEmail, string mailSubject, string mailBody)
        {
            bool result = false;

            SendSparkpostEmailRequest request = new SendSparkpostEmailRequest();
            request.content = new Content();
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
                IRestResponse response= MailGunEmail.SendSimpleMessage(Emails,mailSubject,mailBody);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = true;
                }                
            }
       
            return result;
        }
        #endregion
    }
}