using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RmWebApi.Migrations
{
    public partial class AddIsFromGoogleAndCreatedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IconName",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GoogleReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsFromGoogle",
                table: "GoogleReviews",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "DisplayOrder", table: "Services");
            migrationBuilder.DropColumn(name: "IconName", table: "Services");
            migrationBuilder.DropColumn(name: "ImageUrl", table: "Services");
            migrationBuilder.DropColumn(name: "Images", table: "Services");
            migrationBuilder.DropColumn(name: "CreatedAt", table: "GoogleReviews");
            migrationBuilder.DropColumn(name: "IsFromGoogle", table: "GoogleReviews");
        }
    }
}