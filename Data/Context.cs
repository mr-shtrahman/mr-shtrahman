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

        }


        protected void addImg(ModelBuilder modelBuilder)
        {


            // TODO: Add to here for data seeding
            modelBuilder.Entity<Img>().HasOne(t => t.Trip).WithOne();

            modelBuilder.Entity<Img>().HasData(
                new Img
                {
                    Id = 1,
                    Src = "~Assets/categories/bags.jpg",
                    Description = "bags"
                },
                new Img
                {
                    Id = 2,
                    Src = "~Assets/categories/camping.jpg",
                    Description = "camping"
                },
                new Img
                {
                    Id = 3,
                    Src = "~Assets/categories/clothes.jpg",
                    Description = "clothes"
                },
                new Img
                {
                    Id = 4,
                    Src = "~Assets/categories/gadgets.jpg",
                    Description = "gadgets"
                },
                new Img
                {
                    Id = 5,
                    Src = "~Assets/categories/shoes.jpg",
                    Description = "shoes"
                },         
                new Img
                {
                    Id = 6,
                    Src = "~Assets/categories/soldiers.jpg",
                    Description = "clothes"
                },
                new Img
                {
                    Id = 7,
                    Src = "~Assets/trips/south/avdaat.jpg",
                    Description = "avdaat"
                }, 
                new Img
                {
                    Id = 8,
                    Src = "~Assets/trips/south/bashor.jpg",
                    Description = "bashor"
                }, 
                new Img
                {
                    Id = 9,
                    Src = "~Assets/trips/south/ein-gedi.jpg",
                    Description = "ein-gedi"
                },
                new Img
                {
                    Id = 10,
                    Src = "~Assets/trips/south/gov.jpg",
                    Description = "gov"
                }, 
                new Img
                {
                    Id = 11,
                    Src = "~Assets/trips/south/makhtesh-ramon.jpg",
                    Description = "makhtesh-ramon"
                }, 
                new Img
                {
                    Id = 12,
                    Src = "~Assets/trips/south/mesada.jpg",
                    Description = "mesada"
                },
                new Img
                {
                    Id = 13,
                    Src = "~Assets/trips/south/peres.jpg",
                    Description = "peres"
                },
                new Img
                {
                    Id = 14,
                    Src = "~Assets/trips/south/prat.jpg",
                    Description = "prat"
                }, 
                new Img
                {
                    Id = 15,
                    Src = "~Assets/trips/south/rahaf.jpg",
                    Description = "rahaf"
                },
                new Img
                {
                    Id = 16,
                    Src = "~Assets/trips/south/red-canyon.jpg",
                    Description = "red-canyon"
                },
                new Img
                {
                    Id = 17,
                    Src = "~Assets/trips/south/shivta.jpg",
                    Description = "shivta"
                },
                new Img
                {
                    Id = 18,
                    Src = "~Assets/trips/south/timna.jpg",
                    Description = "timna"
                }, 
                new Img
                {
                    Id = 19,
                    Src = "~Assets/trips/south/vardit-canyon.jpg",
                    Description = "vardit-canyon"
                }, 
                new Img
                {
                    Id = 20,
                    Src = "~Assets/trips/south/zeelim.jpg",
                    Description = "zeelim"
                },
                new Img
                {
                    Id = 21,
                    Src = "~Assets/trips/center/alexander.jpg",
                    Description = "gadgets"
                }, 
                new Img
                {
                    Id = 22,
                    Src = "~Assets/trips/center/britania.jpg",
                    Description = "britania"
                },
                new Img
                {
                    Id = 23,
                    Src = "~Assets/trips/center/caesarea.jpg",
                    Description = "caesarea"
                },
                new Img
                {
                    Id = 23,
                    Src = "~Assets/trips/center/carmila.jpg",
                    Description = "carmila"
                },
                new Img
                {
                    Id = 24,
                    Src = "~Assets/trips/center/david-garden.jpg",
                    Description = "david-garden"
                },
                new Img
                {
                    Id = 25,
                    Src = "~Assets/trips/center/florentin.jpg",
                    Description = "florentin"
                },
                new Img
                {
                    Id = 26,
                    Src = "~Assets/trips/center/gamzo.jpg",
                    Description = "gamzo"
                },
                new Img
                {
                    Id = 27,
                    Src = "~Assets/trips/center/jaffa.jpg",
                    Description = "jaffa"
                },
                new Img
                {
                    Id = 28,
                    Src = "~Assets/trips/center/jerusalem.jpg",
                    Description = "jerusalem"
                },
                new Img
                {
                    Id = 29,
                    Src = "~Assets/trips/center/king-george.jpg",
                    Description = "king-george"
                },
                new Img
                {
                    Id = 30,
                    Src = "~Assets/trips/center/mahne-yehuda.jpg",
                    Description = "mahne-yehuda"
                },
                new Img
                {
                    Id = 31,
                    Src = "~Assets/trips/center/alexander.jpg",
                    Description = "gadgets"
                },
                new Img
                {
                    Id = 32,
                    Src = "~Assets/trips/center/palmahim.jpg",
                    Description = "palmahim"
                },
                new Img
                {
                    Id = 33,
                    Src = "~Assets/trips/center/poleg.jpg",
                    Description = "poleg"
                },
                new Img
                {
                    Id = 34,
                    Src = "~Assets/trips/center/rishon-letzion.jpg",
                    Description = "rishon-letzion"
                },
                new Img
                {
                    Id = 35,
                    Src = "~Assets/trips/center/roses-garden.jpg",
                    Description = "roses-garden"
                },
                new Img
                {
                    Id = 36,
                    Src = "~Assets/trips/center/salit.jpg",
                    Description = "salit"
                },
                new Img
                {
                    Id = 36,
                    Src = "~Assets/trips/center/shaananim.jpg",
                    Description = "shaananim"
                },
                new Img
                {
                    Id = 37,
                    Src = "~Assets/trips/center/shfela.jpg",
                    Description = "shfela"
                },
                 new Img
                 {
                     Id =38 ,
                     Src = "~Assets/trips/north/acre.jpg",
                     Description = "acre"
                 },
                 new Img
                 {
                     Id =39 ,
                     Src = "~Assets/trips/north/afek.jpg",
                     Description = "afek"
                 },
                 new Img
                 {
                     Id = 40,
                     Src = "~Assets/trips/north/binyamina.jpg",
                     Description = "binyamina"
                 },
                 new Img
                 {
                     Id = 41,
                     Src = "~Assets/trips/north/bonim.jpg",
                     Description = "bonim"
                 },
                 new Img
                 {
                     Id = 42,
                     Src = "~Assets/trips/north/carmel-caves.jpg",
                     Description = "carmel-caves"
                 },
                 new Img
                 {
                     Id = 43,
                     Src = "~Assets/trips/north/dishon.jpg",
                     Description = "dishon"
                 },
                 new Img
                 {
                     Id = 44,
                     Src = "~Assets/trips/north/golan.jpg",
                     Description = "golan"
                 },
                 new Img
                 {
                     Id =45 ,
                     Src = "~Assets/trips/north/golan-amphitheater.jpg",
                     Description = "golan-amphitheater"
                 },
                 new Img
                 {
                     Id =46 ,
                     Src = "~Assets/trips/north/hula-valley.jpg",
                     Description = "hula-valley"
                 },
                 new Img
                 {
                     Id = 47,
                     Src = "~Assets/trips/north/kziv.jpg",
                     Description = "kziv"
                 },
                 new Img
                 {
                     Id = 48,
                     Src = "~Assets/trips/north/meitsar.jpg",
                     Description = "meitsar"
                 },
                 new Img
                 {
                     Id =49 ,
                     Src = "~Assets/trips/north/miron.jpg",
                     Description = "miron"
                 },
                 new Img
                 {
                     Id = 50,
                     Src = "~Assets/trips/north/orvim.jpg",
                     Description = "orvim"
                 },
                 new Img
                 {
                     Id = 51,
                     Src = "~Assets/trips/north/rosh-pina.jpg",
                     Description = "rosh-pina"
                 },
                 new Img
                 {
                     Id =52 ,
                     Src = "~Assets/trips/north/saar.jpg",
                     Description = "saar"
                 },
                 new Img
                 {
                     Id = 53,
                     Src = "~Assets/trips/north/shofet.jpg",
                     Description = "shofet"
                 },
                 new Img
                 {
                     Id = 54,
                     Src = "~Assets/trips/north/tanur.jpg",
                     Description = "tanur"
                 },
                 new Img
                 {
                     Id = 55,
                     Src = "~Assets/shops/shop1.jpg",
                     Description = "shop1"
                 },
                 new Img
                 {
                     Id = 56,
                     Src = "~Assets/shops/shop2.jpg",
                     Description = "shop2"
                 },
                 new Img
                 {
                     Id = 57,
                     Src = "~Assets/shops/shop3.jpg",
                     Description = "shop3"
                 },
                 new Img
                 {
                     Id = 58,
                     Src = "~Assets/shops/shop4.jpg",
                     Description = "shop4"
                 },
                 new Img
                 {
                     Id = 59,
                     Src = "~Assets/shops/shop5.jpg",
                     Description = "shop5"
                 },
                 new Img
                 {
                     Id = 60,
                     Src = "~Assets/shops/shop6.jpg",
                     Description = "shop6"
                 },
                 new Img
                 {
                     Id = 61,
                     Src = "~Assets/shops/shop7.jpg",
                     Description = "shop7"
                 },
                 new Img
                 {
                     Id = 62,
                     Src = "~Assets/shops/shop8.jpg",
                     Description = "shop8"
                 },
                 new Img
                 {
                     Id = 63,
                     Src = "~Assets/shops/shop9.jpg",
                     Description = "shop9"
                 },
                 new Img
                 {
                     Id =64 ,
                     Src = "~Assets/products/bags/backpack1.jpg",
                     Description = "backpack1"
                 },

                 new Img
                 {
                     Id =65 ,
                     Src = "~Assets/products/bags/backpack2.jpg",
                     Description = "backpack2"
                 },
                 new Img
                 {
                     Id =66 ,
                     Src = "~Assets/products/bags/backpack3.jpg",
                     Description = "backpack3"
                 },
                 new Img
                 {
                     Id = 67,
                     Src = "~Assets/products/bags/backpack4.jpg",
                     Description = "backpack4"
                 },
                 new Img
                 {
                     Id =68 ,
                     Src = "~Assets/products/bags/backpack5.jpg",
                     Description = "backpack5"
                 },
                 new Img
                 {
                     Id =69 ,
                     Src = "~Assets/products/bags/backpack5.jpg",
                     Description = "backpack5"
                 },
                 new Img
                 {
                     Id = 70,
                     Src = "~Assets/products/bags/bag1.jpg",
                     Description = "bag1"
                 },
                 new Img
                 {
                     Id = 71,
                     Src = "~Assets/products/bags/bag2.jpg",
                     Description = "bag2"
                 },
                 new Img
                 {
                     Id = 72,
                     Src = "~Assets/products/bags/bag3.jpg",
                     Description = "bag3"
                 },
                 new Img
                 {
                     Id = 73,
                     Src = "~Assets/products/bags/bag4.jpg",
                     Description = "bag4"
                 },
                 new Img
                 {
                     Id = 74,
                     Src = "~Assets/products/bags/bag5.jpg",
                     Description = "bag5"
                 },
                 new Img
                 {
                     Id = 75,
                     Src = "~Assets/products/bags/bag6.jpg",
                     Description = "bag6"
                 },
                 new Img
                 {
                     Id = 76,
                     Src = "~Assets/products/bags/bag7.jpg",
                     Description = "bag7"
                 },
                 new Img
                 {
                     Id = 77,
                     Src = "~Assets/products/bags/bag8.jpg",
                     Description = "bag8"
                 },
                 new Img
                 {
                     Id = 78,
                     Src = "~Assets/products/bags/bag9.jpg",
                     Description = "bag9"
                 },
                 new Img
                 {
                     Id = 79,
                     Src = "~Assets/products/bags/bag10.jpg",
                     Description = "bag"
                 },
                 new Img
                 {
                     Id = 80,
                     Src = "~Assets/products/camping/chair1.jpg",
                     Description = "chair1"
                 },
                 new Img
                 {
                     Id =81 ,
                     Src = "~Assets/products/camping/chair2.jpg",
                     Description = "chair2"
                 },
                 new Img
                 {
                     Id =82 ,
                     Src = "~Assets/products/camping/chair3.jpg",
                     Description = "chair3"
                 },
                 new Img
                 {
                     Id = 83,
                     Src = "~Assets/products/camping/cooking1.jpg",
                     Description = "cooking1"
                 },
                 new Img
                 {
                     Id =84 ,
                     Src = "~Assets/products/camping/cooking2.jpg",
                     Description = "cooking2"
                 },
                 new Img
                 {
                     Id = 85,
                     Src = "~Assets/products/camping/cooking3.jpg",
                     Description = "cooking3"
                 },

                 new Img
                 {
                     Id = 86,
                     Src = "~Assets/products/camping/sleepingbag1.jpg",
                     Description = "sleepingbag1"
                 },
                 new Img
                 {
                     Id = 87,
                     Src = "~Assets/products/camping/sleepingbag2.jpg",
                     Description = "sleepingbag2"
                 },
                 new Img
                 {
                     Id = 88,
                     Src = "~Assets/products/camping/sleepingbag3.jpg",
                     Description = "sleepingbag3"
                 },
                 new Img
                 {
                     Id = 89,
                     Src = "~Assets/products/clothing/coat1.jpg",
                     Description = "coat1"
                 },
                 new Img
                 {
                     Id = 90,
                     Src = "~Assets/products/clothing/coat2.jpg",
                     Description = "coat2"
                 },
                 new Img
                 {
                     Id = 91,
                     Src = "~Assets/products/clothing/coat3.jpg",
                     Description = "coat4"
                 },
                 new Img
                 {
                     Id = 92,
                     Src = "~Assets/products/clothing/coat4.jpg",
                     Description = "coat4"
                 },
                 new Img
                 {
                     Id = 93,
                     Src = "~Assets/products/clothing/coat5.jpg",
                     Description = "coat5"
                 },
                 new Img
                 {
                     Id = 94,
                     Src = "~Assets/products/clothing/pants1.jpg",
                     Description = "pants1"
                 },
                 new Img
                 {
                     Id = 95,
                     Src = "~Assets/products/shoes/blandston1.jpg",
                     Description = "blandston1"
                 },
                 new Img
                 {
                     Id =96 ,
                     Src = "~Assets/products/shoes/shoes1.jpg",
                     Description = "shoes1"
                 },
                 new Img
                 {
                     Id =97 ,
                     Src = "~Assets/products/shoes/shoresh1.jpg",
                     Description = "shoresh1"
                 },
                 new Img
                 {
                     Id = 98,
                     Src = "~Assets/products/shoes/shoresh2.jpg",
                     Description = "shoresh2"
                 },
                 new Img
                 {
                     Id = 99,
                     Src = "~Assets/products/gadgets/ac.jpg",
                     Description = "ac"
                 },
                 new Img
                 {
                     Id = 100,
                     Src = "~Assets/products/gadgets/camera-bag.jpg",
                     Description = "camera-bag"
                 },
                 new Img
                 {
                     Id = 101,
                     Src = "~Assets/products/gadgets/compass.jpg",
                     Description = "compass"
                 },
                 new Img
                 {
                     Id = 102,
                     Src = "~Assets/products/soldiers/belt.jpg",
                     Description = "belt"
                 },
                 new Img
                 {
                     Id = 103,
                     Src = "~Assets/products/soldiers/beret.jpg",
                     Description = "beret"
                 },
                 new Img
                 {
                     Id = 104,
                     Src = "~Assets/products/soldiers/gshock.jpg",
                     Description = "gshock"
                 },
                 new Img
                 {
                     Id = 105,
                     Src = "~Assets/products/soldiers/leatherman.jpg",
                     Description = "leatherman"
                 },
                 new Img
                 {
                     Id = 106,
                     Src = "~Assets/products/soldiers/white-shirt.jpg",
                     Description = "white-shirt"
                 }
                );
        }
    }
}




