using Microsoft.EntityFrameworkCore.Migrations;

namespace DAl.Impl.Migrations
{
    public partial class SeatEntit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Van_VanId",
                table: "Seat");

            migrationBuilder.AlterColumn<int>(
                name: "VanId",
                table: "Seat",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Van_VanId",
                table: "Seat",
                column: "VanId",
                principalTable: "Van",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Van_VanId",
                table: "Seat");

            migrationBuilder.AlterColumn<int>(
                name: "VanId",
                table: "Seat",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Van_VanId",
                table: "Seat",
                column: "VanId",
                principalTable: "Van",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
