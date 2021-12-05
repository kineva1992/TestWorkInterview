using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VswTask.Migrations
{
    public partial class CreateBasicDateTimeModelEditDbContext1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicModels_BasicDates_BasicDateId1",
                table: "BasicModels");

            migrationBuilder.DropForeignKey(
                name: "FK_BasicModels_TargetOuterDiameters_BasicDateId",
                table: "BasicModels");

            migrationBuilder.DropIndex(
                name: "IX_BasicModels_BasicDateId1",
                table: "BasicModels");

            migrationBuilder.DropColumn(
                name: "BasicDateId1",
                table: "BasicModels");

            migrationBuilder.CreateIndex(
                name: "IX_BasicModels_TargetDiameterId",
                table: "BasicModels",
                column: "TargetDiameterId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasicModels_BasicDates_BasicDateId",
                table: "BasicModels",
                column: "BasicDateId",
                principalTable: "BasicDates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasicModels_TargetOuterDiameters_TargetDiameterId",
                table: "BasicModels",
                column: "TargetDiameterId",
                principalTable: "TargetOuterDiameters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicModels_BasicDates_BasicDateId",
                table: "BasicModels");

            migrationBuilder.DropForeignKey(
                name: "FK_BasicModels_TargetOuterDiameters_TargetDiameterId",
                table: "BasicModels");

            migrationBuilder.DropIndex(
                name: "IX_BasicModels_TargetDiameterId",
                table: "BasicModels");

            migrationBuilder.AddColumn<int>(
                name: "BasicDateId1",
                table: "BasicModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BasicModels_BasicDateId1",
                table: "BasicModels",
                column: "BasicDateId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BasicModels_BasicDates_BasicDateId1",
                table: "BasicModels",
                column: "BasicDateId1",
                principalTable: "BasicDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasicModels_TargetOuterDiameters_BasicDateId",
                table: "BasicModels",
                column: "BasicDateId",
                principalTable: "TargetOuterDiameters",
                principalColumn: "Id");
        }
    }
}
