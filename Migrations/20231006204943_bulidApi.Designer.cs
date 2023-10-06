﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cookie_stand_api.Data;

#nullable disable

namespace cookie_stand_api.Migrations
{
    [DbContext(typeof(CookieDbContext))]
    [Migration("20231006204943_bulidApi")]
    partial class bulidApi
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("cookie_stand_api.Model.CookieStand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AverageCookiesPerSale")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaximumCustomersPerHour")
                        .HasColumnType("int");

                    b.Property<int>("MinimumCustomersPerHour")
                        .HasColumnType("int");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CookieStand");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AverageCookiesPerSale = 2.5,
                            Description = "",
                            Location = "Barcelona",
                            MaximumCustomersPerHour = 7,
                            MinimumCustomersPerHour = 3,
                            Owner = ""
                        },
                        new
                        {
                            Id = 2,
                            AverageCookiesPerSale = 3.0,
                            Description = "",
                            Location = "maxico",
                            MaximumCustomersPerHour = 8,
                            MinimumCustomersPerHour = 2,
                            Owner = ""
                        },
                        new
                        {
                            Id = 3,
                            AverageCookiesPerSale = 3.5,
                            Description = "",
                            Location = "Chickgio",
                            MaximumCustomersPerHour = 7,
                            MinimumCustomersPerHour = 3,
                            Owner = ""
                        });
                });

            modelBuilder.Entity("cookie_stand_api.Model.HourlySales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CookieStandId")
                        .HasColumnType("int");

                    b.Property<int>("SalesAmount")
                        .HasColumnType("int");

                    b.Property<int>("hour")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CookieStandId");

                    b.ToTable("HourlySales");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CookieStandId = 1,
                            SalesAmount = 17,
                            hour = 5
                        },
                        new
                        {
                            Id = 2,
                            CookieStandId = 2,
                            SalesAmount = 7,
                            hour = 4
                        },
                        new
                        {
                            Id = 3,
                            CookieStandId = 3,
                            SalesAmount = 6,
                            hour = 1
                        });
                });

            modelBuilder.Entity("cookie_stand_api.Model.HourlySales", b =>
                {
                    b.HasOne("cookie_stand_api.Model.CookieStand", "CookieStand")
                        .WithMany("HourlySales")
                        .HasForeignKey("CookieStandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CookieStand");
                });

            modelBuilder.Entity("cookie_stand_api.Model.CookieStand", b =>
                {
                    b.Navigation("HourlySales");
                });
#pragma warning restore 612, 618
        }
    }
}
