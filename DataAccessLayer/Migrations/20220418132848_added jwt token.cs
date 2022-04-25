using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addedjwttoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d4695c5-ebeb-4c7d-9144-26637787a1ec",
                column: "ConcurrencyStamp",
                value: "219c5506-3ce8-4651-9f2e-c6f6621a12e7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99deb2e8-7cab-4013-a43e-0a8d55308419",
                column: "ConcurrencyStamp",
                value: "2f58764d-4295-4094-8e60-e16234586916");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "83c4eefe-3f50-458d-a227-21f6a7806ab1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d7efa09-885a-4a6b-83ee-5a7ba36bf384", "AQAAAAEAACcQAAAAEHXSWH1Ca1LaorKV2FPnxgAyayktJ7SnK1r8dtgD1FuGq+XidEv+hbe9qAJzOUuGyg==", "20f062d1-6163-4438-8ef3-a29ab5505ee3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d4695c5-ebeb-4c7d-9144-26637787a1ec",
                column: "ConcurrencyStamp",
                value: "b1296d7f-94b3-417b-81e7-0fcc112cb95d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99deb2e8-7cab-4013-a43e-0a8d55308419",
                column: "ConcurrencyStamp",
                value: "c22510be-253a-433d-914f-321b3a7711c4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "83c4eefe-3f50-458d-a227-21f6a7806ab1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40fce467-8c6b-4a36-8675-b4aff329767e", "AQAAAAEAACcQAAAAECZ6zV7vqTa1e9ca9vjONtxSI9d8SlG2XIOitt6VUY0nTC0QTeRngz3pv7k/d6fbVw==", "de6e095c-fc1f-419b-bf0e-a76e356fbfba" });
        }
    }
}
