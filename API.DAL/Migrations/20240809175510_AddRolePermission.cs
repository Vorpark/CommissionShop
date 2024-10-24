using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRolePermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionRole");

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("07cd44f0-f887-4be0-b4aa-ad7c656df04f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fb0f1a7f-90f9-4c6c-9263-c04bfae9dc63"));

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                column: "Id",
                value: new Guid("e88a55fc-c148-469a-9697-dfc01172b9af"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CityId", "CreatedDate", "Description", "DiscountPercent", "DiscountPrice", "HasDiscount", "ImageUrl", "IsSold", "Name", "Price", "SubCategoryId", "UpdatedDate" },
                values: new object[] { new Guid("86add8ac-cfc0-4eff-9640-999890ed8d84"), 1, 1, 1, new DateTime(2024, 8, 9, 17, 55, 9, 896, DateTimeKind.Utc).AddTicks(5257), "WTF", 0, 0m, false, "", false, "123", 12455.01m, 1, new DateTime(2024, 8, 9, 17, 55, 9, 896, DateTimeKind.Utc).AddTicks(5260) });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("e88a55fc-c148-469a-9697-dfc01172b9af"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86add8ac-cfc0-4eff-9640-999890ed8d84"));

            migrationBuilder.CreateTable(
                name: "PermissionRole",
                columns: table => new
                {
                    PermissionsId = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRole", x => new { x.PermissionsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_PermissionRole_Permissions_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRole_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                column: "Id",
                value: new Guid("07cd44f0-f887-4be0-b4aa-ad7c656df04f"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CityId", "CreatedDate", "Description", "DiscountPercent", "DiscountPrice", "HasDiscount", "ImageUrl", "IsSold", "Name", "Price", "SubCategoryId", "UpdatedDate" },
                values: new object[] { new Guid("fb0f1a7f-90f9-4c6c-9263-c04bfae9dc63"), 1, 1, 1, new DateTime(2024, 8, 8, 17, 18, 24, 538, DateTimeKind.Utc).AddTicks(6511), "WTF", 0, 0m, false, "", false, "123", 12455.01m, 1, new DateTime(2024, 8, 8, 17, 18, 24, 538, DateTimeKind.Utc).AddTicks(6514) });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRole_RolesId",
                table: "PermissionRole",
                column: "RolesId");
        }
    }
}
