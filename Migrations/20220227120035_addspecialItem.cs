using Microsoft.EntityFrameworkCore.Migrations;

namespace MyECommerceWebSite2022.Migrations
{
    public partial class addspecialItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "specialItem",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "specialItem",
                table: "Items");
        }
    }
}
