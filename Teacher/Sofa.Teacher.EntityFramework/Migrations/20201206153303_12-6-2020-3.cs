using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.Teacher.EntityFramework.Migrations
{
    public partial class _12620203 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Syllabus_LessonPlanId",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Syllabus",
                table: "Syllabus");

            migrationBuilder.RenameTable(
                name: "Syllabus",
                newName: "LessonPlan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonPlan",
                table: "LessonPlan",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 6, 19, 3, 2, 749, DateTimeKind.Local).AddTicks(5004));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 6, 19, 3, 2, 749, DateTimeKind.Local).AddTicks(6803));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 6, 19, 3, 2, 746, DateTimeKind.Local).AddTicks(8018));

            migrationBuilder.AddForeignKey(
                name: "FK_Post_LessonPlan_LessonPlanId",
                table: "Post",
                column: "LessonPlanId",
                principalTable: "LessonPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_LessonPlan_LessonPlanId",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonPlan",
                table: "LessonPlan");

            migrationBuilder.RenameTable(
                name: "LessonPlan",
                newName: "Syllabus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Syllabus",
                table: "Syllabus",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 6, 18, 46, 37, 185, DateTimeKind.Local).AddTicks(2877));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 6, 18, 46, 37, 185, DateTimeKind.Local).AddTicks(3930));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 6, 18, 46, 37, 183, DateTimeKind.Local).AddTicks(6455));

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Syllabus_LessonPlanId",
                table: "Post",
                column: "LessonPlanId",
                principalTable: "Syllabus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
