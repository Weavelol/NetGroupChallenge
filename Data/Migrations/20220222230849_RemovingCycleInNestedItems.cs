using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class RemovingCycleInNestedItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5092bbe7-8cb1-482d-abae-2dcb79a68226");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3f56bff5-24ce-4960-ad2e-3d43b8fd8e9d", "c4e2b262-16d0-4b83-b095-033ccd8de5f0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f56bff5-24ce-4960-ad2e-3d43b8fd8e9d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4e2b262-16d0-4b83-b095-033ccd8de5f0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4aab17ab-3f97-4048-ab19-10e4772a4d27", "bc95edd3-4c8b-48f3-aeab-e10148f8b091", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f97da49-d34f-40d1-a3d9-edbf91b64fc1", "cbdd9b66-669e-4d21-9621-cc31d9ed5f45", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "43fdd186-539b-4013-ae27-d3d0400cd818", 0, "c2da878d-85a1-418b-b083-1f2b08f675d1", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEBm/0edKiWhJOvhTR51WUms+iEMIFkcdRf6I0tqZgKWIO+j7i+G2yUxdVVuVnW9FVA==", null, false, "9910b74a-395b-450b-9ff5-276e0167d215", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4aab17ab-3f97-4048-ab19-10e4772a4d27", "43fdd186-539b-4013-ae27-d3d0400cd818" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f97da49-d34f-40d1-a3d9-edbf91b64fc1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4aab17ab-3f97-4048-ab19-10e4772a4d27", "43fdd186-539b-4013-ae27-d3d0400cd818" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aab17ab-3f97-4048-ab19-10e4772a4d27");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43fdd186-539b-4013-ae27-d3d0400cd818");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f56bff5-24ce-4960-ad2e-3d43b8fd8e9d", "8e4d370d-f361-4a0a-a81a-2f53bcb307a3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5092bbe7-8cb1-482d-abae-2dcb79a68226", "09c00c6b-faf4-4f09-86b8-368e9ce6a137", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c4e2b262-16d0-4b83-b095-033ccd8de5f0", 0, "e81b3584-8dc4-4981-8f56-9c4d683f68a6", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEIOlXuVTlWpp9c/TiD4QGrCvPkM3gqVNAJEKQmcKZbZ53JEscnPLybervz+X6JbPwg==", null, false, "dacde771-788d-40d6-9fc2-78115e47e557", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3f56bff5-24ce-4960-ad2e-3d43b8fd8e9d", "c4e2b262-16d0-4b83-b095-033ccd8de5f0" });
        }
    }
}
