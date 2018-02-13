using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PunkHouseReal.Data.Migrations
{
    public partial class Add_IsDividedUnevenly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDividedEvenly",
                table: "Expenses",
                newName: "IsDividedUnevenly");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDividedUnevenly",
                table: "Expenses",
                newName: "IsDividedEvenly");
        }
    }
}
