using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B_B_api.Migrations
{
    /// <inheritdoc />
    public partial class AccessoryAsEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "RoomAccessories",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 8, 21, 0, 5, 5, 852, DateTimeKind.Local).AddTicks(5152));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 8, 21, 0, 5, 5, 852, DateTimeKind.Local).AddTicks(5199));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 8, 21, 0, 5, 5, 852, DateTimeKind.Local).AddTicks(5202));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "RoomAccessories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 8, 16, 9, 0, 55, 283, DateTimeKind.Local).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 8, 16, 9, 0, 55, 283, DateTimeKind.Local).AddTicks(9808));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 8, 16, 9, 0, 55, 283, DateTimeKind.Local).AddTicks(9810));
        }
    }
}
