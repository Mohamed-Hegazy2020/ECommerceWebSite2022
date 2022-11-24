using Microsoft.EntityFrameworkCore.Migrations;

namespace MyECommerceWebSite2022.Migrations
{
    public partial class createInvoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CompanyNameAr",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invNo = table.Column<int>(type: "int", nullable: false),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsViewed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyNameAr",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
