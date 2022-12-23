﻿// <auto-generated />
using System;
using MartBerries_Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MartBerriesServer.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ServerContext))]
    [Migration("20221112195930_InitialMigrate")]
    partial class InitialMigrate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MartBerries_Server.Core.Entities.MoneyTransfer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransferDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MoneyTransfers");
                });

            modelBuilder.Entity("MartBerries_Server.Core.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<decimal>("RequestedMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("SubmittedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SubmittedMoney")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MartBerries_Server.Core.Entities.OrderedProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderedProducts");
                });

            modelBuilder.Entity("MartBerries_Server.Core.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MartBerries_Server.Core.Entities.ProductTransfer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TransferDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransferType")
                        .HasColumnType("int");

                    b.Property<int>("TransferTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductTransfers");
                });

            modelBuilder.Entity("MartBerries_Server.Core.Entities.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("MartBerries_Server.Core.Entities.SupplierProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("SupplierProducts");
                });

            modelBuilder.Entity("MartBerries_Server.Core.Entities.OrderedProduct", b =>
                {
                    b.HasOne("MartBerries_Server.Core.Entities.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MartBerries_Server.Core.Entities.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MartBerries_Server.Core.Entities.Product", b =>
                {
                    b.HasOne("MartBerries_Server.Core.Entities.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("MartBerries_Server.Core.Entities.ProductTransfer", b =>
                {
                    b.HasOne("MartBerries_Server.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MartBerries_Server.Core.Entities.SupplierProduct", b =>
                {
                    b.HasOne("MartBerries_Server.Core.Entities.Product", "Product")
                        .WithMany("Suppliers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MartBerries_Server.Core.Entities.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("MartBerries_Server.Core.Entities.Order", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MartBerries_Server.Core.Entities.Product", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("MartBerries_Server.Core.Entities.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
