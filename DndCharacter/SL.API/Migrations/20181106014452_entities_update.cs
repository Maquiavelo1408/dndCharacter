using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class entities_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ability_score",
                table: "ability_score");

            migrationBuilder.DropIndex(
                name: "IX_ability_score_id_character",
                table: "ability_score");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "equipment",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ability_score_id_character",
                table: "ability_score",
                column: "id_character");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ability_score",
                table: "ability_score",
                columns: new[] { "id_character", "id_c_ability_score" });

            migrationBuilder.CreateIndex(
                name: "IX_skill_id_c_ability_score",
                table: "skill",
                column: "id_c_ability_score");

            migrationBuilder.CreateIndex(
                name: "IX_feat_feature_id_c_type_feat",
                table: "feat_feature",
                column: "id_c_type_feat");

            migrationBuilder.CreateIndex(
                name: "IX_equipment_id_c_type_equipment",
                table: "equipment",
                column: "id_c_type_equipment");

            migrationBuilder.AddForeignKey(
                name: "FK_equipment_data_collection_id_c_type_equipment",
                table: "equipment",
                column: "id_c_type_equipment",
                principalTable: "data_collection",
                principalColumn: "id_data_collection",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_feat_feature_data_collection_id_c_type_feat",
                table: "feat_feature",
                column: "id_c_type_feat",
                principalTable: "data_collection",
                principalColumn: "id_data_collection",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_skill_data_collection_id_c_ability_score",
                table: "skill",
                column: "id_c_ability_score",
                principalTable: "data_collection",
                principalColumn: "id_data_collection",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_equipment_data_collection_IdCTypeEquipment",
                table: "equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_feat_feature_data_collection_id_c_type_feat",
                table: "feat_feature");

            migrationBuilder.DropForeignKey(
                name: "FK_skill_data_collection_id_c_ability_score",
                table: "skill");

            migrationBuilder.DropIndex(
                name: "IX_skill_id_c_ability_score",
                table: "skill");

            migrationBuilder.DropIndex(
                name: "IX_feat_feature_id_c_type_feat",
                table: "feat_feature");

            migrationBuilder.DropIndex(
                name: "IX_equipment_IdCTypeEquipment",
                table: "equipment");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ability_score_id_character",
                table: "ability_score");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ability_score",
                table: "ability_score");

            migrationBuilder.DropColumn(
                name: "IdCTypeEquipment",
                table: "equipment");

            migrationBuilder.DropColumn(
                name: "name",
                table: "equipment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ability_score",
                table: "ability_score",
                columns: new[] { "id_c_ability_score", "id_character" });

            migrationBuilder.CreateIndex(
                name: "IX_ability_score_id_character",
                table: "ability_score",
                column: "id_character");
        }
    }
}
