using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_DEMO.Migrations
{
    /// <inheritdoc />
    public partial class Address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSuppliers_Suppliers_SuppliersId",
                table: "ProductSuppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Supplier");

            migrationBuilder.AddColumn<string>(
                name: "Address_Area",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "SuppliersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSuppliers_Supplier_SuppliersId",
                table: "ProductSuppliers",
                column: "SuppliersId",
                principalTable: "Supplier",
                principalColumn: "SuppliersId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSuppliers_Supplier_SuppliersId",
                table: "ProductSuppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Address_Area",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Supplier");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "Suppliers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "SuppliersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSuppliers_Suppliers_SuppliersId",
                table: "ProductSuppliers",
                column: "SuppliersId",
                principalTable: "Suppliers",
                principalColumn: "SuppliersId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
