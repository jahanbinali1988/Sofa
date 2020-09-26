using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    public partial class _092620201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WebsiteUrl",
                table: "Institute",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RowVersion = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    InstituteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Field_Institute_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 26, 15, 44, 15, 480, DateTimeKind.Local).AddTicks(3835), new DateTime(2020, 9, 26, 15, 44, 15, 480, DateTimeKind.Local).AddTicks(3969) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 26, 15, 44, 15, 488, DateTimeKind.Local).AddTicks(7965), new DateTime(2020, 9, 26, 15, 44, 15, 488, DateTimeKind.Local).AddTicks(7986) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 26, 15, 44, 15, 462, DateTimeKind.Local).AddTicks(8951), new DateTime(2020, 9, 26, 15, 44, 15, 463, DateTimeKind.Local).AddTicks(2544) });

            migrationBuilder.CreateIndex(
                name: "IX_Field_InstituteId",
                table: "Field",
                column: "InstituteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropColumn(
                name: "WebsiteUrl",
                table: "Institute");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 18, 2, 20, 89, DateTimeKind.Local).AddTicks(42), new DateTime(2020, 9, 22, 18, 2, 20, 89, DateTimeKind.Local).AddTicks(167) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 18, 2, 20, 97, DateTimeKind.Local).AddTicks(3493), new DateTime(2020, 9, 22, 18, 2, 20, 97, DateTimeKind.Local).AddTicks(3517) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2020, 9, 22, 18, 2, 20, 76, DateTimeKind.Local).AddTicks(4956), new DateTime(2020, 9, 22, 18, 2, 20, 76, DateTimeKind.Local).AddTicks(9029) });
        }
    }
}
