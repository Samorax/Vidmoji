namespace WebApplication1
{
    using System.Data.Entity;
    using Models;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<user_playlists> user_playlists { get; set; }
        public virtual DbSet<user_ratings> user_ratings { get; set; }
        public virtual DbSet<user_subscribers> user_subscribers { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user_playlists>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user_playlists>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<user_playlists>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<user_playlists>()
                .Property(e => e.tags)
                .IsUnicode(false);

            modelBuilder.Entity<user_playlists>()
                .Property(e => e.picturename)
                .IsUnicode(false);

            modelBuilder.Entity<user_ratings>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user_subscribers>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user_subscribers>()
                .Property(e => e.subscriber_username)
                .IsUnicode(false);

            
        }
    }
}
