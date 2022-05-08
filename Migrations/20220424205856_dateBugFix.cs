using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAPI.Migrations
{
    /// <inheritdoc />
    public partial class dateBugFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Roles_roleId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "users",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "DateOfBirt",
                table: "users",
                newName: "DateOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_users_roleId",
                table: "users",
                newName: "IX_users_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Roles_RoleId",
                table: "users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Roles_RoleId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "users",
                newName: "roleId");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "users",
                newName: "DateOfBirt");

            migrationBuilder.RenameIndex(
                name: "IX_users_RoleId",
                table: "users",
                newName: "IX_users_roleId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Roles_roleId",
                table: "users",
                column: "roleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
