using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "EmailLogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "EmailAddresses",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "EmailLogs");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "EmailAddresses");
        }
    }
}
