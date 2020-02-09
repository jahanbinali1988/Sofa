using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.Teacher.EntityFramework.Migrations
{
    public partial class _292020tb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "LastCourseId",
                table: "User",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 2, 9, 3, 30, 5, 104, DateTimeKind.Local).AddTicks(5696), new DateTime(2020, 2, 9, 3, 30, 5, 104, DateTimeKind.Local).AddTicks(5736) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 2, 9, 3, 30, 5, 104, DateTimeKind.Local).AddTicks(5767), new DateTime(2020, 2, 9, 3, 30, 5, 104, DateTimeKind.Local).AddTicks(5775) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 2, 9, 3, 30, 5, 103, DateTimeKind.Local).AddTicks(7801), new DateTime(2020, 2, 9, 3, 30, 5, 104, DateTimeKind.Local).AddTicks(1832) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "LastCourseId",
                table: "User",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 2, 6, 10, 4, 28, 287, DateTimeKind.Local).AddTicks(767), new DateTime(2020, 2, 6, 10, 4, 28, 287, DateTimeKind.Local).AddTicks(807) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 2, 6, 10, 4, 28, 287, DateTimeKind.Local).AddTicks(842), new DateTime(2020, 2, 6, 10, 4, 28, 287, DateTimeKind.Local).AddTicks(846) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 2, 6, 10, 4, 28, 286, DateTimeKind.Local).AddTicks(2939), new DateTime(2020, 2, 6, 10, 4, 28, 286, DateTimeKind.Local).AddTicks(6966) });
        }
    }
}
