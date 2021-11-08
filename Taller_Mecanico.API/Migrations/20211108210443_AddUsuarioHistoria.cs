using Microsoft.EntityFrameworkCore.Migrations;

namespace Taller_Mecanico.API.Migrations
{
    public partial class AddUsuarioHistoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "foto",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Historiales",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_UsuarioId",
                table: "Historiales",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Historiales_AspNetUsers_UsuarioId",
                table: "Historiales",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historiales_AspNetUsers_UsuarioId",
                table: "Historiales");

            migrationBuilder.DropIndex(
                name: "IX_Historiales_UsuarioId",
                table: "Historiales");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Historiales");

            migrationBuilder.AddColumn<string>(
                name: "foto",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
