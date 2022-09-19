using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Becoming.Core.TaskManager.Infrastructure.PostgreSql.Migrations
{
    public partial class TaskManager_Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category_Name",
                schema: "tasks",
                table: "task_manager");

            migrationBuilder.CreateTable(
                name: "task_manager_category",
                schema: "tasks",
                columns: table => new
                {
                    TaskManagerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "task_manager_category",
                schema: "tasks");

            migrationBuilder.AddColumn<string>(
                name: "Category_Name",
                schema: "tasks",
                table: "task_manager",
                type: "text",
                nullable: true);
        }
    }
}
