using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailSendApi.Model.Response
{
    public class LoginResponse
    {
        public int code { get; set; }
        public string msg { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string token { get; set; }
    }
}