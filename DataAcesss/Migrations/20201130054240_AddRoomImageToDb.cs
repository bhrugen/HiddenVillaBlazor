using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAcesss.Migrations
{
    public partial class AddRoomImageToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelRoomImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    RoomImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoomImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelRoomImages_HotelRooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "HotelRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoomImages_RoomId",
                table: "HotelRoomImages",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelRoomImages");
        }
    }
}
