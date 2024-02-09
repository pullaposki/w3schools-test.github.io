using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipRates_Companies_CompanyId",
                table: "ShipRates");

            migrationBuilder.DropIndex(
                name: "IX_ShipRates_CompanyId",
                table: "ShipRates");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "ShipRates");

            migrationBuilder.DropColumn(
                name: "PriceCategoryName",
                table: "PriceCategories");

            migrationBuilder.AddColumn<int>(
                name: "ShipRateId",
                table: "PriceCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PriceCategories_ShipRateId",
                table: "PriceCategories",
                column: "ShipRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceCategories_ShipRates_ShipRateId",
                table: "PriceCategories",
                column: "ShipRateId",
                principalTable: "ShipRates",
                principalColumn: "ShipRateId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceCategories_ShipRates_ShipRateId",
                table: "PriceCategories");

            migrationBuilder.DropIndex(
                name: "IX_PriceCategories_ShipRateId",
                table: "PriceCategories");

            migrationBuilder.DropColumn(
                name: "ShipRateId",
                table: "PriceCategories");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "ShipRates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceCategoryName",
                table: "PriceCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ShipRates_CompanyId",
                table: "ShipRates",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipRates_Companies_CompanyId",
                table: "ShipRates",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId");
        }
    }
}
