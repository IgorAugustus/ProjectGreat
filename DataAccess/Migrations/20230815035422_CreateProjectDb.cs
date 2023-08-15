using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateProjectDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassLeaves",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassLeaves", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypes",
                columns: table => new
                {
                    LeaveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypes", x => x.LeaveId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    LeaveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_ClassLeaves_ClassId",
                        column: x => x.ClassId,
                        principalTable: "ClassLeaves",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_LeaveTypes_LeaveId",
                        column: x => x.LeaveId,
                        principalTable: "LeaveTypes",
                        principalColumn: "LeaveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClassLeaves",
                columns: new[] { "ClassId", "Name" },
                values: new object[,]
                {
                    { 1, "Class .NET01" },
                    { 2, "Class .NET02" },
                    { 3, "Class .JAVA01" },
                    { 4, "Class .JAVA02" }
                });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "LeaveId", "LeaveName" },
                values: new object[,]
                {
                    { 1, "Late Coming" },
                    { 2, "Early Leave" },
                    { 3, "Leave a haft of day" },
                    { 4, "Leave one day" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "ClassId", "LeaveDate", "LeaveId", "Reason", "Status", "StudentName", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "No way", "Nothing", "Phan Anh", "AAA" },
                    { 2, 2, new DateTime(2022, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "No way", "Nothing", "La Tuan", "AAC" },
                    { 3, 3, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "No way", "Nothing", "Ton Nguyen", "BBB" },
                    { 4, 4, new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "No way", "Nothing", "Luu Bi", "CCC" },
                    { 5, 1, new DateTime(2020, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "No money", "Nothing", "Tao Thao", "DDD" },
                    { 6, 4, new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "No time", "Nothing", "Bang Thong", "EEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_LeaveId",
                table: "Students",
                column: "LeaveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "ClassLeaves");

            migrationBuilder.DropTable(
                name: "LeaveTypes");
        }
    }
}
