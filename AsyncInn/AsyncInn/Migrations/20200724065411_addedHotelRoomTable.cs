using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class addedHotelRoomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Room_RoomId",
                table: "HotelRoom");

            migrationBuilder.DropIndex(
                name: "IX_HotelRoom_RoomId",
                table: "HotelRoom");

            migrationBuilder.AddColumn<int>(
                name: "HotelRoomHotelId",
                table: "Room",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelRoomRoomNumber",
                table: "Room",
                nullable: true);

            migrationBuilder.InsertData(
                table: "HotelRoom",
                columns: new[] { "HotelId", "RoomNumber", "PetFriendly", "Rate", "RoomId" },
                values: new object[] { 1, 1, true, 75.00m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Room_HotelRoomHotelId_HotelRoomRoomNumber",
                table: "Room",
                columns: new[] { "HotelRoomHotelId", "HotelRoomRoomNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Room_HotelRoom_HotelRoomHotelId_HotelRoomRoomNumber",
                table: "Room",
                columns: new[] { "HotelRoomHotelId", "HotelRoomRoomNumber" },
                principalTable: "HotelRoom",
                principalColumns: new[] { "HotelId", "RoomNumber" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_HotelRoom_HotelRoomHotelId_HotelRoomRoomNumber",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_HotelRoomHotelId_HotelRoomRoomNumber",
                table: "Room");

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DropColumn(
                name: "HotelRoomHotelId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "HotelRoomRoomNumber",
                table: "Room");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_RoomId",
                table: "HotelRoom",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Room_RoomId",
                table: "HotelRoom",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
