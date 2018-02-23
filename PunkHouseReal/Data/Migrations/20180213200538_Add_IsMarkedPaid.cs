using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PunkHouseReal.Data.Migrations
{
    public partial class Add_IsMarkedPaid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMarkedPaid",
                table: "HouseMateExpenses",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMarkedPaid",
                table: "HouseMateExpenses");
        }
    }
}
