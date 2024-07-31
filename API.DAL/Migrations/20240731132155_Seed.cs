using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "Name", "TranslitName" },
                values: new object[] { new Guid("83b2010f-0410-4005-8837-b85de9dbb2be"), "", "", "" });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "Name", "TranslitName" },
                values: new object[] { new Guid("2cc2d055-757f-418f-badc-68d048157087"), new Guid("83b2010f-0410-4005-8837-b85de9dbb2be"), "", "", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "City", "CreatedDate", "Description", "ImageUrl", "IsSold", "Name", "Price", "SubCategoryId" },
                values: new object[] { new Guid("bb9ba571-369a-485c-9559-c16c75a87e78"), "", new DateTime(2024, 7, 31, 16, 21, 54, 810, DateTimeKind.Local).AddTicks(289), "WTF", "", false, "123", 12455.01m, new Guid("2cc2d055-757f-418f-badc-68d048157087") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bb9ba571-369a-485c-9559-c16c75a87e78"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("2cc2d055-757f-418f-badc-68d048157087"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("83b2010f-0410-4005-8837-b85de9dbb2be"));
        }
    }
}
