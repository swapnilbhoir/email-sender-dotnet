using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailSendApi.Model.Request
{
    public class EmailerRequest
    {
        public List<string> to { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public string from { get; set; }
    }
}