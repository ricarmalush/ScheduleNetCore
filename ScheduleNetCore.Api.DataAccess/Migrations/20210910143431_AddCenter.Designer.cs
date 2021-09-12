﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScheduleNetCore.Api.DataAccess;

namespace ScheduleNetCore.Api.DataAccess.Migrations
{
    [DbContext(typeof(ScheduleNetCoreDBContext))]
    [Migration("20210910143431_AddCenter")]
    partial class AddCenter
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ScheduleNetCore.Api.DataAccess.Contracts.Entities.CauseEntity", b =>
                {
                    b.Property<int>("CauseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CauseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientScheduleId")
                        .HasColumnType("int");

                    b.Property<bool>("Low")
                        .HasColumnType("bit");

                    b.HasKey("CauseId");

                    b.ToTable("Cause");
                });

            modelBuilder.Entity("ScheduleNetCore.Api.DataAccess.Contracts.Entities.CenterEntity", b =>
                {
                    b.Property<int>("CenterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CenterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientScheduleId")
                        .HasColumnType("int");

                    b.Property<bool>("Low")
                        .HasColumnType("bit");

                    b.HasKey("CenterId");

                    b.ToTable("Center");
                });

            modelBuilder.Entity("ScheduleNetCore.Api.DataAccess.Contracts.Entities.ClientScheduleEntity", b =>
                {
                    b.Property<int>("ClientScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("HighDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Low")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Lowdate")
                        .HasColumnType("datetime2");

                    b.HasKey("ClientScheduleId");

                    b.ToTable("ClientSchedule");
                });

            modelBuilder.Entity("ScheduleNetCore.Api.DataAccess.Contracts.Entities.CompanyEntity", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientScheduleId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Low")
                        .HasColumnType("bit");

                    b.Property<int>("TownId")
                        .HasColumnType("int");

                    b.HasKey("CompanyId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("ScheduleNetCore.Api.DataAccess.Contracts.Entities.CountryEntity", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientScheduleId")
                        .HasColumnType("int");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Low")
                        .HasColumnType("bit");

                    b.HasKey("CountryId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("ScheduleNetCore.Api.DataAccess.Contracts.Entities.ProvinceEntity", b =>
                {
                    b.Property<int>("ProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<bool>("Low")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProvinceId");

                    b.ToTable("Province");
                });

            modelBuilder.Entity("ScheduleNetCore.Api.DataAccess.Contracts.Entities.TownEntity", b =>
                {
                    b.Property<int>("TownId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientScheduleId")
                        .HasColumnType("int");

                    b.Property<bool>("Low")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.HasKey("TownId");

                    b.ToTable("Town");
                });
#pragma warning restore 612, 618
        }
    }
}
