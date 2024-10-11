using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class storedpreceduremigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllPatient = @"CREATE PROCEDURE [dbo].[GetAllPatient] AS BEGIN SELECT * FROM [dbo].[Patient] END";
            migrationBuilder.Sql(sp_GetAllPatient);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
