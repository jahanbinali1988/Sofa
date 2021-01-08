using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _1820211 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: new Guid("b70d992c-2b43-496a-9981-3578e2d0ec4c"),
                column: "CreateDate",
                value: new DateTime(2021, 1, 8, 16, 5, 14, 383, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: new Guid("ccdd20d4-b2a0-455a-8f7a-168503776b82"),
                column: "CreateDate",
                value: new DateTime(2021, 1, 8, 16, 5, 14, 382, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("e9a52e3d-27aa-4726-a1a9-bf90b6cc2357"),
                columns: new[] { "Code", "CreateDate", "Description", "WebsiteUrl" },
                values: new object[] { "0eb95b4d-7376-4804-b38f-e65ae71d963d", new DateTime(2021, 1, 8, 16, 5, 14, 381, DateTimeKind.Local).AddTicks(9208), "60605ebe-b498-42ea-ba8b-45b94cb35864", "fe6925fb-b7a1-4909-9465-9b2b4791927f" });

            migrationBuilder.UpdateData(
                table: "LessonPlan",
                keyColumn: "Id",
                keyValue: new Guid("0908ec03-9f07-426a-a26c-78cac8646545"),
                column: "CreateDate",
                value: new DateTime(2021, 1, 8, 16, 5, 14, 385, DateTimeKind.Local).AddTicks(1355));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: new Guid("b0108b2c-5837-4f22-b78d-857bc22f9554"),
                column: "CreateDate",
                value: new DateTime(2021, 1, 8, 16, 5, 14, 386, DateTimeKind.Local).AddTicks(6174));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: new Guid("49f4c5f7-d568-449c-9b5f-4d5b987e1e59"),
                column: "CreateDate",
                value: new DateTime(2021, 1, 8, 16, 5, 14, 385, DateTimeKind.Local).AddTicks(7914));

            migrationBuilder.UpdateData(
                table: "Term",
                keyColumn: "Id",
                keyValue: new Guid("21b8dc7f-9d87-409d-9ec1-46287e7a6559"),
                column: "CreateDate",
                value: new DateTime(2021, 1, 8, 16, 5, 14, 384, DateTimeKind.Local).AddTicks(3614));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                column: "CreateDate",
                value: new DateTime(2021, 1, 8, 16, 5, 14, 364, DateTimeKind.Local).AddTicks(7381));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                column: "CreateDate",
                value: new DateTime(2021, 1, 8, 16, 5, 14, 373, DateTimeKind.Local).AddTicks(1458));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                column: "CreateDate",
                value: new DateTime(2021, 1, 8, 16, 5, 14, 347, DateTimeKind.Local).AddTicks(3094));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: new Guid("b70d992c-2b43-496a-9981-3578e2d0ec4c"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 7, 18, 38, 32, 637, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: new Guid("ccdd20d4-b2a0-455a-8f7a-168503776b82"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 7, 18, 38, 32, 635, DateTimeKind.Local).AddTicks(9667));

            migrationBuilder.UpdateData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("e9a52e3d-27aa-4726-a1a9-bf90b6cc2357"),
                columns: new[] { "Code", "CreateDate", "Description", "WebsiteUrl" },
                values: new object[] { "5efb613e-9a32-4d00-a5f9-966974fe0396", new DateTime(2020, 12, 7, 18, 38, 32, 634, DateTimeKind.Local).AddTicks(9914), "2f0e46c9-6236-44b4-b14e-ac2e5cef4d13", "2f52352f-3f29-4802-8025-eabdfde4534b" });

            migrationBuilder.UpdateData(
                table: "LessonPlan",
                keyColumn: "Id",
                keyValue: new Guid("0908ec03-9f07-426a-a26c-78cac8646545"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 7, 18, 38, 32, 639, DateTimeKind.Local).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: new Guid("b0108b2c-5837-4f22-b78d-857bc22f9554"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 7, 18, 38, 32, 642, DateTimeKind.Local).AddTicks(2050));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: new Guid("49f4c5f7-d568-449c-9b5f-4d5b987e1e59"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 7, 18, 38, 32, 640, DateTimeKind.Local).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "Term",
                keyColumn: "Id",
                keyValue: new Guid("21b8dc7f-9d87-409d-9ec1-46287e7a6559"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 7, 18, 38, 32, 638, DateTimeKind.Local).AddTicks(5539));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 7, 18, 38, 32, 608, DateTimeKind.Local).AddTicks(1963));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 7, 18, 38, 32, 622, DateTimeKind.Local).AddTicks(2867));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 7, 18, 38, 32, 589, DateTimeKind.Local).AddTicks(5040));
        }
    }
}
