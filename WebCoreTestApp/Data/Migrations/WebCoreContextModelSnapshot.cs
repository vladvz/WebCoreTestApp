﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebCoreTestApp.Data.Entities;

namespace WebCoreTestApp.Migrations
{
    [DbContext(typeof(WebCoreContext))]
    partial class WebCoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebCoreTestApp.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("OrderNumber");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebCoreTestApp.Data.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderId");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("WebCoreTestApp.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtDating");

                    b.Property<string>("ArtDescription");

                    b.Property<string>("ArtId");

                    b.Property<string>("Artist");

                    b.Property<DateTime>("ArtistBirthDate");

                    b.Property<DateTime>("ArtistDeathDate");

                    b.Property<string>("ArtistNationality");

                    b.Property<string>("Category");

                    b.Property<decimal>("Price");

                    b.Property<string>("Size");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebCoreTestApp.Data.Entities.OrderItem", b =>
                {
                    b.HasOne("WebCoreTestApp.Data.Entities.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("WebCoreTestApp.Data.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
