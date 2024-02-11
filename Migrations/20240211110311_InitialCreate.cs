using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShipRates",
                columns: table => new
                {
                    ShipRatesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PerCubicMeter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PerKm = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipRates", x => x.ShipRatesId);
                });

            migrationBuilder.CreateTable(
                name: "PriceCategories",
                columns: table => new
                {
                    PriceCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipRatesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceCategories", x => x.PriceCategoryId);
                    table.ForeignKey(
                        name: "FK_PriceCategories_ShipRates_ShipRatesId",
                        column: x => x.ShipRatesId,
                        principalTable: "ShipRates",
                        principalColumn: "ShipRatesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_PriceCategories_PriceCategoryId",
                        column: x => x.PriceCategoryId,
                        principalTable: "PriceCategories",
                        principalColumn: "PriceCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_PriceCategoryId",
                table: "Companies",
                column: "PriceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceCategories_ShipRatesId",
                table: "PriceCategories",
                column: "ShipRatesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "PriceCategories");

            migrationBuilder.DropTable(
                name: "ShipRates");
        }
    }
}
