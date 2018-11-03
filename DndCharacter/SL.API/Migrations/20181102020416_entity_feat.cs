using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class entity_feat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "feat",
                columns: table => new
                {
                    id_feat = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    prerequisite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feat", x => x.id_feat);
                });

            migrationBuilder.CreateTable(
                name: "character_feat",
                columns: table => new
                {
                    id_character = table.Column<int>(nullable: false),
                    id_feat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character_feat", x => new { x.id_character, x.id_feat });
                    table.ForeignKey(
                        name: "FK_character_feat_character_id_character",
                        column: x => x.id_character,
                        principalTable: "character",
                        principalColumn: "id_character",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_character_feat_feat_id_feat",
                        column: x => x.id_feat,
                        principalTable: "feat",
                        principalColumn: "id_feat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feat_feature",
                columns: table => new
                {
                    id_feat_feature = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_feat = table.Column<int>(nullable: false),
                    id_c_type_feat = table.Column<int>(nullable: false),
                    added_amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feat_feature", x => x.id_feat_feature);
                    table.ForeignKey(
                        name: "FK_feat_feature_feat_id_feat",
                        column: x => x.id_feat,
                        principalTable: "feat",
                        principalColumn: "id_feat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_spell_class_id_c_class",
                table: "spell_class",
                column: "id_c_class");

            migrationBuilder.CreateIndex(
                name: "IX_character_feat_id_feat",
                table: "character_feat",
                column: "id_feat");

            migrationBuilder.CreateIndex(
                name: "IX_feat_feature_id_feat",
                table: "feat_feature",
                column: "id_feat");

            migrationBuilder.AddForeignKey(
                name: "FK_spell_class_class_id_c_class",
                table: "spell_class",
                column: "id_c_class",
                principalTable: "class",
                principalColumn: "id_class",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spell_class_spell_id_spell",
                table: "spell_class",
                column: "id_spell",
                principalTable: "spell",
                principalColumn: "id_spell",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_spell_class_class_id_c_class",
                table: "spell_class");

            migrationBuilder.DropForeignKey(
                name: "FK_spell_class_spell_id_spell",
                table: "spell_class");

            migrationBuilder.DropTable(
                name: "character_feat");

            migrationBuilder.DropTable(
                name: "feat_feature");

            migrationBuilder.DropTable(
                name: "feat");

            migrationBuilder.DropIndex(
                name: "IX_spell_class_id_c_class",
                table: "spell_class");
        }
    }
}
