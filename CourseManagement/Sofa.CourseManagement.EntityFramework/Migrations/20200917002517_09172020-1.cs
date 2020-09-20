using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _091720201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DeleteData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("4091cdfe-3d31-4fc1-973e-bd76037fb8ed"));

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

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 17, 4, 55, 16, 627, DateTimeKind.Local).AddTicks(5688), new DateTime(2020, 9, 17, 4, 55, 16, 627, DateTimeKind.Local).AddTicks(5845) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 17, 4, 55, 16, 641, DateTimeKind.Local).AddTicks(8126), new DateTime(2020, 9, 17, 4, 55, 16, 641, DateTimeKind.Local).AddTicks(8209) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 17, 4, 55, 16, 606, DateTimeKind.Local).AddTicks(7967), new DateTime(2020, 9, 17, 4, 55, 16, 607, DateTimeKind.Local).AddTicks(3429) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                    InstituteId = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => new { x.InstituteId, x.City, x.ZipCode });
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
                values: new object[] { new Guid("4091cdfe-3d31-4fc1-973e-bd76037fb8ed"), new DateTime(2020, 9, 16, 15, 26, 46, 61, DateTimeKind.Local).AddTicks(1136), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Default" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 16, 15, 26, 46, 41, DateTimeKind.Local).AddTicks(5921), new DateTime(2020, 9, 16, 15, 26, 46, 41, DateTimeKind.Local).AddTicks(5980) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 16, 15, 26, 46, 51, DateTimeKind.Local).AddTicks(6796), new DateTime(2020, 9, 16, 15, 26, 46, 51, DateTimeKind.Local).AddTicks(6837) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 16, 15, 26, 46, 28, DateTimeKind.Local).AddTicks(143), new DateTime(2020, 9, 16, 15, 26, 46, 28, DateTimeKind.Local).AddTicks(2378) });
        }
    }
}
