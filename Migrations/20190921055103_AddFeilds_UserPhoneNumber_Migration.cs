using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pishkhan.Migrations
{
    public partial class AddFeilds_UserPhoneNumber_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivationCode",
                table: "UserPhoneNumbers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivationCodeDate",
                table: "UserPhoneNumbers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "UserPhoneNumbers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivationCode",
                table: "UserPhoneNumbers");

            migrationBuilder.DropColumn(
                name: "ActivationCodeDate",
                table: "UserPhoneNumbers");

            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "UserPhoneNumbers");
        }
    }
}
