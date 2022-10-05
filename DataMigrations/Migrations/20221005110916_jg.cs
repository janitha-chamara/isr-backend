using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataMigrations.Migrations
{
    public partial class jg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Tasks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Jobs",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "JobNo",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tasks",
                newName: "TaskId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Jobs",
                newName: "JobId");

            migrationBuilder.AlterColumn<int>(
                name: "JobNo",
                table: "Jobs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
