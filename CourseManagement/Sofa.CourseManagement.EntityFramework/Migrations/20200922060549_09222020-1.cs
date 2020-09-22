using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _092220201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("e431950d-deec-4b9b-9fd2-1b897d7c08d1"));

            migrationBuilder.InsertData(
                table: "Institute",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "ModifyDate", "RowVersion", "Title" },
                values: new object[] { new Guid("c224f75f-1156-47a7-a944-17a239af0618"), new DateTime(2020, 9, 22, 9, 35, 47, 535, DateTimeKind.Local).AddTicks(5081), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Default" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 9, 35, 47, 518, DateTimeKind.Local).AddTicks(1962), new DateTime(2020, 9, 22, 9, 35, 47, 518, DateTimeKind.Local).AddTicks(2095) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 9, 35, 47, 526, DateTimeKind.Local).AddTicks(8660), new DateTime(2020, 9, 22, 9, 35, 47, 526, DateTimeKind.Local).AddTicks(8690) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 9, 35, 47, 494, DateTimeKind.Local).AddTicks(9848), new DateTime(2020, 9, 22, 9, 35, 47, 495, DateTimeKind.Local).AddTicks(3287) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("c224f75f-1156-47a7-a944-17a239af0618"));

            migrationBuilder.InsertData(
                table: "Institute",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "ModifyDate", "RowVersion", "Title" },
                values: new object[] { new Guid("e431950d-deec-4b9b-9fd2-1b897d7c08d1"), new DateTime(2020, 9, 21, 16, 52, 4, 190, DateTimeKind.Local).AddTicks(9242), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Default" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 21, 16, 52, 4, 171, DateTimeKind.Local).AddTicks(7721), new DateTime(2020, 9, 21, 16, 52, 4, 171, DateTimeKind.Local).AddTicks(7839) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 21, 16, 52, 4, 181, DateTimeKind.Local).AddTicks(6421), new DateTime(2020, 9, 21, 16, 52, 4, 181, DateTimeKind.Local).AddTicks(6483) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 21, 16, 52, 4, 159, DateTimeKind.Local).AddTicks(3286), new DateTime(2020, 9, 21, 16, 52, 4, 159, DateTimeKind.Local).AddTicks(6836) });
        }
    }
}
