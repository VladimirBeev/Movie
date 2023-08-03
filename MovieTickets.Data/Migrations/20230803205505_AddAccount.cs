using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTickets.Data.Migrations
{
    public partial class AddAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 13, 23, 55, 4, 398, DateTimeKind.Local).AddTicks(4066), new DateTime(2023, 7, 24, 23, 55, 4, 398, DateTimeKind.Local).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 6, 23, 55, 4, 398, DateTimeKind.Local).AddTicks(4079), new DateTime(2023, 8, 3, 23, 55, 4, 398, DateTimeKind.Local).AddTicks(4076) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 10, 23, 55, 4, 398, DateTimeKind.Local).AddTicks(4086), new DateTime(2023, 8, 3, 23, 55, 4, 398, DateTimeKind.Local).AddTicks(4084) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 29, 23, 55, 4, 398, DateTimeKind.Local).AddTicks(4094), new DateTime(2023, 7, 24, 23, 55, 4, 398, DateTimeKind.Local).AddTicks(4091) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 1, 23, 55, 4, 398, DateTimeKind.Local).AddTicks(4101), new DateTime(2023, 7, 24, 23, 55, 4, 398, DateTimeKind.Local).AddTicks(4098) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 23, 23, 55, 4, 398, DateTimeKind.Local).AddTicks(4111), new DateTime(2023, 8, 6, 23, 55, 4, 398, DateTimeKind.Local).AddTicks(4108) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 13, 1, 39, 59, 674, DateTimeKind.Local).AddTicks(8087), new DateTime(2023, 7, 24, 1, 39, 59, 674, DateTimeKind.Local).AddTicks(8046) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 6, 1, 39, 59, 674, DateTimeKind.Local).AddTicks(8095), new DateTime(2023, 8, 3, 1, 39, 59, 674, DateTimeKind.Local).AddTicks(8093) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 10, 1, 39, 59, 674, DateTimeKind.Local).AddTicks(8101), new DateTime(2023, 8, 3, 1, 39, 59, 674, DateTimeKind.Local).AddTicks(8099) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 29, 1, 39, 59, 674, DateTimeKind.Local).AddTicks(8107), new DateTime(2023, 7, 24, 1, 39, 59, 674, DateTimeKind.Local).AddTicks(8105) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 1, 1, 39, 59, 674, DateTimeKind.Local).AddTicks(8112), new DateTime(2023, 7, 24, 1, 39, 59, 674, DateTimeKind.Local).AddTicks(8110) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 23, 1, 39, 59, 674, DateTimeKind.Local).AddTicks(8120), new DateTime(2023, 8, 6, 1, 39, 59, 674, DateTimeKind.Local).AddTicks(8117) });
        }
    }
}
