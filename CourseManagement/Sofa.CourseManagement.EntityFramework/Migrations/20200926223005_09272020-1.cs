using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _092720201 : Migration
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
                    Title = table.Column<string>(nullable: true),
                    WebsiteUrl = table.Column<string>(nullable: true),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_State = table.Column<string>(nullable: true),
                    Address_Country = table.Column<string>(nullable: true),
                    Address_ZipCode = table.Column<string>(nullable: true)
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
                    Level = table.Column<int>(nullable: false),
                    SessionId = table.Column<Guid>(nullable: false)
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
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RowVersion = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    InstituteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Field_Institute_InstituteId",
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
                    AgeRange = table.Column<string>(nullable: true),
                    FieldId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Field_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Term",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RowVersion = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    CourseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Term", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Term_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RowVersion = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    TermId = table.Column<Guid>(nullable: false),
                    LessonPlanId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Session_LessonPlan_LessonPlanId",
                        column: x => x.LessonPlanId,
                        principalTable: "LessonPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Session_Term_TermId",
                        column: x => x.TermId,
                        principalTable: "Term",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateDate", "Description", "Email", "FirstName", "IsActive", "LastName", "Level", "ModifyDate", "PasswordHash", "PhoneNumber", "Role", "RowVersion", "UserName" },
                values: new object[] { new Guid("731874e2-b89c-4509-819a-5b69396a336b"), new DateTime(2020, 9, 27, 2, 0, 5, 100, DateTimeKind.Local).AddTicks(5016), "", "jahanbin.ali1988@gmail.com", "Ali", true, "Jahanbin", 2, new DateTime(2020, 9, 27, 2, 0, 5, 100, DateTimeKind.Local).AddTicks(8659), "JB661pQ8yCirbaGKuNu8wIZjd7/lq74u5bDYUaX6GW0=", "09224957626", 0, 0, "sysadmin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateDate", "Description", "Email", "FirstName", "IsActive", "LastName", "Level", "ModifyDate", "PasswordHash", "PhoneNumber", "Role", "RowVersion", "UserName" },
                values: new object[] { new Guid("253e472e-21ac-4864-b218-b364169d0611"), new DateTime(2020, 9, 27, 2, 0, 5, 112, DateTimeKind.Local).AddTicks(8190), "", "jahanbinali88@yahoo.com", "Ali", true, "Jahanbin", 2, new DateTime(2020, 9, 27, 2, 0, 5, 112, DateTimeKind.Local).AddTicks(8324), "JB661pQ8yCirbaGKuNu8wIZjd7/lq74u5bDYUaX6GW0=", "09224957626", 1, 0, "teacher" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateDate", "Description", "Email", "FirstName", "IsActive", "LastName", "Level", "ModifyDate", "PasswordHash", "PhoneNumber", "Role", "RowVersion", "UserName" },
                values: new object[] { new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"), new DateTime(2020, 9, 27, 2, 0, 5, 121, DateTimeKind.Local).AddTicks(2159), "", "jahanbin.ali1988@yahoo.com", "Ali", true, "Jahanbin", 0, new DateTime(2020, 9, 27, 2, 0, 5, 121, DateTimeKind.Local).AddTicks(2180), "JB661pQ8yCirbaGKuNu8wIZjd7/lq74u5bDYUaX6GW0=", "09224957626", 1, 0, "student" });

            migrationBuilder.CreateIndex(
                name: "IX_Course_FieldId",
                table: "Course",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Field_InstituteId",
                table: "Field",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_LessonPlanId",
                table: "Post",
                column: "LessonPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_LessonPlanId",
                table: "Session",
                column: "LessonPlanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Session_TermId",
                table: "Session",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_Term_CourseId",
                table: "Term",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "LessonPlan");

            migrationBuilder.DropTable(
                name: "Term");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "Institute");
        }
    }
}
