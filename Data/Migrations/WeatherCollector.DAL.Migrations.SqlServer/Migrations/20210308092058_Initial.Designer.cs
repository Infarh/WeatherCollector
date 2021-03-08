﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherCollector.DAL.Context;

namespace WeatherCollector.DAL.Migrations.SqlServer.Migrations
{
    [DbContext(typeof(WeatherDB))]
    [Migration("20210308092058_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherCollector.DAL.Entities.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("WeatherCollector.DAL.Entities.Pressure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Pressure");
                });

            modelBuilder.Entity("WeatherCollector.DAL.Entities.Temperature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Temperature");
                });

            modelBuilder.Entity("WeatherCollector.DAL.Entities.Pressure", b =>
                {
                    b.HasOne("WeatherCollector.DAL.Entities.Place", "Place")
                        .WithMany("Pressures")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("WeatherCollector.DAL.Entities.Temperature", b =>
                {
                    b.HasOne("WeatherCollector.DAL.Entities.Place", "Place")
                        .WithMany("Temperatures")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("WeatherCollector.DAL.Entities.Place", b =>
                {
                    b.Navigation("Pressures");

                    b.Navigation("Temperatures");
                });
#pragma warning restore 612, 618
        }
    }
}