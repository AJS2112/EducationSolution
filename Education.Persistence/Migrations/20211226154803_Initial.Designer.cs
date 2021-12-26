﻿// <auto-generated />
using System;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Education.Persistence.Migrations
{
    [DbContext(typeof(EducationDbContext))]
    [Migration("20211226154803_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Education.Domain.Curse", b =>
                {
                    b.Property<Guid>("CurseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.Property<DateTime?>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CurseId");

                    b.ToTable("Curses");

                    b.HasData(
                        new
                        {
                            CurseId = new Guid("58f5732e-c3f7-4a81-b856-dc6256164287"),
                            CreationDate = new DateTime(2021, 12, 26, 15, 48, 2, 577, DateTimeKind.Utc).AddTicks(4954),
                            Description = "C# basic curse",
                            Price = 60m,
                            PublishDate = new DateTime(2023, 12, 26, 15, 48, 2, 577, DateTimeKind.Utc).AddTicks(5275),
                            Title = "C# From Zero to Hero"
                        },
                        new
                        {
                            CurseId = new Guid("a0ab84df-9234-46fa-b73d-ea914c7157ec"),
                            CreationDate = new DateTime(2021, 12, 26, 15, 48, 2, 578, DateTimeKind.Utc).AddTicks(6233),
                            Description = "Java Curse",
                            Price = 40m,
                            PublishDate = new DateTime(2023, 12, 26, 15, 48, 2, 578, DateTimeKind.Utc).AddTicks(6234),
                            Title = "Mastery Java"
                        },
                        new
                        {
                            CurseId = new Guid("2ce1fd43-2fa5-48fd-9928-2b64a7438f37"),
                            CreationDate = new DateTime(2021, 12, 26, 15, 48, 2, 578, DateTimeKind.Utc).AddTicks(6324),
                            Description = "Unit Test For Net Core",
                            Price = 100m,
                            PublishDate = new DateTime(2023, 12, 26, 15, 48, 2, 578, DateTimeKind.Utc).AddTicks(6325),
                            Title = "NetCore Unit Testing"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}