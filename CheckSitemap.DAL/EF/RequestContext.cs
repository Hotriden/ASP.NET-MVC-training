using CheckSitemap.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CheckSitemap.DAL.EF
{
    /// <summary>
    /// EF interface of interaction with database
    /// Model first
    /// Changed EF to EF core
    /// </summary>
    public class RequestContext:DbContext
    {
        public RequestContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Site> Sites { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CheckSitemapAppDb;Trusted_Connection=True;"); // Should be on root folder - fix it
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Site>().HasMany(t => t.Requests).WithOne(x => x.site).HasForeignKey(s => s.CurrentSiteId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Request>().Property(c => c.TimeRequest).HasMaxLength(7);
            modelBuilder.Entity<Site>().Property(c => c.SummaryTime).HasMaxLength(7);
        }
    }
}