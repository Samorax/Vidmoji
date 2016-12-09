using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage ="This field is required")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [StringLength(20)]
        public string UserName { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required(ErrorMessage ="This field is required")]
        public string Provider { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage ="This field is required")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "UserName")]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(128)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name ="UserName")]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [Display(Name = "Country")]
        public string Countryname { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [Display(Name = "Account Type")]
        public string AccountType { get; set; }

        [Required(ErrorMessage ="This field is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage ="You must agree to the Terms and Privacy Policy of this website")]
        public bool TermsAgreement { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required (ErrorMessage ="This field is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage ="This field is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="This field is requiredd")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required (ErrorMessage ="This field is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
