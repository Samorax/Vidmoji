using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MyProfileSetupViewModel
    {
        public string ProfilePic { get; set; }
        public string AboutMe { get; set; }
        public string Website { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string relStatus { get; set; }
        public string age { get; set; }
        public string gender { get; set; }

        public string Occupation { get; set; }
        public string Companies { get; set; }
        public string Schools { get; set; }
        public string Interests { get; set; }
        public string favBooks { get; set; }
        public string favMusics { get; set; }
        public string favMovies { get; set; }

        public string HomeTown { get; set; }
        public string PostalCode { get; set; }
        public string CurrentCity { get; set; }
        public string Country { get; set; }
    }
}