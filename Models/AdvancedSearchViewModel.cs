using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class AdvancedSearchViewModel
    {
        [Required(ErrorMessage ="This field is required")]
        public string Term { get; set; }
        public string Author { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [Display(Name ="Select Category")]
        public mediaCategories SelectCategory { get; set; }
        public mediaTypes Type { get; set; }

        [Display(Name ="Order By")]
        public mediaOrder OrderBy { get; set; }
    }

    public enum mediaCategories
    {
        [Display(Name ="All Categories")]
        AllCategories,
        Entertainment,
        Songs,
        [Display(Name ="Film and Animation")]
        FilmAnimation,
        Gaming,
        Education,
        Comedy,
        Science,
        Sports
    }

    public enum mediaTypes
    {
        All,
        Normal,
        Featured,
        Premium
    }

    public enum mediaOrder
    {
        [Display(Name = "Recently Added")]
        recentlyAdded,
        [Display(Name ="Title")]
        title,
        [Display(Name ="Most Liked")]
        Mostliked,
        [Display(Name ="Most Commented")]
        MostCommented
    }
}