using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VswTask.Migrations
{
    public partial class newMigrationsLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicModels_TargetOuterDiameters_TargetDiameterId",
                table: "BasicModels");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "BasicModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                name: "FK_BasicModels_TargetOuterDiameters_TargetDiameterId",
                table: "BasicModels");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "BasicModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
