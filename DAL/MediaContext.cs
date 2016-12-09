
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using WebApplication1.Models;
using static WebApplication1.Models.MediaModels;
using static WebApplication1.Models.UserRelatedModel;

namespace WebApplication1.DAL
{

    public partial class MediaContext : IdentityDbContext<ApplicationUser>
    {
        
        public virtual DbSet<photo> photos { get; set; }
        public virtual DbSet<video> videos { get; set; }
        public virtual DbSet<Galleries> Albums { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<favorite> favorites { get; set; }
        public virtual DbSet<playlist_videos> playlist_videos { get; set; }
        public virtual DbSet<tag> tags { get; set; }
        public virtual DbSet<user_playlists> user_playlists { get; set; }
        public virtual DbSet<useractivity> useractivities { get; set; }
        public virtual DbSet<UserTag> UserTags { get; set; }
        public virtual DbSet<UserRelatedModel.user_video_history> user_video_history { get; set; }

        public virtual DbSet<UserRelatedModel.user_ratings> user_ratings { get; set; }

        
        public MediaContext()
            : base("DefaultConnection")
        {
        }

        public static MediaContext Create()
        {
            return new MediaContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure Asp Net Identity Tables
           

            modelBuilder.Entity<photo>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<photo>()
                .Property(e => e.filename)
                .IsUnicode(false);

            modelBuilder.Entity<photo>()
                .Property(e => e.caption)
                .IsUnicode(false);

            modelBuilder.Entity<photo>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<photo>()
                .Property(e => e.tags)
                .IsUnicode(false);

            modelBuilder.Entity<photo>()
                .Property(e => e.categories)
                .IsUnicode(false);

            modelBuilder.Entity<photo>()
                .Property(e => e.language)
                .IsUnicode(false);

            modelBuilder.Entity<photo>()
                .Property(e => e.authkey)
                .IsUnicode(false);

            modelBuilder.Entity<photo>()
                .Property(e => e.usertags)
                .IsUnicode(false);

            modelBuilder.Entity<photo>()
                .Property(e => e.instaID)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.search_term)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.tags)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.duration)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.videofilename)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.thumbfilename)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.originalvideofilename)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.embed_script)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.flv_url)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.org_url)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.thumb_url)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.ipaddress)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.youtubeid)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.categories)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.language)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.authkey)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.coverurl)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.usertags)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.audiocovername)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.instaID)
                .IsUnicode(false);
        }
    }
}
