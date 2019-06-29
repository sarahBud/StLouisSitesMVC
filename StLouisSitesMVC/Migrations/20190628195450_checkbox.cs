using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisSitesMVC.Migrations
{
    public partial class checkbox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CheckboxAnswer",
                table: "Categories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckboxAnswer",
                table: "Categories");
        }
    }
}
