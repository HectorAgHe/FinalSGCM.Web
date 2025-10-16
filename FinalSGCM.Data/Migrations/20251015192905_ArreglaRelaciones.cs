using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalSGCM.Data.Migrations
{
    /// <inheritdoc />
    public partial class ArreglaRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Doctors_OfficeId",
                table: "Doctors");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_OfficeId",
                table: "Doctors",
                column: "OfficeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Doctors_OfficeId",
                table: "Doctors");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_OfficeId",
                table: "Doctors",
                column: "OfficeId",
                unique: true,
                filter: "[OfficeId] IS NOT NULL");
        }
    }
}
