using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addedseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5d4695c5-ebeb-4c7d-9144-26637787a1ec", "b1296d7f-94b3-417b-81e7-0fcc112cb95d", "Client", "CLIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99deb2e8-7cab-4013-a43e-0a8d55308419", "c22510be-253a-433d-914f-321b3a7711c4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "83c4eefe-3f50-458d-a227-21f6a7806ab1", 0, "none", "40fce467-8c6b-4a36-8675-b4aff329767e", "admin@gmail.com", true, "Admin", false, "Admin", false, null, null, "ADMIN", "AQAAAAEAACcQAAAAECZ6zV7vqTa1e9ca9vjONtxSI9d8SlG2XIOitt6VUY0nTC0QTeRngz3pv7k/d6fbVw==", "+111111111111", true, "de6e095c-fc1f-419b-bf0e-a76e356fbfba", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Balance", "IsActive", "UserId" },
                values: new object[] { "eebce548-84a8-43b6-a258-94ecbd9b41cb", 99999.9m, true, "83c4eefe-3f50-458d-a227-21f6a7806ab1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "99deb2e8-7cab-4013-a43e-0a8d55308419", "83c4eefe-3f50-458d-a227-21f6a7806ab1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: "eebce548-84a8-43b6-a258-94ecbd9b41cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d4695c5-ebeb-4c7d-9144-26637787a1ec");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "99deb2e8-7cab-4013-a43e-0a8d55308419", "83c4eefe-3f50-458d-a227-21f6a7806ab1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99deb2e8-7cab-4013-a43e-0a8d55308419");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "83c4eefe-3f50-458d-a227-21f6a7806ab1");
        }
    }
}
