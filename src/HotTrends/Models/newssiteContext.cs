using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HotTrends.Models
{
    public partial class newssiteContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=newssite;Trusted_Connection=True;");
        //}
        public newssiteContext(DbContextOptions<newssiteContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.AdminId).HasColumnName("admin_id");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Videopost>(entity =>
            {
                entity.HasKey(e => e.VideoId)
                    .HasName("PK__videopos__E8F62A685B2F902A");

                entity.ToTable("videopost");

                entity.Property(e => e.VideoId).HasColumnName("video_Id");

                entity.Property(e => e.VideoCategory)
                    .HasColumnName("video_category")
                    .HasMaxLength(30);

                entity.Property(e => e.VideoDiscription)
                    .HasColumnName("video_discription")
                    .HasMaxLength(100);

                entity.Property(e => e.VideoEmbed)
                    .HasColumnName("video_embed")
                    .HasMaxLength(100);

                entity.Property(e => e.VideoName)
                    .HasColumnName("video_name")
                    .HasMaxLength(50);
            });
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Videopost> Videopost { get; set; }
    }
}