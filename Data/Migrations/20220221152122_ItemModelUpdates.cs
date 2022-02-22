using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ItemModelUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Storages",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Classification",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemOwner",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d6e6dbe-55b2-4e00-b287-721013261b34", "8eb0811b-76c4-43a8-b3fb-8ffaa2832a02", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a0ed1835-ee9f-4cdf-8e36-90e6191fcc3b", "f8019bb2-d896-4d7e-b5ce-b2f306e9fee8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "94af7ccd-8509-4cb0-b809-e2721aca8a25", 0, "4088b0bf-2c1e-4871-8715-6f7eba28a422", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEF567Z2IoSOYL49cTV4B7MRmLE6ntFaz6v7xEwbSFsH3a4Fb2OpVdfVk0pi4xuU7oA==", null, false, "f46261e6-2994-4be5-bd73-afe624583cf8", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2d6e6dbe-55b2-4e00-b287-721013261b34", "94af7ccd-8509-4cb0-b809-e2721aca8a25" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0ed1835-ee9f-4cdf-8e36-90e6191fcc3b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d6e6dbe-55b2-4e00-b287-721013261b34", "94af7ccd-8509-4cb0-b809-e2721aca8a25" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d6e6dbe-55b2-4e00-b287-721013261b34");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "94af7ccd-8509-4cb0-b809-e2721aca8a25");

            migrationBuilder.DropColumn(
                name: "Classification",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemOwner",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Storages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
    }
}
