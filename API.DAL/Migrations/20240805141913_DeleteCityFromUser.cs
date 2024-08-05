using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCityFromUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cities_CityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CityId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fa3aab0b-e28c-4226-a440-d7f4691df48f"));

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CityId", "CreatedDate", "Description", "DiscountPercent", "DiscountPrice", "HasDiscount", "ImageUrl", "IsSold", "Name", "Price", "SubCategoryId", "UpdatedDate" },
                values: new object[] { new Guid("eff62f00-c0fe-4cbe-a65a-ea020f071999"), 1, 1, 1, new DateTime(2024, 8, 5, 17, 19, 12, 776, DateTimeKind.Local).AddTicks(5033), "WTF", 0, 0m, false, "", false, "123", 12455.01m, 1, new DateTime(2024, 8, 5, 17, 19, 12, 776, DateTimeKind.Local).AddTicks(5042) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eff62f00-c0fe-4cbe-a65a-ea020f071999"));

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CityId", "CreatedDate", "Description", "DiscountPercent", "DiscountPrice", "HasDiscount", "ImageUrl", "IsSold", "Name", "Price", "SubCategoryId", "UpdatedDate" },
                values: new object[] { new Guid("fa3aab0b-e28c-4226-a440-d7f4691df48f"), 1, 1, 1, new DateTime(2024, 8, 5, 13, 15, 0, 569, DateTimeKind.Utc).AddTicks(99), "WTF", 0, 0m, false, "", false, "123", 12455.01m, 1, new DateTime(2024, 8, 5, 13, 15, 0, 569, DateTimeKind.Utc).AddTicks(101) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cities_CityId",
                table: "Users",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
