using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eternal.Data.Migrations
{
    public partial class AlterTableClientAddFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Neighborhood",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Clients");
        }
    }
}
