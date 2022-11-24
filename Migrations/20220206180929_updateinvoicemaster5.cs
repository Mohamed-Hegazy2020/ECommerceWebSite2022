using Microsoft.EntityFrameworkCore.Migrations;

namespace MyECommerceWebSite2022.Migrations
{
    public partial class updateinvoicemaster5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "invDate",
                table: "InvoiceMaster",
                newName: "invoiceDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "invoiceDate",
                table: "InvoiceMaster",
                newName: "invDate");
        }
    }
}
