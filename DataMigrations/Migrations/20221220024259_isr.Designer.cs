﻿// <auto-generated />
using System;
using DataMigrations.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataMigrations.Migrations
{
    [DbContext(typeof(ISRContext))]
    [Migration("20221220024259_isr")]
    partial class isr
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataMigrations.DataModels.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("ActualHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("CurrentQuotedHoursUsed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CurrentthroughProject")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("EstToComplHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ForecastQuotedHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("IsLock")
                        .HasColumnType("bit");

                    b.Property<string>("JobName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectManger")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("QuotedHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SDM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("TotalForeCastHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UUID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WFMLastUpdate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("DataMigrations.DataModels.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("ActualHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CurrentofQuotedHoursUsed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EstToComplHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("QuotedHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TaskName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalForecastHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UUID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("DataMigrations.DataModels.Tasks", b =>
                {
                    b.HasOne("DataMigrations.DataModels.Job", "job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("job");
                });
#pragma warning restore 612, 618
        }
    }
}
