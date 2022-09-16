using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesLayer.Migrations
{
    public partial class PortfolioImageUpdateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Portfolios",
                newName: "SmallImageURL");

            migrationBuilder.AddColumn<string>(
                name: "BigImageURL",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BigImageURL",
                table: "Portfolios");

            migrationBuilder.RenameColumn(
                name: "SmallImageURL",
                table: "Portfolios",
                newName: "ImageURL");
        }
    }
}
