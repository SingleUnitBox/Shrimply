using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shrimply.Migrations.AuthDb
{
    public partial class addnormalizedemailandusernameforsuperadminuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "63945fe9-2198-4fbc-95a2-8ed87d47e659",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "823a56b0-575a-45bf-bedc-22916c7dd843", "SUPERADMIN@SHRIMPLY.COM", "SUPERADMIN@SHRIMPLY.COM", "AQAAAAEAACcQAAAAENDp1zCxuqHOdzrddNX2MfKJjtaJpEMijuxmz0px5VXLqEUt8DHxxJt3JL0zX+RN5A==", "95a7a2b1-2c0c-43c1-98e6-f287c51c9f83" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "63945fe9-2198-4fbc-95a2-8ed87d47e659",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4012831d-4915-4833-afec-d264d86da335", null, null, "AQAAAAEAACcQAAAAEBxeZjlrbaRIVreLpivpHGKXr+ulK1C596UUlXLNA2KSyOz/2mVEiDTYlNyKfnGZ6w==", "5019e331-f248-460a-b838-bb22283cbbe6" });
        }
    }
}
