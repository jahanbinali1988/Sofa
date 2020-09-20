using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _091820202 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("8ff36325-d87d-4b3e-b348-f3757ca9f8b7"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 18, 23, 49, 49, 493, DateTimeKind.Local).AddTicks(8484), new DateTime(2020, 9, 18, 23, 49, 49, 493, DateTimeKind.Local).AddTicks(8673) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 18, 23, 49, 49, 505, DateTimeKind.Local).AddTicks(3794), new DateTime(2020, 9, 18, 23, 49, 49, 505, DateTimeKind.Local).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 18, 23, 49, 49, 475, DateTimeKind.Local).AddTicks(5188), new DateTime(2020, 9, 18, 23, 49, 49, 476, DateTimeKind.Local).AddTicks(828) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Institute",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "ModifyDate", "RowVersion", "Title" },
                values: new object[] { new Guid("8ff36325-d87d-4b3e-b348-f3757ca9f8b7"), new DateTime(2020, 9, 18, 22, 46, 32, 916, DateTimeKind.Local).AddTicks(9173), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Default" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 18, 22, 46, 32, 900, DateTimeKind.Local).AddTicks(371), new DateTime(2020, 9, 18, 22, 46, 32, 900, DateTimeKind.Local).AddTicks(510) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 18, 22, 46, 32, 908, DateTimeKind.Local).AddTicks(4939), new DateTime(2020, 9, 18, 22, 46, 32, 908, DateTimeKind.Local).AddTicks(4959) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 18, 22, 46, 32, 887, DateTimeKind.Local).AddTicks(576), new DateTime(2020, 9, 18, 22, 46, 32, 887, DateTimeKind.Local).AddTicks(4645) });
        }
    }
}
