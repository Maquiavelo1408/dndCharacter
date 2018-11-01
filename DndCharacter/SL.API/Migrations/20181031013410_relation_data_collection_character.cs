using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class relation_data_collection_character : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_c_class",
                table: "character",
                newName: "id_class");

            migrationBuilder.CreateIndex(
                name: "IX_character_id_c_aligment",
                table: "character",
                column: "id_c_aligment");

            migrationBuilder.AddForeignKey(
                name: "FK_character_data_collection_id_c_aligment",
                table: "character",
                column: "id_c_aligment",
                principalTable: "data_collection",
                principalColumn: "id_data_collection",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_character_data_collection_id_c_aligment",
                table: "character");

            migrationBuilder.DropIndex(
                name: "IX_character_id_c_aligment",
                table: "character");

            migrationBuilder.RenameColumn(
                name: "id_class",
                table: "character",
                newName: "id_c_class");
        }
    }
}
