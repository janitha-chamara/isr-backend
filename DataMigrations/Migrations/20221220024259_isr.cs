using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataMigrations.Migrations
{
    public partial class isr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAllTaskUpdated",
                table: "Jobs",
                newName: "IsLock");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsLock",
                table: "Jobs",
                newName: "IsAllTaskUpdated");
        }
    }
}
