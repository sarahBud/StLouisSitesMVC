using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisSitesMVC.Migrations
{
    public partial class county2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Locations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "County",
                table: "Locations");
        }
    }
}
