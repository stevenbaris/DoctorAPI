using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorAPI.Migrations
{
    public partial class storedprocedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp1 = @"CREATE OR ALTER PROCEDURE [dbo].[GetAllDoctor]
            AS
            BEGIN
	            SELECT * FROM dbo.Doctors
            END";
            migrationBuilder.Sql(sp1);

            var sp2 = @"CREATE OR ALTER PROCEDURE [dbo].[GetDoctorById]
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

            var sp3 = @"CREATE OR ALTER PROCEDURE [dbo].[AddDoctor]
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

            var sp5 = @"CREATE OR ALTER PROCEDURE [dbo].[DeleteDoctor]
            @DoctorId int
            AS
            BEGIN
                SELECT
		            DoctorId,
		            FirstName,
		            LastName,
		            Specialization
	            FROM dbo.Doctors where DoctorId = @DoctorId
	            DELETE FROM dbo.Doctors where DoctorId = @DoctorId
            END";
            migrationBuilder.Sql(sp5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp1 = @"DROP PROCEDURE [dbo].[GetAllDoctor]";

            migrationBuilder.Sql(sp1);

            var sp2 = @"DROP PROCEDURE [dbo].[GetDoctorByID]";

            migrationBuilder.Sql(sp2);

            var sp3 = @"DROP PROCEDURE [dbo].[AddDoctor]";

            migrationBuilder.Sql(sp3);

            var sp4 = @"DROP PROCEDURE [dbo].[UpdateDoctor]";

            migrationBuilder.Sql(sp4);

            var sp5 = @"DROP PROCEDURE [dbo].[DeleteDoctor]";

            migrationBuilder.Sql(sp5);
        }
    }
}