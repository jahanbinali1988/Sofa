using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _12720201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: new Guid("b70d992c-2b43-496a-9981-3578e2d0ec4c"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 7, 18, 36, 54, 827, DateTimeKind.Local).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: new Guid("ccdd20d4-b2a0-455a-8f7a-168503776b82"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 7, 18, 36, 54, 826, DateTimeKind.Local).AddTicks(8099));

            migrationBuilder.UpdateData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("e9a52e3d-27aa-4726-a1a9-bf90b6cc2357"),
                columns: new[] { "Code", "CreateDate", "Description", "WebsiteUrl" },
                values: new object[] { "7e042a43-c35f-4e19-8ab2-c04a7e02ae9c", new DateTime(2020, 12, 7, 18, 36, 54, 825, DateTimeKind.Local).AddTicks(9360), "51eb93fa-c343-42c9-a775-9aeecf79f2aa", "025e5dc2-1a9c-4158-85ce-59c6d08b14f1" });

            migrationBuilder.UpdateData(
                table: "LessonPlan",
                keyColumn: "Id",
                keyValue: new Guid("0908ec03-9f07-426a-a26c-78cac8646545"),
                columns: new[] { "CreateDate", "SessionId" },
                values: new object[] { new DateTime(2020, 12, 7, 18, 36, 54, 829, DateTimeKind.Local).AddTicks(1412), new Guid("49f4c5f7-d568-449c-9b5f-4d5b987e1e59") });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: new Guid("b0108b2c-5837-4f22-b78d-857bc22f9554"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 7, 18, 36, 54, 830, DateTimeKind.Local).AddTicks(6716));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: new Guid("49f4c5f7-d568-449c-9b5f-4d5b987e1e59"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 7, 18, 36, 54, 829, DateTimeKind.Local).AddTicks(7413));

            migrationBuilder.UpdateData(
                table: "Term",
                keyColumn: "Id",
                keyValue: new Guid("21b8dc7f-9d87-409d-9ec1-46287e7a6559"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 7, 18, 36, 54, 828, DateTimeKind.Local).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 7, 18, 36, 54, 801, DateTimeKind.Local).AddTicks(8722));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 7, 18, 36, 54, 812, DateTimeKind.Local).AddTicks(7963));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 7, 18, 36, 54, 788, DateTimeKind.Local).AddTicks(4406));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: new Guid("b70d992c-2b43-496a-9981-3578e2d0ec4c"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 6, 17, 46, 28, 290, DateTimeKind.Local).AddTicks(310));

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: new Guid("ccdd20d4-b2a0-455a-8f7a-168503776b82"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 6, 17, 46, 28, 289, DateTimeKind.Local).AddTicks(3237));

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
                columns: new[] { "CreateDate", "SessionId" },
                values: new object[] { new DateTime(2020, 12, 6, 17, 46, 28, 291, DateTimeKind.Local).AddTicks(6629), new Guid("00000000-0000-0000-0000-000000000000") });

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
    }
}
