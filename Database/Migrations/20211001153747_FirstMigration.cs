using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Region = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    Channel = table.Column<string>(nullable: true),
                    OrderPriority = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderId = table.Column<string>(nullable: true),
                    ShipDate = table.Column<DateTime>(nullable: false),
                    UnitsSold = table.Column<int>(nullable: false),
                    UnitCost = table.Column<decimal>(nullable: false),
                    TotalRevenue = table.Column<decimal>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false),
                    TotalProfit = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
