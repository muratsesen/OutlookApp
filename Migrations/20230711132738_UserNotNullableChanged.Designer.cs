﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraphTutorial.Migrations
{
    [DbContext(typeof(OutlookContext))]
    [Migration("20230711132738_UserNotNullableChanged")]
    partial class UserNotNullableChanged
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "displayName");

                    b.Property<string>("GivenName")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "givenName");

                    b.Property<string>("JobTitle")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "jobTitle");

                    b.Property<string>("Mail")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "mail");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "mobilePhone");

                    b.Property<string>("OfficeLocation")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "officeLocation");

                    b.Property<string>("PreferredLanguage")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "preferredLanguage");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "surname");

                    b.Property<string>("UserPrincipalName")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "userPrincipalName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
