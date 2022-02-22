using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class StoragePathAddedToStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "StoragePath",
                table: "Storages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "08b9ff0b-4acd-4e3d-88c9-7fb9aa90c0ae", "1768b99e-8693-4e18-a4d2-a747f52996eb", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab0159c3-452f-4636-aa59-c029a957f441", "566d9ece-e58b-41f7-afac-eae48b1ddbc0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7298ad2b-fb7f-40cc-9d18-8ed4b6bd06f6", 0, "fcc2c732-a985-4d0a-91a1-18d253912835", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEAse0rJWOviUBBdvHgZ7deo8YBZOf/47K76fF6IYGKHFH85gR/N6wOXo8SQuYq/JgQ==", null, false, "4ef5242b-c1aa-4dd5-8cfc-b309999bc614", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ab0159c3-452f-4636-aa59-c029a957f441", "7298ad2b-fb7f-40cc-9d18-8ed4b6bd06f6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08b9ff0b-4acd-4e3d-88c9-7fb9aa90c0ae");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ab0159c3-452f-4636-aa59-c029a957f441", "7298ad2b-fb7f-40cc-9d18-8ed4b6bd06f6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab0159c3-452f-4636-aa59-c029a957f441");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7298ad2b-fb7f-40cc-9d18-8ed4b6bd06f6");

            migrationBuilder.DropColumn(
                name: "StoragePath",
                table: "Storages");

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
    }
}
