using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _091820204 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("ffe66661-4fb0-4ea6-89f9-001b586466f7"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("134b88af-218c-4674-80c0-7ab2be535a1c"));

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
    }
}
