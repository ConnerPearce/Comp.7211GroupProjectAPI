using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Comp._7211GroupProjectAPI.Models
{
    public partial class Comp7211GroupProjectAPI20191115092109_dbContext : DbContext
    {
        public Comp7211GroupProjectAPI20191115092109_dbContext()
        {
        }

        public Comp7211GroupProjectAPI20191115092109_dbContext(DbContextOptions<Comp7211GroupProjectAPI20191115092109_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Settings> Settings { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=tcp:comp7211groupprojectapi20191115092109dbserver.database.windows.net,1433;Database=Comp7211GroupProjectAPI20191115092109_db;Persist Security Info=False;User ID=Comp7211GroupProject;Password=Google1#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AppTheme)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Uid).HasColumnName("UId");
            });
        }
    }
}
