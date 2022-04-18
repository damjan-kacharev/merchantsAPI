using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MerchantsApi.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    storeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    displayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    merchantCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.storeCode);
                    table.ForeignKey(
                        name: "FK_Stores_Merchants_merchantCode",
                        column: x => x.merchantCode,
                        principalTable: "Merchants",
                        principalColumn: "merchantCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_merchantCode",
                table: "Stores",
                column: "merchantCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
