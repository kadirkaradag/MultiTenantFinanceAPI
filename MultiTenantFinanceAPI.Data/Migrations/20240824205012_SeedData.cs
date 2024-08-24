using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MultiTenantFinanceAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "Id", "Amount", "Cost", "Name", "TenantId" },
                values: new object[,]
                {
                    { 1, 10000m, 8000m, "Agreement 1", 1 },
                    { 2, 15000m, 12000m, "Agreement 2", 1 }
                });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "Id", "Name", "TenantId" },
                values: new object[,]
                {
                    { 1, "Partner 1", 1 },
                    { 2, "Partner 2", 1 }
                });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "AgreementId", "Description", "RiskAmount", "TenantId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Description for Issue 1", 500m, 1, "Issue 1" },
                    { 2, 2, "Description for Issue 2", 700m, 1, "Issue 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Agreements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Agreements",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
