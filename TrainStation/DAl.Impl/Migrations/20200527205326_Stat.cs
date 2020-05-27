using Microsoft.EntityFrameworkCore.Migrations;

namespace DAl.Impl.Migrations
{
    public partial class Stat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Train_Station_StationId",
                table: "Train");

            migrationBuilder.AlterColumn<int>(
                name: "StationId",
                table: "Train",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Train_Station_StationId",
                table: "Train",
                column: "StationId",
                principalTable: "Station",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Train_Station_StationId",
                table: "Train");

            migrationBuilder.AlterColumn<int>(
                name: "StationId",
                table: "Train",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Train_Station_StationId",
                table: "Train",
                column: "StationId",
                principalTable: "Station",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
