namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<user_ratings> user_ratings { get; set; }
        public virtual DbSet<user_subscribers> user_subscribers { get; set; }
        public virtual DbSet<user_video_history> user_video_history { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user_ratings>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user_subscribers>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user_subscribers>()
                .Property(e => e.subscriber_username)
                .IsUnicode(false);

            modelBuilder.Entity<user_video_history>()
                .Property(e => e.username)
                .IsUnicode(false);
        }
    }
}
