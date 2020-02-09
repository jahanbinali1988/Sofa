using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class cm1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 2, 6, 9, 21, 4, 571, DateTimeKind.Local).AddTicks(8617), new DateTime(2020, 2, 6, 9, 21, 4, 571, DateTimeKind.Local).AddTicks(8685) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 2, 6, 9, 21, 4, 581, DateTimeKind.Local).AddTicks(9438), new DateTime(2020, 2, 6, 9, 21, 4, 581, DateTimeKind.Local).AddTicks(9474) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 2, 6, 9, 21, 4, 557, DateTimeKind.Local).AddTicks(8635), new DateTime(2020, 2, 6, 9, 21, 4, 558, DateTimeKind.Local).AddTicks(2599) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 2, 6, 8, 56, 23, 328, DateTimeKind.Local).AddTicks(3478), new DateTime(2020, 2, 6, 8, 56, 23, 328, DateTimeKind.Local).AddTicks(3549) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 2, 6, 8, 56, 23, 337, DateTimeKind.Local).AddTicks(3779), new DateTime(2020, 2, 6, 8, 56, 23, 337, DateTimeKind.Local).AddTicks(3791) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 2, 6, 8, 56, 23, 288, DateTimeKind.Local).AddTicks(8037), new DateTime(2020, 2, 6, 8, 56, 23, 289, DateTimeKind.Local).AddTicks(1878) });
        }
    }
}
