using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shoppingCartAPI.Migrations
{
    public partial class AddUserVerifyFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password_reset_token",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "reset_token_expires",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "verfied_at",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "verification_token",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password_reset_token",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "reset_token_expires",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "verfied_at",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "verification_token",
                table: "Users");
        }
    }
}
