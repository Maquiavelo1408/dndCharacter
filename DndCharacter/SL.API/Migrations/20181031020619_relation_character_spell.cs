using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class relation_character_spell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_character_spell_id_spell",
                table: "character_spell",
                column: "id_spell");

            migrationBuilder.AddForeignKey(
                name: "FK_character_spell_character_id_character",
                table: "character_spell",
                column: "id_character",
                principalTable: "character",
                principalColumn: "id_character",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_character_spell_spell_id_spell",
                table: "character_spell",
                column: "id_spell",
                principalTable: "spell",
                principalColumn: "id_spell",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_character_spell_character_id_character",
                table: "character_spell");

            migrationBuilder.DropForeignKey(
                name: "FK_character_spell_spell_id_spell",
                table: "character_spell");

            migrationBuilder.DropIndex(
                name: "IX_character_spell_id_spell",
                table: "character_spell");
        }
    }
}
