using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RmWebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGoogleReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFromGoogle",
                table: "GoogleReviews");

            migrationBuilder.DropColumn(
                name: "ReviewDate",
                table: "GoogleReviews");

            migrationBuilder.RenameColumn(
                name: "RelativeTime",
                table: "GoogleReviews",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "ProfilePhotoUrl",
                table: "GoogleReviews",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "GoogleReviews",
                newName: "Initial");

            migrationBuilder.RenameColumn(
                name: "AuthorName",
                table: "GoogleReviews",
                newName: "Date");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "GoogleReviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "GoogleReviews",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "GoogleReviews");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "GoogleReviews",
                newName: "RelativeTime");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "GoogleReviews",
                newName: "ProfilePhotoUrl");

            migrationBuilder.RenameColumn(
                name: "Initial",
                table: "GoogleReviews",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "GoogleReviews",
                newName: "AuthorName");

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "GoogleReviews",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsFromGoogle",
                table: "GoogleReviews",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewDate",
                table: "GoogleReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
