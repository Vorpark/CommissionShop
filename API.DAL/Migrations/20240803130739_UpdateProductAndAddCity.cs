using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductAndAddCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fd26c54d-97d7-4952-9355-b6aa6b2689cc"));

            migrationBuilder.DropColumn(
                name: "City",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercent",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountedPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Набережные Челны" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CityId", "CreatedDate", "Description", "DiscountPercent", "DiscountedPrice", "HasDiscount", "ImageUrl", "IsSold", "Name", "Price", "SubCategoryId" },
                values: new object[] { new Guid("cc402e63-cba8-4793-a440-e83278bc37a0"), "", 1, 1, new DateTime(2024, 8, 3, 16, 7, 38, 540, DateTimeKind.Local).AddTicks(7621), "WTF", 0, 0m, false, "", false, "123", 12455.01m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CityId",
                table: "Products",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_City_CityId",
                table: "Products",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_City_CityId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropIndex(
                name: "IX_Products_CityId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cc402e63-cba8-4793-a440-e83278bc37a0"));

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountedPrice",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Products",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "City", "CreatedDate", "Description", "Discount", "HasDiscount", "ImageUrl", "IsSold", "Name", "Price", "SubCategoryId" },
                values: new object[] { new Guid("fd26c54d-97d7-4952-9355-b6aa6b2689cc"), "", 1, "", new DateTime(2024, 8, 3, 9, 51, 49, 506, DateTimeKind.Local).AddTicks(6375), "WTF", 0m, false, "", false, "123", 12455.01m, 1 });
        }
    }
}
