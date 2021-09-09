using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mr_shtrahman.Models;

namespace mr_shtrahman.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options)
           : base(options)
        {
            //Database.set(new Context());
        }

        public DbSet<mr_shtrahman.Models.Img> Img { get; set; }

        public DbSet<mr_shtrahman.Models.Trip> Trip { get; set; }

        public DbSet<mr_shtrahman.Models.VisitorsAttendance> VisitorsAttendance { get; set; }

        public DbSet<mr_shtrahman.Models.Product> Product { get; set; }

        public DbSet<mr_shtrahman.Models.Shop> Shop { get; set; }

        public DbSet<mr_shtrahman.Models.User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TODO: Add to here for data seeding
            modelBuilder.Entity<Img>().HasOne(t => t.Trip).WithOne( );

            modelBuilder.Entity<Img>().HasData(
                new Img
                {
                    Id =1,
                    Src = "~Assets/trips/south/avdaat.jpg",
                    Description = "avdaat"
                });
        }
    }
}
