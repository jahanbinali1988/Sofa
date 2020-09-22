using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _092220203 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("5f3a1b34-0310-4253-9f14-77ca67dff811"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 17, 18, 50, 608, DateTimeKind.Local).AddTicks(8329), new DateTime(2020, 9, 22, 17, 18, 50, 608, DateTimeKind.Local).AddTicks(8474) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 17, 18, 50, 617, DateTimeKind.Local).AddTicks(9349), new DateTime(2020, 9, 22, 17, 18, 50, 617, DateTimeKind.Local).AddTicks(9384) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 17, 18, 50, 590, DateTimeKind.Local).AddTicks(1927), new DateTime(2020, 9, 22, 17, 18, 50, 590, DateTimeKind.Local).AddTicks(7533) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Institute",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "ModifyDate", "RowVersion", "Title" },
                values: new object[] { new Guid("5f3a1b34-0310-4253-9f14-77ca67dff811"), new DateTime(2020, 9, 22, 10, 59, 39, 461, DateTimeKind.Local).AddTicks(3844), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Default" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 10, 59, 39, 442, DateTimeKind.Local).AddTicks(6167), new DateTime(2020, 9, 22, 10, 59, 39, 442, DateTimeKind.Local).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 10, 59, 39, 452, DateTimeKind.Local).AddTicks(151), new DateTime(2020, 9, 22, 10, 59, 39, 452, DateTimeKind.Local).AddTicks(182) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 10, 59, 39, 421, DateTimeKind.Local).AddTicks(9905), new DateTime(2020, 9, 22, 10, 59, 39, 422, DateTimeKind.Local).AddTicks(3617) });
        }
    }
}
