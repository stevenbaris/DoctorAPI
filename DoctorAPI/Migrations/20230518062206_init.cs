using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "FirstName", "LastName", "Specialization" },
                values: new object[] { 1, "Maria", "Clara", "Opthamologist" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "FirstName", "LastName", "Specialization" },
                values: new object[] { 2, "Juan", "Cruz", "Neurologist" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "FirstName", "LastName", "Specialization" },
                values: new object[] { 3, "Tim", "Hortons", "Surgeon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
