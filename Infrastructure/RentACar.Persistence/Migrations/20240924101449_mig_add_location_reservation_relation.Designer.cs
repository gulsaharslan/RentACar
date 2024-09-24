﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentACar.Persistence.Context;

#nullable disable

namespace RentACar.Persistence.Migrations
{
    [DbContext(typeof(CarBookContext))]
    [Migration("20240924101449_mig_add_location_reservation_relation")]
    partial class mig_add_location_reservation_relation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RentACar.Domain.Entities.About", b =>
                {
                    b.Property<int>("AboutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AboutID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AboutID");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Banner", b =>
                {
                    b.Property<int>("BannerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BannerID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BannerID");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Blog", b =>
                {
                    b.Property<int>("BlogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogID"));

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BlogID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Car", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarID"));

                    b.Property<string>("BigImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrandID")
                        .HasColumnType("int");

                    b.Property<string>("CoverImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fuel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Km")
                        .HasColumnType("int");

                    b.Property<byte>("Luggage")
                        .HasColumnType("tinyint");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Seat")
                        .HasColumnType("tinyint");

                    b.Property<string>("Transmission")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarID");

                    b.HasIndex("BrandID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.CarDescription", b =>
                {
                    b.Property<int>("CarDescriptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarDescriptionID"));

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarDescriptionID");

                    b.HasIndex("CarID");

                    b.ToTable("CarDescriptions");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.CarFeature", b =>
                {
                    b.Property<int>("CarFeatureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarFeatureID"));

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<int>("FeatureID")
                        .HasColumnType("int");

                    b.HasKey("CarFeatureID");

                    b.HasIndex("CarID");

                    b.HasIndex("FeatureID");

                    b.ToTable("CarFeatures");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.CarPricing", b =>
                {
                    b.Property<int>("CarPricingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarPricingID"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<int>("PricingID")
                        .HasColumnType("int");

                    b.HasKey("CarPricingID");

                    b.HasIndex("CarID");

                    b.HasIndex("PricingID");

                    b.ToTable("CarPricings");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentID"));

                    b.Property<int>("BlogID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentID");

                    b.HasIndex("BlogID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("CustomerMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Feature", b =>
                {
                    b.Property<int>("FeatureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeatureID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeatureID");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.FooterAddress", b =>
                {
                    b.Property<int>("FooterAddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FooterAddressID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FooterAddressID");

                    b.ToTable("FooterAddresses");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Pricing", b =>
                {
                    b.Property<int>("PricingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PricingID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PricingID");

                    b.ToTable("Pricings");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.RentACar", b =>
                {
                    b.Property<int>("RentACarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentACarId"));

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.HasKey("RentACarId");

                    b.HasIndex("CarID");

                    b.HasIndex("LocationID");

                    b.ToTable("RentACars");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.RentACarProcess", b =>
                {
                    b.Property<int>("RentACarProcessID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentACarProcessID"));

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DropOffDate")
                        .HasColumnType("Date");

                    b.Property<string>("DropOffDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DropOffLocation")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("DropOffTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("PickUpDate")
                        .HasColumnType("Date");

                    b.Property<string>("PickUpDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PickUpLocation")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("PickUpTime")
                        .HasColumnType("time");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("RentACarProcessID");

                    b.HasIndex("CarID");

                    b.HasIndex("CustomerID");

                    b.ToTable("RentACarProcess");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DriverLicenseYear")
                        .HasColumnType("int");

                    b.Property<int?>("DropOffLocationID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PickUpLocationID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReservationID");

                    b.HasIndex("CarID");

                    b.HasIndex("DropOffLocationID");

                    b.HasIndex("PickUpLocationID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.SocialMedia", b =>
                {
                    b.Property<int>("SocialMediaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SocialMediaID"));

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SocialMediaID");

                    b.ToTable("SocialMedias");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.TagCloud", b =>
                {
                    b.Property<int>("TagCloudID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagCloudID"));

                    b.Property<int>("BlogID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagCloudID");

                    b.HasIndex("BlogID");

                    b.ToTable("TagClouds");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Testimonial", b =>
                {
                    b.Property<int>("TestimonialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestimonialID"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestimonialID");

                    b.ToTable("Testimonials");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Blog", b =>
                {
                    b.HasOne("RentACar.Domain.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentACar.Domain.Entities.Category", "Category")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Car", b =>
                {
                    b.HasOne("RentACar.Domain.Entities.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.CarDescription", b =>
                {
                    b.HasOne("RentACar.Domain.Entities.Car", "Car")
                        .WithMany("CarDescriptions")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.CarFeature", b =>
                {
                    b.HasOne("RentACar.Domain.Entities.Car", "Car")
                        .WithMany("CarFeatures")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentACar.Domain.Entities.Feature", "Feature")
                        .WithMany("CarFeatures")
                        .HasForeignKey("FeatureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.CarPricing", b =>
                {
                    b.HasOne("RentACar.Domain.Entities.Car", "Car")
                        .WithMany("CarPricings")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentACar.Domain.Entities.Pricing", "Pricing")
                        .WithMany("CarPricings")
                        .HasForeignKey("PricingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Pricing");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Comment", b =>
                {
                    b.HasOne("RentACar.Domain.Entities.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.RentACar", b =>
                {
                    b.HasOne("RentACar.Domain.Entities.Car", "Car")
                        .WithMany("RentACars")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentACar.Domain.Entities.Location", "Location")
                        .WithMany("RentACars")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.RentACarProcess", b =>
                {
                    b.HasOne("RentACar.Domain.Entities.Car", "Car")
                        .WithMany("RentACarProcesses")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentACar.Domain.Entities.Customer", "Customer")
                        .WithMany("RentACarProcesses")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("RentACar.Domain.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentACar.Domain.Entities.Location", "DropOffLocation")
                        .WithMany("DropOffReservation")
                        .HasForeignKey("DropOffLocationID");

                    b.HasOne("RentACar.Domain.Entities.Location", "PickUpLocation")
                        .WithMany("PickUpReservation")
                        .HasForeignKey("PickUpLocationID");

                    b.Navigation("Car");

                    b.Navigation("DropOffLocation");

                    b.Navigation("PickUpLocation");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.TagCloud", b =>
                {
                    b.HasOne("RentACar.Domain.Entities.Blog", "Blog")
                        .WithMany("TagClouds")
                        .HasForeignKey("BlogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Blog", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("TagClouds");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Brand", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Car", b =>
                {
                    b.Navigation("CarDescriptions");

                    b.Navigation("CarFeatures");

                    b.Navigation("CarPricings");

                    b.Navigation("RentACarProcesses");

                    b.Navigation("RentACars");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Category", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Customer", b =>
                {
                    b.Navigation("RentACarProcesses");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Feature", b =>
                {
                    b.Navigation("CarFeatures");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Location", b =>
                {
                    b.Navigation("DropOffReservation");

                    b.Navigation("PickUpReservation");

                    b.Navigation("RentACars");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Pricing", b =>
                {
                    b.Navigation("CarPricings");
                });
#pragma warning restore 612, 618
        }
    }
}
