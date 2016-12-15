using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebApplication1.Models.MediaModels;

namespace WebApplication1.Models
{
    public class VideoCategoryViewModel
    {
        public int id { get; set; }
        public string CategoryName { get; set; }
        public List<video> CategoryVideos { get; set; }
    }
}