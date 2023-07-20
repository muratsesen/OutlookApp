using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphTutorial.Migrations
{
    /// <inheritdoc />
    public partial class UserEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ChangeKey = table.Column<string>(type: "TEXT", nullable: false),
                    ReceivedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SentDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HasAttachments = table.Column<bool>(type: "INTEGER", nullable: false),
                    InternetMessageId = table.Column<string>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    BodyPreview = table.Column<string>(type: "TEXT", nullable: false),
                    Importance = table.Column<string>(type: "TEXT", nullable: false),
                    ParentFolderId = table.Column<string>(type: "TEXT", nullable: false),
                    ConversationId = table.Column<string>(type: "TEXT", nullable: false),
                    ConversationIndex = table.Column<string>(type: "TEXT", nullable: false),
                    IsReadReceiptRequested = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsRead = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDraft = table.Column<bool>(type: "INTEGER", nullable: false),
                    WebLink = table.Column<string>(type: "TEXT", nullable: false),
                    InferenceClassification = table.Column<string>(type: "TEXT", nullable: false),
                    MeetingMessageType = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    IsOutOfDate = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsAllDay = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDelegated = table.Column<bool>(type: "INTEGER", nullable: false),
                    ResponseRequested = table.Column<bool>(type: "INTEGER", nullable: false),
                    MeetingRequestType = table.Column<string>(type: "TEXT", nullable: false),
                    Sender = table.Column<string>(type: "TEXT", nullable: false),
                    From = table.Column<string>(type: "TEXT", nullable: false),
                    ToRecipients = table.Column<string>(type: "TEXT", nullable: false),
                    CcRecipients = table.Column<string>(type: "TEXT", nullable: false),
                    BccRecipients = table.Column<string>(type: "TEXT", nullable: false),
                    ReplyTo = table.Column<string>(type: "TEXT", nullable: false),
                    Flag = table.Column<string>(type: "TEXT", nullable: false),
                    StartDateTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    EndDateTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emails_UserId",
                table: "Emails",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emails");
        }
    }
}
