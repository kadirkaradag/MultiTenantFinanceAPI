using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiTenantFinanceAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAgreementSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "Id", "Name", "Amount", "Cost", "StartDate", "EndDate", "TenantId" },
                values: new object[,]
                {
                { 1, "Agreement 1", 10000m, 5000m, new DateTime(2023, 1, 1), new DateTime(2023, 12, 31), 1 },
                { 2, "Agreement 2", 15000m, 7500m, new DateTime(2023, 2, 1), new DateTime(2023, 11, 30), 2 },
                { 3, "Agreement 3", 20000m, 10000m, new DateTime(2023, 3, 1), new DateTime(2023, 10, 31), 1 },
                { 4, "Agreement 4", 25000m, 12500m, new DateTime(2023, 4, 1), new DateTime(2023, 9, 30), 2 },
                { 5, "Agreement 5", 30000m, 15000m, new DateTime(2023, 5, 1), new DateTime(2023, 8, 31), 1 },
                { 6, "Agreement 6", 35000m, 17500m, new DateTime(2023, 6, 1), new DateTime(2023, 7, 31), 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agreements",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6 });
        }
    }

}
