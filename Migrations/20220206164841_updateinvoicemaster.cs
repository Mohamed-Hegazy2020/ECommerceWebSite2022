using Microsoft.EntityFrameworkCore.Migrations;

namespace MyECommerceWebSite2022.Migrations
{
    public partial class updateinvoicemaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "InvoiceMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentURL",
                table: "InvoiceMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "paymentMethod",
                table: "InvoiceMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "InvoiceMaster");

            migrationBuilder.DropColumn(
                name: "PaymentURL",
                table: "InvoiceMaster");

            migrationBuilder.DropColumn(
                name: "paymentMethod",
                table: "InvoiceMaster");
        }
    }
}
