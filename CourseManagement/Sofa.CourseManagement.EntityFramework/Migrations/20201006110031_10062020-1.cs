using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _100620201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostType",
                table: "Post");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Term",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Session",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Post",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContentType",
                table: "Post",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Post",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LessonPlan",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Institute",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Field",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "AgeRange",
                table: "Course",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Course",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: new Guid("b70d992c-2b43-496a-9981-3578e2d0ec4c"),
                columns: new[] { "AgeRange", "CreateDate" },
                values: new object[] { 2, new DateTime(2020, 10, 6, 14, 30, 30, 659, DateTimeKind.Local).AddTicks(3468) });

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: new Guid("ccdd20d4-b2a0-455a-8f7a-168503776b82"),
                column: "CreateDate",
                value: new DateTime(2020, 10, 6, 14, 30, 30, 658, DateTimeKind.Local).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("e9a52e3d-27aa-4726-a1a9-bf90b6cc2357"),
                columns: new[] { "Code", "CreateDate" },
                values: new object[] { "65479c12-0fbc-4c78-862a-1872a4021797", new DateTime(2020, 10, 6, 14, 30, 30, 658, DateTimeKind.Local).AddTicks(1996) });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: new Guid("b0108b2c-5837-4f22-b78d-857bc22f9554"),
                columns: new[] { "Content", "CreateDate", "Description" },
                values: new object[] { "Sample Content", new DateTime(2020, 10, 6, 14, 30, 30, 661, DateTimeKind.Local).AddTicks(4878), "" });

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: new Guid("49f4c5f7-d568-449c-9b5f-4d5b987e1e59"),
                columns: new[] { "CreateDate", "Description" },
                values: new object[] { new DateTime(2020, 10, 6, 14, 30, 30, 660, DateTimeKind.Local).AddTicks(7220), "" });

            migrationBuilder.UpdateData(
                table: "Term",
                keyColumn: "Id",
                keyValue: new Guid("21b8dc7f-9d87-409d-9ec1-46287e7a6559"),
                columns: new[] { "CreateDate", "Description" },
                values: new object[] { new DateTime(2020, 10, 6, 14, 30, 30, 659, DateTimeKind.Local).AddTicks(8310), "" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "Email", "ModifyDate" },
                values: new object[] { new DateTime(2020, 10, 6, 14, 30, 30, 649, DateTimeKind.Local).AddTicks(4077), "jahanbin.ali1988@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "Email", "ModifyDate", "Role", "UserName" },
                values: new object[] { new DateTime(2020, 10, 6, 14, 30, 30, 657, DateTimeKind.Local).AddTicks(8354), "jahanbin.ali1988@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "sysadmin" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "Level", "ModifyDate" },
                values: new object[] { new DateTime(2020, 10, 6, 14, 30, 30, 640, DateTimeKind.Local).AddTicks(5273), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Term");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LessonPlan");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Institute");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Course");

            migrationBuilder.AddColumn<int>(
                name: "PostType",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "AgeRange",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: new Guid("b70d992c-2b43-496a-9981-3578e2d0ec4c"),
                columns: new[] { "AgeRange", "CreateDate" },
                values: new object[] { "", new DateTime(2020, 9, 30, 0, 38, 57, 750, DateTimeKind.Local).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: new Guid("ccdd20d4-b2a0-455a-8f7a-168503776b82"),
                column: "CreateDate",
                value: new DateTime(2020, 9, 30, 0, 38, 57, 749, DateTimeKind.Local).AddTicks(8035));

            migrationBuilder.UpdateData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("e9a52e3d-27aa-4726-a1a9-bf90b6cc2357"),
                columns: new[] { "Code", "CreateDate" },
                values: new object[] { "0daffaaa-037e-44da-bd14-254262138acc", new DateTime(2020, 9, 30, 0, 38, 57, 749, DateTimeKind.Local).AddTicks(2752) });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: new Guid("b0108b2c-5837-4f22-b78d-857bc22f9554"),
                columns: new[] { "CreateDate", "Description" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: new Guid("49f4c5f7-d568-449c-9b5f-4d5b987e1e59"),
                columns: new[] { "CreateDate", "Description" },
                values: new object[] { new DateTime(2020, 9, 30, 0, 38, 57, 751, DateTimeKind.Local).AddTicks(6496), null });

            migrationBuilder.UpdateData(
                table: "Term",
                keyColumn: "Id",
                keyValue: new Guid("21b8dc7f-9d87-409d-9ec1-46287e7a6559"),
                columns: new[] { "CreateDate", "Description" },
                values: new object[] { new DateTime(2020, 9, 30, 0, 38, 57, 750, DateTimeKind.Local).AddTicks(7455), null });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "Email", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 30, 0, 38, 57, 731, DateTimeKind.Local).AddTicks(3369), "jahanbinali88@yahoo.com", new DateTime(2020, 9, 30, 0, 38, 57, 731, DateTimeKind.Local).AddTicks(3506) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "Email", "ModifyDate", "Role", "UserName" },
                values: new object[] { new DateTime(2020, 9, 30, 0, 38, 57, 740, DateTimeKind.Local).AddTicks(1739), "jahanbin.ali1988@yahoo.com", new DateTime(2020, 9, 30, 0, 38, 57, 740, DateTimeKind.Local).AddTicks(1792), 1, "student" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "Level", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 30, 0, 38, 57, 718, DateTimeKind.Local).AddTicks(6801), 2, new DateTime(2020, 9, 30, 0, 38, 57, 719, DateTimeKind.Local).AddTicks(638) });
        }
    }
}
