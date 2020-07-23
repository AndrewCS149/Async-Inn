using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class addRoomAmenitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Layout = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelRoom",
                columns: table => new
                {
                    HotelId = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    PetFriendly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoom", x => new { x.HotelId, x.RoomNumber });
                    table.ForeignKey(
                        name: "FK_HotelRoom_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelRoom_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomAmenity",
                columns: table => new
                {
                    AmenitiesId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenity", x => new { x.RoomId, x.AmenitiesId });
                    table.ForeignKey(
                        name: "FK_RoomAmenity_Amenities_AmenitiesId",
                        column: x => x.AmenitiesId,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAmenity_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fridge" },
                    { 2, "Microwave" },
                    { 3, "Minibar" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "City", "Name", "Phone", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Seattle", "Good Feels Inn", "8675309", "WA", "12345 Road Street" },
                    { 2, "Rockford", "Nice Stay Lounge", "8675309", "IL", "334 2nd street" },
                    { 3, "Issaquah", "Relaxation Paradise", "8675309", "WA", "61107 Hillbridge Road" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "Layout", "Name" },
                values: new object[,]
                {
                    { 1, 2, "Relax" },
                    { 2, 1, "Vibrant" },
                    { 3, 0, "Sooth" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_RoomId",
                table: "HotelRoom",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenity_AmenitiesId",
                table: "RoomAmenity",
                column: "AmenitiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelRoom");

            migrationBuilder.DropTable(
                name: "RoomAmenity");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
