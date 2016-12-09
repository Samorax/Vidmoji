using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AlbumViewModel
    {
        [Required(ErrorMessage = "This Field is Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string Tags { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string Categories { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public int Privacy { get; set; }
    }
}