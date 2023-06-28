using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Becoming.Core.TaskManager.Infrastructure.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tasks");

            migrationBuilder.CreateTable(
                name: "task_manager",
                schema: "tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task_manager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "summary_task",
                schema: "tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(3072)", maxLength: 3072, nullable: true),
                    TaskManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    OnlyDate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_summary_task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_summary_task_task_manager_TaskManagerId",
                        column: x => x.TaskManagerId,
                        principalSchema: "tasks",
                        principalTable: "task_manager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "task_manager_category",
                schema: "tasks",
                columns: table => new
                {
                    TaskManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task_manager_category", x => x.TaskManagerId);
                    table.ForeignKey(
                        name: "FK_task_manager_category_task_manager_TaskManagerId",
                        column: x => x.TaskManagerId,
                        principalSchema: "tasks",
                        principalTable: "task_manager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subtask",
                schema: "tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(3072)", maxLength: 3072, nullable: true),
                    SummaryTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subtask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subtask_summary_task_SummaryTaskId",
                        column: x => x.SummaryTaskId,
                        principalSchema: "tasks",
                        principalTable: "summary_task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subtask_SummaryTaskId",
                schema: "tasks",
                table: "subtask",
                column: "SummaryTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_summary_task_TaskManagerId",
                schema: "tasks",
                table: "summary_task",
                column: "TaskManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subtask",
                schema: "tasks");

            migrationBuilder.DropTable(
                name: "task_manager_category",
                schema: "tasks");

            migrationBuilder.DropTable(
                name: "summary_task",
                schema: "tasks");

            migrationBuilder.DropTable(
                name: "task_manager",
                schema: "tasks");
        }
    }
}
