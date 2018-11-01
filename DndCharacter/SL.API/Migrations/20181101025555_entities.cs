using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "copper_coins",
                table: "character",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "electrum_coins",
                table: "character",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "gold_coins",
                table: "character",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "silver_coins",
                table: "character",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ability_score",
                columns: table => new
                {
                    id_character = table.Column<int>(nullable: false),
                    id_c_ability_score = table.Column<int>(nullable: false),
                    value = table.Column<int>(nullable: false),
                    proficient = table.Column<bool>(nullable: false),
                    ability_modifier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ability_score", x => new { x.id_c_ability_score, x.id_character });
                    table.ForeignKey(
                        name: "FK_ability_score_character_id_character",
                        column: x => x.id_character,
                        principalTable: "character",
                        principalColumn: "id_character",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "equipment",
                columns: table => new
                {
                    id_equipment = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_c_type_equipment = table.Column<int>(nullable: false),
                    cost = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment", x => x.id_equipment);
                });

            migrationBuilder.CreateTable(
                name: "skill",
                columns: table => new
                {
                    id_skill = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    id_c_ability_score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skill", x => x.id_skill);
                });

            migrationBuilder.CreateTable(
                name: "character_equipment",
                columns: table => new
                {
                    id_character = table.Column<int>(nullable: false),
                    id_equipment = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character_equipment", x => new { x.id_character, x.id_equipment });
                    table.ForeignKey(
                        name: "FK_character_equipment_character_id_character",
                        column: x => x.id_character,
                        principalTable: "character",
                        principalColumn: "id_character",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_character_equipment_equipment_id_equipment",
                        column: x => x.id_equipment,
                        principalTable: "equipment",
                        principalColumn: "id_equipment",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "character_skill",
                columns: table => new
                {
                    id_character = table.Column<int>(nullable: false),
                    id_skill = table.Column<int>(nullable: false),
                    value = table.Column<int>(nullable: false),
                    proficient = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character_skill", x => new { x.id_character, x.id_skill });
                    table.ForeignKey(
                        name: "FK_character_skill_character_id_character",
                        column: x => x.id_character,
                        principalTable: "character",
                        principalColumn: "id_character",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_character_skill_skill_id_skill",
                        column: x => x.id_skill,
                        principalTable: "skill",
                        principalColumn: "id_skill",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ability_score_id_character",
                table: "ability_score",
                column: "id_character");

            migrationBuilder.CreateIndex(
                name: "IX_character_equipment_id_equipment",
                table: "character_equipment",
                column: "id_equipment");

            migrationBuilder.CreateIndex(
                name: "IX_character_skill_id_skill",
                table: "character_skill",
                column: "id_skill");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ability_score");

            migrationBuilder.DropTable(
                name: "character_equipment");

            migrationBuilder.DropTable(
                name: "character_skill");

            migrationBuilder.DropTable(
                name: "equipment");

            migrationBuilder.DropTable(
                name: "skill");

            migrationBuilder.DropColumn(
                name: "copper_coins",
                table: "character");

            migrationBuilder.DropColumn(
                name: "electrum_coins",
                table: "character");

            migrationBuilder.DropColumn(
                name: "gold_coins",
                table: "character");

            migrationBuilder.DropColumn(
                name: "silver_coins",
                table: "character");
        }
    }
}
