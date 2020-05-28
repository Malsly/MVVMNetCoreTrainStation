using Microsoft.EntityFrameworkCore.Migrations;

namespace DAl.Impl.Migrations
{
    public partial class StatinUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_RoutePropereties_RouteProperetiesId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_RouteProperetiesId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "RouteProperetiesId",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "StationId",
                table: "Ticket",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_StationId",
                table: "Ticket",
                column: "StationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Station_StationId",
                table: "Ticket",
                column: "StationId",
                principalTable: "Station",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Station_StationId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_StationId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "StationId",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "RouteProperetiesId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_RouteProperetiesId",
                table: "Ticket",
                column: "RouteProperetiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_RoutePropereties_RouteProperetiesId",
                table: "Ticket",
                column: "RouteProperetiesId",
                principalTable: "RoutePropereties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
