using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B_B_api.Migrations
{
    /// <inheritdoc />
    public partial class DbPictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbLocationPicture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Base64 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbLocationPicture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbRoomPicture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Base64 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbRoomPicture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbLocationDbLocationPicture",
                columns: table => new
                {
                    LocationsId = table.Column<int>(type: "int", nullable: false),
                    PicturesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbLocationDbLocationPicture", x => new { x.LocationsId, x.PicturesId });
                    table.ForeignKey(
                        name: "FK_DbLocationDbLocationPicture_DbLocationPicture_PicturesId",
                        column: x => x.PicturesId,
                        principalTable: "DbLocationPicture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbLocationDbLocationPicture_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbRoomDbRoomPicture",
                columns: table => new
                {
                    PicturesId = table.Column<int>(type: "int", nullable: false),
                    RoomsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbRoomDbRoomPicture", x => new { x.PicturesId, x.RoomsId });
                    table.ForeignKey(
                        name: "FK_DbRoomDbRoomPicture_DbRoomPicture_PicturesId",
                        column: x => x.PicturesId,
                        principalTable: "DbRoomPicture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbRoomDbRoomPicture_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 8, 21, 0, 22, 9, 35, DateTimeKind.Local).AddTicks(6877));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 8, 21, 0, 22, 9, 35, DateTimeKind.Local).AddTicks(6922));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 8, 21, 0, 22, 9, 35, DateTimeKind.Local).AddTicks(6924));

            migrationBuilder.CreateIndex(
                name: "IX_DbLocationDbLocationPicture_PicturesId",
                table: "DbLocationDbLocationPicture",
                column: "PicturesId");

            migrationBuilder.CreateIndex(
                name: "IX_DbRoomDbRoomPicture_RoomsId",
                table: "DbRoomDbRoomPicture",
                column: "RoomsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbLocationDbLocationPicture");

            migrationBuilder.DropTable(
                name: "DbRoomDbRoomPicture");

            migrationBuilder.DropTable(
                name: "DbLocationPicture");

            migrationBuilder.DropTable(
                name: "DbRoomPicture");

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
    }
}
