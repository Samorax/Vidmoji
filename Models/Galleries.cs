using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Galleries
    {
        public int GalleriesId { get; set; }
        public int CategoryID { get; set; }
        public string Categories { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int   isDisabled { get; set; }
        public int   isApproved { get; set; }
        public DateTime  Added_Date { get; set; }
        public string   language { get; set; }
        public int type { get; set; }
        public string mode { get; set; }
        public int privacy { get; set; }
        public string authkey { get; set; }
    }
}