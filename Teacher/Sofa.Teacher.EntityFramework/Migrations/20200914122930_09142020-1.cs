using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.Teacher.EntityFramework.Migrations
{
    public partial class _091420201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Syllabus",
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
                    table.PrimaryKey("PK_Syllabus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
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
                    SyllabusId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Syllabus_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "Syllabus",
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
                    CourseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Email = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    LastCourseId = table.Column<Guid>(nullable: true),
                    CourseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CourseId", "CreateDate", "Description", "Email", "FirstName", "IsActive", "LastCourseId", "LastName", "Level", "ModifyDate", "PhoneNumber", "RowVersion", "UserName" },
                values: new object[] { new Guid("731874e2-b89c-4509-819a-5b69396a336b"), null, new DateTime(2020, 9, 14, 16, 59, 30, 183, DateTimeKind.Local).AddTicks(2969), "", "jahanbin.ali1988@gmail.com", "Ali", true, new Guid("00000000-0000-0000-0000-000000000000"), "Jahanbin", 2, new DateTime(2020, 9, 14, 16, 59, 30, 183, DateTimeKind.Local).AddTicks(4974), "09224957626", 0, "09224957626" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CourseId", "CreateDate", "Description", "Email", "FirstName", "IsActive", "LastCourseId", "LastName", "Level", "ModifyDate", "PhoneNumber", "RowVersion", "UserName" },
                values: new object[] { new Guid("253e472e-21ac-4864-b218-b364169d0611"), null, new DateTime(2020, 9, 14, 16, 59, 30, 196, DateTimeKind.Local).AddTicks(4334), "", "jahanbinali88@yahoo.com", "Ali", true, new Guid("00000000-0000-0000-0000-000000000000"), "Jahanbin", 1, new DateTime(2020, 9, 14, 16, 59, 30, 196, DateTimeKind.Local).AddTicks(4423), "09389459731", 0, "09389459731" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CourseId", "CreateDate", "Description", "Email", "FirstName", "IsActive", "LastCourseId", "LastName", "Level", "ModifyDate", "PhoneNumber", "RowVersion", "UserName" },
                values: new object[] { new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"), null, new DateTime(2020, 9, 14, 16, 59, 30, 196, DateTimeKind.Local).AddTicks(4482), "", "jahanbin.ali1988@yahoo.com", "Ali", true, new Guid("00000000-0000-0000-0000-000000000000"), "Jahanbin", 0, new DateTime(2020, 9, 14, 16, 59, 30, 196, DateTimeKind.Local).AddTicks(4490), "09370429731", 0, "09370429731" });

            migrationBuilder.CreateIndex(
                name: "IX_Course_SyllabusId",
                table: "Course",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CourseId",
                table: "Post",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CourseId",
                table: "User",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Syllabus");
        }
    }
}
