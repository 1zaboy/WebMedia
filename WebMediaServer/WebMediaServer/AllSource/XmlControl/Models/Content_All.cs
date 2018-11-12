using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMediaServer.AllSource.XmlControl.Models
{
    public class Content_All
    {
        public int id { get; set; }

        public string NameVideo { get; set; }

        public string UserName { get; set; }

        public string UserId { get; set; }

        public string Url1 { get; set; }

        public string Url2 { get; set; }

        public DateTime DateAddVideo { get; set; }

        public TimeSpan? LengthVideo { get; set; }

        public int TypeContent { get; set; }

        public string Text_Description { get; set; }
    }
}