using Microsoft.EntityFrameworkCore.Migrations;

namespace Pishkhan.Migrations
{
    public partial class RenameTable_IdentityTables_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPhoneNumbers_AspNetUsers_UserId",
                table: "UserPhoneNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "UserTokens",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Users",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "UserRoles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "UserLogins",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "UserClaims",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "Roles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "RoleClaims",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_NationalCode",
                schema: "dbo",
                table: "Users",
                newName: "IX_Users_NationalCode");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "dbo",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "dbo",
                table: "UserLogins",
                newName: "IX_UserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "dbo",
                table: "UserClaims",
                newName: "IX_UserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "dbo",
                table: "RoleClaims",
                newName: "IX_RoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                schema: "dbo",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "dbo",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                schema: "dbo",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                schema: "dbo",
                table: "UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserClaims",
                schema: "dbo",
                table: "UserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                schema: "dbo",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClaims",
                schema: "dbo",
                table: "RoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhoneNumbers_Users_UserId",
                table: "UserPhoneNumbers",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                schema: "dbo",
                table: "RoleClaims",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_UserId",
                schema: "dbo",
                table: "UserClaims",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserId",
                schema: "dbo",
                table: "UserLogins",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                schema: "dbo",
                table: "UserRoles",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                schema: "dbo",
                table: "UserRoles",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                schema: "dbo",
                table: "UserTokens",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPhoneNumbers_Users_UserId",
                table: "UserPhoneNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                schema: "dbo",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_UserId",
                schema: "dbo",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserId",
                schema: "dbo",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                schema: "dbo",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                schema: "dbo",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                schema: "dbo",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                schema: "dbo",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                schema: "dbo",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                schema: "dbo",
                table: "UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserClaims",
                schema: "dbo",
                table: "UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                schema: "dbo",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClaims",
                schema: "dbo",
                table: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "dbo",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "dbo",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "dbo",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                schema: "dbo",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "dbo",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "dbo",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "dbo",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_Users_NationalCode",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_NationalCode");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogins_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserClaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhoneNumbers_AspNetUsers_UserId",
                table: "UserPhoneNumbers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
