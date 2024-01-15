using Microsoft.EntityFrameworkCore;
using Pages.Models;

namespace Pages.Data
{
    public class PagesUDDbContext : DbContext
    {
        public PagesUDDbContext(DbContextOptions<PagesUDDbContext> options) : base(options)
        {
        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionFile> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Section>()
                .HasOne(p => p.Page)
                .WithMany(s => s.Sections)
                .HasForeignKey(s => s.PageId);

            modelBuilder.Entity<SectionFile>()
                .HasOne(s => s.Section)
                .WithMany(f => f.Files)
                .HasForeignKey(f => f.SectionId);

            modelBuilder.Entity<Page>()
            .HasIndex(p => p.PageName)
            .IsUnique();

            modelBuilder.Entity<Section>()
            .HasIndex(p => p.EnglishName)
            .IsUnique();
        }
    }
}

