using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hoopstatsapi.Migrations
{
    /// <inheritdoc />
    public partial class TeamStatsIdRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamStatsId",
                table: "Teams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamStatsId",
                table: "Teams",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
