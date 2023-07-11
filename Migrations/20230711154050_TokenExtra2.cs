using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphTutorial.Migrations
{
    /// <inheritdoc />
    public partial class TokenExtra2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrantDateTime",
                table: "Tokens");

            migrationBuilder.RenameColumn(
                name: "ExpiresAfter",
                table: "Tokens",
                newName: "ExtExpiresIn");

            migrationBuilder.AddColumn<int>(
                name: "ExpiresIn",
                table: "Tokens",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TokenType",
                table: "Tokens",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiresIn",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "TokenType",
                table: "Tokens");

            migrationBuilder.RenameColumn(
                name: "ExtExpiresIn",
                table: "Tokens",
                newName: "ExpiresAfter");

            migrationBuilder.AddColumn<DateTime>(
                name: "GrantDateTime",
                table: "Tokens",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
