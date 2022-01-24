using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LEARNING.Migrations
{
    public partial class addstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cause",
                table: "tblFormation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "tblFormation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cause",
                table: "tblFormation");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tblFormation");
        }
    }
}
