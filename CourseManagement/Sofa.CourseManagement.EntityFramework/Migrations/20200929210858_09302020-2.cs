using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _093020202 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Institute",
                columns: new[] { "Id", "Code", "CreateDate", "Description", "IsActive", "ModifyDate", "RowVersion", "Title", "WebsiteUrl" },
                values: new object[] { new Guid("e9a52e3d-27aa-4726-a1a9-bf90b6cc2357"), "0daffaaa-037e-44da-bd14-254262138acc", new DateTime(2020, 9, 30, 0, 38, 57, 749, DateTimeKind.Local).AddTicks(2752), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "TestInstitute", null });

            migrationBuilder.InsertData(
                table: "LessonPlan",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "Level", "ModifyDate", "RowVersion", "SessionId" },
                values: new object[] { new Guid("0908ec03-9f07-426a-a26c-78cac8646545"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 30, 0, 38, 57, 731, DateTimeKind.Local).AddTicks(3369), new DateTime(2020, 9, 30, 0, 38, 57, 731, DateTimeKind.Local).AddTicks(3506) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 30, 0, 38, 57, 740, DateTimeKind.Local).AddTicks(1739), new DateTime(2020, 9, 30, 0, 38, 57, 740, DateTimeKind.Local).AddTicks(1792) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 30, 0, 38, 57, 718, DateTimeKind.Local).AddTicks(6801), new DateTime(2020, 9, 30, 0, 38, 57, 719, DateTimeKind.Local).AddTicks(638) });

            migrationBuilder.InsertData(
                table: "Field",
                columns: new[] { "Id", "CreateDate", "Description", "InstituteId", "IsActive", "ModifyDate", "RowVersion", "Title" },
                values: new object[] { new Guid("ccdd20d4-b2a0-455a-8f7a-168503776b82"), new DateTime(2020, 9, 30, 0, 38, 57, 749, DateTimeKind.Local).AddTicks(8035), null, new Guid("e9a52e3d-27aa-4726-a1a9-bf90b6cc2357"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "DefaultField" });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "LessonPlanId", "ModifyDate", "Order", "PostType", "RowVersion", "Title" },
                values: new object[] { new Guid("b0108b2c-5837-4f22-b78d-857bc22f9554"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, new Guid("0908ec03-9f07-426a-a26c-78cac8646545"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, 0, 0, "DefaultPost" });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "AgeRange", "CreateDate", "Description", "FieldId", "IsActive", "ModifyDate", "RowVersion", "Title" },
                values: new object[] { new Guid("b70d992c-2b43-496a-9981-3578e2d0ec4c"), "", new DateTime(2020, 9, 30, 0, 38, 57, 750, DateTimeKind.Local).AddTicks(3210), null, new Guid("ccdd20d4-b2a0-455a-8f7a-168503776b82"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "DefaultCourse" });

            migrationBuilder.InsertData(
                table: "Term",
                columns: new[] { "Id", "CourseId", "CreateDate", "Description", "IsActive", "ModifyDate", "RowVersion", "Title" },
                values: new object[] { new Guid("21b8dc7f-9d87-409d-9ec1-46287e7a6559"), new Guid("b70d992c-2b43-496a-9981-3578e2d0ec4c"), new DateTime(2020, 9, 30, 0, 38, 57, 750, DateTimeKind.Local).AddTicks(7455), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "DefaultTerm" });

            migrationBuilder.InsertData(
                table: "Session",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "LessonPlanId", "ModifyDate", "RowVersion", "TermId", "Title" },
                values: new object[] { new Guid("49f4c5f7-d568-449c-9b5f-4d5b987e1e59"), new DateTime(2020, 9, 30, 0, 38, 57, 751, DateTimeKind.Local).AddTicks(6496), null, true, new Guid("0908ec03-9f07-426a-a26c-78cac8646545"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("21b8dc7f-9d87-409d-9ec1-46287e7a6559"), "DefaultSession" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: new Guid("b0108b2c-5837-4f22-b78d-857bc22f9554"));

            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "Id",
                keyValue: new Guid("49f4c5f7-d568-449c-9b5f-4d5b987e1e59"));

            migrationBuilder.DeleteData(
                table: "LessonPlan",
                keyColumn: "Id",
                keyValue: new Guid("0908ec03-9f07-426a-a26c-78cac8646545"));

            migrationBuilder.DeleteData(
                table: "Term",
                keyColumn: "Id",
                keyValue: new Guid("21b8dc7f-9d87-409d-9ec1-46287e7a6559"));

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: new Guid("b70d992c-2b43-496a-9981-3578e2d0ec4c"));

            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "Id",
                keyValue: new Guid("ccdd20d4-b2a0-455a-8f7a-168503776b82"));

            migrationBuilder.DeleteData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("e9a52e3d-27aa-4726-a1a9-bf90b6cc2357"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 30, 0, 13, 11, 638, DateTimeKind.Local).AddTicks(9398), new DateTime(2020, 9, 30, 0, 13, 11, 638, DateTimeKind.Local).AddTicks(9541) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 30, 0, 13, 11, 647, DateTimeKind.Local).AddTicks(2893), new DateTime(2020, 9, 30, 0, 13, 11, 647, DateTimeKind.Local).AddTicks(2908) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 30, 0, 13, 11, 605, DateTimeKind.Local).AddTicks(3000), new DateTime(2020, 9, 30, 0, 13, 11, 605, DateTimeKind.Local).AddTicks(6928) });
        }
    }
}
