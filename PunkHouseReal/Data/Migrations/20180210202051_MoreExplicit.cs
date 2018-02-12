using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PunkHouseReal.Data.Migrations
{
    public partial class MoreExplicit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Expenses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CreatorId",
                table: "Expenses",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_HouseId",
                table: "Expenses",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HouseId",
                table: "AspNetUsers",
                column: "HouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Houses_HouseId",
                table: "AspNetUsers",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_CreatorId",
                table: "Expenses",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Houses_HouseId",
                table: "Expenses",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Houses_HouseId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_CreatorId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Houses_HouseId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CreatorId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_HouseId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HouseId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Expenses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
