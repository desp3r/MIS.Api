using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS.Data.Migrations
{
    public partial class EmployeeAddSpecialtyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SpecialtyId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Employees");
        }
    }
}
