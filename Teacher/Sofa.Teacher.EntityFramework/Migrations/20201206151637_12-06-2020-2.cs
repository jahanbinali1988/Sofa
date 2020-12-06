using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.Teacher.EntityFramework.Migrations
{
    public partial class _120620202 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Syllabus_SyllabusId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Course_CourseId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Syllabus");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Post",
                newName: "LessonPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_CourseId",
                table: "Post",
                newName: "IX_Post_LessonPlanId");

            migrationBuilder.RenameColumn(
                name: "SyllabusId",
                table: "Course",
                newName: "FieldId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_SyllabusId",
                table: "Course",
                newName: "IX_Course_FieldId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Syllabus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Syllabus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SessionId",
                table: "Syllabus",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Post",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Post",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AgeRange",
                table: "Course",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Course",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Institute",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RowVersion = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institute", x => x.Id);
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
                    IsDeleted = table.Column<bool>(nullable: false),
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
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RowVersion = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
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
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RowVersion = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    TermId = table.Column<Guid>(nullable: false),
                    LessonPlanId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Session_Term_TermId",
                        column: x => x.TermId,
                        principalTable: "Term",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "Email", "Level", "ModifyDate", "PhoneNumber", "UserName" },
                values: new object[] { new DateTime(2020, 12, 6, 18, 46, 37, 185, DateTimeKind.Local).AddTicks(2877), "jahanbin.ali1988@gmail.com", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09224957626", "teacher" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "Email", "ModifyDate", "PhoneNumber", "UserName" },
                values: new object[] { new DateTime(2020, 12, 6, 18, 46, 37, 185, DateTimeKind.Local).AddTicks(3930), "jahanbin.ali1988@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09224957626", "sysadmin" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "Level", "ModifyDate", "UserName" },
                values: new object[] { new DateTime(2020, 12, 6, 18, 46, 37, 183, DateTimeKind.Local).AddTicks(6455), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sysadmin" });

            migrationBuilder.CreateIndex(
                name: "IX_Field_InstituteId",
                table: "Field",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_TermId",
                table: "Session",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_Term_CourseId",
                table: "Term",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Field_FieldId",
                table: "Course",
                column: "FieldId",
                principalTable: "Field",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Syllabus_LessonPlanId",
                table: "Post",
                column: "LessonPlanId",
                principalTable: "Syllabus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Field_FieldId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Syllabus_LessonPlanId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Institute");

            migrationBuilder.DropTable(
                name: "Term");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Syllabus");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Syllabus");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Syllabus");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "AgeRange",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "LessonPlanId",
                table: "Post",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_LessonPlanId",
                table: "Post",
                newName: "IX_Post_CourseId");

            migrationBuilder.RenameColumn(
                name: "FieldId",
                table: "Course",
                newName: "SyllabusId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_FieldId",
                table: "Course",
                newName: "IX_Course_SyllabusId");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Syllabus",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Order",
                table: "Course",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "Email", "Level", "ModifyDate", "PhoneNumber", "UserName" },
                values: new object[] { new DateTime(2020, 9, 14, 16, 59, 30, 196, DateTimeKind.Local).AddTicks(4334), "jahanbinali88@yahoo.com", 1, new DateTime(2020, 9, 14, 16, 59, 30, 196, DateTimeKind.Local).AddTicks(4423), "09389459731", "09389459731" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "Email", "ModifyDate", "PhoneNumber", "UserName" },
                values: new object[] { new DateTime(2020, 9, 14, 16, 59, 30, 196, DateTimeKind.Local).AddTicks(4482), "jahanbin.ali1988@yahoo.com", new DateTime(2020, 9, 14, 16, 59, 30, 196, DateTimeKind.Local).AddTicks(4490), "09370429731", "09370429731" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "Level", "ModifyDate", "UserName" },
                values: new object[] { new DateTime(2020, 9, 14, 16, 59, 30, 183, DateTimeKind.Local).AddTicks(2969), 2, new DateTime(2020, 9, 14, 16, 59, 30, 183, DateTimeKind.Local).AddTicks(4974), "09224957626" });

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Syllabus_SyllabusId",
                table: "Course",
                column: "SyllabusId",
                principalTable: "Syllabus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Course_CourseId",
                table: "Post",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
