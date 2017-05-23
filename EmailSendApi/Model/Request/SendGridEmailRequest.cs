using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;  

/// <summary>
/// Summary description for SendGridEmailRequest
/// </summary>
/// 
 namespace EmailSender
{
    public class SendSparkpostEmailRequest
    {     
     
        public Options options { get; set; }
        public Content content { get; set; }
        public List<Recipient> recipients { get; set; }
    }


    public class Content
    {
        public string from { get; set; }
        public string subject { get; set; }
        public string text { get; set; }

    }

    public class Options
    {
        public bool sandbox { get; set; }
    }

    public class Recipient
    {
        public string address { get; set; }
    }
}