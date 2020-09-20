using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _091820203 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Institute",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "ModifyDate", "RowVersion", "Title" },
                values: new object[] { new Guid("ffe66661-4fb0-4ea6-89f9-001b586466f7"), new DateTime(2020, 9, 19, 0, 0, 25, 721, DateTimeKind.Local).AddTicks(7075), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Default" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 19, 0, 0, 25, 696, DateTimeKind.Local).AddTicks(9962), new DateTime(2020, 9, 19, 0, 0, 25, 697, DateTimeKind.Local).AddTicks(115) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 19, 0, 0, 25, 706, DateTimeKind.Local).AddTicks(6451), new DateTime(2020, 9, 19, 0, 0, 25, 706, DateTimeKind.Local).AddTicks(6509) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 19, 0, 0, 25, 682, DateTimeKind.Local).AddTicks(8395), new DateTime(2020, 9, 19, 0, 0, 25, 683, DateTimeKind.Local).AddTicks(2556) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("ffe66661-4fb0-4ea6-89f9-001b586466f7"));

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
    }
}
