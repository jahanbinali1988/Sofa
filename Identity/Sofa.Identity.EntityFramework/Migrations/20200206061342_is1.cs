using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.Identity.EntityFramework.Migrations
{
    public partial class is1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IDN_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RowVersion = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    UserCurrentSyllabusId = table.Column<Guid>(nullable: true),
                    UserCurrentCourseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDN_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IDN_User",
                columns: new[] { "Id", "CreateDate", "Description", "Email", "FirstName", "IsActive", "LastName", "Level", "ModifyDate", "PasswordHash", "PhoneNumber", "Role", "RowVersion", "UserCurrentCourseId", "UserCurrentSyllabusId", "UserName" },
                values: new object[] { new Guid("731874e2-b89c-4509-819a-5b69396a336b"), new DateTime(2020, 2, 6, 9, 43, 42, 504, DateTimeKind.Local).AddTicks(8307), "", "jahanbin.ali1988@gmail.com", "Ali", true, "Jahanbin", 0, new DateTime(2020, 2, 6, 9, 43, 42, 507, DateTimeKind.Local).AddTicks(279), "JB661pQ8yCirbaGKuNu8wIZjd7/lq74u5bDYUaX6GW0=", "09224957626", 0, 0, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), "sysadmin" });

            migrationBuilder.InsertData(
                table: "IDN_User",
                columns: new[] { "Id", "CreateDate", "Description", "Email", "FirstName", "IsActive", "LastName", "Level", "ModifyDate", "PasswordHash", "PhoneNumber", "Role", "RowVersion", "UserCurrentCourseId", "UserCurrentSyllabusId", "UserName" },
                values: new object[] { new Guid("253e472e-21ac-4864-b218-b364169d0611"), new DateTime(2020, 2, 6, 9, 43, 42, 520, DateTimeKind.Local).AddTicks(5951), "", "jahanbinali88@yahoo.com", "Ali", true, "Jahanbin", 0, new DateTime(2020, 2, 6, 9, 43, 42, 520, DateTimeKind.Local).AddTicks(6014), "JB661pQ8yCirbaGKuNu8wIZjd7/lq74u5bDYUaX6GW0=", "09224957626", 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), "teacher" });

            migrationBuilder.InsertData(
                table: "IDN_User",
                columns: new[] { "Id", "CreateDate", "Description", "Email", "FirstName", "IsActive", "LastName", "Level", "ModifyDate", "PasswordHash", "PhoneNumber", "Role", "RowVersion", "UserCurrentCourseId", "UserCurrentSyllabusId", "UserName" },
                values: new object[] { new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"), new DateTime(2020, 2, 6, 9, 43, 42, 530, DateTimeKind.Local).AddTicks(1185), "", "jahanbin.ali1988@yahoo.com", "Ali", true, "Jahanbin", 0, new DateTime(2020, 2, 6, 9, 43, 42, 530, DateTimeKind.Local).AddTicks(1201), "JB661pQ8yCirbaGKuNu8wIZjd7/lq74u5bDYUaX6GW0=", "09224957626", 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), "student" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IDN_User");
        }
    }
}
