using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Matricula.BD.Migrations
{
    public partial class indices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Especialidades_EspecialidadId",
                table: "Matricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Medicos_MedicoId",
                table: "Matricula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matricula",
                table: "Matricula");

            migrationBuilder.DropIndex(
                name: "IX_Matricula_MedicoId",
                table: "Matricula");

            migrationBuilder.RenameTable(
                name: "Matricula",
                newName: "Matriculas");

            migrationBuilder.RenameIndex(
                name: "IX_Matricula_EspecialidadId",
                table: "Matriculas",
                newName: "IX_Matriculas_EspecialidadId");

            migrationBuilder.AlterColumn<string>(
                name: "NumMatricula",
                table: "Matriculas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matriculas",
                table: "Matriculas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "MatriculaMedicoIdEspecialidadId_UQ",
                table: "Matriculas",
                columns: new[] { "MedicoId", "EspecialidadId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Especialidades_EspecialidadId",
                table: "Matriculas",
                column: "EspecialidadId",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Medicos_MedicoId",
                table: "Matriculas",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Especialidades_EspecialidadId",
                table: "Matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Medicos_MedicoId",
                table: "Matriculas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matriculas",
                table: "Matriculas");

            migrationBuilder.DropIndex(
                name: "MatriculaMedicoIdEspecialidadId_UQ",
                table: "Matriculas");

            migrationBuilder.RenameTable(
                name: "Matriculas",
                newName: "Matricula");

            migrationBuilder.RenameIndex(
                name: "IX_Matriculas_EspecialidadId",
                table: "Matricula",
                newName: "IX_Matricula_EspecialidadId");

            migrationBuilder.AlterColumn<string>(
                name: "NumMatricula",
                table: "Matricula",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matricula",
                table: "Matricula",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_MedicoId",
                table: "Matricula",
                column: "MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Especialidades_EspecialidadId",
                table: "Matricula",
                column: "EspecialidadId",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Medicos_MedicoId",
                table: "Matricula",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
