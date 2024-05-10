using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Novo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    USER_ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    USERNAME = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    PASSWORD = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    ROLE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "TODOLIST",
                columns: table => new
                {
                    TODOLIST_ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    TITLE = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    START_DATE = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    END_DATE = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    USER_ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TODOLIST", x => x.TODOLIST_ID);
                    table.ForeignKey(
                        name: "FK_TODOLIST_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TODOLIST_USER_ID",
                table: "TODOLIST",
                column: "USER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TODOLIST");

            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
