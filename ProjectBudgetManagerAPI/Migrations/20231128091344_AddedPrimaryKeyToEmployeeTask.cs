using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBudgetManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedPrimaryKeyToEmployeeTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTasks",
                table: "EmployeeTasks");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeTaskId",
                table: "EmployeeTasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTasks",
                table: "EmployeeTasks",
                column: "EmployeeTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_EmployeeId",
                table: "EmployeeTasks",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTasks",
                table: "EmployeeTasks");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTasks_EmployeeId",
                table: "EmployeeTasks");

            migrationBuilder.DropColumn(
                name: "EmployeeTaskId",
                table: "EmployeeTasks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTasks",
                table: "EmployeeTasks",
                columns: new[] { "EmployeeId", "TaskId" });
        }
    }
}
