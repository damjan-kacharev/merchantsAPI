using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MerchantsApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    merchantCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    displayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.merchantCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Merchants");
        }
    }
}
