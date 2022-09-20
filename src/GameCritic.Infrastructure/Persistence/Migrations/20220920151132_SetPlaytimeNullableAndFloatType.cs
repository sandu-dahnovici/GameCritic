using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameCritic.Infrastructure.Persistence.Migrations
{
    public partial class SetPlaytimeNullableAndFloatType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Playtime",
                table: "Games",
                type: "float(2)",
                precision: 2,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Playtime",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "float(2)",
                oldPrecision: 2,
                oldNullable: true);
        }
    }
}
