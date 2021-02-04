using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdWebScraper.Models;

namespace AdWebScraper.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Car> Cars { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Advert>().ToTable("Adverts");
            builder.Entity<Advert>().HasKey(p => p._id);
            builder.Entity<Advert>().Property(p => p._id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Advert>().Property(p => p.Url).IsRequired();
            builder.Entity<Advert>().Property(p => p.DatePosted).IsRequired();
            builder.Entity<Advert>().Property(p => p.Description);
            builder.Entity<Advert>().HasOne(p => p.Car).WithOne(p => p.Advert).HasForeignKey<Car>(p => p.AdvertId);

            //To test endpoints
            builder.Entity<Advert>().HasData
            (
                new Advert { _id = 100, Url = "http://blank.com"},
                new Advert { _id = 101, Url = "http://blank.com/2"}
            );

            builder.Entity<Car>().ToTable("Cars");
            builder.Entity<Car>().HasKey(p => p._id);
            builder.Entity<Car>().Property(p => p._id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Car>().Property(p => p.MakeModel).IsRequired();
            builder.Entity<Car>().Property(p => p.Year).IsRequired();
            builder.Entity<Car>().Property(p => p.Price).IsRequired();
            builder.Entity<Car>().Property(p => p.Miles);
            builder.Entity<Car>().Property(p => p.Condition);
            builder.Entity<Car>().Property(p => p.Color);
        }
    }
}
