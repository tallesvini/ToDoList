using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Novo3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TODOLIST_USER_UserId",
                table: "TODOLIST");

            migrationBuilder.DropIndex(
                name: "IX_TODOLIST_UserId",
                table: "TODOLIST");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TODOLIST");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "TODOLIST",
                type: "RAW(16)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TODOLIST_UserId",
                table: "TODOLIST",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TODOLIST_USER_UserId",
                table: "TODOLIST",
                column: "UserId",
                principalTable: "USER",
                principalColumn: "USER_ID");
        }
    }
}
