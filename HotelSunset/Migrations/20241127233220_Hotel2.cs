using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelSunset.Migrations
{
    /// <inheritdoc />
    public partial class Hotel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agregados",
                columns: table => new
                {
                    AgregadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Existencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agregados", x => x.AgregadoId);
                });

            migrationBuilder.CreateTable(
                name: "ArticulosExtras",
                columns: table => new
                {
                    ExtrasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Existencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticulosExtras", x => x.ExtrasId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoReserva = table.Column<bool>(type: "bit", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaId);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    ServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreServicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.ServicioId);
                });

            migrationBuilder.CreateTable(
                name: "TipoHabitaciones",
                columns: table => new
                {
                    TipoHabitacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHabitaciones", x => x.TipoHabitacionId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservasId = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_Reservas_ReservasId",
                        column: x => x.ReservasId,
                        principalTable: "Reservas",
                        principalColumn: "ReservaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservasDetalle",
                columns: table => new
                {
                    ReservaDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtrasId = table.Column<int>(type: "int", nullable: false),
                    ReservaId = table.Column<int>(type: "int", nullable: false),
                    ArticulosExtrasExtrasId = table.Column<int>(type: "int", nullable: true),
                    ReservasReservaId = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservasDetalle", x => x.ReservaDetalleId);
                    table.ForeignKey(
                        name: "FK_ReservasDetalle_ArticulosExtras_ArticulosExtrasExtrasId",
                        column: x => x.ArticulosExtrasExtrasId,
                        principalTable: "ArticulosExtras",
                        principalColumn: "ExtrasId");
                    table.ForeignKey(
                        name: "FK_ReservasDetalle_Reservas_ReservasReservaId",
                        column: x => x.ReservasReservaId,
                        principalTable: "Reservas",
                        principalColumn: "ReservaId");
                });

            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    HabitacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoHabitacionId = table.Column<int>(type: "int", nullable: false),
                    NumeroHabitacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    PrecioBase = table.Column<double>(type: "float", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    TipoHabitacionesTipoHabitacionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.HabitacionId);
                    table.ForeignKey(
                        name: "FK_Habitaciones_TipoHabitaciones_TipoHabitacionesTipoHabitacionId",
                        column: x => x.TipoHabitacionesTipoHabitacionId,
                        principalTable: "TipoHabitaciones",
                        principalColumn: "TipoHabitacionId");
                });

            migrationBuilder.CreateTable(
                name: "MetodoPago",
                columns: table => new
                {
                    MetodoPagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    NombresApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTarjeta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaExpiracion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoSeguridad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientesClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPago", x => x.MetodoPagoId);
                    table.ForeignKey(
                        name: "FK_MetodoPago_Clientes_ClientesClienteId",
                        column: x => x.ClientesClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId");
                });

            migrationBuilder.CreateTable(
                name: "HabitacionDetalle",
                columns: table => new
                {
                    HabitacionDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgregadoId = table.Column<int>(type: "int", nullable: false),
                    HabitacionId = table.Column<int>(type: "int", nullable: false),
                    AgregadosAgregadoId = table.Column<int>(type: "int", nullable: true),
                    HabitacionesHabitacionId = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitacionDetalle", x => x.HabitacionDetalleId);
                    table.ForeignKey(
                        name: "FK_HabitacionDetalle_Agregados_AgregadosAgregadoId",
                        column: x => x.AgregadosAgregadoId,
                        principalTable: "Agregados",
                        principalColumn: "AgregadoId");
                    table.ForeignKey(
                        name: "FK_HabitacionDetalle_Habitaciones_HabitacionesHabitacionId",
                        column: x => x.HabitacionesHabitacionId,
                        principalTable: "Habitaciones",
                        principalColumn: "HabitacionId");
                });

            migrationBuilder.CreateTable(
                name: "HabitacionesReservas",
                columns: table => new
                {
                    ReservasReservaId = table.Column<int>(type: "int", nullable: false),
                    habitacionesHabitacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitacionesReservas", x => new { x.ReservasReservaId, x.habitacionesHabitacionId });
                    table.ForeignKey(
                        name: "FK_HabitacionesReservas_Habitaciones_habitacionesHabitacionId",
                        column: x => x.habitacionesHabitacionId,
                        principalTable: "Habitaciones",
                        principalColumn: "HabitacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabitacionesReservas_Reservas_ReservasReservaId",
                        column: x => x.ReservasReservaId,
                        principalTable: "Reservas",
                        principalColumn: "ReservaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ReservasId",
                table: "Clientes",
                column: "ReservasId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionDetalle_AgregadosAgregadoId",
                table: "HabitacionDetalle",
                column: "AgregadosAgregadoId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionDetalle_HabitacionesHabitacionId",
                table: "HabitacionDetalle",
                column: "HabitacionesHabitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_TipoHabitacionesTipoHabitacionId",
                table: "Habitaciones",
                column: "TipoHabitacionesTipoHabitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionesReservas_habitacionesHabitacionId",
                table: "HabitacionesReservas",
                column: "habitacionesHabitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_MetodoPago_ClientesClienteId",
                table: "MetodoPago",
                column: "ClientesClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasDetalle_ArticulosExtrasExtrasId",
                table: "ReservasDetalle",
                column: "ArticulosExtrasExtrasId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasDetalle_ReservasReservaId",
                table: "ReservasDetalle",
                column: "ReservasReservaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "HabitacionDetalle");

            migrationBuilder.DropTable(
                name: "HabitacionesReservas");

            migrationBuilder.DropTable(
                name: "MetodoPago");

            migrationBuilder.DropTable(
                name: "ReservasDetalle");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Agregados");

            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "ArticulosExtras");

            migrationBuilder.DropTable(
                name: "TipoHabitaciones");

            migrationBuilder.DropTable(
                name: "Reservas");
        }
    }
}
