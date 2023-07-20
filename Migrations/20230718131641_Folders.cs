using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphTutorial.Migrations
{
    /// <inheritdoc />
    public partial class Folders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    ParentFolderId = table.Column<string>(type: "TEXT", nullable: true),
                    ChildFolderCount = table.Column<int>(type: "INTEGER", nullable: true),
                    UnreadItemCount = table.Column<int>(type: "INTEGER", nullable: true),
                    TotalItemCount = table.Column<int>(type: "INTEGER", nullable: true),
                    SizeInBytes = table.Column<int>(type: "INTEGER", nullable: true),
                    IsHidden = table.Column<bool>(type: "INTEGER", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emails_ParentFolderId",
                table: "Emails",
                column: "ParentFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_UserId",
                table: "Folders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Folders_ParentFolderId",
                table: "Emails",
                column: "ParentFolderId",
                principalTable: "Folders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Folders_ParentFolderId",
                table: "Emails");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropIndex(
                name: "IX_Emails_ParentFolderId",
                table: "Emails");
        }
    }
}
