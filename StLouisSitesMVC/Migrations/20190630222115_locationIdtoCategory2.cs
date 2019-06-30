using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisSitesMVC.Migrations
{
    public partial class locationIdtoCategory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Categories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Categories");
        }
    }
}
