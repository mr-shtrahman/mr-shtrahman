using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mr_shtrahman.Models;
using mr_shtrahman.enums;

namespace mr_shtrahman.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options)
           : base(options)
        {
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

            addImg(modelBuilder);
            addVisitorsAttendance(modelBuilder);

        }

        private void addVisitorsAttendance(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VisitorsAttendance>().HasData(
                new VisitorsAttendance
                {
                     Id =1,
                     TripId = 1,
                     Attendance = 20,
                     Date= new DateTime(2021,9,10)
                }, new VisitorsAttendance
                {
                    Id = 2,
                    TripId = 1,
                    Attendance = 18,
                    Date = new DateTime(2021, 9, 11)
                }, new VisitorsAttendance
                {
                    Id = 3,
                    TripId = 1,
                    Attendance =  23,
                    Date = new DateTime(2021, 9, 12)
                }, new VisitorsAttendance
                {
                    Id = 4,
                    TripId = 1,
                    Attendance =  26,
                    Date = new DateTime(2021, 9, 13)
                }, new VisitorsAttendance
                {
                    Id = 5,
                    TripId = 1,
                    Attendance =  23,
                    Date = new DateTime(2021, 9, 14)
                }, new VisitorsAttendance
                {
                    Id = 6,
                    TripId = 1,
                    Attendance =  25,
                    Date = new DateTime(2021, 9, 15)
                }, new VisitorsAttendance
                {
                    Id = 7,
                    TripId = 1,
                    Attendance =  35,
                    Date = new DateTime(2021, 9, 16)
                }, new VisitorsAttendance
                {
                    Id = 8,
                    TripId = 1,
                    Attendance =  27,
                    Date = new DateTime(2021, 9, 17)
                }, new VisitorsAttendance
                {
                    Id = 9,
                    TripId = 1,
                    Attendance =  15,
                    Date = new DateTime(2021, 9, 18)
                }, new VisitorsAttendance
                {
                    Id = 10,
                    TripId = 1,
                    Attendance =  18,
                    Date = new DateTime(2021, 9, 19)
                },new VisitorsAttendance
                {
                    Id = 11,
                    TripId = 2,
                    Attendance =  18,
                    Date = new DateTime(2021, 9, 10)
                }, new VisitorsAttendance
                {
                    Id = 12,
                    TripId = 2,
                    Attendance = 18,
                    Date = new DateTime(2021, 9, 11)
                }, new VisitorsAttendance
                {
                    Id = 13,
                    TripId = 2,
                    Attendance =  17,
                    Date = new DateTime(2021, 9, 12)
                }, new VisitorsAttendance
                {
                    Id = 14,
                    TripId = 2,
                    Attendance =  31,
                    Date = new DateTime(2021, 9, 13)
                }, new VisitorsAttendance
                {
                    Id = 15,
                    TripId = 1,
                    Attendance =  32,
                    Date = new DateTime(2021, 9, 14)
                }, new VisitorsAttendance
                {
                    Id = 16,
                    TripId = 2,
                    Attendance =  22,
                    Date = new DateTime(2021, 9, 15)
                }, new VisitorsAttendance
                {
                    Id = 17,
                    TripId = 2,
                    Attendance =  23,
                    Date = new DateTime(2021, 9, 16)
                }, new VisitorsAttendance
                {
                    Id = 18,
                    TripId = 2,
                    Attendance =  25,
                    Date = new DateTime(2021, 9, 17)
                }, new VisitorsAttendance
                {
                    Id = 19,
                    TripId = 2,
                    Attendance =  22,
                    Date = new DateTime(2021, 9, 18)
                }, new VisitorsAttendance
                {
                    Id = 20,
                    TripId = 2,
                    Attendance =  21,
                    Date = new DateTime(2021, 9, 19)
                }, new VisitorsAttendance
                {
                    Id = 21,
                    TripId = 11,
                    Attendance = 20,
                    Date = new DateTime(2021, 9, 10)
                }, new VisitorsAttendance
                {
                    Id = 22,
                    TripId = 11,
                    Attendance = 18,
                    Date = new DateTime(2021, 9, 11)
                }, new VisitorsAttendance
                {
                    Id = 23,
                    TripId = 11,
                    Attendance = 20,
                    Date = new DateTime(2021, 9, 12)
                }, new VisitorsAttendance
                {
                    Id = 24,
                    TripId = 11,
                    Attendance = 25,
                    Date = new DateTime(2021, 9, 13)
                }, new VisitorsAttendance
                {
                    Id = 25,
                    TripId = 11,
                    Attendance = 20,
                    Date = new DateTime(2021, 9, 14)
                }, new VisitorsAttendance
                {
                    Id = 26,
                    TripId = 11,
                    Attendance = 27,
                    Date = new DateTime(2021, 9, 15)
                }, new VisitorsAttendance
                {
                    Id = 27,
                    TripId = 11,
                    Attendance = 20,
                    Date = new DateTime(2021, 9, 16)
                }, new VisitorsAttendance
                {
                    Id = 28,
                    TripId = 11,
                    Attendance = 37,
                    Date = new DateTime(2021, 9, 17)
                }, new VisitorsAttendance
                {
                    Id = 29,
                    TripId = 11,
                    Attendance = 36,
                    Date = new DateTime(2021, 9, 18)
                }, new VisitorsAttendance
                {
                    Id = 31,
                    TripId = 3,
                    Attendance =  21,
                    Date = new DateTime(2021, 9, 10)
                }, new VisitorsAttendance
                {
                    Id = 32,
                    TripId = 3,
                    Attendance = 18,
                    Date = new DateTime(2021, 9, 11)
                }, new VisitorsAttendance
                {
                    Id = 33,
                    TripId = 3,
                    Attendance =  17,
                    Date = new DateTime(2021, 9, 12)
                }, new VisitorsAttendance
                {
                    Id = 34,
                    TripId = 3,
                    Attendance =  19,
                    Date = new DateTime(2021, 9, 13)
                }, new VisitorsAttendance
                {
                    Id = 35,
                    TripId = 3,
                    Attendance =  18,
                    Date = new DateTime(2021, 9, 14)
                }, new VisitorsAttendance
                {
                    Id = 36,
                    TripId = 3,
                    Attendance =  17,
                    Date = new DateTime(2021, 9, 15)
                }, new VisitorsAttendance
                {
                    Id = 37,
                    TripId = 3,
                    Attendance =  18,
                    Date = new DateTime(2021, 9, 16)
                }, new VisitorsAttendance
                {
                    Id = 38,
                    TripId = 3,
                    Attendance =  20,
                    Date = new DateTime(2021, 9, 17)
                }, new VisitorsAttendance
                {
                    Id = 39,
                    TripId = 3,
                    Attendance =  21,
                    Date = new DateTime(2021, 9, 18)
                }, new VisitorsAttendance
                {
                    Id = 30,
                    TripId = 3,
                    Attendance =  29,
                    Date = new DateTime(2021, 9, 19)
                }, new VisitorsAttendance
                {
                    Id = 41,
                    TripId = 4,
                    Attendance =  23,
                    Date = new DateTime(2021, 9, 10)
                }, new VisitorsAttendance
                {
                    Id = 42,
                    TripId = 4,
                    Attendance = 18,
                    Date = new DateTime(2021, 9, 11)
                }, new VisitorsAttendance
                {
                    Id = 43,
                    TripId = 4,
                    Attendance =  21,
                    Date = new DateTime(2021, 9, 12)
                }, new VisitorsAttendance
                {
                    Id = 44,
                    TripId = 4,
                    Attendance =  2,
                    Date = new DateTime(2021, 9, 13)
                }, new VisitorsAttendance
                {
                    Id = 45,
                    TripId = 4,
                    Attendance =  28,
                    Date = new DateTime(2021, 9, 14)
                }, new VisitorsAttendance
                {
                    Id = 46,
                    TripId = 4,
                    Attendance =  2,
                    Date = new DateTime(2021, 9, 15)
                }, new VisitorsAttendance
                {
                    Id = 47,
                    TripId = 4,
                    Attendance =  21,
                    Date = new DateTime(2021, 9, 16)
                }, new VisitorsAttendance
                {
                    Id = 48,
                    TripId = 4,
                    Attendance =  28,
                    Date = new DateTime(2021, 9, 17)
                }, new VisitorsAttendance
                {
                    Id = 49,
                    TripId = 4,
                    Attendance =  34,
                    Date = new DateTime(2021, 9, 18)
                }, new VisitorsAttendance
                {
                    Id = 40,
                    TripId = 4,
                    Attendance =  33,
                    Date = new DateTime(2021, 9, 19)
                }, new VisitorsAttendance
                {
                    Id = 51,
                    TripId = 5,
                    Attendance =  40,
                    Date = new DateTime(2021, 9, 10)
                }, new VisitorsAttendance
                {
                    Id = 52,
                    TripId = 5,
                    Attendance = 18,
                    Date = new DateTime(2021, 9, 11)
                }, new VisitorsAttendance
                {
                    Id = 53,
                    TripId = 5,
                    Attendance =  41,
                    Date = new DateTime(2021, 9, 12)
                }, new VisitorsAttendance
                {
                    Id = 54,
                    TripId = 5,
                    Attendance =  45,
                    Date = new DateTime(2021, 9, 13)
                }, new VisitorsAttendance
                {
                    Id = 55,
                    TripId = 5,
                    Attendance =  46,
                    Date = new DateTime(2021, 9, 14)
                }, new VisitorsAttendance
                {
                    Id = 56,
                    TripId = 5,
                    Attendance =  47,
                    Date = new DateTime(2021, 9, 15)
                }, new VisitorsAttendance
                {
                    Id = 57,
                    TripId = 5,
                    Attendance =  47,
                    Date = new DateTime(2021, 9, 16)
                }, new VisitorsAttendance
                {
                    Id = 58,
                    TripId = 5,
                    Attendance =  43,
                    Date = new DateTime(2021, 9, 17)
                }, new VisitorsAttendance
                {
                    Id = 59,
                    TripId = 5,
                    Attendance =  40,
                    Date = new DateTime(2021, 9, 18)
                }, new VisitorsAttendance
                {
                    Id = 50,
                    TripId = 5,
                    Attendance =  41,
                    Date = new DateTime(2021, 9, 19)
                }, new VisitorsAttendance
                {
                    Id = 61,
                    TripId = 6,
                    Attendance =  21,
                    Date = new DateTime(2021, 9, 10)
                }, new VisitorsAttendance
                {
                    Id = 62,
                    TripId = 6,
                    Attendance = 18,
                    Date = new DateTime(2021, 9, 11)
                }, new VisitorsAttendance
                {
                    Id = 63,
                    TripId = 6,
                    Attendance =  19,
                    Date = new DateTime(2021, 9, 12)
                }, new VisitorsAttendance
                {
                    Id = 64,
                    TripId = 6,
                    Attendance =  18,
                    Date = new DateTime(2021, 9, 13)
                }, new VisitorsAttendance
                {
                    Id = 65,
                    TripId = 6,
                    Attendance =  17,
                    Date = new DateTime(2021, 9, 14)
                }, new VisitorsAttendance
                {
                    Id = 66,
                    TripId = 6,
                    Attendance =  19,
                    Date = new DateTime(2021, 9, 15)
                }, new VisitorsAttendance
                {
                    Id = 67,
                    TripId = 6,
                    Attendance =  19,
                    Date = new DateTime(2021, 9, 16)
                }, new VisitorsAttendance
                {
                    Id = 68,
                    TripId = 6,
                    Attendance =  18,
                    Date = new DateTime(2021, 9, 17)
                }, new VisitorsAttendance
                {
                    Id = 69,
                    TripId = 6,
                    Attendance =  29,
                    Date = new DateTime(2021, 9, 18)
                }, new VisitorsAttendance
                {
                    Id = 60,
                    TripId = 6,
                    Attendance =  24,
                    Date = new DateTime(2021, 9, 19)
                }, new VisitorsAttendance
                {
                    Id = 71,
                    TripId = 7,
                    Attendance =  29,
                    Date = new DateTime(2021, 9, 10)
                }, new VisitorsAttendance
                {
                    Id = 72,
                    TripId = 7,
                    Attendance = 18,
                    Date = new DateTime(2021, 9, 11)
                }, new VisitorsAttendance
                {
                    Id = 73,
                    TripId = 7,
                    Attendance =  28,
                    Date = new DateTime(2021, 9, 12)
                }, new VisitorsAttendance
                {
                    Id = 74,
                    TripId = 7,
                    Attendance =  31,
                    Date = new DateTime(2021, 9, 13)
                }, new VisitorsAttendance
                {
                    Id = 75,
                    TripId = 7,
                    Attendance =  24,
                    Date = new DateTime(2021, 9, 14)
                }, new VisitorsAttendance
                {
                    Id = 76,
                    TripId = 7,
                    Attendance =  24,
                    Date = new DateTime(2021, 9, 15)
                }, new VisitorsAttendance
                {
                    Id = 77,
                    TripId = 7,
                    Attendance =  42,
                    Date = new DateTime(2021, 9, 16)
                }, new VisitorsAttendance
                {
                    Id = 78,
                    TripId = 7,
                    Attendance =  24,
                    Date = new DateTime(2021, 9, 17)
                }, new VisitorsAttendance
                {
                    Id = 79,
                    TripId = 7,
                    Attendance =  1,
                    Date = new DateTime(2021, 9, 18)
                }, new VisitorsAttendance
                {
                    Id = 70,
                    TripId = 7,
                    Attendance =  11,
                    Date = new DateTime(2021, 9, 19)
                }, new VisitorsAttendance
                {
                    Id = 81,
                    TripId = 8,
                    Attendance = 20,
                    Date = new DateTime(2021, 9, 10)
                }, new VisitorsAttendance
                {
                    Id = 82,
                    TripId = 8,
                    Attendance = 18,
                    Date = new DateTime(2021, 9, 11)
                }, new VisitorsAttendance
                {
                    Id = 83,
                    TripId = 8,
                    Attendance = 20,
                    Date = new DateTime(2021, 9, 12)
                }, new VisitorsAttendance
                {
                    Id = 84,
                    TripId = 8,
                    Attendance = 20,
                    Date = new DateTime(2021, 9, 13)
                }, new VisitorsAttendance
                {
                    Id = 85,
                    TripId = 8,
                    Attendance = 20,
                    Date = new DateTime(2021, 9, 14)
                }, new VisitorsAttendance
                {
                    Id = 86,
                    TripId = 8,
                    Attendance =  28,
                    Date = new DateTime(2021, 9, 15)
                }, new VisitorsAttendance
                {
                    Id = 87,
                    TripId = 8,
                    Attendance =  28,
                    Date = new DateTime(2021, 9, 16)
                }, new VisitorsAttendance
                {
                    Id = 88,
                    TripId = 8,
                    Attendance =  22,
                    Date = new DateTime(2021, 9, 17)
                }, new VisitorsAttendance
                {
                    Id = 89,
                    TripId = 8,
                    Attendance =  26,
                    Date = new DateTime(2021, 9, 18)
                }, new VisitorsAttendance
                {
                    Id = 80,
                    TripId = 8,
                    Attendance =  26,
                    Date = new DateTime(2021, 9, 19)
                }, new VisitorsAttendance
                {
                    Id = 91,
                    TripId = 9,
                    Attendance =  26,
                    Date = new DateTime(2021, 9, 10)
                }, new VisitorsAttendance
                {
                    Id = 92,
                    TripId = 9,
                    Attendance = 18,
                    Date = new DateTime(2021, 9, 11)
                }, new VisitorsAttendance
                {
                    Id = 93,
                    TripId = 9,
                    Attendance =  27,
                    Date = new DateTime(2021, 9, 12)
                }, new VisitorsAttendance
                {
                    Id = 94,
                    TripId = 9,
                    Attendance =  23,
                    Date = new DateTime(2021, 9, 13)
                }, new VisitorsAttendance
                {
                    Id = 95,
                    TripId = 9,
                    Attendance =  12,
                    Date = new DateTime(2021, 9, 14)
                }, new VisitorsAttendance
                {
                    Id = 96,
                    TripId = 9,
                    Attendance =  12,
                    Date = new DateTime(2021, 9, 15)
                }, new VisitorsAttendance
                {
                    Id = 97,
                    TripId = 9,
                    Attendance =  31,
                    Date = new DateTime(2021, 9, 16)
                }, new VisitorsAttendance
                {
                    Id = 98,
                    TripId = 9,
                    Attendance =  32,
                    Date = new DateTime(2021, 9, 17)
                }, new VisitorsAttendance
                {
                    Id = 99,
                    TripId = 9,
                    Attendance =  33,
                    Date = new DateTime(2021, 9, 18)
                }, new VisitorsAttendance
                {
                    Id = 91,
                    TripId = 9,
                    Attendance =  35,
                    Date = new DateTime(2021, 9, 19)
                }, new VisitorsAttendance
                {
                    Id = 101,
                    TripId = 10,
                    Attendance =  25,
                    Date = new DateTime(2021, 9, 10)
                }, new VisitorsAttendance
                {
                    Id = 102,
                    TripId = 10,
                    Attendance = 18,
                    Date = new DateTime(2021, 9, 11)
                }, new VisitorsAttendance
                {
                    Id = 103,
                    TripId = 10,
                    Attendance =  21,
                    Date = new DateTime(2021, 9, 12)
                }, new VisitorsAttendance
                {
                    Id = 104,
                    TripId = 10,
                    Attendance =  23,
                    Date = new DateTime(2021, 9, 13)
                }, new VisitorsAttendance
                {
                    Id = 105,
                    TripId = 10,
                    Attendance =  21,
                    Date = new DateTime(2021, 9, 14)
                }, new VisitorsAttendance
                {
                    Id = 106,
                    TripId = 10,
                    Attendance =  20,
                    Date = new DateTime(2021, 9, 15)
                }, new VisitorsAttendance
                {
                    Id = 107,
                    TripId = 10,
                    Attendance =  20,
                    Date = new DateTime(2021, 9, 16)
                }, new VisitorsAttendance
                {
                    Id = 108,
                    TripId = 10,
                    Attendance =  27,
                    Date = new DateTime(2021, 9, 17)
                }, new VisitorsAttendance
                {
                    Id = 109,
                    TripId = 10,
                    Attendance =  26,
                    Date = new DateTime(2021, 9, 18)
                }, new VisitorsAttendance
                {
                    Id = 100,
                    TripId = 10,
                    Attendance = 20,
                    Date = new DateTime(2021, 9, 19)
                }
                );
        }

        protected void addImg(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Img>().HasData(
                new Img
                {
                    Id = 1,
                    Src = "~/Assets/categories/bags.jpg",
                    Description = "bags"
                },
                new Img
                {
                    Id = 2,
                    Src = "~/Assets/categories/camping.jpg",
                    Description = "camping"
                },
                new Img
                {
                    Id = 3,
                    Src = "~/Assets/categories/clothes.jpg",
                    Description = "clothes"
                },
                new Img
                {
                    Id = 4,
                    Src = "~/Assets/categories/gadgets.jpg",
                    Description = "gadgets"
                },
                new Img
                {
                    Id = 5,
                    Src = "~/Assets/categories/shoes.jpg",
                    Description = "shoes"
                },         
                new Img
                {
                    Id = 6,
                    Src = "~/Assets/categories/soldiers.jpg",
                    Description = "clothes"
                },
                new Img
                {
                    Id = 7,
                    Src = "~/Assets/trips/south/avdaat.jpg",
                    Description = "avdaat"
                }, 
                new Img
                {
                    Id = 8,
                    Src = "~/Assets/trips/south/bashor.jpg",
                    Description = "bashor"
                }, 
                new Img
                {
                    Id = 9,
                    Src = "~/Assets/trips/south/ein-gedi.jpg",
                    Description = "ein-gedi"
                },
                new Img
                {
                    Id = 10,
                    Src = "~/Assets/trips/south/gov.jpg",
                    Description = "gov"
                }, 
                new Img
                {
                    Id = 11,
                    Src = "~/Assets/trips/south/makhtesh-ramon.jpg",
                    Description = "makhtesh-ramon"
                }, 
                new Img
                {
                    Id = 12,
                    Src = "~/Assets/trips/south/mesada.jpg",
                    Description = "mesada"
                },
                new Img
                {
                    Id = 13,
                    Src = "~/Assets/trips/south/peres.jpg",
                    Description = "peres"
                },
                new Img
                {
                    Id = 14,
                    Src = "~/Assets/trips/south/prat.jpg",
                    Description = "prat"
                }, 
                new Img
                {
                    Id = 15,
                    Src = "~/Assets/trips/south/rahaf.jpg",
                    Description = "rahaf"
                },
                new Img
                {
                    Id = 16,
                    Src = "~/Assets/trips/south/red-canyon.jpg",
                    Description = "red-canyon"
                },
                new Img
                {
                    Id = 17,
                    Src = "~/Assets/trips/south/shivta.jpg",
                    Description = "shivta"
                },
                new Img
                {
                    Id = 18,
                    Src = "~/Assets/trips/south/timna.jpg",
                    Description = "timna"
                }, 
                new Img
                {
                    Id = 19,
                    Src = "~/Assets/trips/south/vardit-canyon.jpg",
                    Description = "vardit-canyon"
                }, 
                new Img
                {
                    Id = 20,
                    Src = "~/Assets/trips/south/zeelim.jpg",
                    Description = "zeelim"
                },
                new Img
                {
                    Id = 21,
                    Src = "~/Assets/trips/center/alexander.jpg",
                    Description = "gadgets"
                }, 
                new Img
                {
                    Id = 22,
                    Src = "~/Assets/trips/center/britania.jpg",
                    Description = "britania"
                },
                new Img
                {
                    Id = 23,
                    Src = "~/Assets/trips/center/caesarea.jpg",
                    Description = "caesarea"
                },
                new Img
                {
                    Id = 108,
                    Src = "~/Assets/trips/center/carmila.jpg",
                    Description = "carmila"
                },
                new Img
                {
                    Id = 24,
                    Src = "~/Assets/trips/center/david-garden.jpg",
                    Description = "david-garden"
                },
                new Img
                {
                    Id = 25,
                    Src = "~/Assets/trips/center/florentin.jpg",
                    Description = "florentin"
                },
                new Img
                {
                    Id = 26,
                    Src = "~/Assets/trips/center/gamzo.jpg",
                    Description = "gamzo"
                },
                new Img
                {
                    Id = 27,
                    Src = "~/Assets/trips/center/jaffa.jpg",
                    Description = "jaffa"
                },
                new Img
                {
                    Id = 28,
                    Src = "~/Assets/trips/center/jerusalem.jpg",
                    Description = "jerusalem"
                },
                new Img
                {
                    Id = 29,
                    Src = "~/Assets/trips/center/king-george.jpg",
                    Description = "king-george"
                },
                new Img
                {
                    Id = 30,
                    Src = "~/Assets/trips/center/mahne-yehuda.jpg",
                    Description = "mahne-yehuda"
                },
                new Img
                {
                    Id = 31,
                    Src = "~/Assets/trips/center/alexander.jpg",
                    Description = "gadgets"
                },
                new Img
                {
                    Id = 32,
                    Src = "~/Assets/trips/center/palmahim.jpg",
                    Description = "palmahim"
                },
                new Img
                {
                    Id = 33,
                    Src = "~/Assets/trips/center/poleg.jpg",
                    Description = "poleg"
                },
                new Img
                {
                    Id = 34,
                    Src = "~/Assets/trips/center/rishon-letzion.jpg",
                    Description = "rishon-letzion"
                },
                new Img
                {
                    Id = 35,
                    Src = "~/Assets/trips/center/roses-garden.jpg",
                    Description = "roses-garden"
                },
                new Img
                {
                    Id = 36,
                    Src = "~/Assets/trips/center/salit.jpg",
                    Description = "salit"
                },
                new Img
                {
                    Id = 107,
                    Src = "~/Assets/trips/center/shaananim.jpg",
                    Description = "shaananim"
                },
                new Img
                {
                    Id = 37,
                    Src = "~/Assets/trips/center/shfela.jpg",
                    Description = "shfela"
                },
                 new Img
                 {
                     Id =38 ,
                     Src = "~/Assets/trips/north/acre.jpg",
                     Description = "acre"
                 },
                 new Img
                 {
                     Id =39 ,
                     Src = "~/Assets/trips/north/afek.jpg",
                     Description = "afek"
                 },
                 new Img
                 {
                     Id = 40,
                     Src = "~/Assets/trips/north/binyamina.jpg",
                     Description = "binyamina"
                 },
                 new Img
                 {
                     Id = 41,
                     Src = "~/Assets/trips/north/bonim.jpg",
                     Description = "bonim"
                 },
                 new Img
                 {
                     Id = 42,
                     Src = "~/Assets/trips/north/carmel-caves.jpg",
                     Description = "carmel-caves"
                 },
                 new Img
                 {
                     Id = 43,
                     Src = "~/Assets/trips/north/dishon.jpg",
                     Description = "dishon"
                 },
                 new Img
                 {
                     Id = 44,
                     Src = "~/Assets/trips/north/golan.jpg",
                     Description = "golan"
                 },
                 new Img
                 {
                     Id =45 ,
                     Src = "~/Assets/trips/north/golan-amphitheater.jpg",
                     Description = "golan-amphitheater"
                 },
                 new Img
                 {
                     Id =46 ,
                     Src = "~/Assets/trips/north/hula-valley.jpg",
                     Description = "hula-valley"
                 },
                 new Img
                 {
                     Id = 47,
                     Src = "~/Assets/trips/north/kziv.jpg",
                     Description = "kziv"
                 },
                 new Img
                 {
                     Id = 48,
                     Src = "~/Assets/trips/north/meitsar.jpg",
                     Description = "meitsar"
                 },
                 new Img
                 {
                     Id =49 ,
                     Src = "~/Assets/trips/north/miron.jpg",
                     Description = "miron"
                 },
                 new Img
                 {
                     Id = 50,
                     Src = "~/Assets/trips/north/orvim.jpg",
                     Description = "orvim"
                 },
                 new Img
                 {
                     Id = 51,
                     Src = "~/Assets/trips/north/rosh-pina.jpg",
                     Description = "rosh-pina"
                 },
                 new Img
                 {
                     Id =52 ,
                     Src = "~/Assets/trips/north/saar.jpg",
                     Description = "saar"
                 },
                 new Img
                 {
                     Id = 53,
                     Src = "~/Assets/trips/north/shofet.jpg",
                     Description = "shofet"
                 },
                 new Img
                 {
                     Id = 54,
                     Src = "~/Assets/trips/north/tanur.jpg",
                     Description = "tanur"
                 },
                 new Img
                 {
                     Id = 55,
                     Src = "~/Assets/shops/shop1.jpg",
                     Description = "shop1"
                 },
                 new Img
                 {
                     Id = 56,
                     Src = "~/Assets/shops/shop2.jpg",
                     Description = "shop2"
                 },
                 new Img
                 {
                     Id = 57,
                     Src = "~/Assets/shops/shop3.jpg",
                     Description = "shop3"
                 },
                 new Img
                 {
                     Id = 58,
                     Src = "~/Assets/shops/shop4.jpg",
                     Description = "shop4"
                 },
                 new Img
                 {
                     Id = 59,
                     Src = "~/Assets/shops/shop5.jpg",
                     Description = "shop5"
                 },
                 new Img
                 {
                     Id = 60,
                     Src = "~/Assets/shops/shop6.jpg",
                     Description = "shop6"
                 },
                 new Img
                 {
                     Id = 61,
                     Src = "~/Assets/shops/shop7.jpg",
                     Description = "shop7"
                 },
                 new Img
                 {
                     Id = 62,
                     Src = "~/Assets/shops/shop8.jpg",
                     Description = "shop8"
                 },
                 new Img
                 {
                     Id = 63,
                     Src = "~/Assets/shops/shop9.jpg",
                     Description = "shop9"
                 },
                 new Img
                 {
                     Id =64 ,
                     Src = "~/Assets/products/bags/backpack1.jpg",
                     Description = "backpack1"
                 },

                 new Img
                 {
                     Id =65 ,
                     Src = "~/Assets/products/bags/backpack2.jpg",
                     Description = "backpack2"
                 },
                 new Img
                 {
                     Id =66 ,
                     Src = "~/Assets/products/bags/backpack3.jpg",
                     Description = "backpack3"
                 },
                 new Img
                 {
                     Id = 67,
                     Src = "~/Assets/products/bags/backpack4.jpg",
                     Description = "backpack4"
                 },
                 new Img
                 {
                     Id =68 ,
                     Src = "~/Assets/products/bags/backpack5.jpg",
                     Description = "backpack5"
                 },
                 new Img
                 {
                     Id =69 ,
                     Src = "~/Assets/products/bags/backpack5.jpg",
                     Description = "backpack5"
                 },
                 new Img
                 {
                     Id = 70,
                     Src = "~/Assets/products/bags/bag1.jpg",
                     Description = "bag1"
                 },
                 new Img
                 {
                     Id = 71,
                     Src = "~/Assets/products/bags/bag2.jpg",
                     Description = "bag2"
                 },
                 new Img
                 {
                     Id = 72,
                     Src = "~/Assets/products/bags/bag3.jpg",
                     Description = "bag3"
                 },
                 new Img
                 {
                     Id = 73,
                     Src = "~/Assets/products/bags/bag4.jpg",
                     Description = "bag4"
                 },
                 new Img
                 {
                     Id = 74,
                     Src = "~/Assets/products/bags/bag5.jpg",
                     Description = "bag5"
                 },
                 new Img
                 {
                     Id = 75,
                     Src = "~/Assets/products/bags/bag6.jpg",
                     Description = "bag6"
                 },
                 new Img
                 {
                     Id = 76,
                     Src = "~/Assets/products/bags/bag7.jpg",
                     Description = "bag7"
                 },
                 new Img
                 {
                     Id = 77,
                     Src = "~/Assets/products/bags/bag8.jpg",
                     Description = "bag8"
                 },
                 new Img
                 {
                     Id = 78,
                     Src = "~/Assets/products/bags/bag9.jpg",
                     Description = "bag9"
                 },
                 new Img
                 {
                     Id = 79,
                     Src = "~/Assets/products/bags/bag10.jpg",
                     Description = "bag"
                 },
                 new Img
                 {
                     Id = 80,
                     Src = "~/Assets/products/camping/chair1.jpg",
                     Description = "chair1"
                 },
                 new Img
                 {
                     Id =81 ,
                     Src = "~/Assets/products/camping/chair2.jpg",
                     Description = "chair2"
                 },
                 new Img
                 {
                     Id =82 ,
                     Src = "~/Assets/products/camping/chair3.jpg",
                     Description = "chair3"
                 },
                 new Img
                 {
                     Id = 83,
                     Src = "~/Assets/products/camping/cooking1.jpg",
                     Description = "cooking1"
                 },
                 new Img
                 {
                     Id =84 ,
                     Src = "~/Assets/products/camping/cooking2.jpg",
                     Description = "cooking2"
                 },
                 new Img
                 {
                     Id = 85,
                     Src = "~/Assets/products/camping/cooking3.jpg",
                     Description = "cooking3"
                 },

                 new Img
                 {
                     Id = 86,
                     Src = "~/Assets/products/camping/sleepingbag1.jpg",
                     Description = "sleepingbag1"
                 },
                 new Img
                 {
                     Id = 87,
                     Src = "~/Assets/products/camping/sleepingbag2.jpg",
                     Description = "sleepingbag2"
                 },
                 new Img
                 {
                     Id = 88,
                     Src = "~/Assets/products/camping/sleepingbag3.jpg",
                     Description = "sleepingbag3"
                 },
                 new Img
                 {
                     Id = 89,
                     Src = "~/Assets/products/clothing/coat1.jpg",
                     Description = "coat1"
                 },
                 new Img
                 {
                     Id = 90,
                     Src = "~/Assets/products/clothing/coat2.jpg",
                     Description = "coat2"
                 },
                 new Img
                 {
                     Id = 91,
                     Src = "~Assets/products/clothing/coat3.jpg",
                     Description = "coat3"
                 },
                 new Img
                 {
                     Id = 92,
                     Src = "~/Assets/products/clothing/coat4.jpg",
                     Description = "coat4"
                 },
                 new Img
                 {
                     Id = 93,
                     Src = "~/Assets/products/clothing/coat5.jpg",
                     Description = "coat5"
                 },
                 new Img
                 {
                     Id = 94,
                     Src = "~/Assets/products/clothing/pants1.jpg",
                     Description = "pants1"
                 },
                 new Img
                 {
                     Id = 95,
                     Src = "~/Assets/products/shoes/blandston1.jpg",
                     Description = "blandston1"
                 },
                 new Img
                 {
                     Id =96 ,
                     Src = "~/Assets/products/shoes/shoes1.jpg",
                     Description = "shoes1"
                 },
                 new Img
                 {
                     Id =97 ,
                     Src = "~/Assets/products/shoes/shoresh1.jpg",
                     Description = "shoresh1"
                 },
                 new Img
                 {
                     Id = 98,
                     Src = "~/Assets/products/shoes/shoresh2.jpg",
                     Description = "shoresh2"
                 },
                 new Img
                 {
                     Id = 99,
                     Src = "~/Assets/products/gadgets/ac.jpg",
                     Description = "ac"
                 },
                 new Img
                 {
                     Id = 100,
                     Src = "~/Assets/products/gadgets/camera-bag.jpg",
                     Description = "camera-bag"
                 },
                 new Img
                 {
                     Id = 101,
                     Src = "~/Assets/products/gadgets/compass.jpg",
                     Description = "compass"
                 },
                 new Img
                 {
                     Id = 102,
                     Src = "~/Assets/products/soldiers/belt.jpg",
                     Description = "belt"
                 },
                 new Img
                 {
                     Id = 103,
                     Src = "~/Assets/products/soldiers/beret.jpg",
                     Description = "beret"
                 },
                 new Img
                 {
                     Id = 104,
                     Src = "~/Assets/products/soldiers/gshock.jpg",
                     Description = "gshock"
                 },
                 new Img
                 {
                     Id = 105,
                     Src = "~/Assets/products/soldiers/leatherman.jpg",
                     Description = "leatherman"
                 },
                 new Img
                 {
                     Id = 106,
                     Src = "~/Assets/products/soldiers/white-shirt.jpg",
                     Description = "white-shirt"
                 }
                );
        }

        protected void addProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Blandston",
                    Rating = 5,
                    Category = Category.Shoes,
                    Color = "Brown",
                    Price = 250,
                    Size = Size.L,
                    Description = "Most sought after for a reason. Everything you love about our Original boots, turned up to max.",
                    Details = "",
                    ImgId = 95,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product{
                    Id = 2,
                    Name = "Running Shoes",
                    Rating = 2,
                    Category = Category.Shoes,
                    Color = "Brown",
                    Price = 470,
                    Size = Size.M,
                    Description = "Best shoes to feel like your floating while running.",
                    Details = "",
                    ImgId = 96,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 3,
                    Name = "Shoresh Sandals",
                    Rating = 5,
                    Category = Category.Shoes,
                    Color = "Red",
                    Price = 300,
                    Size = Size.S,
                    Description = "The beloved Israeli sandals for hiking, entering the water and looking like a nerd.",
                    Details = "",
                    ImgId = 97,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 4,
                    Name = "Shoresh Sandals",
                    Rating = 5,
                    Category = Category.Shoes,
                    Color = "Black",
                    Price = 300,
                    Size = Size.L,
                    Description = "The beloved Israeli sandals for hiking, entering the water and looking like a nerd.",
                    Details = "",
                    ImgId = 98,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product 
                {
                    Id = 5,
                    Name = "Portable AC",
                    Rating = 3,
                    Category = Category.Gadgets,
                    Color = "Blue",
                    Price = 640,
                    Size = Size.OneSize,
                    Description = "The device that will save you from the heat and scare the mosquitos away. A must-have for every camp!",
                    Details = "",
                    ImgId = 99,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 6,
                    Name = "Camera Bag",
                    Rating = 4,
                    Category = Category.Gadgets,
                    Color = "Green",
                    Price = 500,
                    Size = Size.OneSize,
                    Description = "Protect your equipmment the way it deserves.",
                    Details = "",
                    ImgId = 100,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 7,
                    Name = " Vintage Compass",
                    Rating = 3,
                    Category = Category.Gadgets,
                    Color = "Gold",
                    Price = 320,
                    Size = Size.OneSize,
                    Description = "Go classy with this vintage compass, while getting to your destination fast and safely.",
                    Details = "",
                    ImgId = 101,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 8,
                    Name = "Uniform Belt",
                    Rating = 3,
                    Category = Category.Soldiers,
                    Color = "Blue",
                    Price = 35,
                    Size = Size.OneSize,
                    Description = "Don't settle for the rusty old belt you got.",
                    Details = "",
                    ImgId = 102,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 8,
                    Name = "Beret",
                    Rating = 2,
                    Category = Category.Soldiers,
                    Color = "Red",
                    Price = 15,
                    Size = Size.OneSize,
                    Description = "Lost yours at the bus? Ww got you.",
                    Details = "",
                    ImgId = 103,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 9,
                    Name = "G-Shock",
                    Rating = 5,
                    Category = Category.Soldiers,
                    Color = "Black",
                    Price = 360,
                    Size = Size.OneSize,
                    Description = "The great watch everyone's talking about. Get it at our shops with a discount!",
                    Details = "",
                    ImgId = 104,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 10,
                    Name = "Leatherman",
                    Rating = 4,
                    Category = Category.Soldiers,
                    Color = "Silver",
                    Price = 200,
                    Size = Size.OneSize,
                    Description = "Cook, fix and protect yourself. All with one device.",
                    Details = "",
                    ImgId = 105,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 11,
                    Name = "White Shirt",
                    Rating = 3,
                    Category = Category.Soldiers,
                    Color = "White",
                    Price = 30,
                    Size = Size.OneSize,
                    Description = "Basic T-Shirt to wear under uniform.",
                    Details = "",
                    ImgId = 106,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 12,
                    Name = "Backpack",
                    Rating = 3,
                    Category = Category.Bags,
                    Color = "Orange",
                    Price = 150,
                    Size = Size.OneSize,
                    Description = "The most comfortable backpack in vibrant colors.",
                    Details = "",
                    ImgId = 64,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 13,
                    Name = "Backpack",
                    Rating = 5,
                    Category = Category.Bags,
                    Color = "Blue",
                    Price = 230,
                    Size = Size.OneSize,
                    Description = "Support your back while exploring the world.",
                    Details = "",
                    ImgId = 65,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 14,
                    Name = "Backpack",
                    Rating = 3,
                    Category = Category.Bags,
                    Color = "Gray",
                    Price = 150,
                    Size = Size.OneSize,
                    Description = "The most comfortable backpack in vibrant colors.",
                    Details = "",
                    ImgId = 66,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 15,
                    Name = "Hiking Bag",
                    Rating = 5,
                    Category = Category.Bags,
                    Color = "Gray",
                    Price = 860,
                    Size = Size.OneSize,
                    Description = "Comes with a set of walking sticks and an amazing support for your back.",
                    Details = "",
                    ImgId = 72,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 16,
                    Name = "Backpack",
                    Rating = 4,
                    Category = Category.Bags,
                    Color = "Blue",
                    Price = 650,
                    Size = Size.OneSize,
                    Description = "You won't even feel that's it's there!",
                    Details = "",
                    ImgId = 74,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 17,
                    Name = "Camping chair",
                    Rating = 5,
                    Category = Category.Camping,
                    Color = "Black",
                    Price = 80,
                    Size = Size.OneSize,
                    Description = "Give your legs some rest while toasting some marshmellows.",
                    Details = "",
                    ImgId = 80,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 18,
                    Name = "Cooking set",
                    Rating = 3,
                    Category = Category.Camping,
                    Color = "Blue",
                    Price = 60,
                    Size = Size.OneSize,
                    Description = "Have a great time with your family, making memories with a dinner under the moonlight.",
                    Details = "",
                    ImgId = 84,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 19,
                    Name = "Light Coat",
                    Rating = 5,
                    Category = Category.Clothes,
                    Color = "Red",
                    Price = 320,
                    Size = Size.M,
                    Description = "Stay warm at your next hike, with this great coat.",
                    Details = "",
                    ImgId = 89,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 20,
                    Name = "Heavy Coat",
                    Rating = 5,
                    Category = Category.Clothes,
                    Color = "Brown",
                    Price = 240,
                    Size = Size.S,
                    Description = "Stay warm at your next hike, with this great coat.",
                    Details = "",
                    ImgId = 93,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 21,
                    Name = "Hiking pants",
                    Rating = 5,
                    Category = Category.Clothes,
                    Color = "Brown",
                    Price = 190,
                    Size = Size.S,
                    Description = "The most comforatble pants, with zippers to adjust length on a hot weather!",
                    Details = "",
                    ImgId = 94,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 22,
                    Name = "Sleeping Bag",
                    Rating = 2,
                    Category = Category.Camping,
                    Color = "Blue",
                    Price = 140,
                    Size = Size.OneSize,
                    Description = "Feel at home with our soft, warm collection of sleeping bags.",
                    Details = "",
                    ImgId = 86,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                },
                new Product
                {
                    Id = 23,
                    Name = "Sleeping Bag",
                    Rating = 5,
                    Category = Category.Camping,
                    Color = "Blue",
                    Price = 250,
                    Size = Size.OneSize,
                    Description = "Our best sleeping bag ever, now back in more colors!",
                    Details = "",
                    ImgId = 87,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                }, new Product
                {
                    Id = 23,
                    Name = "Sleeping Bag",
                    Rating = 4,
                    Category = Category.Camping,
                    Color = "Yellow",
                    Price = 140,
                    Size = Size.OneSize,
                    Description = "Sleep better than ever, anywhere, anytime.",
                    Details = "",
                    ImgId = 88,
                    Shops = new List<Shop>(),
                    Trips = new List<Trip>()
                }
        );

        }
    }
}




