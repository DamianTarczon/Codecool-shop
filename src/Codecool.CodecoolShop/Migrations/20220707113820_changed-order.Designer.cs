﻿// <auto-generated />
using System;
using Codecool.CodecoolShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Codecool.CodecoolShop.Migrations
{
    [DbContext(typeof(CodecoolShopContext))]
    [Migration("20220707113820_changed-order")]
    partial class changedorder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Codecool.CodecoolShop.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.CartDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<int?>("UserDataId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserDataId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("NumberOfProduct")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("DefaultPrice")
                        .HasColumnType("decimal(20,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Currency = "USD",
                            DefaultPrice = 49.9m,
                            Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.",
                            Name = "Amazon Fire",
                            ProductCategoryId = 1,
                            SupplierId = 1
                        },
                        new
                        {
                            Id = 2,
                            Currency = "USD",
                            DefaultPrice = 479.0m,
                            Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.",
                            Name = "Lenovo IdeaPad Miix 700",
                            ProductCategoryId = 1,
                            SupplierId = 5
                        },
                        new
                        {
                            Id = 3,
                            Currency = "USD",
                            DefaultPrice = 89.0m,
                            Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.",
                            Name = "Amazon Fire HD 8",
                            ProductCategoryId = 1,
                            SupplierId = 1
                        },
                        new
                        {
                            Id = 4,
                            Currency = "USD",
                            DefaultPrice = 500.9m,
                            Description = "Fantasic mobile phone",
                            Name = "iPhone 10",
                            ProductCategoryId = 2,
                            SupplierId = 2
                        },
                        new
                        {
                            Id = 5,
                            Currency = "USD",
                            DefaultPrice = 500.9m,
                            Description = "Good enough",
                            Name = "iPhone 8",
                            ProductCategoryId = 2,
                            SupplierId = 2
                        },
                        new
                        {
                            Id = 6,
                            Currency = "USD",
                            DefaultPrice = 50.9m,
                            Description = "Fantasic smartwatch with good price",
                            Name = "Xiaomi Redmi 2",
                            ProductCategoryId = 2,
                            SupplierId = 3
                        },
                        new
                        {
                            Id = 7,
                            Currency = "USD",
                            DefaultPrice = 60.9m,
                            Description = "Smartwatch with a lot of functions",
                            Name = "Garmin Fenix 5",
                            ProductCategoryId = 3,
                            SupplierId = 4
                        },
                        new
                        {
                            Id = 8,
                            Currency = "USD",
                            DefaultPrice = 70.9m,
                            Description = "The best smartwatch",
                            Name = "Xiaomi Mi Band 6",
                            ProductCategoryId = 3,
                            SupplierId = 3
                        });
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = "Hardware",
                            Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display.",
                            Name = "Tablet"
                        },
                        new
                        {
                            Id = 2,
                            Department = "Hardware",
                            Description = "A mobile phone that is smart",
                            Name = "Smartphone"
                        },
                        new
                        {
                            Id = 3,
                            Department = "Luxury goods",
                            Description = "A watch with smart functions",
                            Name = "Smartwatch"
                        });
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Digital content and services",
                            Name = "Amazon"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Digital content",
                            Name = "Apple"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Digital content",
                            Name = "Xiaomi"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Electronics watches",
                            Name = "Garmin"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Computers",
                            Name = "Lenovo"
                        });
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.UserData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.ToTable("UserData");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.CartDetail", b =>
                {
                    b.HasOne("Codecool.CodecoolShop.Models.Cart", "Cart")
                        .WithMany("CartDetails")
                        .HasForeignKey("CartId");

                    b.HasOne("Codecool.CodecoolShop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.Order", b =>
                {
                    b.HasOne("Codecool.CodecoolShop.Models.UserData", "UserData")
                        .WithMany()
                        .HasForeignKey("UserDataId");

                    b.Navigation("UserData");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.OrderDetails", b =>
                {
                    b.HasOne("Codecool.CodecoolShop.Models.Order", null)
                        .WithMany("ProductsDetails")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.Product", b =>
                {
                    b.HasOne("Codecool.CodecoolShop.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Codecool.CodecoolShop.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.Cart", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.Order", b =>
                {
                    b.Navigation("ProductsDetails");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}