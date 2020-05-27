using Microsoft.EntityFrameworkCore.Migrations;

namespace DAl.Impl.Migrations
{
    public partial class RouteProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutePropereties_Train_TrainId",
                table: "RoutePropereties");

            migrationBuilder.AlterColumn<int>(
                name: "TrainId",
                table: "RoutePropereties",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutePropereties_Train_TrainId",
                table: "RoutePropereties",
                column: "TrainId",
                principalTable: "Train",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutePropereties_Train_TrainId",
                table: "RoutePropereties");

            migrationBuilder.AlterColumn<int>(
                name: "TrainId",
                table: "RoutePropereties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_RoutePropereties_Train_TrainId",
                table: "RoutePropereties",
                column: "TrainId",
                principalTable: "Train",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
