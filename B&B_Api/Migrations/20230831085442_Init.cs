﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace B_B_api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomAccessory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAccessory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Landlords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPRNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landlords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Landlords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LandlordId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountOfRooms = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Landlords_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "Landlords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationPictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Base64 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationPictures_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationRatings_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    NumberOfBeds = table.Column<int>(type: "int", nullable: false),
                    PricePerNight = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    SignedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoomAccessories",
                columns: table => new
                {
                    AccessoriesId = table.Column<int>(type: "int", nullable: false),
                    RoomsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAccessories", x => new { x.AccessoriesId, x.RoomsId });
                    table.ForeignKey(
                        name: "FK_RoomAccessories_RoomAccessory_AccessoriesId",
                        column: x => x.AccessoriesId,
                        principalTable: "RoomAccessory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAccessories_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomPictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Base64 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomPictures_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomRatings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RoomAccessory",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Desk" },
                    { 2, "TV" },
                    { 3, "Wifi" },
                    { 4, "Balcony" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Country", "Created", "Email", "FirstName", "LastName", "Password", "PasswordSalt", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 1, "Denmark", new DateTime(2023, 8, 31, 10, 54, 41, 646, DateTimeKind.Local).AddTicks(4237), "ken1ander2@hotmail.com", "Kenneth", "Andersen", "q5yHTWQW2SrE3gyI3SHQfZYmjsdy274WcllLHch+Zho=", "wuB6MiK4WMA=", "12345678", "Kenneth" },
                    { 2, "Denmark", new DateTime(2023, 8, 31, 10, 54, 41, 646, DateTimeKind.Local).AddTicks(4413), "mortvest5@gmail.com", "Morten", "Vestergaard", "Eyki/vykvjv6hF1GC3xN49mFA9Sxf8+GL2DA3qVV5Os=", "aUDcodYHRV8=", "11223344", "Mort" },
                    { 3, "Denmark", new DateTime(2023, 8, 31, 10, 54, 41, 646, DateTimeKind.Local).AddTicks(4439), "buster@outlook.com", "Buster", "Jørgensen", "12345", "NotRealSalt", "55005500", "Buster123" }
                });

            migrationBuilder.InsertData(
                table: "Landlords",
                columns: new[] { "Id", "AccountNumber", "CPRNumber", "RegistrationNumber", "UserId" },
                values: new object[] { 1, "0000222244446666", "0101906673", "6789", 1 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "AmountOfRooms", "Area", "City", "Country", "LandlordId", "Name", "Rating", "ZipCode" },
                values: new object[] { 1, "Havnevej 1", 4, "TestArea", "Skagen", "Denmark", 1, "Hansens fede Bed and Breakfast", 4.0999999999999996, "1000" });

            migrationBuilder.InsertData(
                table: "LocationRatings",
                columns: new[] { "Id", "LocationId", "Rating" },
                values: new object[,]
                {
                    { 1, 1, 4.0 },
                    { 2, 1, 5.0 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "LocationId", "Number", "NumberOfBeds", "PricePerNight", "Rating" },
                values: new object[,]
                {
                    { 1, 1, 1, 2, 500, 4.0 },
                    { 2, 1, 2, 2, 200, 2.0 },
                    { 3, 1, 3, 1, 1000, 5.0 },
                    { 4, 1, 4, 3, 2000, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "FromDate", "RoomId", "SignedDate", "State", "ToDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 31, 10, 54, 41, 646, DateTimeKind.Local).AddTicks(6761), 1, new DateTime(2023, 8, 31, 10, 54, 41, 646, DateTimeKind.Local).AddTicks(6699), "Pending", new DateTime(2023, 8, 31, 10, 54, 41, 646, DateTimeKind.Local).AddTicks(6773), 2 },
                    { 2, new DateTime(2023, 8, 31, 10, 54, 41, 646, DateTimeKind.Local).AddTicks(6807), 2, new DateTime(2023, 8, 31, 10, 54, 41, 646, DateTimeKind.Local).AddTicks(6794), "Pending", new DateTime(2023, 8, 31, 10, 54, 41, 646, DateTimeKind.Local).AddTicks(6820), 2 },
                    { 3, new DateTime(2023, 8, 31, 10, 54, 41, 646, DateTimeKind.Local).AddTicks(6851), 3, new DateTime(2023, 8, 31, 10, 54, 41, 646, DateTimeKind.Local).AddTicks(6839), "Approved", new DateTime(2023, 8, 31, 10, 54, 41, 646, DateTimeKind.Local).AddTicks(6864), 2 },
                    { 4, new DateTime(2023, 8, 31, 10, 54, 41, 646, DateTimeKind.Local).AddTicks(6892), 4, new DateTime(2023, 8, 31, 10, 54, 41, 646, DateTimeKind.Local).AddTicks(6879), "Approved", new DateTime(2023, 8, 31, 10, 54, 41, 646, DateTimeKind.Local).AddTicks(6905), 2 }
                });

            migrationBuilder.InsertData(
                table: "RoomRatings",
                columns: new[] { "Id", "Rating", "RoomId" },
                values: new object[,]
                {
                    { 1, 1.0, 1 },
                    { 2, 5.0, 2 },
                    { 3, 3.0, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_RoomId",
                table: "Contracts",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_UserId",
                table: "Contracts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Landlords_UserId",
                table: "Landlords",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationPictures_LocationId",
                table: "LocationPictures",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationRatings_LocationId",
                table: "LocationRatings",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LandlordId",
                table: "Locations",
                column: "LandlordId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAccessories_RoomsId",
                table: "RoomAccessories",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomPictures_RoomId",
                table: "RoomPictures",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRatings_RoomId",
                table: "RoomRatings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_LocationId",
                table: "Rooms",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "LocationPictures");

            migrationBuilder.DropTable(
                name: "LocationRatings");

            migrationBuilder.DropTable(
                name: "RoomAccessories");

            migrationBuilder.DropTable(
                name: "RoomPictures");

            migrationBuilder.DropTable(
                name: "RoomRatings");

            migrationBuilder.DropTable(
                name: "RoomAccessory");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Landlords");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
