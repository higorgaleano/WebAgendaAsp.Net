using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAgendaCodeFirst.Migrations
{
    public partial class Obs_Adicionado_em_Agendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_cliente_ClienteId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_procedimento_ProcedimentoId",
                table: "Agendamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agendamentos",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "Concluido",
                table: "Agendamentos");

            migrationBuilder.RenameTable(
                name: "Agendamentos",
                newName: "agendamento");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamentos_ProcedimentoId",
                table: "agendamento",
                newName: "IX_agendamento_ProcedimentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamentos_ClienteId",
                table: "agendamento",
                newName: "IX_agendamento_ClienteId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "procedimento",
                type: "Decimal(6,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "FLOAT(5)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "agendamento",
                type: "Decimal(6,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "ProcedimentoId",
                table: "agendamento",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "agendamento",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "agendamento",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "agendamento",
                type: "VARCHAR(25)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_agendamento",
                table: "agendamento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_agendamento_cliente_ClienteId",
                table: "agendamento",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_agendamento_procedimento_ProcedimentoId",
                table: "agendamento",
                column: "ProcedimentoId",
                principalTable: "procedimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agendamento_cliente_ClienteId",
                table: "agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_agendamento_procedimento_ProcedimentoId",
                table: "agendamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_agendamento",
                table: "agendamento");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "agendamento");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "agendamento");

            migrationBuilder.RenameTable(
                name: "agendamento",
                newName: "Agendamentos");

            migrationBuilder.RenameIndex(
                name: "IX_agendamento_ProcedimentoId",
                table: "Agendamentos",
                newName: "IX_Agendamentos_ProcedimentoId");

            migrationBuilder.RenameIndex(
                name: "IX_agendamento_ClienteId",
                table: "Agendamentos",
                newName: "IX_Agendamentos_ClienteId");

            migrationBuilder.AlterColumn<float>(
                name: "Valor",
                table: "procedimento",
                type: "FLOAT(5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(6,2)");

            migrationBuilder.AlterColumn<float>(
                name: "Valor",
                table: "Agendamentos",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(6,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ProcedimentoId",
                table: "Agendamentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Agendamentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Concluido",
                table: "Agendamentos",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agendamentos",
                table: "Agendamentos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_cliente_ClienteId",
                table: "Agendamentos",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_procedimento_ProcedimentoId",
                table: "Agendamentos",
                column: "ProcedimentoId",
                principalTable: "procedimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
