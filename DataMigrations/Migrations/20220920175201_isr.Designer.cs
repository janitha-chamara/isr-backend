// <auto-generated />
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
    [Migration("20220920175201_isr")]
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
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("JobId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"), 1L, 1);

                    b.Property<int>("AccountManagerID")
                        .HasColumnType("int");

                    b.Property<decimal>("ActualHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BusinessUnitID")
                        .HasColumnType("int");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DifferencePercent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("EstToComplHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ForecastHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("JobCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ManageVisaISR")
                        .HasColumnType("bit");

                    b.Property<decimal>("PercentComplete")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PercentUsed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProjectMangerID")
                        .HasColumnType("int");

                    b.Property<decimal>("QuotedHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("VarianceHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VariancePercent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("WFMId")
                        .HasColumnType("int");

                    b.Property<string>("WFMLastUpdate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("ISRDataAccess.Models.BusinessUnit", b =>
                {
                    b.Property<int>("BusinessUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BusinessUnitId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusinessUnitId"), 1L, 1);

                    b.Property<string>("JobBusinessUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeadBusinessUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BusinessUnitId");

                    b.ToTable("BusinessUnits");
                });

            modelBuilder.Entity("ISRDataAccess.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ClientId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"), 1L, 1);

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsProspect")
                        .HasColumnType("bit");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ISRDataAccess.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmployeeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ISRDataAccess.Models.EmployeeRole", b =>
                {
                    b.Property<int>("EmpRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmpRoleId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpRoleId"), 1L, 1);

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("EmpRoleId");

                    b.ToTable("EmployeeRoles");
                });

            modelBuilder.Entity("ISRDataAccess.Models.LookUp", b =>
                {
                    b.Property<int>("LookupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LookupId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LookupId"), 1L, 1);

                    b.Property<string>("LookupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LookupValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LookupId");

                    b.ToTable("LookUps");
                });

            modelBuilder.Entity("ISRDataAccess.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ISRDataAccess.Models.Tasks", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TaskId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"), 1L, 1);

                    b.Property<decimal>("ActualHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DifferencePercent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EstToComplHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ForecastHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PercentComplete")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PercentUsed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("QuotedHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TaskName")
                        .HasColumnType("int");

                    b.Property<decimal>("VarianceHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VariancePercent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Weighting")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
