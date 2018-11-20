using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class foreign_key_race_character : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_character_id_race",
                table: "character",
                column: "id_race");

            migrationBuilder.AddForeignKey(
                name: "FK_character_race_id_race",
                table: "character",
                column: "id_race",
                principalTable: "race",
                principalColumn: "id_race",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_character_race_id_race",
                table: "character");

            migrationBuilder.DropIndex(
                name: "IX_character_id_race",
                table: "character");
        }
    }
}
