using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class add_columns_character_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "armor_class",
                table: "character",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "experience_points",
                table: "character",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_race",
                table: "character",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "initiative",
                table: "character",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "max_hit_points",
                table: "character",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "player_name",
                table: "character",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "proficiency_bonus",
                table: "character",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "speed",
                table: "character",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "armor_class",
                table: "character");

            migrationBuilder.DropColumn(
                name: "experience_points",
                table: "character");

            migrationBuilder.DropColumn(
                name: "id_race",
                table: "character");

            migrationBuilder.DropColumn(
                name: "initiative",
                table: "character");

            migrationBuilder.DropColumn(
                name: "max_hit_points",
                table: "character");

            migrationBuilder.DropColumn(
                name: "player_name",
                table: "character");

            migrationBuilder.DropColumn(
                name: "proficiency_bonus",
                table: "character");

            migrationBuilder.DropColumn(
                name: "speed",
                table: "character");
        }
    }
}
