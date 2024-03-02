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
    [Migration("20240302124213_OrderProduct")]
    partial class OrderProduct
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

            modelBuilder.Entity("StockDataLayer.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
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
                            Id = new Guid("0a2fb9bf-c182-46d2-8070-193f294e2828"),
                            Image = "https://i.imgur.com/LvKZW4A.png",
                            Name = "Product 1",
                            Price = 100.0
                        },
                        new
                        {
                            Id = new Guid("09cb716d-e7d4-4d3d-af61-f2659924cd51"),
                            Image = "https://i.imgur.com/lHDLsU4.png",
                            Name = "Product 2",
                            Price = 200.0
                        },
                        new
                        {
                            Id = new Guid("a902b534-3dea-41e6-b877-eea658d35d07"),
                            Image = "https://i.imgur.com/174MybH.png",
                            Name = "Product 3",
                            Price = 300.0
                        },
                        new
                        {
                            Id = new Guid("0ff0ca74-84fc-415c-a0f0-35ab91fe3481"),
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

                    b.Property<string>("Token")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("")
                        .HasColumnName("Token");

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
                            Password = "$2a$11$wYG56M84beizRMaW4OnEnO1gMAYeN7cF8yFQdKYK9UWrDmkKUOl1G",
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

            modelBuilder.Entity("StockDataLayer.Models.OrderProduct", b =>
                {
                    b.HasOne("StockDataLayer.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockDataLayer.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("StockDataLayer.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("StockDataLayer.Models.Product", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("StockDataLayer.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
