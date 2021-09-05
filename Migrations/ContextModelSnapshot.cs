﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mr_shtrahman.Data;

namespace mr_shtrahman.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductShop", b =>
                {
                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("ShopsId")
                        .HasColumnType("int");

                    b.HasKey("ProductsId", "ShopsId");

                    b.HasIndex("ShopsId");

                    b.ToTable("ProductShop");
                });

            modelBuilder.Entity("ProductTrip", b =>
                {
                    b.Property<int>("RelevantProductsId")
                        .HasColumnType("int");

                    b.Property<int>("TripsId")
                        .HasColumnType("int");

                    b.HasKey("RelevantProductsId", "TripsId");

                    b.HasIndex("TripsId");

                    b.ToTable("ProductTrip");
                });

            modelBuilder.Entity("mr_shtrahman.Models.Img", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductId");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int")
                        .HasColumnName("ShopId");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TripId")
                        .HasColumnType("int")
                        .HasColumnName("TripId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShopId");

                    b.HasIndex("TripId")
                        .IsUnique()
                        .HasFilter("[TripId] IS NOT NULL");

                    b.ToTable("Img");
                });

            modelBuilder.Entity("mr_shtrahman.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImgId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<short>("Rating")
                        .HasColumnType("smallint");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("mr_shtrahman.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<string>("ClosingFriday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClosingSaturday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClosingSundayTilThursday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImgId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningFriday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningSaturday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningSundayTilThursday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Rating")
                        .HasColumnType("smallint");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Shop");
                });

            modelBuilder.Entity("mr_shtrahman.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Destination")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<int>("ImgId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<short>("Rating")
                        .HasColumnType("smallint");

                    b.Property<int>("TripType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Trip");
                });

            modelBuilder.Entity("mr_shtrahman.Models.VisitorsAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attendance")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("VisitorsAttendance");
                });

            modelBuilder.Entity("ProductShop", b =>
                {
                    b.HasOne("mr_shtrahman.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mr_shtrahman.Models.Shop", null)
                        .WithMany()
                        .HasForeignKey("ShopsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductTrip", b =>
                {
                    b.HasOne("mr_shtrahman.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("RelevantProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mr_shtrahman.Models.Trip", null)
                        .WithMany()
                        .HasForeignKey("TripsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("mr_shtrahman.Models.Img", b =>
                {
                    b.HasOne("mr_shtrahman.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("mr_shtrahman.Models.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId");

                    b.HasOne("mr_shtrahman.Models.Trip", "Trip")
                        .WithOne()
                        .HasForeignKey("mr_shtrahman.Models.Img", "TripId");

                    b.Navigation("Product");

                    b.Navigation("Shop");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("mr_shtrahman.Models.VisitorsAttendance", b =>
                {
                    b.HasOne("mr_shtrahman.Models.Trip", "Trip")
                        .WithMany("VisitorsAttendance")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("mr_shtrahman.Models.Trip", b =>
                {
                    b.Navigation("VisitorsAttendance");
                });
#pragma warning restore 612, 618
        }
    }
}
