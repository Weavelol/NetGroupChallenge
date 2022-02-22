using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ModelsFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsImages_ItemsImages_ItemImageId",
                table: "ItemsImages");

            migrationBuilder.DropIndex(
                name: "IX_ItemsImages_ItemImageId",
                table: "ItemsImages");

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
                name: "ItemImageId",
                table: "ItemsImages");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "ItemImageId",
                table: "ItemsImages",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ItemsImages_ItemImageId",
                table: "ItemsImages",
                column: "ItemImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsImages_ItemsImages_ItemImageId",
                table: "ItemsImages",
                column: "ItemImageId",
                principalTable: "ItemsImages",
                principalColumn: "Id");
        }
    }
}
