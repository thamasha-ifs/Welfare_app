using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Welfare_App.Migrations
{
    public partial class alterVendors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BudgetCategoryItemId",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BudgetItemName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VendorName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BudgetItemName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "VendorName",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "BudgetCategoryItemId",
                table: "Vendors",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
