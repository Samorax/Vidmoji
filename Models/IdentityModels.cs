using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using static WebApplication1.Models.MediaModels;

namespace WebApplication1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        public string countryname { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public DateTime? birthdate { get; set; }
        public int views { get; set; }
        public string picturename { get; set; }

        public byte isenabled { get; set; }

        public byte issendmessages { get; set; }

        public byte isallowbirthday { get; set; }

        public DateTime? register_date { get; set; }

        public DateTime? last_login { get; set; }

  
        public string val_key { get; set; }

    
        public string relationshipstatus { get; set; }

       
        public string aboutme { get; set; }


        public string website { get; set; }

     
        public string hometown { get; set; }

    
        public string currentcity { get; set; }


        public string zipcode { get; set; }


        public string occupations { get; set; }


        public string companies { get; set; }


        public string schools { get; set; }

 
        public string interests { get; set; }

        public string  photos { get; set; }
        public  string  movies { get; set; }

        
        public string musics { get; set; }

        public string books { get; set; }

        public byte isautomail { get; set; }

        public byte mail_vcomment { get; set; }

        public byte mail_ccomment { get; set; }

        public byte mail_pmessage { get; set; }

        public byte mail_finvite { get; set; }

        public byte mail_subscribe { get; set; }

        public byte privacy_fmessages { get; set; }

        public int videos_watched { get; set; }

        public int subscribers { get; set; }

        public byte channel_iscomments { get; set; }

        public byte channel_isfriends { get; set; }

        public byte channel_issubscribers { get; set; }

        public byte channel_isgroups { get; set; }

        public byte channel_isphotos { get; set; }

        public byte channel_isblogs { get; set; }

        public byte channel_isaudios { get; set; }

        public string channel_name { get; set; }

        public string channel_theme { get; set; }

        public int stat_videos { get; set; }

        public int stat_friends { get; set; }

        public int stat_subscribers { get; set; }

        public int stat_favorites { get; set; }

        public int stat_groups { get; set; }

        public int stat_messages { get; set; }

        public int stat_comments { get; set; }

        public int stat_photos { get; set; }

        public int stat_blogs { get; set; }

        public int stat_audios { get; set; }

        public int stat_audiofavorites { get; set; }

        public byte type { get; set; }

        public byte _readonly { get; set; }

        public string fb_uid { get; set; }

        public int credits { get; set; }

        public int remained_video { get; set; }

        public int remained_audio { get; set; }

        public int remained_gallery { get; set; }

        public int remained_photos { get; set; }

        public int remained_blogs { get; set; }

        public int space_video { get; set; }

        public int space_audio { get; set; }

        public int space_photos { get; set; }

        public int roleid { get; set; }

        public int stat_forum_posts { get; set; }

        public int stat_forum_points { get; set; }

        public DateTime? last_purchased { get; set; }

        public DateTime? membership_expiry { get; set; }

        public byte islifetimerenewal { get; set; }

        public byte paypal_subscriber { get; set; }

        public string paypal_email { get; set; }

        public short stat_qa { get; set; }

        public short stat_qanswers { get; set; }

        public short stat_qafavorites { get; set; }

        public short stat_photofavorites { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       
    }
}