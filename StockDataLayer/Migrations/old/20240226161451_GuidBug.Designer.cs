﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockDataLayer.Contexts;

#nullable disable

namespace StockDataLayer.Migrations
{
    [DbContext(typeof(MarketplaceStockContext))]
    [Migration("20240226161451_GuidBug")]
    partial class GuidBug
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StockDataLayer.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Status");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("StockDataLayer.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Image URL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00e7b90d-a8a4-4f08-8247-57a3ff89dc06"),
                            Image = "https://i.imgur.com/LvKZW4A.png",
                            Name = "Product 1",
                            Price = 100.0
                        },
                        new
                        {
                            Id = new Guid("577cfea5-c239-48c3-8267-7492d974f9cc"),
                            Image = "https://i.imgur.com/lHDLsU4.png",
                            Name = "Product 2",
                            Price = 200.0
                        },
                        new
                        {
                            Id = new Guid("e9196c30-6210-46c3-afa2-5699a11ba6de"),
                            Image = "https://i.imgur.com/174MybH.png",
                            Name = "Product 3",
                            Price = 300.0
                        },
                        new
                        {
                            Id = new Guid("9771b73d-3948-4aba-9cba-b2267eabad03"),
                            Image = "https://i.imgur.com/NXYAbHe.png",
                            Name = "Product 4",
                            Price = 400.0
                        });
                });

            modelBuilder.Entity("StockDataLayer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "stock_admin@gmail.com",
                            Password = "$2a$11$yN66.wDmc1JeUOYj8o2WhOei07lOqOz7.wai3KEOnLmk5gz.y9f92",
                            Role = 3,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("StockDataLayer.Models.Order", b =>
                {
                    b.HasOne("StockDataLayer.Models.User", "Owner")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("StockDataLayer.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}