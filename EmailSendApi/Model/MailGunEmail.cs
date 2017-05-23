using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading.Tasks;

namespace EmailSender
{
    public static class MailGunEmail
    {

        public static IRestResponse SendSimpleMessage(string[]toEmail,string subject,string body)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                                            "key-652eb9118612ce9fe0ea09219c50ed89");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "mg.mailguntest.com", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Test User <mailgun@mg.mailguntest.com>");

            for (int i = 0; i < toEmail.Length;i++)
                request.AddParameter("to", toEmail[i]);

            request.AddParameter("subject", subject);
            request.AddParameter("text", body);
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}