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
                values: new object[] { "5d4695c5-ebeb-4c7d-9144-26637787a1ec", "e47e980c-4145-437e-8921-1ba076c13b0e", "Client", "CLIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99deb2e8-7cab-4013-a43e-0a8d55308419", "29c3415f-3bc3-4a80-a99e-c688693cbdb8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "83c4eefe-3f50-458d-a227-21f6a7806ab1", 0, "none", "75872849-5693-473b-ad2b-2a0fa6c16efd", "admin@gmail.com", true, "Admin", false, "Admin", false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEPnmHi16tVm0kSiEcUjq8kqLZ+Jtv/RrgU507N3ZyAzr05fzNjuRZaiRsVHNANJaTw==", "+111111111111", true, "67ca990c-a58a-4408-963c-607078654698", false, "Admin" });

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
