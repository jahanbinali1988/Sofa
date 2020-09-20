using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _091820205 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("134b88af-218c-4674-80c0-7ab2be535a1c"));

            migrationBuilder.InsertData(
                table: "Institute",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "ModifyDate", "RowVersion", "Title" },
                values: new object[] { new Guid("50ed6547-084e-480c-be7d-4ccece84958e"), new DateTime(2020, 9, 19, 0, 43, 10, 259, DateTimeKind.Local).AddTicks(7624), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Default" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 19, 0, 43, 10, 242, DateTimeKind.Local).AddTicks(5336), new DateTime(2020, 9, 19, 0, 43, 10, 242, DateTimeKind.Local).AddTicks(5456) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 19, 0, 43, 10, 251, DateTimeKind.Local).AddTicks(1703), new DateTime(2020, 9, 19, 0, 43, 10, 251, DateTimeKind.Local).AddTicks(1720) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 19, 0, 43, 10, 229, DateTimeKind.Local).AddTicks(3495), new DateTime(2020, 9, 19, 0, 43, 10, 229, DateTimeKind.Local).AddTicks(7018) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("50ed6547-084e-480c-be7d-4ccece84958e"));

            migrationBuilder.InsertData(
                table: "Institute",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "ModifyDate", "RowVersion", "Title" },
                values: new object[] { new Guid("134b88af-218c-4674-80c0-7ab2be535a1c"), new DateTime(2020, 9, 19, 0, 22, 31, 480, DateTimeKind.Local).AddTicks(7562), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Default" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 19, 0, 22, 31, 463, DateTimeKind.Local).AddTicks(6866), new DateTime(2020, 9, 19, 0, 22, 31, 463, DateTimeKind.Local).AddTicks(6992) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 19, 0, 22, 31, 472, DateTimeKind.Local).AddTicks(785), new DateTime(2020, 9, 19, 0, 22, 31, 472, DateTimeKind.Local).AddTicks(807) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 19, 0, 22, 31, 450, DateTimeKind.Local).AddTicks(5054), new DateTime(2020, 9, 19, 0, 22, 31, 450, DateTimeKind.Local).AddTicks(8782) });
        }
    }
}
