using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameShopV3.Migrations
{
    public partial class UpdatingOrderModeladdPurchaseDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "Orders");
        }
    }
}
