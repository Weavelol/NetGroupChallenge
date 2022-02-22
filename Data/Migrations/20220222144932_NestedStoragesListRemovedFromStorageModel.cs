using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class NestedStoragesListRemovedFromStorageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b0efeb1-b5f7-4240-a4d1-0d3be7fa36e7");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94ec3e72-1422-4ae6-b2db-307348f02485", "c5e1a67a-48fa-4746-8291-f598819371d0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94ec3e72-1422-4ae6-b2db-307348f02485");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5e1a67a-48fa-4746-8291-f598819371d0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "327b6668-ae5b-4327-a8ee-0785b0d69c1c", "9ad580ec-14c6-4d51-94e5-e7664659f380", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d797028-c0fa-448a-8be4-020a8ea9fa92", "540a8fb4-5b8d-413a-abd0-b53753bcfa4b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6ce0c6f3-706a-4438-ac35-7b2c3301aeea", 0, "76132957-2210-4a6e-b6ed-b01234e07b61", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAECkOkY0e4Cwj77QVy+6KOhDRPvcXDucJStE+iVrcI5lxbNaK+lOhYpCBTPnhw9RJoA==", null, false, "8df29b72-b6eb-441d-bc5e-bbc0e0350320", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "327b6668-ae5b-4327-a8ee-0785b0d69c1c", "6ce0c6f3-706a-4438-ac35-7b2c3301aeea" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d797028-c0fa-448a-8be4-020a8ea9fa92");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "327b6668-ae5b-4327-a8ee-0785b0d69c1c", "6ce0c6f3-706a-4438-ac35-7b2c3301aeea" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "327b6668-ae5b-4327-a8ee-0785b0d69c1c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ce0c6f3-706a-4438-ac35-7b2c3301aeea");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8b0efeb1-b5f7-4240-a4d1-0d3be7fa36e7", "12d067ac-88d5-407c-850c-7948add14746", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "94ec3e72-1422-4ae6-b2db-307348f02485", "e1a5511a-739c-4941-bf41-7c7bc75cc283", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c5e1a67a-48fa-4746-8291-f598819371d0", 0, "cfbf5e99-913d-454f-aa8f-902146f28636", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAELBA4/pz7sgdVOmzY2lQrgrIGYpkTMS8MergUZT3LobGHZ+hyYaE0X8d+g1Z+IOTIA==", null, false, "54607c4a-d0f5-4723-b8cd-39ddf5255a63", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "94ec3e72-1422-4ae6-b2db-307348f02485", "c5e1a67a-48fa-4746-8291-f598819371d0" });
        }
    }
}
