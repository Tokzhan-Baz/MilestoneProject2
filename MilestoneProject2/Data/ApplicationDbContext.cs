using Microsoft.EntityFrameworkCore;
using MilestoneProject2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MilestoneProject2.Models.Identity;

namespace MilestoneProject2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<News> News { get; set; }

       
        public DbSet<Projects> Projects{ get; set; }
      
        public DbSet<NewsN> NewsNs { get; set; }
        public DbSet<Startups> Startups { get; set; }
        public DbSet<StartupsNews> StartupsNews{ get; set; }
       

        public ApplicationDbContext(DbContextOptions options): base(options)
        {
           
        }

        protected ApplicationDbContext()
        {
        }

      

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StartupsNews>().HasKey(oc => new { oc.StartupsId, oc.NewsId });

            builder.Entity<StartupsNews>()
                .HasOne<Startups>(oc => oc.Startups)
                .WithMany(o => o.StartupsNews)
                .HasForeignKey(oc => oc.StartupsId);

            builder.Entity<StartupsNews>()
                .HasOne<News>(oc => oc.News)
                .WithMany(c => c.StartupsNews)
                .HasForeignKey(oc => oc.NewsId);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=Milestone.db");
        }

      
    
}
}
