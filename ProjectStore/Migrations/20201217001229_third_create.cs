using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectStore.Migrations
{
    public partial class third_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Certifications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Prix",
                table: "Certifications",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Certifications");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "Certifications");
        }
    }
}
