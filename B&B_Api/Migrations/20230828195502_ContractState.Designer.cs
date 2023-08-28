﻿// <auto-generated />
using System;
using B_B_api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace B_B_api.Migrations
{
    [DbContext(typeof(BedAndBreakfastContext))]
    [Migration("20230828195502_ContractState")]
    partial class ContractState
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SignedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbLandlord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPRNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Landlords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountNumber = "0000222244446666",
                            CPRNumber = "0101906673",
                            RegistrationNumber = "6789",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AmountOfRooms")
                        .HasColumnType("int");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LandlordId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LandlordId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Havnevej 1",
                            AmountOfRooms = 4,
                            Area = "TestArea",
                            City = "Skagen",
                            Country = "Denmark",
                            LandlordId = 1,
                            Name = "Hansens fede Bed and Breakfast",
                            Rating = 4.0999999999999996,
                            ZipCode = "1000"
                        });
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbLocationPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Base64")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("LocationPictures");
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbLocationRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("LocationRatings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LocationId = 1,
                            Rating = 4.0
                        },
                        new
                        {
                            Id = 2,
                            LocationId = 1,
                            Rating = 5.0
                        });
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfBeds")
                        .HasColumnType("int");

                    b.Property<int>("PricePerNight")
                        .HasColumnType("int");

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LocationId = 1,
                            Number = 1,
                            NumberOfBeds = 2,
                            PricePerNight = 500,
                            Rating = 4.0
                        },
                        new
                        {
                            Id = 2,
                            LocationId = 1,
                            Number = 2,
                            NumberOfBeds = 2,
                            PricePerNight = 200,
                            Rating = 2.0
                        },
                        new
                        {
                            Id = 3,
                            LocationId = 1,
                            Number = 3,
                            NumberOfBeds = 1,
                            PricePerNight = 1000,
                            Rating = 5.0
                        },
                        new
                        {
                            Id = 4,
                            LocationId = 1,
                            Number = 4,
                            NumberOfBeds = 3,
                            PricePerNight = 2000,
                            Rating = 1.0
                        });
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbRoomAccessory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoomAccessory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Desk"
                        },
                        new
                        {
                            Id = 2,
                            Type = "TV"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Wifi"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Balcony"
                        });
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbRoomPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Base64")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomPictures");
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbRoomRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomRatings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Rating = 1.0,
                            RoomId = 1
                        },
                        new
                        {
                            Id = 2,
                            Rating = 5.0,
                            RoomId = 2
                        },
                        new
                        {
                            Id = 3,
                            Rating = 3.0,
                            RoomId = 4
                        });
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "Denmark",
                            Created = new DateTime(2023, 8, 28, 21, 55, 2, 249, DateTimeKind.Local).AddTicks(8679),
                            Email = "ken1ander2@hotmail.com",
                            FirstName = "Kenneth",
                            LastName = "Andersen",
                            Password = "12345",
                            PasswordSalt = "NotRealSalt",
                            PhoneNumber = "12345678",
                            Username = "Kenneth123"
                        },
                        new
                        {
                            Id = 2,
                            Country = "Denmark",
                            Created = new DateTime(2023, 8, 28, 21, 55, 2, 249, DateTimeKind.Local).AddTicks(8725),
                            Email = "mortvest5@gmail.com",
                            FirstName = "Morten",
                            LastName = "Vestergaard",
                            Password = "12345",
                            PasswordSalt = "NotRealSalt",
                            PhoneNumber = "11223344",
                            Username = "Morten123"
                        },
                        new
                        {
                            Id = 3,
                            Country = "Denmark",
                            Created = new DateTime(2023, 8, 28, 21, 55, 2, 249, DateTimeKind.Local).AddTicks(8728),
                            Email = "buster@outlook.com",
                            FirstName = "Buster",
                            LastName = "Jørgensen",
                            Password = "12345",
                            PasswordSalt = "NotRealSalt",
                            PhoneNumber = "55005500",
                            Username = "Buster123"
                        });
                });

            modelBuilder.Entity("RoomAccessories", b =>
                {
                    b.Property<int>("AccessoriesId")
                        .HasColumnType("int");

                    b.Property<int>("RoomsId")
                        .HasColumnType("int");

                    b.HasKey("AccessoriesId", "RoomsId");

                    b.HasIndex("RoomsId");

                    b.ToTable("RoomAccessories");
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbContract", b =>
                {
                    b.HasOne("B_B_ClassLibrary.Models.DbRoom", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("B_B_ClassLibrary.Models.DbUser", "User")
                        .WithMany("Contracts")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbLandlord", b =>
                {
                    b.HasOne("B_B_ClassLibrary.Models.DbUser", "User")
                        .WithOne("Landlord")
                        .HasForeignKey("B_B_ClassLibrary.Models.DbLandlord", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbLocation", b =>
                {
                    b.HasOne("B_B_ClassLibrary.Models.DbLandlord", "Landlord")
                        .WithMany("Locations")
                        .HasForeignKey("LandlordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Landlord");
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbLocationPicture", b =>
                {
                    b.HasOne("B_B_ClassLibrary.Models.DbLocation", "Location")
                        .WithMany("Pictures")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbLocationRating", b =>
                {
                    b.HasOne("B_B_ClassLibrary.Models.DbLocation", "Location")
                        .WithMany("Ratings")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbRoom", b =>
                {
                    b.HasOne("B_B_ClassLibrary.Models.DbLocation", "Location")
                        .WithMany("Rooms")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbRoomPicture", b =>
                {
                    b.HasOne("B_B_ClassLibrary.Models.DbRoom", "Room")
                        .WithMany("Pictures")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbRoomRating", b =>
                {
                    b.HasOne("B_B_ClassLibrary.Models.DbRoom", "Room")
                        .WithMany("Ratings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("RoomAccessories", b =>
                {
                    b.HasOne("B_B_ClassLibrary.Models.DbRoomAccessory", null)
                        .WithMany()
                        .HasForeignKey("AccessoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("B_B_ClassLibrary.Models.DbRoom", null)
                        .WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbLandlord", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbLocation", b =>
                {
                    b.Navigation("Pictures");

                    b.Navigation("Ratings");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbRoom", b =>
                {
                    b.Navigation("Pictures");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("B_B_ClassLibrary.Models.DbUser", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("Landlord");
                });
#pragma warning restore 612, 618
        }
    }
}
