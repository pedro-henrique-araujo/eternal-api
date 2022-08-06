using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eternal.Data.Migrations
{
    public partial class AlterTableDependentAddFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depdendents_Clients_ClientId",
                table: "Depdendents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Depdendents",
                table: "Depdendents");

            migrationBuilder.RenameTable(
                name: "Depdendents",
                newName: "Dependents");

            migrationBuilder.RenameIndex(
                name: "IX_Depdendents_ClientId",
                table: "Dependents",
                newName: "IX_Dependents_ClientId");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Dependents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Dependents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "Dependents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dependents",
                table: "Dependents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependents_Clients_ClientId",
                table: "Dependents",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependents_Clients_ClientId",
                table: "Dependents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dependents",
                table: "Dependents");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Dependents");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Dependents");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "Dependents");

            migrationBuilder.RenameTable(
                name: "Dependents",
                newName: "Depdendents");

            migrationBuilder.RenameIndex(
                name: "IX_Dependents_ClientId",
                table: "Depdendents",
                newName: "IX_Depdendents_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Depdendents",
                table: "Depdendents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Depdendents_Clients_ClientId",
                table: "Depdendents",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
