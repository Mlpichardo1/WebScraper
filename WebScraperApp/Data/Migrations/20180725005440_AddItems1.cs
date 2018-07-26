using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraperApp.Data.Migrations
{
    public partial class AddItems1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Change",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CostBasis",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shares",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Change",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CostBasis",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Shares",
                table: "Items");
        }
    }
}
