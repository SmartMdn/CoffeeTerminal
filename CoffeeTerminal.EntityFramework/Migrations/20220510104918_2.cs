using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeTerminal.EntityFramework.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "Terminals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "Terminals",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
