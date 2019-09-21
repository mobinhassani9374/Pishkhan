using Microsoft.EntityFrameworkCore.Migrations;

namespace Pishkhan.Migrations
{
    public partial class AddFeild_IsConfirm_UserPhoneNumber_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsConfirm",
                table: "UserPhoneNumbers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirm",
                table: "UserPhoneNumbers");
        }
    }
}
