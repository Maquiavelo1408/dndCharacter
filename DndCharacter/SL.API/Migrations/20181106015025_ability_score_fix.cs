using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class ability_score_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ability_score_id_character",
                table: "ability_score");

            migrationBuilder.CreateIndex(
                name: "IX_ability_score_id_c_ability_score",
                table: "ability_score",
                column: "id_c_ability_score");

            migrationBuilder.AddForeignKey(
                name: "FK_ability_score_data_collection_id_c_ability_score",
                table: "ability_score",
                column: "id_c_ability_score",
                principalTable: "data_collection",
                principalColumn: "id_data_collection",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ability_score_data_collection_id_c_ability_score",
                table: "ability_score");

            migrationBuilder.DropIndex(
                name: "IX_ability_score_id_c_ability_score",
                table: "ability_score");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ability_score_id_character",
                table: "ability_score",
                column: "id_character");
        }
    }
}
