using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailSendApi.Model.Response
{
    public class EmailerResponse
    {
        public int code { get; set; }
        public string msg { get; set; }
        public EmailData data { get; set; }
    }

    public class Mailgun
    {
        public bool status { get; set; }
    }

    public class Sparkpost
    {
        public bool status { get; set; }
    }

    public class Nodemailer
    {
        public bool status { get; set; }
    }

    public class EmailData
    {
        public Mailgun mailgun { get; set; }
        public Sparkpost sparkpost { get; set; }
        public Nodemailer nodemailer { get; set; }
    }
}