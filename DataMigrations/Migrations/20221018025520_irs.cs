using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataMigrations.Migrations
{
    public partial class irs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAllTaskUpdated",
                table: "Jobs",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAllTaskUpdated",
                table: "Jobs");
        }
    }
}
