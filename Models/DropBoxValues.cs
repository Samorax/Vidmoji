using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DropBoxValues
    {
        public string name { get; set; }


        public string link { get; set; }


        public int bytes { get; set; }


        public string icon { get; set; }


        public string thumbnailLinkv { get; set; }

        public bool isDir{get;set;}
    }
}