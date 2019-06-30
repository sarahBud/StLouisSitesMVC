using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StLouisSitesMVC.Models;

namespace StLouisSitesMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        

        public DbSet<Location> Locations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<LocationCategory> LocationCategories { get; set; }
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Location>()
        //        .HasIndex(u => u.Name)
        //        .IsUnique();
        //}
    }
}
