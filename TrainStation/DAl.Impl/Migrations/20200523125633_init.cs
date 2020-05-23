using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAl.Impl.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassPropereties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPropereties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passanger",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passanger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Train",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PlaceDeparture = table.Column<string>(nullable: true),
                    PlaceArrival = table.Column<string>(nullable: true),
                    StationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Train_Station_StationId",
                        column: x => x.StationId,
                        principalTable: "Station",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoutePropereties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    TrainId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutePropereties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutePropereties_Train_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Train",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Van",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassProperetiesId = table.Column<int>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    TrainId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Van", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Van_ClassPropereties_ClassProperetiesId",
                        column: x => x.ClassProperetiesId,
                        principalTable: "ClassPropereties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Van_Train_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Train",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    IsOccupied = table.Column<bool>(nullable: false),
                    VanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_Van_VanId",
                        column: x => x.VanId,
                        principalTable: "Van",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassangerId = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    VanId = table.Column<int>(nullable: true),
                    TrainId = table.Column<int>(nullable: true),
                    SeatId = table.Column<int>(nullable: true),
                    RouteProperetiesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Passanger_PassangerId",
                        column: x => x.PassangerId,
                        principalTable: "Passanger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_RoutePropereties_RouteProperetiesId",
                        column: x => x.RouteProperetiesId,
                        principalTable: "RoutePropereties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Train_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Train",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Van_VanId",
                        column: x => x.VanId,
                        principalTable: "Van",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoutePropereties_TrainId",
                table: "RoutePropereties",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_VanId",
                table: "Seat",
                column: "VanId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PassangerId",
                table: "Ticket",
                column: "PassangerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_RouteProperetiesId",
                table: "Ticket",
                column: "RouteProperetiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SeatId",
                table: "Ticket",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TrainId",
                table: "Ticket",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_VanId",
                table: "Ticket",
                column: "VanId");

            migrationBuilder.CreateIndex(
                name: "IX_Train_StationId",
                table: "Train",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Van_ClassProperetiesId",
                table: "Van",
                column: "ClassProperetiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Van_TrainId",
                table: "Van",
                column: "TrainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Passanger");

            migrationBuilder.DropTable(
                name: "RoutePropereties");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Van");

            migrationBuilder.DropTable(
                name: "ClassPropereties");

            migrationBuilder.DropTable(
                name: "Train");

            migrationBuilder.DropTable(
                name: "Station");
        }
    }
}
