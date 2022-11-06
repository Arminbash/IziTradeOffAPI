using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IziTradeOff.Persistence.Migrations
{
    public partial class TablePersona20221102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tipo_cliente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    estado = table.Column<bool>(nullable: false),
                    tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tipo_cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_persona",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    estado = table.Column<bool>(nullable: false),
                    tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tipo_persona", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    estado = table.Column<bool>(nullable: false),
                    primer_nombre = table.Column<string>(nullable: true),
                    segundo_nombre = table.Column<string>(nullable: true),
                    primer_apellido = table.Column<string>(nullable: true),
                    segundo_apellido = table.Column<string>(nullable: true),
                    correo = table.Column<string>(nullable: true),
                    cedula = table.Column<string>(nullable: true),
                    direccion = table.Column<string>(nullable: true),
                    telefono = table.Column<int>(nullable: false),
                    tipo_persona_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_persona", x => x.id);
                    table.ForeignKey(
                        name: "FK_persona_tipo_persona_tipo_persona_id",
                        column: x => x.tipo_persona_id,
                        principalTable: "tipo_persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    estado = table.Column<bool>(nullable: false),
                    persona_id = table.Column<int>(nullable: false),
                    tipo_cliente_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_cliente_persona_persona_id",
                        column: x => x.persona_id,
                        principalTable: "persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cliente_tipo_cliente_tipo_cliente_id",
                        column: x => x.tipo_cliente_id,
                        principalTable: "tipo_cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "empleado",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    estado = table.Column<bool>(nullable: false),
                    persona_id = table.Column<int>(nullable: false),
                    fecha_ingreso = table.Column<DateTime>(nullable: true),
                    cargo = table.Column<string>(nullable: true),
                    numero_licencia = table.Column<string>(nullable: true),
                    foto = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_empleado", x => x.id);
                    table.ForeignKey(
                        name: "FK_empleado_persona_persona_id",
                        column: x => x.persona_id,
                        principalTable: "persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_cliente_persona_id",
                table: "cliente",
                column: "persona_id");

            migrationBuilder.CreateIndex(
                name: "ix_cliente_tipo_cliente_id",
                table: "cliente",
                column: "tipo_cliente_id");

            migrationBuilder.CreateIndex(
                name: "ix_empleado_persona_id",
                table: "empleado",
                column: "persona_id");

            migrationBuilder.CreateIndex(
                name: "ix_persona_tipo_persona_id",
                table: "persona",
                column: "tipo_persona_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "empleado");

            migrationBuilder.DropTable(
                name: "tipo_cliente");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "tipo_persona");
        }
    }
}
