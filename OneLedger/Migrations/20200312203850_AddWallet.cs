using Microsoft.EntityFrameworkCore.Migrations;

namespace OneLedger.Migrations
{
    public partial class AddWallet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumOnHand",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cash = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropColumn(
                name: "NumOnHand",
                table: "Product");
        }
    }
}
