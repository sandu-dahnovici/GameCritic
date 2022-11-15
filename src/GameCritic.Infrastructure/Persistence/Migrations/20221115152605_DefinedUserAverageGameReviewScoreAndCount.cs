using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameCritic.Infrastructure.Persistence.Migrations
{
    public partial class DefinedUserAverageGameReviewScoreAndCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewCount",
                schema: "Auth",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Score",
                schema: "Auth",
                table: "Users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewCount",
                schema: "Auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Score",
                schema: "Auth",
                table: "Users");
        }
    }
}
