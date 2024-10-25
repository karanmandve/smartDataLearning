using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateTablenamemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_states_Countries_CountryId",
                table: "states");

            migrationBuilder.DropPrimaryKey(
                name: "PK_states",
                table: "states");

            migrationBuilder.RenameTable(
                name: "states",
                newName: "States");

            migrationBuilder.RenameIndex(
                name: "IX_states_CountryId",
                table: "States",
                newName: "IX_States_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "states");

            migrationBuilder.RenameIndex(
                name: "IX_States_CountryId",
                table: "states",
                newName: "IX_states_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_states",
                table: "states",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_states_Countries_CountryId",
                table: "states",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
