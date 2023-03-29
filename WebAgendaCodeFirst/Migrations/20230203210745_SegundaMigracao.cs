using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAgendaCodeFirst.Migrations
{
    public partial class SegundaMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Procedimentos_ProcedimentoId",
                table: "Agendamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Procedimentos",
                table: "Procedimentos");

            migrationBuilder.RenameTable(
                name: "Procedimentos",
                newName: "procedimento");

            migrationBuilder.AlterColumn<float>(
                name: "Valor",
                table: "procedimento",
                type: "FLOAT(5)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "procedimento",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_procedimento",
                table: "procedimento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_procedimento_ProcedimentoId",
                table: "Agendamentos",
                column: "ProcedimentoId",
                principalTable: "procedimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_procedimento_ProcedimentoId",
                table: "Agendamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_procedimento",
                table: "procedimento");

            migrationBuilder.RenameTable(
                name: "procedimento",
                newName: "Procedimentos");

            migrationBuilder.AlterColumn<float>(
                name: "Valor",
                table: "Procedimentos",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "FLOAT(5)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Procedimentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procedimentos",
                table: "Procedimentos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Procedimentos_ProcedimentoId",
                table: "Agendamentos",
                column: "ProcedimentoId",
                principalTable: "Procedimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
