using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisSitesMVC.Migrations
{
    public partial class locationinreview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Locations_LocationId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Reviews",
                newName: "LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_LocationId",
                table: "Reviews",
                newName: "IX_Reviews_LocationID");

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Locations_LocationID",
                table: "Reviews",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Locations_LocationID",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Reviews",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_LocationID",
                table: "Reviews",
                newName: "IX_Reviews_LocationId");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Locations_LocationId",
                table: "Reviews",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
