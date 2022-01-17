using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NttDataSupplier.Infra.Migrations
{
    public partial class Two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "SupplierId",
                table: "TB_Product",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "SupplierId",
                table: "TB_Product",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));
        }
    }
}
