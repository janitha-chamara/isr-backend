using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataMigrations.Migrations
{
    public partial class k : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CurrentQuotedHoursUsed",
                table: "Jobs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentthroughProject",
                table: "Jobs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EstToComplHours",
                table: "Jobs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ForecastQuotedHours",
                table: "Jobs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalForeCastHours",
                table: "Jobs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentQuotedHoursUsed",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CurrentthroughProject",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "EstToComplHours",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ForecastQuotedHours",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "TotalForeCastHours",
                table: "Jobs");
        }
    }
}
