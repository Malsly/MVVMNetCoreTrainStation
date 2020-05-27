using Microsoft.EntityFrameworkCore.Migrations;

namespace DAl.Impl.Migrations
{
    public partial class UpdateVan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Van_ClassPropereties_ClassProperetiesId",
                table: "Van");

            migrationBuilder.AlterColumn<int>(
                name: "ClassProperetiesId",
                table: "Van",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Van_ClassPropereties_ClassProperetiesId",
                table: "Van",
                column: "ClassProperetiesId",
                principalTable: "ClassPropereties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Van_ClassPropereties_ClassProperetiesId",
                table: "Van");

            migrationBuilder.AlterColumn<int>(
                name: "ClassProperetiesId",
                table: "Van",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Van_ClassPropereties_ClassProperetiesId",
                table: "Van",
                column: "ClassProperetiesId",
                principalTable: "ClassPropereties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
