using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneLedger.Migrations
{
    public partial class AddTrans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Time = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalCharge = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ProductId",
                table: "Transaction",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");
        }
    }
}
