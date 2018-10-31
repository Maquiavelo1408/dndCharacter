using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class create_tables_spells : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "character_spell",
                columns: table => new
                {
                    id_character = table.Column<int>(nullable: false),
                    id_spell = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character_spell", x => new { x.id_character, x.id_spell });
                });

            migrationBuilder.CreateTable(
                name: "spell",
                columns: table => new
                {
                    id_spell = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    level = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spell", x => x.id_spell);
                });

            migrationBuilder.CreateTable(
                name: "spell_class",
                columns: table => new
                {
                    id_spell = table.Column<int>(nullable: false),
                    id_c_class = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spell_class", x => new { x.id_spell, x.id_c_class });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "character_spell");

            migrationBuilder.DropTable(
                name: "spell");

            migrationBuilder.DropTable(
                name: "spell_class");
        }
    }
}
