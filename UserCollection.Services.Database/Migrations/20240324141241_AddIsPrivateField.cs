using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserCollection.Services.Database.Migrations
{
    public partial class AddIsPrivateField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Collections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Collections");
        }
    }
}
