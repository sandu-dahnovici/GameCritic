using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameCritic.Infrastructure.Persistance.Migrations
{
    public partial class AddedPlaytimePropertyToGamesAndDescriptionToGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Genres",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Playtime",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "Playtime",
                table: "Games");
        }
    }
}
