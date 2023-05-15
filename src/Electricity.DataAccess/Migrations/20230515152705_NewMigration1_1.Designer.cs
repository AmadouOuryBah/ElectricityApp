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
    [Migration("20230515152705_NewMigration1_1")]
    partial class NewMigration1_1
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

                    b.Property<int>("ElectricityMeterId")
                        .HasColumnType("int");

                    b.Property<int>("HeatMeterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WaterMeterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ElectricityMeterId");

                    b.HasIndex("HeatMeterId")
                        .IsUnique();

                    b.HasIndex("WaterMeterId")
                        .IsUnique();

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

            modelBuilder.Entity("Electricity.DataAccess.Entities.ElectricityMeter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FactoryNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ElectricityMeters");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.HeatMeter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FactoryNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HeatMeters");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.MetersData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Indication")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MetersDatas");
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

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RenterId")
                        .HasColumnType("int");

                    b.Property<double>("RoomArea")
                        .HasColumnType("float");

                    b.Property<double>("TotalWorkers")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("RenterId");

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

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("WorkingTime")
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

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("TotalOfDay")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId")
                        .IsUnique();

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

            modelBuilder.Entity("Electricity.DataAccess.Entities.WaterMeter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FactoryNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WaterMeters");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.Building", b =>
                {
                    b.HasOne("Electricity.DataAccess.Entities.ElectricityMeter", "ElectricityMeter")
                        .WithMany("Building")
                        .HasForeignKey("ElectricityMeterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Electricity.DataAccess.Entities.HeatMeter", "HeatMeter")
                        .WithOne("Building")
                        .HasForeignKey("Electricity.DataAccess.Entities.Building", "HeatMeterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Electricity.DataAccess.Entities.WaterMeter", "WaterMeter")
                        .WithOne("Building")
                        .HasForeignKey("Electricity.DataAccess.Entities.Building", "WaterMeterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ElectricityMeter");

                    b.Navigation("HeatMeter");

                    b.Navigation("WaterMeter");
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

                    b.Navigation("Building");

                    b.Navigation("Renter");
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

            modelBuilder.Entity("Electricity.DataAccess.Entities.Schedule", b =>
                {
                    b.HasOne("Electricity.DataAccess.Entities.Room", "Room")
                        .WithOne("Schedule")
                        .HasForeignKey("Electricity.DataAccess.Entities.Schedule", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.ElectricalEquipement", b =>
                {
                    b.Navigation("RoomElectricalEquipements");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.ElectricityMeter", b =>
                {
                    b.Navigation("Building");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.HeatMeter", b =>
                {
                    b.Navigation("Building")
                        .IsRequired();
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.Renter", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.Room", b =>
                {
                    b.Navigation("RoomElectricalEquipements");

                    b.Navigation("Schedule")
                        .IsRequired();
                });

            modelBuilder.Entity("Electricity.DataAccess.Entities.WaterMeter", b =>
                {
                    b.Navigation("Building")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
