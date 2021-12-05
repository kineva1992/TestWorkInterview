﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VswTask.Models;

#nullable disable

namespace VswTask.Migrations
{
    [DbContext(typeof(DbContextPipe))]
    [Migration("20211128161824_CreateBasicDateTimeModel")]
    partial class CreateBasicDateTimeModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VswTask.Models.BasicDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BasicDate");
                });

            modelBuilder.Entity("VswTask.Models.BasicModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BasicDateId")
                        .HasColumnType("int");

                    b.Property<double>("MaxDeviation")
                        .HasColumnType("float");

                    b.Property<double>("MeasuredDiameter1")
                        .HasColumnType("float");

                    b.Property<double>("MeasuredDiameter2")
                        .HasColumnType("float");

                    b.Property<double>("MeasuredDiameter3")
                        .HasColumnType("float");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberTube")
                        .HasColumnType("int");

                    b.Property<int>("TargetDiameterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BasicDateId");

                    b.HasIndex("TargetDiameterId");

                    b.ToTable("BasicModels");
                });

            modelBuilder.Entity("VswTask.Models.TargetOuterDiameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("TargetOuterDiameters")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("TargetOuterDiameters");
                });

            modelBuilder.Entity("VswTask.Models.BasicModel", b =>
                {
                    b.HasOne("VswTask.Models.BasicDate", "BasicDate")
                        .WithMany("BasicModels")
                        .HasForeignKey("BasicDateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VswTask.Models.TargetOuterDiameter", "TargetOuterDiameter")
                        .WithMany("BasicModels")
                        .HasForeignKey("TargetDiameterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BasicDate");

                    b.Navigation("TargetOuterDiameter");
                });

            modelBuilder.Entity("VswTask.Models.BasicDate", b =>
                {
                    b.Navigation("BasicModels");
                });

            modelBuilder.Entity("VswTask.Models.TargetOuterDiameter", b =>
                {
                    b.Navigation("BasicModels");
                });
#pragma warning restore 612, 618
        }
    }
}
