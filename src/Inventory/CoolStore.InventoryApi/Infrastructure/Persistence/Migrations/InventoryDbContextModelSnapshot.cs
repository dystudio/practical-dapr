﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoolStore.InventoryApi.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(InventoryDbContext))]
    partial class InventoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoolStore.InventoryApi.Domain.Inventory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Inventory","inv");

                    b.HasData(
                        new
                        {
                            Id = new Guid("90c9479e-a11c-4d6d-aaaa-0405b6c0efcd"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "This store sells electronic gadgets",
                            Location = "Vietnam",
                            Website = "https://coolstore-vn.com"
                        },
                        new
                        {
                            Id = new Guid("b8b62196-6369-409d-b709-11c112dd023f"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "This store sells food and beverage products",
                            Location = "Seattle",
                            Website = "https://coolstore-sea.com"
                        },
                        new
                        {
                            Id = new Guid("ec186ddf-f430-44ec-84e5-205c93d84f14"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "This store sells food and beverage products",
                            Location = "San Francisco",
                            Website = "https://coolstore-san.com"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
