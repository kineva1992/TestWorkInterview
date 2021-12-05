using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VswTask.Migrations
{
    public partial class new12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicModels_TargetOuterDiameters_TargetDiameterId",
                table: "BasicModels");

            migrationBuilder.DropIndex(
                name: "IX_BasicModels_TargetDiameterId",
                table: "BasicModels");

            migrationBuilder.AddColumn<int>(
                name: "TargetOuterDiameterId",
                table: "BasicModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BasicModels_TargetOuterDiameterId",
                table: "BasicModels",
                column: "TargetOuterDiameterId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasicModels_TargetOuterDiameters_TargetOuterDiameterId",
                table: "BasicModels",
                column: "TargetOuterDiameterId",
                principalTable: "TargetOuterDiameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicModels_TargetOuterDiameters_TargetOuterDiameterId",
                table: "BasicModels");

            migrationBuilder.DropIndex(
                name: "IX_BasicModels_TargetOuterDiameterId",
                table: "BasicModels");

            migrationBuilder.DropColumn(
                name: "TargetOuterDiameterId",
                table: "BasicModels");

            migrationBuilder.CreateIndex(
                name: "IX_BasicModels_TargetDiameterId",
                table: "BasicModels",
                column: "TargetDiameterId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasicModels_TargetOuterDiameters_TargetDiameterId",
                table: "BasicModels",
                column: "TargetDiameterId",
                principalTable: "TargetOuterDiameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
