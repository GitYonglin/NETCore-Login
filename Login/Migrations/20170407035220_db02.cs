using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Login.Migrations
{
    public partial class db02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserSessionId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserSession",
                columns: table => new
                {
                    UserSessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSession", x => x.UserSessionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserSessionId",
                table: "Users",
                column: "UserSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserSession_UserSessionId",
                table: "Users",
                column: "UserSessionId",
                principalTable: "UserSession",
                principalColumn: "UserSessionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserSession_UserSessionId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserSession");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserSessionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserSessionId",
                table: "Users");
        }
    }
}
