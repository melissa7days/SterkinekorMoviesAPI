﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SterkinekorMoviesAPI.Models;

namespace SterkinekorMoviesAPI.Migrations
{
    [DbContext(typeof(SterkinekorContext))]
    [Migration("20200710030246_Migration3")]
    partial class Migration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SterkinekorMoviesAPI.Models.Cart", b =>
                {
                    b.Property<int>("cartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("finalTotal")
                        .HasColumnType("float");

                    b.HasKey("cartId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("SterkinekorMoviesAPI.Models.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cartId")
                        .HasColumnType("int");

                    b.Property<double>("itemCost")
                        .HasColumnType("float");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("totalCost")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("cartId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("SterkinekorMoviesAPI.Models.OrderDetails", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cartId")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("paymentId")
                        .HasColumnType("int");

                    b.HasKey("orderId");

                    b.HasIndex("cartId");

                    b.HasIndex("id");

                    b.HasIndex("paymentId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("SterkinekorMoviesAPI.Models.OrderViewModel", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cartId")
                        .HasColumnType("int");

                    b.Property<double>("finalTotal")
                        .HasColumnType("float");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<double>("itemCost")
                        .HasColumnType("float");

                    b.Property<int>("paymentId")
                        .HasColumnType("int");

                    b.Property<string>("paymentMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("totalCost")
                        .HasColumnType("float");

                    b.HasKey("orderId");

                    b.ToTable("OrderViewModels");
                });

            modelBuilder.Entity("SterkinekorMoviesAPI.Models.Payment", b =>
                {
                    b.Property<int>("paymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cartId")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("paymentMessage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("paymentId");

                    b.HasIndex("cartId");

                    b.HasIndex("id");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("SterkinekorMoviesAPI.Models.PaymentViewModel", b =>
                {
                    b.Property<int>("paymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cartId")
                        .HasColumnType("int");

                    b.Property<double>("finalTotal")
                        .HasColumnType("float");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<double>("itemCost")
                        .HasColumnType("float");

                    b.Property<string>("paymentMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("totalCost")
                        .HasColumnType("float");

                    b.HasKey("paymentId");

                    b.ToTable("PaymentViewModels");
                });

            modelBuilder.Entity("SterkinekorMoviesAPI.Models.Item", b =>
                {
                    b.HasOne("SterkinekorMoviesAPI.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("cartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SterkinekorMoviesAPI.Models.OrderDetails", b =>
                {
                    b.HasOne("SterkinekorMoviesAPI.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("cartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SterkinekorMoviesAPI.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SterkinekorMoviesAPI.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("paymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SterkinekorMoviesAPI.Models.Payment", b =>
                {
                    b.HasOne("SterkinekorMoviesAPI.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("cartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SterkinekorMoviesAPI.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
