using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _092220202 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DeleteData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("c224f75f-1156-47a7-a944-17a239af0618"));

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Institute",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Institute",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Institute",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Institute",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_ZipCode",
                table: "Institute",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Institute",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "ModifyDate", "RowVersion", "Title" },
                values: new object[] { new Guid("5f3a1b34-0310-4253-9f14-77ca67dff811"), new DateTime(2020, 9, 22, 10, 59, 39, 461, DateTimeKind.Local).AddTicks(3844), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Default" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 10, 59, 39, 442, DateTimeKind.Local).AddTicks(6167), new DateTime(2020, 9, 22, 10, 59, 39, 442, DateTimeKind.Local).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 10, 59, 39, 452, DateTimeKind.Local).AddTicks(151), new DateTime(2020, 9, 22, 10, 59, 39, 452, DateTimeKind.Local).AddTicks(182) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 10, 59, 39, 421, DateTimeKind.Local).AddTicks(9905), new DateTime(2020, 9, 22, 10, 59, 39, 422, DateTimeKind.Local).AddTicks(3617) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("5f3a1b34-0310-4253-9f14-77ca67dff811"));

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Institute");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Institute");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "Institute");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Institute");

            migrationBuilder.DropColumn(
                name: "Address_ZipCode",
                table: "Institute");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    InstituteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => new { x.InstituteId, x.Id });
                    table.ForeignKey(
                        name: "FK_Address_Institute_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
    }
}
