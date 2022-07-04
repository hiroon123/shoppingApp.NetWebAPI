using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shoppingCartAPI.Migrations
{
    public partial class AddGenderToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gender",
                table: "Users");
        }
    }
}
