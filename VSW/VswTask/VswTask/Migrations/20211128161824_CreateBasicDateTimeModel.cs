using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VswTask.Migrations
{
    public partial class CreateBasicDateTimeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BasicDateId",
                table: "BasicModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BasicDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicDate", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasicModels_BasicDateId",
                table: "BasicModels",
                column: "BasicDateId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasicModels_BasicDate_BasicDateId",
                table: "BasicModels",
                column: "BasicDateId",
                principalTable: "BasicDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicModels_BasicDate_BasicDateId",
                table: "BasicModels");

            migrationBuilder.DropTable(
                name: "BasicDate");

            migrationBuilder.DropIndex(
                name: "IX_BasicModels_BasicDateId",
                table: "BasicModels");

            migrationBuilder.DropColumn(
                name: "BasicDateId",
                table: "BasicModels");
        }
    }
}
