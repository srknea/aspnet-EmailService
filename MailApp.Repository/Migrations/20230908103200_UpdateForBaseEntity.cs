using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "EmailLogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "EmailLogs",
                type: "datetime2",
                nullable: true);
        }
    }
}
