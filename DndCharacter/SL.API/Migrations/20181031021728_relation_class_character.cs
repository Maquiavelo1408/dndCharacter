using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class relation_class_character : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_character_id_class",
                table: "character",
                column: "id_class");

            migrationBuilder.AddForeignKey(
                name: "FK_character_class_id_class",
                table: "character",
                column: "id_class",
                principalTable: "class",
                principalColumn: "id_class",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_character_class_id_class",
                table: "character");

            migrationBuilder.DropIndex(
                name: "IX_character_id_class",
                table: "character");
        }
    }
}
