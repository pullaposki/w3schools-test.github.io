﻿// <auto-generated />
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
    [Migration("20240213124146_AddEmployee")]
    partial class AddEmployee
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

            modelBuilder.Entity("WebApi.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");
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

                    b.Property<int>("ShipRatesId")
                        .HasColumnType("int");

                    b.HasKey("PriceCategoryId");

                    b.HasIndex("ShipRatesId");

                    b.ToTable("PriceCategories");
                });

            modelBuilder.Entity("WebApi.Models.ShipRates", b =>
                {
                    b.Property<int>("ShipRatesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipRatesId"));

                    b.Property<decimal>("PerCubicMeter")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PerKg")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PerKm")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ShipRatesId");

                    b.ToTable("ShipRates");
                });

            modelBuilder.Entity("WebApi.Models.Company", b =>
                {
                    b.HasOne("WebApi.Models.PriceCategory", "PriceCategory")
                        .WithMany()
                        .HasForeignKey("PriceCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PriceCategory");
                });

            modelBuilder.Entity("WebApi.Models.Employee", b =>
                {
                    b.HasOne("WebApi.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("WebApi.Models.PriceCategory", b =>
                {
                    b.HasOne("WebApi.Models.ShipRates", "ShipRates")
                        .WithMany()
                        .HasForeignKey("ShipRatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShipRates");
                });

            modelBuilder.Entity("WebApi.Models.Company", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
