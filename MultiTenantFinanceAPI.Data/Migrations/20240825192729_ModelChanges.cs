using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiTenantFinanceAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Agreements_AgreementId",
                table: "Issues");

            migrationBuilder.AddColumn<int>(
                name: "PartnerId",
                table: "Agreements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Agreements",
                keyColumn: "Id",
                keyValue: 1,
                column: "PartnerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Agreements",
                keyColumn: "Id",
                keyValue: 2,
                column: "PartnerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Agreements",
                keyColumn: "Id",
                keyValue: 3,
                column: "PartnerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Agreements",
                keyColumn: "Id",
                keyValue: 4,
                column: "PartnerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Agreements",
                keyColumn: "Id",
                keyValue: 5,
                column: "PartnerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Agreements",
                keyColumn: "Id",
                keyValue: 6,
                column: "PartnerId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_PartnerId",
                table: "Agreements",
                column: "PartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_Partners_PartnerId",
                table: "Agreements",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Agreements_AgreementId",
                table: "Issues",
                column: "AgreementId",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agreements_Partners_PartnerId",
                table: "Agreements");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Agreements_AgreementId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Agreements_PartnerId",
                table: "Agreements");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "Agreements");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Agreements_AgreementId",
                table: "Issues",
                column: "AgreementId",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
