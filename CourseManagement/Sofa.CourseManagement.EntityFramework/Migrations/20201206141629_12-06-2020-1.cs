using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _120620201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: new Guid("b70d992c-2b43-496a-9981-3578e2d0ec4c"),
                columns: new[] { "CreateDate", "Description" },
                values: new object[] { new DateTime(2020, 12, 6, 17, 46, 28, 290, DateTimeKind.Local).AddTicks(310), "" });

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: new Guid("ccdd20d4-b2a0-455a-8f7a-168503776b82"),
                columns: new[] { "CreateDate", "Description" },
                values: new object[] { new DateTime(2020, 12, 6, 17, 46, 28, 289, DateTimeKind.Local).AddTicks(3237), "" });

            migrationBuilder.UpdateData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("e9a52e3d-27aa-4726-a1a9-bf90b6cc2357"),
                columns: new[] { "Code", "CreateDate", "Description", "WebsiteUrl" },
                values: new object[] { "a5104a54-00a8-4ab7-8b88-dfd12d13668e", new DateTime(2020, 12, 6, 17, 46, 28, 288, DateTimeKind.Local).AddTicks(4419), "49685659-8124-4475-84f2-b3f031383dfc", "3b6b930f-63b9-44c1-8da7-a3dbb4421413" });

            migrationBuilder.UpdateData(
                table: "LessonPlan",
                keyColumn: "Id",
                keyValue: new Guid("0908ec03-9f07-426a-a26c-78cac8646545"),
                columns: new[] { "CreateDate", "Description" },
                values: new object[] { new DateTime(2020, 12, 6, 17, 46, 28, 291, DateTimeKind.Local).AddTicks(6629), "" });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: new Guid("b0108b2c-5837-4f22-b78d-857bc22f9554"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 6, 17, 46, 28, 293, DateTimeKind.Local).AddTicks(820));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: new Guid("49f4c5f7-d568-449c-9b5f-4d5b987e1e59"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 6, 17, 46, 28, 292, DateTimeKind.Local).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "Term",
                keyColumn: "Id",
                keyValue: new Guid("21b8dc7f-9d87-409d-9ec1-46287e7a6559"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 6, 17, 46, 28, 290, DateTimeKind.Local).AddTicks(8817));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 6, 17, 46, 28, 270, DateTimeKind.Local).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 6, 17, 46, 28, 279, DateTimeKind.Local).AddTicks(5766));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 6, 17, 46, 28, 230, DateTimeKind.Local).AddTicks(5040));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: new Guid("b70d992c-2b43-496a-9981-3578e2d0ec4c"),
                columns: new[] { "CreateDate", "Description" },
                values: new object[] { new DateTime(2020, 10, 6, 14, 30, 30, 659, DateTimeKind.Local).AddTicks(3468), null });

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: new Guid("ccdd20d4-b2a0-455a-8f7a-168503776b82"),
                columns: new[] { "CreateDate", "Description" },
                values: new object[] { new DateTime(2020, 10, 6, 14, 30, 30, 658, DateTimeKind.Local).AddTicks(8119), null });

            migrationBuilder.UpdateData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("e9a52e3d-27aa-4726-a1a9-bf90b6cc2357"),
                columns: new[] { "Code", "CreateDate", "Description", "WebsiteUrl" },
                values: new object[] { "65479c12-0fbc-4c78-862a-1872a4021797", new DateTime(2020, 10, 6, 14, 30, 30, 658, DateTimeKind.Local).AddTicks(1996), null, null });

            migrationBuilder.UpdateData(
                table: "LessonPlan",
                keyColumn: "Id",
                keyValue: new Guid("0908ec03-9f07-426a-a26c-78cac8646545"),
                columns: new[] { "CreateDate", "Description" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: new Guid("b0108b2c-5837-4f22-b78d-857bc22f9554"),
                column: "CreateDate",
                value: new DateTime(2020, 10, 6, 14, 30, 30, 661, DateTimeKind.Local).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: new Guid("49f4c5f7-d568-449c-9b5f-4d5b987e1e59"),
                column: "CreateDate",
                value: new DateTime(2020, 10, 6, 14, 30, 30, 660, DateTimeKind.Local).AddTicks(7220));

            migrationBuilder.UpdateData(
                table: "Term",
                keyColumn: "Id",
                keyValue: new Guid("21b8dc7f-9d87-409d-9ec1-46287e7a6559"),
                column: "CreateDate",
                value: new DateTime(2020, 10, 6, 14, 30, 30, 659, DateTimeKind.Local).AddTicks(8310));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                column: "CreateDate",
                value: new DateTime(2020, 10, 6, 14, 30, 30, 649, DateTimeKind.Local).AddTicks(4077));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                column: "CreateDate",
                value: new DateTime(2020, 10, 6, 14, 30, 30, 657, DateTimeKind.Local).AddTicks(8354));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                column: "CreateDate",
                value: new DateTime(2020, 10, 6, 14, 30, 30, 640, DateTimeKind.Local).AddTicks(5273));
        }
    }
}
