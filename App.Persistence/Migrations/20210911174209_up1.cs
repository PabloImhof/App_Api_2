using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Persistence.Migrations
{
    public partial class up1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pessoa_cidade_pes_cidadeId",
                table: "pessoa");

            migrationBuilder.RenameColumn(
                name: "pes_cidadeId",
                table: "pessoa",
                newName: "CidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_pessoa_pes_cidadeId",
                table: "pessoa",
                newName: "IX_pessoa_CidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_pessoa_cidade_CidadeId",
                table: "pessoa",
                column: "CidadeId",
                principalTable: "cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pessoa_cidade_CidadeId",
                table: "pessoa");

            migrationBuilder.RenameColumn(
                name: "CidadeId",
                table: "pessoa",
                newName: "pes_cidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_pessoa_CidadeId",
                table: "pessoa",
                newName: "IX_pessoa_pes_cidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_pessoa_cidade_pes_cidadeId",
                table: "pessoa",
                column: "pes_cidadeId",
                principalTable: "cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
