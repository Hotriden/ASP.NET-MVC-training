using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckSitemap.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CheckSitemap.DAL.EF
{
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
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CheckSitemapAppDb;Trusted_Connection=True;");
        }
    }
}