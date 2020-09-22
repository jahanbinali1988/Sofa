using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _092220204 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 18, 2, 20, 89, DateTimeKind.Local).AddTicks(42), new DateTime(2020, 9, 22, 18, 2, 20, 89, DateTimeKind.Local).AddTicks(167) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 18, 2, 20, 97, DateTimeKind.Local).AddTicks(3493), new DateTime(2020, 9, 22, 18, 2, 20, 97, DateTimeKind.Local).AddTicks(3517) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 18, 2, 20, 76, DateTimeKind.Local).AddTicks(4956), new DateTime(2020, 9, 22, 18, 2, 20, 76, DateTimeKind.Local).AddTicks(9029) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
