﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240208160536_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceCategoryId")
                        .HasColumnType("int");

                    b.HasKey("CompanyId");

                    b.HasIndex("PriceCategoryId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("WebApi.Models.PriceCategory", b =>
                {
                    b.Property<int>("PriceCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriceCategoryId"));

                    b.Property<string>("PriceCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PriceCategoryId");

                    b.ToTable("PriceCategories");
                });

            modelBuilder.Entity("WebApi.Models.ShipRate", b =>
                {
                    b.Property<int>("ShipRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipRateId"));

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<decimal>("PerCubicMeter")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PerKg")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PerKm")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ShipRateId");

                    b.HasIndex("CompanyId");

                    b.ToTable("ShipRates");
                });

            modelBuilder.Entity("WebApi.Models.Company", b =>
                {
                    b.HasOne("WebApi.Models.PriceCategory", "PriceCategory")
                        .WithMany("Companies")
                        .HasForeignKey("PriceCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PriceCategory");
                });

            modelBuilder.Entity("WebApi.Models.ShipRate", b =>
                {
                    b.HasOne("WebApi.Models.Company", null)
                        .WithMany("ShipRates")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("WebApi.Models.Company", b =>
                {
                    b.Navigation("ShipRates");
                });

            modelBuilder.Entity("WebApi.Models.PriceCategory", b =>
                {
                    b.Navigation("Companies");
                });
#pragma warning restore 612, 618
        }
    }
}
