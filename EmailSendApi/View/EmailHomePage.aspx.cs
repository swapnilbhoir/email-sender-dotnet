using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace EmailSender
{

    public partial class View_EmailHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /*
        protected async void submit_ServerClick(object sender, EventArgs e)
        {

            Button BtnSendEmail = sender as Button;

            BtnSendEmail.Enabled = false;

            string toEmail = String.Format("{0}", Request.Form["toEmail"]);
            string mailSubject = String.Format("{0}", Request.Form["subjectEmail"]);
            string mailBody = String.Format("{0}", Request.Form["composeEmail"]);

            SendGridEmailRequest request=new SendGridEmailRequest();
            request.content=new Content();
            request.content.from="sandbox@sparkpostbox.com";
            request.content.subject=mailSubject;
            request.content.text=mailBody;

            request.options=new Options();
            request.options.sandbox=true;

            string[] Emails=toEmail.Split(',').ToArray();

            if(Emails.Length>=1)
            {
                request.recipients=new List<Recipient>();

                for(int i=0;i<Emails.Length;i++)
                {
                    Recipient receiver=new Recipient();
                    receiver.address=Emails[i];
                    request.recipients.Add(receiver);
                }
            }


            SendGridEmailResponse response = await WebServiceUtil.SendEmailGridApi(request);

            if(response!=null)
            {
               if(response.results.total_accepted_recipients==Emails.Length)
               {

                   string a = "sucess";
                  // System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">alert("+"Hello this is an Alert"+")+</SCRIPT>");
               }
               else
               {

               }
            }
            else
            {

            }


            BtnSendEmail.Enabled = true;
            //  Console.WriteLine(((TextBox)this.FindControl("toEmail")).Text);
        }

        */
        protected async void BtnSubmit_Click(object sender, EventArgs e)
        {
            Button BtnSendEmail = sender as Button;

            BtnSendEmail.Enabled = false;

            string toEmail = String.Format("{0}", Request.Form["toEmail"]);
            string mailSubject = String.Format("{0}", Request.Form["subjectEmail"]);
            string mailBody = String.Format("{0}", Request.Form["composeEmail"]);

            SendGridEmailRequest request = new SendGridEmailRequest();
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


            SendGridEmailResponse response = await WebServiceUtil.SendEmailGridApi(request);

            if (response != null)
            {
                if (response.results.total_accepted_recipients == Emails.Length)
                {

                    string a = "sucess";
                    // System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">alert("+"Hello this is an Alert"+")+</SCRIPT>");
                }
                else
                {

                }
            }
            else
            {

            }


            BtnSendEmail.Enabled = true;
        }
}
}