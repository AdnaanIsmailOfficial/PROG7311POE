using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;


namespace PROG7311POE.Data
{

    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('1', 'Farmer', 'FARMER')");
           
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('2', 'Employee', 'EMPLOYEE')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM AspNetRoles WHERE Name IN ('Farmer', 'Employee')");
        }
    }
}