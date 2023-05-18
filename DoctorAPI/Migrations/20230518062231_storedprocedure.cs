using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorAPI.Migrations
{
    public partial class storedprocedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp1 = @"CREATE OR ALTER PROCEDURE [dbo].[GetDoctorList]
            AS
            BEGIN
	            SELECT * FROM dbo.Doctors
            END";
            migrationBuilder.Sql(sp1);

            var sp2 = @"CREATE OR ALTER PROCEDURE [dbo].[GetDoctorByID]
            @DoctorId int
            AS
            BEGIN
	            SELECT
		            DoctorId,
		            FirstName,
		            LastName,
		            Specialization
	            FROM dbo.Doctors where DoctorId = @DoctorId
            END";
            migrationBuilder.Sql(sp2);

            var sp3 = @"CREATE OR ALTER PROCEDURE [dbo].[AddNewDoctor]
            @FirstName [nvarchar](max),
            @LastName [nvarchar](max),
            @Specialization [nvarchar](max)
            AS
            BEGIN
	            INSERT INTO dbo.Doctors
		            (
			           FirstName,
		               LastName,
		               Specialization
		            )
                VALUES
		            (
			            @FirstName,
			            @LastName,
			            @Specialization
		            )
            END";
            migrationBuilder.Sql(sp3);

            var sp4 = @"CREATE OR ALTER PROCEDURE [dbo].[UpdateDoctor]
            @DoctorId int,
            @FirstName [nvarchar](max),
            @LastName [nvarchar](max),
            @Specialization [nvarchar](max)
            AS
            BEGIN
	            UPDATE dbo.Doctors
                SET
		            FirstName = @FirstName,
                    LastName = @LastName,
		            Specialization = @Specialization
	            WHERE DoctorId = @DoctorId
            END";
            migrationBuilder.Sql(sp4);

            var sp5 = @"CREATE OR ALTER PROCEDURE [dbo].[DeleteDoctorByID]
            @DoctorId int
            AS
            BEGIN
	            DELETE FROM dbo.Doctors where DoctorId = @DoctorId
            END";
            migrationBuilder.Sql(sp5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp1 = @"DROP PROCEDURE [dbo].[GetDoctorList]";

            migrationBuilder.Sql(sp1);

            var sp2 = @"DROP PROCEDURE [dbo].[GetDoctorByID]";

            migrationBuilder.Sql(sp2);

            var sp3 = @"DROP PROCEDURE [dbo].[AddNewDoctor]";

            migrationBuilder.Sql(sp3);

            var sp4 = @"DROP PROCEDURE [dbo].[UpdateDoctor]";

            migrationBuilder.Sql(sp4);

            var sp5 = @"DROP PROCEDURE [dbo].[DeleteDoctorByID]";

            migrationBuilder.Sql(sp5);
        }
    }
}
