using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _091620202 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Institute",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "ModifyDate", "RowVersion", "Title" },
                values: new object[] { new Guid("4091cdfe-3d31-4fc1-973e-bd76037fb8ed"), new DateTime(2020, 9, 16, 15, 26, 46, 61, DateTimeKind.Local).AddTicks(1136), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Default" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 16, 15, 26, 46, 41, DateTimeKind.Local).AddTicks(5921), new DateTime(2020, 9, 16, 15, 26, 46, 41, DateTimeKind.Local).AddTicks(5980) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 16, 15, 26, 46, 51, DateTimeKind.Local).AddTicks(6796), new DateTime(2020, 9, 16, 15, 26, 46, 51, DateTimeKind.Local).AddTicks(6837) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 16, 15, 26, 46, 28, DateTimeKind.Local).AddTicks(143), new DateTime(2020, 9, 16, 15, 26, 46, 28, DateTimeKind.Local).AddTicks(2378) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("4091cdfe-3d31-4fc1-973e-bd76037fb8ed"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 16, 14, 22, 33, 23, DateTimeKind.Local).AddTicks(8733), new DateTime(2020, 9, 16, 14, 22, 33, 23, DateTimeKind.Local).AddTicks(8833) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 16, 14, 22, 33, 39, DateTimeKind.Local).AddTicks(342), new DateTime(2020, 9, 16, 14, 22, 33, 39, DateTimeKind.Local).AddTicks(377) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 16, 14, 22, 32, 999, DateTimeKind.Local).AddTicks(7056), new DateTime(2020, 9, 16, 14, 22, 33, 0, DateTimeKind.Local).AddTicks(329) });
        }
    }
}
