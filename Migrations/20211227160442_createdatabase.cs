using Microsoft.EntityFrameworkCore.Migrations;

namespace MyECommerceWebSite2022.Migrations
{
    public partial class createdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyDatas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyNameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaceBookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstgramLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDatas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Curunces",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuruncyNameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuruncyNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curunces", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupNameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemNameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemDescreptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemDescreptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    groupId = table.Column<int>(type: "int", nullable: false),
                    unitId = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    itemImgFile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitNameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyDatas");

            migrationBuilder.DropTable(
                name: "Curunces");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
