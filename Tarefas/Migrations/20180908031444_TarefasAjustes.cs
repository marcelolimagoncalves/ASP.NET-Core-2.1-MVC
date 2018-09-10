using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarefas.Migrations
{
    public partial class TarefasAjustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Tarefas",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.DropPrimaryKey(name: "PK_Tarefas", table:"Tarefas");
            migrationBuilder.DropColumn(name: "id", table: "Tarefas");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tarefas",
                nullable: false,
                type: "int")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            migrationBuilder.AddPrimaryKey(name: "PK_Tarefas", table: "Tarefas", column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Tarefas",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.DropPrimaryKey(name: "PK_Tarefas", table:"Tarefas");
            migrationBuilder.DropColumn(name: "Id", table: "Tarefas");
            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Tarefas",
                nullable: false,
                type: "int")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            migrationBuilder.AddPrimaryKey(name: "PK_Tarefas", table: "Tarefas", column: "id");
        }
    }
}
