using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class relation_collection_data_collection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_data_collection_id_collection",
                table: "data_collection",
                column: "id_collection");

            migrationBuilder.AddForeignKey(
                name: "FK_data_collection_collection_id_collection",
                table: "data_collection",
                column: "id_collection",
                principalTable: "collection",
                principalColumn: "id_collection",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_data_collection_collection_id_collection",
                table: "data_collection");

            migrationBuilder.DropIndex(
                name: "IX_data_collection_id_collection",
                table: "data_collection");
        }
    }
}
