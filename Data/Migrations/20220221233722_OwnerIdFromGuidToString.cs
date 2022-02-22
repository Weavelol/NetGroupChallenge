using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class OwnerIdFromGuidToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f00e7407-8039-4f71-a0dc-435ebef60292");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e760460e-ff31-4720-834b-9913f3edfb28", "97331484-b9af-4993-bb76-a2c7a602670a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e760460e-ff31-4720-834b-9913f3edfb28");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97331484-b9af-4993-bb76-a2c7a602670a");

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
                values: new object[] { "0690f2b0-c25b-4ebd-9f55-403ad81b8e51", "9b1c8066-b917-44b7-8805-4cc4158d7cae", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab9dea15-984b-43d2-91da-318b181bf381", "e3e5dfd3-6af8-423e-bb32-19dfa03f4f9d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5e58ecb6-191e-4d20-82c1-47605f01b748", 0, "d2293af9-24c6-4730-8662-00b1457ff221", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAENGxt0TSHhUyjSVGwOND93ziI9q4M7LYBCJ3lTZCzSkFPFv0z/m9uNlmP7i9A48H8w==", null, false, "8f1f020a-114c-4739-9464-951e41b18c10", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0690f2b0-c25b-4ebd-9f55-403ad81b8e51", "5e58ecb6-191e-4d20-82c1-47605f01b748" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab9dea15-984b-43d2-91da-318b181bf381");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0690f2b0-c25b-4ebd-9f55-403ad81b8e51", "5e58ecb6-191e-4d20-82c1-47605f01b748" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0690f2b0-c25b-4ebd-9f55-403ad81b8e51");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e58ecb6-191e-4d20-82c1-47605f01b748");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Storages",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e760460e-ff31-4720-834b-9913f3edfb28", "fc6dc397-f004-4739-80fb-381a362da59f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f00e7407-8039-4f71-a0dc-435ebef60292", "a2b01837-6a8f-44fb-b297-1bad21c87e3f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "97331484-b9af-4993-bb76-a2c7a602670a", 0, "e0a9d459-9553-4308-8834-c24c94aa334a", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEDky4EHGSl1Qo/RdUXjBnaH/yOR424qSShXCauTyldNpyWi4sGdiDJTcEOKi3oLLXQ==", null, false, "59c37a97-3814-4413-90db-7d30b8d85478", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e760460e-ff31-4720-834b-9913f3edfb28", "97331484-b9af-4993-bb76-a2c7a602670a" });
        }
    }
}
