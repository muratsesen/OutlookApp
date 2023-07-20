﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraphTutorial.Migrations
{
    [DbContext(typeof(OutlookContext))]
    [Migration("20230718131641_Folders")]
    partial class Folders
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("Email", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("BccRecipients")
                        .HasColumnType("TEXT");

                    b.Property<string>("BodyPreview")
                        .HasColumnType("TEXT");

                    b.Property<string>("CcRecipients")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChangeKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConversationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConversationIndex")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("EndDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Flag")
                        .HasColumnType("TEXT");

                    b.Property<string>("From")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("HasAttachments")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Importance")
                        .HasColumnType("TEXT");

                    b.Property<string>("InferenceClassification")
                        .HasColumnType("TEXT");

                    b.Property<string>("InternetMessageId")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsAllDay")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsDelegated")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsDraft")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsOutOfDate")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsRead")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsReadReceiptRequested")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModifiedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("MeetingMessageType")
                        .HasColumnType("TEXT");

                    b.Property<string>("MeetingRequestType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentFolderId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReceivedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReplyTo")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("ResponseRequested")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sender")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("SentDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("StartDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subject")
                        .HasColumnType("TEXT");

                    b.Property<string>("ToRecipients")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WebLink")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentFolderId");

                    b.HasIndex("UserId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("Folder", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ChildFolderCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsHidden")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ParentFolderId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SizeInBytes")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TotalItemCount")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UnreadItemCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "access_token");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("ExpiresIn")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "expires_in");

                    b.Property<int>("ExtExpiresIn")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "ext_expires_in");

                    b.Property<string>("TokenType")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "token_type");

                    b.HasKey("Id");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("GivenName")
                        .HasColumnType("TEXT");

                    b.Property<string>("JobTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mail")
                        .HasColumnType("TEXT");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("TEXT");

                    b.Property<string>("OfficeLocation")
                        .HasColumnType("TEXT");

                    b.Property<string>("PreferredLanguage")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserPrincipalName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Email", b =>
                {
                    b.HasOne("Folder", "Folder")
                        .WithMany("Emails")
                        .HasForeignKey("ParentFolderId");

                    b.HasOne("User", "User")
                        .WithMany("Emails")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Folder");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Folder", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany("Folders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Folder", b =>
                {
                    b.Navigation("Emails");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("Emails");

                    b.Navigation("Folders");
                });
#pragma warning restore 612, 618
        }
    }
}
