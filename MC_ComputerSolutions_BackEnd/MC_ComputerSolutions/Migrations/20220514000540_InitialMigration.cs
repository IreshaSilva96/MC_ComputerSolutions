using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MC_ComputerSolutions.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrossTotal = table.Column<float>(type: "real", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    NetTotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceProducts",
                columns: table => new
                {
                    InvoiceProductsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceProducts", x => x.InvoiceProductsID);
                    table.ForeignKey(
                        name: "FK_InvoiceProducts_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProducts_ProductID",
                table: "InvoiceProducts",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "InvoiceProducts");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
