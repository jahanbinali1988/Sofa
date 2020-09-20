using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _091820201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DeleteData(
                table: "Institute",
                keyColumn: "Id",
                keyValue: new Guid("8ff36325-d87d-4b3e-b348-f3757ca9f8b7"));

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Institute",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Institute",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Institute",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Institute",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_ZipCode",
                table: "Institute",
                type: "nvarchar(max)",
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
    }
}
