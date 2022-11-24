using Microsoft.EntityFrameworkCore.Migrations;

namespace MyECommerceWebSite2022.Migrations
{
    public partial class addisDefualtCuruncy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDefualtCuruncy",
                table: "Curunces",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDefualtCuruncy",
                table: "Curunces");
        }
    }
}
