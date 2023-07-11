using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphTutorial.Migrations
{
    /// <inheritdoc />
    public partial class TokenExtra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpiresAfter",
                table: "Tokens",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "GrantDateTime",
                table: "Tokens",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiresAfter",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "GrantDateTime",
                table: "Tokens");
        }
    }
}
