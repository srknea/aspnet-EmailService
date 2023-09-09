using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsRequiredForFluentAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmailAddresses_Email",
                table: "EmailAddresses");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "EmailLogs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "EmailLogs",
                type: "nvarchar(max)",
                maxLength: 20000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 20000);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "EmailAddresses",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_Email",
                table: "EmailAddresses",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmailAddresses_Email",
                table: "EmailAddresses");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "EmailLogs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "EmailLogs",
                type: "nvarchar(max)",
                maxLength: 20000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 20000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "EmailAddresses",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_Email",
                table: "EmailAddresses",
                column: "Email",
                unique: true);
        }
    }
}
