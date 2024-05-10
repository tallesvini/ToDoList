using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Novo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TODOLIST_USER_USER_ID",
                table: "TODOLIST");

            migrationBuilder.RenameColumn(
                name: "USER_ID",
                table: "TODOLIST",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TODOLIST_USER_ID",
                table: "TODOLIST",
                newName: "IX_TODOLIST_UserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "TODOLIST",
                type: "RAW(16)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "RAW(16)");

            migrationBuilder.AddForeignKey(
                name: "FK_TODOLIST_USER_UserId",
                table: "TODOLIST",
                column: "UserId",
                principalTable: "USER",
                principalColumn: "USER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TODOLIST_USER_UserId",
                table: "TODOLIST");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TODOLIST",
                newName: "USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TODOLIST_UserId",
                table: "TODOLIST",
                newName: "IX_TODOLIST_USER_ID");

            migrationBuilder.AlterColumn<Guid>(
                name: "USER_ID",
                table: "TODOLIST",
                type: "RAW(16)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "RAW(16)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TODOLIST_USER_USER_ID",
                table: "TODOLIST",
                column: "USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
