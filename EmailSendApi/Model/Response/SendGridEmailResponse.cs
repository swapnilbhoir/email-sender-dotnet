using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SendGridEmailResponse
/// </summary>
/// 

namespace EmailSender
{
    public class SendGridEmailResponse
    {
        public Results results { get; set; }
    }

    public class Results
    {
        public int total_rejected_recipients { get; set; }
        public int total_accepted_recipients { get; set; }
        public string id { get; set; }
    }
}
