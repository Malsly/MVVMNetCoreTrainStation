using Microsoft.EntityFrameworkCore.Migrations;

namespace DAl.Impl.Migrations
{
    public partial class Updatetr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutePropereties_Train_RouteProperetiesId",
                table: "RoutePropereties");

            migrationBuilder.DropIndex(
                name: "IX_RoutePropereties_RouteProperetiesId",
                table: "RoutePropereties");

            migrationBuilder.DropColumn(
                name: "RouteProperetiesId",
                table: "Train");

            migrationBuilder.DropColumn(
                name: "RouteProperetiesId",
                table: "RoutePropereties");

            migrationBuilder.AddColumn<int>(
                name: "TrainId",
                table: "RoutePropereties",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoutePropereties_TrainId",
                table: "RoutePropereties",
                column: "TrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoutePropereties_Train_TrainId",
                table: "RoutePropereties",
                column: "TrainId",
                principalTable: "Train",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutePropereties_Train_TrainId",
                table: "RoutePropereties");

            migrationBuilder.DropIndex(
                name: "IX_RoutePropereties_TrainId",
                table: "RoutePropereties");

            migrationBuilder.DropColumn(
                name: "TrainId",
                table: "RoutePropereties");

            migrationBuilder.AddColumn<int>(
                name: "RouteProperetiesId",
                table: "Train",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RouteProperetiesId",
                table: "RoutePropereties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoutePropereties_RouteProperetiesId",
                table: "RoutePropereties",
                column: "RouteProperetiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoutePropereties_Train_RouteProperetiesId",
                table: "RoutePropereties",
                column: "RouteProperetiesId",
                principalTable: "Train",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
