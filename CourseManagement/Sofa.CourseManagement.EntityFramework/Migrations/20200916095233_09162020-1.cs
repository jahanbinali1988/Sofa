using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _091620201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Institute",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RowVersion = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RowVersion = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
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
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    City = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    InstituteId = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => new { x.InstituteId, x.City, x.ZipCode });
                    table.ForeignKey(
                        name: "FK_Address_Institute_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RowVersion = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Order = table.Column<short>(nullable: false),
                    PostType = table.Column<int>(nullable: false),
                    LessonPlanId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_LessonPlan_LessonPlanId",
                        column: x => x.LessonPlanId,
                        principalTable: "LessonPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateDate", "Description", "Email", "FirstName", "IsActive", "LastName", "Level", "ModifyDate", "PasswordHash", "PhoneNumber", "Role", "RowVersion", "UserName" },
                values: new object[] { new Guid("731874e2-b89c-4509-819a-5b69396a336b"), new DateTime(2020, 9, 16, 14, 22, 32, 999, DateTimeKind.Local).AddTicks(7056), "", "jahanbin.ali1988@gmail.com", "Ali", true, "Jahanbin", 2, new DateTime(2020, 9, 16, 14, 22, 33, 0, DateTimeKind.Local).AddTicks(329), "JB661pQ8yCirbaGKuNu8wIZjd7/lq74u5bDYUaX6GW0=", "09224957626", 0, 0, "sysadmin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateDate", "Description", "Email", "FirstName", "IsActive", "LastName", "Level", "ModifyDate", "PasswordHash", "PhoneNumber", "Role", "RowVersion", "UserName" },
                values: new object[] { new Guid("253e472e-21ac-4864-b218-b364169d0611"), new DateTime(2020, 9, 16, 14, 22, 33, 23, DateTimeKind.Local).AddTicks(8733), "", "jahanbinali88@yahoo.com", "Ali", true, "Jahanbin", 2, new DateTime(2020, 9, 16, 14, 22, 33, 23, DateTimeKind.Local).AddTicks(8833), "JB661pQ8yCirbaGKuNu8wIZjd7/lq74u5bDYUaX6GW0=", "09224957626", 1, 0, "teacher" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateDate", "Description", "Email", "FirstName", "IsActive", "LastName", "Level", "ModifyDate", "PasswordHash", "PhoneNumber", "Role", "RowVersion", "UserName" },
                values: new object[] { new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"), new DateTime(2020, 9, 16, 14, 22, 33, 39, DateTimeKind.Local).AddTicks(342), "", "jahanbin.ali1988@yahoo.com", "Ali", true, "Jahanbin", 0, new DateTime(2020, 9, 16, 14, 22, 33, 39, DateTimeKind.Local).AddTicks(377), "JB661pQ8yCirbaGKuNu8wIZjd7/lq74u5bDYUaX6GW0=", "09224957626", 1, 0, "student" });

            migrationBuilder.CreateIndex(
                name: "IX_Post_LessonPlanId",
                table: "Post",
                column: "LessonPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Institute");

            migrationBuilder.DropTable(
                name: "LessonPlan");
        }
    }
}
