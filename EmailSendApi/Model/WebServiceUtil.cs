﻿
using Newtonsoft;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using EmailSendApi.Model;
using EmailSendApi.Model.Response;
using EmailSendApi.Model.Request;

namespace EmailSender
{
    public static class WebServiceUtil
    {

        public static string SendGridUrl = "https://api.sparkpost.com/api/v1/transmissions/";
        public static string SendGridApiKey = "1d1ffbb823168316e82b0fcad82b6c5dffc805af";//"3e7048d9505ca76070b6bf3495961e125faa3c82";
        public static string LoginUrl = "http://10.40.12.205:3000/user/signin";
        public static string MailToken = "";
        public static string MailUrl = "http://10.40.12.205:3000/v1/mailer/sendmail";


        public static async Task<SendSparkpostEmailResponse> SendEmailSparkPostApi(SendSparkpostEmailRequest request)
        {
            SendSparkpostEmailResponse response = null;
            //Dictionary<string, string> param = new Dictionary<string, string>();
            //param.Add("email_id", email);

            string data = JsonConvert.SerializeObject(request);
            System.Diagnostics.Debug.WriteLine(data);
            string result = await PostAsync(data, "", SendGridUrl,true,false);

            if (!string.IsNullOrEmpty(result))
            {
                try
                {
                    response = JsonConvert.DeserializeObject<SendSparkpostEmailResponse>(result);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                }
            }

            return response;
        }


        public static async Task<EmailerResponse> SendEmailApi(EmailerRequest request)
        {
            EmailerResponse response = null;
            //Dictionary<string, string> param = new Dictionary<string, string>();
            //param.Add("email_id", email);

            string data = JsonConvert.SerializeObject(request);
            System.Diagnostics.Debug.WriteLine(data);
            string result = await PostAsync(data, "", MailUrl, false, true);

            if (!string.IsNullOrEmpty(result))
            {
                try
                {
                    response = JsonConvert.DeserializeObject<EmailerResponse>(result);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                }
            }

            return response;
        }




        public static async Task<LoginResponse> Login(string username,string password)
        {
            LoginResponse response = null;
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("username", username);
            param.Add("password", password);

            string data = JsonConvert.SerializeObject(param);
            System.Diagnostics.Debug.WriteLine(data);
            string result = await PostAsync(data, "", LoginUrl, false,false);

            if (!string.IsNullOrEmpty(result))
            {
                try
                {
                    response = JsonConvert.DeserializeObject<LoginResponse>(result);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                }
            }

            return response;
        }

       
        private async static Task<string> PostAsync(string postData, string functionName, string BASE_URL , bool header , bool emailHeader)
        {


            string result = "";


            if (postData != null )//&& !string.IsNullOrEmpty(functionName))
            {
                Uri url = new Uri(BASE_URL + functionName);
                HttpClient httpClient = new HttpClient();
              

                if(header==true)
                {
                   // httpClient.DefaultRequestHeaders.Add("Content-Type","application/json");
                    httpClient.DefaultRequestHeaders.Add("Authorization", SendGridApiKey);
                }
               
                if(emailHeader==true)
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", MailToken);
                }

                StringContent content = new StringContent(postData, Encoding.UTF8, "application/json");
                try
                {
                    HttpResponseMessage response = await httpClient.PostAsync(url, content);
                    string status = response.StatusCode.ToString();
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        try
                        {
                            if(emailHeader)
                            {
                               MailToken= response.Headers.GetValues("Authorization").ToString();
                            }

                            result = await response.Content.ReadAsStringAsync();
                        }
                        catch (Exception e)
                        {
                            result = "";
                            Debug.WriteLine(e.StackTrace);
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                }
            }
            return result;
        }


    }

}
