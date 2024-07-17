using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backed_Developer_Project.InfraStructure.Migrations
{
    public partial class deleteIdentityRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Admin", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b72f8bf-e909-4ef5-b302-fa8e16c7c328", "AQAAAAEAACcQAAAAEPQYaYeXT4uj923NUeL9gLJKzPlYxabAE27DpPveOfTB3CcEl9aJ8mYJOtuJOwdAaw==", "9f4c534e-c428-44c6-8a56-1e686a7d7366" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "Admin", "00000000-0000-0000-0000-000000000000", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9b41902-1b79-45b3-8bd1-a5af8935dbd0", "AQAAAAEAACcQAAAAEM3XAISTF4NoHnW71k6/qz6dC6hEGUzflNGeClH1ZmfBUe95nNsm9tTAfJCWntqsEQ==", "cdbcdcfb-6a61-41f5-92ed-7cd17ac7111c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "Admin", "1" });
        }
    }
}
