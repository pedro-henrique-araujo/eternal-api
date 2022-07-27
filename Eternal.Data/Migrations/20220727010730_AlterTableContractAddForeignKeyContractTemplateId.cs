using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eternal.Data.Migrations
{
    public partial class AlterTableContractAddForeignKeyContractTemplateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractTemplateId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractTemplateId",
                table: "Contracts",
                column: "ContractTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_ContractTemplates_ContractTemplateId",
                table: "Contracts",
                column: "ContractTemplateId",
                principalTable: "ContractTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_ContractTemplates_ContractTemplateId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ContractTemplateId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ContractTemplateId",
                table: "Contracts");
        }
    }
}
