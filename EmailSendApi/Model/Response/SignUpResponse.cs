using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailSendApi.Model.Response
{
    public class SignUpResponse
    {
        public int code { get; set; }
        public string msg { get; set; }
        public SignUpData data { get; set; }
    }

    public class SignUpData
    {
        public int total_record_inserted { get; set; }
    }
}