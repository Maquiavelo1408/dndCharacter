using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class id_race_feat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "trait",
                table: "feat");

            migrationBuilder.AddColumn<int>(
                name: "id_race",
                table: "feat",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_feat_id_race",
                table: "feat",
                column: "id_race");

            migrationBuilder.AddForeignKey(
                name: "FK_feat_race_id_race",
                table: "feat",
                column: "id_race",
                principalTable: "race",
                principalColumn: "id_race",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feat_race_id_race",
                table: "feat");

            migrationBuilder.DropIndex(
                name: "IX_feat_id_race",
                table: "feat");

            migrationBuilder.DropColumn(
                name: "id_race",
                table: "feat");

            migrationBuilder.AddColumn<bool>(
                name: "trait",
                table: "feat",
                nullable: false,
                defaultValue: false);
        }
    }
}
