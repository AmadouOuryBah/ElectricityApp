﻿// <auto-generated />
using System;
using Electricity.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Electricity.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230606172055_NewMigration")]
    partial class NewMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Electricity.DataAccess.Entities.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("BuildingArea")
                        .HasColumnType("float");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RenterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RenterId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.ElectricalEquipement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Coefficient")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Power")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ElectricalEquipments");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.Renter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Renters");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<string>("ResourceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = -2,
                            Name = "user"
                        },
                        new
                        {
                            Id = -1,
                            Name = "admin"
                        });
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LeavingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RenterId")
                        .HasColumnType("int");

                    b.Property<double>("RoomArea")
                        .HasColumnType("float");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<double>("TotalWorkers")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("RenterId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.RoomElectricalEquipement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ElectricalEquipementId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ElectricalEquipementId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomElectricalEquipements");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Fri")
                        .HasColumnType("bit");

                    b.Property<bool>("Mon")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sat")
                        .HasColumnType("bit");

                    b.Property<bool>("Sun")
                        .HasColumnType("bit");

                    b.Property<bool>("Thu")
                        .HasColumnType("bit");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int");

                    b.Property<bool>("Tue")
                        .HasColumnType("bit");

                    b.Property<bool>("Wed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Password = "123456",
                            RoleId = -1,
                            Username = "Patrick"
                        });
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.Building", b =>
                {
                    b.HasOne("Electricity.DataAccess.Entities.Renter", "Renter")
                        .WithMany("Buildings")
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Renter");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.Resource", b =>
                {
                    b.HasOne("Electricity.DataAccess.Entities.Building", "Building")
                        .WithMany("Resources")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.Room", b =>
                {
                    b.HasOne("Electricity.DataAccess.Entities.Building", "Building")
                        .WithMany("Rooms")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Electricity.DataAccess.Entities.Renter", "Renter")
                        .WithMany("Rooms")
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Electricity.DataAccess.Entities.Schedule", "Schedule")
                        .WithMany("Rooms")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("Renter");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.RoomElectricalEquipement", b =>
                {
                    b.HasOne("Electricity.DataAccess.Entities.ElectricalEquipement", "ElectricalEquipement")
                        .WithMany("RoomElectricalEquipements")
                        .HasForeignKey("ElectricalEquipementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Electricity.DataAccess.Entities.Room", "Room")
                        .WithMany("RoomElectricalEquipements")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ElectricalEquipement");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.User", b =>
                {
                    b.HasOne("Electricity.DataAccess.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.Building", b =>
                {
                    b.Navigation("Resources");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.ElectricalEquipement", b =>
                {
                    b.Navigation("RoomElectricalEquipements");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.Renter", b =>
                {
                    b.Navigation("Buildings");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.Room", b =>
                {
                    b.Navigation("RoomElectricalEquipements");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.Schedule", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
