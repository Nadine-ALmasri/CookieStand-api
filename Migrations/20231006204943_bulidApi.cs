using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cookie_stand_api.Migrations
{
    /// <inheritdoc />
    public partial class bulidApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CookieStand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumCustomersPerHour = table.Column<int>(type: "int", nullable: false),
                    MaximumCustomersPerHour = table.Column<int>(type: "int", nullable: false),
                    AverageCookiesPerSale = table.Column<double>(type: "float", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookieStand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HourlySales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CookieStandId = table.Column<int>(type: "int", nullable: false),
                    SalesAmount = table.Column<int>(type: "int", nullable: false),
                    hour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlySales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourlySales_CookieStand_CookieStandId",
                        column: x => x.CookieStandId,
                        principalTable: "CookieStand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CookieStand",
                columns: new[] { "Id", "AverageCookiesPerSale", "Description", "Location", "MaximumCustomersPerHour", "MinimumCustomersPerHour", "Owner" },
                values: new object[,]
                {
                    { 1, 2.5, "", "Barcelona", 7, 3, "" },
                    { 2, 3.0, "", "maxico", 8, 2, "" },
                    { 3, 3.5, "", "Chickgio", 7, 3, "" }
                });

            migrationBuilder.InsertData(
                table: "HourlySales",
                columns: new[] { "Id", "CookieStandId", "SalesAmount", "hour" },
                values: new object[,]
                {
                    { 1, 1, 17, 5 },
                    { 2, 2, 7, 4 },
                    { 3, 3, 6, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HourlySales_CookieStandId",
                table: "HourlySales",
                column: "CookieStandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HourlySales");

            migrationBuilder.DropTable(
                name: "CookieStand");
        }
    }
}
