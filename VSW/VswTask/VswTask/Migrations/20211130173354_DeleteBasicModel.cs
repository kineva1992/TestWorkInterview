using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VswTask.Migrations
{
    public partial class DeleteBasicModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicModels_BasicDates_BasicDateId",
                table: "BasicModels");

            migrationBuilder.DropTable(
                name: "BasicDates");

            migrationBuilder.DropIndex(
                name: "IX_BasicModels_BasicDateId",
                table: "BasicModels");

            migrationBuilder.DropColumn(
                name: "BasicDateId",
                table: "BasicModels");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "BasicModels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "BasicModels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "BasicModels");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "BasicModels");

            migrationBuilder.AddColumn<int>(
                name: "BasicDateId",
                table: "BasicModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BasicDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicDates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasicModels_BasicDateId",
                table: "BasicModels",
                column: "BasicDateId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasicModels_BasicDates_BasicDateId",
                table: "BasicModels",
                column: "BasicDateId",
                principalTable: "BasicDates",
                principalColumn: "Id");
        }
    }
}
