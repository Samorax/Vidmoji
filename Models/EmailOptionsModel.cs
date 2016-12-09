using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EmailOptionsModel
    {
        [Required(ErrorMessage ="This field is required")]
        [Display(Name ="New Email")]
        [DataType(DataType.EmailAddress)]
        public string NewEmail { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name ="Account Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string AccountPassword { get; set; }

        [Display(Name = "Send individual emails for the events below.")]
        public bool SendEventEmails { get; set; }

        [Display(Name = "Don't send any emails for the above events.")]
        public bool DontSendEventEmails { get; set; }

        [Display(Name = "One of my videos receives a comment or a video response.")]
        public bool CommentorVideoResponse { get; set; }

        [Display(Name = "Someone leaves a comment on my channel.")]
        public bool CommentLeftChannel { get; set; }

        [Display(Name = "I receive a private message.")]
        public bool PrivateMessage { get; set; }

        [Display(Name = "I receive a friend invite from another user.")]
        public bool FriendInvite { get; set; }

        [Display(Name = "Someone subscribes to my channel.")]
        public bool channelSubscription { get; set; }
    }
}