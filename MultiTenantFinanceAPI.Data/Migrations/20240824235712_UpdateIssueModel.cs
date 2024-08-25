using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiTenantFinanceAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIssueModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AgreementAmount",
                table: "Issues",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Issues",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Keywords",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RiskLevel",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AgreementAmount", "Cost", "Description", "Keywords", "RiskLevel", "TenantId" },
                values: new object[] { 10000m, 3000m, "Description 1", "critical", 2, 0 });

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AgreementAmount", "Cost", "Description", "Keywords", "RiskAmount", "RiskLevel", "TenantId" },
                values: new object[] { 20000m, 1000m, "Description 2", "important", 300m, 1, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgreementAmount",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Keywords",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "RiskLevel",
                table: "Issues");

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "TenantId" },
                values: new object[] { "Description for Issue 1", 1 });

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "RiskAmount", "TenantId" },
                values: new object[] { "Description for Issue 2", 700m, 1 });
        }
    }
}
