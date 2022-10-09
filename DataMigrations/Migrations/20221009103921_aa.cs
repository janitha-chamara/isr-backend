using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataMigrations.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WFMLastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectManger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotedHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ActualHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProjectStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentQuotedHoursUsed = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EstToComplHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalForeCastHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrentthroughProject = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ForecastQuotedHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuotedHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ActualHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrentofQuotedHoursUsed = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EstToComplHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalForecastHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_JobId",
                table: "Tasks",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
