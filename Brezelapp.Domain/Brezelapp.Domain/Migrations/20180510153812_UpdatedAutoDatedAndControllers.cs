using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Brezelapp.Migrations
{
    public partial class UpdatedAutoDatedAndControllers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Stores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Stores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "Stores",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Rating",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Price",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Price",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "GeoLoc",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "GeoLoc",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brezels",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BrezelId",
                table: "Brezels",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Brezels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Brezels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Address",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Address",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "GeoLoc");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "GeoLoc");

            migrationBuilder.DropColumn(
                name: "BrezelId",
                table: "Brezels");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Brezels");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Brezels");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brezels",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
