using Microsoft.EntityFrameworkCore.Migrations;

namespace DAl.Impl.Migrations
{
    public partial class Ticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Passanger_PassangerId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_RoutePropereties_RouteProperetiesId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Seat_SeatId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Train_TrainId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Van_VanId",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "VanId",
                table: "Ticket",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrainId",
                table: "Ticket",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SeatId",
                table: "Ticket",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RouteProperetiesId",
                table: "Ticket",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PassangerId",
                table: "Ticket",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Passanger_PassangerId",
                table: "Ticket",
                column: "PassangerId",
                principalTable: "Passanger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_RoutePropereties_RouteProperetiesId",
                table: "Ticket",
                column: "RouteProperetiesId",
                principalTable: "RoutePropereties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Seat_SeatId",
                table: "Ticket",
                column: "SeatId",
                principalTable: "Seat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Train_TrainId",
                table: "Ticket",
                column: "TrainId",
                principalTable: "Train",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Van_VanId",
                table: "Ticket",
                column: "VanId",
                principalTable: "Van",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Passanger_PassangerId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_RoutePropereties_RouteProperetiesId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Seat_SeatId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Train_TrainId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Van_VanId",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "VanId",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TrainId",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SeatId",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RouteProperetiesId",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PassangerId",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Passanger_PassangerId",
                table: "Ticket",
                column: "PassangerId",
                principalTable: "Passanger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_RoutePropereties_RouteProperetiesId",
                table: "Ticket",
                column: "RouteProperetiesId",
                principalTable: "RoutePropereties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Seat_SeatId",
                table: "Ticket",
                column: "SeatId",
                principalTable: "Seat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Train_TrainId",
                table: "Ticket",
                column: "TrainId",
                principalTable: "Train",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Van_VanId",
                table: "Ticket",
                column: "VanId",
                principalTable: "Van",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
