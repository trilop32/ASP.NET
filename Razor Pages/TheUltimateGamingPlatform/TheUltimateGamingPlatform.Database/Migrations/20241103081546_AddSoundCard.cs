using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheUltimateGamingPlatform.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSoundCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SoundCard",
                table: "SystemRequirements",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoundCard",
                table: "SystemRequirements");
        }
    }
}
