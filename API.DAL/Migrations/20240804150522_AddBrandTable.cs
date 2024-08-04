using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddBrandTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_City_CityId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("08dd628e-b3dd-4f7c-ba39-4509cd63e67d"));

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Android" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CityId", "CreatedDate", "Description", "DiscountPercent", "DiscountPrice", "HasDiscount", "ImageUrl", "IsSold", "Name", "Price", "SubCategoryId" },
                values: new object[] { new Guid("a695bfea-ba6a-45ac-b68a-a8d9f985918e"), 1, 1, 1, new DateTime(2024, 8, 4, 18, 5, 22, 121, DateTimeKind.Local).AddTicks(6531), "WTF", 0, 0m, false, "", false, "123", 12455.01m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Cities_CityId",
                table: "Products",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cities_CityId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a695bfea-ba6a-45ac-b68a-a8d9f985918e"));

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CityId", "CreatedDate", "Description", "DiscountPercent", "DiscountPrice", "HasDiscount", "ImageUrl", "IsSold", "Name", "Price", "SubCategoryId" },
                values: new object[] { new Guid("08dd628e-b3dd-4f7c-ba39-4509cd63e67d"), "", 1, 1, new DateTime(2024, 8, 3, 16, 12, 38, 606, DateTimeKind.Local).AddTicks(2658), "WTF", 0, 0m, false, "", false, "123", 12455.01m, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_City_CityId",
                table: "Products",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
