using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarefas.Migrations
{
    public partial class IncluirOwnerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DataConclusao",
                table: "Tarefas",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Tarefas",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Tarefas");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DataConclusao",
                table: "Tarefas",
                nullable: true,
                oldClrType: typeof(DateTimeOffset));
        }
    }
}
