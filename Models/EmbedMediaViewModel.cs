using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EmbedMediaViewModel
    {
        [Display(Name ="Title:")]
        [Required(ErrorMessage = "This field is required")]
        public string Title { get; set; }

        [Display(Name ="Thumb Preview:")]
        [Required(ErrorMessage ="This field is required")]
        public string ThumbPreview { get; set; }

        [Display(Name = "Embed Code:")]
        [DataType(DataType.MultilineText)]
        [MaxLength(2000,ErrorMessage ="You have exceeded the maximum characters.")]
        public string EmbedCode { get; set; }

        [Display(Name ="Description:")]
        [DataType(DataType.MultilineText)]
        [MaxLength(2000, ErrorMessage = "You have exceeded the maximum characters.")]
        public string Description { get; set; }

        [Display(Name = "Tags:")]
        [Required(ErrorMessage = "This field is required")]
        public string Tags { get; set; }

        [Display(Name = "Category:")]
        [Required(ErrorMessage = "This field is required")]
        public string Category { get; set; }

        [Display(Name = "Privacy:")]
        [Required(ErrorMessage = "This field is required")]
        public string Privacy { get; set; }
    }
}