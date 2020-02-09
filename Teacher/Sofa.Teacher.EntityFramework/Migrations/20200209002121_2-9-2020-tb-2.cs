using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.Teacher.EntityFramework.Migrations
{
    public partial class _292020tb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "User",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 2, 9, 3, 51, 21, 19, DateTimeKind.Local).AddTicks(1070), new DateTime(2020, 2, 9, 3, 51, 21, 19, DateTimeKind.Local).AddTicks(1110) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 2, 9, 3, 51, 21, 19, DateTimeKind.Local).AddTicks(1142), new DateTime(2020, 2, 9, 3, 51, 21, 19, DateTimeKind.Local).AddTicks(1145) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 2, 9, 3, 51, 21, 18, DateTimeKind.Local).AddTicks(3433), new DateTime(2020, 2, 9, 3, 51, 21, 18, DateTimeKind.Local).AddTicks(7277) });

            migrationBuilder.CreateIndex(
                name: "IX_User_CourseId",
                table: "User",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Course_CourseId",
                table: "User",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Course_CourseId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CourseId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "User");

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
    }
}
