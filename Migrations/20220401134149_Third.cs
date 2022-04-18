using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MerchantsApi.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Merchants_merchantCode",
                table: "Stores");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Merchants_merchantCode",
                table: "Stores",
                column: "merchantCode",
                principalTable: "Merchants",
                principalColumn: "merchantCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Merchants_merchantCode",
                table: "Stores");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Merchants_merchantCode",
                table: "Stores",
                column: "merchantCode",
                principalTable: "Merchants",
                principalColumn: "merchantCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
