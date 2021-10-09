﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Taller_Mecanico.API.Migrations
{
    public partial class AddTablaTipoVehiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoVehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVehiculos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoVehiculos_Descripcion",
                table: "TipoVehiculos",
                column: "Descripcion",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoVehiculos");
        }
    }
}
