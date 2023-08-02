using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTYBApi.Models.Avigma
{
    public class EmailDTO
    {
        public long CustId { get; set; }
        public long UserId { get; set; }
        public string MainBody { get; set; }
        public String From { get; set; }
        public String To { get; set; }
        public String Subject { get; set; }
        public String Message { get; set; }
        public String CC { get; set; }
        public String BCC { get; set; }
        public String? Attachment { get; set; }
        public String? Password { get; set; }
        public String? Username { get; set; }
        public bool IsBodyHtml { get; set; }
        public String? FirstName { get; set; }
        public List<dynamic> Attachmentarr { get; set; }
        public List<dynamic> filenamearr { get; set; }
    }
}