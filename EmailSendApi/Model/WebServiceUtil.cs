
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

namespace EmailSender
{
    public static class WebServiceUtil
    {

        public static string SendGridUrl = "https://api.sparkpost.com/api/v1/transmissions/";
        public static string SendGridApiKey = "1d1ffbb823168316e82b0fcad82b6c5dffc805af";//"3e7048d9505ca76070b6bf3495961e125faa3c82";


        public static async Task<SendSparkpostEmailResponse> SendEmailSparkPostApi(SendSparkpostEmailRequest request)
        {
            SendSparkpostEmailResponse response = null;
            //Dictionary<string, string> param = new Dictionary<string, string>();
            //param.Add("email_id", email);

            string data = JsonConvert.SerializeObject(request);
            System.Diagnostics.Debug.WriteLine(data);
            string result = await PostAsync(data, "", SendGridUrl,true);

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

       

       

        private static byte[] ReadFully(Stream stream)
        {
            var buffer = new byte[32768];
            using (var ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }

        private async static Task<string> getAsync(string BASE_URL)
        {
            string result = "";
            HttpClient httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(BASE_URL);

                if (response != null && response.IsSuccessStatusCode)
                {
                    try
                    {
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

            return result;
        }

        private async static Task<string> PostAsync(string postData, string functionName, string BASE_URL , bool header)
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

                StringContent content = new StringContent(postData, Encoding.UTF8, "application/json");
                try
                {
                    HttpResponseMessage response = await httpClient.PostAsync(url, content);
                    string status = response.StatusCode.ToString();
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        try
                        {
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
