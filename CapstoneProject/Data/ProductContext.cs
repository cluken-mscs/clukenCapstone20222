using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapstoneProject.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CapstoneProject.Models;

namespace CapstoneProject.Data
{
    public class ProductContext : DbContext 
    { 
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Boot> Boots { get; set; }
        public DbSet<Coat> Coats { get; set; }
        public DbSet<Snowboard> Snowboards { get; set; }
        public DbSet<Helmet> Helmets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boot>().ToTable("Boots");
            modelBuilder.Entity<Coat>().ToTable("Coats");
            modelBuilder.Entity<Snowboard>().ToTable("Snowboards");
            modelBuilder.Entity<Helmet>().ToTable("Helmets");
        }
    }
}