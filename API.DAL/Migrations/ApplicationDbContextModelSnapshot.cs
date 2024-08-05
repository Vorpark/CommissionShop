﻿// <auto-generated />
using System;
using API.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Domain.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Android"
                        });
                });

            modelBuilder.Entity("API.Domain.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("API.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TranslitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "",
                            Name = "",
                            TranslitName = ""
                        });
                });

            modelBuilder.Entity("API.Domain.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Набережные Челны"
                        });
                });

            modelBuilder.Entity("API.Domain.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("API.Domain.Models.OrderDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("API.Domain.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountPercent")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("HasDiscount")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CityId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fa3aab0b-e28c-4226-a440-d7f4691df48f"),
                            BrandId = 1,
                            CategoryId = 1,
                            CityId = 1,
                            CreatedDate = new DateTime(2024, 8, 5, 13, 15, 0, 569, DateTimeKind.Utc).AddTicks(99),
                            Description = "WTF",
                            DiscountPercent = 0,
                            DiscountPrice = 0m,
                            HasDiscount = false,
                            ImageUrl = "",
                            IsSold = false,
                            Name = "123",
                            Price = 12455.01m,
                            SubCategoryId = 1,
                            UpdatedDate = new DateTime(2024, 8, 5, 13, 15, 0, 569, DateTimeKind.Utc).AddTicks(101)
                        });
                });

            modelBuilder.Entity("API.Domain.Models.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TranslitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            ImageUrl = "",
                            Name = "",
                            TranslitName = ""
                        });
                });

            modelBuilder.Entity("API.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PhoneNumber")
                        .HasColumnType("decimal(11,0)");

                    b.HasKey("Id");

                    b.HasIndex("CartId")
                        .IsUnique();

                    b.HasIndex("CityId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CartProduct", b =>
                {
                    b.Property<Guid>("CartsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CartsId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CartProduct");
                });

            modelBuilder.Entity("API.Domain.Models.OrderDetails", b =>
                {
                    b.HasOne("API.Domain.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Domain.Models.Product", "Product")
                        .WithOne("OrderDetails")
                        .HasForeignKey("API.Domain.Models.OrderDetails", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("API.Domain.Models.Product", b =>
                {
                    b.HasOne("API.Domain.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Domain.Models.City", "City")
                        .WithMany("Products")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Domain.Models.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("City");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("API.Domain.Models.SubCategory", b =>
                {
                    b.HasOne("API.Domain.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("API.Domain.Models.User", b =>
                {
                    b.HasOne("API.Domain.Models.Cart", "Cart")
                        .WithOne("User")
                        .HasForeignKey("API.Domain.Models.User", "CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Domain.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("City");
                });

            modelBuilder.Entity("CartProduct", b =>
                {
                    b.HasOne("API.Domain.Models.Cart", null)
                        .WithMany()
                        .HasForeignKey("CartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Domain.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Domain.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("API.Domain.Models.Cart", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Domain.Models.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("API.Domain.Models.City", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("API.Domain.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("API.Domain.Models.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("API.Domain.Models.SubCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
