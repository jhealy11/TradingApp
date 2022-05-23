using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trading.App.Repository.Migrations
{
    public partial class NewCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total2",
                table: "Trade");

            migrationBuilder.AddColumn<int>(
                name: "TradeTypeId",
                table: "Trade",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trade_TradeTypeId",
                table: "Trade",
                column: "TradeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_TradeType_TradeTypeId",
                table: "Trade",
                column: "TradeTypeId",
                principalTable: "TradeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trade_TradeType_TradeTypeId",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Trade_TradeTypeId",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "TradeTypeId",
                table: "Trade");

            migrationBuilder.AddColumn<decimal>(
                name: "Total2",
                table: "Trade",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
