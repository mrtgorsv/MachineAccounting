using Microsoft.EntityFrameworkCore.Migrations;

namespace MachineAccounting.DataContext.Migrations
{
    public partial class UpdateDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Machine",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Machine");
        }
    }
}
