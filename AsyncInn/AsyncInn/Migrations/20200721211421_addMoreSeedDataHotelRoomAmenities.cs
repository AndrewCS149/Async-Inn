using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class addMoreSeedDataHotelRoomAmenities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Minibar" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Phone",
                value: "8675309");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Phone", "StreetAddress" },
                values: new object[] { "8675309", "334 2nd street" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "City", "Name", "Phone", "State", "StreetAddress" },
                values: new object[] { 3, "Issaquah", "Relaxation Paradise", "8675309", "WA", "61107 Hillbridge Road" });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "Layout", "Name" },
                values: new object[] { 3, 0, "Sooth" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Phone",
                value: "12345678");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Phone", "StreetAddress" },
                values: new object[] { "12345678", "12345 Road Street" });
        }
    }
}
