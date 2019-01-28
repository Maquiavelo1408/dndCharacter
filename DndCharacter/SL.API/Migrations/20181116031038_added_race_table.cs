using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class added_race_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<bool>(
                name: "trait",
                table: "feat",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "race",
                columns: table => new
                {
                    id_race = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    age = table.Column<string>(nullable: true),
                    size = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_race", x => x.id_race);
                });


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_equipment_data_collection_id_c_type_equipment",
                table: "equipment");

            migrationBuilder.DropTable(
                name: "race");

            migrationBuilder.DropIndex(
                name: "IX_equipment_id_c_type_equipment",
                table: "equipment");

            migrationBuilder.DropColumn(
                name: "trait",
                table: "feat");

            migrationBuilder.AddColumn<int>(
                name: "IdCTypeEquipment",
                table: "equipment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_equipment_IdCTypeEquipment",
                table: "equipment",
                column: "IdCTypeEquipment");

            migrationBuilder.AddForeignKey(
                name: "FK_equipment_data_collection_IdCTypeEquipment",
                table: "equipment",
                column: "IdCTypeEquipment",
                principalTable: "data_collection",
                principalColumn: "id_data_collection",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
