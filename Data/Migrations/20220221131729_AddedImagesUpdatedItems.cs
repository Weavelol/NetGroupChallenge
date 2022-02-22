using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddedImagesUpdatedItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62b1faba-b2ce-4220-b02e-dacdf7c97513");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a47d88d7-4b74-43e7-bf9d-76485142ea67", "1850f59c-a670-4652-8cfe-2c44d1240288" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a47d88d7-4b74-43e7-bf9d-76485142ea67");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1850f59c-a670-4652-8cfe-2c44d1240288");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Items");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ItemsImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsImages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "646ce4ec-95e1-4606-a23c-9b248dbfe506", "691f3c53-e948-4a21-8d9e-d0dc24dfd57b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99e16235-4e4c-485d-850a-89a05272959e", "20dfc418-0705-4919-8cab-9b8e1ca15e2c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fb660b27-0683-472f-9899-c35d2aa222a4", 0, "5b08d180-3cce-44e5-a0ad-666da3410ec9", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEPdptORcpIwvzwuSGycYqO8q9uHbCWkQQQnFmmqt16CuXXZu8UpkuQjdRpxaWYlYaQ==", null, false, "0dfc8671-7eb9-4321-a515-679556e2c0a5", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "646ce4ec-95e1-4606-a23c-9b248dbfe506", "fb660b27-0683-472f-9899-c35d2aa222a4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsImages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99e16235-4e4c-485d-850a-89a05272959e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "646ce4ec-95e1-4606-a23c-9b248dbfe506", "fb660b27-0683-472f-9899-c35d2aa222a4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "646ce4ec-95e1-4606-a23c-9b248dbfe506");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb660b27-0683-472f-9899-c35d2aa222a4");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62b1faba-b2ce-4220-b02e-dacdf7c97513", "06d1e198-9b50-413f-9ca8-f7bbf7c3617e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a47d88d7-4b74-43e7-bf9d-76485142ea67", "597cc3bd-2bb1-474d-8629-f0fb8bfab7b2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1850f59c-a670-4652-8cfe-2c44d1240288", 0, "9b3f57cc-d67e-4d86-a7c8-fadbb49d8e38", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEDI9DNEwuHOZPG9W6gNVHFga3pD8eUFI410nR0OCVfwXkXABVSn+1gFWY5LW9oClBQ==", null, false, "e29dab5a-f06e-450a-bc1f-b48381c8ed8d", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a47d88d7-4b74-43e7-bf9d-76485142ea67", "1850f59c-a670-4652-8cfe-2c44d1240288" });
        }
    }
}
