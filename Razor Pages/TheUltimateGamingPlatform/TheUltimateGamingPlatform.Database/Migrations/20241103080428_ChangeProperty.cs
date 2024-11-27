using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheUltimateGamingPlatform.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_SystemRequirements_MinimumSystemRequirementId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "MinimumSystemRequirementId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_SystemRequirements_MinimumSystemRequirementId",
                table: "Games",
                column: "MinimumSystemRequirementId",
                principalTable: "SystemRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_SystemRequirements_MinimumSystemRequirementId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "MinimumSystemRequirementId",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_SystemRequirements_MinimumSystemRequirementId",
                table: "Games",
                column: "MinimumSystemRequirementId",
                principalTable: "SystemRequirements",
                principalColumn: "Id");
        }
    }
}
