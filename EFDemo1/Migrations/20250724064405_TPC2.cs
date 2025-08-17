using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDemo1.Migrations
{
    /// <inheritdoc />
    public partial class TPC2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSupplier");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ProductId",
                table: "Suppliers",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Products_ProductId",
                table: "Suppliers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Products_ProductId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_ProductId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Suppliers");

            migrationBuilder.CreateTable(
                name: "ProductSupplier",
                columns: table => new
                {
                    ProductsProductId = table.Column<int>(type: "int", nullable: false),
                    SuppliersPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSupplier", x => new { x.ProductsProductId, x.SuppliersPersonId });
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Suppliers_SuppliersPersonId",
                        column: x => x.SuppliersPersonId,
                        principalTable: "Suppliers",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplier_SuppliersPersonId",
                table: "ProductSupplier",
                column: "SuppliersPersonId");
        }
    }
}
