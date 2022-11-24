using Microsoft.EntityFrameworkCore.Migrations;

namespace MyECommerceWebSite2022.Migrations
{
    public partial class addsubGroupId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "subGroupId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "subGroupId",
                table: "Items");
        }
    }
}
