using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ItemImageModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemsImages_ImageId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ImageId",
                table: "Items");

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
                values: new object[] { "026921dc-d870-4df3-bca3-58f82fc64654", "6bc5d1c5-8fd0-46b5-ac36-f65fb583b4d9", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f222d91-6b60-437b-9bfc-f0e09e187af3", "47d0aad5-63df-476e-8180-587ec90ce83a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d2045bb3-f96a-4e07-b642-e593c2e3cf13", 0, "47003665-1fe8-4f70-b395-4f7edcc94106", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAELngzQHoBsFdsyK+ivd2qlKNx2ZBgHi/pEMvdb7wYsouaYZaY7MYZ/nMFy1JbGGIdQ==", null, false, "9752a28d-e39a-4a82-87bb-37ffed69c6b9", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4f222d91-6b60-437b-9bfc-f0e09e187af3", "d2045bb3-f96a-4e07-b642-e593c2e3cf13" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsImages_Items_Id",
                table: "ItemsImages",
                column: "Id",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsImages_Items_Id",
                table: "ItemsImages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "026921dc-d870-4df3-bca3-58f82fc64654");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4f222d91-6b60-437b-9bfc-f0e09e187af3", "d2045bb3-f96a-4e07-b642-e593c2e3cf13" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f222d91-6b60-437b-9bfc-f0e09e187af3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2045bb3-f96a-4e07-b642-e593c2e3cf13");

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

            migrationBuilder.CreateIndex(
                name: "IX_Items_ImageId",
                table: "Items",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemsImages_ImageId",
                table: "Items",
                column: "ImageId",
                principalTable: "ItemsImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
