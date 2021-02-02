using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Marketplace.API.Models
{
    public partial class MarketplaceDbContext : DbContext
    {
        public MarketplaceDbContext()
        {
        }

        public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Award> Awards { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<OtherName> OtherNames { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<StoryLine> StoryLines { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<TitleGenre> TitleGenres { get; set; }
        public virtual DbSet<TitleParticipant> TitleParticipants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Titles;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Award>(entity =>
            {
                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Awards)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Award_FK_Award_Title");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<OtherName>(entity =>
            {
                entity.HasOne(d => d.Title)
                    .WithMany(p => p.OtherNames)
                    .HasForeignKey(d => d.TitleId)
                    .HasConstraintName("OtherName_FK_OtherName_Title");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<StoryLine>(entity =>
            {
                entity.HasOne(d => d.Title)
                    .WithMany(p => p.StoryLines)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StoryLine_FK_StoryLine_Title");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.Property(e => e.TitleId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TitleGenre>(entity =>
            {
                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.TitleGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TitleGenre_FK_TitleGenre_Genre");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.TitleGenres)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TitleGenre_FK_TitleGenre_Title");
            });

            modelBuilder.Entity<TitleParticipant>(entity =>
            {
                entity.HasOne(d => d.Participant)
                    .WithMany(p => p.TitleParticipants)
                    .HasForeignKey(d => d.ParticipantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TitleParticipant_FK_TitleParticipant_Participant");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.TitleParticipants)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TitleParticipant_FK_TitleParticipant_Title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
