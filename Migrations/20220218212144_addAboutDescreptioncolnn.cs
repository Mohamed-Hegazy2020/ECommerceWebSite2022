using Microsoft.EntityFrameworkCore.Migrations;

namespace MyECommerceWebSite2022.Migrations
{
    public partial class addAboutDescreptioncolnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutDescreptionAr",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutDescreptionEn",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutDescreptionAr",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "AboutDescreptionEn",
                table: "CompanyDatas");
        }
    }
}
