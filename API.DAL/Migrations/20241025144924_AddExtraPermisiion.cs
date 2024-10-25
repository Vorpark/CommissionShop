using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddExtraPermisiion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("e88a55fc-c148-469a-9697-dfc01172b9af"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86add8ac-cfc0-4eff-9640-999890ed8d84"));

            migrationBuilder.InsertData(
                table: "Carts",
                column: "Id",
                value: new Guid("dbbb30b9-ee12-41f0-ad68-b049316516a7"));

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "ExtraPermission" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CityId", "CreatedDate", "Description", "DiscountPercent", "DiscountPrice", "HasDiscount", "ImageUrl", "IsSold", "Name", "Price", "SubCategoryId", "UpdatedDate" },
                values: new object[] { new Guid("6280c7f3-957a-448b-ae63-86dd6920f676"), 1, 1, 1, new DateTime(2024, 10, 25, 14, 49, 24, 85, DateTimeKind.Utc).AddTicks(6259), "WTF", 0, 0m, false, "", false, "123", 12455.01m, 1, new DateTime(2024, 10, 25, 14, 49, 24, 85, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 6, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("dbbb30b9-ee12-41f0-ad68-b049316516a7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6280c7f3-957a-448b-ae63-86dd6920f676"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "Carts",
                column: "Id",
                value: new Guid("e88a55fc-c148-469a-9697-dfc01172b9af"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CityId", "CreatedDate", "Description", "DiscountPercent", "DiscountPrice", "HasDiscount", "ImageUrl", "IsSold", "Name", "Price", "SubCategoryId", "UpdatedDate" },
                values: new object[] { new Guid("86add8ac-cfc0-4eff-9640-999890ed8d84"), 1, 1, 1, new DateTime(2024, 8, 9, 17, 55, 9, 896, DateTimeKind.Utc).AddTicks(5257), "WTF", 0, 0m, false, "", false, "123", 12455.01m, 1, new DateTime(2024, 8, 9, 17, 55, 9, 896, DateTimeKind.Utc).AddTicks(5260) });
        }
    }
}
