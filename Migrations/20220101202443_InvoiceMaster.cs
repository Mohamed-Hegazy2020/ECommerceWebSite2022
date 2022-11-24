using Microsoft.EntityFrameworkCore.Migrations;

namespace MyECommerceWebSite2022.Migrations
{
    public partial class InvoiceMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.CreateTable(
                name: "InvoiceDetailes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    masterId = table.Column<int>(type: "int", nullable: false),
                    invNo = table.Column<int>(type: "int", nullable: false),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsViewed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetailes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceMaster",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleverMethod = table.Column<int>(type: "int", nullable: false),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleverd = table.Column<bool>(type: "bit", nullable: false),
                    invDate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceMaster", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetailes");

            migrationBuilder.DropTable(
                name: "InvoiceMaster");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsViewed = table.Column<bool>(type: "bit", nullable: false),
                    customerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    invNo = table.Column<int>(type: "int", nullable: false),
                    itemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.id);
                });
        }
    }
}
