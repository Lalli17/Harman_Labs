using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentEnrollment.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentEnrollments_courses_CourseId",
                table: "studentEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_studentEnrollments_students_StudentId",
                table: "studentEnrollments");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropIndex(
                name: "IX_studentEnrollments_CourseId",
                table: "studentEnrollments");

            migrationBuilder.DropIndex(
                name: "IX_studentEnrollments_StudentId",
                table: "studentEnrollments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.StudentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentEnrollments_CourseId",
                table: "studentEnrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_studentEnrollments_StudentId",
                table: "studentEnrollments",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentEnrollments_courses_CourseId",
                table: "studentEnrollments",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_studentEnrollments_students_StudentId",
                table: "studentEnrollments",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
