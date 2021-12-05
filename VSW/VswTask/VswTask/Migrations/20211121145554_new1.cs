using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VswTask.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TargetOuterDiameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TargetOuterDiameters = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetOuterDiameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasicModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberTube = table.Column<int>(type: "int", nullable: false),
                    MeasuredDiameter1 = table.Column<double>(type: "float", nullable: false),
                    MeasuredDiameter2 = table.Column<double>(type: "float", nullable: false),
                    MeasuredDiameter3 = table.Column<double>(type: "float", nullable: false),
                    MaxDeviation = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetDiameterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasicModels_TargetOuterDiameters_TargetDiameterId",
                        column: x => x.TargetDiameterId,
                        principalTable: "TargetOuterDiameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasicModels_TargetDiameterId",
                table: "BasicModels",
                column: "TargetDiameterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasicModels");

            migrationBuilder.DropTable(
                name: "TargetOuterDiameters");
        }
    }
}
