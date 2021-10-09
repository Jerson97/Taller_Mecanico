using Microsoft.EntityFrameworkCore.Migrations;

namespace Taller_Mecanico.API.Migrations
{
    public partial class AddTableProceduresIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Procedures_Descripcion",
                table: "Procedures",
                column: "Descripcion",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Procedures_Descripcion",
                table: "Procedures");
        }
    }
}
