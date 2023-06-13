using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpTest.Migrations
{
    public partial class emp1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mobile",
                table: "employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "employees");
        }
    }
}
