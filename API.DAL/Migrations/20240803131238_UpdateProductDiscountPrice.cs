using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductDiscountPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cc402e63-cba8-4793-a440-e83278bc37a0"));

            migrationBuilder.RenameColumn(
                name: "DiscountedPrice",
                table: "Products",
                newName: "DiscountPrice");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CityId", "CreatedDate", "Description", "DiscountPercent", "DiscountPrice", "HasDiscount", "ImageUrl", "IsSold", "Name", "Price", "SubCategoryId" },
                values: new object[] { new Guid("08dd628e-b3dd-4f7c-ba39-4509cd63e67d"), "", 1, 1, new DateTime(2024, 8, 3, 16, 12, 38, 606, DateTimeKind.Local).AddTicks(2658), "WTF", 0, 0m, false, "", false, "123", 12455.01m, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("08dd628e-b3dd-4f7c-ba39-4509cd63e67d"));

            migrationBuilder.RenameColumn(
                name: "DiscountPrice",
                table: "Products",
                newName: "DiscountedPrice");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CityId", "CreatedDate", "Description", "DiscountPercent", "DiscountedPrice", "HasDiscount", "ImageUrl", "IsSold", "Name", "Price", "SubCategoryId" },
                values: new object[] { new Guid("cc402e63-cba8-4793-a440-e83278bc37a0"), "", 1, 1, new DateTime(2024, 8, 3, 16, 7, 38, 540, DateTimeKind.Local).AddTicks(7621), "WTF", 0, 0m, false, "", false, "123", 12455.01m, 1 });
        }
    }
}
