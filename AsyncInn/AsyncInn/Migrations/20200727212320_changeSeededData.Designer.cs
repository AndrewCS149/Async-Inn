﻿// <auto-generated />
using System;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncInn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20200727212320_changeSeededData")]
    partial class changeSeededData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsyncInn.Models.Amenities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fridge"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Microwave"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Minibar"
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Seattle",
                            Name = "Good Feels Inn",
                            Phone = "8675309",
                            State = "WA",
                            StreetAddress = "12345 Road Street"
                        },
                        new
                        {
                            Id = 2,
                            City = "Rockford",
                            Name = "Nice Stay Lounge",
                            Phone = "8675309",
                            State = "IL",
                            StreetAddress = "334 2nd street"
                        },
                        new
                        {
                            Id = 3,
                            City = "Issaquah",
                            Name = "Relaxation Paradise",
                            Phone = "8675309",
                            State = "WA",
                            StreetAddress = "61107 Hillbridge Road"
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<bool>("PetFriendly")
                        .HasColumnType("bit");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("HotelId", "RoomNumber");

                    b.ToTable("HotelRoom");

                    b.HasData(
                        new
                        {
                            HotelId = 1,
                            RoomNumber = 1,
                            PetFriendly = true,
                            Rate = 75.00m,
                            RoomId = 1
                        },
                        new
                        {
                            HotelId = 1,
                            RoomNumber = 2,
                            PetFriendly = false,
                            Rate = 125.00m,
                            RoomId = 2
                        },
                        new
                        {
                            HotelId = 1,
                            RoomNumber = 3,
                            PetFriendly = true,
                            Rate = 100.00m,
                            RoomId = 3
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HotelRoomHotelId")
                        .HasColumnType("int");

                    b.Property<int?>("HotelRoomRoomNumber")
                        .HasColumnType("int");

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelRoomHotelId", "HotelRoomRoomNumber");

                    b.ToTable("Room");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Layout = 1,
                            Name = "Relax"
                        },
                        new
                        {
                            Id = 2,
                            Layout = 1,
                            Name = "Vibrant"
                        },
                        new
                        {
                            Id = 3,
                            Layout = 0,
                            Name = "Sooth"
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("AmenitiesId")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "AmenitiesId");

                    b.HasIndex("AmenitiesId");

                    b.ToTable("RoomAmenity");
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.HasOne("AsyncInn.Models.Hotel", "Hotel")
                        .WithMany("HotelRoom")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AsyncInn.Models.Room", b =>
                {
                    b.HasOne("AsyncInn.Models.HotelRoom", null)
                        .WithMany("Room")
                        .HasForeignKey("HotelRoomHotelId", "HotelRoomRoomNumber");
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.HasOne("AsyncInn.Models.Amenities", "Amenity")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
