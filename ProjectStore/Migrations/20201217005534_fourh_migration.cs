using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectStore.Migrations
{
    public partial class fourh_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prix",
                table: "Certifications");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Certifications",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Certifications");

            migrationBuilder.AddColumn<int>(
                name: "Prix",
                table: "Certifications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
