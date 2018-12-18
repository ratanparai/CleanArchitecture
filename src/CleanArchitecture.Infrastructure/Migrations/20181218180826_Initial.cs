using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cleanarchitecuture");

            migrationBuilder.CreateSequence(
                name: "orderitemseq",
                schema: "cleanarchitecuture",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "orderseq",
                schema: "cleanarchitecuture",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "order",
                schema: "cleanarchitecuture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_State = table.Column<string>(nullable: true),
                    Address_Country = table.Column<string>(nullable: true),
                    Address_ZipCode = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orderItems",
                schema: "cleanarchitecuture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: true),
                    ProductName = table.Column<string>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Units = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderItems_order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "cleanarchitecuture",
                        principalTable: "order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_OrderId",
                schema: "cleanarchitecuture",
                table: "orderItems",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderItems",
                schema: "cleanarchitecuture");

            migrationBuilder.DropTable(
                name: "order",
                schema: "cleanarchitecuture");

            migrationBuilder.DropSequence(
                name: "orderitemseq",
                schema: "cleanarchitecuture");

            migrationBuilder.DropSequence(
                name: "orderseq",
                schema: "cleanarchitecuture");
        }
    }
}
