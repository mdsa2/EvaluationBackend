﻿// <auto-generated />
using System;
using EvaluationBackend.DATA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EvaluationBackend.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240720152801_mohammedsdaa")]
    partial class mohammedsdaa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EvaluationBackend.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("UserImage")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.Citizen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("Phonenumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("citizens");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.Fine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("AppUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("DesNumber")
                        .HasColumnType("integer");

                    b.Property<int?>("FineTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("GovId")
                        .HasColumnType("integer");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<int?>("Number")
                        .HasColumnType("integer");

                    b.Property<int?>("PlaceFineId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<int?>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("VechileId")
                        .HasColumnType("integer");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("FineTypeId");

                    b.HasIndex("GovId");

                    b.HasIndex("PlaceFineId");

                    b.HasIndex("VehicleId");

                    b.ToTable("fines");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.FineTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("fineTypes");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.Gov", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("govs");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Subject")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.PlaceFine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("placeFines");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.RolePermission", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("PermissionId")
                        .HasColumnType("integer");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.TypeOfVehicles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TypeOfVehicles");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.Vehical", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CitizenId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("NumberOfVechile")
                        .HasColumnType("integer");

                    b.Property<int>("TypeOfVechileId")
                        .HasColumnType("integer");

                    b.Property<int>("VehicleCityId")
                        .HasColumnType("integer");

                    b.Property<string>("carPartNumber")
                        .HasColumnType("text");

                    b.Property<string>("character")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CitizenId");

                    b.HasIndex("TypeOfVechileId");

                    b.HasIndex("VehicleCityId");

                    b.ToTable("Vehical");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.VehiclesGovernarete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("VehicleGovernarte")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("VehicleCities");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.AppUser", b =>
                {
                    b.HasOne("EvaluationBackend.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.Fine", b =>
                {
                    b.HasOne("EvaluationBackend.Entities.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.HasOne("EvaluationBackend.Entities.FineTypes", "FineType")
                        .WithMany()
                        .HasForeignKey("FineTypeId");

                    b.HasOne("EvaluationBackend.Entities.Gov", "Gov")
                        .WithMany()
                        .HasForeignKey("GovId");

                    b.HasOne("EvaluationBackend.Entities.PlaceFine", "placeFine")
                        .WithMany()
                        .HasForeignKey("PlaceFineId");

                    b.HasOne("EvaluationBackend.Entities.Vehical", "Vehicle")
                        .WithMany("Fines")
                        .HasForeignKey("VehicleId");

                    b.Navigation("AppUser");

                    b.Navigation("FineType");

                    b.Navigation("Gov");

                    b.Navigation("Vehicle");

                    b.Navigation("placeFine");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.RolePermission", b =>
                {
                    b.HasOne("EvaluationBackend.Entities.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EvaluationBackend.Entities.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.Vehical", b =>
                {
                    b.HasOne("EvaluationBackend.Entities.Citizen", "Citizen")
                        .WithMany("Vehicles")
                        .HasForeignKey("CitizenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EvaluationBackend.Entities.TypeOfVehicles", "typeOfVechile")
                        .WithMany()
                        .HasForeignKey("TypeOfVechileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EvaluationBackend.Entities.VehiclesGovernarete", "VehicleCity")
                        .WithMany()
                        .HasForeignKey("VehicleCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Citizen");

                    b.Navigation("VehicleCity");

                    b.Navigation("typeOfVechile");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.Citizen", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.Role", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("EvaluationBackend.Entities.Vehical", b =>
                {
                    b.Navigation("Fines");
                });
#pragma warning restore 612, 618
        }
    }
}
