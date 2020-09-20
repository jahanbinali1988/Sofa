using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _092020201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("73400994-2d74-49b7-ba3e-fcfad82ec45e"));

            migrationBuilder.InsertData(
                table: "Institute",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "ModifyDate", "RowVersion", "Title" },
                values: new object[] { new Guid("eab09285-ae8b-4396-b041-32a3e60d5512"), new DateTime(2020, 9, 20, 15, 17, 9, 698, DateTimeKind.Local).AddTicks(9692), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Default" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 20, 15, 17, 9, 680, DateTimeKind.Local).AddTicks(9728), new DateTime(2020, 9, 20, 15, 17, 9, 680, DateTimeKind.Local).AddTicks(9899) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 20, 15, 17, 9, 689, DateTimeKind.Local).AddTicks(4050), new DateTime(2020, 9, 20, 15, 17, 9, 689, DateTimeKind.Local).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 20, 15, 17, 9, 668, DateTimeKind.Local).AddTicks(2410), new DateTime(2020, 9, 20, 15, 17, 9, 668, DateTimeKind.Local).AddTicks(5908) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("eab09285-ae8b-4396-b041-32a3e60d5512"));

            migrationBuilder.InsertData(
                table: "Institute",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "ModifyDate", "RowVersion", "Title" },
                values: new object[] { new Guid("73400994-2d74-49b7-ba3e-fcfad82ec45e"), new DateTime(2020, 9, 19, 16, 48, 34, 732, DateTimeKind.Local).AddTicks(3413), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Default" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 19, 16, 48, 34, 713, DateTimeKind.Local).AddTicks(8014), new DateTime(2020, 9, 19, 16, 48, 34, 713, DateTimeKind.Local).AddTicks(8167) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 19, 16, 48, 34, 722, DateTimeKind.Local).AddTicks(6282), new DateTime(2020, 9, 19, 16, 48, 34, 722, DateTimeKind.Local).AddTicks(6303) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 19, 16, 48, 34, 698, DateTimeKind.Local).AddTicks(7012), new DateTime(2020, 9, 19, 16, 48, 34, 699, DateTimeKind.Local).AddTicks(979) });
        }
    }
}
