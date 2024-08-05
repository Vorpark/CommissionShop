using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCartSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eff62f00-c0fe-4cbe-a65a-ea020f071999"));

            migrationBuilder.InsertData(
                table: "Carts",
                column: "Id",
                value: new Guid("49cc873c-5fe6-4c53-81cd-212169f69dca"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CityId", "CreatedDate", "Description", "DiscountPercent", "DiscountPrice", "HasDiscount", "ImageUrl", "IsSold", "Name", "Price", "SubCategoryId", "UpdatedDate" },
                values: new object[] { new Guid("6ce7b933-912e-4ce9-8178-474f65fbcda0"), 1, 1, 1, new DateTime(2024, 8, 5, 18, 40, 39, 796, DateTimeKind.Local).AddTicks(7787), "WTF", 0, 0m, false, "", false, "123", 12455.01m, 1, new DateTime(2024, 8, 5, 18, 40, 39, 796, DateTimeKind.Local).AddTicks(7795) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("49cc873c-5fe6-4c53-81cd-212169f69dca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6ce7b933-912e-4ce9-8178-474f65fbcda0"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CityId", "CreatedDate", "Description", "DiscountPercent", "DiscountPrice", "HasDiscount", "ImageUrl", "IsSold", "Name", "Price", "SubCategoryId", "UpdatedDate" },
                values: new object[] { new Guid("eff62f00-c0fe-4cbe-a65a-ea020f071999"), 1, 1, 1, new DateTime(2024, 8, 5, 17, 19, 12, 776, DateTimeKind.Local).AddTicks(5033), "WTF", 0, 0m, false, "", false, "123", 12455.01m, 1, new DateTime(2024, 8, 5, 17, 19, 12, 776, DateTimeKind.Local).AddTicks(5042) });
        }
    }
}
