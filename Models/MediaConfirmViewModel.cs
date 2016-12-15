using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MediaConfirmViewModel
    {
        [Required(ErrorMessage ="This field is required")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage ="This field is required")]
        public mediaCategories Category { get; set; }

        public bool Delete { get; set; }
        public bool AlbumCover { get; set; }

        public string Tags { get; set; }
    }
}