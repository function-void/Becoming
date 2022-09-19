using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Becoming.Core.TaskManager.Infrastructure.PostgreSql.Migrations
{
    public partial class TaskManager_Category_Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                schema: "tasks",
                table: "task_manager_category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                schema: "tasks",
                table: "task_manager_category",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
