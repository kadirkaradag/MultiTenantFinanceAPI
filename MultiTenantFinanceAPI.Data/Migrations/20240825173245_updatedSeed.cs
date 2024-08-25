using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MultiTenantFinanceAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "AgreementAmount", "AgreementId", "Cost", "Description", "Keywords", "RiskAmount", "RiskLevel", "TenantId", "Title" },
                values: new object[,]
                {
                    { 1, 10000m, 1, 3000m, "Description for Issue 1", "critical, high", 500m, 2, 1, "Issue 1" },
                    { 2, 15000m, 2, 4000m, "Description for Issue 2", "important, medium", 300m, 1, 2, "Issue 2" },
                    { 3, 20000m, 3, 2000m, "Description for Issue 3", "low, minimal", 200m, 0, 1, "Issue 3" },
                    { 4, 25000m, 4, 7000m, "Description for Issue 4", "critical, high", 1000m, 2, 2, "Issue 4" },
                    { 5, 30000m, 5, 5000m, "Description for Issue 5", "important, medium", 700m, 1, 1, "Issue 5" },
                    { 6, 35000m, 6, 3500m, "Description for Issue 6", "low, minimal", 400m, 0, 2, "Issue 6" }
                });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "Id", "ContactInfo", "Name", "TenantId" },
                values: new object[,]
                {
                    { 1, "partner1@example.com", "Partner 1", 1 },
                    { 2, "partner2@example.com", "Partner 2", 2 },
                    { 3, "partner3@example.com", "Partner 3", 1 },
                    { 4, "partner4@example.com", "Partner 4", 2 },
                    { 5, "partner5@example.com", "Partner 5", 1 },
                    { 6, "partner6@example.com", "Partner 6", 2 }
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
                table: "Issues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
