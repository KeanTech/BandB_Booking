using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace B_B_api.Migrations
{
    /// <inheritdoc />
    public partial class DbSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Country", "Created", "Email", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Denmark", new DateTime(2023, 8, 16, 9, 0, 55, 283, DateTimeKind.Local).AddTicks(9765), "ken1ander2@hotmail.com", "Kenneth", "Andersen", "12345", "12345678" },
                    { 2, "Denmark", new DateTime(2023, 8, 16, 9, 0, 55, 283, DateTimeKind.Local).AddTicks(9808), "mortvest5@gmail.com", "Morten", "Vestergaard", "12345", "11223344" },
                    { 3, "Denmark", new DateTime(2023, 8, 16, 9, 0, 55, 283, DateTimeKind.Local).AddTicks(9810), "buster@outlook.com", "Buster", "Jørgensen", "12345", "55005500" }
                });

            migrationBuilder.InsertData(
                table: "Landlords",
                columns: new[] { "Id", "AccountNumber", "CPRNumber", "RegistrationNumber", "UserId" },
                values: new object[] { 1, "0000222244446666", "0101906673", "6789", 3 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "AmountOfRooms", "Area", "City", "Country", "LandlordId", "Name", "Rating", "ZipCode" },
                values: new object[] { 1, "Havnevej 1", 4, "TestArea", "Skagen", "Denmark", 1, "Hansens fede Bed and Breakfast", 4.0999999999999996, "1000" });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Landlords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
