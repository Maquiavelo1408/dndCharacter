using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class added_columns_feat_feature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "added_description",
                table: "feat_feature",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "feat_feature",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "added_description",
                table: "feat_feature");

            migrationBuilder.DropColumn(
                name: "description",
                table: "feat_feature");
        }
    }
}
