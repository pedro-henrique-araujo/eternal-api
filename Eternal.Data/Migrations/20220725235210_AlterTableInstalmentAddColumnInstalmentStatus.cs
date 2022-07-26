using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eternal.Data.Migrations
{
    public partial class AlterTableInstalmentAddColumnInstalmentStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstalmentStatus",
                table: "Instalments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstalmentStatus",
                table: "Instalments");
        }
    }
}
