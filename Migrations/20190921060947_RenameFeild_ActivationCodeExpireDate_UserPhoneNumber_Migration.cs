using Microsoft.EntityFrameworkCore.Migrations;

namespace Pishkhan.Migrations
{
    public partial class RenameFeild_ActivationCodeExpireDate_UserPhoneNumber_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActivationCodeDate",
                table: "UserPhoneNumbers",
                newName: "ActivationCodeExpireDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActivationCodeExpireDate",
                table: "UserPhoneNumbers",
                newName: "ActivationCodeDate");
        }
    }
}
