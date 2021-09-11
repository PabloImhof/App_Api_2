using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Persistence.Migrations
{
    public partial class upv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "pes_cidadeId",
                table: "pessoa",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_pes_cidadeId",
                table: "pessoa",
                column: "pes_cidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_pessoa_cidade_pes_cidadeId",
                table: "pessoa",
                column: "pes_cidadeId",
                principalTable: "cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pessoa_cidade_pes_cidadeId",
                table: "pessoa");

            migrationBuilder.DropIndex(
                name: "IX_pessoa_pes_cidadeId",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "pes_cidadeId",
                table: "pessoa");
        }
    }
}
