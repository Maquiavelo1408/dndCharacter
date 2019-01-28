using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class rename_table_feature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feat_feature");

            migrationBuilder.CreateTable(
                name: "feature",
                columns: table => new
                {
                    id_feat_feature = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_feat = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    id_c_type_feat = table.Column<int>(nullable: false),
                    added_amount = table.Column<int>(nullable: false),
                    added_description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feature", x => x.id_feat_feature);
                    table.ForeignKey(
                        name: "FK_feature_data_collection_id_c_type_feat",
                        column: x => x.id_c_type_feat,
                        principalTable: "data_collection",
                        principalColumn: "id_data_collection",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feature_feat_id_feat",
                        column: x => x.id_feat,
                        principalTable: "feat",
                        principalColumn: "id_feat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_feature_id_c_type_feat",
                table: "feature",
                column: "id_c_type_feat");

            migrationBuilder.CreateIndex(
                name: "IX_feature_id_feat",
                table: "feature",
                column: "id_feat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feature");

            migrationBuilder.CreateTable(
                name: "feat_feature",
                columns: table => new
                {
                    id_feat_feature = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    added_amount = table.Column<int>(nullable: false),
                    added_description = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    id_c_type_feat = table.Column<int>(nullable: false),
                    id_feat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feat_feature", x => x.id_feat_feature);
                    table.ForeignKey(
                        name: "FK_feat_feature_data_collection_id_c_type_feat",
                        column: x => x.id_c_type_feat,
                        principalTable: "data_collection",
                        principalColumn: "id_data_collection",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feat_feature_feat_id_feat",
                        column: x => x.id_feat,
                        principalTable: "feat",
                        principalColumn: "id_feat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_feat_feature_id_c_type_feat",
                table: "feat_feature",
                column: "id_c_type_feat");

            migrationBuilder.CreateIndex(
                name: "IX_feat_feature_id_feat",
                table: "feat_feature",
                column: "id_feat");
        }
    }
}
