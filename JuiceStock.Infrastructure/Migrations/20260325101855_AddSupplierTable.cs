using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuiceStock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSupplierTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "LedgerEntry",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LedgerEntry_SupplierId",
                table: "LedgerEntry",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerEntry_Suppliers_SupplierId",
                table: "LedgerEntry",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LedgerEntry_Suppliers_SupplierId",
                table: "LedgerEntry");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_LedgerEntry_SupplierId",
                table: "LedgerEntry");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "LedgerEntry");
        }
    }
}
