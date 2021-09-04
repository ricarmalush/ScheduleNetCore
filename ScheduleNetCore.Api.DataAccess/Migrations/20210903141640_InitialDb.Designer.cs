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
    [Migration("20210903141640_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
#pragma warning restore 612, 618
        }
    }
}